namespace New_KTANE_Solver
{
    partial class CreationForm
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
            this.bottomRightComboBox = new System.Windows.Forms.ComboBox();
            this.upperRightComboBox = new System.Windows.Forms.ComboBox();
            this.bottomLeftComboBox = new System.Windows.Forms.ComboBox();
            this.upperLeftComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.weatherComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(484, 302);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(120, 54);
            this.submitButton.TabIndex = 17;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // strikeButton
            // 
            this.strikeButton.Location = new System.Drawing.Point(247, 302);
            this.strikeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.strikeButton.Name = "strikeButton";
            this.strikeButton.Size = new System.Drawing.Size(120, 54);
            this.strikeButton.TabIndex = 16;
            this.strikeButton.Text = "Stike";
            this.strikeButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(16, 302);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(120, 54);
            this.backButton.TabIndex = 15;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // bottomRightComboBox
            // 
            this.bottomRightComboBox.FormattingEnabled = true;
            this.bottomRightComboBox.Location = new System.Drawing.Point(425, 207);
            this.bottomRightComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bottomRightComboBox.Name = "bottomRightComboBox";
            this.bottomRightComboBox.Size = new System.Drawing.Size(131, 28);
            this.bottomRightComboBox.TabIndex = 14;
            // 
            // upperRightComboBox
            // 
            this.upperRightComboBox.FormattingEnabled = true;
            this.upperRightComboBox.Location = new System.Drawing.Point(425, 116);
            this.upperRightComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upperRightComboBox.Name = "upperRightComboBox";
            this.upperRightComboBox.Size = new System.Drawing.Size(131, 28);
            this.upperRightComboBox.TabIndex = 13;
            // 
            // bottomLeftComboBox
            // 
            this.bottomLeftComboBox.FormattingEnabled = true;
            this.bottomLeftComboBox.Location = new System.Drawing.Point(55, 224);
            this.bottomLeftComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bottomLeftComboBox.Name = "bottomLeftComboBox";
            this.bottomLeftComboBox.Size = new System.Drawing.Size(131, 28);
            this.bottomLeftComboBox.TabIndex = 12;
            // 
            // upperLeftComboBox
            // 
            this.upperLeftComboBox.FormattingEnabled = true;
            this.upperLeftComboBox.Location = new System.Drawing.Point(55, 116);
            this.upperLeftComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upperLeftComboBox.Name = "upperLeftComboBox";
            this.upperLeftComboBox.Size = new System.Drawing.Size(131, 28);
            this.upperLeftComboBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Starting Weather:";
            // 
            // weatherComboBox
            // 
            this.weatherComboBox.FormattingEnabled = true;
            this.weatherComboBox.Location = new System.Drawing.Point(225, 54);
            this.weatherComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.weatherComboBox.Name = "weatherComboBox";
            this.weatherComboBox.Size = new System.Drawing.Size(160, 28);
            this.weatherComboBox.TabIndex = 9;
            // 
            // CreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 372);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.strikeButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.bottomRightComboBox);
            this.Controls.Add(this.upperRightComboBox);
            this.Controls.Add(this.bottomLeftComboBox);
            this.Controls.Add(this.upperLeftComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.weatherComboBox);
            this.Name = "CreationForm";
            this.Text = "CreationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button strikeButton;
        private System.Windows.Forms.Button backButton;
        private ComboBox bottomRightComboBox;
        private ComboBox upperRightComboBox;
        private ComboBox bottomLeftComboBox;
        private ComboBox upperLeftComboBox;
        private Label label1;
        private ComboBox weatherComboBox;
    }
}