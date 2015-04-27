using System.Collections;
using System.Collections.Generic;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Wrapper for List&lt;Manufacturer&gt; to get round the fact that you can't convert List&lt;CarManufacturer&gt; to List&lt;Manufacturer&gt;.
    /// </summary>
    public class ListOfManufacturer : IEnumerable
    {
        private List<IManufacturer> _list;

        public ListOfManufacturer(List<IManufacturer> list)
        {
            _list = list;
        }

        public static implicit operator ListOfManufacturer(List<IManufacturer> input)
        {
            if (input == null)
            {
                return null;
            }
            return new ListOfManufacturer(input);
        }

        public static implicit operator List<IManufacturer>(ListOfManufacturer input)
        {
            if (input == null)
            {
                return null;
            }
            return input._list;
        }

        public static implicit operator ListOfManufacturer(List<ICarManufacturer> input)
        {
            if (input == null)
            {
                return null;
            }
            return (ListOfManufacturer)input.ConvertAll<IManufacturer>(delegate(ICarManufacturer d)
            {
                return (IManufacturer)d;
            });
        }

        public static implicit operator ListOfManufacturer(List<IVanManufacturer> input)
        {
            if (input == null)
            {
                return null;
            }
            return (ListOfManufacturer)input.ConvertAll<IManufacturer>(delegate(IVanManufacturer d)
            {
                return (IManufacturer)d;
            });
        }

        public static explicit operator List<ICarManufacturer>(ListOfManufacturer input)
        {
            if (input == null)
            {
                return null;
            }
            return input._list.ConvertAll<ICarManufacturer>(d => (ICarManufacturer)d);
        }

        public static explicit operator List<IVanManufacturer>(ListOfManufacturer input)
        {
            if (input == null)
            {
                return null;
            }
            return input._list.ConvertAll<IVanManufacturer>(d => (IVanManufacturer)d);
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion
    }
}
