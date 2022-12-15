namespace New_KTANE_Solver
{
    partial class FastMathStage1Form
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
            this.lettersTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.StrikeButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.letterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lettersTextBox
            // 
            this.lettersTextBox.Location = new System.Drawing.Point(226, 105);
            this.lettersTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lettersTextBox.Name = "lettersTextBox";
            this.lettersTextBox.Size = new System.Drawing.Size(140, 23);
            this.lettersTextBox.TabIndex = 11;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(331, 218);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(108, 50);
            this.submitButton.TabIndex = 15;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // StrikeButton
            // 
            this.StrikeButton.Location = new System.Drawing.Point(173, 218);
            this.StrikeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StrikeButton.Name = "StrikeButton";
            this.StrikeButton.Size = new System.Drawing.Size(108, 50);
            this.StrikeButton.TabIndex = 17;
            this.StrikeButton.Text = "Strike";
            this.StrikeButton.UseVisualStyleBackColor = true;
            this.StrikeButton.Click += new System.EventHandler(this.StrikeButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(18, 218);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(108, 50);
            this.backButton.TabIndex = 16;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // letterLabel
            // 
            this.letterLabel.AutoSize = true;
            this.letterLabel.Location = new System.Drawing.Point(106, 107);
            this.letterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.letterLabel.Name = "letterLabel";
            this.letterLabel.Size = new System.Drawing.Size(45, 15);
            this.letterLabel.TabIndex = 12;
            this.letterLabel.Text = "Letters:";
            // 
            // FastMathStage1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 278);
            this.Controls.Add(this.lettersTextBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.StrikeButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.letterLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FastMathStage1Form";
            this.Text = "KTANE Bot by Hawker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox lettersTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button StrikeButton;
        private System.Windows.Forms.Button backButton;
        private Label letterLabel;
    }
}