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
    /// Date: 3/6/21
    /// Purpose: Gets the information needed to solve the Logic module
    /// </summary>
    public partial class LogicForm : ModuleForm
    {
        //the logic module
        private Logic logicModule;

        /// <summary>
        /// Creates a form that will get the information to solve the logic module
        /// </summary>
        /// <param name="bomb">where the edgework will come from</param>
        /// <param name="moduleSelectionForm">the form used to get here</param>
        public LogicForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Logic", false)
        {
            InitializeComponent();
            UpdateForm(bomb, logFileWriter, moduleSelectionForm);
        }

        /// <summary>
        /// Sets up the form so it looks brand new
        /// </summary>
        /// <param name="bomb">where the edgework will come from</param>
        /// <param name="moduleSelectionForm">the form used to get here</param>
        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            //setting the prompt text for the textboxes
            SetPromptText(topFirstTextBox, "Top First Letter");
            SetPromptText(topSecondTextBox, "Top Second Letter");
            SetPromptText(topThirdTextBox, "Top Third Letter");
            SetPromptText(bottomFirstTextBox, "Bottom First Letter");
            SetPromptText(bottomSecondTextBox, "Bottom Second Letter");
            SetPromptText(bottomThirdTextBox, "Bottom Third Letter");

            //setting up the comboBoxes
            SetComboBox(topFirstOperationComboBox);
            SetComboBox(topSecondOperationComboBox);
            SetComboBox(bottomFirstOperationComboBox);
            SetComboBox(bottomSecondOperationComboBox);

            //all the checkBoxes have to be unchecked
            topFirstNotCheckBox.Checked = false;
            topSecondNotCheckBox.Checked = false;
            topThirdNotCheckBox.Checked = false;
            bottomFirstNotCheckBox.Checked = false;
            bottomSecondNotCheckBox.Checked = false;
            bottomThirdNotCheckBox.Checked = false;
            topFirstTwoCheckBox.Checked = false;
            bottomFirstTwoCheckBox.Checked = false;

            //set up tab order

            //checkboxes sholdn't be part of the tab order
            topFirstNotCheckBox.TabStop = false;
            topSecondNotCheckBox.TabStop = false;
            topThirdNotCheckBox.TabStop = false;
            topFirstTwoCheckBox.TabStop = false;

            bottomFirstNotCheckBox.TabStop = false;
            bottomSecondNotCheckBox.TabStop = false;
            bottomThirdNotCheckBox.TabStop = false;
            bottomFirstTwoCheckBox.TabStop = false;

            //combo boxes shouldbt be part of the tab order
            topFirstOperationComboBox.TabStop = false;
            topSecondOperationComboBox.TabStop = false;
            bottomFirstOperationComboBox.TabStop = false;
            bottomSecondOperationComboBox.TabStop = false;

            //no buttons besdies the submit button is part of the
            //tab order
            strikeButton.TabStop = false;
            backButton.TabStop = false;
        }

        /// <summary>
        /// Brings the player to the moudle selection form
        /// </summary>
        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        /// <summary>
        /// Sets up a combobox so the opeations are set up
        /// </summary>
        private void SetComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            String[] operations = new String[] { "∧", "∨", "	⊻", "|", "↓", "↔", "→", "←" };
            comboBox.Items.AddRange(operations);
            comboBox.Text = operations[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Sets up prompt text that will inside a text box
        /// </summary>
        /// <param name="textBox">the text box that will have the prompt text</param>
        /// <param name="text">the prompt text</param>
        private void SetPromptText(TextBox textBox, String text)
        {
            textBox.Text = text;
            textBox.ForeColor = Color.Gray;
        }

        /// <summary>
        /// Gets rid of text box when mouse
        /// enters the text box
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="promptText"></param>
        private void DeletePromptText(TextBox textBox, String promptText)
        {
            if (textBox.Text == promptText)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Deletes text box prompt if appropiate
        /// </summary>
        private void topFirstTextBox_Enter(object sender, EventArgs e)
        {
            DeletePromptText((TextBox)sender, "Top First Letter");
        }

        /// <summary>
        /// Deletes text box prompt if appropiate
        /// </summary>
        private void topSecondTextBox_Enter(object sender, EventArgs e)
        {
            DeletePromptText((TextBox)sender, "Top Second Letter");
        }

        /// <summary>
        /// Deletes text box prompt if appropiate
        /// </summary>
        private void topThirdTextBox_Enter(object sender, EventArgs e)
        {
            DeletePromptText((TextBox)sender, "Top Third Letter");
        }

        /// <summary>
        /// Deletes text box prompt if appropiate
        /// </summary>
        private void bottomFirstTextBox_Enter(object sender, EventArgs e)
        {
            DeletePromptText((TextBox)sender, "Bottom First Letter");
        }

        /// <summary>
        /// Deletes text box prompt if appropiate
        /// </summary>
        private void bottomSecondTextBox_Enter(object sender, EventArgs e)
        {
            DeletePromptText((TextBox)sender, "Bottom Second Letter");
        }

        /// <summary>
        /// Deletes text box prompt if appropiate
        /// </summary>
        private void bottomThirdTextBox_Enter(object sender, EventArgs e)
        {
            DeletePromptText((TextBox)sender, "Bottom Third Letter");
        }

        /// <summary>
        /// Brings back prompt text if appropriate
        /// </summary>
        private void topFirstTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "")
            {
                SetPromptText((TextBox)sender, "Top First Letter");
            }
        }

        /// <summary>
        /// Brings back prompt text if appropriate
        /// </summary>
        private void topSecondTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "")
            {
                SetPromptText((TextBox)sender, "Top Second Letter");
            }
        }

        /// <summary>
        /// Brings back prompt text if appropriate
        /// </summary>
        private void topThirdTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "")
            {
                SetPromptText((TextBox)sender, "Top Third Letter");
            }
        }

        /// <summary>
        /// Brings back prompt text if appropriate
        /// </summary>
        private void bottomFirstTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "")
            {
                SetPromptText((TextBox)sender, "Bottom First Letter");
            }
        }

        /// <summary>
        /// Brings back prompt text if appropriate
        /// </summary>
        private void bottomSecondTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "")
            {
                SetPromptText((TextBox)sender, "Bottom Second Letter");
            }
        }

        /// <summary>
        /// Brings back prompt text if appropriate
        /// </summary>
        private void bottomThirdTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "")
            {
                SetPromptText((TextBox)sender, "Bottom Third Letter");
            }
        }

        /// <summary>
        /// Shows logic answer if
        /// infomration given is appropriate
        /// </summary>
        private void submitButton_Click(object sender, EventArgs e)
        {
            String topFirst = topFirstTextBox.Text.ToUpper();
            String topSecond = topSecondTextBox.Text.ToUpper();
            String topThird = topThirdTextBox.Text.ToUpper();

            String bottomFirst = bottomFirstTextBox.Text.ToUpper();
            String bottomSecond = bottomSecondTextBox.Text.ToUpper();
            String bottomThird = bottomThirdTextBox.Text.ToUpper();

            //check to see if all text box length is one character long
            if (
                topFirst.Length != 1
                || topSecond.Length != 1
                || topThird.Length != 1
                || bottomFirst.Length != 1
                || bottomSecond.Length != 1
                || bottomThird.Length != 1
            )
            {
                ShowErrorMessage("Invalid Character Count");
                return;
            }

            char topFirstChar = topFirstTextBox.Text.ToUpper()[0];
            char topSecondChar = topSecondTextBox.Text.ToUpper()[0];
            char topThirdChar = topThirdTextBox.Text.ToUpper()[0];

            char bottomFirstChar = bottomFirstTextBox.Text.ToUpper()[0];
            char bottomSecondChar = bottomSecondTextBox.Text.ToUpper()[0];
            char bottomThirdChar = bottomThirdTextBox.Text.ToUpper()[0];

            //checks to see if character is illegal
            if (
                !(
                    IsLetter(topFirstChar)
                    && IsLetter(topSecondChar)
                    && IsLetter(topThirdChar)
                    && IsLetter(bottomFirstChar)
                    && IsLetter(bottomSecondChar)
                    && IsLetter(bottomThirdChar)
                )
            )
            {
                ShowErrorMessage("Invalid Character");
                return;
            }

            String topFirstOperation = topFirstOperationComboBox.Text;
            String topSecondOperation = topSecondOperationComboBox.Text;
            String bottomFirstOperation = bottomFirstOperationComboBox.Text;
            String bottomSecondOperation = bottomSecondOperationComboBox.Text;

            //getting rid of the tabs in the operatros
            char tab = '\u0009';

            topFirstOperation = topFirstOperation.Replace(tab.ToString(), "");
            topSecondOperation = topSecondOperation.Replace(tab.ToString(), "");
            bottomFirstOperation = bottomFirstOperation.Replace(tab.ToString(), "");
            bottomSecondOperation = bottomSecondOperation.Replace(tab.ToString(), "");

            PrintHeader();
            logicModule = new Logic(
                Bomb,
                topFirstNotCheckBox.Checked,
                topFirstChar,
                topSecondNotCheckBox.Checked,
                topSecondChar,
                topThirdNotCheckBox.Checked,
                topThirdChar,
                topFirstOperation,
                topSecondOperation,
                topFirstTwoCheckBox.Checked,
                bottomFirstNotCheckBox.Checked,
                bottomFirstChar,
                bottomSecondNotCheckBox.Checked,
                bottomSecondChar,
                bottomThirdNotCheckBox.Checked,
                bottomThirdChar,
                bottomFirstOperation,
                bottomSecondOperation,
                bottomFirstTwoCheckBox.Checked,
                LogFileWriter
            );

            logicModule.Solve();
            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }

        /// <summary>
        /// Tells if a character is a letter
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true if the character is a letter</returns>
        private bool IsLetter(char character)
        {
            return character >= 65 && character <= 90;
        }

        /// <summary>
        /// Adds a stirke to the total
        /// </summary>
        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }
    }
}
