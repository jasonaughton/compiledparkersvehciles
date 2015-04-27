// <copyright file="AdjustedVanValuation.cs" company="Bauer Consumer Media">
//   Copyright 2015 Bauer Consumer Media, All Rights Reserved
// </copyright>

namespace Parkers.Vehicles.Valuations.Implementation
{
    #region Usings
    using System;
    #endregion

    /// <summary>
    /// Adjusted valuation representation
    /// </summary>
    public class AdjustedVanValuation
    {
        #region Constants

        /// <summary>
        /// The amount to add to the cap data valuation to create the parkers valuation. 
        /// </summary>
        private const int ParkersAdditionalValue = 5;

        /// <summary>
        /// Constant that will round to the round to the nearest
        /// </summary>
        private const int RoundToNearest = 5;
        #endregion

        #region Fields

        /// <summary>
        /// The dealer price
        /// </summary>
        private int dealerPrice;

        /// <summary>
        /// The private seller
        /// </summary>
        private int privateSeller;

        /// <summary>
        /// The part ex
        /// </summary>
        private int partEx;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the mileage.
        /// </summary>
        /// <value>
        /// The mileage.
        /// </value>
        public int Mileage
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the dealer price.
        /// </summary>
        /// <value>
        /// The dealer price.
        /// </value>
        public int DealerPrice
        {
            get
            {
                return this.dealerPrice;
            }

            set
            {
                this.dealerPrice = this.CreateParkersValuation(value);
            }
        }

        /// <summary>
        /// Gets or sets the private seller.
        /// </summary>
        /// <value>
        /// The private seller.
        /// </value>
        public int PrivateSeller
        {
            get
            {
                return this.privateSeller;
            }

            set
            {
                this.privateSeller = this.CreateParkersValuation(value);
            }
        }

        /// <summary>
        /// Gets or sets the part ex.
        /// </summary>
        /// <value>
        /// The part ex.
        /// </value>
        public int PartEx
        {
            get
            {
                return this.partEx;
            }

            set
            {
                this.partEx = this.CreateParkersValuation(value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the parkers valuation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the parkers valuation</returns>
        private int CreateParkersValuation(int value)
        {
            return ((int)Math.Round((decimal)value / RoundToNearest) * RoundToNearest) + ParkersAdditionalValue;
        }

        #endregion
    }
}
