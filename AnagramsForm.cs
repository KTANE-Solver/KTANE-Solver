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
    public partial class AnagramsForm : ModuleForm
    {
        public AnagramsForm()
        {
            InitializeComponent();
        }

        public AnagramsForm(
            Bomb bomb,
            StreamWriter logFile,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFile, moduleSelectionForm, "Anagrams", false)
        {
            InitializeComponent();
            UpdateForm(bomb, logFile, moduleSelectionForm);
        }

        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFile,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFile, moduleSelectionForm);

            string[] words = new string[]
            {
                "ARMETS",
                "BARELY",
                "BARLEY",
                "BLEARY",
                "CALLER",
                "CELLAR",
                "CEREUS",
                "CERUSE",
                "DUSTER",
                "LOOPED",
                "MASTER",
                "MATERS",
                "MATRES",
                "POODLE",
                "POOLED",
                "RAMETS",
                "RASHES",
                "RECALL",
                "RECUSE",
                "RESCUE",
                "RUDEST",
                "RUSTED",
                "SEATED",
                "SEDATE",
                "SECURE",
                "SHARES",
                "SHEARS",
                "STREAM",
                "TAMERS",
                "TEASED"
            };

            wordComboBox.Items.Clear();
            wordComboBox.Items.AddRange(words);
            wordComboBox.Text = words[0];
            wordComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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
            Anagrams module = new Anagrams(Bomb, LogFileWriter);
            module.Solve(wordComboBox.Text, false);
            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }
    }
}
