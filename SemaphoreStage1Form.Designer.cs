namespace New_KTANE_Solver
{
    partial class SemaphoreStage1Form
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
            this.secondFlagComboBox = new System.Windows.Forms.ComboBox();
            this.firstFlagComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.strikeButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // secondFlagComboBox
            // 
            this.secondFlagComboBox.FormattingEnabled = true;
            this.secondFlagComboBox.Location = new System.Drawing.Point(232, 170);
            this.secondFlagComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.secondFlagComboBox.Name = "secondFlagComboBox";
            this.secondFlagComboBox.Size = new System.Drawing.Size(160, 28);
            this.secondFlagComboBox.TabIndex = 14;
            // 
            // firstFlagComboBox
            // 
            this.firstFlagComboBox.FormattingEnabled = true;
            this.firstFlagComboBox.Location = new System.Drawing.Point(232, 56);
            this.firstFlagComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstFlagComboBox.Name = "firstFlagComboBox";
            this.firstFlagComboBox.Size = new System.Drawing.Size(160, 28);
            this.firstFlagComboBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 175);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Second Flag:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "First Flag:";
            // 
            // strikeButton
            // 
            this.strikeButton.Location = new System.Drawing.Point(204, 225);
            this.strikeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.strikeButton.Name = "strikeButton";
            this.strikeButton.Size = new System.Drawing.Size(119, 52);
            this.strikeButton.TabIndex = 10;
            this.strikeButton.Text = "Strike";
            this.strikeButton.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(395, 225);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(119, 52);
            this.submitButton.TabIndex = 9;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(19, 225);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(119, 52);
            this.backButton.TabIndex = 8;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // SemaphoreStage1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 291);
            this.Controls.Add(this.secondFlagComboBox);
            this.Controls.Add(this.firstFlagComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.strikeButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.backButton);
            this.Name = "SemaphoreStage1Form";
            this.Text = "SemaphoreStage1Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox secondFlagComboBox;
        private ComboBox firstFlagComboBox;
        private Label label2;
        private Label label1;
        private System.Windows.Forms.Button strikeButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button backButton;
    }
}