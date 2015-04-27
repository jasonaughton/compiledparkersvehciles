using System;
using System.Collections.Generic;

namespace Parkers.Vehicles
{
    internal class CarReview : ICarReview
    {
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

        public string For
        {
            get
            {
                return _for;
            }
            set
            {
                _for = value;
            }
        }
        private string _for;

        public string Against
        {
            get
            {
                return _against;
            }
            set
            {
                _against = value;
            }
        }
        private string _against;

        public string Summary
        {
            get
            {
                return _summary;
            }
            set
            {
                _summary = value;
            }
        }
        private string _summary;

        public string Performance
        {
            get
            {
                return _performance;
            }
            set
            {
                _performance = value;
            }
        }
        private string _performance;

        public string Handling
        {
            get
            {
                return _handling;
            }
            set
            {
                _handling = value;
            }
        }
        private string _handling;

        public string Comfort
        {
            get
            {
                return _comfort;
            }
            set
            {
                _comfort = value;
            }
        }
        private string _comfort;

        public string Wheel
        {
            get
            {
                return _wheel;
            }
            set
            {
                _wheel = value;
            }
        }
        private string _wheel;

        public string Practicality
        {
            get
            {
                return _practicality;
            }
            set
            {
                _practicality = value;
            }
        }
        private string _practicality;

        public string Safety
        {
            get
            {
                return _safety;
            }
            set
            {
                _safety = value;
            }
        }
        private string _safety;

        public string Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }
        private string _cost;

        public string Reliability
        {
            get
            {
                return _reliability;
            }
            set
            {
                _reliability = value;
            }
        }
        private string _reliability;

        public string BuyingNew
        {
            get
            {
                return _buyingNew;
            }
            set
            {
                _buyingNew = value;
            }
        }
        private string _buyingNew;

        public string BuyingUsed
        {
            get
            {
                return _buyingUsed;
            }
            set
            {
                _buyingUsed = value;
            }
        }
        private string _buyingUsed;

        public string Selling
        {
            get
            {
                return _selling;
            }
            set
            {
                _selling = value;
            }
        }
        private string _selling;

        public string Equipment
        {
            get
            {
                return _equipment;
            }
            set
            {
                _equipment = value;
            }
        }
        private string _equipment;

        public string Green
        {
            get
            {
                return _green;
            }
            set
            {
                _green = value;
            }
        }
        private string _green;

        public string UpdateHeading
        {
            get
            {
                return _updateHeading;
            }
            set
            {
                _updateHeading = value;
            }
        }
        private string _updateHeading;

        public string UpdateBody
        {
            get
            {
                return _updateBody;
            }
            set
            {
                _updateBody = value;
            }
        }
        private string _updateBody;

        public int SummaryRating
        {
            get
            {
                return _summaryRating;
            }
            set
            {
                _summaryRating = value;
            }
        }
        private int _summaryRating;

        public int PerformanceRating
        {
            get
            {
                return _performanceRating;
            }
            set
            {
                _performanceRating = value;
            }
        }
        private int _performanceRating;

        public int HandlingRating
        {
            get
            {
                return _handlingRating;
            }
            set
            {
                _handlingRating = value;
            }
        }
        private int _handlingRating;

        public int ComfortRating
        {
            get
            {
                return _comfortRating;
            }
            set
            {
                _comfortRating = value;
            }
        }
        private int _comfortRating;

        public int WheelRating
        {
            get
            {
                return _wheelRating;
            }
            set
            {
                _wheelRating = value;
            }
        }
        private int _wheelRating;

        public int PracticalityRating
        {
            get
            {
                return _practicalityRating;
            }
            set
            {
                _practicalityRating = value;
            }
        }
        private int _practicalityRating;

        public int SafetyRating
        {
            get
            {
                return _safetyRating;
            }
            set
            {
                _safetyRating = value;
            }
        }
        private int _safetyRating;

        public int CostRating
        {
            get
            {
                return _costRating;
            }
            set
            {
                _costRating = value;
            }
        }
        private int _costRating;

