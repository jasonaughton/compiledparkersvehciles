
using System;

namespace Parkers.Vehicles
{
    internal class Valuation : IValuation
    {
        #region Properties

        public IDerivative Derivative
        {
            get
            {
                return _derivative;
            }
            set
            {
                _derivative = value;
            }
        }
        private IDerivative _derivative;

        public IYearPlate YearPlate
        {
            get
            {
                return _yearPlate;
            }
            set
            {
                _yearPlate = value;
            }
        }
        private IYearPlate _yearPlate;

        public int Mileage
        {
            get
            {
                return _mileage;
            }
            set
            {
                _mileage = value;
            }
        }
        private int _mileage;

        public int Year
        {
            get
            {
                return _yearPlate.Year;
            }
        }

        public virtual int OriginalPrice
        {
            get
            {
                return _originalPrice;
            }
            set
            {
                _originalPrice = value;
            }
        }
        private int _originalPrice;

        public virtual int FranchiseDealer
        {
            get
            {
                return _franchiseDealer;
            }
            set
            {
                _franchiseDealer = value;
            }
        }
        private int _franchiseDealer;

        public virtual int IndependentDealer
        {
            get
            {
                return _independentDealer;
            }
            set
            {
                _independentDealer = value;
            }
        }
        private int _independentDealer;

        public virtual int PrivateGood
        {
            get
            {
                return _privateGood;
            }
            set
            {
                _privateGood = value;
            }
        }
        private int _privateGood;

        public virtual int PrivatePoor
        {
            get
            {
                return _privatePoor;
            }
            set
            {
                _privatePoor = value;
            }
        }
        private int _privatePoor;

        public virtual int PartExchange
        {
            get
            {
                return _partExchange;
            }
            set
            {
                _partExchange = value;
            }
        }
        private int _partExchange;

        public ValuationResultType Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }
        private ValuationResultType _result;

        #endregion

        #region Methods

        internal Valuation()
        {
        }

        /// <summary>
        /// Abbreviate body styles etc to help to squeeze model and derivative names into SMS messages.
        /// </summary>
        /// <param name="input">A string</param>
        /// <returns>The input string with certain words abbreviated</returns>
        public string AbbreviateForSms(string input)
        {
            string result = input;

            result = result.Replace("é", "e");
            result = result.Replace("ë", "e");
            result = result.Replace("Hatchback", "Hatch");
            result = result.Replace("Estate", "Est");
            result = result.Replace("Saloon", "Sal");
            result = result.Replace("Executive", "Exec");
            result = result.Replace("Station Wagon", "SW");
            result = result.Replace("Inch", "in");
            result = result.Replace("Limited Edition", "LE");
            result = result.Replace("Sport Tourer", "Est");
            result = result.Replace("(Euro 3)", "");
            result = result.Replace("(Euro 4)", "");

            return result;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Rounded to £5, then "#,##0"
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        [Obsolete]
        internal static string FormatPrice(int price)
        {
            int roundedPrice = 5 * (int)(price / 5.0);
            return FormatPriceUnrounded(roundedPrice);
        }

        /// <summary>
        /// "#,##0"
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        private static string FormatPriceUnrounded(int price)
        {
            return price.ToString("#,##0");
        }

        #endregion
    }
}