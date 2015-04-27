// <copyright file="IEntity.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Contract for an entity that exposes an Id property 
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id value.</value>
        int Id
        {
            get;
            set;
        }
    }
}
