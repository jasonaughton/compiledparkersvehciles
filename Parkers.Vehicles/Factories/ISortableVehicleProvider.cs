// <copyright file="ISortableVehicleProvider.cs" company="Bauer Consumer Media Limited">
//    Copyright 2012 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// sortable vehicle provider interface
    /// </summary>
    public interface ISortableVehicleProvider
    {
        #region Methods

        /// <summary>
        /// Gets the sort model from id.
        /// </summary>
        /// <param name="id">The model id.</param>
        /// <returns>The model</returns>
        IModel GetSortModelFromId(int id);

        #endregion
    }
}
