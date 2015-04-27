// <copyright file="VanModel.cs" company="Bauer Consumer Media Limited">
//    Copyright 2015 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using StructureMap;

    #endregion

    /// <summary>
    /// Implementation of Model for vans
    /// </summary>
    public class VanModel : Model, IVanModel
    {
        #region Fields

        /// <summary>
        /// The van provider
        /// </summary>
        private static IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the review for this model
        /// </summary>
        public IVanReview Review
        {
            get
            {
                if (!HasReview)
                {
                    return null;
                }
                else
                {
                    IVanReviewProvider vanReviewProvider = ObjectFactory.GetInstance<IVanReviewProvider>();

                    return vanReviewProvider.GetReviewFromId(Id);
                }
            }
        }

        /// <summary>
        /// All gallery images
        /// </summary>
        public override ReviewImageCollection Images
        {
            get
            {
                return vanProvider.GetImagesByModelId(Id);
            }
        }
        
        /// <summary>
        /// Gets the VanManufacturer to which the model belongs
        /// </summary>
        public new IVanManufacturer Manufacturer
        {
            get
            {
                return Range.Manufacturer;
            }
        }

        /// <summary>
        /// Gets the VanRange to which the model belongs
        /// </summary>
        public new IVanRange Range
        {
            get
            {
                return (VanRange)GetRange();
            }
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public override string DisplayName
        {
            get
            {
                return this.NameWithYears;
            }
        }

        /// <summary>
        /// Gets or sets the classification
        /// </summary>
        public IVanClassification Classification
        {
            get;
            set;
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Filter derivatives for some predicate
        /// </summary>
        /// <param name="filter">The derivative filter</param>
        /// <returns>The derivaties</returns>
        public new List<IVanDerivative> FindDerivatives(Predicate<IDerivative> filter)
        {
            return (List<IVanDerivative>)base.FindDerivatives(filter);
        }

        /// <summary>
        /// Get a VanModel from a VANModId
        /// </summary>
        /// <param name="id">The model id</param>
        /// <returns>The model</returns>
        internal static IVanModel FromId(int id)
        {
            return vanProvider.GetModelFromId(id);
        }

        /// <summary>
        /// Backs the base.Range property
        /// </summary>
        /// <returns>The range</returns>
        protected override IRange GetRange()
        {
            return vanProvider.GetRangeFromId(RangeId);
        }

        /// <summary>
        /// Backs the base.Derivatives property
        /// </summary>
        /// <returns>All the derivatives</returns>
        protected override List<IDerivative> GetAllDerivatives()
        {
            return (ListOfDerivative)vanProvider.GetDerivativesFromId(Id);
        }

        #endregion
    }
}
