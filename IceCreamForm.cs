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
    /// DATE: 3/14/21
    /// Purpose: Gets information needed to solve the ice cream module
    /// </summary>

    public partial class IceCreamForm : ModuleForm
    {
        //used to solve the ice cream do
        private IceCream module;
        private IceCreamStage2Form secondStageForm;

        /// <summary>
        /// Creates a form used to get information to solve the ice cream
        /// module
        /// </summary>
        /// <param name="moduleSelectionForm">the form used to get to this form</param>
        /// <param name="bomb">used for the edgework</param>
        public IceCreamForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Ice Cream", false)
        {
            InitializeComponent();
            UpdateForm(bomb, logFileWriter, moduleSelectionForm);
            LogFileWriter = logFileWriter;
        }

        /// <summary>
        /// Updates the form so it looks new
        /// </summary>
        /// <param name="bomb">used to get the edgework</param>
        /// <param name="stage">what stage the user is on</param>
        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            stageLabel.Text = "Stage 1";

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

        /// <summary>
        /// sends the player back to the module selection stage
        /// </summary>
        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        /// <summary>
        /// Shows the user the answer assuming edgeowork is correct
        /// </summary>
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

            PrintHeader();

            PrintDebugLine($"{stageLabel.Text}\n");

            module.Solve();

            this.Hide();

            secondStageForm = new IceCreamStage2Form(
                Bomb,
                LogFileWriter,
                ModuleSelectionForm,
                this,
                module
            );
            secondStageForm.Show();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }
    }
}
