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
    /// Purpose: Gets information needed to solve the two bits module
    /// </summary>
    public partial class TwoBitsOtherStageForm : MultiStageModuleForm
    {
        int stage;
        TwoBits module;
        TwoBitsStage1Form stage1Form;

        public TwoBitsOtherStageForm(
            TwoBits module,
            TwoBitsStage1Form stage1Form,
            int stage,
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, stage1Form, "Two Bits", false)
        {
            InitializeComponent();
            UpdateForm(stage1Form, stage, bomb, logFileWriter, moduleSelectionForm);

            this.module = module;
        }

        public void UpdateForm(
            TwoBitsStage1Form stage1Form,
            int stage,
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            this.stage1Form = stage1Form;

            this.stage = stage;

            stageLabel.Text = "Stage " + stage;

            resultTextBox.Text = "";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (stage == 2)
            {
                stage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                ResetModule();
            }
            else
            {
                UpdateForm(stage1Form, stage - 1, Bomb, LogFileWriter, ModuleSelectionForm);
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
            int code;

            try
            {
                code = Int32.Parse(resultTextBox.Text);
            }
            catch
            {
                ShowErrorMessage("Text box can only hold numbers");
                return;
            }

            if (code < 0 && code > 99)
            {
                ShowErrorMessage("Text box can only hold numbers that are between 0 and 99");
                return;
            }

            module.Solve(stage, code);

            module = new TwoBits(Bomb, LogFileWriter);

            if (stage == 4)
            {
                this.Hide();
                stage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                stage1Form.Show();
            }
            else
            {
                UpdateForm(stage1Form, stage + 1, Bomb, LogFileWriter, ModuleSelectionForm);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            stage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            ResetModule();
        }
    }
}
