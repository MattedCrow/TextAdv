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

        public string _item;
        public bool _itemExists;

        public bool _hasEnemy;
        public int _enemyIndex;

        public bool _hasNPC;
        public int _npcIndex;
        public bool _spokenToNPC;
        public bool _npcHasExtraDialouge;

        // Constructors
        public Room()
        {
            _canGoNorth = false;
            _canGoEast = false;
            _canGoSouth = false;
            _canGoWest = false;

            _desc = "You're in a room";
            _enterDesc = "This is a different room.";

            _item = "";
            _itemExists = false;

            _hasEnemy = false;
            _enemyIndex = -1;

            _hasNPC = false;
            _npcIndex = -1;
            _spokenToNPC = false;
            _npcHasExtraDialouge = false;
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

        public bool ItemExists
        {
            get { return _itemExists; }
            set { _itemExists = value; }
        }

        public string Item
        {
            get { return _item; }
            set { _item = value; }
        }

        public bool HasEnemy
        {
            get; set;
        }

        public int EnemyIndex
        {
            get; set;
        }

        public bool HasNPC
        {
            get; set;
        }

        public int npcIndex
        {
            get; set;
        }

        public bool SpokenToNPC
        {
            get; set;
        }

        public bool NPCHasExtraDialogue
        {
            get { return _npcHasExtraDialouge; }
            set { _npcHasExtraDialouge = value; }
        }
    }
}
