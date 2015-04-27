// <copyright file="IModel.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Defines model
    /// </summary>
    public interface IModel : IKeyValueMappable
    {
        /// <summary>
        /// Gets or sets the popularity rank.
        /// </summary>
        /// <value>The popularity rank.</value>
        int PopularityRank
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the popularity.
        /// </summary>
        /// <value>The popularity.</value>
        double Popularity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the body style.
        /// </summary>
        /// <value>
        /// The body style.
        /// </value>
        string BodyStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the CAP body style id.
        /// </summary>
        /// <value>
        /// The CAP body style id.
        /// </value>
        string CAPBodyStyleId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the CAP ran id.
        /// </summary>
        /// <value>
        /// The CAP ran id.
        /// </value>
        string CAPRanId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the derivatives.
        /// </summary>
        List<IDerivative> Derivatives
        {
            get;
        }

        /// <summary>
        /// Gets or sets the discontinued year.
        /// </summary>
        /// <value>
        /// The discontinued year.
        /// </value>
        int DiscontinuedYear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets from year plate.
        /// </summary>
        /// <value>
        /// From year plate.
        /// </value>
        IYearPlate FromYearPlate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has new prices.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has new prices; otherwise, <c>false</c>.
        /// </value>
        bool HasNewPrices
        {
            get;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has review.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has review; otherwise, <c>false</c>.
        /// </value>
        bool HasReview
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has tech data.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has tech data; otherwise, <c>false</c>.
        /// </value>
        bool HasTechData
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the images.
        /// </summary>
        ReviewImageCollection Images
        {
            get;
        }

        /// <summary>
        /// Gets or sets the introduced year.
        /// </summary>
        /// <value>
        /// The introduced year.
        /// </value>
        int IntroducedYear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is discontinued.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is discontinued; otherwise, <c>false</c>.
        /// </value>
        bool IsDiscontinued
        {
            get;
        }

        /// <summary>
        /// Gets the main image.
        /// </summary>
        ReviewImage MainImage
        {
            get;
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        IManufacturer Manufacturer
        {
            get;
        }

        /// <summary>
        /// Gets the max price new.
        /// </summary>
        int MaxPriceNew
        {
            get;
        }

        /// <summary>
        /// Gets or sets the max price used.
        /// </summary>
        /// <value>
        /// The max price used.
        /// </value>
        int MaxPriceUsed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the min price new.
        /// </summary>
        int MinPriceNew
        {
            get;
        }

        /// <summary>
        /// Gets the min price used.
        /// </summary>
        int MinPriceUsed
        {
            get;
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

        /// <summary>
        /// Gets or sets the name with years.
        /// </summary>
        /// <value>
        /// The name with years.
        /// </value>
        string NameWithYears
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the production years.
        /// </summary>
        string ProductionYears
        {
            get;
        }

        /// <summary>
        /// Gets the range.
        /// </summary>
        IRange Range
        {
            get;
        }

        /// <summary>
        /// Gets or sets to year plate.
        /// </summary>
        /// <value>
        /// To year plate.
        /// </value>
        IYearPlate ToYearPlate
        {
            get;
            set;
        }


        /// <summary>
        /// Gets the index of the URL variant.
        /// </summary>
        /// <value>
        /// The variant index which differenciates between distinct models for url purposes when they
        /// have the same property values used during URL construction/deconstruction
        /// </value>
        int UrlVariantIndex
        {
            get;
        }

        /// <summary>
        /// Finds the derivatives.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>list of derivatives</returns>
        ListOfDerivative FindDerivatives(Predicate<IDerivative> filter);

        /// <summary>
        /// Gets the trim list.
        /// </summary>
        /// <returns>a trim list</returns>
        TrimList GetTrimList();

        /// <summary>
        /// Determines whether the specified filter has derivative.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        ///     <c>true</c> if the specified filter has derivative; otherwise, <c>false</c>.
        /// </returns>
        bool HasDerivative(Predicate<IDerivative> filter);
    }
}
