
namespace Parkers.Vehicles
{
    internal class Trim : ITrim
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

        public EquipmentList Equipment
        {
            get
            {
                return _equipment;
            }
            set
            {
                _equipment = value;
            }
        }
        private EquipmentList _equipment;

        public string BasedOn
        {
            get
            {
                return _basedOn;
            }
            set
            {
                _basedOn = value;
            }
        }
        private string _basedOn;
    }
}
