using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textAdventure_walsh
{
    public partial class Form1 : Form
    {
        // Make some variables dude
        /* public const int ROWS = 4;
        public const int COLS = 4;
        public int[,] coords = new int[ROWS, COLS];
        int row = 0;
        int col = 0; */
        int quitCheck = 0;

        // Make the objects I GUESS??
        private Move moveChar = new Move();
        private World World = new World();
        private Room Room = new Room();

        public Form1()
        {
            InitializeComponent();
            enterTextBox.Focus();
            this.AcceptButton = enterButton;
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

            if (tokens[0] == "move")
            {
                string direction = tokens[1];

                moveChar.MoveCharacter(direction, World.currentRow, World.currentCol);

                string newLocation = moveChar.CurrentLocation;

                string[] newCoords = newLocation.Split(delim);

                int newRow;
                int newCol;

                int.TryParse(newCoords[0], out newRow);
                int.TryParse(newCoords[1], out newCol);

                if (World.currentRow == newRow && World.currentCol == newCol)
                {
                    chatLogTextBox.Text += "It seems you were unable to move! Are you on the edge of the map?\n"
                        + "Current location is (" + World.currentRow + "," + World.currentCol + ").\n";
                    World.currentRow = newRow;
                    World.currentCol = newCol;
                }
                else
                {
                    World.currentRow = newRow;
                    World.currentCol = newCol;
                    chatLogTextBox.Text += "You moved one space! New location is (" + World.currentRow + "," + World.currentCol + ").\n";
                }

                currentMinimap = "room" + World.currentRow + World.currentCol + ".png";
                miniMapPictureBox.Image = Image.FromFile(currentMinimap);

                chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
                chatLogTextBox.ScrollToCaret();
            }
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
