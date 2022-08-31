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
    public partial class SemaphoreStage1Form : ModuleForm
    {
        public SemaphoreStage1Form(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Semaphore", false)
        {
            InitializeComponent();
            UpdateForm();
        }

        public void UpdateForm()
        {
            string[] firstItems = new string[] { "North/East", "North/North East" };

            firstFlagComboBox.Items.Clear();
            firstFlagComboBox.Items.AddRange(firstItems.ToArray());
            firstFlagComboBox.Text = firstItems[0];
            firstFlagComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            string[] direction = new string[]
            {
                "East",
                "North",
                "North East",
                "North West",
                "South",
                "South East",
                "South West",
                "West"
            };

            List<string> combinedDirection = new List<string>();

            for (int i = 0; i < direction.Length; i++)
            {
                for (int j = 0; j < direction.Length; j++)
                {
                    combinedDirection.Add(direction[i] + "/" + direction[j]);
                }
            }

            secondFlagComboBox.Items.Clear();
            secondFlagComboBox.Items.AddRange(combinedDirection.ToArray());
            secondFlagComboBox.Text = combinedDirection[0];
            secondFlagComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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
            Semaphore.Flag firstFlag = GetFlag(firstFlagComboBox.Text);

            Semaphore module = new Semaphore(Bomb, LogFileWriter, firstFlag);

            string answer = module.Solve(GetFlag(secondFlagComboBox.Text));

            if (answer == "Valid")
            {
                SemaphoreOtherStageForm form = new SemaphoreOtherStageForm(
                    Bomb,
                    LogFileWriter,
                    ModuleSelectionForm,
                    module,
                    this
                );
                this.Hide();
                form.Show();
            }
            else
            {
                UpdateForm();
            }
        }

        private Semaphore.Flag GetFlag(string str)
        {
            string[] arr = str.Split('/');

            return new Semaphore.Flag(GetFlagState(arr[0]), GetFlagState(arr[1]));
        }

        private Semaphore.FlagState GetFlagState(string str)
        {
            switch (str)
            {
                case "North":
                    return Semaphore.FlagState.North;

                case "North East":
                    return Semaphore.FlagState.NorthEast;

                case "East":
                    return Semaphore.FlagState.East;

                case "South East":
                    return Semaphore.FlagState.SouthEast;

                case "South":
                    return Semaphore.FlagState.South;

                case "South West":
                    return Semaphore.FlagState.SouthWest;

                case "West":
                    return Semaphore.FlagState.West;

                default:
                    return Semaphore.FlagState.NorthWest;
            }
        }
    }
}
