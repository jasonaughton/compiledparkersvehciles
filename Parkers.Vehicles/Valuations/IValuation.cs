// <copyright file="IValuation.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines valuation
    /// </summary>
    public interface IValuation
    {
        /// <summary>
        /// Gets or sets the derivative.
        /// </summary>
        /// <value>
        /// The derivative.
        /// </value>
        IDerivative Derivative
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the franchise dealer.
        /// </summary>
        /// <value>
        /// The franchise dealer.
        /// </value>
        int FranchiseDealer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the independent dealer.
        /// </summary>
        /// <value>
        /// The independent dealer.
        /// </value>
        int IndependentDealer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the mileage.
        /// </summary>
        /// <value>
        /// The mileage.
        /// </value>
        int Mileage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the original price.
        /// </summary>
        /// <value>
        /// The original price.
        /// </value>
        int OriginalPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the part exchange.
        /// </summary>
        /// <value>
        /// The part exchange.
        /// </value>
        int PartExchange
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the private good.
        /// </summary>
        /// <value>
        /// The private good.
        /// </value>
        int PrivateGood
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the private poor.
        /// </summary>
        /// <value>
        /// The private poor.
        /// </value>
        int PrivatePoor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        ValuationResultType Result
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the year.
        /// </summary>
        int Year
        {
            get;
        }

        /// <summary>
        /// Gets or sets the year plate.
        /// </summary>
        /// <value>
        /// The year plate.
        /// </value>
        IYearPlate YearPlate
        {
            get;
            set;
        }

        /// <summary>
        /// Abbreviates for SMS.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>input abbreviated for sms</returns>
        string AbbreviateForSms(string input);
    }
}
