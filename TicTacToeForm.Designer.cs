namespace New_KTANE_Solver
{
    partial class TicTacToeForm
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
            this.symbolComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.strikeButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.middleRowTextBox = new System.Windows.Forms.TextBox();
            this.bottomRowTextBox = new System.Windows.Forms.TextBox();
            this.topRowTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // symbolComboBox
            // 
            this.symbolComboBox.FormattingEnabled = true;
            this.symbolComboBox.Location = new System.Drawing.Point(184, 45);
            this.symbolComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.symbolComboBox.Name = "symbolComboBox";
            this.symbolComboBox.Size = new System.Drawing.Size(132, 28);
            this.symbolComboBox.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Symbol:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 257);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Bottom Row:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 193);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Middle Row:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 127);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Top Row:";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(247, 336);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(108, 55);
            this.submitButton.TabIndex = 16;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // strikeButton
            // 
            this.strikeButton.Location = new System.Drawing.Point(131, 336);
            this.strikeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.strikeButton.Name = "strikeButton";
            this.strikeButton.Size = new System.Drawing.Size(108, 55);
            this.strikeButton.TabIndex = 15;
            this.strikeButton.Text = "Strike";
            this.strikeButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(15, 336);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(108, 55);
            this.backButton.TabIndex = 14;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // middleRowTextBox
            // 
            this.middleRowTextBox.Location = new System.Drawing.Point(184, 182);
            this.middleRowTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.middleRowTextBox.Name = "middleRowTextBox";
            this.middleRowTextBox.Size = new System.Drawing.Size(132, 27);
            this.middleRowTextBox.TabIndex = 13;
            // 
            // bottomRowTextBox
            // 
            this.bottomRowTextBox.Location = new System.Drawing.Point(184, 253);
            this.bottomRowTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bottomRowTextBox.Name = "bottomRowTextBox";
            this.bottomRowTextBox.Size = new System.Drawing.Size(132, 27);
            this.bottomRowTextBox.TabIndex = 12;
            // 
            // topRowTextBox
            // 
            this.topRowTextBox.Location = new System.Drawing.Point(184, 122);
            this.topRowTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.topRowTextBox.Name = "topRowTextBox";
            this.topRowTextBox.Size = new System.Drawing.Size(132, 27);
            this.topRowTextBox.TabIndex = 11;
            // 
            // TicTacToeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 405);
            this.Controls.Add(this.symbolComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.strikeButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.middleRowTextBox);
            this.Controls.Add(this.bottomRowTextBox);
            this.Controls.Add(this.topRowTextBox);
            this.Name = "TicTacToeForm";
            this.Text = "TicTacToeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox symbolComboBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button strikeButton;
        private System.Windows.Forms.Button backButton;
        private TextBox middleRowTextBox;
        private TextBox bottomRowTextBox;
        private TextBox topRowTextBox;
    }
}