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
    public partial class _3DMazeStage2Form : MultiStageModuleForm
    {
        _3DMazeForm firstStageForm;

        private _3DMaze Module
        {
            get { return firstStageForm.Module; }
        }

        public _3DMazeStage2Form()
        {
            InitializeComponent();
        }

        public _3DMazeStage2Form(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm,
            _3DMazeForm firstStageForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, firstStageForm, "3D Maze", false)
        {
            InitializeComponent();

            UpdateForm(bomb, logFileWriter, moduleSelectionForm, firstStageForm);
        }

        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm,
            _3DMazeForm firstStageForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            string[] cardinals = new string[] { "North", "East", "South", "West" };

            cardinalComboBox.Items.Clear();
            cardinalComboBox.Items.AddRange(cardinals);
            cardinalComboBox.Text = cardinals[0];
            cardinalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            this.firstStageForm = firstStageForm;
        }

        private void moduleSelectionButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            firstStageForm.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            firstStageForm.Show();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //find the goal cardinal
            string goalCardinal = cardinalComboBox.Text.ToUpper();

            Module.MainCardinalGoal = goalCardinal;

            //find the goal node
            int row = Module.FindRow();

            int column = Module.FindColumn();

            Module.MainGoal = Module.Maze[row, column];

            PrintDebugLine($"Main Goal: [{row},{column}]");

            Module.UpdateGoal();

            PrintDebugLine($"Main Updated Goal: [{Module.MainGoal.Row},{Module.MainGoal.Colunm}]");
            PrintDebugLine($"Main Cardinal Direction: {Module.MainCardinalGoal}\n");

            PrintDebugLine(
                $"Secondary Goal: [{Module.SecondaryGoal.Row},{Module.SecondaryGoal.Colunm}]"
            );
            PrintDebugLine($"Secondary Cardinal Direction: {Module.SecondaryCardinalGoal}\n");

            Module.Solve(false);

            this.Hide();
            firstStageForm.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            firstStageForm.Show();
        }
    }
}
