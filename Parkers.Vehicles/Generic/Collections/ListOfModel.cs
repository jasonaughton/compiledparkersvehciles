using System.Collections;
using System.Collections.Generic;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Wrapper for List&lt;Model&gt; to get round the fact that you can't convert List&lt;CarModel&gt; to List&lt;Model&gt;.
    /// </summary>
    public class ListOfModel : IEnumerable
    {
        private List<IModel> _list;

        public ListOfModel(List<IModel> list)
        {
            _list = list;
        }

        public static implicit operator ListOfModel(List<IModel> input)
        {
            if (input == null)
            {
                return null;
            }
            return new ListOfModel(input);
        }

        public static implicit operator List<IModel>(ListOfModel input)
        {
            if (input == null)
            {
                return null;
            }
            return input._list;
        }

        public static implicit operator ListOfModel(List<ICarModel> input)
        {
            if (input == null)
            {
                return null;
            }
            return (ListOfModel)input.ConvertAll<IModel>(delegate(ICarModel d)
            {
                return (IModel)d;
            });
        }

        public static implicit operator ListOfModel(List<IVanModel> input)
        {
            if (input == null)
            {
                return null;
            }
            return (ListOfModel)input.ConvertAll<IModel>(delegate(IVanModel d)
            {
                return (IModel)d;
            });
        }


        public static explicit operator List<ICarModel>(ListOfModel input)
        {
            if (input == null)
            {
                return null;
            }
            return input._list.ConvertAll<ICarModel>(d => (ICarModel)d);
        }

        public static explicit operator List<IVanModel>(ListOfModel input)
        {
            if (input == null)
            {
                return null;
            }
            return input._list.ConvertAll<IVanModel>(d => (IVanModel)d);
        }


        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion
    }
}
