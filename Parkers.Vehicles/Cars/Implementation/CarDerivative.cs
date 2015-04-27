using System;
using System.Collections.Generic;
using StructureMap;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Implementation of Derivative for cars
    /// </summary>
    internal class CarDerivative : Derivative, ICarDerivative
    {
        internal int _imageId;

        #region Properties

        /// <summary>
        /// Gets or sets the ved full.
        /// </summary>
        /// <value>The ved full.</value>
        public decimal VedFull
        {
            get;
            set;
        }

        /// <summary>
        /// eg "LX"
        /// </summary>
        public string Trim
        {
            get
            {
                return _trim;
            }
            set
            {
                _trim = value;
            }
        }
        private string _trim;

        /// <summary>
        /// eg "1.6 Petrol"
        /// </summary>
        public string Engine
        {
            get
            {
                return _engine;
            }
            set
            {
                _engine = value;
            }
        }
        private string _engine;

        /// <summary>
        /// eg "Estate" where the model is called "3-Series Touring"
        /// </summary>
        public string OriginalBodystyle
        {
            get
            {
                return _originalBodystyle;
            }
            set
            {
                _originalBodystyle = value;
            }
        }
        private string _originalBodystyle;

        /// <summary>
        /// Are details of standard equipment and option prices available?
        /// </summary>
        public bool HasOptionData
        {
            get
            {
                return _hasOptionData;
            }
            set
            {
                _hasOptionData = value;
            }
        }
        private bool _hasOptionData;

        /// <summary>
        /// List of standard equipment and option prices
        /// </summary>
        public List<IOption> Options
        {
            get
            {
                if (_hasOptionData == false)
                {
                    return new List<IOption>();
                }

                if (_options == null)
                {
                    ICarProvider carProvider = ObjectFactory.GetInstance<ICarProvider>();

                    _options = carProvider.GetOptionsByDerivativeId(Id);
                }
                return _options;
            }
        }
        private List<IOption> _options;

        /// <summary>
        /// The CAP code, eg "BMX325XDS5EPIA4 1   "
        /// </summary>
        public string CapCode
        {
            get
            {
                return _capCode;
            }
            set
            {
                _capCode = value;
            }
        }
        private string _capCode;

        #region Tech data

        /// <summary>
        /// Predicted value three years after purchase
        /// </summary>
        public int ThreeYearValue
        {
            get
            {
                return _threeYearValue;
            }
            set
            {
                _threeYearValue = value;
            }
        }
        private int _threeYearValue;

        /// <summary>
        /// Parker's Target Price for the derivative
        /// </summary>
        public int TargetPrice
        {
            get
            {
                return _targetPrice;
            }
            set
            {
                _targetPrice = value;
            }
        }
        private int _targetPrice;

        /// <summary>
        /// 1 to 20
        /// </summary>
        public int InsuranceGroup
        {
            get
            {
                return _insuranceGroup;
            }
            set
            {
                _insuranceGroup = value;
            }
        }
        private int _insuranceGroup;

        /// <summary>
        /// e.g. 4
        /// </summary>
        public int Doors
        {
            get
            {
                return _doors;
            }
            set
            {
                _doors = value;
            }
        }
        private int _doors;

        /// <summary>
        /// e.g. 5
        /// </summary>
        public int Seats
        {
            get
            {
                return _seats;
            }
            set
            {
                _seats = value;
            }
        }
        private int _seats;

        /// <summary>
        /// Engine capacity
        /// </summary>
        public int CC
        {
            get
            {
                return _cc;
            }
            set
            {
                _cc = value;
            }
        }
        private int _cc;

        /// <summary>
        /// Number of cylinders
        /// </summary>
        public int Cylinders
        {
            get
            {
                return _cylinders;
            }
            set
            {
                _cylinders = value;
            }
        }
        private int _cylinders;

        /// <summary>
        /// Engine power in bhp
        /// </summary>
        public int Bhp
        {
            get
            {
                return _bhp;
            }
            set
            {
                _bhp = value;
            }
        }
        private int _bhp;

        /// <summary>
        /// Top speed in miles per hour
        /// </summary>
        public int TopSpeed
        {
            get
            {
                return _topSpeed;
            }
            set
            {
                _topSpeed = value;
            }
        }
        private int _topSpeed;

        /// <summary>
        /// 0-60 time in seconds
        /// </summary>
        public decimal ZeroToSixty
        {
            get
            {
                return _zeroToSixty;
            }
            set
            {
                _zeroToSixty = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether has body style.
        /// </summary>
        public bool HasBodyStyle
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
        /// Gets or sets a value indicating whether has transmission.
        /// </summary>
        public bool HasTransmission
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
        /// Gets or sets a value indicating whether has mpg.
        /// </summary>
        public bool HasMPG
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether has mileage.
        /// </summary>
        public bool HasMileage
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

        private decimal _zeroToSixty;

        /// <summary>
        /// Fuel consumption
        /// </summary>
        public int MilesPerGallon
        {
            get
            {
                return _milesPerGallon;
            }
            set
            {
                _milesPerGallon = value;
            }
        }
        private int _milesPerGallon;

        /// <summary>
        /// in mm
        /// </summary>
        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }
        private int _length;

        /// <summary>
        /// in mm
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        private int _width;

        /// <summary>
        /// in mm
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        private int _height;

        /// <summary>
        /// Engine torque in Newton-metres
        /// </summary>
        public int TorqueNm
        {
            get
            {
                return _torqueNm;
            }
            set
            {
                _torqueNm = value;
            }
        }
        private int _torqueNm;

        /// <summary>
        /// Engine torque in pound-feet
        /// </summary>
        public int TorqueLbFt
        {
            get
            {
                return _torqueLbFt;
            }
            set
            {
                _torqueLbFt = value;
            }
        }
        private int _torqueLbFt;

        /// <summary>
        /// in mm
        /// </summary>
        public int Wheelbase
        {
            get
            {
                return _wheelbase;
            }
            set
            {
                _wheelbase = value;
            }
        }
        private int _wheelbase;

        /// <summary>
        /// in litres
        /// </summary>
        public int LuggageCapacity
        {
            get
            {
                return _luggageCapacity;
            }
            set
            {
                _luggageCapacity = value;
            }
        }
        private int _luggageCapacity;

        /// <summary>
        /// in kg
        /// </summary>
        public int UnbrakedTowing
        {
            get
            {
                return _unbrakedTowing;
            }
            set
            {
                _unbrakedTowing = value;
            }
        }
        private int _unbrakedTowing;

        /// <summary>
        /// in metres
        /// </summary>
        public int TurningCircle
        {
            get
            {
                return _turningCircle;
            }
            set
            {
                _turningCircle = value;
            }
        }
        private int _turningCircle;

        // This fails in April 2009 - should get really all bands from the VED table
        /// <summary>
        /// A to G, or "F/G", or "-"
        /// </summary>
        public string VedBand
        {
            get
            {
                ICarTaxProvider carTaxProvider = ObjectFactory.GetInstance<ICarTaxProvider>();

                if (Discontinued < carTaxProvider.ChangeoverDate)
                {
                    return "-";
                }

                if (_vedBand == "G")
                {
                    if (Discontinued < carTaxProvider.BandGDate)
                    {
                        return "F";
                    }
                    else if (Introduced >= carTaxProvider.BandGDate)
                    {
                        return "G";
                    }
                    else
                    {
                        return "F/G";
                    }
                }
                else
                {
                    return _vedBand;
                }
            }
            set
            {
                _vedBand = value;
            }
        }
        private string _vedBand;


        /// <summary>
        /// Gets or sets the this year basic rate.
        /// </summary>
        /// <value>The this year basic rate.</value>
        public Int32 ThisYearBasicRate
        {
            get
            {
                return m_thisYearBasicRate;
            }
            set
            {
                m_thisYearBasicRate = value;
            }
        }
        private Int32 m_thisYearBasicRate;


        /// <summary>
        /// Gets or sets the this year higher rate.
        /// </summary>
        /// <value>The this year higher rate.</value>
        public Int32 ThisYearHigherRate
        {
            get
            {
                return m_thisYearHigherRate;
            }
            set
            {
                m_thisYearHigherRate = value;
            }
        }
        private Int32 m_thisYearHigherRate;


        /// <summary>
        /// Gets or sets the this year basic rate.
        /// </summary>
        /// <value>The this year basic rate.</value>
        public Int32 NextYearBasicRate
        {
            get
            {
                return m_nextYearBasicRate;
            }
            set
            {
                m_nextYearBasicRate = value;
            }
        }
        private Int32 m_nextYearBasicRate;


        /// <summary>
        /// Gets or sets the this year higher rate.
        /// </summary>
        /// <value>The this year higher rate.</value>
        public Int32 NextYearHigherRate
        {
            get
            {
                return m_nextYearHigherRate;
            }
            set
            {
                m_nextYearHigherRate = value;
            }
        }
        private Int32 m_nextYearHigherRate;


        /// <summary>
        /// Gets or sets the company car tax percentage.
        /// </summary>
        /// <value>The company car tax percentage.</value>
        public Int32 CompanyCarTaxPercentage
        {
            get
            {
                return m_companyCarTaxPercentage;
            }
            set
            {
                m_companyCarTaxPercentage = value;
            }
        }
        private Int32 m_companyCarTaxPercentage;

        #endregion

        #endregion
        
        #region Hierarchy glue

        /// <summary>
        /// The CarManufacturer to which this derivative belongs
        /// </summary>
        public new ICarManufacturer Manufacturer
        {
            get
            {
                return Range.Manufacturer;
            }
        }

        /// <summary>
        /// The CarRange to which this derivative belongs
        /// </summary>
        public new ICarRange Range
        {
            get
            {
                return Model.Range;
            }
        }

        /// <summary>
        /// The CarModel to which this derivative belongs
        /// </summary>
        public new ICarModel Model
        {
            get
            {
                return (ICarModel)GetModel();
            }
        }

        /// <summary>
        /// Backs the base.Model property
        /// </summary>
        /// <returns></returns>
        protected override IModel GetModel()
        {
            return CarModel.FromId(_modelId);
        }

        #endregion

        #region PDF reports

        /// <summary>
        /// The URL of the PDF for this derivative, or null if none exists
        /// </summary>
        public string PdfReportDownloadUrl
        {
            get
            {
                return PdfProvider.DownloadUrl(this);
            }
        }

        /// <summary>
        /// Does this derivative have a PDF available for download?
        /// </summary>
        public bool HasPdfReport
        {
            get
            {
                if (_hasPdfReport.HasValue)
                {
                    return _hasPdfReport.Value;
                }

                _hasPdfReport = PdfProvider.HasPdfReport(this);

                return _hasPdfReport.Value;
            }
        }
        private bool? _hasPdfReport = null;

        #endregion

        #region Static

        /// <summary>
        /// Get a CarDerivative from a CARDerId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static CarDerivative FromId(int id)
        {
            ICarProvider carProvider = ObjectFactory.GetInstance<ICarProvider>();

            return carProvider.GetDerivativeFromId(id) as CarDerivative;
        }

        /// <summary>
        /// Get a CarDerivative from a CAP code
        /// </summary>
        /// <param name="capCode"></param>
        /// <returns></returns>
        internal static CarDerivative FromCapCode(string capCode)
        {
            ICarProvider carProvider = ObjectFactory.GetInstance<ICarProvider>();

            return carProvider.GetDerivativeFromCapCode(capCode) as CarDerivative;
        }

        #endregion
    }
}
