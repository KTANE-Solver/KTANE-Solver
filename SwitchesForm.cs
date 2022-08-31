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
    /// Purpose: Gets information needed to solve the switches module
    /// </summary>

    public partial class SwitchesForm : ModuleForm
    {
        public SwitchesForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Switches", false)
        {
            InitializeComponent();
            UpdateForm(bomb, logFileWriter, moduleSelectionForm);

            start1.Click += Tile_Click;
            start2.Click += Tile_Click;
            start3.Click += Tile_Click;
            start4.Click += Tile_Click;
            start5.Click += Tile_Click;

            end1.Click += Tile_Click;
            end2.Click += Tile_Click;
            end3.Click += Tile_Click;
            end4.Click += Tile_Click;
            end5.Click += Tile_Click;
        }

        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            start1.BackColor = Color.White;
            start2.BackColor = Color.White;
            start3.BackColor = Color.White;
            start4.BackColor = Color.White;
            start5.BackColor = Color.White;

            end1.BackColor = Color.White;
            end2.BackColor = Color.White;
            end3.BackColor = Color.White;
            end4.BackColor = Color.White;
            end5.BackColor = Color.White;
        }

        public void Tile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

            if (button.BackColor == Color.White)
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

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            bool[] start =
            {
                SwitchedOn(start1),
                SwitchedOn(start2),
                SwitchedOn(start3),
                SwitchedOn(start4),
                SwitchedOn(start5)
            };
            bool[] end =
            {
                SwitchedOn(end1),
                SwitchedOn(end2),
                SwitchedOn(end3),
                SwitchedOn(end4),
                SwitchedOn(end5)
            };

            if (SameSwitches(start, end))
            {
                ShowErrorMessage("Really?");
                return;
            }

            PrintHeader();

            Switches module = new Switches(start, end, Bomb, LogFileWriter);
            module.Solve();
            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }

        private bool SameSwitches(bool[] start, bool[] end)
        {
            for (int i = 0; i < 5; i++)
            {
                if (start[i] != end[i])
                    return false;
            }

            return true;
        }

        public bool SwitchedOn(System.Windows.Forms.Button b)
        {
            return b.BackColor == Color.Green;
        }
    }
}
