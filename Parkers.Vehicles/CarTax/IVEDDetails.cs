// <copyright file="IVEDDetails.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region

    using System;

    #endregion

    /// <summary>
    /// Defines VED details
    /// </summary>
    public interface IVEDDetails
    {
        /// <summary>
        /// Gets or sets the band.
        /// </summary>
        /// <value>
        /// The VED band.
        /// </value>
        string Band
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the C o2.
        /// </summary>
        string CO2
        {
            get;
        }

        /// <summary>
        /// Gets or sets the C o2 max.
        /// </summary>
        /// <value>
        /// The C o2 max.
        /// </value>
        int CO2Max
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the C o2 min.
        /// </summary>
        /// <value>
        /// The C o2 min.
        /// </value>
        int CO2Min
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the effective period.
        /// </summary>
        /// <value>
        /// The effective period.
        /// </value>
        string EffectivePeriod
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        DateTime EndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the first year.
        /// </summary>
        /// <value>
        /// The first year.
        /// </value>
        decimal FirstYear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [first year applies].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [first year applies]; otherwise, <c>false</c>.
        /// </value>
        bool FirstYearApplies
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the six months.
        /// </summary>
        /// <value>
        /// The six months.
        /// </value>
        decimal SixMonths
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        DateTime StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the twelve months.
        /// </summary>
        /// <value>
        /// The twelve months.
        /// </value>
        decimal TwelveMonths
        {
            get;
            set;
        }

        /// <summary>
        /// Combines the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        void Combine(IVEDDetails other);
    }
}
