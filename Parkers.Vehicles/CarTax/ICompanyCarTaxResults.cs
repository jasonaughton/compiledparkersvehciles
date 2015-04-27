// <copyright file="ICompanyCarTaxResults.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines company car tax results
    /// </summary>
    public interface ICompanyCarTaxResults
    {
        /// <summary>
        /// Gets or sets the car annual tax.
        /// </summary>
        /// <value>
        /// The car annual tax.
        /// </value>
        decimal CarAnnualTax
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the car monthly tax.
        /// </summary>
        /// <value>
        /// The car monthly tax.
        /// </value>
        decimal CarMonthlyTax
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the car tax CAV.
        /// </summary>
        /// <value>
        /// The car tax CAV.
        /// </value>
        decimal CarTaxCAV
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the CC.
        /// </summary>
        /// <value>
        /// The cubic centilitres.
        /// </value>
        int CC
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the euro emissions.
        /// </summary>
        /// <value>
        /// The euro emissions.
        /// </value>
        int EuroEmissions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fuel annual tax.
        /// </summary>
        /// <value>
        /// The fuel annual tax.
        /// </value>
        int FuelAnnualTax
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fuel CAV.
        /// </summary>
        /// <value>
        /// The fuel CAV.
        /// </value>
        int FuelCAV
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fuel monthly tax.
        /// </summary>
        /// <value>
        /// The fuel monthly tax.
        /// </value>
        int FuelMonthlyTax
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the fuel.
        /// </summary>
        /// <value>
        /// The type of the fuel.
        /// </value>
        string FuelType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the grams per km.
        /// </summary>
        /// <value>
        /// The grams per km.
        /// </value>
        int GramsPerKm
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list.
        /// </summary>
        /// <value>
        /// The results list.
        /// </value>
        int List
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>
        /// The results rate.
        /// </value>
        float Rate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the tax benefit percent.
        /// </summary>
        /// <value>
        /// The tax benefit percent.
        /// </value>
        int TaxBenefitPercent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the tax year.
        /// </summary>
        /// <value>
        /// The tax year.
        /// </value>
        int TaxYear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the tax year text.
        /// </summary>
        string TaxYearText
        {
            get;
        }
    }
}
