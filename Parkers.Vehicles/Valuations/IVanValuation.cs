// <copyright file="IVanValuation.cs" company="Bauer Consumer Media">
//   Copyright 2015 Bauer Consumer Media, All Rights Reserved
// </copyright>

namespace Parkers.Vehicles.Valuations
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Van valuation interface
    /// </summary>
    public interface IVanValuation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the derivative.
        /// </summary>
        /// <value>
        /// The derivative.
        /// </value>
        IDerivative Derivative
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the original price.
        /// </summary>
        /// <value>
        /// The original price.
        /// </value>
        int OriginalPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the year plate.
        /// </summary>
        /// <value>
        /// The year plate.
        /// </value>
        IYearPlate YearPlate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        ValuationResultType Result
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the valuation segments.
        /// </summary>
        /// <value>
        /// The valuation segments.
        /// </value>
        Dictionary<int, IVanValuationSegment> ValuationSegments
        {
            get;
            set;
        }

        #endregion
    }
}
