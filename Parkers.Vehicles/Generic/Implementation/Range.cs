using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Parkers.Vehicles
{
    /// <summary>
    /// A set of models, eg Ford Focus (05 on)
    /// </summary>
    internal class Range : IRange
    {
        internal int _manufacturerId;

        #region Properties

        /// <summary>
        /// Primary key on the range table
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
        /// eg Focus
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

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>
        /// The name value.
        /// </value>
        /// <remarks>
        /// implemented to satisfy <see cref="IKeyValueMappable"/>
        /// </remarks>
        public virtual string DisplayName
        {
            get
            {
                return this.NameWithYears;
            }
        }

        /// <summary>
        /// eg Focus (05 on)
        /// </summary>
        public string NameWithYears
        {
            get
            {
                return _nameWithYears;
            }
            set
            {
                _nameWithYears = value;
            }
        }
        private string _nameWithYears;

        /// <summary>
        /// eg "1999 to 2005" or "2005 on"
        /// </summary>
        public string ProductionYears
        {
            get
            {
                if (IsDiscontinued)
                {
                    return Convert.ToString(IntroducedYear) + " to " + Convert.ToString(DiscontinuedYear);
                }
                else
                {
                    return Convert.ToString(IntroducedYear) + " on ";
                }
            }
        }

        /// <summary>
        /// First year in which the range was sold
        /// </summary>
        public int IntroducedYear
        {
            get
            {
                return _introducedYear;
            }
            set
            {
                _introducedYear = value;
            }
        }
        private int _introducedYear;

        /// <summary>
        /// The year in which the range was discontinued, or Int32.MaxValue if the range is still in production
        /// </summary>
        public int DiscontinuedYear
        {
            get
            {
                return _discontinuedYear;
            }
            set
            {
                _discontinuedYear = value;
            }
        }
        private int _discontinuedYear = Int32.MaxValue;

        /// <summary>
        /// Is the range still on sale?
        /// </summary>
        public bool IsDiscontinued
        {
            get
            {
                return (_discontinuedYear < Int32.MaxValue);
            }
        }

        /// <summary>
        /// The popularity rank in relation to other ranges based on Google Analytics page impressions, 1 = most popular
        /// </summary>
        public int PopularityRank
        {
            get
            {
                return popularityRank;
            }
            set
            {
                popularityRank = value;
            }
        }
        private int popularityRank;

        /// <summary>
        /// Gets or sets the popularity.
        /// </summary>
        /// <value>
        /// The popularity.
        /// </value>
        public double Popularity
        {
            get;
            set;
        }

        #endregion

        #region Hierarchy glue

        /// <summary>
        /// The Manufacturer to which this range belongs
        /// </summary>
        public IManufacturer Manufacturer
        {
            get
            {
                return GetManufacturer();
            }
        }

        /// <summary>
        /// Override to return the Manufacturer to which this range belongs
        /// </summary>
        /// <returns></returns>
        protected virtual IManufacturer GetManufacturer()
        {
            return null;
        }

        public List<IModel> Models
        {
            get
            {
                return Manufacturer.Models.FindAll(r => r.Range.Id == this.Id);
            }
        }

        /// <summary>
        /// Lowest list price for all models within this range
        /// </summary>
        public int MinPriceNew
        {
            get
            {
                return Models.Min(m => m.MinPriceNew);
            }
        }

        /// <summary>
        /// Highest list price for all models within this range
        /// </summary>
        public int MaxPriceNew
        {
            get
            {
                return Models.Max(m => m.MaxPriceNew);
            }
        }

        #endregion
    }
}
