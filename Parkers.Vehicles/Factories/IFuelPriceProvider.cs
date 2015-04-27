// <copyright file="IFuelPriceProvider.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Fuel Price provider interface
    /// </summary>
    public interface IFuelPriceProvider
    {
        /// <summary>
        /// Gets the diesel price.
        /// </summary>
        double DieselPrice
        {
            get;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has real values.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has real values; otherwise, <c>false</c>.
        /// </value>
        bool HasRealValues
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the petrol price.
        /// </summary>
        double PetrolPrice
        {
            get;
        }
    }
}
