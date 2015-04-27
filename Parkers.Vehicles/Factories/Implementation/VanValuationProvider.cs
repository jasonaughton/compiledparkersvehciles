// <copyright file="VanValuationProvider.cs" company="Bauer Consumer Media">
//   Copyright 2015 Bauer Consumer Media, All Rights Reserved
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Parkers.Data;
    using Parkers.Vehicles.Valuations;
    using Parkers.Vehicles.Valuations.Implementation;
    using StructureMap;
    #endregion

    /// <summary>
    /// VanValuationProvder implementation
    /// </summary>
    public class VanValuationProvider : IVanValuationProvider
    {
        #region Constants

        /// <summary>
        /// Database to use.
        /// </summary>
        private const string Database = "ParkersVAN";

        #endregion

        #region Methods

        /// <summary>
        /// Gets the plates by model id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <param name="section">The section.</param>
        /// <returns> List of year plates </returns>
        public List<IYearPlate> GetPlatesByModelId(int modelId, VanValuationSection section)
        {
            int sectionFrom = GetYearPlateFromForSection(section);
            int sectionTo = GetYearPlateToForSection(section);
            IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();
            IYearPlateProvider yearPlateProvider = ObjectFactory.GetInstance<IYearPlateProvider>();

            IVanModel m = vanProvider.GetModelFromId(modelId);

            if (m.FromYearPlate == null || m.ToYearPlate == null)
            {
                return null;
            }

            int plateFrom = m.FromYearPlate.Id;
            int plateTo = m.ToYearPlate.Id;

            if (sectionFrom > plateFrom)
            {
                plateFrom = sectionFrom;
            }
            if (sectionTo < plateTo)
            {
                plateTo = sectionTo;
            }

            return yearPlateProvider.GetRange(plateFrom, plateTo);
        }

        /// <summary>
        /// Gets the derivatives by model and plate id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <param name="section">The section.</param>
        /// <returns> List of van derivatives </returns>
        public List<IVanDerivative> GetDerivativesByModelAndPlateId(int modelId, int plateId, VanValuationSection section)
        {
            if (plateId >= GetYearPlateFromForSection(section) && plateId <= GetYearPlateToForSection(section))
            {

                Sproc sp = new Sproc("Used_Select_DerivsByModelAndPlate", Database);
                sp.Parameters.Add("@VANModId", SqlDbType.Int).Value = modelId;
                sp.Parameters.Add("@YearPlateId", SqlDbType.Int).Value = plateId;

                using (SqlDataReader dr = sp.ExecuteReader())
                {
                    if (dr != null && dr.HasRows)
                    {
                        List<IVanDerivative> result = new List<IVanDerivative>();

                        IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

                        while (dr.Read())
                        {
                            result.Add(vanProvider.GetDerivativeFromId((int)dr["VANDerId"]));
                        }
                        return result;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the valuation.
        /// </summary>
        /// <param name="derivId">The derivative id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <param name="section">The section.</param>
        /// <returns>
        /// The Van valuation
        /// </returns>
        public IVanValuation GetValuation(int derivId, int plateId, VanValuationSection section)
        {
            VanValuation result = new VanValuation();

            PopulateVanValuation(derivId, plateId, section, result);
            if (result.Result == ValuationResultType.Error)
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// Populates the mileage adjusted valuation.
        /// </summary>
        /// <param name="derivId">The deriv identifier.</param>
        /// <param name="plateId">The plate identifier.</param>
        /// <param name="section">The section.</param>
        /// <param name="valuation">The valuation.</param>
        private static void PopulateVanValuation(int derivId, int plateId, VanValuationSection section, VanValuation valuation)
        {
            if (plateId >= GetYearPlateFromForSection(section) && plateId <= GetYearPlateToForSection(section))
            {
                valuation.Result = ValuationResultType.Error;
                IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();
                IYearPlateProvider yearPlateProvider = ObjectFactory.GetInstance<IYearPlateProvider>();

                valuation.Derivative = vanProvider.GetDerivativeFromId(derivId);
                valuation.YearPlate = yearPlateProvider.FromId(plateId);

                valuation.ValuationSegments = new Dictionary<int, IVanValuationSegment>();

                valuation.OriginalPrice = GetOriginalPrice(derivId, plateId);

                Sproc sp = new Sproc("Used_Select_Valuation", Database);
                sp.Parameters.Add("@VANDerId", SqlDbType.Int).Value = derivId;
                sp.Parameters.Add("@YearPlateId", SqlDbType.Int).Value = plateId;
            
                using (SqlDataReader dataReader = sp.ExecuteReader())
                {
                    if (dataReader != null)
                    {
                        while (dataReader.Read())
                        {
                            PopulateValuationSegmentFromDataReader(dataReader, valuation);
                        }

                        valuation.Result = ValuationResultType.VanEstimatedMileage;   
                    }
                }
            }
        }

        /// <summary>
        /// Gets the original price.
        /// </summary>
        /// <param name="derivId">The deriv identifier.</param>
        /// <param name="yearPlateId">The year plate identifier.</param>
        /// <returns>
        /// the original price for derivative
        /// </returns>
        private static int GetOriginalPrice(int derivId, int yearPlateId)
        {
            int result = 0;
            Sproc sp = new Sproc("Used_Select_OriginalPrice", Database);
            sp.Parameters.Add("@VANDerId", SqlDbType.Int).Value = derivId;
            sp.Parameters.Add("@YearPlateId", SqlDbType.Int).Value = yearPlateId;

            using (SqlDataReader dataReader = sp.ExecuteReader())
            {
                if (dataReader != null && dataReader.Read())
                {
                    result = DataUtil.GetInt32(dataReader, "New");
                }
            }

            return result;
        }

        /// <summary>
        /// Populates the valuation segment from the data reader.
        /// </summary>
        /// <param name="dataReader">The data reader.</param>
        /// <param name="valuation">The valuation.</param>
        private static void PopulateValuationSegmentFromDataReader(SqlDataReader dataReader, VanValuation valuation)
        {
            int mileage = DataUtil.GetInt32(dataReader, "Mileage");

            if (mileage > 0)
            {
                IVanValuationSegment segment = new VanValuationSegment
                {
                    PrivateHigh = DataUtil.GetInt32(dataReader, "PrivateHigh"), 
                    PrivateLow = DataUtil.GetInt32(dataReader, "PrivateLow"),
                    AverageHigh = DataUtil.GetInt32(dataReader, "AverageHigh"), 
                    AverageLow = DataUtil.GetInt32(dataReader, "AverageLow"), 
                    RetailHigh = DataUtil.GetInt32(dataReader, "RetailHigh"), 
                    RetailLow = DataUtil.GetInt32(dataReader, "RetailLow"),
                };

                valuation.ValuationSegments.Add(mileage, segment);
            }
        }

        /// <summary>
        /// Gets the year plate from for section.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <returns>the from year plate</returns>
        private static int GetYearPlateFromForSection(VanValuationSection section)
        {
            return 0;
        }

        /// <summary>
        /// Gets the year plate to for section.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <returns>the to year plate</returns>
        private static int GetYearPlateToForSection(VanValuationSection section)
        {
            return Int32.MaxValue;
        }

        #endregion
    }
}

