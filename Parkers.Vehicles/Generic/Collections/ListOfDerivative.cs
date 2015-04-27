using System.Collections;
using System.Collections.Generic;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Wrapper for List&lt;Derivative&gt; to get round the fact that you can't convert List&lt;CarDerivative&gt; to List&lt;Derivative&gt;.
    /// </summary>
    public class ListOfDerivative : IEnumerable
    {
        private List<IDerivative> _list;

        public ListOfDerivative(List<IDerivative> list)
        {
            _list = list;
        }

        public static implicit operator ListOfDerivative(List<IDerivative> input)
        {
            return new ListOfDerivative(input);
        }

        public static implicit operator List<IDerivative>(ListOfDerivative input)
        {
            if (input == null)
            {
                return null;
            }
            return input._list;
        }

        public static explicit operator List<ICarDerivative>(ListOfDerivative input)
        {
            if (input == null)
            {
                return null;
            }
            return input._list.ConvertAll<ICarDerivative>(d => (ICarDerivative)d);
        }

        public static explicit operator List<IVanDerivative>(ListOfDerivative input)
        {
            if (input == null)
            {
                return null;
            }
            return input._list.ConvertAll<IVanDerivative>(d => (IVanDerivative)d);
        }


        public static implicit operator ListOfDerivative(List<ICarDerivative> input)
        {
            if (input == null)
            {
                return null;
            }
            return (ListOfDerivative)input.ConvertAll<IDerivative>(delegate(ICarDerivative d)
            {
                return (IDerivative)d;
            });
        }

        public static implicit operator ListOfDerivative(List<IVanDerivative> input)
        {
            if (input == null)
            {
                return null;
            }
            return (ListOfDerivative)input.ConvertAll<IDerivative>(delegate(IVanDerivative d)
            {
                return (IDerivative)d;
            });
        }


        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion
    }
}
