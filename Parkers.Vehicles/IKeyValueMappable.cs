// <copyright file="IKeyValueMappable.cs" company="Bauer Consumer Media Limited">
//    Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines types that can be mapped to a convention based key value pair
    /// that uses Id property for key and DisplayName for value
    /// </summary>
    public interface IKeyValueMappable : IEntity
    {
        #region Properties

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>
        /// The name value.
        /// </value>
        string DisplayName
        {
            get;
        }

        #endregion
    }
}