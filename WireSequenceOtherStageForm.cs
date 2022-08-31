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
    /// Purpose: Gets information needed to solve the wire sequence module
    /// </summary>
    public partial class WireSequenceOtherStageForm : MultiStageModuleForm
    {
        int stage;
        WireSequence module;
        WireSequenceStage1Form firstStage;
        int firstWireIndex;
        int secondWireIndex;
        int thirdWireIndex;

        public WireSequenceOtherStageForm(
            WireSequence module,
            WireSequenceStage1Form firstStage,
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, firstStage, "Wire Sequence", false)
        {
            InitializeComponent();

            this.firstStage = firstStage;
            this.module = module;

            UpdateForm(2, bomb, logFileWriter, moduleSelectionForm);
        }

        public void UpdateForm(
            int stage,
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            this.stage = stage;

            firstWireIndex = (stage - 1) * 3 + 1;
            secondWireIndex = firstWireIndex + 1;
            thirdWireIndex = firstWireIndex + 2;

            wire1Label.Text = $"Wire {firstWireIndex}:";
            wire2Label.Text = $"Wire {secondWireIndex}:";
            wire3Label.Text = $"Wire {thirdWireIndex}:";

            stageLabel.Text = "Stage " + stage;

            UpdateColorComboBox(wire1ColorComboBox);
            UpdateColorComboBox(wire2ColorComboBox);
            UpdateColorComboBox(wire3ColorComboBox);

            UpdateLetterComboBox(wire1LetterComboBox);
            UpdateLetterComboBox(wire2LetterComboBox);
            UpdateLetterComboBox(wire3LetterComboBox);

            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);
        }

        private void UpdateColorComboBox(ComboBox comboBox)
        {
            String[] color = { "", "Black", "Blue", "Red" };

            comboBox.Items.Clear();
            comboBox.Items.AddRange(color);
            comboBox.Text = color[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void UpdateLetterComboBox(ComboBox comboBox)
        {
            String[] letter = { "", "A", "B", "C" };

            comboBox.Items.Clear();
            comboBox.Items.AddRange(letter);
            comboBox.Text = letter[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            firstStage.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            ResetModule();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (stage == 2)
            {
                firstStage.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                ResetModule();
            }
            else
            {
                UpdateForm(stage - 1, Bomb, LogFileWriter, ModuleSelectionForm);
            }
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            String answer = "";

            PrintDebugLine($"Stage {stage}\n");

            int wireNum1 = (stage - 1) * 3 + 1;
            int wireNum2 = (stage - 1) * 3 + 2;
            int wireNum3 = (stage - 1) * 3 + 3;

            if (wire1ColorComboBox.Text != "" && wire1LetterComboBox.Text != "")
            {
                answer +=
                    $"{firstWireIndex}. {module.Solve(wireNum1, wire1ColorComboBox.Text, wire1LetterComboBox.Text[0])}";
            }

            if (wire2ColorComboBox.Text != "" && wire2LetterComboBox.Text != "")
            {
                answer +=
                    $"\n{secondWireIndex}. {module.Solve(wireNum2, wire2ColorComboBox.Text, wire2LetterComboBox.Text[0])}";
            }

            if (wire3ColorComboBox.Text != "" && wire3LetterComboBox.Text != "")
            {
                answer +=
                    $"\n{thirdWireIndex}. {module.Solve(wireNum3, wire3ColorComboBox.Text, wire3LetterComboBox.Text[0])}";
            }

            ShowAnswer(answer);

            UpdateForm(stage + 1, Bomb, LogFileWriter, ModuleSelectionForm);
        }
    }
}
