namespace New_KTANE_Solver
{
    partial class ShapeShiftWordForm
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
            this.rightTicketComboBox = new System.Windows.Forms.ComboBox();
            this.leftTicketComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // strikeButton
            // 
            this.strikeButton.Location = new System.Drawing.Point(229, 149);
            this.strikeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.strikeButton.Name = "strikeButton";
            this.strikeButton.Size = new System.Drawing.Size(100, 58);
            this.strikeButton.TabIndex = 22;
            this.strikeButton.Text = "Strike";
            this.strikeButton.UseVisualStyleBackColor = true;
            this.strikeButton.Click += new System.EventHandler(this.strikeButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(434, 149);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(100, 58);
            this.submitButton.TabIndex = 21;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(8, 149);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 58);
            this.backButton.TabIndex = 20;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // rightTicketComboBox
            // 
            this.rightTicketComboBox.FormattingEnabled = true;
            this.rightTicketComboBox.Location = new System.Drawing.Point(403, 52);
            this.rightTicketComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rightTicketComboBox.Name = "rightTicketComboBox";
            this.rightTicketComboBox.Size = new System.Drawing.Size(121, 28);
            this.rightTicketComboBox.TabIndex = 19;
            // 
            // leftTicketComboBox
            // 
            this.leftTicketComboBox.FormattingEnabled = true;
            this.leftTicketComboBox.Location = new System.Drawing.Point(101, 52);
            this.leftTicketComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.leftTicketComboBox.Name = "leftTicketComboBox";
            this.leftTicketComboBox.Size = new System.Drawing.Size(121, 28);
            this.leftTicketComboBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Right Side:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Left Side:";
            // 
            // ShapeShiftWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 221);
            this.Controls.Add(this.strikeButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.rightTicketComboBox);
            this.Controls.Add(this.leftTicketComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ShapeShiftWordForm";
            this.Text = "KTANE Bot by Hawker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button strikeButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button backButton;
        private ComboBox rightTicketComboBox;
        private ComboBox leftTicketComboBox;
        private Label label2;
        private Label label1;
    }
}