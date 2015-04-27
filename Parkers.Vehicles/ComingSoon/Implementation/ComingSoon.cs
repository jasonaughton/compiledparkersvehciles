using System.Collections.Generic;
using System;

namespace Parkers.Vehicles
{
    /// <summary>
    /// Cars that are coming soon
    /// </summary>
    internal class ComingSoon : IComingSoon
    {
        public int PageId
        {
            get
            {
                return _pageId;
            }
            set
            {
                _pageId = value;
            }
        }
        private int _pageId;

        public string Heading
        {
            get
            {
                return _heading;
            }
            set
            {
                _heading = value;
            }
        }
        private string _heading;

        public string Strapline
        {
            get
            {
                return _strapline;
            }
            set
            {
                _strapline = value;
            }
        }
        private string _strapline;

        public string Prices
        {
            get
            {
                return _prices;
            }
            set
            {
                _prices = value;
            }
        }
        private string _prices;

        public string OnSale
        {
            get
            {
                return _onSale;
            }
            set
            {
                _onSale = value;
            }
        }
        private string _onSale;

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

        public string SecondaryText
        {
            get
            {
                return _secondaryText;
            }
            set
            {
                _secondaryText = value;
            }
        }
        private string _secondaryText;

        public string SecondaryHeading
        {
            get
            {
                return _secondaryHeading;
            }
            set
            {
                _secondaryHeading = value;
            }
        }
        private string _secondaryHeading;

        public int SecondaryModelId
        {
            get
            {
                return _secondaryModelId;
            }
            set
            {
                _secondaryModelId = value;
            }
        }
        private int _secondaryModelId;

        public ICarModel SecondaryModel
        {
            get
            {
                return CarModel.FromId(_secondaryModelId);
            }
        }

        public string SecondaryImage
        {
            get
            {
                return _secondaryImage;
            }
            set
            {
                _secondaryImage = value;
            }
        }
        private string _secondaryImage;

        public bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
            }
        }
        private bool _visible;

        public bool SubHome
        {
            get
            {
                return _subHome;
            }
            set
            {
                _subHome = value;
            }
        }
        private bool _subHome;

        public List<IComingSoonImage> Images
        {
            get
            {
                return _images;
            }
            set
            {
                _images = value;
            }
        }
        private List<IComingSoonImage> _images = new List<IComingSoonImage>();

        public string FirstImage
        {
            get
            {
                return _images[0].File;
            }
        }

        public string FirstImageUrl(int width, int height)
        {
            throw new NotImplementedException();
        }

        public string CarSearchTerm
        {
            get
            {
                return _carSearchTerm;
            }
            set
            {
                _carSearchTerm = value;
            }
        }
        private string _carSearchTerm;

    }
}







