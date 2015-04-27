
namespace Parkers.Vehicles
{
    internal class ComingSoonCaption : IComingSoonCaption
    {
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        private int _id;

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

        public int Top
        {
            get
            {
                return _top;
            }
            set
            {
                _top = value;
            }
        }
        private int _top;

        public int Left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
            }
        }
        private int _left;

        public int ImageId
        {
            get
            {
                return _imageId;
            }
            set
            {
                _imageId = value;
            }
        }
        private int _imageId;

        public int ImageTop
        {
            get
            {
                return _top;
            }
        }

        public int ImageLeft
        {
            get
            {
                return _left;
            }
        }

        public int CaptionLeft
        {
            get
            {
                int captionLeft = _left + 15;
                if (captionLeft < 175)
                {
                    captionLeft = captionLeft - 215;
                }
                return captionLeft;
            }
        }

        public int CaptionTop
        {
            get
            {
                return _top + 15;
            }
        }

        public string CaptionId
        {
            get
            {
                return "caption" + _id.ToString();
            }
        }

    }

}
