namespace textAdventure_walsh
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.chatLogTextBox = new System.Windows.Forms.RichTextBox();
            this.enterTextBox = new System.Windows.Forms.TextBox();
            this.creaturePictureBox = new System.Windows.Forms.PictureBox();
            this.miniMapPictureBox = new System.Windows.Forms.PictureBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.otherPictureBox = new System.Windows.Forms.PictureBox();
            this.holdingLabel = new System.Windows.Forms.Label();
            this.holdingPictureBox = new System.Windows.Forms.PictureBox();
            this.helpButton = new System.Windows.Forms.Button();
            this.floorPictureBox = new System.Windows.Forms.PictureBox();
            this.floorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.creaturePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miniMapPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdingPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chatLogTextBox
            // 
            this.chatLogTextBox.BackColor = System.Drawing.Color.White;
            this.chatLogTextBox.Location = new System.Drawing.Point(12, 12);
            this.chatLogTextBox.Name = "chatLogTextBox";
            this.chatLogTextBox.ReadOnly = true;
            this.chatLogTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.chatLogTextBox.Size = new System.Drawing.Size(379, 163);
            this.chatLogTextBox.TabIndex = 1;
            this.chatLogTextBox.Text = "";
            // 
            // enterTextBox
            // 
            this.enterTextBox.Location = new System.Drawing.Point(12, 181);
            this.enterTextBox.Name = "enterTextBox";
            this.enterTextBox.Size = new System.Drawing.Size(298, 20);
            this.enterTextBox.TabIndex = 0;
            // 
            // creaturePictureBox
            // 
            this.creaturePictureBox.Image = global::textAdventure_walsh.Properties.Resources.PlayerIcon;
            this.creaturePictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("creaturePictureBox.InitialImage")));
            this.creaturePictureBox.Location = new System.Drawing.Point(12, 207);
            this.creaturePictureBox.Name = "creaturePictureBox";
            this.creaturePictureBox.Size = new System.Drawing.Size(75, 105);
            this.creaturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.creaturePictureBox.TabIndex = 2;
            this.creaturePictureBox.TabStop = false;
            // 
            // miniMapPictureBox
            // 
            this.miniMapPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("miniMapPictureBox.Image")));
            this.miniMapPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("miniMapPictureBox.InitialImage")));
            this.miniMapPictureBox.Location = new System.Drawing.Point(286, 208);
            this.miniMapPictureBox.Name = "miniMapPictureBox";
            this.miniMapPictureBox.Size = new System.Drawing.Size(105, 105);
            this.miniMapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.miniMapPictureBox.TabIndex = 4;
            this.miniMapPictureBox.TabStop = false;
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(316, 181);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(75, 20);
            this.enterButton.TabIndex = 5;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // otherPictureBox
            // 
            this.otherPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("otherPictureBox.InitialImage")));
            this.otherPictureBox.Location = new System.Drawing.Point(93, 207);
            this.otherPictureBox.Name = "otherPictureBox";
            this.otherPictureBox.Size = new System.Drawing.Size(75, 105);
            this.otherPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.otherPictureBox.TabIndex = 6;
            this.otherPictureBox.TabStop = false;
            this.otherPictureBox.Visible = false;
            // 
            // holdingLabel
            // 
            this.holdingLabel.AutoSize = true;
            this.holdingLabel.BackColor = System.Drawing.Color.Transparent;
            this.holdingLabel.ForeColor = System.Drawing.Color.White;
            this.holdingLabel.Location = new System.Drawing.Point(177, 246);
            this.holdingLabel.Name = "holdingLabel";
            this.holdingLabel.Size = new System.Drawing.Size(45, 13);
            this.holdingLabel.TabIndex = 7;
            this.holdingLabel.Text = "In Hand";
            this.holdingLabel.Visible = false;
            // 
            // holdingPictureBox
            // 
            this.holdingPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("holdingPictureBox.InitialImage")));
            this.holdingPictureBox.Location = new System.Drawing.Point(174, 262);
            this.holdingPictureBox.Name = "holdingPictureBox";
            this.holdingPictureBox.Size = new System.Drawing.Size(50, 50);
            this.holdingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.holdingPictureBox.TabIndex = 8;
            this.holdingPictureBox.TabStop = false;
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(192, 208);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 9;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // floorPictureBox
            // 
            this.floorPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("floorPictureBox.InitialImage")));
            this.floorPictureBox.Location = new System.Drawing.Point(230, 262);
            this.floorPictureBox.Name = "floorPictureBox";
            this.floorPictureBox.Size = new System.Drawing.Size(50, 50);
            this.floorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.floorPictureBox.TabIndex = 10;
            this.floorPictureBox.TabStop = false;
            // 
            // floorLabel
            // 
            this.floorLabel.AutoSize = true;
            this.floorLabel.BackColor = System.Drawing.Color.Transparent;
            this.floorLabel.ForeColor = System.Drawing.Color.White;
            this.floorLabel.Location = new System.Drawing.Point(232, 246);
            this.floorLabel.Name = "floorLabel";
            this.floorLabel.Size = new System.Drawing.Size(47, 13);
            this.floorLabel.TabIndex = 11;
            this.floorLabel.Text = "On Floor";
            this.floorLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(402, 325);
            this.Controls.Add(this.floorLabel);
            this.Controls.Add(this.floorPictureBox);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.holdingPictureBox);
            this.Controls.Add(this.holdingLabel);
            this.Controls.Add(this.otherPictureBox);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.miniMapPictureBox);
            this.Controls.Add(this.creaturePictureBox);
            this.Controls.Add(this.enterTextBox);
            this.Controls.Add(this.chatLogTextBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Into the Dungeon";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.creaturePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miniMapPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdingPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox chatLogTextBox;
        private System.Windows.Forms.TextBox enterTextBox;
        private System.Windows.Forms.PictureBox creaturePictureBox;
        private System.Windows.Forms.PictureBox miniMapPictureBox;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.PictureBox otherPictureBox;
        private System.Windows.Forms.Label holdingLabel;
        private System.Windows.Forms.PictureBox holdingPictureBox;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.PictureBox floorPictureBox;
        private System.Windows.Forms.Label floorLabel;
    }
}

