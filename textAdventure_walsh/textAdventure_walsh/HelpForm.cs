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
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();

            this.AcceptButton = enterButton;
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {

        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            string input;
            char[] delim = { ' ' };

            // Format input properly
            input = inputTextBox.Text.Trim();
            input = input.ToLower();
            string[] tokens = input.Split(delim);

            if (tokens[0] == "close")
            {
                this.Close();
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
