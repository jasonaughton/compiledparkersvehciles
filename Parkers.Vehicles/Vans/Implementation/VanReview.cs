using System;
using System.Collections.Generic;
using StructureMap;

namespace Parkers.Vehicles
{
    internal class VanReview : IVanReview
    {
        private static IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();
        private static IVanReviewProvider vanReviewProvider = ObjectFactory.GetInstance<IVanReviewProvider>();

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

        public string Cargo
        {
            get
            {
                return _cargo;
            }
            set
            {
                _cargo = value;
            }
        }
        private string _cargo;

        public string Road
        {
            get
            {
                return _road;
            }
            set
            {
                _road = value;
            }
        }
        private string _road;

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

        public int CargoRating
        {
            get
            {
                return _cargoRating;
            }
            set
            {
                _cargoRating = value;
            }
        }
        private int _cargoRating;

        public int RoadRating
        {
            get
            {
                return _roadRating;
            }
            set
            {
                _roadRating = value;
            }
        }
        private int _roadRating;

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

        public string ModelIntroduced
        {
            get
            {
                return _modelIntroduced;
            }
            set
            {
                _modelIntroduced = value;
            }
        }
        private string _modelIntroduced;

        public string ModelDiscontinued
        {
            get
            {
                return _modelDiscontinued;
            }
            set
            {
                _modelDiscontinued = value;
            }
        }
        private string _modelDiscontinued;

        public IVanModel Model
        {
            get
            {
                return vanProvider.GetModelFromId(_id);
            }
        }

        public ReviewImageCollection Images
        {
            get
            {
                return vanProvider.GetImagesByModelId(this.Model.Id);
            }
        }

        public List<IVanDerivative> Derivatives
        {
            get
            {

                return vanReviewProvider.GetDerivativesFromId(_id);
            }
        }

        public string NewPriceRange
        {
            get
            {
                if (_minPriceNew > 0 && _maxPriceNew > 0)
                {
                    return _minPriceNew.ToString("£#,##0") + " - " + _maxPriceNew.ToString("£#,##0");
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


        public List<IVanModel> Alternatives
        {
            get
            {
                List<IVanModel> alternatives = new List<IVanModel>();
                foreach (int id in _alternativeIds)
                {
                    IVanModel m = VanModel.FromId(id);
                    if (m != null)
                    {
                        alternatives.Add(m);
                    }
                }
                return alternatives;
            }
        }

        public List<IVanModel> AlternativesWithReviews
        {
            get
            {
                return Alternatives.FindAll(
                    delegate(IVanModel m)
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
                    delegate(IVanModel m)
                    {
                        return m != null && m.HasReview;
                    }
                );
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
        /// Gets or sets the review's video id
        /// </summary>
        public string Video
        {
            get;
            set;
        }
    }
}
