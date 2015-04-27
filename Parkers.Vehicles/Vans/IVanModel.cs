// <copyright file="IVanModel.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Defines van model
    /// </summary>
    public interface IVanModel : IModel
    {
        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        new IVanManufacturer Manufacturer
        {
            get;
        }

        /// <summary>
        /// Gets the range.
        /// </summary>
        new IVanRange Range
        {
            get;
        }

        /// <summary>
        /// Gets the review.
        /// </summary>
        IVanReview Review
        {
            get;
        }

        /// <summary>
        /// Gets the classification
        /// </summary>
        IVanClassification Classification
        {
            get;
        }

        /// <summary>
        /// Finds the derivatives.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>a list of van derivatives</returns>
        new List<IVanDerivative> FindDerivatives(Predicate<IDerivative> filter);
    }
}
