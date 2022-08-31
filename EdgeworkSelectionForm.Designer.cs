namespace New_KTANE_Solver
{
    partial class EdgeworkSelectionForm
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
            this.manualButton = new System.Windows.Forms.Button();
            this.automaticButton = new System.Windows.Forms.Button();
            this.promptLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // manualButton
            // 
            this.manualButton.Location = new System.Drawing.Point(253, 101);
            this.manualButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.manualButton.Name = "manualButton";
            this.manualButton.Size = new System.Drawing.Size(104, 51);
            this.manualButton.TabIndex = 5;
            this.manualButton.Text = "Manual";
            this.manualButton.UseVisualStyleBackColor = true;
            // 
            // automaticButton
            // 
            this.automaticButton.Location = new System.Drawing.Point(253, 42);
            this.automaticButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.automaticButton.Name = "automaticButton";
            this.automaticButton.Size = new System.Drawing.Size(104, 51);
            this.automaticButton.TabIndex = 4;
            this.automaticButton.Text = "Automatic";
            this.automaticButton.UseVisualStyleBackColor = true;
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Location = new System.Drawing.Point(17, 8);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(586, 20);
            this.promptLabel.TabIndex = 3;
            this.promptLabel.Text = "Would you like to manually input the edgework or use the information in Edgework." +
    "txt?";
            // 
            // EdgeworkSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 165);
            this.Controls.Add(this.manualButton);
            this.Controls.Add(this.automaticButton);
            this.Controls.Add(this.promptLabel);
            this.Name = "EdgeworkSelectionForm";
            this.Text = "EdgeworkSelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button manualButton;
        private System.Windows.Forms.Button automaticButton;
        private Label promptLabel;
    }
}