using System.Collections.Generic;
using System.Data.SqlClient;

using Parkers.Data;

namespace Parkers.Vehicles
{
    internal class CarFamily : ICarFamily
    {
        public static Dictionary<int, CarFamily> Families
        {
            get
            {
                if (_list == null)
                {
                    Populate();
                }
                return _list;
            }
        }
        private static Dictionary<int, CarFamily> _list;

        private CarFamily()
        {
        }

        private CarFamily(SqlDataReader dr)
        {
            _id = (int)dr["CARFamId"];
            _name = (string)dr["Family"];
        }

        internal static CarFamily FromId(int id)
        {
            if (_list == null)
            {
                Populate();
            }
            if (_list.ContainsKey(id))
            {
                return _list[id];
            }
            return null;
        }

        private static void Populate()
        {
            Sproc sp = new Sproc("Fam_S", "ParkersCAR");
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    _list = new Dictionary<int, CarFamily>();

                    CarFamily none = new CarFamily();
                    none._name = "";
                    none._id = 0;
                    _list.Add(0, none);

                    while (dr.Read())
                    {
                        CarFamily newFamily = new CarFamily(dr);
                        _list[newFamily.Id] = newFamily;
                    }
                }
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }
        private int _id;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        private string _name;

    }

}
