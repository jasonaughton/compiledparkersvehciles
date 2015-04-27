// <copyright file="ITaxonomyProvider.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Taxonomy provider interface - represents utility methods to extract vehicle taxonomy related data
    /// </summary>
    public interface ITaxonomyProvider
    {
        /// <summary>
        /// Gets the models in range.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <param name="ran">The range.</param>
        /// <returns>List of models</returns>
        ListOfModel GetModelsInRange(ListOfModel models, IRange ran);

        /// <summary>
        /// Gets the name of the ranges with.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <param name="rangeName">Name of the range.</param>
        /// <returns>List of ranges</returns>
        ListOfRange GetRangesWithName(ListOfModel models, string rangeName);

        /// <summary>
        /// Gets the unique ranges.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>The list of ranges</returns>
        ListOfRange GetUniqueRanges(ListOfModel models);
    }
}
