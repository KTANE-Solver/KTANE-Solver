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
    /// Purpose: Gets information needed to solve the light cycle module
    /// </summary>
    public partial class LightCycleForm : ModuleForm
    {
        public LightCycleForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Light Cycle", false)
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
            ColorComboBox(colorComboBox4);
            ColorComboBox(colorComboBox5);
        }

        private void ColorComboBox(ComboBox comboBox)
        {
            String[] colors = { "Blue", "Green", "Magenta", "Red", "White", "Yellow" };

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
            //no duplicate colors

            int blue = 0;
            int green = 0;
            int magenta = 0;
            int red = 0;
            int white = 0;
            int yellow = 0;

            string cycle =
                ""
                + colorComboBox1.Text[0]
                + colorComboBox2.Text[0]
                + colorComboBox3.Text[0]
                + colorComboBox4.Text[0]
                + colorComboBox5.Text[0];

            foreach (char character in cycle)
            {
                switch (character)
                {
                    case 'B':
                        blue++;
                        break;

                    case 'G':
                        green++;
                        break;

                    case 'M':
                        magenta++;
                        break;

                    case 'R':
                        red++;
                        break;

                    case 'W':
                        white++;
                        break;

                    case 'Y':
                        yellow++;
                        break;
                }
            }

            if (blue > 1 || green > 1 || magenta > 1 || red > 1 || white > 1 || yellow > 1)
            {
                ShowErrorMessage("Can't have duplicate colors");
                return;
            }

            //find the missing letter

            if (blue == 0)
            {
                cycle += "B";
            }
            else if (green == 0)
            {
                cycle += "G";
            }
            else if (magenta == 0)
            {
                cycle += "M";
            }
            else if (red == 0)
            {
                cycle += "R";
            }
            else if (white == 0)
            {
                cycle += "W";
            }
            else
            {
                cycle += "Y";
            }

            PrintHeader();

            LightCycle module = new LightCycle(Bomb, LogFileWriter, cycle);
            module.Solve();
            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }
    }
}
