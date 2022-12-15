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
            lettersTextBox.Text = "";
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
            string letters = lettersTextBox.Text.ToUpper();

            if (letters.Length != 2)
            {
                ShowErrorMessage("Text boxes can only have 2 letters");
                return;
            }

            foreach (char c in letters)
            {
                if (!Char.IsLetter(c))
                {
                    ShowErrorMessage("Text boxes can only contain letters");
                    return;
                }
            }

            PrintHeader();

            FastMath module = new FastMath(Bomb, LogFileWriter);

            module.Solve(letters[0], letters[1]);

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
    }
}
