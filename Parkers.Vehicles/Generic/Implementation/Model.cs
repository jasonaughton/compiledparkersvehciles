// <copyright file="Model.cs" company="Bauer Consumer Media Limited">
//    Copyright 2013 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings
    using System;
    using System.Collections.Generic;
    #endregion
    
    /// <summary>
    /// Represents a model
    /// </summary>
    public class Model : IModel
    {
        #region Fields
        
        /// <summary>
        /// Popularity rank backing field
        /// </summary>
        private int popularityRank = int.MinValue;

        /// <summary>
        /// Popularity backing field
        /// </summary>
        private double popularity = double.MinValue;

        /// <summary>
        /// The discontinued year backing field
        /// </summary>
        private int discontinuedYear = Int32.MaxValue;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the popularity rank.
        /// </summary>
        public int PopularityRank
        {
            get
            {
                return this.popularityRank;
            }

            set
            {
                this.popularityRank = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the popularity.
        /// </summary>
        public double Popularity
        {
            get
            {
                return this.popularity;
            }

            set
            {
                this.popularity = value;
            }
        }

        /// <summary>
        /// Gets or sets primary key on the model table
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the range id
        /// </summary>
        public int RangeId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the model name
        /// </summary>
        /// <remarks>e.g. "Focus Hatchback"</remarks>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the display name
        /// </summary>
        public virtual string DisplayName
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Gets or sets the name with years
        /// </summary>
        /// <remarks>eg " Focus Hatchback (05 on)"</remarks>
        public string NameWithYears
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the body style
        /// </summary>
        /// <remarks>eg "Avant", or "Hatchback"</remarks>
        public string BodyStyle
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets the production years
        /// </summary>
        /// <remarks>eg if discontinued: "1999 to 2005", if still in productions: "2005 on"</remarks>
        public string ProductionYears
        {
            get
            {
                string result;

                if (this.IsDiscontinued)
                {
                    result = Convert.ToString(this.IntroducedYear) + " to " + Convert.ToString(this.DiscontinuedYear);
                }
                else
                {
                    result = Convert.ToString(this.IntroducedYear) + " on ";
                }

                return result;
            }
        }

        /// <summary>
        /// Gets or sets the year in which the model was first sold
        /// </summary>
        public int IntroducedYear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the year in which the model was discontinued, or Int32.MaxValue if the model is still in production
        /// </summary>
        public int DiscontinuedYear
        {
            get
            {
                return this.discontinuedYear;
            }

            set
            {
                this.discontinuedYear = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the model still on sale?
        /// </summary>
        public bool IsDiscontinued
        {
            get
            {
                return (this.discontinuedYear < Int32.MaxValue);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether we have reviewed this model
        /// </summary>
        public bool HasReview
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether we have performance and dimension data for this model
        /// </summary>
        public bool HasTechData
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this model is current, and if we have list prices
        /// </summary>
        public bool HasNewPrices
        {
            get
            {
                return !this.IsDiscontinued && this.MinPriceNew > 0 && this.MaxPriceNew > 0;
            }
        }

        /// <summary>
        /// Gets or sets first YearPlate for which used prices are available
        /// </summary>
        public IYearPlate FromYearPlate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets last YearPlate for which used prices are available
        /// </summary>
        public IYearPlate ToYearPlate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Lowest list price
        /// </summary>
        public int MinPriceNew
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Highest list price
        /// </summary>
        public int MaxPriceNew
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Lowest used price
        /// </summary>
        public int MinPriceUsed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Highest used price
        /// </summary>
        public int MaxPriceUsed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the CAP range ID, used to query Look2Buy
        /// </summary>
        public string CAPRanId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the CAP bodystyle ID, used to query Look2Buy
        /// </summary>
        public string CAPBodyStyleId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets all images in the gallery for this model
        /// </summary>
        public virtual ReviewImageCollection Images
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the main review image for this model
        /// </summary>
        public ReviewImage MainImage
        {
            get
            {
                if (this.Images != null && this.Images.ContainsCategory((int)ReviewImageCategory.CutOut) && this.Images.ByCategory[(int)ReviewImageCategory.CutOut].Count > 0)
                {
                    return this.Images.ByCategory[(int)ReviewImageCategory.CutOut][0];
                }
                
                if (this.Images != null && this.Images.ContainsCategory((int)ReviewImageCategory.MainImage) && this.Images.ByCategory[(int)ReviewImageCategory.MainImage].Count > 0)
                {
                    return this.Images.ByCategory[(int)ReviewImageCategory.MainImage][0];
                }
                
                if (this.Images != null && this.Images.ContainsCategory((int)ReviewImageCategory.StaticExterior) && this.Images.ByCategory[(int)ReviewImageCategory.StaticExterior].Count > 0)
                {
                    return this.Images.ByCategory[(int)ReviewImageCategory.StaticExterior][0];
                }

                return null;
            }
        }

        /// <summary>
        /// Gets or sets the index of the URL variant.
        /// </summary>
        /// <value>
        /// The variant index which differenciates between distinct models for url purposes when they
        /// have the same property values used during URL construction/deconstruction
        /// </value>
        public int UrlVariantIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets Manufacturer to which this model belongs
        /// </summary>
        public IManufacturer Manufacturer
        {
            get
            {
                return this.Range.Manufacturer;
            }
        }

        /// <summary>
        /// Gets Range to which this model belongs
        /// </summary>
        public IRange Range
        {
            get
            {
                return this.GetRange();
            }
        }

        /// <summary>
        /// Gets all derivatives for this model
        /// </summary>
        public List<IDerivative> Derivatives
        {
            get
            {
                return this.GetAllDerivatives();
            }
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Override to return the trim and generic equipment information
        /// </summary>
        /// <returns>Returns null trim list</returns>
        public virtual TrimList GetTrimList()
        {
            return null;
        }
        
        /// <summary>
        /// Filter derivatives for some predicate
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <returns>The list of derivatives</returns>
        public ListOfDerivative FindDerivatives(Predicate<IDerivative> filter)
        {
            return this.GetAllDerivatives().FindAll(filter);
        }

        /// <summary>
        /// Does this model have at least one derivative matching the predicate?
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <returns>Whether it has a derivative</returns>
        public bool HasDerivative(Predicate<IDerivative> filter)
        {
            return this.GetAllDerivatives().Exists(filter);
        }

        /// <summary>
        /// Override to return all derivatives for this model
        /// </summary>
        /// <returns>The list of derivatives</returns>
        protected virtual List<IDerivative> GetAllDerivatives()
        {
            return null;
        }

        /// <summary>
        /// Override to return the range to which this model belongs
        /// </summary>
        /// <returns>Null range</returns>
        protected virtual IRange GetRange()
        {
            return null;
        }

        #endregion
    }
}
