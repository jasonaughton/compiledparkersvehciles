// <copyright file="ICarDerivative.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Defines car derivative
    /// </summary>
    public interface ICarDerivative : IDerivative
    {
        /// <summary>
        /// Gets or sets the BHP.
        /// </summary>
        /// <value>
        /// The brake horsepower.
        /// </value>
        int Bhp
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cap code.
        /// </summary>
        /// <value>
        /// The cap code.
        /// </value>
        string CapCode
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
        /// Gets or sets the C o2 emissions.
        /// </summary>
        /// <value>
        /// The C o2 emissions.
        /// </value>
        int CO2Emissions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the company car tax percentage.
        /// </summary>
        /// <value>
        /// The company car tax percentage.
        /// </value>
        int CompanyCarTaxPercentage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cylinders.
        /// </summary>
        /// <value>
        /// The cylinders.
        /// </value>
        int Cylinders
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the doors.
        /// </summary>
        /// <value>
        /// The doors.
        /// </value>
        int Doors
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the engine.
        /// </summary>
        /// <value>
        /// The engine.
        /// </value>
        string Engine
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has option data.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has option data; otherwise, <c>false</c>.
        /// </value>
        bool HasOptionData
        {
            get;
            set;
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
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        int Height
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the insurance group.
        /// </summary>
        /// <value>
        /// The insurance group.
        /// </value>
        int InsuranceGroup
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        int Length
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the luggage capacity.
        /// </summary>
        /// <value>
        /// The luggage capacity.
        /// </value>
        int LuggageCapacity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        new ICarManufacturer Manufacturer
        {
            get;
        }

        /// <summary>
        /// Gets or sets the miles per gallon.
        /// </summary>
        /// <value>
        /// The miles per gallon.
        /// </value>
        int MilesPerGallon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        new ICarModel Model
        {
            get;
        }

        /// <summary>
        /// Gets or sets the next year basic rate.
        /// </summary>
        /// <value>
        /// The next year basic rate.
        /// </value>
        int NextYearBasicRate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the next year higher rate.
        /// </summary>
        /// <value>
        /// The next year higher rate.
        /// </value>
        int NextYearHigherRate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        List<IOption> Options
        {
            get;
        }

        /// <summary>
        /// Gets or sets the original bodystyle.
        /// </summary>
        /// <value>
        /// The original bodystyle.
        /// </value>
        string OriginalBodystyle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the PDF report download URL.
        /// </summary>
        string PdfReportDownloadUrl
        {
            get;
        }

        /// <summary>
        /// Gets the range.
        /// </summary>
        new ICarRange Range
        {
            get;
        }

        /// <summary>
        /// Gets or sets the seats.
        /// </summary>
        /// <value>
        /// The seats.
        /// </value>
        int Seats
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the target price.
        /// </summary>
        /// <value>
        /// The target price.
        /// </value>
        int TargetPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the this year basic rate.
        /// </summary>
        /// <value>
        /// The this year basic rate.
        /// </value>
        int ThisYearBasicRate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the this year higher rate.
        /// </summary>
        /// <value>
        /// The this year higher rate.
        /// </value>
        int ThisYearHigherRate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the three year value.
        /// </summary>
        /// <value>
        /// The three year value.
        /// </value>
        int ThreeYearValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the top speed.
        /// </summary>
        /// <value>
        /// The top speed.
        /// </value>
        int TopSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the torque lb ft.
        /// </summary>
        /// <value>
        /// The torque lb ft.
        /// </value>
        int TorqueLbFt
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the torque nm.
        /// </summary>
        /// <value>
        /// The torque nm.
        /// </value>
        int TorqueNm
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the trim.
        /// </summary>
        /// <value>
        /// The trim of the car.
        /// </value>
        string Trim
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the turning circle.
        /// </summary>
        /// <value>
        /// The turning circle.
        /// </value>
        int TurningCircle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the unbraked towing.
        /// </summary>
        /// <value>
        /// The unbraked towing.
        /// </value>
        int UnbrakedTowing
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the valves.
        /// </summary>
        /// <value>
        /// The valves.
        /// </value>
        int Valves
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ved band.
        /// </summary>
        /// <value>
        /// The ved band.
        /// </value>
        string VedBand
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ved full.
        /// </summary>
        /// <value>The ved full.</value>
        decimal VedFull
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wheelbase.
        /// </summary>
        /// <value>
        /// The wheelbase.
        /// </value>
        int Wheelbase
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        int Width
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the zero to sixty.
        /// </summary>
        /// <value>
        /// The zero to sixty.
        /// </value>
        decimal ZeroToSixty
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has body style.
        /// </summary>
        bool HasBodyStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has fuel type.
        /// </summary>
        bool HasFuelType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has transmission.
        /// </summary>
        bool HasTransmission
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has seats.
        /// </summary>
        bool HasSeats
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has mpg.
        /// </summary>
        bool HasMPG
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has mileage.
        /// </summary>
        bool HasMileage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has engine size.
        /// </summary>
        bool HasEngineSize
        {
            get;
            set;
        }
    }
}
