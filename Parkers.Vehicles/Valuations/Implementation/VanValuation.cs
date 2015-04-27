// <copyright file="VanValuation.cs" company="Bauer Consumer Media">
//   Copyright 2015 Bauer Consumer Media, All Rights Reserved
// </copyright>

namespace Parkers.Vehicles.Valuations.Implementation
{   
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Van valuation interface
    /// </summary>
    public class VanValuation : IVanValuation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the derivative.
        /// </summary>
        /// <value>
        /// The derivative.
        /// </value>
        public IDerivative Derivative
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
        public int OriginalPrice
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
        public IYearPlate YearPlate
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
        public ValuationResultType Result
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
        public Dictionary<int, IVanValuationSegment> ValuationSegments
        {
            get;
            set;
        }

        #endregion
    }
}
