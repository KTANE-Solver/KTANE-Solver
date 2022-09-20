namespace New_KTANE_Solver
{
    partial class BooleanVennDiagramForm
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
            this.operationChoiceBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.operationChoiceBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // strikeButton
            // 
            this.strikeButton.Location = new System.Drawing.Point(150, 258);
            this.strikeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.strikeButton.Name = "strikeButton";
            this.strikeButton.Size = new System.Drawing.Size(100, 48);
            this.strikeButton.TabIndex = 15;
            this.strikeButton.Text = "Strike";
            this.strikeButton.UseVisualStyleBackColor = true;
            this.strikeButton.Click += new System.EventHandler(this.strikeButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(284, 258);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(100, 48);
            this.submitButton.TabIndex = 14;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(19, 258);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 48);
            this.backButton.TabIndex = 13;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // operationChoiceBox2
            // 
            this.operationChoiceBox2.FormattingEnabled = true;
            this.operationChoiceBox2.Location = new System.Drawing.Point(162, 126);
            this.operationChoiceBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.operationChoiceBox2.Name = "operationChoiceBox2";
            this.operationChoiceBox2.Size = new System.Drawing.Size(160, 28);
            this.operationChoiceBox2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Operation 2:";
            // 
            // operationChoiceBox1
            // 
            this.operationChoiceBox1.FormattingEnabled = true;
            this.operationChoiceBox1.Location = new System.Drawing.Point(162, 56);
            this.operationChoiceBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.operationChoiceBox1.Name = "operationChoiceBox1";
            this.operationChoiceBox1.Size = new System.Drawing.Size(160, 28);
            this.operationChoiceBox1.TabIndex = 10;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(80, 193);
            this.checkBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(215, 24);
            this.checkBox.TabIndex = 9;
            this.checkBox.Text = "Parentheses around A and B";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Operation 1:";
            // 
            // BooleanVennDiagramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 320);
            this.Controls.Add(this.strikeButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.operationChoiceBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.operationChoiceBox1);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.label1);
            this.Name = "BooleanVennDiagramForm";
            this.Text = "KTANE Bot by Hawker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button strikeButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button backButton;
        private ComboBox operationChoiceBox2;
        private Label label2;
        private ComboBox operationChoiceBox1;
        private CheckBox checkBox;
        private Label label1;
    }
}