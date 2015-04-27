using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Implements Manufacturer for cars
    /// </summary>
    internal class CarManufacturer : Manufacturer, ICarManufacturer
    {
        /// <summary>
        /// Filter models for some predicate
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public new List<ICarModel> FindModels(Predicate<IModel> filter)
        {
            return (List<ICarModel>)base.FindModels(filter);
        }

        /// <summary>
        /// All models for this manufacturer
        /// </summary>
        public new List<ICarModel> Models
        {
            get
            {
                ICarProvider carProvider = new CarProvider();

                return carProvider.GetModelsByManufacturerId(_id);
            }
        }

        /// <summary>
        /// Backs the base.Models property
        /// </summary>
        /// <returns></returns>
        protected override List<IModel> GetAllModels()
        {
            ICarProvider carProvider = new CarProvider();

            return (ListOfModel)carProvider.GetModelsByManufacturerId(_id);
        }

        /// <summary>
        /// All ranges for this manufacturer
        /// </summary>
        public List<ICarRange> Ranges
        {
            get
            {
                ICarProvider carProvider = new CarProvider();

                return carProvider.GetRangesByManufacturerId(_id);
            }
        }

        /// <summary>
        /// Gets the generic body styles.
        /// </summary>
        public IEnumerable<string> GenericBodyStyles
        {
            get
            {
                return this.Models.Select(model => model.GenericBodyStyle).Distinct();
            }
        }

        /// <summary>
        /// Backs the base.Ranges property
        /// </summary>
        /// <returns></returns>
        protected override List<IRange> GetAllRanges()
        {
            ICarProvider carProvider = new CarProvider();

            return (ListOfRange)carProvider.GetRangesByManufacturerId(_id);
        }

        #region Static

        /// <summary>
        /// Get a CarManufacturer from a CARManId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static ICarManufacturer FromId(int id)
        {
            ICarProvider carProvider = new CarProvider();

            return carProvider.GetManufacturerFromId(id);
        }

        /// <summary>
        /// A list of all manufacturers
        /// </summary>
        internal static List<ICarManufacturer> All
        {
            get
            {
                ICarProvider carProvider = new CarProvider();

                return carProvider.GetManufacturers();
            }
        }

        #endregion
    }
}
