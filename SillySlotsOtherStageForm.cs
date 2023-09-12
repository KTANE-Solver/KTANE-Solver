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
    /// Date: 3/25/21
    /// Purpose: Used to get the information needed to solve stage 2-4
    /// </summary>
    public partial class SillySlotsOtherStageForm : MultiStageModuleForm
    {
        //=========FEILDS=========

        //slot information
        private String keyword;

        //the stage the user is on
        private int stage;

        //the form the user will see next if they press the back button
        //while on stage 2
        private SillySlotsStage1Form sillySlotsStage1Form;

        //used to solve the module
        private SillySlots sillySlotsModule;

        //=========PROPERTIES=========


        //=========CONSTRUCTOR=========

        /// <summary>
        /// Used to get the information
        /// </summary>
        /// <param name="sillySlotsStage1Form">the form used to get here</param>
        /// <param name="moduleSelectionForm">the form used if the user wants to select another module</param>
        /// <param name="bomb">used to increment edgework</param>
        /// <param name="logFileWriter">used to write to the log file</param>
        /// <param name="sillySlotsModule">used to solve the module</param>
        /// <param name="stage">which stage the user is on</param>
        public SillySlotsOtherStageForm(
            SillySlotsStage1Form sillySlotsStage1Form,
            ModuleSelectionForm moduleSelectionForm,
            Bomb bomb,
            StreamWriter logFileWriter,
            SillySlots sillySlotsModule,
            int stage
        )
            : base(
                bomb,
                logFileWriter,
                moduleSelectionForm,
                sillySlotsStage1Form,
                "Silly Slots",
                false
            )
        {
            InitializeComponent();
            UpdateForm(
                sillySlotsStage1Form,
                moduleSelectionForm,
                bomb,
                logFileWriter,
                sillySlotsModule,
                stage
            );
        }

        //=========METHODS=========
        /// <summary>
        /// Used to update the form so it's good as new
        /// </summary>
        public void UpdateForm(
            SillySlotsStage1Form sillySlotsStage1Form,
            ModuleSelectionForm moduleSelectionForm,
            Bomb bomb,
            StreamWriter logFileWriter,
            SillySlots sillySlotsModule,
            int stage
        )
        {
            FormClosing += CloseProgram;

            //setting up all the vairables

            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            this.sillySlotsStage1Form = sillySlotsStage1Form;
            this.stage = stage;
            this.sillySlotsModule = sillySlotsModule;

            /**updating the form itself**/

            //the label will show what stage the user is on
            stageLabel.Text = "Stage " + stage;

            //set up keyword comboBox
            keywordComboBox.Items.Clear();

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
            keywordComboBox.Text = keywordList[0];
            keywordComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //set up each color combobox
            SetColorComboBox(slot1ColorComboBox);
            SetColorComboBox(slot2ColorComboBox);
            SetColorComboBox(slot3ColorComboBox);

            //set up each object combobox
            SetObjectComboBox(slot1ObjectComboBox);
            SetObjectComboBox(slot2ObjectComboBox);
            SetObjectComboBox(slot3ObjectComboBox);
        }

        /// <summary>
        /// Used to give the module more infomration
        /// </summary>
        /// <param name="stage">the stage the slots belong to</param>
        /// <param name="slot1Color"></param>
        /// <param name="slot1Object"></param>
        /// <param name="slot2Color"></param>
        /// <param name="slot2Object"></param>
        /// <param name="slot3Color"></param>
        /// <param name="slot3Object"></param>
        public void UpdateForm(int stage)
        {
            this.stage = stage;

            //the label will show what stage the user is on
            stageLabel.Text = "Stage " + stage;

            //set up keyword comboBox
            keywordComboBox.Items.Clear();

            String[] keywordList = new String[]
            {
                "Sally",
                "Sassy",
                "Silly",
                "Simon",
                "Soggy",
                "Sausage",
                "Steven"
            };

            keywordComboBox.Items.AddRange(keywordList);
            keywordComboBox.Text = keywordList[0];
            keywordComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //set up each color combobox
            SetColorComboBox(slot1ColorComboBox);
            SetColorComboBox(slot2ColorComboBox);
            SetColorComboBox(slot3ColorComboBox);

            //set up each object combobox
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
            comboBox.Items.Clear();

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
        /// Gives the player a strike
        /// </summary>
        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        /// <summary>
        /// Sends the player to the module selection from
        /// </summary>
        private void moduleSelectionButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        /// <summary>
        /// Goes back to the previous stage
        /// </summary>
        private void backButton_Click(object sender, EventArgs e)
        {
            if (stage == 2)
            {
                sillySlotsStage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                ResetModule();
            }
            else
            {
                UpdateForm(
                    sillySlotsStage1Form,
                    ModuleSelectionForm,
                    Bomb,
                    LogFileWriter,
                    sillySlotsModule,
                    stage - 1
                );
            }
        }

        /// <summary>
        /// Tells the player what to do to solve the stage
        /// <summary>
        private void submitButton_Click(object sender, EventArgs e)
        {
            //updating the module
            keyword = keywordComboBox.Text;

            SillySlots.Slot slot1 = new SillySlots.Slot(slot1ColorComboBox.Text, slot1ObjectComboBox.Text);
            SillySlots.Slot slot2 = new SillySlots.Slot(slot2ColorComboBox.Text, slot2ObjectComboBox.Text);
            SillySlots.Slot slot3 = new SillySlots.Slot(slot3ColorComboBox.Text, slot3ObjectComboBox.Text);


            sillySlotsModule.UpdateModule(
                stage,
                keyword,
                slot1,
                slot2,
                slot3
            );

            //getting the answer and showing the appropriate form next
            bool presskeep = sillySlotsModule.Solve(stage);

            if (presskeep)
            {
                ShowAnswer("Press Keep");
                sillySlotsStage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                ResetModule();
            }
            else
            {
                ShowAnswer("Pull the lever");

                //if the stage is 4 then go to the first stage
                if (stage == 4)
                {
                    sillySlotsStage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
                    ResetModule();
                }
                else
                {
                    UpdateForm(stage + 1);
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            sillySlotsStage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            ResetModule();
        }
    }
}
