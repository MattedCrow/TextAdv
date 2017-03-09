using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class Room
    {
        public string Desc { get; set; }

        public bool CanGoNorth { get; set; }
        public bool CanGoEast { get; set; }
        public bool CanGoSouth { get; set; }
        public bool CanGoWest { get; set; }

    }
}
