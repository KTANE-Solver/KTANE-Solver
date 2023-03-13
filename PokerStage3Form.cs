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
    /// Purpose: Gets information needed to solve the poker module
    /// </summary>
    public partial class PokerStage3Form : MultiStageModuleForm
    {
        PokerStage1Form pokerStage1Form;
        PokerStage2Form pokerStage2Form;

        Poker module;

        public PokerStage3Form(
            PokerStage1Form pokerStage1Form,
            PokerStage2Form pokerStage2Form,
            ModuleSelectionForm moduleSelectionForm,
            Poker module,
            Bomb bomb,
            StreamWriter logFileWriter
        ) : base(bomb, logFileWriter, moduleSelectionForm, pokerStage1Form, "Poker", false)
        {
            InitializeComponent();

            UpdateForm(
                pokerStage1Form,
                pokerStage2Form,
                moduleSelectionForm,
                module,
                bomb,
                logFileWriter
            );
        }

        public void UpdateForm(
            PokerStage1Form pokerStage1Form,
            PokerStage2Form pokerStage2Form,
            ModuleSelectionForm moduleSelectionForm,
            Poker module,
            Bomb bomb,
            StreamWriter logFileWriter
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            this.pokerStage1Form = pokerStage1Form;
            this.pokerStage2Form = pokerStage2Form;

            this.module = module;

            betAmountComboBox.Items.Clear();
            betAmountComboBox.Items.AddRange(new String[] { "25", "50", "100", "500" });
            betAmountComboBox.Text = "25";
            betAmountComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            UpdateCardComboBox(card1ComboBox);
            UpdateCardComboBox(card2ComboBox);
            UpdateCardComboBox(card3ComboBox);
            UpdateCardComboBox(card4ComboBox);
        }

        public void UpdateCardComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(new String[] { "CLUB", "DIAMOND", "HEART", "SPADE" });
            comboBox.Text = "CLUB";
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void moduleSelectionButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            pokerStage2Form.UpdateForm(
                pokerStage1Form,
                ModuleSelectionForm,
                module,
                Bomb,
                LogFileWriter
            );
            this.Hide();
            pokerStage2Form.Show();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            Poker.Card.Suite[] cards = { SetUpCard(card1ComboBox.Text),
                                         SetUpCard(card2ComboBox.Text),
                                         SetUpCard(card3ComboBox.Text),
                                         SetUpCard(card4ComboBox.Text)};


            module.CardAnswer(Int32.Parse(betAmountComboBox.Text), cards, false);

            this.Hide();

            pokerStage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            pokerStage1Form.Show();
        }

        private Poker.Card.Suite SetUpCard(String suite)
        {
            switch (suite)
            {
                case "CLUB":
                    return Poker.Card.Suite.CLUB;

                case "DIAMOND":
                    return Poker.Card.Suite.DIAMOND;

                case "HEART":
                    return Poker.Card.Suite.HEART;

                default:
                    return Poker.Card.Suite.SPADE;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            pokerStage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            ResetModule();
        }
    }
}
