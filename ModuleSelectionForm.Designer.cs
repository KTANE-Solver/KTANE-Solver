namespace New_KTANE_Solver
{
    partial class ModuleSelectionForm
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
            this.saveEdgeworkButton = new System.Windows.Forms.Button();
            this.checkEdgeworkButton = new System.Windows.Forms.Button();
            this.changeEdgeworkButton = new System.Windows.Forms.Button();
            this.moduleComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.AutoSize = true;
            this.submitButton.Location = new System.Drawing.Point(462, 128);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 43);
            this.submitButton.TabIndex = 9;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // saveEdgeworkButton
            // 
            this.saveEdgeworkButton.AutoSize = true;
            this.saveEdgeworkButton.Location = new System.Drawing.Point(324, 128);
            this.saveEdgeworkButton.Name = "saveEdgeworkButton";
            this.saveEdgeworkButton.Size = new System.Drawing.Size(124, 43);
            this.saveEdgeworkButton.TabIndex = 8;
            this.saveEdgeworkButton.Text = "Save Edgework";
            this.saveEdgeworkButton.UseVisualStyleBackColor = true;
            // 
            // checkEdgeworkButton
            // 
            this.checkEdgeworkButton.AutoSize = true;
            this.checkEdgeworkButton.Location = new System.Drawing.Point(178, 128);
            this.checkEdgeworkButton.Name = "checkEdgeworkButton";
            this.checkEdgeworkButton.Size = new System.Drawing.Size(132, 43);
            this.checkEdgeworkButton.TabIndex = 7;
            this.checkEdgeworkButton.Text = "Check Edgework";
            this.checkEdgeworkButton.UseVisualStyleBackColor = true;
            // 
            // changeEdgeworkButton
            // 
            this.changeEdgeworkButton.AutoSize = true;
            this.changeEdgeworkButton.Location = new System.Drawing.Point(23, 128);
            this.changeEdgeworkButton.Name = "changeEdgeworkButton";
            this.changeEdgeworkButton.Size = new System.Drawing.Size(140, 43);
            this.changeEdgeworkButton.TabIndex = 6;
            this.changeEdgeworkButton.Text = "Change Edgework";
            this.changeEdgeworkButton.UseVisualStyleBackColor = true;
            // 
            // moduleComboBox
            // 
            this.moduleComboBox.FormattingEnabled = true;
            this.moduleComboBox.Location = new System.Drawing.Point(162, 60);
            this.moduleComboBox.Name = "moduleComboBox";
            this.moduleComboBox.Size = new System.Drawing.Size(263, 28);
            this.moduleComboBox.TabIndex = 5;
            // 
            // ModuleSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 183);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.saveEdgeworkButton);
            this.Controls.Add(this.checkEdgeworkButton);
            this.Controls.Add(this.changeEdgeworkButton);
            this.Controls.Add(this.moduleComboBox);
            this.Name = "ModuleSelectionForm";
            this.Text = "ModuleSelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button saveEdgeworkButton;
        private System.Windows.Forms.Button checkEdgeworkButton;
        private System.Windows.Forms.Button changeEdgeworkButton;
        private ComboBox moduleComboBox;
    }
}