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
    public partial class SeaShellsForm : ModuleForm
    {
        public SeaShellsForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Sea Shells", false)
        {
            InitializeComponent();
            UpdateForm();
        }

        private void UpdateForm()
        {
            SetPhraseComboBox(firstPhraseComboBox);
            SetPhraseComboBox(secondPhraseComboBox);

            string[] arr = new string[] { "BURGLAR ALARM", "SHIH TZU", "SWITCH", "TOUCAN", };

            bigButtonComboBox.Items.Clear();
            bigButtonComboBox.Items.AddRange(arr);
            bigButtonComboBox.Text = arr[0];
            bigButtonComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SetPhraseComboBox(ComboBox combox)
        {
            string[] arr = new string[] { "SEA SELLS", "SEA SHELLS", "SHE SELLS", "SHE SHELLS" };

            combox.Items.Clear();
            combox.Items.AddRange(arr);
            combox.Text = arr[0];
            combox.DropDownStyle = ComboBoxStyle.DropDownList;
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
            SeaShells module = new SeaShells(
                Bomb,
                LogFileWriter,
                firstPhraseComboBox.Text,
                secondPhraseComboBox.Text,
                bigButtonComboBox.Text
            );
            module.Solve();
            UpdateForm();
        }
    }
}
