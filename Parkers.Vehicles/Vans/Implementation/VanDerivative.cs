// <copyright file="VanDerivative.cs" company="Bauer Consumer Media Limited">
//    Copyright 2012 Bauer Consumer Media Limited
// </copyright>
namespace Parkers.Vehicles
{
    #region Usings
 
    using StructureMap;

    #endregion
    /// <summary>
    /// Implementation of Derivative for vans
    /// </summary>
    internal class VanDerivative : Derivative, IVanDerivative
    {
        #region Properties

        #region Tech data
        
        /// <summary>
        /// Gets or sets the Engine power in bhp
        /// </summary>
        public int Bhp
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Engine capacity
        /// </summary>
        public int CC
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Number of cylinders
        /// </summary>
        public int Cylinders
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the height in mm
        /// </summary>
        public int Height
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Insurance group (1 to 20)
        /// </summary>
        public int InsuranceGroup
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the miles per gallon.
        /// </summary>
        public int MilesPerGallon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the payload in kg
        /// </summary>
        public int Payload
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the seats.
        /// </summary>
        public int Seats
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the torque lb ft.
        /// </summary>
        public int TorqueLbFt
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the torque nm.
        /// </summary>
        public int TorqueNm
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the turning circle in metres
        /// </summary>
        public int TurningCircle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wheelbase in mm
        /// </summary>
        public int Wheelbase
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the width in mm
        /// </summary>
        public int Width
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fuel delivery
        /// </summary>
        public string FuelDelivery
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the gears
        /// </summary>
        public string Gears
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the front overhang.
        /// </summary>
        public int FrontOverhang
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the rear overhang.
        /// </summary>
        public int RearOverhang
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has co2 emissions.
        /// </summary>
        public bool HasCO2Emissions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has fuel type.
        /// </summary>
        public bool HasFuelType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has engine power.
        /// </summary>
        public bool HasEnginePower
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has payload.
        /// </summary>
        public bool HasPayload
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has torque.
        /// </summary>
        public bool HasTorque
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has braked towing.
        /// </summary>
        public bool HasBrakedTowing
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has seats.
        /// </summary>
        public bool HasSeats
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has transmission.
        /// </summary>
        public bool HasTransmission
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has engine size.
        /// </summary>
        public bool HasEngineSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has mpg.
        /// </summary>
        public bool HasMpg
        {
            get;
            set;
        }

        #endregion

        #region Hierachy Glue

        /// <summary>
        /// Gets the VanManufacturer to which this derivative belongs
        /// </summary>
        public new IVanManufacturer Manufacturer
        {
            get
            {
                return this.Range.Manufacturer;
            }
        }

        /// <summary>
        /// Gets the VanRange to which this derivative belongs
        /// </summary>
        public new IVanRange Range
        {
            get
            {
                return this.Model.Range;
            }
        }

        /// <summary>
        /// Gets the VanModel to which this derivative belongs
        /// </summary>
        public new IVanModel Model
        {
            get
            {
                return (VanModel)this.GetModel();
            }
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Get a VanDerivative from a VANDerId
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The van derivative</returns>
        internal static IVanDerivative FromId(int id)
        {
            IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

            return vanProvider.GetDerivativeFromId(id);
        }

        /// <summary>
        /// Backs the base.Model property
        /// </summary>
        /// <returns>The model</returns>
        protected override IModel GetModel()
        {
            IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

            return vanProvider.GetModelFromId(_modelId);
        }

        #endregion
    }
}
