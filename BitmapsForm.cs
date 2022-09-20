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
    public partial class BitmapsForm : ModuleForm
    {
        public BitmapsForm()
        {
            InitializeComponent();
        }

        public BitmapsForm(
            Bomb bomb,
            ModuleSelectionForm moduleSelection,
            StreamWriter logFileWriter
        ) : base(bomb, logFileWriter, moduleSelection, "Bitmaps", false)
        {
            InitializeComponent();

            row1Button1.Click += (Tile_Click);
            row1Button2.Click += (Tile_Click);
            row1Button3.Click += (Tile_Click);
            row1Button4.Click += (Tile_Click);
            row1Button5.Click += (Tile_Click);
            row1Button6.Click += (Tile_Click);
            row1Button7.Click += (Tile_Click);
            row1Button8.Click += (Tile_Click);

            row2Button1.Click += (Tile_Click);
            row2Button2.Click += (Tile_Click);
            row2Button3.Click += (Tile_Click);
            row2Button4.Click += (Tile_Click);
            row2Button5.Click += (Tile_Click);
            row2Button6.Click += (Tile_Click);
            row2Button7.Click += (Tile_Click);
            row2Button8.Click += (Tile_Click);

            row3Button1.Click += (Tile_Click);
            row3Button2.Click += (Tile_Click);
            row3Button3.Click += (Tile_Click);
            row3Button4.Click += (Tile_Click);
            row3Button5.Click += (Tile_Click);
            row3Button6.Click += (Tile_Click);
            row3Button7.Click += (Tile_Click);
            row3Button8.Click += (Tile_Click);

            row4Button1.Click += (Tile_Click);
            row4Button2.Click += (Tile_Click);
            row4Button3.Click += (Tile_Click);
            row4Button4.Click += (Tile_Click);
            row4Button5.Click += (Tile_Click);
            row4Button6.Click += (Tile_Click);
            row4Button7.Click += (Tile_Click);
            row4Button8.Click += (Tile_Click);

            row5Button1.Click += (Tile_Click);
            row5Button2.Click += (Tile_Click);
            row5Button3.Click += (Tile_Click);
            row5Button4.Click += (Tile_Click);
            row5Button5.Click += (Tile_Click);
            row5Button6.Click += (Tile_Click);
            row5Button7.Click += (Tile_Click);
            row5Button8.Click += (Tile_Click);

            row6Button1.Click += (Tile_Click);
            row6Button2.Click += (Tile_Click);
            row6Button3.Click += (Tile_Click);
            row6Button4.Click += (Tile_Click);
            row6Button5.Click += (Tile_Click);
            row6Button6.Click += (Tile_Click);
            row6Button7.Click += (Tile_Click);
            row6Button8.Click += (Tile_Click);

            row7Button1.Click += (Tile_Click);
            row7Button2.Click += (Tile_Click);
            row7Button3.Click += (Tile_Click);
            row7Button4.Click += (Tile_Click);
            row7Button5.Click += (Tile_Click);
            row7Button6.Click += (Tile_Click);
            row7Button7.Click += (Tile_Click);
            row7Button8.Click += (Tile_Click);

            row8Button1.Click += (Tile_Click);
            row8Button2.Click += (Tile_Click);
            row8Button3.Click += (Tile_Click);
            row8Button4.Click += (Tile_Click);
            row8Button5.Click += (Tile_Click);
            row8Button6.Click += (Tile_Click);
            row8Button7.Click += (Tile_Click);
            row8Button8.Click += (Tile_Click);

            UpdateForm(bomb, logFileWriter, moduleSelection);
        }

        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelection
        )
        {
            Bomb = bomb;
            ModuleSelectionForm = moduleSelection;
            LogFileWriter = logFileWriter;

            row1Button1.BackColor = Color.White;
            row1Button2.BackColor = Color.White;
            row1Button3.BackColor = Color.White;
            row1Button4.BackColor = Color.White;
            row1Button5.BackColor = Color.White;
            row1Button6.BackColor = Color.White;
            row1Button7.BackColor = Color.White;
            row1Button8.BackColor = Color.White;

            row2Button1.BackColor = Color.White;
            row2Button2.BackColor = Color.White;
            row2Button3.BackColor = Color.White;
            row2Button4.BackColor = Color.White;
            row2Button5.BackColor = Color.White;
            row2Button6.BackColor = Color.White;
            row2Button7.BackColor = Color.White;
            row2Button8.BackColor = Color.White;

            row3Button1.BackColor = Color.White;
            row3Button2.BackColor = Color.White;
            row3Button3.BackColor = Color.White;
            row3Button4.BackColor = Color.White;
            row3Button5.BackColor = Color.White;
            row3Button6.BackColor = Color.White;
            row3Button7.BackColor = Color.White;
            row3Button8.BackColor = Color.White;

            row4Button1.BackColor = Color.White;
            row4Button2.BackColor = Color.White;
            row4Button3.BackColor = Color.White;
            row4Button4.BackColor = Color.White;
            row4Button5.BackColor = Color.White;
            row4Button6.BackColor = Color.White;
            row4Button7.BackColor = Color.White;
            row4Button8.BackColor = Color.White;

            row5Button1.BackColor = Color.White;
            row5Button2.BackColor = Color.White;
            row5Button3.BackColor = Color.White;
            row5Button4.BackColor = Color.White;
            row5Button5.BackColor = Color.White;
            row5Button6.BackColor = Color.White;
            row5Button7.BackColor = Color.White;
            row5Button8.BackColor = Color.White;

            row6Button1.BackColor = Color.White;
            row6Button2.BackColor = Color.White;
            row6Button3.BackColor = Color.White;
            row6Button4.BackColor = Color.White;
            row6Button5.BackColor = Color.White;
            row6Button6.BackColor = Color.White;
            row6Button7.BackColor = Color.White;
            row6Button8.BackColor = Color.White;

            row7Button1.BackColor = Color.White;
            row7Button2.BackColor = Color.White;
            row7Button3.BackColor = Color.White;
            row7Button4.BackColor = Color.White;
            row7Button5.BackColor = Color.White;
            row7Button6.BackColor = Color.White;
            row7Button7.BackColor = Color.White;
            row7Button8.BackColor = Color.White;

            row8Button1.BackColor = Color.White;
            row8Button2.BackColor = Color.White;
            row8Button3.BackColor = Color.White;
            row8Button4.BackColor = Color.White;
            row8Button5.BackColor = Color.White;
            row8Button6.BackColor = Color.White;
            row8Button7.BackColor = Color.White;
            row8Button8.BackColor = Color.White;
        }

        public void Tile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Black;
            }
            else
            {
                button.BackColor = Color.White;
            }
        }

        private bool GetInput(System.Windows.Forms.Button button)
        {
            return button.BackColor == Color.White;
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
            bool[,] grid = new bool[8, 8];

            grid[0, 0] = GetInput(row1Button1);
            grid[0, 1] = GetInput(row1Button2);
            grid[0, 2] = GetInput(row1Button3);
            grid[0, 3] = GetInput(row1Button4);
            grid[0, 4] = GetInput(row1Button5);
            grid[0, 5] = GetInput(row1Button6);
            grid[0, 6] = GetInput(row1Button7);
            grid[0, 7] = GetInput(row1Button8);

            grid[1, 0] = GetInput(row2Button1);
            grid[1, 1] = GetInput(row2Button2);
            grid[1, 2] = GetInput(row2Button3);
            grid[1, 3] = GetInput(row2Button4);
            grid[1, 4] = GetInput(row2Button5);
            grid[1, 5] = GetInput(row2Button6);
            grid[1, 6] = GetInput(row2Button7);
            grid[1, 7] = GetInput(row2Button8);

            grid[2, 0] = GetInput(row3Button1);
            grid[2, 1] = GetInput(row3Button2);
            grid[2, 2] = GetInput(row3Button3);
            grid[2, 3] = GetInput(row3Button4);
            grid[2, 4] = GetInput(row3Button5);
            grid[2, 5] = GetInput(row3Button6);
            grid[2, 6] = GetInput(row3Button7);
            grid[2, 7] = GetInput(row3Button8);

            grid[3, 0] = GetInput(row4Button1);
            grid[3, 1] = GetInput(row4Button2);
            grid[3, 2] = GetInput(row4Button3);
            grid[3, 3] = GetInput(row4Button4);
            grid[3, 4] = GetInput(row4Button5);
            grid[3, 5] = GetInput(row4Button6);
            grid[3, 6] = GetInput(row4Button7);
            grid[3, 7] = GetInput(row4Button8);

            grid[4, 0] = GetInput(row5Button1);
            grid[4, 1] = GetInput(row5Button2);
            grid[4, 2] = GetInput(row5Button3);
            grid[4, 3] = GetInput(row5Button4);
            grid[4, 4] = GetInput(row5Button5);
            grid[4, 5] = GetInput(row5Button6);
            grid[4, 6] = GetInput(row5Button7);
            grid[4, 7] = GetInput(row5Button8);

            grid[5, 0] = GetInput(row6Button1);
            grid[5, 1] = GetInput(row6Button2);
            grid[5, 2] = GetInput(row6Button3);
            grid[5, 3] = GetInput(row6Button4);
            grid[5, 4] = GetInput(row6Button5);
            grid[5, 5] = GetInput(row6Button6);
            grid[5, 6] = GetInput(row6Button7);
            grid[5, 7] = GetInput(row6Button8);

            grid[6, 0] = GetInput(row7Button1);
            grid[6, 1] = GetInput(row7Button2);
            grid[6, 2] = GetInput(row7Button3);
            grid[6, 3] = GetInput(row7Button4);
            grid[6, 4] = GetInput(row7Button5);
            grid[6, 5] = GetInput(row7Button6);
            grid[6, 6] = GetInput(row7Button7);
            grid[6, 7] = GetInput(row7Button8);

            grid[7, 0] = GetInput(row8Button1);
            grid[7, 1] = GetInput(row8Button2);
            grid[7, 2] = GetInput(row8Button3);
            grid[7, 3] = GetInput(row8Button4);
            grid[7, 4] = GetInput(row8Button5);
            grid[7, 5] = GetInput(row8Button6);
            grid[7, 6] = GetInput(row8Button7);
            grid[7, 7] = GetInput(row8Button8);

            Bitmaps module = new Bitmaps(grid, Bomb, LogFileWriter);

            PrintHeader();

            module.Solve(false);

            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }
    }
}
