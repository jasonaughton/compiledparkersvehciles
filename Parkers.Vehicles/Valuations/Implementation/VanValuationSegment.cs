// <copyright file="VanValuationSegment.cs" company="Bauer Consumer Media">
//   Copyright 2015 Bauer Consumer Media, All Rights Reserved
// </copyright>

namespace Parkers.Vehicles.Valuations.Implementation
{
    /// <summary>
    /// Van valuation segment class
    /// </summary>
    public class VanValuationSegment : IVanValuationSegment
    {
        #region Properties

        /// <summary>
        /// Gets or sets the private high.
        /// </summary>
        /// <value>
        /// The private good.
        /// </value>
        public int PrivateHigh
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the private low.
        /// </summary>
        /// <value>
        /// The private poor.
        /// </value>
        public int PrivateLow
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the retail high.
        /// </summary>
        /// <value>
        /// The retail high.
        /// </value>
        public int RetailHigh
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the retail low.
        /// </summary>
        /// <value>
        /// The retail low.
        /// </value>
        public int RetailLow
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the average high.
        /// </summary>
        /// <value>
        /// The average high.
        /// </value>
        public int AverageHigh
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the average low.
        /// </summary>
        /// <value>
        /// The average low.
        /// </value>
        public int AverageLow
        {
            get;
            set;
        }

        #endregion
    }
}
