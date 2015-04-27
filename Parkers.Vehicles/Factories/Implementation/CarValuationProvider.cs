// <copyright file="CarValuationProvider.cs" company="Bauer Consumer Media Limited">
//    Copyright 2012 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Parkers.Data;
    using StructureMap;

    #endregion

    /// <summary>
    /// Data access layer for used prices
    /// </summary>
    public class CarValuationProvider : ICarValuationProvider
    {
        #region Constants

        /// <summary>
        /// The year valutions are available from
        /// </summary>
        private const int ValuationsAvailableFromYear = 1991;

        /// <summary>
        /// the number of years prior to now for which free valuatuions are available
        /// </summary>
        private const int FreeValutionYears = 9;

        /// <summary>
        /// backfiled for valuations database
        /// </summary>
        private const string DatabaseName = "ParkersCAR";

        #endregion

        #region Fields

        /// <summary>
        /// backing field for year plate provider
        /// </summary>
        private static readonly IYearPlateProvider yearPlateProvider = ObjectFactory.GetInstance<IYearPlateProvider>();

        #endregion
        
        #region Methods

        /// <summary>
        /// Determines whether [is year plate available in section] [the specified plate id].
        /// </summary>
        /// <param name="plateId">The plate id.</param>
        /// <param name="section">The section.</param>
        /// <returns>
        ///   <c>true</c> if [is year plate available in section] [the specified plate id]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsYearPlateAvailableInSection(int plateId, CarValuationSection section)
        {
            return plateId >= GetFromYearPlateIdForSection(section) && plateId <= GetToYearPlateIdForSection(section);
        }

        /// <summary>
        /// Gets the plates by model id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <param name="section">The section.</param>
        /// <returns>List of year plates</returns>
        public List<IYearPlate> GetPlatesByModelId(int modelId, CarValuationSection section)
        {
            int sectionYearFromPlateId = GetFromYearPlateIdForSection(section);
            int sectionYearToPlateId = GetToYearPlateIdForSection(section);

            ICarModel model = CarModel.FromId(modelId);

            if (model.FromYearPlate == null || model.ToYearPlate == null)
            {
                return null;
            }

            int plateFrom = model.FromYearPlate.Id;
            int plateTo = model.ToYearPlate.Id;

            if (sectionYearFromPlateId > plateFrom)
            {
                plateFrom = sectionYearFromPlateId;
            }

            if (sectionYearToPlateId < plateTo)
            {
                plateTo = sectionYearToPlateId;
            }

            return yearPlateProvider.GetRange(plateFrom, plateTo);
        }

        /// <summary>
        /// Gets the plates by derivative id.
        /// </summary>
        /// <param name="derivative">The derivative.</param>
        /// <param name="section">The section.</param>
        /// <returns>List of year plates</returns>
        public List<IYearPlate> GetPlatesByDerivative(ICarDerivative derivative, CarValuationSection section)
        {
            int sectionYearFromPlateId = GetFromYearPlateIdForSection(section);
            int sectionYearToPlateId = GetToYearPlateIdForSection(section);
            
            if (derivative.FromYearPlate == null || derivative.ToYearPlate == null)
            {
                return null;
            }

            int plateFrom = derivative.FromYearPlate.Id;
            int plateTo = derivative.ToYearPlate.Id;

            if (sectionYearFromPlateId > plateFrom)
            {
                plateFrom = sectionYearFromPlateId;
            }

            if (sectionYearToPlateId < plateTo)
            {
                plateTo = sectionYearToPlateId;
            }

            return yearPlateProvider.GetRange(plateFrom, plateTo);
        }

        /// <summary>
        /// Gets the derivatives by model and plate id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <returns>List of car derivatives</returns>
        public List<ICarDerivative> GetDerivativesByModelAndPlateId(int modelId, int plateId)
        {
            Sproc sp = new Sproc("Used_Select_DerivsByModelAndPlate", DatabaseName);
            sp.Parameters.Add("@CARModId", SqlDbType.Int).Value = modelId;
            sp.Parameters.Add("@YearPlateId", SqlDbType.Int).Value = plateId;

            using (SqlDataReader reader = sp.ExecuteReader())
            {
                if (reader != null && reader.HasRows)
                {
                    List<ICarDerivative> result = new List<ICarDerivative>();
                    while (reader.Read())
                    {
                        result.Add(CarDerivative.FromId((int)reader["CARDerId"]));
                    }

                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the mileage adjusted valuation.
        /// </summary>
        /// <param name="derivId">The derivative id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <param name="mileage">The mileage.</param>
        /// <param name="section">The section.</param>
        /// <returns>The valuation</returns>
        public IValuation GetMileageAdjustedValuation(int derivId, int plateId, int mileage, CarValuationSection section)
        {
            Valuation valuation = new Valuation();
            PopulateMileageAdjustedValuation(derivId, plateId, mileage, section, valuation);
            if (valuation.Result == ValuationResultType.Error)
            {
                return null;
            }
            else
            {
                return valuation;
            }
        }

        /// <summary>
        /// Gets the valuation.
        /// </summary>
        /// <param name="derivId">The derivative id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <param name="section">The section.</param>
        /// <returns>The valuation</returns>
        public IValuation GetValuation(int derivId, int plateId, CarValuationSection section)
        {
            return this.GetMileageAdjustedValuation(derivId, plateId, 0, section);
        }

        /// <summary>
        /// Gets the option adjusted valuation.
        /// </summary>
        /// <param name="derivId">The derivative id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <param name="mileage">The mileage.</param>
        /// <param name="optionCodes">The option codes.</param>
        /// <param name="section">The section.</param>
        /// <returns>The valuation (with options)</returns>
        public IValuationWithOptions GetOptionAdjustedValuation(int derivId, int plateId, int mileage, int[] optionCodes, CarValuationSection section)
        {
            ValuationWithOptions valuation = new ValuationWithOptions();
            PopulateMileageAdjustedValuation(derivId, plateId, mileage, section, valuation);

            List<int> optionCodesList = new List<int>(optionCodes);
            List<IValuationOption> optionsList = this.GetAvailableOptions(derivId, plateId);
            if (optionsList != null)
            {
                foreach (IValuationOption option in optionsList)
                {
                    if (optionCodesList.Contains(option.OptionCode))
                    {
                        valuation.Options.Add(option);
                    }
                }
            }

            return valuation;
        }

        /// <summary>
        /// Gets the available options.
        /// </summary>
        /// <param name="derivId">The derivative id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <returns>List of valuation options</returns>
        public List<IValuationOption> GetAvailableOptions(int derivId, int plateId)
        {
            Sproc procedure = new Sproc("Used_Select_Options", DatabaseName);
            procedure.Parameters.Add("@CARDerId", SqlDbType.Int).Value = derivId;
            procedure.Parameters.Add("@YearPlateId", SqlDbType.Int).Value = plateId;

            using (SqlDataReader reader = procedure.ExecuteReader())
            {
                if (reader != null && reader.HasRows)
                {
                    List<IValuationOption> result = new List<IValuationOption>();
                    while (reader.Read())
                    {
                        ValuationOption opt = new ValuationOption();
                        opt.OptionCode = (int)reader["OptionCode"];
                        opt.Category = (string)reader["Category"];
                        opt.Item = ((string)reader["Item"]).Trim();
                        opt.Cost = (decimal)reader["Cost"];
                        opt.Value = (decimal)(double)reader["Value"];

                        result.Add(opt);
                    }

                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Creates an empty valuation.
        /// </summary>
        /// <returns>A blank Valuation</returns>
        public IValuation CreateValuation()
        {
            return new Valuation();
        }

        /// <summary>
        /// Populates a valuation object based on the mileage
        /// </summary>
        /// <param name="derivId">The derivative id</param>
        /// <param name="plateId">The plate id</param>
        /// <param name="mileage">The mileage</param>
        /// <param name="section">The valuation section</param>
        /// <param name="valuation">The valuation</param>
        private static void PopulateMileageAdjustedValuation(int derivId, int plateId, int mileage, CarValuationSection section, Valuation valuation)
        {
            if (plateId >= GetFromYearPlateIdForSection(section) && plateId <= GetToYearPlateIdForSection(section))
            {
                Sproc procedure = new Sproc("Used_Select_Valuation", DatabaseName);
                procedure.Parameters.Add("@CARDerId", SqlDbType.Int).Value = derivId;
                procedure.Parameters.Add("@YearPlateId", SqlDbType.Int).Value = plateId;
                if (mileage > 0)
                {
                    procedure.Parameters.Add("@Mileage", SqlDbType.Int).Value = mileage;
                }
                else
                {
                    procedure.Parameters.Add("@Mileage", SqlDbType.Int).Value = DBNull.Value;
                }

                valuation.Result = ValuationResultType.Error;

                using (SqlDataReader reader = procedure.ExecuteReader())
                {
                    if (reader != null && reader.Read())
                    {
                        PopulateValuationFromDataReader(reader, valuation);
                        
                        if (mileage == 0)
                        {
                            valuation.Result = ValuationResultType.StandardMileage;
                        }
                        else if (mileage == valuation.Mileage)
                        {
                            valuation.Result = ValuationResultType.MileageAdjusted;
                        }
                        else if (mileage > valuation.Mileage)
                        {
                            valuation.Result = ValuationResultType.MaximumMileage;
                        }
                        else if (mileage < valuation.Mileage)
                        {
                            valuation.Result = ValuationResultType.MinimumMileage;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Populates a valuation from a data reader
        /// </summary>
        /// <param name="reader">The datareader to use</param>
        /// <param name="valuation">The valuation to populate</param>
        private static void PopulateValuationFromDataReader(SqlDataReader reader, Valuation valuation)
        {
            valuation.Derivative = CarDerivative.FromId((int)reader["CARDerId"]);
            valuation.YearPlate = yearPlateProvider.FromId((short)reader["YearPlateId"]);
            valuation.Mileage = (int)reader["Mileage"];

            valuation.OriginalPrice = (int)reader["New"];
            valuation.FranchiseDealer = (int)reader["Franchise"];
            valuation.IndependentDealer = (int)reader["Independent"];
            valuation.PrivateGood = (int)reader["PrivateGood"];
            valuation.PrivatePoor = (int)reader["PrivatePoor"];
            valuation.PartExchange = (int)reader["PartExchange"];
        }

        /// <summary>
        /// Get the "from" year plate ID for a section
        /// </summary>
        /// <param name="section">The car valuation section</param>
        /// <returns>The from year plate id</returns>
        private static int GetFromYearPlateIdForSection(CarValuationSection section)
        {
            int result;

            switch (section)
            {
                case CarValuationSection.Free:
                    result = yearPlateProvider.FromDate(new DateTime(GetFreeValuationCutOffYear(), 1, 1)).Id;
                    break;
                default:
                    result = yearPlateProvider.FromDate(new DateTime(ValuationsAvailableFromYear, 1, 1)).Id;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Get the "to" year plate ID for a section
        /// </summary>
        /// <param name="section">The car valuation section</param>
        /// <returns>The from year plate id</returns>
        private static int GetToYearPlateIdForSection(CarValuationSection section)
        {
            int result = 0;

            switch (section)
            {
                case CarValuationSection.Older:
                case CarValuationSection.ParkersPlus:
                    result = yearPlateProvider.FromDate(new DateTime(GetFreeValuationCutOffYear() - 1, 12, 31)).Id;
                    break;
                case CarValuationSection.Free:
                case CarValuationSection.AllYears:
                    result = Int32.MaxValue;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Gets the year prior to which free valuations cease to be available
        /// </summary>
        /// <returns>The year</returns>
        private static int GetFreeValuationCutOffYear()
        {
            return DateTime.Now.Year - FreeValutionYears;
        }

        #endregion
    }
}
