using System;
using System.Net;

using System.Xml;
using log4net;

namespace Parkers.Vehicles
{
    public class FuelPriceProvider : IFuelPriceProvider
    {
        /// <summary>
        /// Holds the logger reference
        /// </summary>
        //private static readonly ILog log = LogManager.GetLogger(typeof(FuelPriceProvider));

        private static readonly object _lockObject = new object();

        /// <summary>
        /// Are we using current average values from petrolprices.com, or fallback hardcoded values?
        /// </summary>
        public bool HasRealValues
        {
            get
            {
                return _hasRealValues;
            }
            set
            {
                _hasRealValues = value;
            }
        }
        private bool _hasRealValues = false;

        public double PetrolPrice
        {
            get
            {
                if (!_petrolPrice.HasValue)
                {
                    lock (_lockObject)
                    {
                        if (!_petrolPrice.HasValue)
                        {
                            Populate();
                        }
                    }
                }
                return _petrolPrice.Value;
            }
        }
        private double? _petrolPrice;

        public double DieselPrice
        {
            get
            {
                if (!_dieselPrice.HasValue)
                {
                    lock (_lockObject)
                    {
                        if (!_petrolPrice.HasValue)
                        {
                            Populate();
                        }
                    }
                }
                return _dieselPrice.Value;
            }
        }
        private double? _dieselPrice;

        private void Populate()
        {
            try
            {
                WebClient wc = new WebClient();

                //  hardcoded URL
                string response = wc.DownloadString("http://www.petrolprices.com/feeds/averages.xml");

                XmlDocument averages = new XmlDocument();

                averages.LoadXml(response);

                //  hardcoded XPath - better in config?
                XmlNode dieselNode = averages.SelectSingleNode("/PetrolPrices/Fuel[@type='Diesel']/Average/text()");

                _hasRealValues = true;

                double dieselPrice;

                if (Double.TryParse(dieselNode.Value, out dieselPrice))
                {
                    _dieselPrice = dieselPrice;
                }
                else
                {
                    HandleFailedPopulate(null);
                    return;
                }

                double petrolPrice;

                //  hardcoded XPath - better in config?
                XmlNode unleadedNode = averages.SelectSingleNode("/PetrolPrices/Fuel[@type='Unleaded']/Average/text()");

                if (Double.TryParse(unleadedNode.Value, out petrolPrice))
                {
                    _petrolPrice = petrolPrice;
                }
                else
                {
                    HandleFailedPopulate(null);
                    return;
                }
            }
            catch (WebException wex)
            {
                HandleFailedPopulate(wex);
            }
        }

        private void HandleFailedPopulate(Exception innerException)
        {
            //  Hard coded fall back values
            _petrolPrice = 135d;
            _dieselPrice = 140d;
            _hasRealValues = false;

            //log.Error("Failed to get prices from petrolprices.com", innerException);
        }
    }
}
