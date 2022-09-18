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
    public partial class BooleanVennDiagramForm : ModuleForm
    {
        public BooleanVennDiagramForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Boolean Venn Diagram", false)
        {
            InitializeComponent();
            UpdateForm();
        }

        private void UpdateForm()
        {
            SetComboBox(operationChoiceBox1);
            SetComboBox(operationChoiceBox2);
            checkBox.Checked = false;
        }

        private void SetComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            String[] operations = new String[] { "∧", "∨", "⊻", "|", "↓", "↔", "→", "←" };
            comboBox.Items.AddRange(operations);
            comboBox.Text = operations[0];
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
            PrintHeader();
            BooleanVennDiagram module = new BooleanVennDiagram(
                operationChoiceBox1.Text,
                operationChoiceBox2.Text,
                checkBox.Checked,
                LogFileWriter
            );
            module.Solve(false);
            UpdateForm();
        }
    }
}
