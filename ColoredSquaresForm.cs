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
    public partial class ColoredSquaresForm : ModuleForm
    {
        private ColoredSquares.Color[,] moduleGrid;
        private ColoredSquares module;
        private ColoredSquares.Color color;
        private List<System.Windows.Forms.Button> buttonList;

        public ColoredSquaresForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Colored Squares", false)
        {
            InitializeComponent();

            buttonList = new List<System.Windows.Forms.Button>();

            buttonList.AddRange(
                new System.Windows.Forms.Button[]
                {
                    row1Button1,
                    row1Button2,
                    row1Button3,
                    row1Button4,
                    row2Button1,
                    row2Button2,
                    row2Button3,
                    row2Button4,
                    row3Button1,
                    row3Button2,
                    row3Button3,
                    row3Button4,
                    row4Button1,
                    row4Button2,
                    row4Button3,
                    row4Button4
                }
            );

            UpdateForm();

            foreach (System.Windows.Forms.Button b in buttonList)
            {
                b.Click += Tile_Click;
            }
        }

        public void UpdateForm()
        {
            SetButtonsWhite();

            moduleGrid = null;
        }

        public void Tile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

            if (ButtonGoodToClick(button))
            {
                if (button.BackColor == Color.White)
                {
                    button.BackColor = Color.Red;
                }
                else if (button.BackColor == Color.Red)
                {
                    button.BackColor = Color.Blue;
                }
                else if (button.BackColor == Color.Blue)
                {
                    button.BackColor = Color.Green;
                }
                else if (button.BackColor == Color.Green)
                {
                    button.BackColor = Color.Yellow;
                }
                else if (button.BackColor == Color.Yellow)
                {
                    button.BackColor = Color.Magenta;
                }
                else
                {
                    button.BackColor = Color.White;
                }
            }
        }

        private void SetButtonsWhite()
        {
            foreach (System.Windows.Forms.Button b in buttonList)
            {
                b.BackColor = Color.White;
            }
        }

        private bool ButtonGoodToClick(System.Windows.Forms.Button b)
        {
            if (moduleGrid == null)
                return true;

            int index = buttonList.IndexOf(b);

            int row = index / 4;
            int col = index % 4;

            return moduleGrid[row, col] != ColoredSquares.Color.White;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (moduleGrid == null)
            {
                if (!GoodButtonsNotWhiteNullGrid())
                {
                    ShowErrorMessage("All buttons need colors that are not white");
                    return;
                }

                moduleGrid = ConvertForm();

                module = new ColoredSquares(moduleGrid, Bomb, LogFileWriter);

                module.PrintGrid();

                color = module.GetFirstColor();
            }
            else if (module.ColorNum(ColoredSquares.Color.White) < 15)
            {
                if (!GoodButtonsNotWhite())
                {
                    ShowErrorMessage("Some buttons are white that are not supposed to be");
                    return;
                }

                moduleGrid = ConvertForm();

                module.grid = moduleGrid;

                module.PrintGrid();

                color = module.Solve(color);
            }

            SetButtonsWhite();

            if (module.ColorNum(ColoredSquares.Color.White) >= 15)
            {
                UpdateForm();
            }
        }

        private bool GoodButtonsNotWhite()
        {
            for (int i = 0; i < 16; i++)
            {
                System.Windows.Forms.Button b = buttonList[i];

                int row = i / 4;
                int col = i % 4;

                bool buttonWhite = b.BackColor == Color.White;
                bool gridWhite = moduleGrid[row, col] == ColoredSquares.Color.White;

                if (buttonWhite != gridWhite)
                {
                    return false;
                }
            }

            return true;
        }

        private bool GoodButtonsNotWhiteNullGrid()
        {
            foreach (System.Windows.Forms.Button b in buttonList)
            {
                if (b.BackColor == Color.White)
                {
                    return false;
                }
            }

            return true;
        }

        private ColoredSquares.Color[,] ConvertForm()
        {
            ColoredSquares.Color[,] grid = new ColoredSquares.Color[4, 4];

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int index = row * 4 + col;

                    grid[row, col] = ConvertFormColor(buttonList[index].BackColor);
                }
            }

            return grid;
        }

        private ColoredSquares.Color ConvertFormColor(Color c)
        {
            if (c == Color.Red)
            {
                return ColoredSquares.Color.Red;
            }

            if (c == Color.Blue)
            {
                return ColoredSquares.Color.Blue;
            }

            if (c == Color.Green)
            {
                return ColoredSquares.Color.Green;
            }

            if (c == Color.Yellow)
            {
                return ColoredSquares.Color.Yellow;
            }

            if (c == Color.White)
            {
                return ColoredSquares.Color.White;
            }

            return ColoredSquares.Color.Magenta;
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
