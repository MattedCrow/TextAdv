using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class Player
    {
        // unused currently

        public int _playerHLT;      // Health
        public int _playerATK;      // Attack
        public int _playerDEF;      // Defense
        public int _playerSPD;      // Speed
        public int _playerEVA;      // Evasiveness
        public bool _playerHolding; // Is the player holding an item?
        public bool _playerSword;   // Does the player have a sword

        public Player()
        {
            _playerHLT = 100;
            _playerATK = 28;
            _playerDEF = 15;
            _playerSPD = 12;
            _playerEVA = 11;
            _playerHolding = false;
            _playerSword = false;
        }

        public int PlayerHLT
        {
            get { return _playerHLT; }
            set { _playerHLT = value; }
        }

        public int PlayerATK
        {
            get { return _playerATK; }
            set { _playerATK = value; }
        }

        public int PlayerDEF
        {
            get { return _playerDEF; }
            set { _playerDEF = value; }
        }

        public int PlayerSPD
        {
            get { return _playerSPD; }
            set { _playerSPD = value; }
        }

        public int PlayerEVA
        {
            get { return _playerEVA; }
            set { _playerEVA = value; }
        }

        public bool PlayerHolding
        {
            get { return _playerHolding; }
            set { _playerHolding = value; }
        }

        public bool PlayerSword
        {
            get { return _playerSword; }
            set { _playerSword = value; }
        }
    }
}
