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
    public partial class TicTacToeAnswerForm : Form
    {
        public TicTacToeAnswerForm(int row, int column)
        {
            row++;
            column++;

            int index = (row - 1) * 3 + column;
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button6.Enabled = false;
            button5.Enabled = false;
            button4.Enabled = false;
            button9.Enabled = false;
            button8.Enabled = false;
            button7.Enabled = false;

            switch (index)
            {
                case 1:
                    button1.BackColor = Color.Red;
                    break;
                case 2:
                    button2.BackColor = Color.Red;
                    break;
                case 3:
                    button3.BackColor = Color.Red;
                    break;
                case 4:
                    button4.BackColor = Color.Red;
                    break;
                case 5:
                    button5.BackColor = Color.Red;
                    break;
                case 6:
                    button6.BackColor = Color.Red;
                    break;
                case 7:
                    button7.BackColor = Color.Red;
                    break;
                case 8:
                    button8.BackColor = Color.Red;
                    break;
                case 9:
                    button9.BackColor = Color.Red;
                    break;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
