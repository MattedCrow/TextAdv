using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class Move
    {
        private string _currentLocation;  // row space col

        public string CurrentLocation
        {
            get { return _currentLocation; }
        }

        public void MoveCharacter (string direction, int row, int col)
        {
            if (direction == "north" && Room.CanGoNorth = true)
            {
                row -= 1;
                _currentLocation = row + " " + col;
            }
            else if (direction == "south" && row != 3)
            {
                row += 1;
                _currentLocation = row + " " + col;
            }
            else if (direction == "east" && col != 3)
            {
                col += 1;
                _currentLocation = row + " " + col;
            }
            else if (direction == "west" && col != 0)
            {
                col -= 1;
                _currentLocation = row + " " + col;
            }
            else
            {
                _currentLocation = row + " " + col;
            }
        }
    }
}
