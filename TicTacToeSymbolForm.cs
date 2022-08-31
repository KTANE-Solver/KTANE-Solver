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
    public partial class TicTacToeSymbolForm : ModuleForm
    {
        private TicTacToe module;
        private TicTacToeInputForm tileSelectionForm;
        private TicTacToeForm initialForm;

        public TicTacToeSymbolForm() : base()
        {
            InitializeComponent();
        }

        public void InitaializeForm(
            TicTacToe module,
            TicTacToeInputForm tileSelectionForm,
            TicTacToeForm initialForm
        )
        {
            this.module = module;
            this.initialForm = initialForm;
            this.tileSelectionForm = tileSelectionForm;
            UpdateForm();
        }

        public void UpdateForm()
        {
            string[] arr = new string[] { "X", "O" };
            symbolComboBox.Items.Clear();
            symbolComboBox.Items.AddRange(arr);
            symbolComboBox.Text = arr[0];
            symbolComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            int[] answer = module.Solve(symbolComboBox.Text[0]);

            if (answer.Length != 1)
            {
                TicTacToeAnswerForm answerForm = new TicTacToeAnswerForm(answer[0], answer[1]);
                answerForm.ShowDialog();
            }

            if (!module.SolvedModule(answer.Length == 1))
            {
                if (answer.Length == 1)
                {
                    this.Hide();
                    tileSelectionForm.UpdateForm();
                    tileSelectionForm.Show();
                }
                else
                {
                    UpdateForm();
                }
            }
            else
            {
                this.Hide();
                initialForm.UpdateForm();
                initialForm.Show();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            initialForm.UpdateForm();
            initialForm.Show();
        }
    }
}
