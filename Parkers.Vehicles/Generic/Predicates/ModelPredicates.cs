using System;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Common filters for Manufacturer.FindModels
    /// </summary>
    public static class ModelPredicates
    {
        /// <summary>
        /// The model has a published review
        /// </summary>
        public static readonly Predicate<IModel> HasReview = (m => m.HasReview);

        /// <summary>
        /// The model is current and we know its list price
        /// </summary>
        public static readonly Predicate<IModel> NewPrices = (m => m.HasNewPrices);

        /// <summary>
        /// The model is still on sale
        /// </summary>
        public static readonly Predicate<IModel> Current = (m => !m.IsDiscontinued);

        /// <summary>
        /// The model is still on sale and has a review
        /// </summary>
        public static readonly Predicate<IModel> CurrentWithReview = (m => !m.IsDiscontinued && m.HasReview);

        /// <summary>
        /// The model has data for the Facts and Figures section
        /// </summary>
        public static readonly Predicate<IModel> TechData = (m => m.HasTechData);

        /// <summary>
        /// The model is still on sale and has data for the Facts and Figures section
        /// </summary>
        public static readonly Predicate<IModel> CurrentTechData = (m => m.HasNewPrices && m.HasTechData);

        /// <summary>
        /// The model has a review or at least on car for sale
        /// </summary>
        public static readonly Predicate<IModel> HasContent = (m => m.HasReview || ModelPredicates.UsedPrices(m));

        /// <summary>
        /// The model has at least one derivative with a PDF report
        /// </summary>
        public static readonly Predicate<IModel> PdfReport = (m => (m is ICarModel && ((ICarModel)m).HasPdfReport));

        /// <summary>
        /// The model has at least one derivative with used prices
        /// </summary>
        public static readonly Predicate<IModel> UsedPrices = (m => m.FromYearPlate != null && m.ToYearPlate != null);

        /// <summary>
        /// The model has at least one owner review
        /// </summary>
        [Obsolete]
        public static readonly Predicate<IModel> OwnerReviews = (m => m is ICarModel && (m as ICarModel).OwnerReviewCount > 0);

        /// <summary>
        /// The model has at least one derivative with a CO2 figure
        /// </summary>
        public static readonly Predicate<IModel> CO2 = (m => m is ICarModel && (m as ICarModel).HasDerivative(DerivativePredicates.CO2));

        /// <summary>
        /// The model has at least one derivative with an insurance group
        /// </summary>
        public static readonly Predicate<IModel> InsuranceGroup = (m => m.HasDerivative(d => (d is ICarDerivative && (d as ICarDerivative).InsuranceGroup > 0)));

    }
}
