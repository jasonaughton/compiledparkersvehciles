// <copyright file="IValuationWithOptions.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Defines valuation with options
    /// </summary>
    public interface IValuationWithOptions : IValuation
    {
        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        List<IValuationOption> Options
        {
            get;
            set;
        }
    }
}
