using StructureMap;
namespace Parkers.Vehicles
{
    /// <summary>
    /// Implements Range for vans
    /// </summary>
    internal class VanRange : Range, IVanRange
    {
        /// <summary>
        /// The VanManufacturer to which this range belongs
        /// </summary>
        public new IVanManufacturer Manufacturer
        {
            get
            {
                return (IVanManufacturer)GetManufacturer();
            }
        }

        /// <summary>
        /// Backs the base.Manufacturer property
        /// </summary>
        /// <returns></returns>
        protected override IManufacturer GetManufacturer()
        {
            IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

            return vanProvider.GetManufacturerFromId(_manufacturerId);
        }

        #region Static

        /// <summary>
        /// Get a VanRange from a VANRanId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static IVanRange FromId(int id)
        {
            IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

            return vanProvider.GetRangeFromId(id);
        }

        #endregion
    }

}
