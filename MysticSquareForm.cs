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
    public partial class MysticSquareForm : ModuleForm
    {
        bool stage1;
        MysticSquares module;

        public MysticSquareForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Mystic Square", false)
        {
            InitializeComponent();
            stage1 = true;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            if (text.Length != 9)
            {
                ShowErrorMessage("Text needs to be 9 characters long");
                return;
            }

            bool validText = true;

            for (int i = 0; i < 9; i++)
            {
                char target = (char)(48 + i);
                validText = text.Contains(target);

                if (!validText)
                {
                    break;
                }
            }

            if (!validText)
            {
                ShowErrorMessage("Text missing number(s). Need to have the numbers 0-8");
                return;
            }

            int[,] grid = new int[3, 3];

            for (int i = 0; i < 9; i++)
            {
                int row = i / 3;
                int col = i % 3;

                grid[row, col] = int.Parse("" + text[i]);
            }

            if (stage1)
            {
                module = new MysticSquares(Bomb, LogFileWriter);

                module.FindSkull(grid);

                UpdateForm2();
            }
            else
            {
                module.Solve(grid);
                UpdateForm();
            }

            stage1 = !stage1;
        }

        private void UpdateForm()
        {
            label1.Text = "What does the grid look like?";
            textBox1.Text = "";
        }

        private void UpdateForm2()
        {
            label1.Text = "What does the grid look like now?";
            textBox1.Text = "";
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }
    }
}
