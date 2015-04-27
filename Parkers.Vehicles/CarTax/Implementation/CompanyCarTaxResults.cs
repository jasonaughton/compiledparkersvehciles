
namespace Parkers.Vehicles
{
    internal class CompanyCarTaxResults : ICompanyCarTaxResults
    {
        public decimal CarTaxCAV
        {
            get
            {
                return benefit;
            }
            set
            {
                benefit = value;
            }
        }
        private decimal benefit;

        public string FuelType
        {
            get
            {
                return fuelType;
            }
            set
            {
                fuelType = value;
            }
        }
        private string fuelType;

        public float Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
            }
        }
        private float rate;

        public int CC
        {
            get
            {
                return cc;
            }
            set
            {
                cc = value;
            }
        }
        private int cc;

        public int GramsPerKm
        {
            get
            {
                return gramsPerKm;
            }
            set
            {
                gramsPerKm = value;
            }
        }
        private int gramsPerKm;

        public int EuroEmissions
        {
            get
            {
                return euroEmissions;
            }
            set
            {
                euroEmissions = value;
            }
        }
        private int euroEmissions;

        public int List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
            }
        }
        private int list;

        public int TaxYear
        {
            get
            {
                return taxyear;
            }
            set
            {
                taxyear = value;
            }
        }
        private int taxyear;

        public string TaxYearText
        {
            get
            {
                return TaxYear.ToString() + "/" + ((TaxYear + 1) % 100).ToString("00");
            }
        }

        public int TaxBenefitPercent
        {
            get
            {
                return taxBenefitPercent;
            }
            set
            {
                taxBenefitPercent = value;
            }
        }
        private int taxBenefitPercent;

        public decimal CarMonthlyTax
        {
            get
            {
                return carmonthlyTax;
            }
            set
            {
                carmonthlyTax = value;
            }
        }
        private decimal carmonthlyTax;

        public int FuelCAV
        {
            get
            {
                return fuelCAV;
            }
            set
            {
                fuelCAV = value;
            }
        }
        private int fuelCAV;

        public int FuelAnnualTax
        {
            get
            {
                return fuelAnnualTax;
            }
            set
            {
                fuelAnnualTax = value;
            }
        }
        private int fuelAnnualTax;

        public decimal CarAnnualTax
        {
            get
            {
                return carAnnualTax;
            }
            set
            {
                carAnnualTax = value;
            }
        }
        private decimal carAnnualTax;

        public int FuelMonthlyTax
        {
            get
            {
                return fuelMonthlyTax;
            }
            set
            {
                fuelMonthlyTax = value;
            }
        }
        private int fuelMonthlyTax;
    }

}
