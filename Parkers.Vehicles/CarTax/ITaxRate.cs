// <copyright file="ITaxRate.cs" company="Bauer Consumer Media Limited">
//    Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// The tax rate interface
    /// </summary>
    public interface ITaxRate : IKeyValueMappable
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
        /// Gets the rate.
        /// </summary>
        int Rate
        {
            get;
        }

        /// <summary>
        /// Gets the minimum taxable value.
        /// </summary>
        int MinimumTaxableValue
        {
            get;
        }

        /// <summary>
        /// Gets the maximum taxable value.
        /// </summary>
        int MaximumTaxableValue
        {
            get;
        }

        #endregion
    }
}