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
    /// Date: 4/25/21
    /// Purpose: Used to get infomration to solve the wires module
    /// </summary>
    public partial class WiresForm : ModuleForm
    {
        public WiresForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Wires", false)
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
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            SetUpFirstThreeComboBoxes(wireComboBox1);
            SetUpFirstThreeComboBoxes(wireComboBox2);
            SetUpFirstThreeComboBoxes(wireComboBox3);
            SetUpComboBox(wireComboBox4);
            SetUpComboBox(wireComboBox5);
            SetUpComboBox(wireComboBox6);
        }

        /// <summary>
        /// A helper method that will set up the first 3 combo boxes
        /// </summary>
        /// <param name="comboBox"></param>
        private void SetUpFirstThreeComboBoxes(ComboBox comboBox)
        {
            String[] items = new String[] { "Black", "Blue", "Red", "White", "Yellow" };
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items);
            comboBox.Text = items[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// A helper method that sets up combo boxes 4-6
        /// </summary>
        /// <param name="comboBox"></param>
        private void SetUpComboBox(ComboBox comboBox)
        {
            String[] items = new String[] { "", "Black", "Blue", "Red", "White", "Yellow" };
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items);
            comboBox.Text = items[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Tells the user the answer to the Wires modules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            String wire1 = wireComboBox1.Text;
            String wire2 = wireComboBox2.Text;
            String wire3 = wireComboBox3.Text;
            String wire4 = wireComboBox4.Text;
            String wire5 = wireComboBox5.Text;
            String wire6 = wireComboBox6.Text;

            String error = "";

            bool errorFound = false;

            //if 5th or 6th wire are not blank, but 4th is, then there's an error
            if (wire5 != "" && wire4 == "")
            {
                error = "Can't havae 5th wire be not blank while 4th wire is";
                errorFound = true;
            }

            if (wire6 != "" && wire4 == "")
            {
                error = "Can't havae 6th wire be not blank while 4th wire is";
                errorFound = true;
            }

            //can't have 4th or 5th wire be blank while 6th wire isn't
            if (wire4 == "" && wire6 != "")
            {
                error = "Can't havae 4th wire be blank while 6th wire isn't";
                errorFound = true;
            }

            if (wire5 == "" && wire6 != "")
            {
                error = "Can't havae 6th wire be not blank while 5th wire is";
                errorFound = true;
            }

            if (errorFound)
            {
                ShowErrorMessage(error);
                return;
            }

            PrintHeader();

            Wires wireModule = new Wires(
                wire1,
                wire2,
                wire3,
                wire4,
                wire5,
                wire6,
                Bomb,
                LogFileWriter
            );
            wireModule.Solve();
            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }

        /// <summary>
        /// Adds one stirke to the bomb
        /// </summary>
        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        /// <summary>
        /// Goes back to the module selection form
        /// </summary>
        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }
    }
}
