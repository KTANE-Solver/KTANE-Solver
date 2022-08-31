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
    public partial class WireSequenceStage1Form : ModuleForm
    {
        public WireSequenceStage1Form(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Wire Sequence", false)
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

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            WireSequence module = new WireSequence(Bomb, LogFileWriter);

            String answer = "";

            PrintHeader();

            PrintDebugLine("Stage 1\n");

            if (wire1ColorComboBox.Text != "" && wire1LetterComboBox.Text != "")
            {
                answer +=
                    "1. " + module.Solve(1, wire1ColorComboBox.Text, wire1LetterComboBox.Text[0]);
            }

            if (wire2ColorComboBox.Text != "" && wire2LetterComboBox.Text != "")
            {
                answer +=
                    "\n2. " + module.Solve(2, wire2ColorComboBox.Text, wire2LetterComboBox.Text[0]);
            }

            if (wire3ColorComboBox.Text != "" && wire3LetterComboBox.Text != "")
            {
                answer +=
                    "\n3. " + module.Solve(3, wire3ColorComboBox.Text, wire3LetterComboBox.Text[0]);
            }

            ShowAnswer(answer);

            this.Hide();

            WireSequenceOtherStageForm otherStage = new WireSequenceOtherStageForm(
                module,
                this,
                Bomb,
                LogFileWriter,
                ModuleSelectionForm
            );

            otherStage.Show();
        }
    }
}
