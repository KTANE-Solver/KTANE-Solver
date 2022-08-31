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
    public partial class ScrewForm : ModuleForm
    {
        List<ComboBox> list;

        public ScrewForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Screw", false)
        {
            InitializeComponent();

            list = new List<ComboBox>()
            {
                topLeftComboBox,
                topMidComboBox,
                topRightComboBox,
                bottomLeftComboBox,
                bottomMidComboBox,
                bottomRightComboBox
            };

            UpdateForm();
        }

        private void UpdateForm()
        {
            foreach (ComboBox comboBox in list)
            {
                string[] colors = new string[]
                {
                    "Blue",
                    "Green",
                    "Magenta",
                    "Red",
                    "White",
                    "Yellow"
                };

                comboBox.Items.Clear();

                comboBox.Items.AddRange(colors);

                comboBox.Text = colors[0];

                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
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
            if (!ValidInput())
            {
                ShowErrorMessage("Can't have duplicate colors");
                return;
            }

            Screw module = new Screw(Bomb, LogFileWriter, GetColorLocation());
            module.FindScrewLocations();

            for (int i = 1; i < 4; i++)
            {
                module.Solve(i, false);
            }

            UpdateForm();
        }

        private bool ValidInput()
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (list[i].Text == list[j].Text)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private List<Color> GetColorLocation()
        {
            List<Color> colorList = new List<Color>();
            foreach (ComboBox comboBox in list)
            {
                switch (comboBox.Text)
                {
                    case "Red":
                        colorList.Add(Color.Red);
                        break;

                    case "Blue":
                        colorList.Add(Color.Blue);
                        break;

                    case "Green":
                        colorList.Add(Color.Green);
                        break;

                    case "Magenta":
                        colorList.Add(Color.Magenta);
                        break;

                    case "Yellow":
                        colorList.Add(Color.Yellow);
                        break;

                    default:
                        colorList.Add(Color.White);
                        break;
                }
            }

            return colorList;
        }
    }
}
