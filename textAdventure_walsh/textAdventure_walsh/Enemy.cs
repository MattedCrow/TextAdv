using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class Enemy
    {
        // unused currently

        public string _enemyName;  // The enemy's name
        public string _enemyDesc;  // A description of the enemy
        public int _enemyHLT;      // Health
        public int _enemyATK;      // Attack
        public int _enemyDEF;      // Defense
        public int _enemySPD;      // Speed
        public int _enemyEVA;      // Evasiveness

        public Enemy()
        {
            _enemyName = "Enemy";
            _enemyDesc = "A creature";
            _enemyHLT = 5;
            _enemyATK = 1;
            _enemyDEF = 1;
            _enemySPD = 2;
            _enemyEVA = 1;
        }

        public string EnemyName
        {
            get { return _enemyName; }
            set { _enemyName = value; }
        }

        public string EnemyDesc
        {
            get { return _enemyDesc; }
            set { _enemyDesc = value; }
        }

        public int EnemyHLT
        {
            get { return _enemyHLT; }
            set { _enemyHLT = value; }
        }

        public int EnemyATK
        {
            get { return _enemyATK; }
            set { _enemyATK = value; }
        }

        public int EnemyDEF
        {
            get { return _enemyDEF; }
            set { _enemyDEF = value; }
        }

        public int EnemySPD
        {
            get { return _enemySPD; }
            set { _enemySPD = value; }
        }

        public int EnemyEVA
        {
            get { return _enemyEVA; }
            set { _enemyEVA = value; }
        }
    }
}
