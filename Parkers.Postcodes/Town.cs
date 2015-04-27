using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;

using Parkers.Data;

namespace Parkers.Postcodes
{
    public class Town : IPlace
    {
        private static readonly string _database = "ParkersMeta";

        private string _name;
        private GridRef _gridRef;

        public County County
        {
            get
            {
                return _county;
            }
            set
            {
                _county = value;
            }
        }
        private County _county;

        #region IPlace Members

        public GridRef GetGridRef()
        {
            return _gridRef;
        }

        public string GetDisplayName()
        {
            return _name;
        }

        #endregion

        #region Static methods
        [Obsolete]
        public static IPlace GetPlaceFromString(string input)
        {
            IList<IPlace> places = GetPlacesFromString(input);
            if (places.Count == 0)
            {
                return null;
            }

            return places[0];
        }

        [Obsolete]
        public static List<IPlace> GetPlacesFromString(string input)
        {
            List<IPlace> result = new List<IPlace>();

            if (String.IsNullOrEmpty(input))
            {
                return result;
            }

            Postcode pc = new Postcode(input);
            if (pc.Outcode != null)
            {
                result.Add(pc);
                return result;
            }

            Sproc sp = new Sproc("Geonames_S_FindLocation", _database);
            sp.Parameters.Add("@Search", SqlDbType.VarChar).Value = input.Replace(',', ' ');

            using (SqlDataReader dr = sp.ExecuteReader())
            {
                bool hasWholeWordMatch = false;
                bool hasSimpleNameMatch = false;
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        hasWholeWordMatch = hasWholeWordMatch || DataUtil.GetBoolean(dr, "WholeWord");
                        hasSimpleNameMatch = hasSimpleNameMatch || DataUtil.GetBoolean(dr, "ExcludingCounty");

                        if (hasWholeWordMatch == false || DataUtil.GetBoolean(dr, "WholeWord"))
                        {
                            if (hasSimpleNameMatch == false || DataUtil.GetBoolean(dr, "ExcludingCounty"))
                            {
                                result.Add(FromDataRecord(dr));
                            }
                        }
                    }
                }
            }

            return result;
        }

        [Obsolete]
        public static Town FromString(string input)
        {
            List<IPlace> places = GetPlacesFromString(input);
            return (places.Find(p => p is Town) as Town);
        }

        [Obsolete]
        public static Town FromGridRef(GridRef input)
        {
            if (input == null)
            {
                return null;
            }

            Sproc sp = new Sproc("Geonames_S_FindName", _database);
            sp.Parameters.Add("@Latitude", SqlDbType.Float).Value = input.Latitude;
            sp.Parameters.Add("@Longitude", SqlDbType.Float).Value = input.Longitude;

            return sp.ExecuteObject<IPlace>(FromDataRecord) as Town;
        }

        [Obsolete]
        public static Town FromIpAddress(string ip)
        {
            GridRef maxmindLocation = MaxmindUtil.GetLocation(ip);

            if (maxmindLocation == null)
            {
                return null;
            }
            else
            {
                return Town.FromGridRef(maxmindLocation);
            }
        }

        [Obsolete]
        public static Town FromIpAddress(IPAddress ip)
        {
            if (ip == null)
            {
                return null;
            }
            return FromIpAddress(ip.ToString());
        }

        #endregion

        private static IPlace FromDataRecord(IDataRecord dr)
        {
            IPlace result = null;
            if (DataUtil.GetBoolean(dr, "IsCounty"))
            {
                County c = new County(DataUtil.GetString(dr, "UniqueName"));
                result = c;
            }
            else
            {
                Town t = new Town();
                t._name = DataUtil.GetString(dr, "UniqueName");
                t._county = new County(DataUtil.GetString(dr, "County"));
                t._gridRef = new GridRef(DataUtil.GetDouble(dr, "Latitude"), DataUtil.GetDouble(dr, "Longitude"));
                result = t;
            }
            return result;
        }
    }
}
