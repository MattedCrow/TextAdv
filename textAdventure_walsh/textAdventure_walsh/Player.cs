using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class Player : Mob
    {
        private string _name;
        private bool _hasSword;           // If player has a sword = true
        private bool _holdingObject;      // If player is holding an object = true
        private string _currentlyHolding; // Name of currently held object

        public Player()
        {
            _name = "Player";
            _hasSword = false;
            _holdingObject = false;
            _currentlyHolding = "Nothing";
        }

        public bool HasSword
        {
            get; set;
        }

        public bool HoldingObject
        {
            get; set;
        }

        public string CurrentlyHolding
        {
            get; set;
        }

        public override string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string getInfo()
        {
            string stats;

            stats = Name + "\nHealth: " + HLT.ToString() + "\nAttack: " + ATK.ToString() + "\nDefense: " + DEF.ToString()
                + "\nSpeed: " + SPD.ToString() + "\nEvasiveness: " + EVA.ToString() + "\nCurrent Item: " + CurrentlyHolding + "\n\n";

            return stats;
        }
    }
}
