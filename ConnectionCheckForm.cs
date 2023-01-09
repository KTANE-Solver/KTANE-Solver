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
    public partial class ConnectionCheckForm : ModuleForm
    {
        public ConnectionCheckForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Connection Check", false)
        {
            InitializeComponent();
        }

        private void UpdateForm()
        {
            topLeftTextBox.Text = "";
            topRightTextBox.Text = "";
            bottomLeftTextBox.Text = "";
            bottomRightTextBox.Text = "";
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
            string topLeft = topLeftTextBox.Text;
            string topRight = topRightTextBox.Text;
            string bottomLeft = bottomLeftTextBox.Text;
            string bottomRight = bottomRightTextBox.Text;

            if (
                !ValidTextBox(topLeft)
                || !ValidTextBox(topRight)
                || !ValidTextBox(bottomLeft)
                || !ValidTextBox(bottomRight)
            )
            {
                return;
            }

            int[] topLeftArr = new int[] { int.Parse("" + topLeft[0]), int.Parse("" + topLeft[1]) };
            int[] topRightArr = new int[]
            {
                int.Parse("" + topRight[0]),
                int.Parse("" + topRight[1])
            };
            int[] bottomLeftArr = new int[]
            {
                int.Parse("" + bottomLeft[0]),
                int.Parse("" + bottomLeft[1])
            };
            int[] bottomRightArr = new int[]
            {
                int.Parse("" + bottomRight[0]),
                int.Parse("" + bottomRight[1])
            };

            ConnectionCheck module = new ConnectionCheck(
                topLeftArr,
                topRightArr,
                bottomLeftArr,
                bottomRightArr,
                Bomb,
                LogFileWriter
            );
            module.Solve(false);
            UpdateForm();
        }

        private bool ValidTextBox(string str)
        {
            if (str.Length != 2)
            {
                ShowErrorMessage("Text boxes can only have 2 numbers");
                return false;
            }

            if (str[0] == str[1])
            {
                ShowErrorMessage("Numbers in the same text box can't be the same");
                return false;
            }

            try
            {
                int.Parse("" + str[0]);
                int.Parse("" + str[1]);
            }
            catch
            {
                ShowErrorMessage("Text boxes can only have 2 numbers");
                return false;
            }

            return true;
        }
    }
}
