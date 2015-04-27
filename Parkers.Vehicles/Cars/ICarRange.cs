// <copyright file="ICarRange.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines car range
    /// </summary>
    public interface ICarRange : IRange
    {
        /// <summary>
        /// Gets or sets the car check product id.
        /// </summary>
        /// <value>
        /// The car check product id.
        /// </value>
        int CarCheckProductId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the car check snippet.
        /// </summary>
        /// <value>
        /// The car check snippet.
        /// </value>
        string CarCheckSnippet
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        new ICarManufacturer Manufacturer
        {
            get;
        }
    }
}
