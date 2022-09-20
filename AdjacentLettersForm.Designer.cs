namespace New_KTANE_Solver
{
    partial class AdjacentLettersForm
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
            this.submitButton = new System.Windows.Forms.Button();
            this.strikeButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.row3TextBox = new System.Windows.Forms.TextBox();
            this.row2TextBox = new System.Windows.Forms.TextBox();
            this.row1TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(429, 413);
            this.submitButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(125, 77);
            this.submitButton.TabIndex = 17;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // strikeButton
            // 
            this.strikeButton.Location = new System.Drawing.Point(232, 413);
            this.strikeButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.strikeButton.Name = "strikeButton";
            this.strikeButton.Size = new System.Drawing.Size(125, 77);
            this.strikeButton.TabIndex = 16;
            this.strikeButton.Text = "Strike";
            this.strikeButton.UseVisualStyleBackColor = true;
            this.strikeButton.Click += new System.EventHandler(this.strikeButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(25, 413);
            this.backButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(125, 77);
            this.backButton.TabIndex = 15;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // row3TextBox
            // 
            this.row3TextBox.Location = new System.Drawing.Point(246, 303);
            this.row3TextBox.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.row3TextBox.Name = "row3TextBox";
            this.row3TextBox.Size = new System.Drawing.Size(167, 27);
            this.row3TextBox.TabIndex = 14;
            // 
            // row2TextBox
            // 
            this.row2TextBox.Location = new System.Drawing.Point(246, 197);
            this.row2TextBox.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.row2TextBox.Name = "row2TextBox";
            this.row2TextBox.Size = new System.Drawing.Size(167, 27);
            this.row2TextBox.TabIndex = 13;
            // 
            // row1TextBox
            // 
            this.row1TextBox.Location = new System.Drawing.Point(246, 89);
            this.row1TextBox.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.row1TextBox.Name = "row1TextBox";
            this.row1TextBox.Size = new System.Drawing.Size(167, 27);
            this.row1TextBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 308);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Row 3:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 204);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Row 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Row 1:";
            // 
            // AdjacentLettersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 509);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.strikeButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.row3TextBox);
            this.Controls.Add(this.row2TextBox);
            this.Controls.Add(this.row1TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdjacentLettersForm";
            this.Text = "KTANE Bot by Hawker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button strikeButton;
        private System.Windows.Forms.Button backButton;
        private TextBox row3TextBox;
        private TextBox row2TextBox;
        private TextBox row1TextBox;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}