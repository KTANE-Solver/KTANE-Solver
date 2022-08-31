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
    /// Purpose: Get information needed to solve Stage 1 of
    ///          "Who's on First"
    /// </summary>
    public partial class WhosOnFirstFirstStageForm : ModuleForm
    {
        //the form used for stage 2 and 3
        WhosOnFirstOtherStageForm whosOnFirstOtherStage;

        /// <summary>
        /// Creates the form that will Get information
        /// needed to solve Stage 1 of "Who's on First"
        /// </summary>
        /// <param name="moduleSelectionForm"></param>
        /// <param name="bomb"></param>
        /// <param name="logFileWriter"></param>
        public WhosOnFirstFirstStageForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Who's on First", false)
        {
            InitializeComponent();

            UpdateForm(bomb, logFileWriter, moduleSelectionForm);

            whosOnFirstOtherStage = new WhosOnFirstOtherStageForm(
                moduleSelectionForm,
                bomb,
                logFileWriter,
                this
            );
        }

        /// <summary>
        /// Restarts the form
        /// </summary>
        /// <param name="moduleSelectionForm"></param>
        /// <param name="bomb"></param>
        /// <param name="logFileWriter"></param>
        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            UpdateDisplay();

            UpdateButtonComboBox(topLeftComboBox);
            UpdateButtonComboBox(topRightComboBox);
            UpdateButtonComboBox(midLeftComboBox);
            UpdateButtonComboBox(midRightComboBox);
            UpdateButtonComboBox(bottomLeftComboBox);
            UpdateButtonComboBox(bottomRightComboBox);
        }

        /// <summary>
        /// Restarts the display comboBox
        /// </summary>
        private void UpdateDisplay()
        {
            String[] display = new string[]
            {
                "",
                "BLANK",
                "C",
                "CEE",
                "DISPLAY",
                "FIRST",
                "HOLD ON",
                "LEAD",
                "LED",
                "LEED",
                "NO",
                "NOTHING",
                "OKAY",
                "READ",
                "RED",
                "REED",
                "SAYS",
                "SEE",
                "THEIR",
                "THERE",
                "THEY ARE",
                "THEY'RE",
                "UR",
                "YES",
                "YOU",
                "YOU ARE",
                "YOU'RE",
                "YOUR"
            };

            displayComboBox.Items.Clear();

            displayComboBox.Items.AddRange(display);

            displayComboBox.Text = display[0];

            displayComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Restarts a button comboBox
        /// </summary>
        /// <param name="comboBox"></param>
        private void UpdateButtonComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            String[] items = new string[]
            {
                "BLANK",
                "DONE",
                "FIRST",
                "HOLD",
                "LEFT",
                "LIKE",
                "MIDDLE",
                "NEXT",
                "NO",
                "NOTHING",
                "OKAY",
                "PRESS",
                "READY",
                "RIGHT",
                "SURE",
                "U",
                "UH HUH",
                "UH UH",
                "UHHH",
                "UR",
                "WAIT",
                "WHAT",
                "WHAT?",
                "YES",
                "YOU ARE",
                "YOU",
                "YOU'RE",
                "YOUR"
            };

            comboBox.Items.AddRange(items);

            comboBox.Text = items[0];

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
            //make sure there are no duplicates words

            String topLeft = topLeftComboBox.Text;
            String midLeft = midLeftComboBox.Text;
            String bottomLeft = bottomLeftComboBox.Text;
            String topRight = topRightComboBox.Text;
            String midRight = midRightComboBox.Text;
            String bottomRight = bottomRightComboBox.Text;

            List<String> words = new List<string>()
            {
                topLeft,
                midLeft,
                bottomLeft,
                topRight,
                midRight,
                bottomRight
            };

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i == j)
                        continue;

                    if (words[i] == words[j])
                    {
                        ShowErrorMessage("Can't have duplicate words");
                        return;
                    }
                }
            }

            PrintHeader();
            WhosOnFirst module = new WhosOnFirst(
                1,
                displayComboBox.Text,
                topLeft,
                topRight,
                midLeft,
                midRight,
                bottomLeft,
                bottomRight,
                Bomb,
                LogFileWriter
            );
            module.Solve();

            this.Hide();

            whosOnFirstOtherStage.Show();
            whosOnFirstOtherStage.UpdateForm(2, ModuleSelectionForm, Bomb, LogFileWriter);
        }
    }
}
