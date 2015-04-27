
namespace Parkers.Vehicles
{
    public struct EquipmentItem : IEquipmentItem
    {
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

        public bool OnAll
        {
            get
            {
                return _onAll;
            }
            set
            {
                _onAll = value;
            }
        }
        private bool _onAll;
    }
}
