namespace New_KTANE_Solver
{
    partial class PlateForm
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
            this.parellelCheckBox = new System.Windows.Forms.CheckBox();
            this.DviCheckBox = new System.Windows.Forms.CheckBox();
            this.serialCheckBox = new System.Windows.Forms.CheckBox();
            this.RcaCheckBox = new System.Windows.Forms.CheckBox();
            this.psCheckBox = new System.Windows.Forms.CheckBox();
            this.rjCheckBox = new System.Windows.Forms.CheckBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // parellelCheckBox
            // 
            this.parellelCheckBox.AutoSize = true;
            this.parellelCheckBox.Location = new System.Drawing.Point(203, 77);
            this.parellelCheckBox.Name = "parellelCheckBox";
            this.parellelCheckBox.Size = new System.Drawing.Size(64, 19);
            this.parellelCheckBox.TabIndex = 6;
            this.parellelCheckBox.Text = "Parallel";
            this.parellelCheckBox.UseVisualStyleBackColor = true;
            // 
            // DviCheckBox
            // 
            this.DviCheckBox.AutoSize = true;
            this.DviCheckBox.Location = new System.Drawing.Point(203, 154);
            this.DviCheckBox.Name = "DviCheckBox";
            this.DviCheckBox.Size = new System.Drawing.Size(44, 19);
            this.DviCheckBox.TabIndex = 7;
            this.DviCheckBox.Text = "DVI";
            this.DviCheckBox.UseVisualStyleBackColor = true;
            // 
            // serialCheckBox
            // 
            this.serialCheckBox.AutoSize = true;
            this.serialCheckBox.Location = new System.Drawing.Point(203, 113);
            this.serialCheckBox.Name = "serialCheckBox";
            this.serialCheckBox.Size = new System.Drawing.Size(54, 19);
            this.serialCheckBox.TabIndex = 8;
            this.serialCheckBox.Text = "Serial";
            this.serialCheckBox.UseVisualStyleBackColor = true;
            // 
            // RcaCheckBox
            // 
            this.RcaCheckBox.AutoSize = true;
            this.RcaCheckBox.Location = new System.Drawing.Point(203, 194);
            this.RcaCheckBox.Name = "RcaCheckBox";
            this.RcaCheckBox.Size = new System.Drawing.Size(49, 19);
            this.RcaCheckBox.TabIndex = 9;
            this.RcaCheckBox.Text = "RCA";
            this.RcaCheckBox.UseVisualStyleBackColor = true;
            // 
            // psCheckBox
            // 
            this.psCheckBox.AutoSize = true;
            this.psCheckBox.Location = new System.Drawing.Point(203, 237);
            this.psCheckBox.Name = "psCheckBox";
            this.psCheckBox.Size = new System.Drawing.Size(39, 19);
            this.psCheckBox.TabIndex = 10;
            this.psCheckBox.Text = "PS";
            this.psCheckBox.UseVisualStyleBackColor = true;
            // 
            // rjCheckBox
            // 
            this.rjCheckBox.AutoSize = true;
            this.rjCheckBox.Location = new System.Drawing.Point(203, 276);
            this.rjCheckBox.Name = "rjCheckBox";
            this.rjCheckBox.Size = new System.Drawing.Size(37, 19);
            this.rjCheckBox.TabIndex = 11;
            this.rjCheckBox.Text = "RJ";
            this.rjCheckBox.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(271, 307);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 29);
            this.submitButton.TabIndex = 12;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(100, 307);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 29);
            this.backButton.TabIndex = 13;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Plate # of #";
            // 
            // PlateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 348);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.rjCheckBox);
            this.Controls.Add(this.psCheckBox);
            this.Controls.Add(this.RcaCheckBox);
            this.Controls.Add(this.serialCheckBox);
            this.Controls.Add(this.DviCheckBox);
            this.Controls.Add(this.parellelCheckBox);
            this.Name = "PlateForm";
            this.Text = "PlateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox parellelCheckBox;
        private CheckBox DviCheckBox;
        private CheckBox serialCheckBox;
        private CheckBox RcaCheckBox;
        private CheckBox psCheckBox;
        private CheckBox rjCheckBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button backButton;
        private Label label1;
    }
}