// <copyright file="YearPlateProvider.cs" company="Bauer Consumer Media Limited">
//   Copyright 2012 Bauer Consumer Media Limited
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
    /// Year plate provider
    /// </summary>
    public class YearPlateProvider : IYearPlateProvider
    {
        #region Fields
        
        /// <summary>
        /// Year plates collection
        /// </summary>
        private static YearPlate[] yearPlates = new YearPlate[0];

        #endregion

        #region Methods

        /// <summary>
        /// Froms the id.
        /// </summary>
        /// <param name="id">The year plate id.</param>
        /// <returns>The year plate</returns>
        public IYearPlate FromId(int id)
        {
            if (yearPlates == null)
            {
                Populate();
            }

            if (id <= 0 || id >= yearPlates.Length)
            {
                return null;
            }

            return yearPlates[id];
        }

        /// <summary>
        /// Froms the date.
        /// </summary>
        /// <param name="date">The date to generate a year plate from.</param>
        /// <returns>The year plate</returns>
        public IYearPlate FromDate(DateTime date)
        {
            YearPlate result = null;

            if (yearPlates == null)
            {
                Populate();
            }

            // Read through _values in order, and return the first item
            // that has an end date after the target date

            // KR: index starts at 1 because the first element is always null!
            // (have a look at Populate to see why)
            for (int index = 1; index < yearPlates.Length; index++)
            {
                if (yearPlates[index].EndDate >= date)
                {
                    result = yearPlates[index];
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Froms the year and plate.
        /// </summary>
        /// <param name="year">The year plate year.</param>
        /// <param name="plate">The plate.</param>
        /// <returns>The year plate</returns>
        public IYearPlate FromYearAndPlate(int year, string plate)
        {
            IYearPlate result = null;
            
            if (yearPlates == null)
            {
                Populate();
            }

            IEnumerable<YearPlate> candidates = yearPlates.Where(item => item != null);
            result = candidates.FirstOrDefault(item => item.Year == year && item.Plate == plate);

            return result;
        }

        /// <summary>
        /// Gets the year plate range.
        /// </summary>
        /// <param name="plateFrom">The plate from.</param>
        /// <param name="plateTo">The plate to.</param>
        /// <returns>List of year plates</returns>
        public List<IYearPlate> GetRange(IYearPlate plateFrom, IYearPlate plateTo)
        {
            return this.GetRange(plateFrom.Id, plateTo.Id);
        }

        /// <summary>
        /// Gets the year plate range.
        /// </summary>
        /// <param name="plateFrom">The plate from.</param>
        /// <param name="plateTo">The plate to.</param>
        /// <returns>List of year plates</returns>
        public List<IYearPlate> GetRange(int plateFrom, int plateTo)
        {
            List<IYearPlate> result = new List<IYearPlate>();

            for (int index = plateFrom; index <= plateTo; index++)
            {
                result.Add(this.FromId(index));
            }

            return result;
        }

        /// <summary>
        /// Populates this instance.
        /// </summary>
        private static void Populate()
        {
            //Sproc procedure = new Sproc("YearPlate_Select", "ParkersMeta");

            //using (SqlDataReader reader = procedure.ExecuteReader())
            //{
            //    if (reader != null && reader.HasRows)
            //    {
            //        List<YearPlate> list = new List<YearPlate>();

            //        while (reader.Read())
            //        {
            //            YearPlate newPlate = new YearPlate(reader);
            //            list.Add(newPlate);
            //        }

            //        int maxId = list[list.Count - 1].Id;
            //        yearPlates = new YearPlate[maxId + 1];

            //        foreach (YearPlate yearPlate in list)
            //        {
            //            yearPlates[yearPlate.Id] = yearPlate;
            //        }
            //    }
            //}
        }

        #endregion
    }
}