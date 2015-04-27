// <copyright file="TaxYear.cs" company="Bauer Consumer Media Limited">
//    Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// the tax rate class
    /// </summary>
    internal class TaxYear : ITaxYear
    {
        #region Fields

        /// <summary>
        /// The tax rate collection
        /// </summary>
        private readonly List<ITaxRate> rates = new List<ITaxRate>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the start year.
        /// </summary>
        public int StartYear
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the personal income tax allowance.
        /// </summary>
        public int PersonalIncomeTaxAllowance
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the tax rates.
        /// </summary>
        public List<ITaxRate> Rates
        {
            get
            {
                return this.rates;
            }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>
        /// The name value.
        /// </value>
        public string DisplayName
        {
            get 
            {
                return this.Name;
            }
        }

        #endregion
    }
}