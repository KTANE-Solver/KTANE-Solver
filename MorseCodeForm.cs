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
    /// Purpose: Gets information needed to solve the morse code module
    /// </summary>
    public partial class MorseCodeForm : ModuleForm
    {
        public MorseCodeForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Morse Code", false)
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
            wordComboBox.Items.Clear();

            String[] words = new string[]
            {
                "beats",
                "bistro",
                "bombs",
                "boxes",
                "break",
                "brick",
                "flick",
                "halls",
                "leaks",
                "shell",
                "slick",
                "steak",
                "sting",
                "strobe",
                "trick",
                "vector"
            };

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
            MorseCode module = new MorseCode(Bomb, LogFileWriter);

            module.Solve(wordComboBox.Text);
            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }
    }
}
