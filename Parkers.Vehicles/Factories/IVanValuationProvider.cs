// <copyright file="IVanValuationProvider.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    using System.Collections.Generic;

    using Parkers.Vehicles.Valuations;

    /// <summary>
    /// Van valuation provider interface
    /// </summary>
    public interface IVanValuationProvider
    {
        /// <summary>
        /// Gets the derivatives by model and plate id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <param name="section">The section.</param>
        /// <returns>List of van derivatives</returns>
        List<IVanDerivative> GetDerivativesByModelAndPlateId(int modelId, int plateId, VanValuationSection section);

        /// <summary>
        /// Gets the plates by model id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <param name="section">The section.</param>
        /// <returns>List of year plates</returns>
        List<IYearPlate> GetPlatesByModelId(int modelId, VanValuationSection section);

        /// <summary>
        /// Gets the valuation.
        /// </summary>
        /// <param name="derivId">The derivative id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <param name="section">The section.</param>
        /// <returns>The Van valuation</returns>
        IVanValuation GetValuation(int derivId, int plateId, VanValuationSection section);
    }
}
