// <copyright file="ICarReview.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Data;

    #endregion

    /// <summary>
    /// Defines car review
    /// </summary>
    public interface ICarReview
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
        List<ICarModel> Alternatives
        {
            get;
        }

        /// <summary>
        /// Gets the alternatives with reviews.
        /// </summary>
        List<ICarModel> AlternativesWithReviews
        {
            get;
        }

        /// <summary>
        /// Gets or sets the buying new.
        /// </summary>
        /// <value>
        /// The buying new.
        /// </value>
        string BuyingNew
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the buying new rating.
        /// </summary>
        /// <value>
        /// The buying new rating.
        /// </value>
        int BuyingNewRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the buying used.
        /// </summary>
        /// <value>
        /// The buying used.
        /// </value>
        string BuyingUsed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the buying used rating.
        /// </summary>
        /// <value>
        /// The buying used rating.
        /// </value>
        int BuyingUsedRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the check body.
        /// </summary>
        /// <value>
        /// The check body.
        /// </value>
        string CheckBody
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the check engine.
        /// </summary>
        /// <value>
        /// The check engine.
        /// </value>
        string CheckEngine
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the check other.
        /// </summary>
        /// <value>
        /// The check other.
        /// </value>
        string CheckOther
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the C o2 max.
        /// </summary>
        /// <value>
        /// The C o2 max.
        /// </value>
        int CO2Max
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the C o2 min.
        /// </summary>
        /// <value>
        /// The C o2 min.
        /// </value>
        int CO2Min
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the comfort.
        /// </summary>
        /// <value>
        /// The comfort.
        /// </value>
        string Comfort
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the comfort rating.
        /// </summary>
        /// <value>
        /// The comfort rating.
        /// </value>
        int ComfortRating
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
        /// Gets or sets the equipment.
        /// </summary>
        /// <value>
        /// The equipment.
        /// </value>
        string Equipment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the equipment rating.
        /// </summary>
        /// <value>
        /// The equipment rating.
        /// </value>
        int EquipmentRating
        {
            get;
            set;
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
        /// Gets the FR V12 price range.
        /// </summary>
        string FRV12PriceRange
        {
            get;
        }

        /// <summary>
        /// Gets the FR V36 price range.
        /// </summary>
        string FRV36PriceRange
        {
            get;
        }

        /// <summary>
        /// Gets or sets the green.
        /// </summary>
        /// <value>
        /// The green.
        /// </value>
        string Green
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the green rating.
        /// </summary>
        /// <value>
        /// The green rating.
        /// </value>
        int GreenRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the handling.
        /// </summary>
        /// <value>
        /// The handling.
        /// </value>
        string Handling
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the handling rating.
        /// </summary>
        /// <value>
        /// The handling rating.
        /// </value>
        int HandlingRating
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
        ICarModel Model
        {
            get;
        }

        /// <summary>
        /// Gets or sets the ncap adult.
        /// </summary>
        /// <value>
        /// The ncap adult.
        /// </value>
        int NcapAdult
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ncap child.
        /// </summary>
        /// <value>
        /// The ncap child.
        /// </value>
        int NcapChild
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ncap pedestrian.
        /// </summary>
        /// <value>
        /// The ncap pedestrian.
        /// </value>
        int NcapPedestrian
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
        /// Gets or sets the performance.
        /// </summary>
        /// <value>
        /// The performance.
        /// </value>
        string Performance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the performance rating.
        /// </summary>
        /// <value>
        /// The performance rating.
        /// </value>
        int PerformanceRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the practicality.
        /// </summary>
        /// <value>
        /// The practicality.
        /// </value>
        string Practicality
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the practicality rating.
        /// </summary>
        /// <value>
        /// The practicality rating.
        /// </value>
        int PracticalityRating
        {
            get;
            set;
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
        /// Gets or sets the selling.
        /// </summary>
        /// <value>
        /// The selling.
        /// </value>
        string Selling
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the selling rating.
        /// </summary>
        /// <value>
        /// The selling rating.
        /// </value>
        int SellingRating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the servicing.
        /// </summary>
        /// <value>
        /// The servicing.
        /// </value>
        string Servicing
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
        /// Gets or sets the update body.
        /// </summary>
        /// <value>
        /// The update body.
        /// </value>
        string UpdateBody
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the update heading.
        /// </summary>
        /// <value>
        /// The update heading.
        /// </value>
        string UpdateHeading
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
        /// Gets or sets the warranty.
        /// </summary>
        /// <value>
        /// The warranty.
        /// </value>
        string Warranty
        {
            get;
            set;
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
        /// Gets or sets the company car info
        /// </summary>
        string CompanyCarInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the model's video id
        /// </summary>
        string Video
        {
            get;
        }
    }
}
