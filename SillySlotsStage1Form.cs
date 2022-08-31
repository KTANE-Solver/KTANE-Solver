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
    /// Date: 3/23/21
    /// Purpose: Gets the information needed to solve the fisrt stage of Silly Slots
    /// </summary>
    public partial class SillySlotsStage1Form : ModuleForm
    {
        //used to solve the module
        private SillySlots sillySlotsModule;

        /// <summary>
        /// Creates a form that is used to create
        /// the first stage of silly slots
        /// </summary>
        /// <param name="moduleSelectionForm">the form used to get here</param>
        /// <param name="bomb">used to get the edgework</param>
        /// <param name="logFileWriter">used to write to the log file</param>
        public SillySlotsStage1Form(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Silly Slots", false)
        {
            InitializeComponent();
            UpdateForm(bomb, logFileWriter, moduleSelectionForm);
        }

        /// <summary>
        /// Updates this form so it looks
        /// good as new
        /// </summary>
        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            //clearing all existing items in each comboBox
            keywordComboBox.Items.Clear();

            slot1ColorComboBox.Items.Clear();
            slot2ColorComboBox.Items.Clear();
            slot3ColorComboBox.Items.Clear();

            slot1ObjectComboBox.Items.Clear();
            slot2ObjectComboBox.Items.Clear();
            slot3ObjectComboBox.Items.Clear();

            //set up kewyword comboBox
            String[] keywordList = new String[]
            {
                "Sally",
                "Sassy",
                "Sausage",
                "Silly",
                "Simon",
                "Soggy",
                "Steven"
            };

            keywordComboBox.Items.AddRange(keywordList);
            keywordComboBox.Text = "Sally";
            keywordComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //set up each slot color comboBox
            SetColorComboBox(slot1ColorComboBox);
            SetColorComboBox(slot2ColorComboBox);
            SetColorComboBox(slot3ColorComboBox);

            //set up each slot object comboBox
            SetObjectComboBox(slot1ObjectComboBox);
            SetObjectComboBox(slot2ObjectComboBox);
            SetObjectComboBox(slot3ObjectComboBox);
        }

        /// <summary>
        /// Sets up a combo box so it has
        /// all the colors
        /// </summary>
        /// <param name="comboBox">the combo box that will have all the colors</param>
        private void SetColorComboBox(ComboBox comboBox)
        {
            String[] colorList = new string[] { "Blue", "Green", "Red" };

            comboBox.Items.AddRange(colorList);
            comboBox.Text = "Blue";
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Sets up a combo box so it has
        /// all the objects
        /// </summary>
        /// <param name="comboBox">the combo box that will have all the objects</param>
        private void SetObjectComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            String[] objectList = new string[] { "Bomb", "Cherry", "Coin", "Grape" };

            comboBox.Items.AddRange(objectList);
            comboBox.Text = "Bomb";
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// sends the user back to the module selection stage
        /// </summary>
        private void moduleSelectionButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        /// <summary>
        /// Gives the player a strike
        /// </summary>
        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        /// <summary>
        /// Gets the answer for the first stage of the Silly Slots
        /// </summary>
        private void submitButton_Click(object sender, EventArgs e)
        {
            PrintHeader();

            SillySlots.Slot slot1 = new SillySlots.Slot(
                slot1ColorComboBox.Text,
                slot1ObjectComboBox.Text
            );
            SillySlots.Slot slot2 = new SillySlots.Slot(
                slot2ColorComboBox.Text,
                slot2ObjectComboBox.Text
            );
            SillySlots.Slot slot3 = new SillySlots.Slot(
                slot3ColorComboBox.Text,
                slot3ObjectComboBox.Text
            );

            sillySlotsModule = new SillySlots(
                keywordComboBox.Text,
                slot1,
                slot2,
                slot3,
                LogFileWriter
            );

            //tells if the user has to press keep or not
            bool pressKeep = sillySlotsModule.Solve(1);

            //if the user has to press keep, then send them to the first stage again
            if (pressKeep)
            {
                ShowAnswer("Press Keep");

                UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            }
            //otherwise send them to stage 2
            else
            {
                ShowAnswer("Pull the lever");

                SillySlotsOtherStageForm sillySlotsOtherStageForm = new SillySlotsOtherStageForm(
                    this,
                    ModuleSelectionForm,
                    Bomb,
                    LogFileWriter,
                    sillySlotsModule,
                    2
                );

                this.Hide();
                sillySlotsOtherStageForm.Show();
            }
        }
    }
}
