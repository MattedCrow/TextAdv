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
        public const int ROWS = 4;
        public const int COLS = 4;
        public int[,] coords = new int[ROWS, COLS];
        int row = 0;
        int col = 0;
        int quitCheck = 0;

        // Make a new room object???
        private Room currentRoom = new Room();

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

                currentRoom.MoveCharacter(direction, row, col);

                string newLocation = currentRoom.CurrentLocation;

                string[] coords = newLocation.Split(delim);

                int newRow;
                int newCol;

                int.TryParse(coords[0], out newRow);
                int.TryParse(coords[1], out newCol);

                if (row == newRow && col == newCol)
                {
                    chatLogTextBox.Text += "It seems you were unable to move! Are you on the edge of the map?\n"
                        + "Current location is (" + row + "," + col + ").\n";
                    row = newRow;
                    col = newCol;
                }
                else
                {
                    row = newRow;
                    col = newCol;
                    chatLogTextBox.Text += "You moved one space! New location is (" + row + "," + col + ").\n";
                }

                currentMinimap = "room" + row + col + ".png";
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
