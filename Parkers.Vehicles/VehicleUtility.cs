// <copyright file="VehicleUtility.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Parkers.Data;
    using StructureMap;

    #endregion

    /// <summary>
    /// Vehicle utility
    /// </summary>
    public static class VehicleUtility
    {
        #region Constants

        /// <summary>
        /// The Parkers Car database name
        /// </summary>
        private const string DatabaseName = "ParkersCAR";

        /// <summary>
        /// The default lookup result
        /// </summary>
        private const string DefaultResult = "Other";

        #endregion

        #region Fields

        /// <summary>
        /// Fuel type code to name lookup table
        /// </summary>
        private static readonly Dictionary<string, string> fuelTypeNames = new Dictionary<string, string>();

        /// <summary>
        /// Transmission code to name lookup table
        /// </summary>
        private static readonly Dictionary<string, string> transmissionNames = new Dictionary<string, string>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="VehicleUtility"/> class.
        /// </summary>
        static VehicleUtility()
        {
            PopulateDictionary(fuelTypeNames, "GetFuelTypes", "FuelCode", "FuelDescr");
            PopulateDictionary(transmissionNames, "GetTransmissionTypes", "TransCode", "TransDescr");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the full name of the fuel type.
        /// </summary>
        /// <param name="abbreviation">The abbreviation.</param>
        /// <returns>The full name of the fuel type</returns>
        public static string GetFuelTypeFullName(string abbreviation)
        {
            string result = DefaultResult;

            if (fuelTypeNames.ContainsKey(abbreviation.ToUpper()))
            {
                result = fuelTypeNames[abbreviation];
            }

            return result;
        }

        /// <summary>
        /// Gets all fuel type full names (including the default catch-all)
        /// </summary>
        /// <returns>Collection of fuel type names</returns>
        public static IEnumerable<string> GetAllFuelTypeFullNames()
        {
            List<string> result = new List<string>(fuelTypeNames.Values);
            result.Add(DefaultResult);

            return result;
        }

        /// <summary>
        /// Gets the full name of the transmission.
        /// </summary>
        /// <param name="abbreviation">The abbreviation.</param>
        /// <returns>The full name of the transmission type</returns>
        public static string GetTransmissionFullName(string abbreviation)
        {
            string result = DefaultResult;

            if (transmissionNames.ContainsKey(abbreviation.ToUpper()))
            {
                result = transmissionNames[abbreviation];
            }

            return result;
        }

        /// <summary>
        /// Gets all transmission full names (including the default catch-all value)
        /// </summary>
        /// <returns>Collection of transmission type full names</returns>
        public static IEnumerable<string> GetAllTransmissionFullNames()
        {
            List<string> result = new List<string>(transmissionNames.Values);
            result.Add(DefaultResult);

            return result;
        }

        /// <summary>
        /// Populates the dictionary.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="storedProcedureName">Name of the stored proceudre.</param>
        /// <param name="codeColumnName">Name of the code column.</param>
        /// <param name="descriptionColumnName">Name of the description column.</param>
        private static void PopulateDictionary(Dictionary<string, string> dictionary, string storedProcedureName, string codeColumnName, string descriptionColumnName)
        {
            Sproc procedure = new Sproc(storedProcedureName, DatabaseName);

            using (SqlDataReader reader = procedure.ExecuteReader())
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string code = DataUtil.GetString(reader, codeColumnName).Trim();
                        string name = DataUtil.GetString(reader, descriptionColumnName).Trim();

                        if (!String.IsNullOrEmpty(code) && !String.IsNullOrEmpty(name))
                        {
                            dictionary.Add(code, name);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
