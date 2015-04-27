
// <copyright file="IVanProvider.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Van provider interface
    /// </summary>
    public interface IVanProvider : ISortableVehicleProvider
    {
        #region Methods

        /// <summary>
        /// Gets the derivative from cap code.
        /// </summary>
        /// <param name="capCode">The cap code.</param>
        /// <returns>Van derivative</returns>
        IVanDerivative GetDerivativeFromCapCode(string capCode);

        /// <summary>
        /// Gets the derivative from id.
        /// </summary>
        /// <param name="id">The derivative id.</param>
        /// <returns>Van derivative</returns>
        IVanDerivative GetDerivativeFromId(int id);

        /// <summary>
        /// Gets the derivatives from id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>list of van derivatives</returns>
        List<IVanDerivative> GetDerivativesFromId(int modelId);

        /// <summary>
        /// Gets the manufacturer from id.
        /// </summary>
        /// <param name="id">The manufacturer id.</param>
        /// <returns>Van manufacturer</returns>
        IVanManufacturer GetManufacturerFromId(int id);

        /// <summary>
        /// Gets the images by model id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>Collection of review images</returns>
        ReviewImageCollection GetImagesByModelId(int modelId);

        /// <summary>
        /// Gets the manufacturers.
        /// </summary>
        /// <returns>List of van manufacturers</returns>
        List<IVanManufacturer> GetManufacturers();

        /// <summary>
        /// Gets the model from id.
        /// </summary>
        /// <param name="id">The model id.</param>
        /// <returns>The Van model</returns>
        IVanModel GetModelFromId(int id);

        /// <summary>
        /// Gets the models by manufacturer id.
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id.</param>
        /// <returns>List of van models</returns>
        List<IVanModel> GetModelsByManufacturerId(int manufacturerId);

        /// <summary>
        /// Gets the models by range name and manufacturer identifier.
        /// </summary>
        /// <param name="range">The range name.</param>
        /// <param name="manufacturerId">The manufacturer identifier.</param>
        /// <returns>the models by range and manufacturer</returns>
        List<IVanModel> GetModelsByRangeNameAndManufacturerId(string range, int manufacturerId);

        /// <summary>
        /// Gets the range from id.
        /// </summary>
        /// <param name="id">The range id.</param>
        /// <returns>The Van range</returns>
        IVanRange GetRangeFromId(int id);

        /// <summary>
        /// Gets the ranges by manufacturer id.
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id.</param>
        /// <returns>List of van ranges</returns>
        List<IVanRange> GetRangesByManufacturerId(int manufacturerId);

        /// <summary>
        /// Gets the tech data derivatives from id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>List of van derivatives</returns>
        List<IVanDerivative> GetTechDataDerivativesFromId(int modelId);

        #endregion
    }
}
