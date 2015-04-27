using System.Collections.Generic;

namespace Parkers.Vehicles
{
    internal class ValuationWithOptions : Valuation, IValuationWithOptions
    {
        public List<IValuationOption> Options
        {
            get
            {
                return _options;
            }
            set
            {
                _options = value;
            }
        }
        private List<IValuationOption> _options = new List<IValuationOption>();

        public override int OriginalPrice
        {
            get
            {
                return base.OriginalPrice + GetOptionCost();
            }
            set
            {
                base.OriginalPrice = value;
            }
        }

        public override int FranchiseDealer
        {
            get
            {
                return base.FranchiseDealer + GetOptionValue();
            }
            set
            {
                base.FranchiseDealer = value;
            }
        }

        public override int IndependentDealer
        {
            get
            {
                return base.IndependentDealer + GetOptionValue();
            }
            set
            {
                base.IndependentDealer = value;
            }
        }

        public override int PrivateGood
        {
            get
            {
                return base.PrivateGood + GetOptionValue();
            }
            set
            {
                base.PrivateGood = value;
            }
        }

        public override int PrivatePoor
        {
            get
            {
                // Private Poor value is not adjusted for otpions
                return base.PrivatePoor;
            }
            set
            {
                base.PrivatePoor = value;
            }
        }

        public override int PartExchange
        {
            get
            {
                return base.PartExchange + GetOptionValue();
            }
            set
            {
                base.PartExchange = value;
            }
        }

        private int GetOptionCost()
        {
            decimal totalCost = 0M;
            foreach (ValuationOption opt in _options)
            {
                totalCost += opt.Cost;
            }
            return (int)totalCost;
        }

        private int GetOptionValue()
        {
            decimal totalValue = 0M;
            foreach (IValuationOption opt in _options)
            {
                totalValue += opt.Value;
            }
            return (int)totalValue;
        }

    }
}
