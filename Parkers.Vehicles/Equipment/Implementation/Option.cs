
namespace Parkers.Vehicles
{
    internal class Option : IOption
    {
        public int CategoryId
        {
            get
            {
                return _categoryId;
            }
            set
            {
                _categoryId = value;
            }
        }
        private int _categoryId;

        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }
        private string _category;

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }
        private string _text;

        public decimal Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }
        private decimal _cost;

        public string CostDescription
        {
            get
            {
                if (_type == "S")
                {
                    return "Standard";
                }
                if (_cost == 0)
                {
                    return "Optional";

                }
                else
                {
                    return _cost.ToString("£#,##0");
                }
            }
        }

        public string DateFrom
        {
            get
            {
                return _dateFrom;
            }
            set
            {
                _dateFrom = value;
            }
        }
        private string _dateFrom;

        public string DateTo
        {
            get
            {
                return _dateTo;
            }
            set
            {
                _dateTo = value;
            }
        }
        private string _dateTo;

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        private string _type;

    }
}
