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
        public BinaryPuzzleForm(ModuleSelectionForm moduleSelection, StreamWriter logFileWriter)
            : base(null, logFileWriter, moduleSelection, "Binary Puzzle", false)
        {
            InitializeComponent();

            row1button1.Click += Tile_Click;
            row1button2.Click += Tile_Click;
            row1button3.Click += Tile_Click;
            row1button4.Click += Tile_Click;
            row1button5.Click += Tile_Click;
            row1button6.Click += Tile_Click;

            row2button1.Click += Tile_Click;
            row2button2.Click += Tile_Click;
            row2button3.Click += Tile_Click;
            row2button4.Click += Tile_Click;
            row2button5.Click += Tile_Click;
            row2button6.Click += Tile_Click;

            row3button1.Click += Tile_Click;
            row3button2.Click += Tile_Click;
            row3button3.Click += Tile_Click;
            row3button4.Click += Tile_Click;
            row3button5.Click += Tile_Click;
            row3button6.Click += Tile_Click;

            row4button1.Click += Tile_Click;
            row4button2.Click += Tile_Click;
            row4button3.Click += Tile_Click;
            row4button4.Click += Tile_Click;
            row4button5.Click += Tile_Click;
            row4button6.Click += Tile_Click;

            row5button1.Click += Tile_Click;
            row5button2.Click += Tile_Click;
            row5button3.Click += Tile_Click;
            row5button4.Click += Tile_Click;
            row5button5.Click += Tile_Click;
            row5button6.Click += Tile_Click;

            row6button1.Click += Tile_Click;
            row6button2.Click += Tile_Click;
            row6button3.Click += Tile_Click;
            row6button4.Click += Tile_Click;
            row6button5.Click += Tile_Click;
            row6button6.Click += Tile_Click;

            UpdateForm(moduleSelection, logFileWriter);
        }

        public void UpdateForm(ModuleSelectionForm moduleSelection, StreamWriter logFileWriter)
        {
            ModuleSelectionForm = moduleSelection;
            LogFileWriter = logFileWriter;

            row1button1.BackColor = Color.White;
            row1button2.BackColor = Color.White;
            row1button3.BackColor = Color.White;
            row1button4.BackColor = Color.White;
            row1button5.BackColor = Color.White;
            row1button6.BackColor = Color.White;

            row2button1.BackColor = Color.White;
            row2button2.BackColor = Color.White;
            row2button3.BackColor = Color.White;
            row2button4.BackColor = Color.White;
            row2button5.BackColor = Color.White;
            row2button6.BackColor = Color.White;

            row3button1.BackColor = Color.White;
            row3button2.BackColor = Color.White;
            row3button3.BackColor = Color.White;
            row3button4.BackColor = Color.White;
            row3button5.BackColor = Color.White;
            row3button6.BackColor = Color.White;

            row4button1.BackColor = Color.White;
            row4button2.BackColor = Color.White;
            row4button3.BackColor = Color.White;
            row4button4.BackColor = Color.White;
            row4button5.BackColor = Color.White;
            row4button6.BackColor = Color.White;

            row5button1.BackColor = Color.White;
            row5button2.BackColor = Color.White;
            row5button3.BackColor = Color.White;
            row5button4.BackColor = Color.White;
            row5button5.BackColor = Color.White;
            row5button6.BackColor = Color.White;

            row6button1.BackColor = Color.White;
            row6button2.BackColor = Color.White;
            row6button3.BackColor = Color.White;
            row6button4.BackColor = Color.White;
            row6button5.BackColor = Color.White;
            row6button6.BackColor = Color.White;
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

            grid[0, 0] = GetInput(row1button1);
            grid[0, 1] = GetInput(row1button2);
            grid[0, 2] = GetInput(row1button3);
            grid[0, 3] = GetInput(row1button4);
            grid[0, 4] = GetInput(row1button5);
            grid[0, 5] = GetInput(row1button6);

            grid[1, 0] = GetInput(row2button1);
            grid[1, 1] = GetInput(row2button2);
            grid[1, 2] = GetInput(row2button3);
            grid[1, 3] = GetInput(row2button4);
            grid[1, 4] = GetInput(row2button5);
            grid[1, 5] = GetInput(row2button6);

            grid[2, 0] = GetInput(row3button1);
            grid[2, 1] = GetInput(row3button2);
            grid[2, 2] = GetInput(row3button3);
            grid[2, 3] = GetInput(row3button4);
            grid[2, 4] = GetInput(row3button5);
            grid[2, 5] = GetInput(row3button6);

            grid[3, 0] = GetInput(row4button1);
            grid[3, 1] = GetInput(row4button2);
            grid[3, 2] = GetInput(row4button3);
            grid[3, 3] = GetInput(row4button4);
            grid[3, 4] = GetInput(row4button5);
            grid[3, 5] = GetInput(row4button6);

            grid[4, 0] = GetInput(row5button1);
            grid[4, 1] = GetInput(row5button2);
            grid[4, 2] = GetInput(row5button3);
            grid[4, 3] = GetInput(row5button4);
            grid[4, 4] = GetInput(row5button5);
            grid[4, 5] = GetInput(row5button6);

            grid[5, 0] = GetInput(row6button1);
            grid[5, 1] = GetInput(row6button2);
            grid[5, 2] = GetInput(row6button3);
            grid[5, 3] = GetInput(row6button4);
            grid[5, 4] = GetInput(row6button5);
            grid[5, 5] = GetInput(row6button6);

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
    }
}
