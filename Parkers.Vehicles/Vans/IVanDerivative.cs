// <copyright file="IVanDerivative.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines van derivative
    /// </summary>
    public interface IVanDerivative : IDerivative
    {
        /// <summary>
        /// Gets or sets the BHP.
        /// </summary>
        int Bhp
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
        /// Gets or sets the CC.
        /// </summary>
        int CC
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cylinders.
        /// </summary>
        int Cylinders
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        int Height
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the insurance group.
        /// </summary>
        int InsuranceGroup
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the miles per gallon.
        /// </summary>
        int MilesPerGallon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        int Payload
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the seats.
        /// </summary>
        int Seats
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the torque lb ft.
        /// </summary>
        int TorqueLbFt
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the torque nm.
        /// </summary>
        int TorqueNm
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the turning circle.
        /// </summary>
        int TurningCircle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wheelbase.
        /// </summary>
        int Wheelbase
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        int Width
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the front overhang.
        /// </summary>
        int FrontOverhang
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the rear overhang.
        /// </summary>
        int RearOverhang
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has co2 emissions.
        /// </summary>
        bool HasCO2Emissions
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
        /// Gets or sets a value indicating whether has engine power.
        /// </summary>
        bool HasEnginePower
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has payload.
        /// </summary>
        bool HasPayload
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has torque.
        /// </summary>
        bool HasTorque
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has braked towing.
        /// </summary>
        bool HasBrakedTowing
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
        /// Gets or sets a value indicating whether has transmission.
        /// </summary>
        bool HasTransmission
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

        /// <summary>
        /// Gets or sets a value indicating whether has mpg.
        /// </summary>
        bool HasMpg
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        new IVanManufacturer Manufacturer
        {
            get;
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        new IVanModel Model
        {
            get;
        }

        /// <summary>
        /// Gets the range.
        /// </summary>
        new IVanRange Range
        {
            get;
        }

    }
}
