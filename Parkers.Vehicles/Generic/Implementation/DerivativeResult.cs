using System;
using System.Data;

using Parkers.Vehicles;
using StructureMap;

namespace Parkers.Search
{
    /// <summary>
    /// Represents a single derivative/plate result
    /// </summary>
    internal class DerivativeResult : IDerivativeResult
    {
        protected int _derivativeId;
        protected int _yearPlateId;

        public ICarDerivative Derivative
        {
            get;
            set;
        }

        public IYearPlate YearPlate
        {
            get;
            set;
        }

        public int Price
        {
            get;
            set;
        }

        public string PlateText
        {
            get
            {
                if (this.YearPlate != null)
                {
                    return YearPlate.ToString();
                }
                else
                {
                    return "New";
                }
            }
        }


        public DerivativeResult()
        {
        }

        /// <summary>
        /// Create a SearchResult from an IDataRecord (probably a SqlDataReader)
        /// </summary>
        /// <param name="record">an IDataRecord</param>
        public DerivativeResult(IDataRecord record)
        {
            this.Populate(record);
        }

        private void Populate(IDataRecord record)
        {
            try
            {
                _derivativeId = (int)record["CARDerId"];
                this.Derivative = CarDerivative.FromId(_derivativeId);
                _yearPlateId = (int)record["YearPlateId"];
                if (_yearPlateId == 999)
                {
                    this.YearPlate = null;
                }
                else
                {
                    IYearPlateProvider yearPlateProvider = ObjectFactory.GetInstance<IYearPlateProvider>();

                    this.YearPlate = yearPlateProvider.FromId(_yearPlateId);
                }
                this.Price = (int)record["Price"];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentException("A required column was not found", "record", e);
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentException("A column value was invalid", "record", e);
            }

        }

    }
}