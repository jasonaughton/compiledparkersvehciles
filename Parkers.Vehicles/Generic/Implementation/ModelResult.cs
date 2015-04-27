using System;
using System.Collections;
using System.Data;
using Parkers.Data;
using Parkers.Vehicles;

namespace Parkers.Search
{
    /// <summary>
    /// Represents a model-level result
    /// </summary>
    internal class ModelResult
    {
        protected int _modelId;

        public ICarModel Model
        {
            get
            {
                return CarModel.FromId(_modelId);
            }
        }

        public decimal Rating
        {
            get;
            private set;
        }

        public DerivativeResult[] DerivativeResults
        {
            get
            {
                return (DerivativeResult[])derivativeResultsList.ToArray(typeof(DerivativeResult));
            }
        }
        private ArrayList derivativeResultsList = new ArrayList();

        public void AddDerivativeResult(DerivativeResult newResult)
        {
            derivativeResultsList.Add(newResult);
        }

        public ModelResult()
        {
        }

        /// <summary>
        /// Create a ModelResult from an IDataRecord (probably a SqlDataReader)
        /// </summary>
        /// <param name="record">an IDataRecord</param>
        public ModelResult(IDataRecord record)
        {
            this.Populate(record);
        }

        private void Populate(IDataRecord record)
        {
            try
            {
                _modelId = (int)record["CARModId"];
                this.Rating = DataUtil.GetDecimal(record, "Rating");
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