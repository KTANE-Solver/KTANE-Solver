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
    /// Date: 4/9/21
    /// Purpose: Gets information needed to
    ///          solve the murder module
    /// </summary>
    public partial class MurderForm : ModuleForm
    {
        public MurderForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Murder", false)
        {
            InitializeComponent();

            UpdateForm(bomb, logFileWriter, moduleSelectionForm);
        }

        /// <summary>
        /// Updates the form with current information
        /// </summary>
        /// <param name="bomb"></param>
        /// <param name="moduleSelectionForm"></param>
        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            SetUpSuspectCombBox(suspectComboBox1);
            SetUpSuspectCombBox(suspectComboBox2);
            SetUpSuspectCombBox(suspectComboBox3);
            SetUpSuspectCombBox(suspectComboBox4);

            SetUpWeaponComboBox(weaponComboBox1);
            SetUpWeaponComboBox(weaponComboBox2);
            SetUpWeaponComboBox(weaponComboBox3);
            SetUpWeaponComboBox(weaponComboBox4);

            //set up comboBox where the body was found
            bodyFoundComboBox.Items.Clear();

            String[] rooms = new string[]
            {
                "Ballroom",
                "Conservatory",
                "Dining Room",
                "Hall",
                "Kitchen",
                "Library",
                "Lounge",
                "Study"
            };

            bodyFoundComboBox.Items.AddRange(rooms);

            bodyFoundComboBox.Text = "Ballroom";

            bodyFoundComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Sets up a comboBox for suspects
        /// </summary>
        /// <param name="comboBox">/param>
        private void SetUpSuspectCombBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            String[] suspects = new string[]
            {
                "Green",
                "Mustard",
                "Peacock",
                "Plum",
                "Scarlett",
                "White"
            };

            comboBox.Items.AddRange(suspects);

            comboBox.Text = "Green";

            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Set up comboBox for weapons
        /// </summary>
        /// <param name="comboBox"></param>
        public void SetUpWeaponComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            String[] weapom = new string[]
            {
                "Candle Stick",
                "Dagger",
                "Lead Pipe",
                "Revolver",
                "Rope",
                "Spanner"
            };

            comboBox.Items.AddRange(weapom);

            comboBox.Text = "Candle Stick";

            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Sends the user back to the module selection form
        /// </summary>
        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        /// <summary>
        /// Adds a strike to the bomb
        /// </summary>
        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        /// <summary>
        /// Passes in information to solve the murder module
        /// </summary>
        private void submitButton_Click(object sender, EventArgs e)
        {
            String[] suspects = new String[]
            {
                suspectComboBox1.Text,
                suspectComboBox2.Text,
                suspectComboBox3.Text,
                suspectComboBox4.Text
            };

            String[] weapons = new String[]
            {
                weaponComboBox1.Text,
                weaponComboBox2.Text,
                weaponComboBox3.Text,
                weaponComboBox4.Text
            };

            String room = bodyFoundComboBox.Text;

            //tells if there is a duplicate weapon or suspect

            bool duplicateWeapons = false;
            bool duplicateSuspects = false;

            //can't have duplicate weapons
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (weapons[i] == weapons[j])
                    {
                        duplicateWeapons = true;
                        break;
                    }

                    if (suspects[i] == suspects[j])
                    {
                        duplicateSuspects = true;
                        break;
                    }
                }

                if (duplicateWeapons)
                {
                    ShowErrorMessage("Can't have duplicate weapons");
                    return;
                }

                if (duplicateSuspects)
                {
                    ShowErrorMessage("Can't have duplicate suspects");
                    return;
                }
            }

            PrintHeader();

            Murder murder = new Murder(suspects, weapons, room, Bomb, LogFileWriter);
            murder.Solve(false);

            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }
    }
}
