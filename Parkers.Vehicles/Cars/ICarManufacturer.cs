// <copyright file="ICarManufacturer.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Defines car manufacturer
    /// </summary>
    public interface ICarManufacturer : IManufacturer
    {
        /// <summary>
        /// Gets the models.
        /// </summary>
        new List<ICarModel> Models
        {
            get;
        }

        /// <summary>
        /// Gets the ranges.
        /// </summary>
        List<ICarRange> Ranges
        {
            get;
        }

        /// <summary>
        /// Gets the generic body styles.
        /// </summary>
        IEnumerable<string> GenericBodyStyles
        {
            get;
        }

        /// <summary>
        /// Finds the models.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Car model list</returns>
        new List<ICarModel> FindModels(Predicate<IModel> filter);
    }
}
