using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Shows the answer for Adjacent Letters
    /// </summary>
    public partial class AdjacentLettersAnswerForm : ModuleForm
    {
        public AdjacentLettersAnswerForm(bool[,] answer, StreamWriter logFileWriter)
            : base(null, logFileWriter, null, "Adjacent Letters", true)
        {
            LogFileWriter = logFileWriter;

            InitializeComponent();

            row1Button1.BackColor = GetColor(answer[0, 0]);
            row1Button2.BackColor = GetColor(answer[0, 1]);
            row1Button3.BackColor = GetColor(answer[0, 2]);
            row1Button4.BackColor = GetColor(answer[0, 3]);

            row2Button1.BackColor = GetColor(answer[1, 0]);
            row2Button2.BackColor = GetColor(answer[1, 1]);
            row2Button3.BackColor = GetColor(answer[1, 2]);
            row2Button4.BackColor = GetColor(answer[1, 3]);

            row3Button1.BackColor = GetColor(answer[2, 0]);
            row3Button2.BackColor = GetColor(answer[2, 1]);
            row3Button3.BackColor = GetColor(answer[2, 2]);
            row3Button4.BackColor = GetColor(answer[2, 3]);

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    if (answer[row, column])
                    {
                        PrintDebug("* ");
                    }
                    else
                    {
                        PrintDebug(". ");
                    }
                }

                PrintDebugLine("");
            }

            PrintDebugLine("");

            Text = ModuleName + " Answer";
        }

        private Color GetColor(bool b)
        {
            if (b)
            {
                return Color.Green;
            }

            return Color.White;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
