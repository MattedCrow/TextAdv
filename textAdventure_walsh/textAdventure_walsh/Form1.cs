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
                // Move North
                if (tokens[1] == "north" && row != 0)
                {
                    row -= 1;
                    chatLogTextBox.Text += "You moved one place north. New location is (" + row + "," + col + ").\n";

                    currentMinimap = "room" + row + col + ".png";
                    miniMapPictureBox.Image = Image.FromFile(currentMinimap);
                    
                }
                else if (tokens[1] == "north" && row == 0)
                {
                    chatLogTextBox.Text += "You can't move any further north! Current location is (" + row + "," + col + ").\n";
                }

                // Move South
                if (tokens[1] == "south" && row != 3)
                {
                    row += 1;
                    chatLogTextBox.Text += "You moved one place south. New location is (" + row + "," + col + ").\n";

                    currentMinimap = "room" + row + col + ".png";
                    miniMapPictureBox.Image = Image.FromFile(currentMinimap);
                }
                else if (tokens[1] == "south" && row == 3)
                {
                    chatLogTextBox.Text += "You can't move any further south! Current location is (" + row + "," + col + ").\n";
                }

                // Move East
                if (tokens[1] == "east" && col != 3)
                {
                    col += 1;
                    chatLogTextBox.Text += "You moved one place east! New location is (" + row + "," + col + ").\n";

                    currentMinimap = "room" + row + col + ".png";
                    miniMapPictureBox.Image = Image.FromFile(currentMinimap);
                }
                else if (tokens[1] == "east" && col == 3)
                {
                    chatLogTextBox.Text += "You can't go any further east! Current location is (" + row + "," + col + ").\n";
                }

                // Move West
                if (tokens[1] == "west" && col != 0)
                {
                    col -= 1;
                    chatLogTextBox.Text += "You moved one place west! New location is (" + row + "," + col + ").\n";

                    currentMinimap = "room" + row + col + ".png";
                    miniMapPictureBox.Image = Image.FromFile(currentMinimap);
                }
                else if (tokens[1] == "west" && col == 0)
                {
                    chatLogTextBox.Text += "You can't go any further west! Current location is (" + row + "," + col + ").\n";
                }
            }
            else if (tokens[0] == "quit")
            {
                quitCheck = 1;
                chatLogTextBox.Text += "Are you sure you want to quit? Enter 'yes' if you are sure. \n";
            }
            else if (tokens[0] == "yes" && quitCheck == 1)
            {
                this.Close();
            }
            else
            {
                chatLogTextBox.Text += "You didn't enter a valid command!\n";
            }


            enterTextBox.Text = "";
            enterTextBox.Focus();
            chatLogTextBox.SelectionStart = chatLogTextBox.Text.Length;
            chatLogTextBox.ScrollToCaret();
        }

    }
}
