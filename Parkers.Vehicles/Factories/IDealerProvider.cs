// <copyright file="IDealerProvider.cs" company="Bauer Consumer Media Limited">
//    Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// The dealer provider interface
    /// </summary>
    public interface IDealerProvider
    {
        #region Methods

        /// <summary>
        /// Gets the dealer.
        /// </summary>
        /// <param name="supplierId">The supplier id.</param>
        /// <param name="dealerId">The dealer id.</param>
        /// <returns>The dealer object</returns>
        IDealer GetDealer(int supplierId, int dealerId);

        /// <summary>
        /// Gets the dealer.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="address">The address value.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="town">The town value.</param>
        /// <returns>The dealer object</returns>
        IDealer GetDealer(string name, string address, string phoneNumber, string postcode, string town);

        #endregion
    }
}