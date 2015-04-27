// <copyright file="ITaxYear.cs" company="Bauer Consumer Media Limited">
//    Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The tax year interface
    /// </summary>
    public interface ITaxYear : IKeyValueMappable
    {
        #region Properties

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Gets the start year.
        /// </summary>
        int StartYear
        {
            get;
        }

        /// <summary>
        /// Gets the personal income tax allowance.
        /// </summary>
        int PersonalIncomeTaxAllowance
        {
            get;
        }

        /// <summary>
        /// Gets the tax rates.
        /// </summary>
        List<ITaxRate> Rates
        {
            get;
        }

        #endregion
    }
}