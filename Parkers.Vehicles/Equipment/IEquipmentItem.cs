// <copyright file="IEquipmentItem.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines the equipment item
    /// </summary>
    public interface IEquipmentItem
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [on all].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [on all]; otherwise, <c>false</c>.
        /// </value>
        bool OnAll
        {
            get;
            set;
        }
    }
}
