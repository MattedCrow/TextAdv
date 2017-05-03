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

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = enterButton;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine();
            engine.Init();

            chatLogTextBox.Text += "Current commands are 'move (direction)', 'look', 'get', and 'quit'.\n";
            enterTextBox.Focus();


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
                }

                currentMinimap = "Resources/room" + engine.World.currentRow + engine.World.currentCol + ".png";
                miniMapPictureBox.Image = Image.FromFile(currentMinimap);

                chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                chatLogTextBox.ScrollToCaret();
            }
            else if (tokens[0] == "look" && engine.World.inBattle == false)
            {
                chatLogTextBox.Text += engine.World.coords[engine.World.currentRow, engine.World.currentCol].Desc;

                chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                chatLogTextBox.ScrollToCaret();
            }
            else if (tokens[0] == "look" && engine.World.inBattle == true)
            {
                chatLogTextBox.Text += engine.Monster.EnemyDesc;

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

            // else if (tokens[0] == "use" && engine.World.inBattle == false)
            // else if (tokens[0] == "use" && engine.World.inBattle == true)

            // else if (tokens[0] == "attack" && engine.World.inBattle == false)
            // else if (tokens[0] == "attack" && engine.World.inBattle == true)

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
    }
}
