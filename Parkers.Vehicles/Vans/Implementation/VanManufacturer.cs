using System;
using System.Collections.Generic;
using StructureMap;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Implements Manufacturer for vans
    /// </summary>
    internal class VanManufacturer : Manufacturer, IVanManufacturer
    {
        /// <summary>
        /// Backs the base.Models property
        /// </summary>
        /// <returns></returns>
        protected override List<IModel> GetAllModels()
        {
            IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

            return (ListOfModel)vanProvider.GetModelsByManufacturerId(_id);
        }


        #region Static

        /// <summary>
        /// Get a VanManufacturer from a VANManId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static IVanManufacturer FromId(int id)
        {
            IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

            return vanProvider.GetManufacturerFromId(id);
        }

        /// <summary>
        /// A list of all manufacturers
        /// </summary>
        internal static List<IVanManufacturer> All
        {
            get
            {
                IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

                return vanProvider.GetManufacturers();
            }
        }

        /// <summary>
        /// A list of all manufacturers that match a given predicate
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        internal static List<IVanManufacturer> FindAll(Predicate<IManufacturer> filter)
        {
            List<IManufacturer> allManufacturers = (ListOfManufacturer)All;
            return (List<IVanManufacturer>)(ListOfManufacturer)allManufacturers.FindAll(filter);
        }

        /// <summary>
        /// A list of all manufacturers that match a given predicate
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        internal static List<IVanManufacturer> FindAll(Predicate<IVanManufacturer> filter)
        {
            return All.FindAll(filter);
        }

        #endregion
    }

}
