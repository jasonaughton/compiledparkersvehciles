// <copyright file="ICarFamily.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines car family
    /// </summary>
    public interface ICarFamily
    {
        /// <summary>
        /// Gets the identity.
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name of the car family.
        /// </value>
        string Name
        {
            get;
            set;
        }
    }
}
