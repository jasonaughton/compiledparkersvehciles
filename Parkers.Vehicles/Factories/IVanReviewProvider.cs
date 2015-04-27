// <copyright file="IVanReviewProvider.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    using System.Collections.Generic;

    /// <summary>
    /// Van review provider interface
    /// </summary>
    public interface IVanReviewProvider
    {
        /// <summary>
        /// Gets the derivatives from id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>List of van derivatives</returns>
        List<IVanDerivative> GetDerivativesFromId(int modelId);

        /// <summary>
        /// Gets the review from id.
        /// </summary>
        /// <param name="id">The review id.</param>
        /// <returns>The van review</returns>
        IVanReview GetReviewFromId(int id);
    }
}
