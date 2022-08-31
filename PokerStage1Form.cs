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

    public partial class PokerStage1Form : ModuleForm
    {
        public PokerStage1Form(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Poker", false)
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

            cardComboBox.Items.Clear();
            cardComboBox.Items.AddRange(new String[] { "ACE", "FIVE", "KING", "TWO" });
            cardComboBox.Text = "ACE";
            cardComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void PrintCards(List<Poker.Card> hand)
        {
            foreach (Poker.Card card in hand)
            {
                System.Diagnostics.Debug.WriteLine($"{card.number} of {card.suite}");
            }

            System.Diagnostics.Debug.WriteLine("");
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            PrintHeader();

            Poker module = new Poker(Bomb, LogFileWriter, cardComboBox.Text);

            module.SetHand();

            PrintCards(module.hand);

            Poker.Card[] hand = module.hand.ToArray();
            String rank = module.SetRank(hand);

            System.Diagnostics.Debug.WriteLine($"Rank: {rank}\n");

            String answer;

            switch (rank)
            {
                case "Royal Flush":
                case "Straight Flush":
                case "Four of a Kind":
                    answer = "All-in";
                    break;

                case "Full House":
                case "Flush":
                    answer = "Max Raise";
                    break;

                case "Straight":
                case "Three of a Kind":
                    answer = "Min Raise";
                    break;

                case "Two Pair":
                case "Pair":
                    answer = "Check";
                    break;

                default:
                    answer = "Fold";
                    break;
            }

            ShowAnswer($"Press {answer}");

            this.Hide();

            PokerStage2Form stage2 = new PokerStage2Form(
                this,
                ModuleSelectionForm,
                module,
                Bomb,
                LogFileWriter
            );
            stage2.Show();
        }
    }
}
