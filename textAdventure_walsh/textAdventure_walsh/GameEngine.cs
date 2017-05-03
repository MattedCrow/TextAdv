using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace textAdventure_walsh
{
    class GameEngine
    {
        public World World { get; set; }
        public Enemy Monster { get; set; }
        public Player Player { get; set; }
        public NPC NPC { get; set; }


        // Create array to hold creatures
        public const int CREATURE_SIZE = 5;
        public string[] creatures = new string[CREATURE_SIZE];

        // Create array to hold NPCs
        public const int NPC_SIZE = 5;
        public string[] npcs = new string[NPC_SIZE];


        public GameEngine()
        {
            this.Init();
            this.LoadEnemyList();
            this.LoadNPCList();

            Monster = new Enemy();
            Player = new Player();
            NPC = new NPC();
        }

        public void Init()
        {
            World = new World();
            World.Init();


        }


        public void LoadEnemyList()
        {
            // Counter variable to use in the loop
            int indexOne = 0;
            StreamReader inputFile;

            inputFile = File.OpenText("Resources/Monsters/monsterList.txt");

            // Read the file's contents into the array.

            while (indexOne < creatures.Length && !inputFile.EndOfStream)
            {
                creatures[indexOne] = inputFile.ReadLine();
                indexOne++;
            }

            // Close the file.
            inputFile.Close();
        }

        public void LoadNPCList()
        {
            // Counter variable to use in the loop
            int indexOne = 0;
            StreamReader inputFile;

            inputFile = File.OpenText("Resources/NPCs/npcList.txt");

            // Read the file's contents into the array.

            while (indexOne < npcs.Length && !inputFile.EndOfStream)
            {
                npcs[indexOne] = inputFile.ReadLine();
                indexOne++;
            }

            // Close the file.
            inputFile.Close();
        }
    }
}
