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
        public string _desc;
        public string _enterDesc;

        // Constructors maybe??
        public Room()
        {
            _canGoNorth = false;
            _canGoEast = false;
            _canGoSouth = false;
            _canGoWest = false;
            _desc = "You're in a room";
            _enterDesc = "This is a different room.";
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

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public string EnterDesc
        {
            get { return _enterDesc; }
            set { _enterDesc = value; }
        }

    }
}
