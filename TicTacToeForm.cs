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
    public partial class TicTacToeForm : ModuleForm
    {
        public TicTacToeForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Tic Tac Toe", false)
        {
            InitializeComponent();
            UpdateForm();
        }

        public void UpdateForm()
        {
            string[] arr = new string[] { "X", "O" };
            symbolComboBox.Items.Clear();
            symbolComboBox.Items.AddRange(arr);
            symbolComboBox.Text = arr[0];
            symbolComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            topRowTextBox.Text = "";
            middleRowTextBox.Text = "";
            bottomRowTextBox.Text = "";
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
            string topRow = topRowTextBox.Text.ToUpper();
            string middleRow = middleRowTextBox.Text.ToUpper();
            string bottomRow = bottomRowTextBox.Text.ToUpper();

            if (!ValidRow(topRow) || !ValidRow(middleRow) || !ValidRow(bottomRow))
            {
                return;
            }

            char[,] grid = SetUpGrid(topRow, middleRow, bottomRow);

            TicTacToe module = new TicTacToe(Bomb, LogFileWriter, grid);
            TicTacToeSymbolForm symbolForm = new TicTacToeSymbolForm();
            TicTacToeInputForm tileSelectionForm = new TicTacToeInputForm(module, symbolForm, this);
            symbolForm.InitaializeForm(module, tileSelectionForm, this);

            module.PrintGrid();
            module.FindStartingRow();
            int[] answer = module.Solve(symbolComboBox.Text[0]);

            if (!module.SolvedModule(answer.Length == 1))
            {
                this.Hide();

                if (answer.Length != 1)
                {
                    TicTacToeAnswerForm answerForm = new TicTacToeAnswerForm(answer[0], answer[1]);
                    answerForm.ShowDialog();
                    symbolForm.Show();
                }
                else
                {
                    tileSelectionForm.Show();
                }
            }
            else
            {
                UpdateForm();
            }
        }

        private bool ValidRow(string text)
        {
            if (text.Length != 3)
            {
                ShowErrorMessage("Text boxes need 3 characters");
                return false;
            }

            foreach (char c in text)
            {
                if (c >= 49 && c <= 57 || c == 88 || c == 79)
                {
                    continue;
                }
                else
                {
                    ShowErrorMessage(
                        "Text boxes can only contain caracheters X, O, and the digits between 1-9"
                    );
                    return false;
                }
            }

            return true;
        }

        private char[,] SetUpGrid(string row1, string row2, string row3)
        {
            char[,] grid = new char[3, 3];

            for (int i = 0; i < 3; i++)
            {
                grid[0, i] = row1[i];
                grid[1, i] = row2[i];
                grid[2, i] = row3[i];
            }

            return grid;
        }
    }
}
