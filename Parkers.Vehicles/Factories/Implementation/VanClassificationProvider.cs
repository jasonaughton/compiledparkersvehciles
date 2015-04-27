// <copyright file="VanClassificationProvider.cs" company="Bauer Consumer Media Limited">
//    Copyright 2015 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using Parkers.Data;

    #endregion

    /// <summary>
    /// The van classification provider
    /// </summary>
    public class VanClassificationProvider : IVanClassificationProvider
    {
        #region Fields

        /// <summary>
        /// Year plates collection
        /// </summary>
        private static List<IVanClassification> classifications;

        #endregion

        #region Methods

        /// <summary>
        /// Gets a classification from the id.
        /// </summary>
        /// <param name="id">The classification id.</param>
        /// <returns>The classification</returns>
        public IVanClassification GetClassification(int id)
        {
            IVanClassification result = null;

            if (classifications == null)
            {
                PopulateFromDatabase();
            }

            result = classifications.FirstOrDefault(classification => classification.Id == id);

            return result;
        }

        /// <summary>
        /// Populates the collection of classifications from the database.
        /// </summary>
        private static void PopulateFromDatabase()
        {
            classifications = new List<IVanClassification>();
            Sproc procedure = new Sproc("Classification_Select", "ParkersVAN");

            using (SqlDataReader reader = procedure.ExecuteReader())
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id;
                        
                        if (Int32.TryParse(reader["ClassificationId"].ToString(), out id))
                        {
                            classifications.Add(new VanClassification 
                            {
                                Id = id,
                                Name = reader["ClassificationName"].ToString(),
                                Description = reader["ClassificationDescription"].ToString(),
                                LongDescription = reader["ClassificationDescriptionLong"].ToString(),
                                AverageMileage = new Dictionary<int, int>

                                                     {
                                                         { 1, Convert.ToInt32(reader["AverageMileageYear1"].ToString())},
                                                         { 2, Convert.ToInt32(reader["AverageMileageYear2"].ToString())},
                                                         { 3, Convert.ToInt32(reader["AverageMileageYear3"].ToString())},
                                                         { 4, Convert.ToInt32(reader["AverageMileageYear4"].ToString())},
                                                         { 5, Convert.ToInt32(reader["AverageMileageYear5"].ToString())},
                                                         { 6, Convert.ToInt32(reader["AverageMileageYear6"].ToString())},
                                                         { 7, Convert.ToInt32(reader["AverageMileageYear7"].ToString())},
                                                         { 8, Convert.ToInt32(reader["AverageMileageYear8"].ToString())},
                                                         { 9, Convert.ToInt32(reader["AverageMileageYear9"].ToString())},
                                                         { 10, Convert.ToInt32(reader["AverageMileageYear10"].ToString())}
                                                     },
                            });
                        }
                    }
                }
            }
        }

        #endregion
    }
}
