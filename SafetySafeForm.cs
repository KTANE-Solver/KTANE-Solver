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
    public partial class SafetySafeForm : ModuleForm
    {
        public SafetySafeForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Safety Safe", false)
        {
            InitializeComponent();

            SafetySafe module = new SafetySafe(Bomb, LogFileWriter);

            int[] answer = module.Solve();

            topLeftLabel.Text = $"Top Left: {answer[0]}";
            topMidLabel.Text = $"Top Mid: {answer[1]}";
            topRightLabel.Text = $"Top Right: {answer[2]}";
            bottomLeftLabel.Text = $"Bottom Left: {answer[3]}";
            bottomMidLabel.Text = $"Bottom Mid: {answer[4]}";
            bottomRightLabel.Text = $"Bottom Right: {answer[5]}";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }
    }
}
