// <copyright file="ICarModel.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Defines car model
    /// </summary>
    public interface ICarModel : IModel
    {
        /// <summary>
        /// Gets or sets the adult seats.
        /// </summary>
        /// <value>
        /// The adult seats.
        /// </value>
        int AdultSeats
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the C o2 max.
        /// </summary>
        int CO2Max
        {
            get;
        }

        /// <summary>
        /// Gets the C o2 min.
        /// </summary>
        int CO2Min
        {
            get;
        }

        /// <summary>
        /// Gets or sets the family.
        /// </summary>
        /// <value>
        /// The family.
        /// </value>
        ICarFamily Family
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the name of the family page.
        /// </summary>
        /// <value>
        /// The name of the family page.
        /// </value>
        string FamilyPageName
        {
            get;
        }

        /// <summary>
        /// Gets the family page URL.
        /// </summary>
        string FamilyPageUrl
        {
            get;
        }

        /// <summary>
        /// Gets or sets the generic body style.
        /// </summary>
        /// <value>
        /// The generic body style.
        /// </value>
        string GenericBodyStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has car check.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has car check; otherwise, <c>false</c>.
        /// </value>
        bool HasCarCheck
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has diesel derivatives.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has diesel derivatives; otherwise, <c>false</c>.
        /// </value>
        bool HasDieselDerivatives
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has PDF report.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has PDF report; otherwise, <c>false</c>.
        /// </value>
        bool HasPdfReport
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has company car data.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has company car data; otherwise, <c>false</c>.
        /// </value>
        bool HasCompanyCarData
        {
            get;
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        new ICarManufacturer Manufacturer
        {
            get;
        }

        /// <summary>
        /// Gets the max annual fuel cost.
        /// </summary>
        int MaxAnnualFuelCost
        {
            get;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is current].
        /// </summary>
        bool IsLatest
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets the max diesel annual fuel cost.
        /// </summary>
        /// <returns></returns>
        int? GetMaxDieselAnnualFuelCost(out int dieselPencePerLitre);

        /// <summary>
        /// Gets the min diesel annual fuel cost.
        /// </summary>
        /// <returns></returns>
        int? GetMinDieselAnnualFuelCost(out int dieselPencePerLitre);

        /// <summary>
        /// Gets the max unleaded annual fuel cost.
        /// </summary>
        /// <returns></returns>
        int? GetMaxUnleadedAnnualFuelCost(out int unleadedPencePerLitre);

        /// <summary>
        /// Gets the min unleaded annual fuel cost.
        /// </summary>
        /// <returns></returns>
        int? GetMinUnleadedAnnualFuelCost(out int unleadedPencePerLitre);

        /// <summary>
        /// Gets the max price FR V12.
        /// </summary>
        int MaxPriceFRV12
        {
            get;
        }

        /// <summary>
        /// Gets the max price FR V36.
        /// </summary>
        int MaxPriceFRV36
        {
            get;
        }

        /// <summary>
        /// Gets the max ved full.
        /// </summary>
        decimal MaxVedFull
        {
            get;
        }

        /// <summary>
        /// Gets the min annual fuel cost.
        /// </summary>
        int MinAnnualFuelCost
        {
            get;
        }

        /// <summary>
        /// Gets or sets the min luggage capacity.
        /// </summary>
        /// <value>
        /// The min luggage capacity.
        /// </value>
        int MinLuggageCapacity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the min price FR V12.
        /// </summary>
        int MinPriceFRV12
        {
            get;
        }

        /// <summary>
        /// Gets the min price FR V36.
        /// </summary>
        int MinPriceFRV36
        {
            get;
        }

        /// <summary>
        /// Gets the min ved full.
        /// </summary>
        decimal MinVedFull
        {
            get;
        }

        /// <summary>
        /// Gets or sets the original body style.
        /// </summary>
        /// <value>
        /// The original body style.
        /// </value>
        string OriginalBodyStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [other models with same body original].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [other models with same body original]; otherwise, <c>false</c>.
        /// </value>
        [Obsolete]
        bool OtherModelsWithSameBodyOriginal
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the owner review count.
        /// </summary>
        /// <value>
        /// The owner review count.
        /// </value>
        [Obsolete("Owners reviews now live in the index, so relying on this count from the database is unreliable")]
        int OwnerReviewCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the range.
        /// </summary>
        new ICarRange Range
        {
            get;
        }

        /// <summary>
        /// Gets the review.
        /// </summary>
        ICarReview Review
        {
            get;
        }

        /// <summary>
        /// Gets or sets the seats with luggage.
        /// </summary>
        /// <value>
        /// The seats with luggage.
        /// </value>
        int SeatsWithLuggage
        {
            get;
            set;
        }

        /// <summary>
        /// Finds the derivatives.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>list of car derivatives</returns>
        new List<ICarDerivative> FindDerivatives(Predicate<IDerivative> filter);

        /// <summary>
        /// Gets the default name of the image.
        /// </summary>
        /// <value>
        /// The default name of the image.
        /// </value>
        string DefaultImageName
        {
            get;
        }
    }
}
