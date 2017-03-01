namespace textAdventure_walsh
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chatLogTextBox = new System.Windows.Forms.RichTextBox();
            this.enterTextBox = new System.Windows.Forms.TextBox();
            this.creaturePictureBox = new System.Windows.Forms.PictureBox();
            this.miniMapPictureBox = new System.Windows.Forms.PictureBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.creatureImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.creaturePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miniMapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chatLogTextBox
            // 
            this.chatLogTextBox.Location = new System.Drawing.Point(12, 12);
            this.chatLogTextBox.Name = "chatLogTextBox";
            this.chatLogTextBox.ReadOnly = true;
            this.chatLogTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.chatLogTextBox.Size = new System.Drawing.Size(373, 163);
            this.chatLogTextBox.TabIndex = 0;
            this.chatLogTextBox.Text = "";
            // 
            // enterTextBox
            // 
            this.enterTextBox.Location = new System.Drawing.Point(12, 181);
            this.enterTextBox.Name = "enterTextBox";
            this.enterTextBox.Size = new System.Drawing.Size(293, 20);
            this.enterTextBox.TabIndex = 1;
            // 
            // creaturePictureBox
            // 
            this.creaturePictureBox.Location = new System.Drawing.Point(12, 207);
            this.creaturePictureBox.Name = "creaturePictureBox";
            this.creaturePictureBox.Size = new System.Drawing.Size(75, 105);
            this.creaturePictureBox.TabIndex = 2;
            this.creaturePictureBox.TabStop = false;
            // 
            // miniMapPictureBox
            // 
            this.miniMapPictureBox.Location = new System.Drawing.Point(280, 207);
            this.miniMapPictureBox.Name = "miniMapPictureBox";
            this.miniMapPictureBox.Size = new System.Drawing.Size(105, 105);
            this.miniMapPictureBox.TabIndex = 4;
            this.miniMapPictureBox.TabStop = false;
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(310, 181);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(75, 20);
            this.enterButton.TabIndex = 5;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            // 
            // creatureImageList
            // 
            this.creatureImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("creatureImageList.ImageStream")));
            this.creatureImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.creatureImageList.Images.SetKeyName(0, "GakiIcon.png");
            this.creatureImageList.Images.SetKeyName(1, "HellhoundIcon.png");
            this.creatureImageList.Images.SetKeyName(2, "HumanIcon.png");
            this.creatureImageList.Images.SetKeyName(3, "OniIcon.png");
            this.creatureImageList.Images.SetKeyName(4, "PlayerIcon.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 325);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.miniMapPictureBox);
            this.Controls.Add(this.creaturePictureBox);
            this.Controls.Add(this.enterTextBox);
            this.Controls.Add(this.chatLogTextBox);
            this.Name = "Form1";
            this.Text = "Into the Dungeon";
            ((System.ComponentModel.ISupportInitialize)(this.creaturePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miniMapPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox chatLogTextBox;
        private System.Windows.Forms.TextBox enterTextBox;
        private System.Windows.Forms.PictureBox creaturePictureBox;
        private System.Windows.Forms.PictureBox miniMapPictureBox;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.ImageList creatureImageList;
    }
}

