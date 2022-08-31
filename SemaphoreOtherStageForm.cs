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
    public partial class SemaphoreOtherStageForm : ModuleForm
    {
        SemaphoreStage1Form firstForm;
        Semaphore module;

        public SemaphoreOtherStageForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm,
            Semaphore module,
            SemaphoreStage1Form firstForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Semaphore", false)
        {
            InitializeComponent();
            this.module = module;
            this.firstForm = firstForm;
            SetUpComboBox();
        }

        private void SetUpComboBox()
        {
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

            comboBox.Items.Clear();
            comboBox.Items.AddRange(combinedDirection.ToArray());
            comboBox.Text = combinedDirection[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            firstForm.Show();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Semaphore.Flag flag = GetFlag(comboBox.Text);

            string answer = module.Solve(flag);

            if (answer == "Invalid")
            {
                this.Hide();
                firstForm.Show();
                firstForm.UpdateForm();
            }
            else
            {
                SetUpComboBox();
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
