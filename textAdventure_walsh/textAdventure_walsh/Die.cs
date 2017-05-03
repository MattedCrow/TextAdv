using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class Die
    {
        private int _size; // Is it a d20 or d6 or what
        private int _dieResultA;
        private int _dieResultB;
        private Random _rand;

        public Die(int dieSize = 6)
        {
            _size = dieSize;
            _rand = new Random();
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public int DieResultA
        {
            get { return _dieResultA; }
        }

        public int DieResultB
        {
            get { return _dieResultB; }
        }

        public void roll()
        {
            _dieResultA = _rand.Next(_size) + 1;
            _dieResultB = _rand.Next(_size) + 1;
        }
    }
}
