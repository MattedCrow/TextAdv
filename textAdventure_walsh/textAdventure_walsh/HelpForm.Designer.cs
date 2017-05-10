namespace textAdventure_walsh
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.listTextBox = new System.Windows.Forms.RichTextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listTextBox
            // 
            this.listTextBox.Location = new System.Drawing.Point(12, 12);
            this.listTextBox.Name = "listTextBox";
            this.listTextBox.ReadOnly = true;
            this.listTextBox.Size = new System.Drawing.Size(381, 227);
            this.listTextBox.TabIndex = 1;
            this.listTextBox.Text = resources.GetString("listTextBox.Text");
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 245);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(381, 20);
            this.inputTextBox.TabIndex = 0;
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(129, 271);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(75, 23);
            this.enterButton.TabIndex = 2;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(210, 271);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 306);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.listTextBox);
            this.Name = "HelpForm";
            this.Text = "Command List";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox listTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Button closeButton;
    }
}