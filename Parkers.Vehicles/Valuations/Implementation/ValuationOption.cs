
namespace Parkers.Vehicles
{
    internal class ValuationOption : IValuationOption
    {
        public int OptionCode
        {
            get
            {
                return _optionCode;
            }
            set
            {
                _optionCode = value;
            }
        }
        private int _optionCode;

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

        public string Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
            }
        }
        private string _item;

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

        public decimal Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        private decimal _value;
    }
}
