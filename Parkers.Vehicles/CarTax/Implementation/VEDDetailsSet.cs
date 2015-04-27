using System.Collections.Generic;

namespace Parkers.Vehicles
{
    internal class VEDDetailsSet : Parkers.Vehicles.IVEDDetailsSet
    {
        public List<IVEDDetails> Values
        {
            get
            {
                return _values;
            }
        }
        private List<IVEDDetails> _values = new List<IVEDDetails>();

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

        public void CombineResults()
        {
            for (int i = 0; i < _values.Count - 1; i++)
            {
                if (_values[i].Band == _values[i + 1].Band)
                {
                    _values[i + 1].Combine(_values[i]);
                    _values.RemoveAt(i);
                    i--;
                }
            }
        }
    }

}
