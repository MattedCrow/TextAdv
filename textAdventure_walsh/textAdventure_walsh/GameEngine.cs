using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure_walsh
{
    class GameEngine
    {
        public World World { get; set; }

        public GameEngine()
        {
            this.Init();
        }

        public void Init()
        {
            World = new World();
            World.Init();

        }
    }
}
