using System;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Common filters for CarManufacturer.FindAll etc
    /// </summary>
    [Obsolete]
    public static class ManufacturerPredicates
    {


        /// <summary>
        /// The manufacturer has data for the Facts and Figures section
        /// </summary>
        public static readonly Predicate<IManufacturer> TechData = (m => m.HasTechData);

        /// <summary>
        /// The manufacturer has at least one model still on sale
        /// </summary>
        public static readonly Predicate<IManufacturer> Current = (m => !m.IsDiscontinued);

        /// <summary>
        /// The manufacturer has at least one model still on sale with a review
        /// </summary>
        public static readonly Predicate<IManufacturer> CurrentWithReview = (m => !m.IsDiscontinued && m.HasReview);

        /// <summary>
        /// The manufacturer has at least one model still on sale with data for the Facts and Figures section
        /// </summary>
        public static readonly Predicate<IManufacturer> CurrentTechData = (m => m.IsDiscontinued == false && m.HasTechData);

        /// <summary>
        /// The manufacturer has at least one review or at least on car for sale
        /// </summary>
        public static readonly Predicate<IManufacturer> HasContent = (m => m.HasModel(ModelPredicates.HasContent));

        /// <summary>
        /// Matches the given number of most popular manufacturers
        /// </summary>
        public static Predicate<IManufacturer> MostPopular(int count)
        {
            return (m => m.PopularityRank <= count);
        }

        /// <summary>
        /// The manufacturer has data for the Facts and Figures section
        /// </summary>
        public static readonly Predicate<IManufacturer> Review = (m => m.HasReview);


        /// <summary>
        /// The manufacturer has used prices
        /// </summary>
        public static readonly Predicate<ICarManufacturer> UsedPrices = (m => m.HasModel(ModelPredicates.UsedPrices));

        /// <summary>
        /// The manufacturer has a model with an owner review
        /// </summary>
        public static readonly Predicate<IManufacturer> OwnerReviews = (m => m.HasModel(ModelPredicates.OwnerReviews));

        /// <summary>
        /// The manufacturer has at least one derivative with a CO2 figure
        /// </summary>
        public static readonly Predicate<IManufacturer> CO2 = (m => m is ICarManufacturer && (m as ICarManufacturer).HasModel(ModelPredicates.CO2));

        /// <summary>
        /// The manufacturer has at least one derivative with an insurance group
        /// </summary>
        public static readonly Predicate<IManufacturer> InsuranceGroup = (m => m.HasModel(ModelPredicates.InsuranceGroup));

        /// <summary>
        /// The manufacturer has at least one derivative with a PDF report.
        /// </summary>
        public static readonly Predicate<IManufacturer> HasPdfReports = (m => m.HasModel(ModelPredicates.PdfReport));
    }


}
