// <copyright file="carRangeEqualityComparer.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    using System.Collections.Generic;

    /// <summary>
    /// Compares ranges on their Name property
    /// </summary>
    public class CarRangeEqualityComparer : IEqualityComparer<ICarRange>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="first">The first car range to compare.</param>
        /// <param name="second">The second car range to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public bool Equals(ICarRange first, ICarRange second)
        {
            return first.Name == second.Name;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="range">The <see cref="T:System.Object"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        /// <exception cref="T:System.ArgumentNullException">The type of obj is a reference type and obj is null.</exception>
        public int GetHashCode(ICarRange range)
        {
            return string.Concat(range.Name).GetHashCode();
        }
    }
}
