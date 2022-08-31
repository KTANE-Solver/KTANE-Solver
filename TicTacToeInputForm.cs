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
    public partial class TicTacToeInputForm : ModuleForm
    {
        private TicTacToe module;
        private TicTacToeSymbolForm symbolForm;
        private TicTacToeForm initialForm;

        public TicTacToeInputForm(
            TicTacToe module,
            TicTacToeSymbolForm symbolForm,
            TicTacToeForm initialForm
        ) : base()
        {
            InitializeComponent();

            this.module = module;
            this.symbolForm = symbolForm;
            this.initialForm = initialForm;

            topLeftButton.Click += Tile_Click;
            topMiddleButton.Click += Tile_Click;
            topRightButton.Click += Tile_Click;

            middleLeftButton.Click += Tile_Click;
            middleButton.Click += Tile_Click;
            middleRightButton.Click += Tile_Click;

            bottomLeftButton.Click += Tile_Click;
            bottomMiddleButton.Click += Tile_Click;
            bottomRightButton.Click += Tile_Click;

            UpdateForm();
        }

        public void UpdateForm()
        {
            topLeftButton.BackColor = Color.White;
            topMiddleButton.BackColor = Color.White;
            topRightButton.BackColor = Color.White;

            middleLeftButton.BackColor = Color.White;
            middleButton.BackColor = Color.White;
            middleRightButton.BackColor = Color.White;

            bottomLeftButton.BackColor = Color.White;
            bottomMiddleButton.BackColor = Color.White;
            bottomRightButton.BackColor = Color.White;

            string[] arr = new string[] { "X", "O" };
            symbolComboBox.Items.Clear();
            symbolComboBox.Items.AddRange(arr);
            symbolComboBox.Text = arr[0];
            symbolComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void Tile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Red;
            }
            else
            {
                button.BackColor = Color.White;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button[] buttonArr = new System.Windows.Forms.Button[]
            {
                topLeftButton,
                topMiddleButton,
                topRightButton,
                middleLeftButton,
                middleButton,
                middleRightButton,
                bottomLeftButton,
                bottomMiddleButton,
                bottomRightButton
            };
            int buttonNum = 0;

            foreach (System.Windows.Forms.Button b in buttonArr)
            {
                if (b.BackColor == Color.Red)
                {
                    buttonNum++;
                }
            }

            if (buttonNum != 1)
            {
                ShowErrorMessage("Can only have 1 button highlighted");
                return;
            }

            int index = -1;
            for (int i = 0; i < 9; i++)
            {
                if (buttonArr[i].BackColor == Color.Red)
                {
                    index = i;
                    break;
                }
            }

            module.SetSymbolPosition(index / 3, index % 3, symbolComboBox.Text[0]);

            this.Hide();

            symbolForm.UpdateForm();

            symbolForm.Show();
        }
    }
}
