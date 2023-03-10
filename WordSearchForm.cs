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
    /// Purpose: Gets information needed to solve the word search module
    /// </summary>

    public partial class WordSearchForm : ModuleForm
    {
        public WordSearchForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Word Search", false)
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

            topLeftTextBox.Text = "";
            bottomLeftTextBox.Text = "";
            topRightTextBox.Text = "";
            bottomRightTextBox.Text = "";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            String topLeft = topLeftTextBox.Text;
            String bottomLeft = bottomLeftTextBox.Text;
            String topRight = topRightTextBox.Text;
            String bottomRight = bottomRightTextBox.Text;

            //each textbox can only have 1 character
            if (
                topLeft.Length != 1
                || bottomLeft.Length != 1
                || topRight.Length != 1
                || bottomRight.Length != 1
            )
            {
                MessageBox.Show(
                    "Each text box must have only 1 character",
                    "Word Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            //each character can only be a letter
            if (
                !IsLetter(topLeft[0])
                || !IsLetter(bottomLeft[0])
                || !IsLetter(topRight[0])
                || !IsLetter(bottomRight[0])
            )
            {
                MessageBox.Show(
                    "Text boxes can only contain letters",
                    "Word Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            //if there are lower case letter, captailize them
            if (IsLowerCase(topLeft[0]))
                topLeft = topLeft.ToUpper();

            if (IsLowerCase(bottomLeft[0]))
                bottomLeft = bottomLeft.ToUpper();

            if (IsLowerCase(topRight[0]))
                topRight = topRight.ToUpper();

            if (IsLowerCase(bottomRight[0]))
                bottomRight = bottomRight.ToUpper();

            PrintHeader();

            WordSearch module = new WordSearch(
                Bomb,
                LogFileWriter,
                topLeft[0],
                topRight[0],
                bottomLeft[0],
                bottomRight[0]
            );
            module.Solve(false);
            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }

        /// <summary>
        /// tells if a character is a letter
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool IsLetter(char character)
        {
            return (character >= 65 && character <= 90) || (character >= 97 && character <= 122);
        }

        /// <summary>
        /// tells if a character is a lower case letter
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool IsLowerCase(char character)
        {
            return character >= 97 && character <= 122;
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }
    }
}