        public int ReliabilityRating
        {
            get
            {
                return _reliabilityRating;
            }
            set
            {
                _reliabilityRating = value;
            }
        }
        private int _reliabilityRating;

        public int BuyingNewRating
        {
            get
            {
                return _buyingNewRating;
            }
            set
            {
                _buyingNewRating = value;
            }
        }
        private int _buyingNewRating;

        public int BuyingUsedRating
        {
            get
            {
                return _buyingUsedRating;
            }
            set
            {
                _buyingUsedRating = value;
            }
        }
        private int _buyingUsedRating;

        public int SellingRating
        {
            get
            {
                return _sellingRating;
            }
            set
            {
                _sellingRating = value;
            }
        }
        private int _sellingRating;

        public int EquipmentRating
        {
            get
            {
                return _equipmentRating;
            }
            set
            {
                _equipmentRating = value;
            }
        }
        private int _equipmentRating;

        public int GreenRating
        {
            get
            {
                return _greenRating;
            }
            set
            {
                _greenRating = value;
            }
        }
        private int _greenRating;

        public string CheckBody
        {
            get
            {
                return _checkBody;
            }
            set
            {
                _checkBody = value;
            }
        }
        private string _checkBody;

        public string CheckEngine
        {
            get
            {
                return _checkEngine;
            }
            set
            {
                _checkEngine = value;
            }
        }
        private string _checkEngine;

        public string CheckOther
        {
            get
            {
                return _checkOther;
            }
            set
            {
                _checkOther = value;
            }
        }
        private string _checkOther;

        public string Servicing
        {
            get
            {
                return _servicing;
            }
            set
            {
                _servicing = value;
            }
        }
        private string _servicing;

        public string Warranty
        {
            get
            {
                return _warranty;
            }
            set
            {
                _warranty = value;
            }
        }
        private string _warranty;

        public int MinPriceNew
        {
            get
            {
                return _minPriceNew;
            }
            set
            {
                _minPriceNew = value;
            }
        }
        private int _minPriceNew;

        public int MaxPriceNew
        {
            get
            {
                return _maxPriceNew;
            }
            set
            {
                _maxPriceNew = value;
            }
        }
        private int _maxPriceNew;

        public int MinPriceFRV36
        {
            get
            {
                return _minPriceFRV36;
            }
            internal set
            {
                _minPriceFRV36 = value;
            }
        }
        private int _minPriceFRV36;

        public int MaxPriceFRV36
        {
            get
            {
                return _maxPriceFRV36;
            }
            internal set
            {
                _maxPriceFRV36 = value;
            }
        }
        private int _maxPriceFRV36;

        public int MinPriceFRV12
        {
            get
            {
                return _minPriceFRV12;
            }
            internal set
            {
                _minPriceFRV12 = value;
            }
        }
        private int _minPriceFRV12;

        public int MaxPriceFRV12
        {
            get
            {
                return _maxPriceFRV12;
            }
            internal set
            {
                _maxPriceFRV12 = value;
            }
        }
        private int _maxPriceFRV12;

        public int MinPriceUsed
        {
            get
            {
                return _minPriceUsed;
            }
            set
            {
                _minPriceUsed = value;
            }
        }
        private int _minPriceUsed;

        public int MaxPriceUsed
        {
            get
            {
                return _maxPriceUsed;
            }
            set
            {
                _maxPriceUsed = value;
            }
        }
        private int _maxPriceUsed;

        public int MinIG
        {
            get
            {
                return _minIG;
            }
            set
            {
                _minIG = value;
            }
        }
        private int _minIG;

        public int MaxIG
        {
            get
            {
                return _maxIG;
            }
            set
            {
                _maxIG = value;
            }
        }
        private int _maxIG;

        public int CO2Min
        {
            get
            {
                return _co2min;
            }
            set
            {
                _co2min = value;
            }
        }
        internal int _co2min;

        public int CO2Max
        {
            get
            {
                return _co2max;
            }
            set
            {
                _co2max = value;
            }
        }
        internal int _co2max;

