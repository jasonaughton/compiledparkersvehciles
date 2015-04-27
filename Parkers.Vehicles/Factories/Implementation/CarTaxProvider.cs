// <copyright file="CarTaxProvider.cs" company="Bauer Consumer Media Limited">
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

    #endregion

    /// <summary>
    /// Car tax data provider class
    /// </summary>
    public class CarTaxProvider : ICarTaxProvider
    {
        #region Constants

        /// <summary>
        /// The parkers meta database name
        /// </summary>
        private const string ParkersMetaDatabase = "ParkersMeta";

        /// <summary>
        /// The name of the database
        /// </summary>
        private const string DatabaseName = "ParkersCAR";

        /// <summary>
        /// The first month of the new tax year (April)
        /// </summary>
        private const int TaxYearStartMonth = 4;

        #endregion

        #region Fields

        /// <summary>
        /// The changeover date
        /// </summary>
        private static readonly DateTime changeoverDate = new DateTime(2001, 3, 1);

        /// <summary>
        /// The band G date
        /// </summary>
        private static readonly DateTime bandGDate = new DateTime(2006, 3, 26);

        #endregion

        #region Properties

        /// <summary>
        /// Gets the changeover date
        /// </summary>
        public DateTime ChangeoverDate
        {
            get
            {
                return changeoverDate;
            }
        }

        /// <summary>
        /// Gets the Band G date
        /// </summary>
        public DateTime BandGDate
        {
            get
            {
                return bandGDate;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the company car tax from the database
        /// </summary>
        /// <param name="derivativeId">The derivative id</param>
        /// <param name="taxYear">The tax year</param>
        /// <param name="taxRate">The tax rate</param>
        /// <param name="p11DOverrideValue">The P11D override value</param>
        /// <param name="plateId">The yearplate id</param>
        /// <returns>CompanyCarTaxResults representing the data</returns>
        public ICompanyCarTaxResults GetCompanyCarTax(int derivativeId, int taxYear, int taxRate, int p11DOverrideValue, int plateId)
        {
            Sproc procedure = new Sproc("CompanyCarTaxCalculator", DatabaseName);
            procedure.Parameters.Add("@year", SqlDbType.Int).Value = taxYear;
            procedure.Parameters.Add("@DerId", SqlDbType.Int).Value = derivativeId;
            procedure.Parameters.Add("@taxrate", SqlDbType.Int).Value = taxRate;
            procedure.Parameters.Add("@P11DPrice", SqlDbType.Int).Value = p11DOverrideValue;
            procedure.Parameters.Add("@YearPlateId", SqlDbType.Int).Value = plateId;
            using (SqlDataReader reader = procedure.ExecuteReader())
            {
                if (reader.HasRows && reader.Read())
                {
                    return this.GetTaxFromDataReader(reader);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the VED details by derivate id
        /// </summary>
        /// <param name="derivId">The derivative id</param>
        /// <returns>The VED Details set</returns>
        public List<IVEDDetailsSet> GetVEDDetailsByDerivId(int derivId)
        {
            List<IVEDDetailsSet> results = new List<IVEDDetailsSet>();

            Sproc procedure = new Sproc("VED_S", DatabaseName);
            procedure.Parameters.Add("@CARDerId", SqlDbType.Int).Value = derivId;
            using (SqlDataReader reader = procedure.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    VEDDetailsSet currentSet = null;

                    while (reader.Read())
                    {
                        IVEDDetails ved = GetVEDFromDataReader(reader);

                        if (currentSet == null || ved.EffectivePeriod != currentSet.EffectivePeriod)
                        {
                            currentSet = new VEDDetailsSet 
                            { 
                                EffectivePeriod = ved.EffectivePeriod 
                            };
                            results.Add(currentSet);
                        }

                        currentSet.Values.Add(ved);

                        if (ved.FirstYearApplies)
                        {
                            currentSet.FirstYearApplies = true;
                        }
                    }
                }
            }

            foreach (IVEDDetailsSet item in results)
            {
                item.CombineResults();
            }

            return results;
        }

        /// <summary>
        /// Gets the manufacturer ids with car tax data
        /// </summary>
        /// <returns>The list of manufacturer ids</returns>
        public List<int> GetManufacturerIdsWithCarTaxData()
        {
            Sproc procedure = new Sproc("Man_Ved_S", DatabaseName);

            List<int> manufacturerIdsWithCarTax = new List<int>();

            using (SqlDataReader reader = procedure.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        manufacturerIdsWithCarTax.Add(reader.GetInt32(0));
                    }
                }
            }

            return manufacturerIdsWithCarTax;
        }

        /// <summary>
        /// Gets the model IDs with car tax data
        /// </summary>
        /// <param name="manufacturerId">The manufacturer ids</param>
        /// <returns>The list of model ids</returns>
        public List<int> GetModelIdsWithCarTaxData(int manufacturerId)
        {
            Sproc procedure = new Sproc("Mod_Ved_S", DatabaseName);

            procedure.Parameters.Add("@CARManId", SqlDbType.Int).Value = manufacturerId;

            List<int> modelIdsWithCarTax = new List<int>();

            using (SqlDataReader reader = procedure.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        modelIdsWithCarTax.Add(reader.GetInt32(0));
                    }
                }
            }

            return modelIdsWithCarTax;
        }

        /// <summary>
        /// Gets the list of derivate ids with car tax data
        /// </summary>
        /// <param name="modelId">The model id</param>
        /// <returns>The derivative ids</returns>
        public List<int> GetDerivativeIdsWithCarTaxData(int modelId)
        {
            Sproc procedure = new Sproc("Der_Ved_S", DatabaseName);

            procedure.Parameters.Add("@CARModId", SqlDbType.Int).Value = modelId;

            List<int> derivativeIdsWithCarTax = new List<int>();

            using (SqlDataReader reader = procedure.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        derivativeIdsWithCarTax.Add(reader.GetInt32(0));
                    }
                }
            }

            return derivativeIdsWithCarTax;
        }

        /// <summary>
        /// Gets the tax years.
        /// </summary>
        /// <returns>Returns a list of tax years</returns>
        public IEnumerable<ITaxYear> GetTaxYears()
        {
            List<ITaxYear> result = new List<ITaxYear>();

            Sproc storedProcedure = new Sproc("GetTaxYears", ParkersMetaDatabase);

            using (SqlDataReader reader = storedProcedure.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(this.GetTaxYearFromDatabase(reader));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the tax year text.
        /// </summary>
        /// <param name="year">The calendar year for display.</param>
        /// <returns>Tax year in form y1/y2</returns>
        public string GetTaxYearText(int year)
        {
            if (DateTime.Now.Month < TaxYearStartMonth)
            {
                year--;
            }

            return String.Concat(year.ToString(), " / ", (year + 1).ToString());
        }

        /// <summary>
        /// Gets the VED from data reader
        /// </summary>
        /// <param name="reader">The data reader</param>
        /// <returns>The VED details</returns>
        internal static IVEDDetails GetVEDFromDataReader(SqlDataReader reader)
        {
            VEDDetails result = new VEDDetails 
            { 
                SixMonths = DataUtil.GetDecimal(reader, "HalfYearPrice"), 
                TwelveMonths = DataUtil.GetDecimal(reader, "FullYearPrice"), 
                FirstYear = DataUtil.GetDecimal(reader, "FirstYearPrice"), 
                FirstYearApplies = !reader.IsDBNull(reader.GetOrdinal("FirstYearPrice")), 
                EffectivePeriod = DataUtil.GetString(reader, "EffectivePeriod"), 
                Band = DataUtil.GetString(reader, "VEDBand"), 
                StartDate = DataUtil.GetDateTime(reader, "From"), 
                EndDate = DataUtil.GetDateTime(reader, "To", DateTime.MaxValue), 
                CO2Min = DataUtil.GetInt32(reader, "CO2") 
            };
            result.CO2Max = result.CO2Min;

            return result;
        }

        /// <summary>
        /// Gets the tax results from the data reader
        /// </summary>
        /// <param name="reader">The data reader</param>
        /// <returns>The tax results</returns>
        private ICompanyCarTaxResults GetTaxFromDataReader(SqlDataReader reader)
        {
            CompanyCarTaxResults result = new CompanyCarTaxResults 
            { 
                CarTaxCAV = DataUtil.GetDecimal(reader, "taxCAV"), 
                CC = DataUtil.GetInt32(reader, "cc"), 
                EuroEmissions = DataUtil.GetInt32(reader, "euroemissions"), 
                FuelAnnualTax = DataUtil.GetInt32(reader, "fuelannualtax"), 
                FuelCAV = DataUtil.GetInt32(reader, "fuelCAV"), 
                FuelMonthlyTax = DataUtil.GetInt32(reader, "fuelmonthlytax"), 
                GramsPerKm = DataUtil.GetInt32(reader, "co2emissions"), 
                List = DataUtil.GetInt32(reader, "listprice"), 
                CarAnnualTax = DataUtil.GetDecimal(reader, "annualtax"), 
                CarMonthlyTax = DataUtil.GetDecimal(reader, "monthlytax"), 
                Rate = DataUtil.GetInt32(reader, "rate"), 
                TaxBenefitPercent = DataUtil.GetInt32(reader, "taxbenefitpercent"), 
                TaxYear = DataUtil.GetInt32(reader, "taxyear"), 
                FuelType = DataUtil.GetString(reader, "fueltype") 
            };

            return result;
        }

        /// <summary>
        /// Gets the tax year from database.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>A tax year object</returns>
        private ITaxYear GetTaxYearFromDatabase(SqlDataReader reader)
        {
            TaxYear result = new TaxYear
            {
                Id = DataUtil.GetInt32(reader, "Id"),
                Name = DataUtil.GetString(reader, "Name"),
                StartYear = DataUtil.GetInt32(reader, "StartYear"),
                PersonalIncomeTaxAllowance = DataUtil.GetInt32(reader, "Pita")
            };

            result.Rates.AddRange(this.GetTaxRatesForYear(result.Id));

            return result;
        }

        /// <summary>
        /// Gets the tax rates for year.
        /// </summary>
        /// <param name="taxYearId">The tax year id.</param>
        /// <returns>Collection of tax rates</returns>
        private IEnumerable<ITaxRate> GetTaxRatesForYear(int taxYearId)
        {
            List<ITaxRate> result = new List<ITaxRate>();

            Sproc storedProcedure = new Sproc("GetTaxRatesByYear", ParkersMetaDatabase);
            storedProcedure.Parameters.Add("@TaxYearId", SqlDbType.Int).Value = taxYearId;

            using (SqlDataReader reader = storedProcedure.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(this.GetTaxRateFromDatabase(reader));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the tax rate from database.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>A tax rate object</returns>
        private ITaxRate GetTaxRateFromDatabase(SqlDataReader reader)
        {
            TaxRate result = new TaxRate
                {
                    Id = DataUtil.GetInt32(reader, "Id"),
                    Name = DataUtil.GetString(reader, "Name"),
                    Rate = DataUtil.GetInt32(reader, "Rate"),
                    MinimumTaxableValue = DataUtil.GetInt32(reader, "MinTaxableValue"),
                    MaximumTaxableValue = DataUtil.GetInt32(reader, "MaxTaxableValue", Int32.MaxValue)
                };

            return result;
        }

        #endregion
    }
}
