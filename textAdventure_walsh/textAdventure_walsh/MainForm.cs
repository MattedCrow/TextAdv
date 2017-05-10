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

// This program is a text adventure game! You play as the 'Player', Nillon and can fight enemies and talk to NPCs while picking up items.
//
// CSC 253 0051 -- Final Project -- Text Adventure -- 05.10.17
// Matthew 'Melissa' Walsh

namespace textAdventure_walsh
{
    public partial class MainForm : Form
    {
        // Make some variables dude
        int quitCheck = 0;

        // Make the world object
        private GameEngine engine;
        private CombatEngine combat;

        private HelpForm help;

        public void scrollToBottom()
        {
            chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
            chatLogTextBox.ScrollToCaret();
        }

        public void UpdateHeldItem()
        {
            if (engine.Player.HoldingObject == true)
            {
                holdingLabel.Visible = true;
                holdingPictureBox.Visible = true;

                if (engine.Player.CurrentlyHolding == "Sword")
                {
                    holdingPictureBox.Image = Image.FromFile("Resources/Items/SwordIcon.png");
                }
                else if (engine.Player.CurrentlyHolding == "Health Potion")
                {
                    holdingPictureBox.Image = Image.FromFile("Resources/Items/HealthPotionIcon.png");
                }
                else if (engine.Player.CurrentlyHolding == "Key")
                {
                    holdingPictureBox.Image = Image.FromFile("Resources/Items/KeyIcon.png");
                }
                else if (engine.Player.CurrentlyHolding == "Strength Potion")
                {
                    holdingPictureBox.Image = Image.FromFile("Resources/Items/StrengthPotionIcon.png");
                }
                else if (engine.Player.CurrentlyHolding == "Chest")
                {
                    holdingPictureBox.Image = Image.FromFile("Resources/Items/chestIcon.png");
                }
            }
            else
            {
                holdingLabel.Visible = false;
                holdingPictureBox.Visible = false;
            }
        }

