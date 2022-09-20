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
            this.rightLetterTextBox = new System.Windows.Forms.TextBox();
            this.leftLetterTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.StrikeButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rightLetterTextBox
            // 
            this.rightLetterTextBox.Location = new System.Drawing.Point(258, 180);
            this.rightLetterTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rightLetterTextBox.Name = "rightLetterTextBox";
            this.rightLetterTextBox.Size = new System.Drawing.Size(160, 27);
            this.rightLetterTextBox.TabIndex = 13;
            // 
            // leftLetterTextBox
            // 
            this.leftLetterTextBox.Location = new System.Drawing.Point(258, 83);
            this.leftLetterTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.leftLetterTextBox.Name = "leftLetterTextBox";
            this.leftLetterTextBox.Size = new System.Drawing.Size(160, 27);
            this.leftLetterTextBox.TabIndex = 11;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(378, 291);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(124, 66);
            this.submitButton.TabIndex = 15;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // StrikeButton
            // 
            this.StrikeButton.Location = new System.Drawing.Point(198, 291);
            this.StrikeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StrikeButton.Name = "StrikeButton";
            this.StrikeButton.Size = new System.Drawing.Size(124, 66);
            this.StrikeButton.TabIndex = 17;
            this.StrikeButton.Text = "Strike";
            this.StrikeButton.UseVisualStyleBackColor = true;
            this.StrikeButton.Click += new System.EventHandler(this.StrikeButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(20, 291);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(124, 66);
            this.backButton.TabIndex = 16;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Right Letter:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Left Letter:";
            // 
            // FastMathStage1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 371);
            this.Controls.Add(this.rightLetterTextBox);
            this.Controls.Add(this.leftLetterTextBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.StrikeButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FastMathStage1Form";
            this.Text = "KTANE Bot by Hawker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox rightLetterTextBox;
        private TextBox leftLetterTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button StrikeButton;
        private System.Windows.Forms.Button backButton;
        private Label label2;
        private Label label1;
    }
}