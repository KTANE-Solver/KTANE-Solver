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
    public partial class RoundKeypadAnswerForm : Form
    {
        public RoundKeypadAnswerForm(RoundKeypad.Symbol[] buttonArr, RoundKeypad.Symbol[] answer)
        {
            InitializeComponent();

            List<System.Windows.Forms.Button> buttonList = new List<System.Windows.Forms.Button>()
            {
                northButton,
                northEastButton,
                eastButton,
                southEastButton,
                southButton,
                southWestButton,
                westButton,
                northWestButton
            };

            for (int i = 0; i < buttonList.Count; i++)
            {
                if (answer.Contains(buttonArr[i]))
                {
                    buttonList[i].BackColor = Color.Red;
                }
            }
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
