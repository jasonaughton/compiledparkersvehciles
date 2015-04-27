// <copyright file="ICarValuationProvider.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Car valuation provider interface
    /// </summary>
    public interface ICarValuationProvider
    {
        /// <summary>
        /// Creates an empty valuation.
        /// </summary>
        /// <returns>A blank Valuation</returns>
        IValuation CreateValuation();

        /// <summary>
        /// Gets the available options.
        /// </summary>
        /// <param name="derivId">The derivative id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <returns>List of valuation options</returns>
        List<IValuationOption> GetAvailableOptions(int derivId, int plateId);

        /// <summary>
        /// Gets the derivatives by model and plate id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <returns>List of car derivatives</returns>
        List<ICarDerivative> GetDerivativesByModelAndPlateId(int modelId, int plateId);

        /// <summary>
        /// Gets the mileage adjusted valuation.
        /// </summary>
        /// <param name="derivId">The derivative id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <param name="mileage">The mileage.</param>
        /// <param name="section">The section.</param>
        /// <returns>The valuation</returns>
        IValuation GetMileageAdjustedValuation(int derivId, int plateId, int mileage, CarValuationSection section);

        /// <summary>
        /// Gets the option adjusted valuation.
        /// </summary>
        /// <param name="derivId">The derivative id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <param name="mileage">The mileage.</param>
        /// <param name="optionCodes">The option codes.</param>
        /// <param name="section">The section.</param>
        /// <returns>The valuation (with options)</returns>
        IValuationWithOptions GetOptionAdjustedValuation(int derivId, int plateId, int mileage, int[] optionCodes, CarValuationSection section);

        /// <summary>
        /// Gets the plates by model id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <param name="section">The section.</param>
        /// <returns>List of year plates</returns>
        List<IYearPlate> GetPlatesByModelId(int modelId, CarValuationSection section);

        /// <summary>
        /// Gets the plates by derivative id.
        /// </summary>
        /// <param name="derivative">The derivative.</param>
        /// <param name="section">The section.</param>
        /// <returns>List of year plates</returns>
        List<IYearPlate> GetPlatesByDerivative(ICarDerivative derivative, CarValuationSection section);

        /// <summary>
        /// Gets the valuation.
        /// </summary>
        /// <param name="derivId">The derivative id.</param>
        /// <param name="plateId">The plate id.</param>
        /// <param name="section">The section.</param>
        /// <returns>The valuation</returns>
        IValuation GetValuation(int derivId, int plateId, CarValuationSection section);

        /// <summary>
        /// Determines whether [is year plate available in section] [the specified plate id].
        /// </summary>
        /// <param name="plateId">The plate id.</param>
        /// <param name="section">The section.</param>
        /// <returns>
        ///   <c>true</c> if [is year plate available in section] [the specified plate id]; otherwise, <c>false</c>.
        /// </returns>
        bool IsYearPlateAvailableInSection(int plateId, CarValuationSection section);
    }
}
