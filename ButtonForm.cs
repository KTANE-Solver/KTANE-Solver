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
    /// Purpose: Gets information needed to solve the button module
    /// </summary>

    public partial class ButtonForm : ModuleForm
    {
        public ButtonForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Button", false)
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
            String[] colors = { "Blue", "Red", "White", "Yellow" };
            String[] words = { "Abort", "Detonate", "Hold", "Press" };

            colorComboBox.Items.Clear();
            colorComboBox.Items.AddRange(colors);
            colorComboBox.Text = colors[0];
            colorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            wordComboBox.Items.Clear();
            wordComboBox.Items.AddRange(words);
            wordComboBox.Text = words[0];
            wordComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);
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
            PrintHeader();

            Button module = new Button(Bomb, LogFileWriter);

            Color color = GetColor(colorComboBox.Text);

            module.Solve(color, wordComboBox.Text);
        }

        private Color GetColor(string str)
        {
            if (str == "Blue")
            {
                return Color.Blue;
            }

            if (str == "Red")
            {
                return Color.Red;
            }

            if (str == "White")
            {
                return Color.White;
            }

            return Color.Yellow;
        }

        private void ButtonForm_Load(object sender, EventArgs e)
        {

        }

        private void colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void wordComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
