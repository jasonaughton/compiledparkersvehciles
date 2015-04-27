// <copyright file="TaxRate.cs" company="Bauer Consumer Media Limited">
//    Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #endregion

    /// <summary>
    /// The tax rate class
    /// </summary>
    internal class TaxRate : ITaxRate
    {
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
        /// Gets or sets the rate.
        /// </summary>
        public int Rate
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the minimum taxable value.
        /// </summary>
        public int MinimumTaxableValue
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the maximum taxable value.
        /// </summary>
        public int MaximumTaxableValue
        {
            get;
            internal set;
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
                return String.Format("{0} ({1}%)",this.Name, this.Rate);
            }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id value.
        /// </value>
        public int Id
        {
            get;
            set;
        }

        #endregion
    }
}