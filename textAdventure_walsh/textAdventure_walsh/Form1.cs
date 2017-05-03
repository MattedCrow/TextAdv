using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace textAdventure_walsh
{
    public partial class Form1 : Form
    {
        // Make some variables dude
        int quitCheck = 0;

        // Make the world object
        private GameEngine engine;
        private CombatEngine combat;

        public void scrollToBottom()
        {
            chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
            chatLogTextBox.ScrollToCaret();
        }

        public void LoadPlayerInfo()
        {
            StreamReader inputFile2;
            string playerName = "playerOne";

            inputFile2 = File.OpenText("Resources/Players/" + playerName + "Stats.txt");

            // Make array to hold creature info
            const int INFO_SIZE = 8;
            string[] playInfo = new string[INFO_SIZE];

            //Make a counter
            int indexTwo = 0;

            // Read the file's contents into the array.
            while (indexTwo < playInfo.Length && !inputFile2.EndOfStream)
            {
                playInfo[indexTwo] = inputFile2.ReadLine();
                indexTwo++;
            }

            engine.Player.Name = "Nillon the Destroyer";
            engine.Player.Desc = playInfo[1];
            engine.Player.HLT = int.Parse(playInfo[2]);
            engine.Player.ATK = int.Parse(playInfo[3]);
            engine.Player.DEF = int.Parse(playInfo[4]);
            engine.Player.SPD = int.Parse(playInfo[5]);
            engine.Player.EVA = int.Parse(playInfo[6]);

            inputFile2.Close();
        }

        public void updateNPCInfo()
        {
            int currentRow = engine.World.currentRow;
            int currentCol = engine.World.currentCol;

            if (engine.World.coords[currentRow, currentCol].HasNPC == true)
            {
                string npcName = engine.npcs[engine.World.coords[currentRow, currentCol].npcIndex];

                StreamReader inputFile;
                inputFile = File.OpenText("Resources/NPCs/" + npcName + "Stats.txt");

                // Make array to hold creature info
                const int INFO_SIZE = 8;
                string[] npcInfo = new string[INFO_SIZE];

                //Make a counter
                int index = 0;

                // Read the file's contents into the array.
                while (index < npcInfo.Length && !inputFile.EndOfStream)
                {
                    npcInfo[index] = inputFile.ReadLine();
                    index++;
                }

                inputFile.Close();

                engine.NPC.Name = npcInfo[0].ToString();
                engine.NPC.Desc = npcInfo[1].ToString();
                engine.NPC.HLT = int.Parse(npcInfo[2]);
                engine.NPC.ATK = int.Parse(npcInfo[3]);
                engine.NPC.DEF = int.Parse(npcInfo[4]);
                engine.NPC.SPD = int.Parse(npcInfo[5]);
                engine.NPC.EVA = int.Parse(npcInfo[6]);
                engine.NPC.Faction = npcInfo[7];

                scrollToBottom();
            }
        }

        private void updateMonsterInfo()
        {
            int currentRow = engine.World.currentRow;
            int currentCol = engine.World.currentCol;

            if (engine.World.coords[currentRow, currentCol].HasEnemy == true)
            {
                string monsterName = engine.creatures[engine.World.coords[currentRow, currentCol].EnemyIndex];

                StreamReader inputFile;
                inputFile = File.OpenText("Resources/Monsters/" + monsterName + "Stats.txt");

                // Make array to hold creature info
                const int INFO_SIZE = 8;
                string[] monInfo = new string[INFO_SIZE];

                //Make a counter
                int index = 0;

                // Read the file's contents into the array.
                while (index < monInfo.Length && !inputFile.EndOfStream)
                {
                    monInfo[index] = inputFile.ReadLine();
                    index++;
                }

                inputFile.Close();

                engine.Monster.Name = monInfo[0].ToString();
                engine.Monster.Desc = monInfo[1].ToString();
                engine.Monster.HLT = int.Parse(monInfo[2]);
                engine.Monster.ATK = int.Parse(monInfo[3]);
                engine.Monster.DEF = int.Parse(monInfo[4]);
                engine.Monster.SPD = int.Parse(monInfo[5]);
                engine.Monster.EVA = int.Parse(monInfo[6]);
                engine.Monster.EnemyClass = monInfo[7];
                
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = enterButton;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine();
            combat = new CombatEngine();
            engine.Init();

            chatLogTextBox.Text += "Current commands are 'move (direction)', 'look', 'get', and 'quit'.\n";
            enterTextBox.Focus();

            LoadPlayerInfo();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            string input;
            string currentMinimap;
            char[] delim = { ' ' };

            // Format input properly
            input = enterTextBox.Text.Trim();
            input = input.ToLower();
            string[] tokens = input.Split(delim);

            if (tokens[0] == "move" && engine.World.inBattle == false)
            {
                string direction = tokens[1];

                engine.World.MoveCharacter(direction, engine.World.currentRow, engine.World.currentCol);

                string newLocation = engine.World.CurrentLocation;

                string[] newCoords = newLocation.Split(delim);

                int newRow;
                int newCol;

                int.TryParse(newCoords[0], out newRow);
                int.TryParse(newCoords[1], out newCol);

                if (engine.World.currentRow == newRow && engine.World.currentCol == newCol)
                {
                    chatLogTextBox.Text += "You can't move through walls!\n"
                        + "Current location is (" + engine.World.currentRow + "," + engine.World.currentCol + ").\n";
                    engine.World.currentRow = newRow;
                    engine.World.currentCol = newCol;
                }
                else
                {
                    engine.World.currentRow = newRow;
                    engine.World.currentCol = newCol;
                    chatLogTextBox.Text += "You moved one space! New location is (" + engine.World.currentRow + "," + engine.World.currentCol + ").\n";
                    chatLogTextBox.Text += engine.World.coords[newRow, newCol].EnterDesc;

                    updateMonsterInfo();
                    updateNPCInfo();
                }

                currentMinimap = "Resources/room" + engine.World.currentRow + engine.World.currentCol + ".png";
                miniMapPictureBox.Image = Image.FromFile(currentMinimap);

                scrollToBottom();

                otherPictureBox.Visible = false;
            }
            else if (tokens[0] == "look" && engine.World.inBattle == false)
            {
                chatLogTextBox.Text += engine.World.coords[engine.World.currentRow, engine.World.currentCol].Desc;

                chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                chatLogTextBox.ScrollToCaret();
            }
            else if (tokens[0] == "look" && engine.World.inBattle == true)
            {
                chatLogTextBox.Text += engine.Monster.getInfo();

                chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                chatLogTextBox.ScrollToCaret();
            }
            else if (tokens[0] == "get" && engine.World.inBattle == false)
            {
                if (engine.World.coords[engine.World.currentRow, engine.World.currentCol].ItemExists == true && engine.Player.HoldingObject == false)
                {
                    if (engine.World.coords[engine.World.currentRow, engine.World.currentCol].Item != "Chest")
                    {
                        string newItem = engine.World.coords[engine.World.currentRow, engine.World.currentCol].Item;

                        chatLogTextBox.Text += "You picked up a " + newItem + ".\n";

                        engine.World.coords[engine.World.currentRow, engine.World.currentCol].ItemExists = false;

                        engine.Player.HoldingObject = true;
                        engine.Player.CurrentlyHolding = newItem;

                        chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                        chatLogTextBox.ScrollToCaret();
                    }
                    else
                    {
                        chatLogTextBox.Text += "You can't pick up a chest!\n";

                        chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                        chatLogTextBox.ScrollToCaret();
                    }
                }
                else if (engine.World.coords[engine.World.currentRow, engine.World.currentCol].ItemExists == true && engine.Player.HoldingObject == true)
                {
                    if (engine.World.coords[engine.World.currentRow, engine.World.currentCol].Item != "Chest")
                    {
                        string newItem = engine.World.coords[engine.World.currentRow, engine.World.currentCol].Item;
                        string priorItem = engine.Player.CurrentlyHolding;

                        chatLogTextBox.Text += "You picked up a " + newItem +
                            " and dropped a " + priorItem + ".\n";
                        
                        engine.World.coords[engine.World.currentRow, engine.World.currentCol].ItemExists = true;

                        engine.Player.HoldingObject = true;
                        engine.World.coords[engine.World.currentRow, engine.World.currentCol].Item = priorItem;
                        engine.Player.CurrentlyHolding = newItem;


                        chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                        chatLogTextBox.ScrollToCaret();
                    }
                    else
                    {
                        chatLogTextBox.Text += "You can't pick up a chest!\n";

                        chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                        chatLogTextBox.ScrollToCaret();
                    }
                }
                else
                {
                    chatLogTextBox.Text += "There is nothing to pick up in this room!\n";

                    chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                    chatLogTextBox.ScrollToCaret();
                }
            }

            // else if (tokens[0] == "open" && engine.World.inBattle == false)

            else if (tokens[0] == "use" && engine.World.inBattle == false)
            {
                if (engine.Player.HoldingObject == true && engine.Player.CurrentlyHolding == "Sword")
                {
                    chatLogTextBox.Text += "You equipped your sword!";

                    engine.Player.CurrentlyHolding = "";
                    engine.Player.HoldingObject = false;
                    engine.Player.HasSword = true;
                }
                else if (engine.Player.HoldingObject == true && engine.Player.CurrentlyHolding == "Health Potion")
                {
                    engine.Player.HLT += 100;
                }
            }
            else if (tokens[0] == "use" && engine.World.inBattle == true)
            {
                if (engine.Player.HoldingObject == true && engine.Player.CurrentlyHolding == "Health Potion")
                {
                    engine.Player.HLT += 100;
                }
            }
            else if (tokens[0] == "attack" && engine.World.inBattle == false)
            {
                if (engine.World.coords[engine.World.currentRow,engine.World.currentCol].HasEnemy == true && engine.Player.HasSword == true)
                {
                    chatLogTextBox.Text += "Fight started! You may not move unless you (flee or) defeat the enemy!\n";

                    engine.World.inBattle = true;
                }
                else if (engine.Player.HasSword == true)
                {
                    chatLogTextBox.Text += "There's nothing you can attack in this room!\n";
                }
                else if (engine.Player.HasSword == false)
                {
                    chatLogTextBox.Text += "You need a sword before you can attack things!\n";
                }

                chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                chatLogTextBox.ScrollToCaret();
            }
            else if (tokens[0] == "attack" && engine.World.inBattle == true)
            {
                string response, roundResults;
                DoATK(out response, out roundResults);
                chatLogTextBox.Text += response;
                chatLogTextBox.Text += roundResults;

                chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                chatLogTextBox.ScrollToCaret();

                if (engine.Player.HLT <= 0)
                {
                    engine.gameLost = true;
                    chatLogTextBox.Text += "You lost! Please reopen the game to play again.\n";
                }
                else if (engine.Monster.HLT <= 0)
                {
                    combat.fightStart = false;
                    engine.World.inBattle = false;

                    engine.World.coords[engine.World.currentRow, engine.World.currentCol].HasEnemy = false;
                    otherPictureBox.Visible = false;
                }
                chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                chatLogTextBox.ScrollToCaret();
            }

            // else if (tokens[0] == "leave" && gameWon == true)
            // else if (tokens[0] == "leave" && gameWon == false)
            else if (tokens[0] == "quit")
            {
                quitCheck = 1;
                chatLogTextBox.Text += "Are you sure you want to quit? Enter 'yes' if you are sure. \n";

                chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                chatLogTextBox.ScrollToCaret();
            }
            else if (tokens[0] == "yes" && quitCheck == 1)
            {
                this.Close();
            }
            else
            {
                chatLogTextBox.Text += "You didn't enter a valid command!\n";

                chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                chatLogTextBox.ScrollToCaret();
            }

            enterTextBox.Text = "";
            enterTextBox.Focus();
        }

        public void DoATK(out string response, out string roundResults)
        {
            response = "\n";
            roundResults = "\n";
            engine.Player.getInfo();

            int atkSPD = engine.Player.SPD + combat.roll3d6();
            int MonSPD = engine.Monster.SPD + combat.roll3d6();
            if (atkSPD > MonSPD || atkSPD == MonSPD)
            {
                // Player attacks first
                string attackPlayerResults, defendDefendResults;
                PlayerATK(out attackPlayerResults);
                if (engine.Monster.HLT > 0)
                {
                    MonsterATK(out defendDefendResults);
                    response = attackPlayerResults + defendDefendResults + "\n";
                    roundResults = "\nPlayer " + engine.Player.Name + " now has " + engine.Player.HLT + " health. \nMonster "
                        + engine.Monster.Name + " now has " + engine.Monster.HLT + " health. \n";
                }
                else if (engine.Monster.HLT <= 0)
                {
                    chatLogTextBox.Text += "You defeated the enemy! Your health is now at " + engine.Player.HLT.ToString() + ".\n";
                }
            }
            else if (MonSPD > atkSPD)
            {
                string defendPlayerResults, attackMonsterResults;
                // Monster attacks first
                MonsterATK(out attackMonsterResults);
                if (engine.Player.HLT > 0)
                {
                    PlayerATK(out defendPlayerResults);

                    response = attackMonsterResults + defendPlayerResults + "\n";
                    roundResults = "\nPlayer " + engine.Player.Name + " now has " + engine.Player.HLT + " health. \nMonster "
                        + engine.Monster.Name + " now has " + engine.Monster.HLT + " health. \n";
                }
                else
                {
                    response = attackMonsterResults + "\n";
                }

            }
            
        }

        public void PlayerATK(out string attackResults)
        {
            int atkRoll = engine.Player.ATK + combat.roll3d6();
            int defRoll = engine.Monster.DEF + combat.defenderRoll3d6();

            if (atkRoll > defRoll)
            {
                engine.Player.DamageDie1.roll();
                int atkDamage = engine.Player.DamageDie1.DieResultA;
                engine.Monster.HLT = engine.Monster.HLT - atkDamage;
                attackResults = engine.Player.Name + " attacked the enemy " + engine.Monster.Name + " for " + atkDamage + " damage!\n";

                if (engine.Monster.HLT <= 0)
                {
                    attackResults += engine.Player.Name + " has defeated the enemy " + engine.Monster.Name + "!\n";
                }
                else
                {
                    attackResults = engine.Player.Name + " attacked the enemy " + engine.Monster.Name + " for " + atkDamage + " damage!\n";
                }
            }
            else
            {
                attackResults = engine.Player.Name + " missed!\n";
            }
        }

        public void MonsterATK(out string defendResults)
        {
            int atkRoll = engine.Monster.ATK + combat.defenderRoll3d6();
            int defRoll = engine.Player.DEF + combat.roll3d6();

            if (atkRoll > defRoll)
            {
                engine.Monster.DamageDie2.roll();
                int atkDamage = engine.Monster.DamageDie2.DieResultB;
                engine.Player.HLT = engine.Player.HLT - atkDamage;
                defendResults = engine.Monster.Name + " attacked the player, " + engine.Player.Name + " for " + atkDamage + " damage!\n";

                if (engine.Player.HLT <= 0)
                {
                    defendResults += engine.Monster.Name + " has defeated the player, " + engine.Player.Name + "!\n";
                    engine.gameLost = true;
                }
                else
                {
                    defendResults = engine.Monster.Name + " attacked the player, " + engine.Player.Name + " for " + atkDamage + " damage!\n";
                }
            }
            else
            {
                defendResults = engine.Monster.Name + " missed!\n";
            }
        }

    }
}
