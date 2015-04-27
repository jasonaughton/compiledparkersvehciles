using System;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Common filters for Model.FindDerivatives
    /// </summary>
    public static class DerivativePredicates
    {
        /// <summary>
        /// The derivative has data for the Facts and Figures section
        /// </summary>
        public static readonly Predicate<IDerivative> TechData = (d => d.HasTechData);

        /// <summary>
        /// The derivative is on sale and has data for the Facts and Figures section
        /// </summary>
        public static readonly Predicate<IDerivative> CurrentTechData = (d => d.IsDiscontinued == false && d.ListPrice > 0 && d.HasTechData);

        /// <summary>
        /// The derivative is current and we know its list price
        /// </summary>
        public static readonly Predicate<IDerivative> NewPrice = (d => d.IsDiscontinued == false && d.ListPrice > 0);

        /// <summary>
        /// The derivative is current and we know its list price
        /// </summary>
        public static readonly Predicate<IDerivative> UsedPrices = (d => d.FromYearPlate != null && d.ToYearPlate != null);

        /// <summary>
        /// The derivative has a PDF report available for download
        /// </summary>
        public static readonly Predicate<IDerivative> PdfReport = (d => d is ICarDerivative && ((ICarDerivative)d).HasPdfReport);

        /// <summary>
        /// The derivative has an insurance group
        /// </summary>
        public static readonly Predicate<IDerivative> InsuranceGroup = (d => d is ICarDerivative && ((ICarDerivative)d).InsuranceGroup > 0);

        /// <summary>
        /// The derivative has a CO2 figure
        /// </summary>
        public static readonly Predicate<IDerivative> CO2 = (d => d is ICarDerivative && ((ICarDerivative)d).CO2Emissions > 0);

    }
}
