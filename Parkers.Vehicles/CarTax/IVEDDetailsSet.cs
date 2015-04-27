// <copyright file="IVEDDetailsSet.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Defines VED details set
    /// </summary>
    public interface IVEDDetailsSet
    {
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
        /// Gets or sets a value indicating whether [first year applies].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [first year applies]; otherwise, <c>false</c>.
        /// </value>
        bool FirstYearApplies
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        List<IVEDDetails> Values
        {
            get;
        }

        /// <summary>
        /// Combines the results.
        /// </summary>
        void CombineResults();
    }
}
