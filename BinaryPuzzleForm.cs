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
    /// Purpose: Gets information needed to solve the Binary Puzzle module
    /// </summary>
    public partial class BinaryPuzzleForm : ModuleForm
    {

        private System.Windows.Forms.Button[,] buttonGrid; 
        public BinaryPuzzleForm(ModuleSelectionForm moduleSelection, StreamWriter logFileWriter)
            : base(null, logFileWriter, moduleSelection, "Binary Puzzle", false)
        {
            InitializeComponent();
            buttonGrid = new System.Windows.Forms.Button[6, 6];

            buttonGrid[0, 0] = row1button1;
            buttonGrid[0,1] =  row1button2;
            buttonGrid[0,2] =  row1button3;
            buttonGrid[0,3] =  row1button4;
            buttonGrid[0,4] =  row1button5;
            buttonGrid[0,5] =  row1button6;

            buttonGrid[1, 0] = row2button1;
            buttonGrid[1, 1] = row2button2;
            buttonGrid[1, 2] = row2button3;
            buttonGrid[1, 3] = row2button4;
            buttonGrid[1, 4] = row2button5;
            buttonGrid[1, 5] = row2button6;

            buttonGrid[2, 0] = row3button1;
            buttonGrid[2, 1] = row3button2;
            buttonGrid[2, 2] = row3button3;
            buttonGrid[2, 3] = row3button4;
            buttonGrid[2, 4] = row3button5;
            buttonGrid[2, 5] = row3button6;

            buttonGrid[3, 0] = row4button1;
            buttonGrid[3, 1] = row4button2;
            buttonGrid[3, 2] = row4button3;
            buttonGrid[3, 3] = row4button4;
            buttonGrid[3, 4] = row4button5;
            buttonGrid[3, 5] = row4button6;

            buttonGrid[4, 0] = row5button1;
            buttonGrid[4, 1] = row5button2;
            buttonGrid[4, 2] = row5button3;
            buttonGrid[4, 3] = row5button4;
            buttonGrid[4, 4] = row5button5;
            buttonGrid[4, 5] = row5button6;

            buttonGrid[5, 0] = row6button1;
            buttonGrid[5, 1] = row6button2;
            buttonGrid[5, 2] = row6button3;
            buttonGrid[5, 3] = row6button4;
            buttonGrid[5, 4] = row6button5;
            buttonGrid[5, 5] = row6button6;

            foreach (System.Windows.Forms.Button button in buttonGrid)
            {
                button.Click += Tile_Click;
            }

            UpdateForm(moduleSelection, logFileWriter);
        }

        public void UpdateForm(ModuleSelectionForm moduleSelection, StreamWriter logFileWriter)
        {
            ModuleSelectionForm = moduleSelection;
            LogFileWriter = logFileWriter;

            foreach (System.Windows.Forms.Button button in buttonGrid)
            {
                button.BackColor = Color.White;
            }
        }

        public void Tile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Red;
            }
            else if (button.BackColor == Color.Red)
            {
                button.BackColor = Color.Green;
            }
            else
            {
                button.BackColor = Color.White;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("=================BINARY PUZZLE=================\n");
            //create the grid depending on the buttons
            char[,] grid = new char[6, 6];

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    grid[row, col] = GetInput(buttonGrid[row, col]);
                }
            }

            BinaryPuzzle module = new BinaryPuzzle(grid, LogFileWriter);

            grid = module.Solve();

            if (grid == null)
            {
                ShowErrorMessage("Unable to solve");
            }
            else
            {
                BinaryPuzzleAnswerForm answerForm = new BinaryPuzzleAnswerForm(grid, LogFileWriter);
                answerForm.ShowDialog();
                UpdateForm(ModuleSelectionForm, LogFileWriter);
            }
        }

        private char GetInput(System.Windows.Forms.Button button)
        {
            if (button.BackColor == Color.White)
            {
                return '-';
            }
            else if (button.BackColor == Color.Red)
            {
                return '0';
            }

            return '1';
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            UpdateForm(ModuleSelectionForm, LogFileWriter);
        }
    }
}
