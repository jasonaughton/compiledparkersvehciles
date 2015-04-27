using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Implementation of Model for cars
    /// </summary>
    public class CarModel : Model, ICarModel
    {
        private static ICarProvider carProvider = new CarProvider();

        private static IFuelPriceProvider fuelPriceProvider = new FuelPriceProvider();

        private const double litresPerGallon = 4.54609188d;

        private const double annualMileage = 10000d;

        #region Properties

        internal int _imageId;

        /// <summary>
        /// Supermini, Large 4x4, etc
        /// </summary>
        public ICarFamily Family
        {
            get
            {
                return _family;
            }
            set
            {
                _family = value;
            }
        }
        internal ICarFamily _family;

        /// <summary>
        /// eg "Estate" where the model is called "3-Series Touring"
        /// </summary>
        public string OriginalBodyStyle
        {
            get
            {
                return _originalBodyStyle;
            }
            set
            {
                _originalBodyStyle = value;
            }
        }
        private string _originalBodyStyle;

        /// <summary>
        /// eg "Saloon", "Estate", "4x4", "MPV"
        /// </summary>
        public string GenericBodyStyle
        {
            get
            {
                return _genericBodyStyle;
            }
            set
            {
                _genericBodyStyle = value;
            }
        }
        private string _genericBodyStyle;

        /// <summary>
        /// Number of adults that the model can comfortably seat, used by choosing tool
        /// </summary>
        public int AdultSeats
        {
            get
            {
                return _adultSeats;
            }
            set
            {
                _adultSeats = value;
            }
        }
        private int _adultSeats;

        /// <summary>
        /// Number of people that the model can seat while leaving space for their luggage, used by the choosing tool
        /// </summary>
        public int SeatsWithLuggage
        {
            get
            {
                return _seatsWithLuggage;
            }
            set
            {
                _seatsWithLuggage = value;
            }
        }
        private int _seatsWithLuggage;

        /// <summary>
        /// True where a range contains two models with the same bodystyle, e.g. Civic Hatchback and Civic Type R.
        /// Used to build Oodle searches.
        /// </summary>
        [Obsolete]
        public bool OtherModelsWithSameBodyOriginal
        {
            get
            {
                return _otherModelWithSameBodyOriginal;
            }
            set
            {
                _otherModelWithSameBodyOriginal = value;
            }
        }
        internal bool _otherModelWithSameBodyOriginal;

        /// <summary>
        /// The review for this model
        /// </summary>
        [Obsolete]
        public ICarReview Review
        {
            get
            {
                if (!HasReview)
                {
                    return null;
                }
                else
                {
                    ICarReview r = carProvider.GetReviewFromId(Id);
                    if (r == null)
                    {
                        HasReview = false;
                    }
                    return r;
                }
            }
        }

        /// <summary>
        /// Does this model have a car check list to buy?
        /// </summary>
        public bool HasCarCheck
        {
            get
            {
                return (Range.CarCheckProductId > 0);
            }
        }

        /// <summary>
        /// Number of owner reviews
        /// </summary>
        [Obsolete("Owners reviews now live in the index, so relying on this count from the database is unreliable")]
        public int OwnerReviewCount
        {
            get
            {
                return _ownerReviewCount;
            }
            set
            {
                _ownerReviewCount = value;
            }
        }
        private int _ownerReviewCount = 0;

        /// <summary>
        /// Smallest boot size in litres, used by the boot space part of reviews
        /// </summary>
        public int MinLuggageCapacity
        {
            get
            {
                return _minLuggageCapacity;
            }
            set
            {
                _minLuggageCapacity = value;
            }
        }
        internal int _minLuggageCapacity;

        /// <summary>
        /// Does at least one derivative have a PDF to download?
        /// </summary>
        public bool HasPdfReport
        {
            get
            {
                if (_hasPdfReport.HasValue)
                {
                    return _hasPdfReport.Value;
                }

                _hasPdfReport = HasDerivative(DerivativePredicates.PdfReport);

                return _hasPdfReport.Value;
            }
        }
        private bool? _hasPdfReport = null;


        #region Running cost ranges

        /// <summary>
        /// Lowest CO2 emission figure
        /// </summary>
        public virtual int CO2Min
        {
            get
            {
                return _MinCo2;
            }
        }
        internal int _MinCo2;

        /// <summary>
        /// Highest CO2 emissions figure
        /// </summary>
        public virtual int CO2Max
        {
            get
            {
                return _MaxCo2;
            }
        }
        internal int _MaxCo2;

        /// <summary>
        /// Lowest 3-year residual value
        /// </summary>
        public int MinPriceFRV36
        {
            get
            {
                return _minPriceFRV36;
            }
        }
        internal int _minPriceFRV36;

        /// <summary>
        /// Highest 3-year residual value
        /// </summary>
        public int MaxPriceFRV36
        {
            get
            {
                return _maxPriceFRV36;
            }
        }
        internal int _maxPriceFRV36;

        /// <summary>
        /// Lowest 1-year residual value
        /// </summary>
        public int MinPriceFRV12
        {
            get
            {
                return _minPriceFRV12;
            }
        }
        internal int _minPriceFRV12;

        /// <summary>
        /// Highest 1-year residual value
        /// </summary>
        public int MaxPriceFRV12
        {
            get
            {
                return _maxPriceFRV12;
            }
        }
        internal int _maxPriceFRV12;

        /// <summary>
        /// Highest fuel cost
        /// </summary>
        public int MaxAnnualFuelCost
        {
            get
            {
                return _maxAnnualFuelCost;
            }
        }
        internal int _maxAnnualFuelCost;

        /// <summary>
        /// Lowest fuel cost
        /// </summary>
        public int MinAnnualFuelCost
        {
            get
            {
                return _minAnnualFuelCost;
            }
        }
        internal int _minAnnualFuelCost;

        /// <summary>
        /// Highest annual road tax
        /// </summary>
        public decimal MaxVedFull
        {
            get
            {
                return _maxVedFull;
            }
        }
        internal decimal _maxVedFull;

        /// <summary>
        /// Lowest annual road tax
        /// </summary>
        public decimal MinVedFull
        {
            get
            {
                return _minVedFull;
            }
        }
        internal decimal _minVedFull;

        #endregion

        /// <summary>
        /// All gallery images
        /// </summary>
        public override ReviewImageCollection Images
        {
            get
            {
                return carProvider.GetImagesByModelId(Id);
            }
        }

        /// <summary>
        /// A link to appear in model lists
        /// </summary>
        public string FamilyPageUrl
        {
            get
            {
                if (_family == null)
                {
                    return null;
                }
                switch (_family.Id)
                {
                    case 2:
                    case 7:
                        return "/4x4/";
                    case 4:
                    case 8:
                        return "/small-cars/";
                    case 6:
                        return "/family-cars/";
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Text for a link to appear in model lists
        /// </summary>
        public string FamilyPageName
        {
            get
            {
                if (_family == null)
                {
                    return null;
                }
                switch (_family.Id)
                {
                    case 2:
                    case 7:
                        return "4x4s";
                    case 4:
                    case 8:
                        return "Small cars";
                    case 6:
                        return "Family cars";
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Gets the default name of the image.
        /// </summary>
        /// <value>
        /// The default name of the image.
        /// </value>
        public string DefaultImageName
        {
            get
            {
                return String.Concat(_imageId.ToString(), ".jpg");
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has company car data.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has company car data; otherwise, <c>false</c>.
        /// </value>
        public bool HasCompanyCarData
        {
            get
            {
                IDerivative firstWithData = this.Derivatives.Find(deriv => deriv is ICarDerivative && ((ICarDerivative)deriv).CO2Emissions > 0);

                return firstWithData != null;
            }
        }

        internal List<int> _relatedModelIds = new List<int>();
        public override string DisplayName
        {
            get
            {
                return this.NameWithYears;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is latest].
        /// </summary>
        public bool IsLatest
        {
            get;
            set;
        }

        #endregion

        public override TrimList GetTrimList()
        {
            return carProvider.GetTrimListFromModelId(Id);
        }

        #region Hierarchy glue

        /// <summary>
        /// The CarManufacturer to which this model belongs
        /// </summary>
        public new ICarManufacturer Manufacturer
        {
            get
            {
                return Range.Manufacturer;
            }
        }

        /// <summary>
        /// The CarRange to which this model belongs
        /// </summary>
        public new ICarRange Range
        {
            get
            {
                return (CarRange)GetRange();
            }
        }

        /// <summary>
        /// Backs the base.Range property
        /// </summary>
        /// <returns></returns>
        protected override IRange GetRange()
        {
            return CarRange.FromId(RangeId);
        }

        /// <summary>
        /// Filter derivatives for some predicate
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public new List<ICarDerivative> FindDerivatives(Predicate<IDerivative> filter)
        {
            return (List<ICarDerivative>)base.FindDerivatives(filter);
        }

        /// <summary>
        /// Backs the base.Derivatives property
        /// </summary>
        /// <returns></returns>
        protected override List<IDerivative> GetAllDerivatives()
        {
            return (ListOfDerivative)carProvider.GetDerivativesByModelId(Id);
        }

        #endregion

        #region Static

        /// <summary>
        /// Get a CarModel from a CARModId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static ICarModel FromId(int id)
        {
            return carProvider.GetModelFromId(id);
        }

        #endregion

        public int? GetMinDieselAnnualFuelCost(out int dieselPencePerlitre)
        {
            if (!this.HasDieselDerivatives)
            {
                dieselPencePerlitre = 0;
                return null;
            }

            ICarDerivative highestMpgDieselDerivative = (from ICarDerivative der in this.Derivatives
                                                         where (der.FuelType == "D" && der.MilesPerGallon > 0)
                                                         orderby der.MilesPerGallon descending
                                                         select der).FirstOrDefault() as ICarDerivative;



            if (highestMpgDieselDerivative == null)
            {
                dieselPencePerlitre = 0;
                return null;
            }

            double milesPerGallon = Convert.ToDouble(highestMpgDieselDerivative.MilesPerGallon);

            dieselPencePerlitre = Convert.ToInt32(fuelPriceProvider.DieselPrice);

            return this.GetAnnualFuelCost(milesPerGallon, dieselPencePerlitre);
        }

        public int? GetMaxDieselAnnualFuelCost(out int dieselPencePerlitre)
        {
            if (!this.HasDieselDerivatives)
            {
                dieselPencePerlitre = 0;
                return null;
            }

            ICarDerivative lowestMpgDieselDerivative = (from ICarDerivative der in this.Derivatives
                                                        where (der.FuelType == "D" && der.MilesPerGallon > 0)
                                                        orderby der.MilesPerGallon
                                                        select der).FirstOrDefault() as ICarDerivative;

            if (lowestMpgDieselDerivative == null)
            {
                dieselPencePerlitre = 0;
                return null;
            }

            double milesPerGallon = Convert.ToDouble(lowestMpgDieselDerivative.MilesPerGallon);

            dieselPencePerlitre = Convert.ToInt32(fuelPriceProvider.DieselPrice);

            return this.GetAnnualFuelCost(milesPerGallon, dieselPencePerlitre);
        }

        public int? GetMaxUnleadedAnnualFuelCost(out int unleadedPencePerLitre)
        {
            ICarDerivative lowestMpgUnleadedDerivative = (from ICarDerivative der in this.Derivatives
                                                          where (der.FuelType == "P" && der.MilesPerGallon > 0)
                                                          orderby der.MilesPerGallon
                                                          select der).FirstOrDefault() as ICarDerivative;

            if (lowestMpgUnleadedDerivative == null)
            {
                unleadedPencePerLitre = 0;
                return null;
            }

            double milesPerGallon = Convert.ToDouble(lowestMpgUnleadedDerivative.MilesPerGallon);

            unleadedPencePerLitre = Convert.ToInt32(fuelPriceProvider.PetrolPrice);

            return this.GetAnnualFuelCost(milesPerGallon, unleadedPencePerLitre);
        }

        public int? GetMinUnleadedAnnualFuelCost(out int unleadedPencePerLitre)
        {
            ICarDerivative highestMpgUnleadedDerivative = (from ICarDerivative der in this.Derivatives
                                                           where (der.FuelType == "P" && der.MilesPerGallon > 0)
                                                           orderby der.MilesPerGallon descending
                                                           select der).FirstOrDefault() as ICarDerivative;



            if (highestMpgUnleadedDerivative == null)
            {
                unleadedPencePerLitre = 0;
                return null;
            }

            double milesPerGallon = Convert.ToDouble(highestMpgUnleadedDerivative.MilesPerGallon);

            unleadedPencePerLitre = Convert.ToInt32(fuelPriceProvider.PetrolPrice);

            return this.GetAnnualFuelCost(milesPerGallon, unleadedPencePerLitre);
        }

        private int? GetAnnualFuelCost(double milesPerGallon, double fuelPencePerLitre)
        {
            double milesPerLitre = milesPerGallon / litresPerGallon;

            double annualLitres = annualMileage / milesPerLitre;

            double annualCostInPence = annualLitres * fuelPencePerLitre;

            int annualCostInPounds = Convert.ToInt32(annualCostInPence / 100d);

            return annualCostInPounds;
        }

        public bool HasDieselDerivatives
        {
            get
            {
                return this.Derivatives.Find(der => der.FuelType == "D") != null;
            }
        }
    }

}
