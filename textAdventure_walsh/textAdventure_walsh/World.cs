using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class World
    {
        public Room[,] coords;

        public int MaxRow { get; set; }
        public int MaxCol { get; set; }

        public int currentRow { get; set; }
        public int currentCol { get; set; }

        public World()
        {
            MaxRow = 4;
            MaxCol = 4;

            coords = new Room[MaxRow, MaxCol];

            currentCol = 0;
            currentRow = 0;

            // ROW ONE
            coords[0,0].Desc = "You can see where you came in!";
            coords[0, 0].CanGoEast = true;
            coords[0, 0].CanGoNorth = false;
            coords[0, 0].CanGoWest = false;
            coords[0, 0].CanGoSouth = true;

            coords[0, 1].Desc = "Is this room empty?";
            coords[0, 1].CanGoNorth = false;
            coords[0, 1].CanGoEast = false;
            coords[0, 1].CanGoSouth = true;
            coords[0, 1].CanGoWest = true;

            coords[0, 2].Desc = "This room is huge!";
            coords[0, 2].CanGoNorth = false;
            coords[0, 2].CanGoEast = true;
            coords[0, 2].CanGoSouth = true;
            coords[0, 2].CanGoWest = false;

            coords[0, 3].Desc = "There's an enemy! But you can sneak by right now.";
            coords[0, 3].CanGoNorth = false;
            coords[0, 3].CanGoEast = false;
            coords[0, 3].CanGoSouth = true;
            coords[0, 3].CanGoWest = true;

            // ROW TWO
            coords[1, 0].Desc = "This is a big room!";
            coords[1, 0].CanGoEast = false;
            coords[1, 0].CanGoNorth = true;
            coords[1, 0].CanGoWest = false;
            coords[1, 0].CanGoSouth = true;

            coords[1, 1].Desc = "There's a chest in here!";
            coords[1, 1].CanGoNorth = true;
            coords[1, 1].CanGoEast = false;
            coords[1, 1].CanGoSouth = false;
            coords[1, 1].CanGoWest = false;

            coords[1, 2].Desc = "You can see the exit!";
            coords[1, 2].CanGoNorth = true;
            coords[1, 2].CanGoEast = false;
            coords[1, 2].CanGoSouth = false;
            coords[1, 2].CanGoWest = false;

            coords[1, 3].Desc = "This room is big!";
            coords[1, 3].CanGoNorth = true;
            coords[1, 3].CanGoEast = false;
            coords[1, 3].CanGoSouth = true;
            coords[1, 3].CanGoWest = false;

            // ROW THREE
            coords[2, 0].Desc = "This is a big room!";
            coords[2, 0].CanGoEast = true;
            coords[2, 0].CanGoNorth = true;
            coords[2, 0].CanGoWest = false;
            coords[2, 0].CanGoSouth = true;

            coords[2, 1].Desc = "Is that a person?";
            coords[2, 1].CanGoNorth = false;
            coords[2, 1].CanGoEast = false;
            coords[2, 1].CanGoSouth = false;
            coords[2, 1].CanGoWest = true;

            coords[2, 2].Desc = "You can see the exit!";
            coords[2, 2].CanGoNorth = true;
            coords[2, 2].CanGoEast = false;
            coords[2, 2].CanGoSouth = false;
            coords[2, 2].CanGoWest = false;

            coords[2, 3].Desc = "This room is big!";
            coords[2, 3].CanGoNorth = true;
            coords[2, 3].CanGoEast = false;
            coords[2, 3].CanGoSouth = true;
            coords[2, 3].CanGoWest = false;
        }
    }
}
