// <copyright file="IComingSoonProvider.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    using System.Collections.Generic;

    /// <summary>
    /// Coming Soon provider interface
    /// </summary>
    public interface IComingSoonProvider
    {
        /// <summary>
        /// Gets the active coming soons.
        /// </summary>
        /// <returns>List of coming soons</returns>
        List<IComingSoon> GetActiveComingSoons();

        /// <summary>
        /// Gets the coming soon from id.
        /// </summary>
        /// <param name="id">The 'coming soon' id.</param>
        /// <returns>A coming soon</returns>
        IComingSoon GetComingSoonFromId(int id);
    }
}
