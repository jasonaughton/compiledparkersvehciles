// <copyright file="OptionEqualityComparer.cs" company="Bauer Consumer Media Limited">
//   Copyright 2012 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    using System.Collections.Generic;

    /// <summary>
    /// Option equality comparer
    /// </summary>
    public sealed class OptionEqualityComparer : IEqualityComparer<IOption>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="first">The first object of type <paramref name="first"/> to compare.</param>
        /// <param name="second">The second object of type <paramref name="second"/> to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public bool Equals(IOption first, IOption second)
        {
            return first.Text.Equals(second.Text);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.
        /// </exception>
        public int GetHashCode(IOption obj)
        {
            return obj.Text.GetHashCode();
        }
    }
}
