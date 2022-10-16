using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_KTANE_Solver
{
    public partial class FastMathStage1Form : ModuleForm
    {
        public FastMathStage1Form(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Fast Math", false)
        {
            InitializeComponent();
        }

        public void UpdateForm()
        {
            leftLetterTextBox.Text = "";
            rightLetterTextBox.Text = "";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void StrikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string left = leftLetterTextBox.Text.ToUpper();
            string right = rightLetterTextBox.Text.ToUpper();

            if (left.Length != 1 || right.Length != 1)
            {
                ShowErrorMessage("Text boxes can only have 1 letter");
                return;
            }

            if (left[0] < 65 || left[0] > 90 || right[0] < 65 || right[0] > 90)
            {
                ShowErrorMessage("Text boxes can only contain letters");
                return;
            }

            PrintHeader();

            FastMath module = new FastMath(Bomb, LogFileWriter);

            module.Solve(left[0], right[0]);

            FastMathOtherStageForm stage2 = new FastMathOtherStageForm(
                Bomb,
                LogFileWriter,
                ModuleSelectionForm,
                this,
                module
            );
            this.Hide();
            stage2.Show();
        }

        private void rightLetterTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void leftLetterTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
