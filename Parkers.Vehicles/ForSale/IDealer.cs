// <copyright file="IDealer.cs" company="Bauer Consumer Media Limited">
//    Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The vehicle for sale dealer interface
    /// </summary>
    public interface IDealer
    {
        #region Properties

        /// <summary>
        /// Gets or sets the dealerid.
        /// </summary>
        int DealerId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the supplier id.
        /// </summary>
        int SupplierId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the address elements.
        /// </summary>
        List<string> AddressElements
        {
            get;
        }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        string PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the town.
        /// </summary>
        string Town
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        string Postcode
        {
            get;
            set;
        }

        #endregion
    }
}