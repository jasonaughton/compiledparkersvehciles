// <copyright file="ITrim.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines trim
    /// </summary>
    public interface ITrim
    {
        /// <summary>
        /// Gets or sets the based on.
        /// </summary>
        /// <value>
        /// The based on.
        /// </value>
        string BasedOn
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the equipment.
        /// </summary>
        /// <value>
        /// The equipment.
        /// </value>
        EquipmentList Equipment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name value.
        /// </value>
        string Name
        {
            get;
            set;
        }
    }
}
