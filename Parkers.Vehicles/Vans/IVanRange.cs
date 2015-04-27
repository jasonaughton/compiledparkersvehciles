// <copyright file="IVanRange.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines van range
    /// </summary>
    public interface IVanRange : IRange
    {
        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        new IVanManufacturer Manufacturer
        {
            get;
        }
    }
}
