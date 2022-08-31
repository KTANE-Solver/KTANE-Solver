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
    /// Purpose: Gets information needed to solve the Bulb module
    /// </summary>

    public partial class BulbForm : ModuleForm
    {
        public BulbForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm,
            string name
        ) : base(bomb, logFileWriter, moduleSelectionForm, name, false)
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
            String[] colors = { "Blue", "Green", "Purple", "Red", "White", "Yellow" };

            colorComboBox.Items.Clear();
            colorComboBox.Items.AddRange(colors);
            colorComboBox.Text = colors[0];
            colorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            opaqueCheckBox.Checked = false;
            litCheckBox.Checked = false;

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

            Bulb module = new Bulb(
                Bomb,
                LogFileWriter,
                litCheckBox.Checked,
                opaqueCheckBox.Checked,
                colorComboBox.Text
            );
            module.Solve();

            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }
    }
}
