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
    /// Purpose: Gets information needed to solve the memory module
    /// </summary>
    public partial class MemoryOtherStageForm : MultiStageModuleForm
    {
        MemoryStage1Form firstStage;
        Memory module;
        int stage;

        public MemoryOtherStageForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm,
            Memory module,
            MemoryStage1Form firstStage
        ) : base(bomb, logFileWriter, moduleSelectionForm, firstStage, "Memory", false)
        {
            InitializeComponent();
            UpdateForm(2);
            this.firstStage = firstStage;
            this.module = module;
        }

        public void UpdateForm(int stage)
        {
            displayTextBox.Text = "";
            numberTextBox.Text = "";
            this.stage = stage;
            stageLabel.Text = $"Stage {stage}";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            PrintDebugLine($"User reverted back to Stage {stage - 1}");
            if (stage == 2)
            {
                this.Hide();

                firstStage.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);

                firstStage.Show();
            }
            else
            {
                UpdateForm(stage - 1);
            }
        }

        private void moduleSelectionButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //display can only be 1 - 4
            int display;

            try
            {
                display = int.Parse(displayTextBox.Text);
            }
            catch
            {
                ShowErrorMessage("Display can only be 1 - 4");
                return;
            }

            if (display <= 0 || display >= 5)
            {
                ShowErrorMessage("Display can only be 1 - 4");
                return;
            }

            int num1;
            int num2;
            int num3;
            int num4;

            int totalNumber;

            if (numberTextBox.Text.Length != 4)
            {
                ShowErrorMessage("The second textbox can only hold 4 numbers");
                return;
            }

            try
            {
                totalNumber = int.Parse(numberTextBox.Text);
            }
            catch
            {
                ShowErrorMessage("The second textbox can only hold 4 numbers");
                return;
            }

            num4 = totalNumber % 10;

            totalNumber /= 10;

            num3 = totalNumber % 10;

            totalNumber /= 10;

            num2 = totalNumber % 10;

            totalNumber /= 10;

            num1 = totalNumber % 10;

            if (!(ValidNumber(num4) || ValidNumber(num3) || ValidNumber(num1) || ValidNumber(num2)))
            {
                ShowErrorMessage("The second textbox can only hold 4 numbers");
                return;
            }

            if (
                num1 == num2
                || num1 == num3
                || num1 == num4
                || num2 == num3
                || num2 == num4
                || num3 == num4
            )
            {
                ShowErrorMessage("Can't have duplicate messages");
                return;
            }

            module.Solve(stage, display, num1, num2, num3, num4);

            if (stage == 5)
            {
                this.Hide();

                firstStage.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                firstStage.Show();
            }
            else
            {
                UpdateForm(stage + 1);
            }
        }

        private bool ValidNumber(int num)
        {
            switch (num)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return true;

                default:
                    return false;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            firstStage.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            ResetModule();
        }
    }
}
