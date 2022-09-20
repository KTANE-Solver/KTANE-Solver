namespace New_KTANE_Solver
{
    partial class SeaShellsForm
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
            this.strikeButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.bigButtonComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.secondPhraseComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.firstPhraseComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // strikeButton
            // 
            this.strikeButton.Location = new System.Drawing.Point(248, 269);
            this.strikeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.strikeButton.Name = "strikeButton";
            this.strikeButton.Size = new System.Drawing.Size(113, 55);
            this.strikeButton.TabIndex = 17;
            this.strikeButton.Text = "Strike";
            this.strikeButton.UseVisualStyleBackColor = true;
            this.strikeButton.Click += new System.EventHandler(this.strikeButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(481, 269);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(113, 55);
            this.submitButton.TabIndex = 16;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(20, 269);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(113, 55);
            this.backButton.TabIndex = 15;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bigButtonComboBox
            // 
            this.bigButtonComboBox.FormattingEnabled = true;
            this.bigButtonComboBox.Location = new System.Drawing.Point(269, 178);
            this.bigButtonComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bigButtonComboBox.Name = "bigButtonComboBox";
            this.bigButtonComboBox.Size = new System.Drawing.Size(160, 28);
            this.bigButtonComboBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 182);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Big Button: ";
            // 
            // secondPhraseComboBox
            // 
            this.secondPhraseComboBox.FormattingEnabled = true;
            this.secondPhraseComboBox.Location = new System.Drawing.Point(269, 109);
            this.secondPhraseComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.secondPhraseComboBox.Name = "secondPhraseComboBox";
            this.secondPhraseComboBox.Size = new System.Drawing.Size(160, 28);
            this.secondPhraseComboBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Second Phrase: ";
            // 
            // firstPhraseComboBox
            // 
            this.firstPhraseComboBox.FormattingEnabled = true;
            this.firstPhraseComboBox.Location = new System.Drawing.Point(269, 39);
            this.firstPhraseComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstPhraseComboBox.Name = "firstPhraseComboBox";
            this.firstPhraseComboBox.Size = new System.Drawing.Size(160, 28);
            this.firstPhraseComboBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "First Phrase: ";
            // 
            // SeaShellsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 338);
            this.Controls.Add(this.strikeButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.bigButtonComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.secondPhraseComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstPhraseComboBox);
            this.Controls.Add(this.label1);
            this.Name = "SeaShellsForm";
            this.Text = "KTANE Bot by Hawker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button strikeButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button backButton;
        private ComboBox bigButtonComboBox;
        private Label label3;
        private ComboBox secondPhraseComboBox;
        private Label label2;
        private ComboBox firstPhraseComboBox;
        private Label label1;
    }
}