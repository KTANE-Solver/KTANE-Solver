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

    public partial class PokerStage2Form : MultiStageModuleForm
    {
        PokerStage1Form pokerStage1Form;
        public Poker module;

        public PokerStage2Form(
            PokerStage1Form pokerStage1Form,
            ModuleSelectionForm moduleSelectionForm,
            Poker module,
            Bomb bomb,
            StreamWriter logFileWriter
        ) : base(bomb, logFileWriter, moduleSelectionForm, pokerStage1Form, "Poker", false)
        {
            InitializeComponent();
            UpdateForm(pokerStage1Form, moduleSelectionForm, module, bomb, logFileWriter);
        }

        public void UpdateForm(
            PokerStage1Form pokerStage1Form,
            ModuleSelectionForm moduleSelectionForm,
            Poker module,
            Bomb bomb,
            StreamWriter logFileWriter
        )
        {
            this.pokerStage1Form = pokerStage1Form;
            this.module = module;

            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            responseComboBox.Items.Clear();
            responseComboBox.Items.AddRange(
                new String[]
                {
                    "Are you sure?",
                    "Awful play!",
                    "Really?",
                    "Really, really?",
                    "Sure about that?",
                    "Terrible play!"
                }
            );
            responseComboBox.Text = "Are you sure?";
            responseComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void moduleSelectionButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            pokerStage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            ResetModule();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            module.response = responseComboBox.Text;

            System.Diagnostics.Debug.WriteLine($"Response: {module.response}\n");

            String answer = module.BluffTruth();

            ShowAnswer($"Press {answer}");

            this.Hide();

            PokerStage3Form stage3 = new PokerStage3Form(
                pokerStage1Form,
                this,
                ModuleSelectionForm,
                module,
                Bomb,
                LogFileWriter
            );
            stage3.Show();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            pokerStage1Form.UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
            ResetModule();
        }
    }
}
