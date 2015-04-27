// <copyright file="IVanReview.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Defines van review
    /// </summary>
    public interface IVanReview
    {
        /// <summary>
        /// Gets or sets the against.
        /// </summary>
        /// <value>
        /// The against.
        /// </value>
        string Against
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the alternative ids.
        /// </summary>
        /// <value>
        /// The alternative ids.
        /// </value>
        List<int> AlternativeIds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the alternatives.
        /// </summary>
        List<IVanModel> Alternatives
        {
            get;
        }

        /// <summary>
        /// Gets the alternatives with reviews.
        /// </summary>
        List<IVanModel> AlternativesWithReviews
        {
            get;
        }

        /// <summary>
        /// Gets or sets the cargo.
        /// </summary>
        /// <value>
        /// The cargo.
        /// </value>
        string Cargo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cargo rating.
        /// </summary>
        /// <value>
        /// The cargo rating.
        /// </value>
        int CargoRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost value.
        /// </value>
        string Cost
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cost rating.
        /// </summary>
        /// <value>
        /// The cost rating.
        /// </value>
        int CostRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the derivatives.
        /// </summary>
        List<IVanDerivative> Derivatives
        {
            get;
        }

        /// <summary>
        /// Gets or sets for.
        /// </summary>
        /// <value>
        /// the For value.
        /// </value>
        string For
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has alternatives with reviews.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has alternatives with reviews; otherwise, <c>false</c>.
        /// </value>
        bool HasAlternativesWithReviews
        {
            get;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id value.
        /// </value>
        int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the IG range.
        /// </summary>
        string IGRange
        {
            get;
        }

        /// <summary>
        /// Gets the images.
        /// </summary>
        ReviewImageCollection Images
        {
            get;
        }

        /// <summary>
        /// Gets or sets the max IG.
        /// </summary>
        /// <value>
        /// The max IG.
        /// </value>
        int MaxIG
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the max price new.
        /// </summary>
        /// <value>
        /// The max price new.
        /// </value>
        int MaxPriceNew
        {
            get;
            set;
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
        /// Gets or sets the min IG.
        /// </summary>
        /// <value>
        /// The min IG.
        /// </value>
        int MinIG
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the min price new.
        /// </summary>
        /// <value>
        /// The min price new.
        /// </value>
        int MinPriceNew
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the min price used.
        /// </summary>
        /// <value>
        /// The min price used.
        /// </value>
        int MinPriceUsed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        IVanModel Model
        {
            get;
        }

        /// <summary>
        /// Gets or sets the model discontinued.
        /// </summary>
        /// <value>
        /// The model discontinued.
        /// </value>
        string ModelDiscontinued
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the model introduced.
        /// </summary>
        /// <value>
        /// The model introduced.
        /// </value>
        string ModelIntroduced
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the new price range.
        /// </summary>
        string NewPriceRange
        {
            get;
        }

        /// <summary>
        /// Gets or sets the reliability.
        /// </summary>
        /// <value>
        /// The reliability.
        /// </value>
        string Reliability
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the reliability rating.
        /// </summary>
        /// <value>
        /// The reliability rating.
        /// </value>
        int ReliabilityRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the road.
        /// </summary>
        /// <value>
        /// The road value.
        /// </value>
        string Road
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the road rating.
        /// </summary>
        /// <value>
        /// The road rating.
        /// </value>
        int RoadRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the safety.
        /// </summary>
        /// <value>
        /// The safety.
        /// </value>
        string Safety
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the safety rating.
        /// </summary>
        /// <value>
        /// The safety rating.
        /// </value>
        int SafetyRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>
        /// The summary.
        /// </value>
        string Summary
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the summary rating.
        /// </summary>
        /// <value>
        /// The summary rating.
        /// </value>
        int SummaryRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the used price range.
        /// </summary>
        string UsedPriceRange
        {
            get;
        }

        /// <summary>
        /// Gets or sets the wheel.
        /// </summary>
        /// <value>
        /// The wheel.
        /// </value>
        string Wheel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wheel rating.
        /// </summary>
        /// <value>
        /// The wheel rating.
        /// </value>
        int WheelRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the first published.
        /// </summary>
        /// <value>The first published.</value>
        DateTime FirstPublished
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        /// <value>The last updated.</value>
        DateTime LastUpdated
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the original author.
        /// </summary>
        string OriginalAuthor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the review's video id
        /// </summary>
        string Video
        {
            get;
            set;
        }
    }
}
