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
    /// Purpose: Gets information needed to solve the color math module
    /// </summary>

    public partial class ColorMathForm : ModuleForm
    {
        public ColorMathForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Color Math", false)
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

            UpdateLeftComboBox(leftComboBox1);
            UpdateLeftComboBox(leftComboBox2);
            UpdateLeftComboBox(leftComboBox3);
            UpdateLeftComboBox(leftComboBox4);

            UpdateRightComboBox(rightComboBox1);
            UpdateRightComboBox(rightComboBox2);
            UpdateRightComboBox(rightComboBox3);
            UpdateRightComboBox(rightComboBox4);

            letterTextBox.Text = "";
        }

        private void UpdateLeftComboBox(ComboBox comboBox)
        {
            String[] colors = new String[]
            {
                "Black",
                "Blue",
                "Gray",
                "Green",
                "Magenta",
                "Orange",
                "Purple",
                "Red",
                "White",
                "Yellow"
            };

            comboBox.Items.Clear();
            comboBox.Items.AddRange(colors);
            comboBox.Text = colors[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void UpdateRightComboBox(ComboBox comboBox)
        {
            String[] colors = new String[]
            {
                "",
                "Black",
                "Blue",
                "Gray",
                "Green",
                "Magenta",
                "Orange",
                "Purple",
                "Red",
                "White",
                "Yellow"
            };

            comboBox.Items.Clear();
            comboBox.Items.AddRange(colors);
            comboBox.Text = colors[0];
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
            Color left1;
            Color left2;
            Color left3;
            Color left4;

            Color right1 = Color.Red;
            Color right2 = Color.Red;
            Color right3 = Color.Red;
            Color right4 = Color.Red;

            //if at least one, but not all are filled, throw an error
            int rightFilled = RightTextBoxFilled();

            if (rightFilled != 0 && rightFilled != 4)
            {
                ShowErrorMessage("Either all or none of the right text boxes must be filled");
                return;
            }

            left1 = (Color)Enum.Parse(typeof(Color), leftComboBox1.Text);
            left2 = (Color)Enum.Parse(typeof(Color), leftComboBox2.Text);
            left3 = (Color)Enum.Parse(typeof(Color), leftComboBox3.Text);
            left4 = (Color)Enum.Parse(typeof(Color), leftComboBox4.Text);

            //make sure that the letter text box only has a letter

            if (letterTextBox.Text.Length != 1)
            {
                ShowErrorMessage("Letter text box can only have 1 letter");
                return;
            }

            if (
                !(
                    (letterTextBox.Text[0] >= 65 && letterTextBox.Text[0] <= 90)
                    || (letterTextBox.Text[0] >= 97 && letterTextBox.Text[0] <= 122)
                )
            )
            {
                ShowErrorMessage("Letter text box can only have 1 letter");
                return;
            }

            //capitalize letter
            char letter = letterTextBox.Text.ToUpper()[0];

            //if not all of the right is filled, assume that the letter is red

            bool filled = rightFilled == 4;

            if (filled)
            {
                right1 = (Color)Enum.Parse(typeof(Color), rightComboBox1.Text);
                right2 = (Color)Enum.Parse(typeof(Color), rightComboBox2.Text);
                right3 = (Color)Enum.Parse(typeof(Color), rightComboBox3.Text);
                right4 = (Color)Enum.Parse(typeof(Color), rightComboBox4.Text);
            }

            ColorMath module = new ColorMath(
                new Color[] { left1, left2, left3, left4 },
                new Color[] { right1, right2, right3, right4 },
                letter,
                Bomb,
                LogFileWriter
            );
            PrintHeader();
            module.Solve(!filled);
            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }

        /// <summary>
        /// tells how many of the right text boxes are filled
        /// </summary>
        /// <returns></returns>
        private int RightTextBoxFilled()
        {
            int num = 0;

            if (rightComboBox1.Text != "")
                num++;

            if (rightComboBox2.Text != "")
                num++;

            if (rightComboBox3.Text != "")
                num++;

            if (rightComboBox4.Text != "")
                num++;

            return num;
        }
    }
}