        public void UpdateRoomItem()
        {
            int currentRow = engine.World.currentRow;
            int currentCol = engine.World.currentCol;

            if (engine.World.coords[currentRow,currentCol].ItemExists == true)
            {
                floorPictureBox.Visible = true;
                floorLabel.Visible = true;

                if (engine.World.coords[engine.World.currentRow, engine.World.currentCol].Item == "Sword")
                {
                    floorPictureBox.Image = Image.FromFile("Resources/Items/SwordIcon.png");
                }
                else if (engine.World.coords[currentRow,currentCol].Item == "Health Potion")
                {
                    floorPictureBox.Image = Image.FromFile("Resources/Items/HealthPotionIcon.png");
                }
                else if (engine.World.coords[currentRow,currentCol].Item == "Key")
                {
                    floorPictureBox.Image = Image.FromFile("Resources/Items/KeyIcon.png");
                }
                else if (engine.World.coords[currentRow,currentCol].Item == "Strength Potion")
                {
                    floorPictureBox.Image = Image.FromFile("Resources/Items/StrengthPotionIcon.png");
                }
                else if (engine.World.coords[currentRow,currentCol].Item == "Chest")
                {
                    floorPictureBox.Image = Image.FromFile("Resources/Items/ChestIcon.png");
                }
            }
            else
            {
                floorLabel.Visible = false;
                floorPictureBox.Visible = false;
            }
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

        public MainForm()
        {
            InitializeComponent();
            this.AcceptButton = enterButton;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine();
            combat = new CombatEngine();
            engine.Init();

            help = new HelpForm();

            chatLogTextBox.Text += "Say 'help' or click the 'help' button for a list of commands.\n\n" +
                "Is that something glittering over there..?\n";
            enterTextBox.Focus();

            LoadPlayerInfo();

            UpdateHeldItem();
            UpdateRoomItem();
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

                    UpdateHeldItem();
                    UpdateRoomItem();
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
                int currentRow = engine.World.currentRow;
                int currentCol = engine.World.currentCol;

                if (engine.World.coords[currentRow, currentCol].ItemExists == true && engine.Player.HoldingObject == false)
                {
                    if (engine.World.coords[currentRow, currentCol].Item != "Chest")
                    {
                        string newItem = engine.World.coords[currentRow, currentCol].Item;

                        chatLogTextBox.Text += "You picked up a " + newItem + ".\n";

                        engine.World.coords[currentRow, currentCol].ItemExists = false;

                        engine.Player.HoldingObject = true;
                        engine.Player.CurrentlyHolding = newItem;

                        UpdateHeldItem();
                        UpdateRoomItem();
                        scrollToBottom();
                    }
                    else
                    {
                        chatLogTextBox.Text += "You can't pick up a chest!\n";

                        scrollToBottom();
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

                        UpdateHeldItem();
                        UpdateRoomItem();
                        scrollToBottom();
                    }
                    else
                    {
                        chatLogTextBox.Text += "You can't pick up a chest!\n";

                        scrollToBottom();
                    }
                }
                else
                {
                    chatLogTextBox.Text += "There is nothing to pick up in this room!\n";

                    scrollToBottom();
                }
            }
            else if (tokens[0] == "open" && engine.World.inBattle == false && engine.World.coords[engine.World.currentRow, engine.World.currentCol].Item == "Chest"
                        && engine.World.coords[engine.World.currentRow, engine.World.currentCol].ItemExists == true)
            {
                if (engine.Player.HoldingObject == true && engine.Player.CurrentlyHolding == "Key")
                {
                    chatLogTextBox.Text += "You opened the chest to find... nothing! What a ripoff!\n";

                    engine.Player.CurrentlyHolding = "";
                    engine.Player.HoldingObject = false;
                    engine.World.coords[engine.World.currentRow, engine.World.currentCol].Item = "";
                    engine.World.coords[engine.World.currentRow, engine.World.currentCol].ItemExists = false;

                    scrollToBottom();
                    UpdateHeldItem();
                    UpdateRoomItem();
                }
                else
                {
                    chatLogTextBox.Text += "You need a key to open the chest!\n";

                    scrollToBottom();
                }
            }
            else if (tokens[0] == "use" && engine.World.inBattle == false)
            {
                if (engine.Player.HoldingObject == true && engine.Player.CurrentlyHolding == "Sword")
                {
                    chatLogTextBox.Text += "You equipped your sword!\n";

                    engine.Player.CurrentlyHolding = "";
                    engine.Player.HoldingObject = false;
                    engine.Player.HasSword = true;

                    scrollToBottom();
                    UpdateHeldItem();
                    UpdateRoomItem();
                }
                else if (engine.Player.HoldingObject == true && engine.Player.CurrentlyHolding == "Health Potion")
                {
                    engine.Player.HLT += 150;

                    engine.Player.CurrentlyHolding = "";
                    engine.Player.HoldingObject = false;

                    chatLogTextBox.Text += "You used a potion! Your health is now at " + engine.Player.HLT + ".\n";

                    scrollToBottom();
                    UpdateHeldItem();
                    UpdateRoomItem();
                }
                else if (tokens[0] == "use" && engine.Player.CurrentlyHolding == "Strength Potion")
                {
                    engine.Player.HLT += 10;
                    engine.Player.ATK += 2;
                    engine.Player.DEF += 1;
                    engine.Player.SPD += 1;

                    chatLogTextBox.Text += "You drank the potion! But.. did it actually do anything..?\n";

                    engine.Player.CurrentlyHolding = "";
                    engine.Player.HoldingObject = false;

                    scrollToBottom();
                    UpdateHeldItem();
                    UpdateRoomItem();

                }
            }
            else if (tokens[0] == "use" && engine.World.inBattle == true)
            {
                if (engine.Player.HoldingObject == true && engine.Player.CurrentlyHolding == "Health Potion")
                {
                    engine.Player.HLT += 150;

                    engine.Player.CurrentlyHolding = "";
                    engine.Player.HoldingObject = false;

                    chatLogTextBox.Text += "You used a potion! Your health is now at " + engine.Player.HLT + ".\n";

                    scrollToBottom();
                    UpdateHeldItem();
                    UpdateRoomItem();
                }
                else if (tokens[0] == "use" && engine.Player.CurrentlyHolding == "Strength Potion")
                {
                    engine.Player.HLT += 10;
                    engine.Player.ATK += 2;
                    engine.Player.DEF += 1;
                    engine.Player.SPD += 1;

                    chatLogTextBox.Text += "You drank the potion! But.. did it actually do anything..?\n";

                    engine.Player.CurrentlyHolding = "";
                    engine.Player.HoldingObject = false;

                    scrollToBottom();
                    UpdateHeldItem();
                    UpdateRoomItem();

                }
            }
            
            else if (tokens[0] == "attack" && engine.World.inBattle == false)
            {
                if (engine.World.coords[engine.World.currentRow, engine.World.currentCol].HasEnemy == true && engine.Player.HasSword == true)
                {
                    chatLogTextBox.Text += "Fight started! You may not move unless you (flee or) defeat the enemy!\n";

                    engine.World.inBattle = true;

                    otherPictureBox.Visible = true;
                    otherPictureBox.Image = Image.FromFile("Resources/Monsters/" + engine.Monster.Name + "Icon.png");
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
                int currentRow = engine.World.currentRow;
                int currentCol = engine.World.currentCol;

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
                    if (engine.World.coords[currentRow, currentCol].EnemyIndex == 1)
                    {
                        engine.gameWon = true;

                        chatLogTextBox.Text += "The exit is right there in front of you! Go on!\n";
                    }
                    else if (engine.World.coords[currentRow, currentCol].EnemyIndex == 2)
                    {
                        if (engine.Player.HoldingObject == false)
                        {
                            chatLogTextBox.Text += "The enemy dropped a health potion! You picked it up! \n";

                            engine.Player.HoldingObject = true;
                            engine.Player.CurrentlyHolding = "Health Potion";

                            UpdateHeldItem();
                            UpdateRoomItem();
                        }
                        else if (engine.Player.HoldingObject == true & engine.World.coords[currentRow,currentCol].ItemExists == false)
                        {
                            chatLogTextBox.Text += "The enemy dropped a health potion, but you don't have room to hold it! It fell onto the floor. \n";

                            engine.World.coords[currentRow, currentCol].ItemExists = true;
                            engine.World.coords[currentRow, currentCol].Item = "Health Potion";

                            UpdateHeldItem();
                            UpdateRoomItem();
                        }
                    }

                    combat.fightStart = false;
                    engine.World.inBattle = false;

                    engine.World.coords[currentRow, currentCol].HasEnemy = false;
                    otherPictureBox.Visible = false;
                }

                scrollToBottom();
            }
            else if (tokens[0] == "talk" && engine.World.coords[engine.World.currentRow, engine.World.currentCol].HasNPC == true)
            {
                int currentRow = engine.World.currentRow;
                int currentCol = engine.World.currentCol;

                otherPictureBox.Visible = true;
                otherPictureBox.Image = Image.FromFile("Resources/NPCs/" + engine.NPC.Name + "Icon.png");

                if (engine.World.coords[currentRow, currentCol].HasEnemy == true)
                {
                    chatLogTextBox.Text += engine.NPC.Name + ": Can you PLEASE deal with the thing attacking me first??\n";
                }
                else
                {
                    if (engine.World.coords[currentRow, currentCol].NPCHasExtraDialogue == false)
                    {
                        if (engine.World.coords[currentRow, currentCol].SpokenToNPC == false)
                        {
                            chatLogTextBox.Text += engine.NPC.Name + ": Good to meet you.\n";

                            engine.World.coords[currentRow, currentCol].SpokenToNPC = true;

                            scrollToBottom();
                        }
                        else
                        {
                            chatLogTextBox.Text += engine.NPC.Name + ": Welcome back.\n";

                            scrollToBottom();
                        }
                    }
                    else if (engine.World.coords[currentRow, currentCol].NPCHasExtraDialogue == true)
                    {
                        string dialogue;

                        if (engine.NPC.Name == "Ireth")
                        {
                            dialogue = engine.NPC.irethSpeak();

                            chatLogTextBox.Text += engine.NPC.Name + ": " + dialogue;

                            scrollToBottom();
                        }
                        else if (engine.NPC.Name == "Sauvterre")
                        {
                            dialogue = engine.NPC.sauvterreSpeak();

                            chatLogTextBox.Text += engine.NPC.Name + ": " + dialogue;

                            scrollToBottom();
                        }
                        else if (engine.NPC.Name == "Atlas")
                        {
                            dialogue = engine.NPC.atlasSpeak();

                            chatLogTextBox.Text += engine.NPC.Name + ": " + dialogue;

                            if (engine.NPC.DialogueAtlas03Said == true && engine.Player.HoldingObject == false && engine.NPC.AtlasItemGiven == false)
                            {
                                chatLogTextBox.Text += engine.NPC.Name + " gave you a key!\n";

                                engine.Player.HoldingObject = true;
                                engine.Player.CurrentlyHolding = "Key";
                                engine.NPC.AtlasItemGiven = true;

                                UpdateHeldItem();
                                UpdateRoomItem();
                            }
                            else if (engine.NPC.DialogueAtlas03Said == true && engine.Player.HoldingObject == true && engine.NPC.AtlasItemGiven == false)
                            {
                                chatLogTextBox.Text += engine.NPC.Name + " wants to give you an item, please use your current one first!\n";
                            }

                            scrollToBottom();
                        }
                        else if (engine.NPC.Name == "Annabelle")
                        {
                            dialogue = engine.NPC.annaSpeak();

                            chatLogTextBox.Text += engine.NPC.Name + ": " + dialogue;

                            scrollToBottom();
                        }
                        else if (engine.NPC.Name == "Faustus")
                        {
                            dialogue = engine.NPC.faustSpeak();

                            chatLogTextBox.Text += engine.NPC.Name + ": " + dialogue;

                            if (engine.NPC.DialogueFaustus03Said == true && engine.Player.HoldingObject == false && engine.NPC.FaustItemGiven == false)
                            {
                                chatLogTextBox.Text += engine.NPC.Name + " gave you a key!\n";

                                engine.Player.HoldingObject = true;
                                engine.Player.CurrentlyHolding = "Key";
                                engine.NPC.FaustItemGiven = true;

                                UpdateHeldItem();
                                UpdateRoomItem();
                            }
                            else if (engine.NPC.DialogueFaustus03Said == true && engine.Player.HoldingObject == true && engine.NPC.FaustItemGiven == false)
                            {
                                chatLogTextBox.Text += engine.NPC.Name + " wants to give you an item, please use your current one first!\n";
                            }

                            scrollToBottom();
                        }
                    }
                }
            }
            else if (tokens[0] == "talk" && engine.World.coords[engine.World.currentRow, engine.World.currentCol].HasNPC == false)
            {
                chatLogTextBox.Text += "Why are you talking to yourself?\n";

                scrollToBottom();
            }
            else if (tokens[0] == "leave" && engine.gameWon == true)
            {
                chatLogTextBox.Text += "Are you sure you wish to leave? This will close the game. Enter 'yes' if you are certain.\n";

                quitCheck = 1;

                scrollToBottom();
            }
            else if (tokens[0] == "leave" && engine.gameWon == false)
            {
                chatLogTextBox.Text += "You can't leave the dungeon yet!\n";

                scrollToBottom();
            }
            else if (tokens[0] == "quit")
            {
                quitCheck = 1;
                chatLogTextBox.Text += "Are you sure you want to quit? Enter 'yes' if you are sure. \n";

                scrollToBottom();
            }
            else if (tokens[0] == "yes" && quitCheck == 1)
            {
                this.Close();
            }
            else if (tokens[0] == "help")
            {
                help.ShowDialog();
            }
            else
            {
                chatLogTextBox.Text += "You didn't enter a valid command!\n";

                scrollToBottom();
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

        private void helpButton_Click(object sender, EventArgs e)
        {
            help.ShowDialog();
        }
    }
}
