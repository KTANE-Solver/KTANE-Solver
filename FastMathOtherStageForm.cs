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
    public partial class FastMathOtherStageForm : ModuleForm
    {
        private int stage;
        private FastMathStage1Form stage1;
        private FastMath module;

        public FastMathOtherStageForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm,
            FastMathStage1Form stage1,
            FastMath module
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Fast Math", false)
        {
            InitializeComponent();
            UpdateForm(2);
            this.stage1 = stage1;
            this.module = module;
        }

        private void UpdateForm(int stage)
        {
            this.stage = stage;

            letterTextBox.Text = "";
        }

        private void moduleSelectionButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (stage == 2)
            {
                GoToStage1();
            }
            else
            {
                UpdateForm(stage - 1);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            GoToStage1();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string letters = letterTextBox.Text.ToUpper();

            if (letters.Length != 2)
            {
                ShowErrorMessage("Text box can only have 2 letters");
                return;
            }

            foreach(char c in letters)
            {
                if (letters[0] < 65 || letters[0] > 90)
                {
                    ShowErrorMessage("Text boxes can only contain letters");
                    return;
                }
            }


            module.Solve(letters[0], letters[1]);

            if (stage == 5)
            {
                GoToStage1();
            }
            else
            {
                UpdateForm(stage + 1);
            }
        }

        private void GoToStage1()
        {
            this.Hide();
            stage1.UpdateForm();
            stage1.Show();
        }
    }
}
