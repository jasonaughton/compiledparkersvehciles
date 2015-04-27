using System;

namespace Parkers.Vehicles
{
    /// <summary>
    /// The lowest level of Parker's vehicle hierarchy, eg Ford Focus Hatchback (05 on) 1.6 LX 5d
    /// </summary>
    internal class Derivative : IDerivative
    {
        internal int _modelId;

        #region Properties

        /// <summary>
        /// Primary key from the derivative table
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        private int _id;

        /// <summary>
        /// eg "1.6 LX 5d"
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        private string _name;

        public virtual string DisplayName
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Date that the derivative was first on sale
        /// </summary>
        public DateTime Introduced
        {
            get
            {
                return _introduced;
            }
            set
            {
                _introduced = value;
            }
        }
        private DateTime _introduced;

        /// <summary>
        /// Date that the derivative was last on sale, or DateTime.MaxValue if still in production
        /// </summary>
        public DateTime Discontinued
        {
            get
            {
                return _discontinued;
            }
            set
            {
                _discontinued = value;
            }
        }
        private DateTime _discontinued;

        /// <summary>
        /// Is the derivative still in production?
        /// </summary>
        public bool IsDiscontinued
        {
            get
            {
                return (_discontinued < DateTime.Now);
            }
        }

        /// <summary>
        /// "P", "D", or "A" - Petrol, Diesel, Alternative
        /// </summary>
        public string FuelType
        {
            get
            {
                return _fuelType;
            }
            set
            {
                _fuelType = value;
            }
        }
        private string _fuelType;

        /// <summary>
        /// Gets the full name of the fuel type.
        /// </summary>
        public string FuelTypeFullName
        {
            get
            {
                return VehicleUtility.GetFuelTypeFullName(this.FuelType);
            }
        }

        /// <summary>
        /// "M" or "A"
        /// </summary>
        public string Transmission
        {
            get
            {
                return _transmission;
            }
            set
            {
                _transmission = value;
            }
        }
        private string _transmission;

        /// <summary>
        /// Gets the full name of the transmission.
        /// </summary>
        public string TransmissionFullName
        {
            get
            {
                return VehicleUtility.GetTransmissionFullName(this.Transmission);
            }
        }

        /// <summary>
        /// Price not including vat, ved and reg fee
        /// </summary>
        public int P11DPrice
        {
            get
            {
                return _p11dPrice;
            }
            set
            {
                _p11dPrice = value;
            }
        }
        private int _p11dPrice;

        /// <summary>
        /// On-the-road price including VAT, VED and registration fee
        /// </summary>
        /// <value>The on-the-road price.</value>
        public Int32 ListPrice
        {
            get
            {
                return m_ListPrice;
            }
            set
            {
                m_ListPrice = value;
            }
        }
        private Int32 m_ListPrice;

        /// <summary>
        /// Are details of dimensions, performance and running costs available?
        /// </summary>
        public bool HasTechData
        {
            get
            {
                return _hasTechData;
            }
            set
            {
                _hasTechData = value;
            }
        }
        private bool _hasTechData = false;

        /// <summary>
        /// First YearPlate for which used prices are available
        /// </summary>
        public IYearPlate FromYearPlate
        {
            get
            {
                return _fromYearPlate;
            }
            set
            {
                _fromYearPlate = value;
            }
        }
        private IYearPlate _fromYearPlate;

        /// <summary>
        /// Last YearPlate for which used prices are available
        /// </summary>
        public IYearPlate ToYearPlate
        {
            get
            {
                return _toYearPlate;
            }
            set
            {
                _toYearPlate = value;
            }
        }
        private IYearPlate _toYearPlate;

        /// <summary>
        /// Gets or sets the gears (eg "6 Speed")
        /// </summary>
        public string Gears
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fuel delivery (eg "Multi point fuel injection")
        /// </summary>
        public string FuelDelivery
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fuel capacity (in litres)
        /// </summary>
        public int FuelCapacity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the euro emissions.
        /// </summary>
        public int EuroEmissions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of valves
        /// </summary>
        public int Valves
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the co2 emissions (in g/km)
        /// </summary>
        public int CO2Emissions
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the Braked Towing weight.
        /// </summary>
        public int BrakedTowing
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public int Weight
        {
            get;
            set;
        }
        
        /// <summary>
        /// The Manufacturer to which this derivative belongs
        /// </summary>
        public IManufacturer Manufacturer
        {
            get
            {
                return Range.Manufacturer;
            }
        }

        /// <summary>
        /// The Range to which this derivative belongs
        /// </summary>
        public IRange Range
        {
            get
            {
                return Model.Range;
            }
        }

        /// <summary>
        /// The Model to which this derivative belongs
        /// </summary>
        public IModel Model
        {
            get
            {
                return GetModel();
            }
        }

        #endregion

        /// <summary>
        /// Override to return the model to which the derivative belongs
        /// </summary>
        /// <returns></returns>
        protected virtual IModel GetModel()
        {
            return null;
        }
    }
}
