using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class Room
    {
        public bool _canGoNorth;
        public bool _canGoEast;
        public bool _canGoSouth;
        public bool _canGoWest;

        // Constructors maybe??
        public Room()
        {
            _canGoNorth = false;
            _canGoEast = false;
            _canGoSouth = false;
            _canGoWest = false;
        }

        public bool CanGoNorth
        {
            get { return _canGoNorth; }
            set { _canGoNorth = value; }
        }
        public bool CanGoEast
        {
            get { return _canGoEast; }
            set { _canGoEast = value; }
        }
        public bool CanGoSouth
        {
            get { return _canGoSouth; }
            set { _canGoSouth = value; }
        }
        public bool CanGoWest
        {
            get { return _canGoWest; }
            set { _canGoWest = value; }
        }

    }
}
