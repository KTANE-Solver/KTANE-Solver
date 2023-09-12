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
    /// Purpose: Gets information needed to solve the fizzbuzz module
    /// </summary>

    public partial class FizzBuzzForm : ModuleForm
    {
        public FizzBuzzForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "FizzBuzz", false)
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
            ColorComboBox(colorComboBox1);
            ColorComboBox(colorComboBox2);
            ColorComboBox(colorComboBox3);

            numberTextBox1.Text = "";
            numberTextBox2.Text = "";
            numberTextBox3.Text = "";
        }

        private void ColorComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            String[] colors = { "Blue", "Green", "Red", "White", "Yellow" };

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
            string[] numbers = new string[] { numberTextBox1.Text , numberTextBox2.Text , numberTextBox3.Text };

            for (int i = 0; i < 3; i++)
            {
                if (numbers[i].Length != 7)
                {
                    ShowErrorMessage($"Text box {i + 1} needs 7 digits");
                    return;
                }

                try
                {
                    int.Parse(numbers[i]);
                }

                catch
                {
                    ShowErrorMessage($"Text box {i + 1} can only contain numbers");
                    return;
                }
            }

            PrintHeader();

            FizzBuzz module = new FizzBuzz(
                colorComboBox1.Text,
                numbers[0],
                colorComboBox2.Text,
                numbers[1],
                colorComboBox3.Text,
                numbers[2],
                Bomb,
                LogFileWriter
            );
            module.Solve(false);
            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }
    }
}
