namespace New_KTANE_Solver
{
    partial class _3DMazeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.facingWallCheckBox = new System.Windows.Forms.CheckBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mazeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.strikeButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // facingWallCheckBox
            // 
            this.facingWallCheckBox.AutoSize = true;
            this.facingWallCheckBox.Location = new System.Drawing.Point(269, 547);
            this.facingWallCheckBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.facingWallCheckBox.Name = "facingWallCheckBox";
            this.facingWallCheckBox.Size = new System.Drawing.Size(106, 24);
            this.facingWallCheckBox.TabIndex = 19;
            this.facingWallCheckBox.Text = "Facing Wall";
            this.facingWallCheckBox.UseVisualStyleBackColor = true;
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(209, 475);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(219, 27);
            this.pathTextBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 399);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Find a straight path and tell what is there (blanks = ?)";
            // 
            // mazeTextBox
            // 
            this.mazeTextBox.Location = new System.Drawing.Point(209, 113);
            this.mazeTextBox.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.mazeTextBox.Name = "mazeTextBox";
            this.mazeTextBox.Size = new System.Drawing.Size(219, 27);
            this.mazeTextBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "What are the letters in the maze?";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(25, 624);
            this.backButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(125, 77);
            this.backButton.TabIndex = 14;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // strikeButton
            // 
            this.strikeButton.Location = new System.Drawing.Point(264, 624);
            this.strikeButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.strikeButton.Name = "strikeButton";
            this.strikeButton.Size = new System.Drawing.Size(125, 77);
            this.strikeButton.TabIndex = 13;
            this.strikeButton.Text = "Strike";
            this.strikeButton.UseVisualStyleBackColor = true;
            this.strikeButton.Click += new System.EventHandler(this.strikeButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(520, 624);
            this.submitButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(125, 77);
            this.submitButton.TabIndex = 12;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // _3DMazeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 720);
            this.Controls.Add(this.facingWallCheckBox);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mazeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.strikeButton);
            this.Controls.Add(this.submitButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "_3DMazeForm";
            this.Text = "KTANE Bot by Hawker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox facingWallCheckBox;
        private TextBox pathTextBox;
        private Label label2;
        private TextBox mazeTextBox;
        private Label label1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button strikeButton;
        private System.Windows.Forms.Button submitButton;
    }
}