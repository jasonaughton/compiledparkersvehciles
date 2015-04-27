// <copyright file="IDerivative.cs" company="Bauer Consumer Media">
//     Copyright 2011 Bauer Consumer Media, All Rights Reserved
// </copyright>

namespace Parkers.Vehicles
{
    using System;

    /// <summary>
    /// An interface representing the lowest level of Parker's vehicle hierarchy, eg Ford Focus Hatchback (05 on) 1.6 LX 5d
    /// </summary>
    public interface IDerivative : IKeyValueMappable
    {
        /// <summary>
        /// Gets or sets the date that the derivative was last on sale, or DateTime.MaxValue if still in production
        /// </summary>
        /// <value>
        /// The discontinued date
        /// </value>
        DateTime Discontinued
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets First YearPlate for which used prices are available
        /// </summary>
        IYearPlate FromYearPlate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets fuel type - "P", "D", or "A" - Petrol, Diesel, Alternative
        /// </summary>
        string FuelType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the full name of the fuel type.
        /// </summary>
        string FuelTypeFullName
        {
            get;
        }

        /// <summary>
        /// Gets or sets a value indicating whether details of dimensions, performance and running costs available?
        /// </summary>
        bool HasTechData
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Date that the derivative was first on sale
        /// </summary>
        /// <value>
        /// The introduced date
        /// </value>
        DateTime Introduced
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether the derivative still in production?
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is discontinued; otherwise, <c>false</c>.
        /// </value>
        bool IsDiscontinued
        {
            get;
        }

        /// <summary>
        /// Gets or sets On-the-road price including VAT, VED and registration fee
        /// </summary>
        /// <value>The on-the-road price.</value>
        int ListPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets The Manufacturer to which this derivative belongs
        /// </summary>
        IManufacturer Manufacturer
        {
            get;
        }

        /// <summary>
        /// Gets The Model to which this derivative belongs
        /// </summary>
        IModel Model
        {
            get;
        }

        /// <summary>
        /// Gets or sets name eg "1.6 LX 5d"
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Price not including vat, ved and reg fee
        /// </summary>
        int P11DPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets The Range to which this derivative belongs
        /// </summary>
        IRange Range
        {
            get;
        }

        /// <summary>
        /// Gets or sets Last YearPlate for which used prices are available
        /// </summary>
        IYearPlate ToYearPlate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets "M" or "A"
        /// </summary>
        string Transmission
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the full name of the transmission.
        /// </summary>
        string TransmissionFullName
        {
            get;
        }


        /// <summary>
        /// Gets or sets the fuel capacity.
        /// </summary>
        int FuelCapacity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fuel delivery.
        /// </summary>
        string FuelDelivery
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the gears.
        /// </summary>
        string Gears
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of valves
        /// </summary>
        int Valves
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the euro emissions.
        /// </summary>
        int EuroEmissions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the co2 emissions (in g/km)
        /// </summary>
        int CO2Emissions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Braked Towing weight.
        /// </summary>
        int BrakedTowing
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        int Weight
        {
            get;
            set;
        }
    }
}
