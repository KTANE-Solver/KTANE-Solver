namespace New_KTANE_Solver
{
    partial class BulbForm
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
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.opaqueCheckBox = new System.Windows.Forms.CheckBox();
            this.litCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(429, 286);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(129, 62);
            this.submitButton.TabIndex = 13;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // strikeButton
            // 
            this.strikeButton.Location = new System.Drawing.Point(225, 286);
            this.strikeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.strikeButton.Name = "strikeButton";
            this.strikeButton.Size = new System.Drawing.Size(129, 62);
            this.strikeButton.TabIndex = 12;
            this.strikeButton.Text = "Strike";
            this.strikeButton.UseVisualStyleBackColor = true;
            this.strikeButton.Click += new System.EventHandler(this.strikeButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(20, 286);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(129, 62);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // colorComboBox
            // 
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Location = new System.Drawing.Point(239, 95);
            this.colorComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(160, 28);
            this.colorComboBox.TabIndex = 10;
            // 
            // opaqueCheckBox
            // 
            this.opaqueCheckBox.AutoSize = true;
            this.opaqueCheckBox.Location = new System.Drawing.Point(315, 193);
            this.opaqueCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.opaqueCheckBox.Name = "opaqueCheckBox";
            this.opaqueCheckBox.Size = new System.Drawing.Size(84, 24);
            this.opaqueCheckBox.TabIndex = 9;
            this.opaqueCheckBox.Text = "Opaque";
            this.opaqueCheckBox.UseVisualStyleBackColor = true;
            // 
            // litCheckBox
            // 
            this.litCheckBox.AutoSize = true;
            this.litCheckBox.Location = new System.Drawing.Point(155, 193);
            this.litCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.litCheckBox.Name = "litCheckBox";
            this.litCheckBox.Size = new System.Drawing.Size(47, 24);
            this.litCheckBox.TabIndex = 8;
            this.litCheckBox.Text = "Lit";
            this.litCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Color:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BulbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 362);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.strikeButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.opaqueCheckBox);
            this.Controls.Add(this.litCheckBox);
            this.Controls.Add(this.label1);
            this.Name = "BulbForm";
            this.Text = "KTANE Bot by Hawker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button strikeButton;
        private System.Windows.Forms.Button backButton;
        private ComboBox colorComboBox;
        private CheckBox opaqueCheckBox;
        private CheckBox litCheckBox;
        private Label label1;
    }
}