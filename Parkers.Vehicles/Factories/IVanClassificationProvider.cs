// <copyright file="IVanClassificationProvider.cs" company="Bauer Consumer Media Limited">
//    Copyright 2015 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Van classification provider interface
    /// </summary>
    public interface IVanClassificationProvider
    {
        #region Methods

        /// <summary>
        /// Gets a classification from the id.
        /// </summary>
        /// <param name="id">The classification id.</param>
        /// <returns>The classification</returns>
        IVanClassification GetClassification(int id);

        #endregion
    }
}
