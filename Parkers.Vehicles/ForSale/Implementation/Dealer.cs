// <copyright file="Dealer.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Represents a vehicle for sale dealer
    /// </summary>
    internal sealed class Dealer : IDealer
    {
        #region Fields

        /// <summary>
        /// Address elements back field
        /// </summary>
        private readonly List<string> addressElements = new List<string>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Dealer"/> class.
        /// </summary>
        public Dealer()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the dealer id.
        /// </summary>
        public int DealerId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the supplier id.
        /// </summary>
        public int SupplierId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the address elements.
        /// </summary>
        public List<string> AddressElements
        {
            get
            {
                return this.addressElements;
            }
        }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the town.
        /// </summary>
        public string Town
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        public string Postcode
        {
            get;
            set;
        }

        #endregion
    }
}