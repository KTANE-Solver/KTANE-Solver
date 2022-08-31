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
    /// Purpose: Gets inforamtion needed to solve the Adventure Game module
    /// </summary>
    public partial class AdventureGameForm : ModuleForm
    {
        //tell if a weapon slot is taken
        private static bool weapon1SlotTaken;
        private static bool weapon2SlotTaken;

        private static string weapon1;
        private static string weapon2;
        private static string weapon3;

        //tell if an item slot is taken
        private static bool item1SlotTaken;
        private static bool item2SlotTaken;
        private static bool item3SlotTaken;
        private static bool item4SlotTaken;

        private static AdventureGame.Item item1;
        private static AdventureGame.Item item2;
        private static AdventureGame.Item item3;
        private static AdventureGame.Item item4;
        private static AdventureGame.Item item5;

        public AdventureGameForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Adventure Game", false)
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
            string[] enemies = new string[]
            {
                "Demon",
                "Dragon",
                "Eagle",
                "Goblin",
                "Golem",
                "Troll",
                "Lizard",
                "Wizard"
            };

            enemyComboBox.Items.Clear();
            enemyComboBox.Items.AddRange(enemies);
            enemyComboBox.Text = enemies[0];
            enemyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            broadswoardCheckBox.Checked = false;
            caberCheckBox.Checked = false;
            nastyKnifeCheckBox.Checked = false;
            longbowCheckBox.Checked = false;
            magicOrbCheckBox.Checked = false;
            grimoireCheckBox.Checked = false;

            balloonCheckBox.Checked = false;
            batteryCheckBox.Checked = false;
            bellowsCheckBox.Checked = false;
            cheatCodeCheckBox.Checked = false;
            crystalBallCheckBox.Checked = false;
            featherCheckBox.Checked = false;
            hardDriveCheckBox.Checked = false;
            lampCheckBox.Checked = false;
            moonstoneCheckBox.Checked = false;
            potionCheckBox.Checked = false;
            smallDogCheckBox.Checked = false;
            stepladderCheckBox.Checked = false;
            sunstoneCheckBox.Checked = false;
            symbolCheckBox.Checked = false;
            ticketCheckBox.Checked = false;
            trophyCheckBox.Checked = false;

            strengthTextBox.Text = "";
            intelligenceTextBox.Text = "";
            dexterityTextBox.Text = "";
            heightTextBox.Text = "";
            temperatureTextBox.Text = "";
            gravityTextBox.Text = "";
            pressureTextBox.Text = "";

            item1SlotTaken = false;
            item2SlotTaken = false;
            item3SlotTaken = false;
            item4SlotTaken = false;

            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);
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
            int strength;
            int intelligence;
            int dexterity;
            int height;
            int temp;
            double gravity;
            int pressure;

            try
            {
                strength = int.Parse(strengthTextBox.Text);
                intelligence = int.Parse(intelligenceTextBox.Text);
                dexterity = int.Parse(dexterityTextBox.Text);
                height = int.Parse(heightTextBox.Text);
                temp = int.Parse(temperatureTextBox.Text);
                gravity = double.Parse(gravityTextBox.Text);
                pressure = int.Parse(pressureTextBox.Text);
            }
            catch
            {
                ShowErrorMessage("Only numbers can go in these text box");
                return;
            }

            //needs to be 3 weapons
            if (SelectedWeaponNum() != 3)
            {
                ShowErrorMessage("There can only be 3 weapons selected");
                return;
            }

            //needs to be 5 items
            if (SelectedItemNum() != 5)
            {
                ShowErrorMessage("There can only be 5 items selected");
                return;
            }

            string enemy = enemyComboBox.Text;

            weapon1SlotTaken = false;
            weapon2SlotTaken = false;

            SetWeapon(broadswoardCheckBox);
            SetWeapon(caberCheckBox);
            SetWeapon(nastyKnifeCheckBox);
            SetWeapon(longbowCheckBox);
            SetWeapon(magicOrbCheckBox);
            SetWeapon(grimoireCheckBox);

            SetItem(balloonCheckBox);
            SetItem(batteryCheckBox);
            SetItem(bellowsCheckBox);
            SetItem(cheatCodeCheckBox);
            SetItem(crystalBallCheckBox);
            SetItem(featherCheckBox);
            SetItem(hardDriveCheckBox);
            SetItem(lampCheckBox);
            SetItem(moonstoneCheckBox);
            SetItem(potionCheckBox);
            SetItem(smallDogCheckBox);
            SetItem(stepladderCheckBox);
            SetItem(sunstoneCheckBox);
            SetItem(symbolCheckBox);
            SetItem(ticketCheckBox);
            SetItem(trophyCheckBox);

            AdventureGame module = new AdventureGame(
                strength,
                dexterity,
                intelligence,
                height,
                temp,
                gravity,
                pressure,
                weapon1,
                weapon2,
                weapon3,
                item1,
                item2,
                item3,
                item4,
                item5,
                enemy,
                Bomb,
                LogFileWriter
            );

            module.Solve();

            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }

        /// <summary>
        /// Figures out which weapon is being used
        /// </summary>
        /// <param name="weaponCheckBox">the check box of the weapon that was selected</param>
        private void SetWeapon(CheckBox weaponCheckBox)
        {
            if (weaponCheckBox.Checked)
            {
                if (!weapon1SlotTaken)
                {
                    weapon1SlotTaken = true;
                    weapon1 = weaponCheckBox.Text;
                }
                else if (!weapon2SlotTaken)
                {
                    weapon2SlotTaken = true;
                    weapon2 = weaponCheckBox.Text;
                }
                else
                {
                    weapon3 = weaponCheckBox.Text;
                }
            }
        }

        /// <summary>
        /// Figures out which item is being used
        /// </summary>
        /// <param name="itemCheckBox">the check box of the item that was selected</param>
        private void SetItem(CheckBox itemCheckBox)
        {
            if (itemCheckBox.Checked)
            {
                string itemName = itemCheckBox.Text.ToUpper().Replace(" ", "");
                if (!item1SlotTaken)
                {
                    item1SlotTaken = true;
                    item1 = (AdventureGame.Item)Enum.Parse(typeof(AdventureGame.Item), itemName);
                }
                else if (!item2SlotTaken)
                {
                    item2SlotTaken = true;
                    item2 = (AdventureGame.Item)Enum.Parse(typeof(AdventureGame.Item), itemName);
                }
                else if (!item3SlotTaken)
                {
                    item3SlotTaken = true;
                    item3 = (AdventureGame.Item)Enum.Parse(typeof(AdventureGame.Item), itemName);
                }
                else if (!item4SlotTaken)
                {
                    item4SlotTaken = true;
                    item4 = (AdventureGame.Item)Enum.Parse(typeof(AdventureGame.Item), itemName);
                }
                else
                {
                    item5 = (AdventureGame.Item)Enum.Parse(typeof(AdventureGame.Item), itemName);
                }
            }
        }

        /// <summary>
        /// Checks how many weapons were selected
        /// </summary>
        /// <returns>how many weapon check box were selected</returns>
        private int SelectedWeaponNum()
        {
            int num = 0;

            if (broadswoardCheckBox.Checked)
            {
                num++;
            }

            if (caberCheckBox.Checked)
            {
                num++;
            }

            if (nastyKnifeCheckBox.Checked)
            {
                num++;
            }

            if (longbowCheckBox.Checked)
            {
                num++;
            }

            if (magicOrbCheckBox.Checked)
            {
                num++;
            }

            if (grimoireCheckBox.Checked)
            {
                num++;
            }

            return num;
        }

        /// <summary>
        /// Checks how many items were selected
        /// </summary>
        /// <returns>how many items check box were selected</returns>
        private int SelectedItemNum()
        {
            int num = 0;

            if (balloonCheckBox.Checked)
            {
                num++;
            }

            if (batteryCheckBox.Checked)
            {
                num++;
            }

            if (bellowsCheckBox.Checked)
            {
                num++;
            }

            if (cheatCodeCheckBox.Checked)
            {
                num++;
            }

            if (crystalBallCheckBox.Checked)
            {
                num++;
            }

            if (featherCheckBox.Checked)
            {
                num++;
            }

            if (hardDriveCheckBox.Checked)
            {
                num++;
            }

            if (lampCheckBox.Checked)
            {
                num++;
            }

            if (moonstoneCheckBox.Checked)
            {
                num++;
            }

            if (potionCheckBox.Checked)
            {
                num++;
            }

            if (smallDogCheckBox.Checked)
            {
                num++;
            }

            if (stepladderCheckBox.Checked)
            {
                num++;
            }

            if (sunstoneCheckBox.Checked)
            {
                num++;
            }

            if (symbolCheckBox.Checked)
            {
                num++;
            }

            if (ticketCheckBox.Checked)
            {
                num++;
            }

            if (trophyCheckBox.Checked)
            {
                num++;
            }

            return num;
        }
    }
}
