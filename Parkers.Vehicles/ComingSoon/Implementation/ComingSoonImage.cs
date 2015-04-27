using System.Collections.Generic;

namespace Parkers.Vehicles
{
    internal class ComingSoonImage : IComingSoonImage
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

        public string File
        {
            get
            {
                return _file;
            }
            set
            {
                _file = value;
            }
        }
        private string _file;

        public List<IComingSoonCaption> Captions
        {
            get
            {
                return _captions;
            }
            set
            {
                _captions = value;
            }
        }
        private List<IComingSoonCaption> _captions = new List<IComingSoonCaption>();

    }
}
