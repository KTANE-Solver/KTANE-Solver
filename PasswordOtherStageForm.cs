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
    /// Purpose: Gets information needed to solve the password module
    /// </summary>

    public partial class PasswordOtherStageForm : MultiStageModuleForm
    {
        private int stage;
        private PasswordFirstStageForm firstStage;
        private List<char> previousLetters;
        private Password module;

        public PasswordOtherStageForm(int stage, List<char> previousLetters, PasswordFirstStageForm firstStage, Password module, Bomb bomb, StreamWriter logFileWriter, ModuleSelectionForm moduleSelectionForm)
            : base(bomb, logFileWriter, moduleSelectionForm, firstStage, "Password", false)
        {
            InitializeComponent();
            UpdateForm(stage, previousLetters, firstStage, module, bomb, logFileWriter, moduleSelectionForm);
        }

        public void UpdateForm(int stage, List<char> previousLetters, PasswordFirstStageForm firstStage, Password module, Bomb bomb, StreamWriter logFileWriter, ModuleSelectionForm moduleSelectionForm)
        {
            this.stage = stage;
            this.firstStage = firstStage;
            this.previousLetters = previousLetters;
            this.module = module;

            stageLabel.Text = "Stage " + stage;

            if (stage == 2)
            {
                rowLabel.Text = "Fourth Row";
            }

            else
            {
                rowLabel.Text = "Fifth Row";
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);
        }

        private void moduleSelectionButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
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

                for (int i = previousLetters.Count; i > previousLetters.Count - 6; i--)
                {
                    previousLetters.RemoveAt(previousLetters[i]);
                }

                UpdateForm(stage - 1, previousLetters, firstStage, module, Bomb, LogFileWriter, ModuleSelectionForm);
            }
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            String letter1 = textBox1.Text.ToUpper();
            String letter2 = textBox2.Text.ToUpper();
            String letter3 = textBox3.Text.ToUpper();
            String letter4 = textBox4.Text.ToUpper();
            String letter5 = textBox5.Text.ToUpper();
            String letter6 = textBox6.Text.ToUpper();


            //check to make sure each input is valid
            if (!(ContainsOneLetter(letter1) || ContainsOneLetter(letter2) || ContainsOneLetter(letter3) ||
                  ContainsOneLetter(letter4) || ContainsOneLetter(letter5) || ContainsOneLetter(letter6)))
            {
                ShowErrorMessage("Each text box must contain only 1 letter");
                return;
            }
            List<string> possibleAnswers;

            if (stage == 3)
            {
                module.FillRow(letter1[0], letter2[0], letter3[0], letter4[0], letter5[0], letter6[0], 5);

                possibleAnswers = module.Solve(5);

                if (possibleAnswers.Count == 0)
                {
                    ShowErrorMessage("Unable to find answer");
                    return;
                }

                firstStage.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                ResetModule();
            }

            else
            {
                module.FillRow(letter1[0], letter2[0], letter3[0], letter4[0], letter5[0], letter6[0], 4);

                possibleAnswers = module.Solve(4);

                if (possibleAnswers.Count == 0)
                {
                    ShowErrorMessage("Unable to find answer");
                    return;
                }

                if (possibleAnswers.Count > 3)
                {
                    previousLetters.Add(textBox1.Text[0]);
                    previousLetters.Add(textBox2.Text[0]);
                    previousLetters.Add(textBox3.Text[0]);
                    previousLetters.Add(textBox4.Text[0]);
                    previousLetters.Add(textBox5.Text[0]);
                    previousLetters.Add(textBox6.Text[0]);

                    UpdateForm(stage + 1, previousLetters, firstStage, module, Bomb, LogFileWriter, ModuleSelectionForm);
                }

                else
                {
                    firstStage.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                    ResetModule();
                }
            }
        }

        /// <summary>
        /// Tells if the string is only 1 length
        /// </summary>
        private bool ContainsOneLetter(String str)
        {
            return str.Length == 1 && str[0] >= 65 && str[0] <= 90;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            firstStage.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            ResetModule();
        }
    }
}
