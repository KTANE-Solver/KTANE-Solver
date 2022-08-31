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
    public partial class IceCreamStage2Form : ModuleForm
    {
        private IceCream module;
        private IceCreamForm stage1Form;

        public IceCreamStage2Form(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm,
            IceCreamForm stage1Form,
            IceCream module
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Ice Cream", false)
        {
            InitializeComponent();

            this.module = module;
            this.stage1Form = stage1Form;

            UpdateForm(bomb, logFileWriter, moduleSelectionForm, 2);
        }

        /// <summary>
        /// Updates the form so it looks new
        /// </summary>
        /// <param name="bomb">used to get the edgework</param>
        /// <param name="stage">what stage the user is on</param>
        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm,
            int stage
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            stageLabel.Text = "Stage " + stage;

            //set up the customer combo box

            String[] names = new String[]
            {
                "Adam",
                "Ashley",
                "Bob",
                "Cheryl",
                "Dave",
                "Gary",
                "George",
                "Jacob",
                "Jade",
                "Jessica",
                "Mike",
                "Pat",
                "Sally",
                "Sam",
                "Sean",
                "Simon",
                "Taylor",
                "Tim",
                "Tom",
                "Victor"
            };

            customerComboBox.Items.Clear();
            customerComboBox.Items.AddRange(names);
            customerComboBox.Text = names[0];
            customerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //set up the flavors combo box
            SetUpIceCreamComboBox(flavor1ComboBox);
            SetUpIceCreamComboBox(flavor2ComboBox);
            SetUpIceCreamComboBox(flavor3ComboBox);
            SetUpIceCreamComboBox(flavor4ComboBox);
        }

        /// <summary>
        /// Sets up a combo box for ice cream flavors
        /// </summary>
        /// <param name="comboBox">hte combobox that will be given the flavors</param>
        private void SetUpIceCreamComboBox(ComboBox comboBox)
        {
            String[] flavors = new String[]
            {
                "Cookies and Cream",
                "Double Chocolate",
                "Double Strawberry",
                "Mint Chocolate Chip",
                "Neapolitan",
                "Raspberry Ripple",
                "Rocky Road",
                "The Classic",
                "Tutti Frutti"
            };
            comboBox.Items.Clear();
            comboBox.Items.AddRange(flavors);
            comboBox.Text = "Cookies and Cream";
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            String flavor1 = flavor1ComboBox.Text;
            String flavor2 = flavor2ComboBox.Text;
            String flavor3 = flavor3ComboBox.Text;
            String flavor4 = flavor4ComboBox.Text;

            //check to see if there are duplicate flavors
            if (
                flavor1 == flavor2
                || flavor1 == flavor3
                || flavor1 == flavor4
                || flavor2 == flavor3
                || flavor2 == flavor4
                || flavor3 == flavor4
            )
            {
                ShowErrorMessage("Can't have duplicate flavors");
                return;
            }

            module = new IceCream(
                customerComboBox.Text,
                flavor1,
                flavor2,
                flavor3,
                flavor4,
                Bomb,
                LogFileWriter
            );

            PrintDebugLine($"{stageLabel.Text}\n");

            module.Solve();

            if (stageLabel.Text == "Stage 2")
            {
                UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm, 3);
            }
            else
            {
                stage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                stage1Form.Show();
                this.Hide();
            }
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (stageLabel.Text == "Stage 2")
            {
                this.Hide();

                stage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                stage1Form.Show();
            }
            else
            {
                UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm, 2);
            }
        }

        private void moduleSelectionButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }
    }
}
