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
    /// Purpose: Shows the Binary Puzzle Answer
    /// </summary>
    public partial class BinaryPuzzleAnswerForm : ModuleForm
    {
        public BinaryPuzzleAnswerForm(char[,] grid, StreamWriter logFileWriter)
            : base(null, logFileWriter, null, "Binary Puzzle", true)
        {
            InitializeComponent();

            this.ControlBox = false;
            LogFileWriter = logFileWriter;

            row1button1.BackColor = GetColor(grid[0, 0]);
            row1button2.BackColor = GetColor(grid[0, 1]);
            row1button3.BackColor = GetColor(grid[0, 2]);
            row1button4.BackColor = GetColor(grid[0, 3]);
            row1button5.BackColor = GetColor(grid[0, 4]);
            row1button6.BackColor = GetColor(grid[0, 5]);

            row2button1.BackColor = GetColor(grid[1, 0]);
            row2button2.BackColor = GetColor(grid[1, 1]);
            row2button3.BackColor = GetColor(grid[1, 2]);
            row2button4.BackColor = GetColor(grid[1, 3]);
            row2button5.BackColor = GetColor(grid[1, 4]);
            row2button6.BackColor = GetColor(grid[1, 5]);

            row3button1.BackColor = GetColor(grid[2, 0]);
            row3button2.BackColor = GetColor(grid[2, 1]);
            row3button3.BackColor = GetColor(grid[2, 2]);
            row3button4.BackColor = GetColor(grid[2, 3]);
            row3button5.BackColor = GetColor(grid[2, 4]);
            row3button6.BackColor = GetColor(grid[2, 5]);

            row4button1.BackColor = GetColor(grid[3, 0]);
            row4button2.BackColor = GetColor(grid[3, 1]);
            row4button3.BackColor = GetColor(grid[3, 2]);
            row4button4.BackColor = GetColor(grid[3, 3]);
            row4button5.BackColor = GetColor(grid[3, 4]);
            row4button6.BackColor = GetColor(grid[3, 5]);

            row5button1.BackColor = GetColor(grid[4, 0]);
            row5button2.BackColor = GetColor(grid[4, 1]);
            row5button3.BackColor = GetColor(grid[4, 2]);
            row5button4.BackColor = GetColor(grid[4, 3]);
            row5button5.BackColor = GetColor(grid[4, 4]);
            row5button6.BackColor = GetColor(grid[4, 5]);

            row6button1.BackColor = GetColor(grid[5, 0]);
            row6button2.BackColor = GetColor(grid[5, 1]);
            row6button3.BackColor = GetColor(grid[5, 2]);
            row6button4.BackColor = GetColor(grid[5, 3]);
            row6button4.BackColor = GetColor(grid[5, 3]);
            row6button5.BackColor = GetColor(grid[5, 4]);
            row6button6.BackColor = GetColor(grid[5, 5]);

            Text = ModuleName + " Answer";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private Color GetColor(char num)
        {
            if (num == '1')
                return Color.Green;

            return Color.Red;
        }
    }
}
