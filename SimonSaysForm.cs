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
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Gets information needed to solve the simon says module
    /// </summary>

    public partial class SimonSaysForm : ModuleForm
    {
        private SimonSaysOtherStageForm secondStage;

        public SimonSaysForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Simon Says", false)
        {
            InitializeComponent();
            UpdateForm(bomb, logFileWriter, moduleSelectionForm);
        }

        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            inputTextBox.Text = "";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            String input = inputTextBox.Text.ToUpper();

            //there can only be one char in the textbox
            if (input.Length != 1)
            {
                ShowErrorMessage("There can only be 1 character");
                return;
            }

            //textbox can only contain the character b, r, g, or y
            switch (input[0])
            {
                case 'B':
                case 'G':
                case 'R':
                case 'Y':
                    break;

                default:
                    ShowErrorMessage("Textbox can only contain the character b, r, g, or y");
                    return;
            }

            PrintHeader();

            SimonSays module = new SimonSays(Bomb, LogFileWriter);
            module.Solve(1, input[0]);

            this.Hide();

            if (secondStage == null)
            {
                secondStage = new SimonSaysOtherStageForm(
                    2,
                    this,
                    module,
                    Bomb,
                    LogFileWriter,
                    ModuleSelectionForm
                );
            }

            secondStage.UpdateForm(2, module, Bomb, LogFileWriter, ModuleSelectionForm);

            secondStage.Show();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }
    }
}
