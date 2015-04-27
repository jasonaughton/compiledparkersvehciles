using System;
using System.Collections.Generic;

namespace Parkers.Vehicles
{
    internal class VEDDetails : IVEDDetails
    {
        public decimal SixMonths
        {
            get
            {
                return sixMonths;
            }
            set
            {
                sixMonths = value;
            }
        }
        private decimal sixMonths;

        public decimal TwelveMonths
        {
            get
            {
                return twelveMonths;
            }
            set
            {
                twelveMonths = value;
            }
        }
        private decimal twelveMonths;

        public decimal FirstYear
        {
            get
            {
                return _firstYear;
            }
            set
            {
                _firstYear = value;
            }
        }
        private decimal _firstYear;

        public string Band
        {
            get
            {
                return band;
            }
            set
            {
                band = value;
            }
        }
        private string band;

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }
        private DateTime _startDate;

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
            }
        }
        private DateTime _endDate;

        public string EffectivePeriod
        {
            get
            {
                return _effectivePeriod;
            }
            set
            {
                _effectivePeriod = value;
            }
        }
        private string _effectivePeriod;

        public bool FirstYearApplies
        {
            get
            {
                return _firstYearApplies;
            }
            set
            {
                _firstYearApplies = value;
            }
        }
        private bool _firstYearApplies = false;

        public int CO2Min
        {
            get
            {
                return _co2Min;
            }
            set
            {
                _co2Min = value;
            }
        }
        private int _co2Min;

        public int CO2Max
        {
            get
            {
                return _co2Max;
            }
            set
            {
                _co2Max = value;
            }
        }
        private int _co2Max;

        public string CO2
        {
            get
            {
                if (_co2Min == 0 || _co2Max == 0)
                {
                    return "-";
                }
                if (_co2Min == _co2Max)
                {
                    return _co2Min.ToString();
                }
                return _co2Min.ToString() + "-" + _co2Max.ToString();
            }
        }

        public void Combine(IVEDDetails other)
        {
            if (other.StartDate < this.StartDate)
            {
                this.StartDate = other.StartDate;
            }
            if (other.EndDate > this.EndDate)
            {
                this.EndDate = other.EndDate;
            }
            if (other.CO2Min < this.CO2Min)
            {
                this.CO2Min = other.CO2Min;
            }
            if (other.CO2Max > this.CO2Max)
            {
                this.CO2Max = other.CO2Max;
            }

        }

        /// <summary>
        /// Gets a list of distinct VED bands in the passed list, separated by '/' and omitting any nulls.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        internal static string GetBand(List<IVEDDetails> list)
        {
            List<string> bands = new List<string>();
            string lastBand = null;

            foreach (IVEDDetails v in list)
            {
                if (v.Band != null && v.Band != "" && v.Band != "1" && v.Band != "0" && lastBand != v.Band)
                {
                    bands.Add(v.Band);
                    lastBand = v.Band;
                }
            }

            return String.Join("/", bands.ToArray());
        }
    }
}