        public int NcapAdult
        {
            get
            {
                return _ncapAdult;
            }
            set
            {
                _ncapAdult = value;
            }
        }
        private int _ncapAdult;

        public int NcapChild
        {
            get
            {
                return _ncapChild;
            }
            set
            {
                _ncapChild = value;
            }
        }
        private int _ncapChild;

        public int NcapPedestrian
        {
            get
            {
                return _ncapPedestrian;
            }
            set
            {
                _ncapPedestrian = value;
            }
        }
        private int _ncapPedestrian;

        public List<int> AlternativeIds
        {
            get
            {
                return _alternativeIds;
            }
            set
            {
                _alternativeIds = value;
            }
        }
        private List<int> _alternativeIds = new List<int>();


        public List<ICarModel> Alternatives
        {
            get
            {
                List<ICarModel> alternatives = new List<ICarModel>();
                foreach (int id in _alternativeIds)
                {
                    ICarModel m = CarModel.FromId(id);
                    if (m != null)
                    {
                        alternatives.Add(m);
                    }
                }
                return alternatives;
            }
        }

        public List<ICarModel> AlternativesWithReviews
        {
            get
            {
                return Alternatives.FindAll(
                    delegate(ICarModel m)
                    {
                        return m != null && m.Review != null;
                    }
                    );
            }
        }

        public bool HasAlternativesWithReviews
        {
            get
            {
                return Alternatives.Exists(
                    delegate(ICarModel m)
                    {
                        return m != null && m.HasReview;
                    }
                );
            }
        }

        public string NewPriceRange
        {
            get
            {
                if (_minPriceNew > 0 && _maxPriceNew > 0)
                {
                    if (_minPriceNew.CompareTo(_maxPriceNew) == 0)
                    {
                        //value equal
                        return _minPriceNew.ToString("£#,##0");
                    }
                    else
                    {
                        return _minPriceNew.ToString("£#,##0") + " - " + _maxPriceNew.ToString("£#,##0");
                    }
                }
                else
                {
                    return "-";
                }
            }
        }

        public string FRV12PriceRange
        {
            get
            {
                if (_minPriceFRV12 > 0 && _maxPriceFRV12 > 0)
                {
                    return _minPriceFRV12.ToString("£#,##0") + " - " + _maxPriceFRV12.ToString("£#,##0");
                }
                else
                {
                    return "-";
                }
            }
        }

        public string FRV36PriceRange
        {
            get
            {
                if (_minPriceFRV36 > 0 && _maxPriceFRV36 > 0)
                {
                    return _minPriceFRV36.ToString("£#,##0") + " - " + _maxPriceFRV36.ToString("£#,##0");
                }
                else
                {
                    return "-";
                }
            }
        }

        public string UsedPriceRange
        {
            get
            {
                if (_minPriceUsed > 0 && _maxPriceUsed > 0)
                {
                    return _minPriceUsed.ToString("£#,##0") + " - " + _maxPriceUsed.ToString("£#,##0");
                }
                else
                {
                    return "-";
                }
            }
        }

        public string IGRange
        {
            get
            {
                if (_minIG > 0 && _maxIG > 0)
                {
                    if (_minIG == _maxIG)
                    {
                        return _maxIG.ToString();
                    }
                    else
                    {
                        return _minIG.ToString() + " - " + _maxIG.ToString();
                    }
                }
                else
                {
                    return "-";
                }
            }
        }


        public ICarModel Model
        {
            get
            {
                return CarModel.FromId(_id);
            }
        }

        public ReviewImageCollection Images
        {
            get
            {
                return Model.Images;
            }
        }

        /// <summary>
        /// Gets or sets the first published.
        /// </summary>
        /// <value>The first published.</value>
        public DateTime FirstPublished
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        /// <value>The last updated.</value>
        public DateTime LastUpdated
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the original author.
        /// </summary>
        public string OriginalAuthor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the company car info
        /// </summary>
        public string CompanyCarInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the model's video id
        /// </summary>
        public string Video
        {
            get;
            set;
        }
    }
}
