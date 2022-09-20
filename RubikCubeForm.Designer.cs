namespace New_KTANE_Solver
{
    partial class RubikCubeForm
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
            this.bottomComboBox = new System.Windows.Forms.ComboBox();
            this.rightComboBox = new System.Windows.Forms.ComboBox();
            this.frontComboBox = new System.Windows.Forms.ComboBox();
            this.leftComboBox = new System.Windows.Forms.ComboBox();
            this.topComboBox = new System.Windows.Forms.ComboBox();
            this.bottomFace = new System.Windows.Forms.Label();
            this.rightFace = new System.Windows.Forms.Label();
            this.frontFace = new System.Windows.Forms.Label();
            this.leftFace = new System.Windows.Forms.Label();
            this.topFace = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(509, 612);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(141, 66);
            this.submitButton.TabIndex = 25;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // strikeButton
            // 
            this.strikeButton.Location = new System.Drawing.Point(262, 612);
            this.strikeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.strikeButton.Name = "strikeButton";
            this.strikeButton.Size = new System.Drawing.Size(141, 66);
            this.strikeButton.TabIndex = 24;
            this.strikeButton.Text = "Strike";
            this.strikeButton.UseVisualStyleBackColor = true;
            this.strikeButton.Click += new System.EventHandler(this.strikeButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(13, 612);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(141, 66);
            this.backButton.TabIndex = 23;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bottomComboBox
            // 
            this.bottomComboBox.FormattingEnabled = true;
            this.bottomComboBox.Location = new System.Drawing.Point(373, 456);
            this.bottomComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bottomComboBox.Name = "bottomComboBox";
            this.bottomComboBox.Size = new System.Drawing.Size(160, 28);
            this.bottomComboBox.TabIndex = 22;
            // 
            // rightComboBox
            // 
            this.rightComboBox.FormattingEnabled = true;
            this.rightComboBox.Location = new System.Drawing.Point(373, 353);
            this.rightComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rightComboBox.Name = "rightComboBox";
            this.rightComboBox.Size = new System.Drawing.Size(160, 28);
            this.rightComboBox.TabIndex = 21;
            // 
            // frontComboBox
            // 
            this.frontComboBox.FormattingEnabled = true;
            this.frontComboBox.Location = new System.Drawing.Point(373, 258);
            this.frontComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.frontComboBox.Name = "frontComboBox";
            this.frontComboBox.Size = new System.Drawing.Size(160, 28);
            this.frontComboBox.TabIndex = 20;
            // 
            // leftComboBox
            // 
            this.leftComboBox.FormattingEnabled = true;
            this.leftComboBox.Location = new System.Drawing.Point(373, 152);
            this.leftComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.leftComboBox.Name = "leftComboBox";
            this.leftComboBox.Size = new System.Drawing.Size(160, 28);
            this.leftComboBox.TabIndex = 19;
            // 
            // topComboBox
            // 
            this.topComboBox.FormattingEnabled = true;
            this.topComboBox.Location = new System.Drawing.Point(373, 61);
            this.topComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.topComboBox.Name = "topComboBox";
            this.topComboBox.Size = new System.Drawing.Size(160, 28);
            this.topComboBox.TabIndex = 18;
            // 
            // bottomFace
            // 
            this.bottomFace.AutoSize = true;
            this.bottomFace.Location = new System.Drawing.Point(192, 461);
            this.bottomFace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bottomFace.Name = "bottomFace";
            this.bottomFace.Size = new System.Drawing.Size(95, 20);
            this.bottomFace.TabIndex = 17;
            this.bottomFace.Text = "Bottom Face:";
            // 
            // rightFace
            // 
            this.rightFace.AutoSize = true;
            this.rightFace.Location = new System.Drawing.Point(192, 358);
            this.rightFace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rightFace.Name = "rightFace";
            this.rightFace.Size = new System.Drawing.Size(80, 20);
            this.rightFace.TabIndex = 16;
            this.rightFace.Text = "Right Face:";
            // 
            // frontFace
            // 
            this.frontFace.AutoSize = true;
            this.frontFace.Location = new System.Drawing.Point(192, 262);
            this.frontFace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.frontFace.Name = "frontFace";
            this.frontFace.Size = new System.Drawing.Size(79, 20);
            this.frontFace.TabIndex = 15;
            this.frontFace.Text = "Front Face:";
            // 
            // leftFace
            // 
            this.leftFace.AutoSize = true;
            this.leftFace.Location = new System.Drawing.Point(192, 156);
            this.leftFace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.leftFace.Name = "leftFace";
            this.leftFace.Size = new System.Drawing.Size(70, 20);
            this.leftFace.TabIndex = 14;
            this.leftFace.Text = "Left Face:";
            // 
            // topFace
            // 
            this.topFace.AutoSize = true;
            this.topFace.Location = new System.Drawing.Point(192, 66);
            this.topFace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.topFace.Name = "topFace";
            this.topFace.Size = new System.Drawing.Size(70, 20);
            this.topFace.TabIndex = 13;
            this.topFace.Text = "Top Face:";
            // 
            // RubikCubeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 692);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.strikeButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.bottomComboBox);
            this.Controls.Add(this.rightComboBox);
            this.Controls.Add(this.frontComboBox);
            this.Controls.Add(this.leftComboBox);
            this.Controls.Add(this.topComboBox);
            this.Controls.Add(this.bottomFace);
            this.Controls.Add(this.rightFace);
            this.Controls.Add(this.frontFace);
            this.Controls.Add(this.leftFace);
            this.Controls.Add(this.topFace);
            this.Name = "RubikCubeForm";
            this.Text = "KTANE Bot by Hawker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button strikeButton;
        private System.Windows.Forms.Button backButton;
        private ComboBox bottomComboBox;
        private ComboBox rightComboBox;
        private ComboBox frontComboBox;
        private ComboBox leftComboBox;
        private ComboBox topComboBox;
        private Label bottomFace;
        private Label rightFace;
        private Label frontFace;
        private Label leftFace;
        private Label topFace;
    }
}