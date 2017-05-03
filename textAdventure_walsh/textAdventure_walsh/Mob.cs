using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class Mob
    {
        // Variables
        private string _name; // Mob Name
        private string _desc; // Mob Description

        private int _hlt; // Health
        private int _atk; // Attack
        private int _def; // Defense
        private int _spd; // Speed
        private int _eva; // Evasiveness

        private bool _isHostile; // Checks if Mob is hostile

        // Constraints
        public Mob()
        {
            _name = "Generic";
            _desc = "";

            _hlt = 0;
            _atk = 0;
            _def = 0;
            _spd = 0;
            _eva = 0;

            _isHostile = false;
        }

        public virtual string Name
        {
            get; set;
        }

        public string Desc
        {
            get; set;
        }

        // Stat Getter & Setters Here
        public int HLT
        {
            get; set;
        }

        public int ATK
        {
            get; set;
        }

        public int DEF
        {
            get; set;
        }

        public int SPD
        {
            get; set;
        }

        public int EVA
        {
            get; set;
        }

        public virtual bool IsHostile
        {
            get; set;
        }
    }
}
