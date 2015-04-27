using System.Collections;
using System.Collections.Generic;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Wrapper for List&lt;Range&gt; to get round the fact that you can't convert List&lt;CarRange&gt; to List&lt;Range&gt;.
    /// </summary>
    public class ListOfRange : IEnumerable
    {
        private List<IRange> _list;

        public ListOfRange(List<IRange> list)
        {
            _list = list;
        }

        public static implicit operator ListOfRange(List<IRange> input)
        {
            return new ListOfRange(input);
        }

        public static implicit operator List<IRange>(ListOfRange input)
        {
            return input._list;
        }

        public static implicit operator ListOfRange(List<ICarRange> input)
        {
            return (ListOfRange)input.ConvertAll<IRange>(delegate(ICarRange d)
            {
                return (IRange)d;
            });
        }

        public static implicit operator ListOfRange(List<IVanRange> input)
        {
            return (ListOfRange)input.ConvertAll<IRange>(delegate(IVanRange d)
            {
                return (IRange)d;
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
