// <copyright file="IDerivativeResult.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines derivative result
    /// </summary>
    public interface IDerivativeResult
    {
        /// <summary>
        /// Gets or sets the derivative.
        /// </summary>
        /// <value>
        /// The derivative.
        /// </value>
        ICarDerivative Derivative
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the plate text.
        /// </summary>
        string PlateText
        {
            get;
        }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        int Price
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the year plate.
        /// </summary>
        /// <value>
        /// The year plate.
        /// </value>
        IYearPlate YearPlate
        {
            get;
            set;
        }
    }
}
