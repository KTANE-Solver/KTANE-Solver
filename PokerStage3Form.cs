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

        private void PrintCard(Poker.Card card, int position)
        {
            System.Diagnostics.Debug.WriteLine($"Card {position}: {card.suite}");
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Poker.Card card1 = SetUpCard(card1ComboBox.Text);
            Poker.Card card2 = SetUpCard(card2ComboBox.Text);
            Poker.Card card3 = SetUpCard(card3ComboBox.Text);
            Poker.Card card4 = SetUpCard(card4ComboBox.Text);

            System.Diagnostics.Debug.WriteLine($"Bet: {betAmountComboBox.Text}\n");

            PrintCard(card1, 1);
            PrintCard(card2, 2);
            PrintCard(card3, 3);
            PrintCard(card4, 4);

            int index = module.BettingRule(
                Int32.Parse(betAmountComboBox.Text),
                card1,
                card2,
                card3,
                card4
            );

            System.Diagnostics.Debug.WriteLine($"\nAnswer: {index}\n");

            String prefix = "";

            switch (index)
            {
                case 1:
                    prefix = "1st";
                    break;

                case 2:
                    prefix = "2nd";
                    break;

                case 3:
                    prefix = "3rd";
                    break;

                case 4:
                    prefix = "4th";
                    break;
            }

            ShowAnswer($"Press the {prefix} card");
            this.Hide();

            pokerStage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            pokerStage1Form.Show();
        }

        private Poker.Card SetUpCard(String suite)
        {
            switch (suite)
            {
                case "CLUB":
                    return new Poker.Card(Poker.Card.Number.ACE, Poker.Card.Suite.CLUB);

                case "DIAMOND":
                    return new Poker.Card(Poker.Card.Number.ACE, Poker.Card.Suite.DIAMOND);

                case "HEART":
                    return new Poker.Card(Poker.Card.Number.ACE, Poker.Card.Suite.HEART);

                default:
                    return new Poker.Card(Poker.Card.Number.ACE, Poker.Card.Suite.SPADE);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            pokerStage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            ResetModule();
        }
    }
}
