using System;
using System.Data.SqlClient;

namespace Parkers.Vehicles
{
    internal class YearPlate : IYearPlate
    {
        private YearPlate()
        {
        }

        internal YearPlate(SqlDataReader dr)
        {
            _id = (int)dr["YearPlateId"];
            _year = (int)dr["Year"];
            _plate = ((string)dr["Plate"]).TrimEnd();

            int startMonth = (int)dr["MonthStart"];
            int endMonth = (int)dr["MonthEnd"];

            _startDate = new DateTime(_year, startMonth, 1);
            _endDate = new DateTime(_year, endMonth, 1);
            _endDate = _endDate.AddMonths(1);
            _endDate = _endDate.AddTicks(-1); // _endDate is now the last tick of the final month
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        private int _id;

        public int Year
        {
            get
            {
                return _year;
            }
        }
        private int _year;

        public string Plate
        {
            get
            {
                return _plate;
            }
        }
        private string _plate;

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
        }
        private DateTime _startDate;

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
        }
        private DateTime _endDate;

        public string Example
        {
            get
            {
                return _year.ToString() + " / " + GetPlateTemplate();
            }
        }

        public override string ToString()
        {
            return _year.ToString() + "/" + _plate;
        }

        private string GetPlateTemplate()
        {
            if (Plate.Length == 1)
            {
                return "<b>" + Plate + "</b>&#x25af;&#x25af;&#x25af;&nbsp;&#x25af;&#x25af;&#x25af;";
            }
            else
            {
                return "&#x25af;&#x25af;<b>" + Plate + "</b>&nbsp;&#x25af;&#x25af;&#x25af;";
            }
        }


        public string DisplayName
        {
            get 
            {
                return this.ToString();
            }
        }
    }

}
