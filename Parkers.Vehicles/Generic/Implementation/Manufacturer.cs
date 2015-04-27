using System;
using System.Collections.Generic;
using System.IO;

namespace Parkers.Vehicles
{
    /// <summary>
    /// A set of Ranges, eg Ford
    /// </summary>
    internal abstract class Manufacturer : IManufacturer
    {
        private string _logo;

        #region Properties

        /// <summary>
        /// The primary key on the Man table
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
        internal int _id;

        /// <summary>
        /// eg "Ford"
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
        internal string _name;

        public virtual string DisplayName
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// eg "www.ford.co.uk"
        /// </summary>
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }
        private string _url;

        /// <summary>
        /// 1 for the most-viewed manufacturer, and so on
        /// </summary>
        public int PopularityRank
        {
            get
            {
                return _popularityRank;
            }
            set
            {
                _popularityRank = value;
            }
        }
        internal int _popularityRank;

        /// <summary>
        /// Does this manufacturer have at least one model which is not discontinued?
        /// </summary>
        public bool IsDiscontinued
        {
            get
            {
                return _isDiscontinued;
            }
            set
            {
                _isDiscontinued = value;
            }
        }
        internal bool _isDiscontinued;

        /// <summary>
        /// Do we have a review for at least one model?
        /// </summary>
        public bool HasReview
        {
            get
            {
                return _hasReview;
            }
            set
            {
                _hasReview = value;
            }
        }
        private bool _hasReview = false;

        /// <summary>
        /// Do we have performance and dimensions data for at least one model?
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
        /// Gets the logo filename.
        /// </summary>
        public string LogoFileName
        {
            get
            {
                return this._logo;
            }
            internal set
            {
                this._logo = value;

                if (!String.IsNullOrEmpty(this._logo))
                {
                    this._logo.Replace(".gif", ".jpg").Replace("\\", "/");
                }
            }
        }

        #endregion

        #region Hierarchy glue

        /// <summary>
        /// All models for this manufacturer
        /// </summary>
        public List<IModel> Models
        {
            get
            {
                return GetAllModels();
            }
        }

        /// <summary>
        /// Filter models for some predicate
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ListOfModel FindModels(Predicate<IModel> filter)
        {
            return GetAllModels().FindAll(filter);
        }

        /// <summary>
        /// Does this manufacturer have at least one model matching the predicate?
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool HasModel(Predicate<IModel> filter)
        {
            return GetAllModels().Exists(filter);
        }

        /// <summary>
        /// Override to return all models for this manufacturer
        /// </summary>
        /// <returns></returns>
        protected virtual List<IModel> GetAllModels()
        {
            return null;
        }

        /// <summary>
        /// Override to return all ranges for this manufacturer
        /// </summary>
        /// <returns></returns>
        protected virtual List<IRange> GetAllRanges()
        {
            return null;
        }

        #endregion

    }


}
