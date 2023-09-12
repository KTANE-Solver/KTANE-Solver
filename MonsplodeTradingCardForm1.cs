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
    /// Purpose: Gets information needed to solve the monsplode trading cards module
    /// </summary>

    public partial class MonsplodeTradingCardForm1 : ModuleForm
    {
        public MonsplodeTradingCardForm1(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Monsplode Trading Cards", false)
        {
            InitializeComponent();
            label1.TabStop = false;
            label2.TabStop = false;
            label3.TabStop = false;
            label4.TabStop = false;
            label5.TabStop = false;
            label6.TabStop = false;
            label7.TabStop = false;
            label8.TabStop = false;
            label9.TabStop = false;
            label10.TabStop = false;
            label11.TabStop = false;
            label12.TabStop = false;
            label13.TabStop = false;
            label14.TabStop = false;
            label15.TabStop = false;
            label16.TabStop = false;
            label17.TabStop = false;
            label18.TabStop = false;
            label19.TabStop = false;
            label21.TabStop = false;

            UpdateForm(bomb, logFileWriter, moduleSelectionForm);
        }

        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            card1ShinyCheckBox.Checked = false;
            card2ShinyCheckBox.Checked = false;
            card3ShinyCheckBox.Checked = false;

            offeringCardShinyCheckBox.Checked = false;

            UpdateCardNameComboBox(card1NameComboBox);
            UpdateCardNameComboBox(card2NameComboBox);
            UpdateCardNameComboBox(card3NameComboBox);
            UpdateCardNameComboBox(offeringCardNameComboBox);

            UpdateRarityComboBox(card1RarityComboBox);
            UpdateRarityComboBox(card2RarityComboBox);
            UpdateRarityComboBox(card3RarityComboBox);
            UpdateRarityComboBox(offeringCardRarityComboBox);

            card1PrintVersionTextBox.Text = "";
            card2PrintVersionTextBox.Text = "";
            card3PrintVersionTextBox.Text = "";
            offeringCardPrintVersionTextBox.Text = "";

            card1BentCornerTextBox.Text = "";
            card2BentCornerTextBox.Text = "";
            card3BentCornerTextBox.Text = "";
            offeringCardBentCornerTextBox.Text = "";
        }

        private void UpdateCardNameComboBox(ComboBox comboBox)
        {
            String[] names =
            {
                "Aluga",
                "Aluga, The Fighter",
                "Asteran",
                "Bob",
                "Bob, The Ancestor",
                "Buhar",
                "Buhar, The Protector",
                "Caadarim",
                "Clondar",
                "Cutie Pie",
                "Docsplode",
                "Flaurim",
                "Gloorim",
                "Lanaluff",
                "Lugirit",
                "Magmy",
                "Melbor",
                "Melbor, The Web Bug",
                "Mountoise",
                "Myrchat",
                "Nibs",
                "Percy",
                "Pouse",
                "Ukkens",
                "Vellarim",
                "Violan",
                "Zapra",
                "Zenlad"
            };
            comboBox.Items.Clear();
            comboBox.Items.AddRange(names);
            comboBox.Text = names[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void UpdateRarityComboBox(ComboBox comboBox)
        {
            String[] rarity = { "Common", "Uncommon", "Rare", "Ultra" };

            comboBox.Items.Clear();
            comboBox.Items.AddRange(rarity);
            comboBox.Text = rarity[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void moduleSelectionButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            MonsplodeTradingCard.Card card1 = GetCard(
                card1NameComboBox,
                card1RarityComboBox,
                card1PrintVersionTextBox,
                card1BentCornerTextBox,
                card1ShinyCheckBox
            );

            if (card1 == null)
            {
                return;
            }

            MonsplodeTradingCard.Card card2 = GetCard(
                card2NameComboBox,
                card2RarityComboBox,
                card2PrintVersionTextBox,
                card2BentCornerTextBox,
                card2ShinyCheckBox
            );

            if (card2 == null)
            {
                return;
            }

            MonsplodeTradingCard.Card card3 = GetCard(
                card3NameComboBox,
                card3RarityComboBox,
                card3PrintVersionTextBox,
                card3BentCornerTextBox,
                card3ShinyCheckBox
            );

            if (card3 == null)
            {
                return;
            }

            MonsplodeTradingCard.Card offeringCard = GetCard(
                offeringCardNameComboBox,
                offeringCardRarityComboBox,
                offeringCardPrintVersionTextBox,
                offeringCardBentCornerTextBox,
                offeringCardShinyCheckBox
            );

            if (offeringCard == null)
            {
                return;
            }

            PrintHeader();

            MonsplodeTradingCard module = new MonsplodeTradingCard(
                Bomb,
                LogFileWriter,
                card1,
                card2,
                card3
            );

            module.Solve(offeringCard, false);

            this.Hide();
            MonsplodeTradingCardOtherStageForm secondStage = new MonsplodeTradingCardOtherStageForm(
                2,
                module,
                Bomb,
                this,
                LogFileWriter,
                ModuleSelectionForm
            );
            secondStage.Show();
        }

        private MonsplodeTradingCard.Card GetCard(
            ComboBox name,
            ComboBox rarityComboBox,
            TextBox printVersionTextBox,
            TextBox bentCorners,
            CheckBox shiny
        )
        {
            String printVersion = printVersionTextBox.Text.ToUpper();

            if (printVersion.Length != 2)
            {
                ShowErrorMessage("Print Version can only be two charcters");
                return null;
            }

            if (printVersion[0] < 65 || printVersion[0] > 90)
            {
                ShowErrorMessage("First character of Print Version must be a letter");
                return null;
            }

            if (printVersion[1] < 48 || printVersion[1] > 57)
            {
                ShowErrorMessage("Second character of Print Version must be a number");
                return null;
            }

            int bentNumber;
            try
            {
                bentNumber = int.Parse(bentCorners.Text);
            }
            catch
            {
                ShowErrorMessage("Bent Corners must be a number");
                return null;
            }

            if (bentNumber < 0 || bentNumber > 4)
            {
                ShowErrorMessage("Bent corners can only be between 0 - 4");
                return null;
            }

            MonsplodeTradingCard.Card.Rarity rarity = (MonsplodeTradingCard.Card.Rarity)
                Enum.Parse(typeof(MonsplodeTradingCard.Card.Rarity), rarityComboBox.Text);

            return new MonsplodeTradingCard.Card(
                name.Text,
                printVersion,
                rarity,
                shiny.Checked,
                bentNumber,
                Bomb
            );
        }
    }
}
