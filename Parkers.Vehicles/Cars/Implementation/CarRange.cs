
using StructureMap;
namespace Parkers.Vehicles
{
    /// <summary>
    /// Implements Range for cars
    /// </summary>
    internal class CarRange : Range, ICarRange
    {
        #region Properties

        /// <summary>
        /// A piece of text to use as an upsell for the CarCheck
        /// </summary>
        public string CarCheckSnippet
        {
            get
            {
                return _carCheckSnippet;
            }
            set
            {
                _carCheckSnippet = value;
            }
        }
        private string _carCheckSnippet;

        /// <summary>
        /// Product ID to purchase for access to this model's CarCheck
        /// </summary>
        public int CarCheckProductId
        {
            get
            {
                return _CarCheckProductId;
            }
            set
            {
                _CarCheckProductId = value;
            }
        }
        private int _CarCheckProductId;

        #endregion

        #region Hierarchy glue

        /// <summary>
        /// The CarManufacturer to which this range belongs
        /// </summary>
        public new ICarManufacturer Manufacturer
        {
            get
            {
                return (ICarManufacturer)GetManufacturer();
            }
        }

        /// <summary>
        /// Backs the base.Manufacturer property
        /// </summary>
        /// <returns></returns>
        protected override IManufacturer GetManufacturer()
        {
            return CarManufacturer.FromId(_manufacturerId);
        }

        #endregion

        #region Static

        /// <summary>
        /// Get a CarRange from a CARRanId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static ICarRange FromId(int id)
        {
            ICarProvider carProvider = ObjectFactory.GetInstance<ICarProvider>();

            return carProvider.GetRangeFromId(id);
        }

        #endregion
    }


}
