// <copyright file="ICarProvider.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Data;

    #endregion

    /// <summary>
    /// Car provider interface
    /// </summary>
    public interface ICarProvider : ISortableVehicleProvider
    {
        #region Methods

        /// <summary>
        /// Gets the data version info.
        /// </summary>
        /// <returns>The latest data version and timestamp</returns>
        KeyValuePair<int, DateTime> GetDataVersionInfo();

        /// <summary>
        /// Sets the data version poll.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="server">The server.</param>
        void SetDataVersionPoll(int version, string server);

        /// <summary>
        /// Gets the server data versions.
        /// </summary>
        /// <returns>Data version by server</returns>
        IEnumerable<KeyValuePair<string, int>> GetServerDataVersions();
        
        /// <summary>
        /// Finds all manufacturers.
        /// </summary>
        /// <param name="filter">The filter predicate.</param>
        /// <returns>List of car manufacturers</returns>
        List<ICarManufacturer> FindAllManufacturers(Predicate<ICarManufacturer> filter);

        /// <summary>
        /// Gets the generic body styles for manufacturer.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <returns>Enumerable of generic body styles</returns>
        IEnumerable<string> GetGenericBodyStylesForManufacturer(ICarManufacturer manufacturer);

        /// <summary>
        /// Gets the derivative from cap code.
        /// </summary>
        /// <param name="capCode">The CAP code.</param>
        /// <returns>Car derivative</returns>
        ICarDerivative GetDerivativeFromCapCode(string capCode);

        /// <summary>
        /// Gets the derivative from id.
        /// </summary>
        /// <param name="id">The derivative id.</param>
        /// <returns>Car derivative</returns>
        ICarDerivative GetDerivativeFromId(int id);

        /// <summary>
        /// Gets the derivatives by model id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>List of car model derivatives</returns>
        List<ICarDerivative> GetDerivativesByModelId(int modelId);

        /// <summary>
        /// Gets all derivatives.
        /// </summary>
        /// <returns>All the car derivatives</returns>
        List<ICarDerivative> GetAllDerivatives();

        /// <summary>
        /// Gets the images by model id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>Collection of review images</returns>
        ReviewImageCollection GetImagesByModelId(int modelId);

        /// <summary>
        /// Gets the manufacturer from id.
        /// </summary>
        /// <param name="id">The manufacturer id.</param>
        /// <returns>Car manufacturer</returns>
        ICarManufacturer GetManufacturerFromId(int id);

        /// <summary>
        /// Gets the manufacturers.
        /// </summary>
        /// <returns>List of car manufacturers</returns>
        List<ICarManufacturer> GetManufacturers();

        /// <summary>
        /// Gets the model from id.
        /// </summary>
        /// <param name="id">The model id.</param>
        /// <returns>The Car model</returns>
        ICarModel GetModelFromId(int id);

        /// <summary>
        /// Gets the models by insurance group.
        /// </summary>
        /// <param name="group">The insurance group.</param>
        /// <returns>List of car models</returns>
        List<ICarModel> GetModelsByInsuranceGroup(int group);

        /// <summary>
        /// Gets the models by manufacturer id.
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id.</param>
        /// <returns>List of car models</returns>
        List<ICarModel> GetModelsByManufacturerId(int manufacturerId);

        /// <summary>
        /// Gets the models by range and manufacturer identifier.
        /// </summary>
        /// <param name="rangeName">The range name.</param>
        /// <param name="manufacturerId">The manufacturer identifier.</param>
        /// <returns>the models by range and manufacturer</returns>
        List<ICarModel> GetModelsByRangeNameAndManufacturer(string rangeName, int manufacturerId);

        /// <summary>
        /// Gets the options by derivative id.
        /// </summary>
        /// <param name="derivId">The derivative id.</param>
        /// <returns>List of options</returns>
        List<IOption> GetOptionsByDerivativeId(int derivId);

        /// <summary>
        /// Gets the range from id.
        /// </summary>
        /// <param name="id">The range id.</param>
        /// <returns>The Car range</returns>
        ICarRange GetRangeFromId(int id);

        /// <summary>
        /// Gets the ranges by manufacturer id.
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id.</param>
        /// <returns>List of car ranges</returns>
        List<ICarRange> GetRangesByManufacturerId(int manufacturerId);

        /// <summary>
        /// Gets the review from id.
        /// </summary>
        /// <param name="id">The review id.</param>
        /// <returns>The Car review</returns>
        ICarReview GetReviewFromId(int id);

        /// <summary>
        /// Gets the trim list from model id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>The Trim list</returns>
        TrimList GetTrimListFromModelId(int modelId);

        /// <summary>
        /// Gets the manufacturer ids with insurance info.
        /// </summary>
        /// <returns>A list of manufacturer ids with insurance info</returns>
        List<int> GetManufacturerIdsWithInsuranceInfo();

        /// <summary>
        /// Gets the model ids with insurance info.
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id.</param>
        /// <returns>A list of manufacturer model ids with insurance info</returns>
        List<int> GetManufacturerModelIdsWithInsuranceInfo(int manufacturerId);

        /// <summary>
        /// Gets the manufacturer ids with checklist.
        /// </summary>
        /// <returns>a list of ids of manufacturers with at least one checklist</returns>
        List<int> GetManufacturerIdsWithChecklist();

        /// <summary>
        /// Gets the range ids with checklist by manufacturer.
        /// </summary>
        /// <returns>a list of ids of ranges with a checklist for a given manufacturer</returns>
        /// <param name="manufacturerId">The manufacturer id</param>
        List<int> GetRangeIdsWithChecklistByManufacturer(int manufacturerId);

        /// <summary>
        /// Gets the trim equipment table.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>A table with rows for equipment items and a tri state flag for trim level (none - no derivatives have the equipment, some or all)</returns>
        DataTable GetModelTrimEquipmentTable(int modelId);

        #endregion
    }
}
