// <copyright file="IVanValuationSegment.cs" company="Bauer Consumer Media">
//   Copyright 2015 Bauer Consumer Media, All Rights Reserved
// </copyright>

namespace Parkers.Vehicles.Valuations
{
    /// <summary>
    /// Van valuation segment interface
    /// </summary>
    public interface IVanValuationSegment
    {
        #region Properties

        /// <summary>
        /// Gets or sets the private high.
        /// </summary>
        /// <value>
        /// The private good.
        /// </value>
        int PrivateHigh
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
        int PrivateLow
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
        int RetailHigh
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
        int RetailLow
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
        int AverageHigh
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
        int AverageLow
        {
            get;
            set;
        }

        #endregion
    }
}
