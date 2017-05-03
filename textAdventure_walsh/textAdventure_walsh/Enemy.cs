using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class Enemy : Mob
    {
        // unused currently

        public string _enemyClass;  // The enemy's name
        public string _enemyDesc;  // A description of the enemy

        private bool _isHostile;
        private string _name;

        public Enemy()
        {
            _enemyClass = "Yokai";
            _enemyDesc = "A creature\n\n";

            _isHostile = true;
            _name = "Generic Monster";
        }

        public string EnemyClass
        {
            get { return _enemyClass; }
            set { _enemyClass = value; }
        }

        public string EnemyDesc
        {
            get { return _enemyDesc; }
            set { _enemyDesc = value; }
        }

        public override bool IsHostile
        {
            get
            {
                return _isHostile;
            }

            set
            {
                _isHostile = value;
            }
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
                + "\nSpeed: " + SPD.ToString() + "\nEvasiveness: " + EVA.ToString() + "\nClass: " + EnemyClass + "\n\n";

            return stats;
        }
    }
}
