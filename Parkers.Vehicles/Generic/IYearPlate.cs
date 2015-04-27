// <copyright file="IYearPlate.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;

    #endregion

    /// <summary>
    /// Defines the year plate
    /// </summary>
    public interface IYearPlate : IKeyValueMappable
    {
        /// <summary>
        /// Gets the end date.
        /// </summary>
        DateTime EndDate
        {
            get;
        }

        /// <summary>
        /// Gets the example.
        /// </summary>
        string Example
        {
            get;
        }

        /// <summary>
        /// Gets the plate.
        /// </summary>
        string Plate
        {
            get;
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        DateTime StartDate
        {
            get;
        }

        /// <summary>
        /// Gets the year.
        /// </summary>
        int Year
        {
            get;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        string ToString();
    }
}
