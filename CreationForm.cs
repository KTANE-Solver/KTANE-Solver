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
    public partial class CreationForm : ModuleForm
    {
        private Creation module;

        public CreationForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Creation", false)
        {
            InitializeComponent();
            UpdateForm();
        }

        public void UpdateForm()
        {
            UpdateElementComboBox(upperLeftComboBox);
            UpdateElementComboBox(upperRightComboBox);
            UpdateElementComboBox(bottomLeftComboBox);
            UpdateElementComboBox(bottomRightComboBox);

            String[] weather = new string[]
            {
                "Rain",
                "Wind",
                "Heat Wave",
                "Meteor Shower",
                "Clear"
            };

            weatherComboBox.Items.Clear();
            weatherComboBox.Items.AddRange(weather);
            weatherComboBox.Text = weather[0];
            weatherComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void UpdateElementComboBox(ComboBox comboBox)
        {
            String[] elements = new string[] { "Air", "Earth", "Fire", "Water", };

            comboBox.Items.Clear();
            comboBox.Items.AddRange(elements);
            comboBox.Text = elements[0];
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
            //make sure comboBoxes don't share element

            string upperLeft = upperLeftComboBox.Text;
            string upperRight = upperRightComboBox.Text;
            string lowerLeft = bottomLeftComboBox.Text;
            string lowerRight = bottomRightComboBox.Text;

            if (
                upperLeft == upperRight
                || upperLeft == lowerLeft
                || upperLeft == lowerRight
                || upperRight == lowerLeft
                || upperRight == lowerRight
                || lowerLeft == lowerRight
            )
            {
                ShowErrorMessage("Can't have duplicate elements");
                return;
            }

            string weather = weatherComboBox.Text.Replace(" ", String.Empty);

            Creation.Weather startingWeather = (Creation.Weather)
                Enum.Parse(typeof(Creation.Weather), weather);

            module = new Creation(
                Bomb,
                LogFileWriter,
                startingWeather,
                upperLeft,
                lowerLeft,
                upperRight,
                lowerRight
            );
            module.SetUpModule();
            module.Solve(startingWeather, 0);

            this.Hide();

            CreationOtherStageForm stage2 = new CreationOtherStageForm(
                Bomb,
                LogFileWriter,
                module,
                this,
                ModuleSelectionForm
            );

            stage2.Show();
        }
    }
}
