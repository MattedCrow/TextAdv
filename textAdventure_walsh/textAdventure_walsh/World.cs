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

        public bool inBattle { get; set; }

        public World()
        {
            MaxRow = 4;
            MaxCol = 4;

            coords = new Room[MaxRow, MaxCol];

            currentCol = 0;
            currentRow = 0;

            inBattle = false;
        }

        public void Init()
        {
            // Populate coords
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    coords[row, col] = new Room();
                }
            }

            // ROW ONE
            coords[0,0].EnterDesc = "This room is where you came in.\n\n";
            coords[0, 0].Desc = "The entrance is right there.\n\n";
            coords[0, 0].CanGoEast = true;
            coords[0, 0].CanGoNorth = false;
            coords[0, 0].CanGoWest = false;
            coords[0, 0].CanGoSouth = true;

            coords[0, 1].EnterDesc = "There's an enemy in here... Can you slip by?\n\n";
            coords[0, 1].Desc = "Upon further inspection, this room stinks.\n\n";
            coords[0, 1].CanGoNorth = false;
            coords[0, 1].CanGoEast = false;
            coords[0, 1].CanGoSouth = true;
            coords[0, 1].CanGoWest = true;

            coords[0, 2].EnterDesc = "This room is fairly large and open.. Wait! That's the boss to the south!\n\n";
            coords[0, 2].Desc = "The boss is really intimating to watch..\n\n";
            coords[0, 2].CanGoNorth = false;
            coords[0, 2].CanGoEast = true;
            coords[0, 2].CanGoSouth = true;
            coords[0, 2].CanGoWest = false;

            coords[0, 3].EnterDesc = "There's an enemy! But it seems you can sneak by right now...\n\n";
            coords[0, 3].Desc = "The enemy seems to be asleep right now.\n\n";
            coords[0, 3].CanGoNorth = false;
            coords[0, 3].CanGoEast = false;
            coords[0, 3].CanGoSouth = true;
            coords[0, 3].CanGoWest = true;

            // ROW TWO
            coords[1, 0].EnterDesc = "Woah, what's that dude doing? Let's leave him alone for now...\n\n";
            coords[1, 0].Desc = "You can't even begin to describe what the guy might be doing.\n\n";
            coords[1, 0].CanGoEast = false;
            coords[1, 0].CanGoNorth = true;
            coords[1, 0].CanGoWest = false;
            coords[1, 0].CanGoSouth = true;

            coords[1, 1].EnterDesc = "Hey, there's a chest in here! But it's locked.\n\n";
            coords[1, 1].Desc = "If only you had a key.\n\n";
            coords[1, 1].CanGoNorth = true;
            coords[1, 1].CanGoEast = false;
            coords[1, 1].CanGoSouth = false;
            coords[1, 1].CanGoWest = false;

            coords[1, 2].EnterDesc = "The boss is right in front of you! Sleeping.. on the exit.\n\n";
            coords[1, 2].Desc = "Seems you can't get out until you find your sword.\n\n";
            coords[1, 2].CanGoNorth = true;
            coords[1, 2].CanGoEast = false;
            coords[1, 2].CanGoSouth = false;
            coords[1, 2].CanGoWest = false;

            coords[1, 3].EnterDesc = "Is that person sleeping on that chest?\n\n";
            coords[1, 3].Desc = "They're truly dead to the world.\n\n";
            coords[1, 3].CanGoNorth = true;
            coords[1, 3].CanGoEast = false;
            coords[1, 3].CanGoSouth = true;
            coords[1, 3].CanGoWest = false;

            // ROW THREE
            coords[2, 0].EnterDesc = "That dude to the north is still.. doing something.\n\n";
            coords[2, 0].Desc = "You better get a move on.\n\n";
            coords[2, 0].CanGoEast = true;
            coords[2, 0].CanGoNorth = true;
            coords[2, 0].CanGoWest = false;
            coords[2, 0].CanGoSouth = true;

            coords[2, 1].EnterDesc = "There's another person in here! But they're busy with a chest.\n\n";
            coords[2, 1].Desc = "Seems you can't get their attention.\n\n";
            coords[2, 1].CanGoNorth = false;
            coords[2, 1].CanGoEast = false;
            coords[2, 1].CanGoSouth = false;
            coords[2, 1].CanGoWest = true;

            coords[2, 2].EnterDesc = "There's a person being attacked here! But we can't.. help.. yet. \n\n";
            coords[2, 2].Desc = "If only you hadn't misplaced your sword. Then you could of helped. \n\n";
            coords[2, 2].CanGoNorth = true;
            coords[2, 2].CanGoEast = true;
            coords[2, 2].CanGoSouth = false;
            coords[2, 2].CanGoWest = false;

            coords[2, 3].EnterDesc = "Is that person sleeping on that chest?\n\n";
            coords[2, 3].Desc = "Yup. They're definitely asleep on that chest.\n\n";
            coords[2, 3].CanGoNorth = true;
            coords[2, 3].CanGoEast = false;
            coords[2, 3].CanGoSouth = true;
            coords[2, 3].CanGoWest = false;

            // ROW FOUR
            coords[3, 0].EnterDesc = "There's an enemey sleeping in here! Let's slip by them for now.\n\n";
            coords[3, 0].Desc = "Get a move on before you wake it up!\n\n";
            coords[3, 0].CanGoEast = true;
            coords[3, 0].CanGoNorth = true;
            coords[3, 0].CanGoWest = false;
            coords[3, 0].CanGoSouth = true;

            coords[3, 1].EnterDesc = "Just an empty room it seems...\n\n";
            coords[3, 1].Desc = "This room is amazingly boring.\n\n";
            coords[3, 1].CanGoNorth = false;
            coords[3, 1].CanGoEast = true;
            coords[3, 1].CanGoSouth = false;
            coords[3, 1].CanGoWest = true;

            coords[3, 2].EnterDesc = "There's a person being attacked to the north of us!\n\n";
            coords[3, 2].Desc = "You should probably help but you misplaced your sword.\n\n";
            coords[3, 2].CanGoNorth = true;
            coords[3, 2].CanGoEast = false;
            coords[3, 2].CanGoSouth = false;
            coords[3, 2].CanGoWest = false;

            coords[3, 3].EnterDesc = "Is that person... friendly? Let's not find out.\n\n";
            coords[3, 3].Desc = "Why are you still staring at them?\n\n";
            coords[3, 3].CanGoNorth = true;
            coords[3, 3].CanGoEast = false;
            coords[3, 3].CanGoSouth = true;
            coords[3, 3].CanGoWest = false;
        }

        private string _currentLocation;  // row space col

        public string CurrentLocation
        {
            get { return _currentLocation; }
        }

        public void MoveCharacter(string direction, int row, int col)
        {
            bool north = coords[row, col].CanGoNorth;
            bool south = coords[row, col].CanGoSouth;
            bool east = coords[row, col].CanGoEast;
            bool west = coords[row, col].CanGoWest;

            if (direction == "north" && row != 0 && north == true)
            {
                row -= 1;
                _currentLocation = row + " " + col;
            }
            else if (direction == "south" && row != 3 && coords[row, col].CanGoSouth == true)
            {
                row += 1;
                _currentLocation = row + " " + col;
            }
            else if (direction == "east" && col != 3 && coords[row, col].CanGoEast == true)
            {
                col += 1;
                _currentLocation = row + " " + col;
            }
            else if (direction == "west" && col != 0 && coords[row, col].CanGoWest == true)
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
