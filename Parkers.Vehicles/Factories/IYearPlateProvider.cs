// <copyright file="IYearPlateProvider.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Year plate provider interface
    /// </summary>
    public interface IYearPlateProvider
    {
        /// <summary>
        /// Froms the date.
        /// </summary>
        /// <param name="date">The date to generate a year plate from.</param>
        /// <returns>The year plate</returns>
        IYearPlate FromDate(DateTime date);

        /// <summary>
        /// Froms the id.
        /// </summary>
        /// <param name="id">The year plate id.</param>
        /// <returns>The year plate</returns>
        IYearPlate FromId(int id);

        /// <summary>
        /// Froms the year and plate.
        /// </summary>
        /// <param name="year">The year plate year.</param>
        /// <param name="plate">The plate.</param>
        /// <returns>The year plate</returns>
        IYearPlate FromYearAndPlate(int year, string plate);

        /// <summary>
        /// Gets the year plate range.
        /// </summary>
        /// <param name="plateFrom">The plate from.</param>
        /// <param name="plateTo">The plate to.</param>
        /// <returns>List of year plates</returns>
        List<IYearPlate> GetRange(IYearPlate plateFrom, IYearPlate plateTo);

        /// <summary>
        /// Gets the year plate range.
        /// </summary>
        /// <param name="plateFrom">The plate from.</param>
        /// <param name="plateTo">The plate to.</param>
        /// <returns>List of year plates</returns>
        List<IYearPlate> GetRange(int plateFrom, int plateTo);
    }
}
