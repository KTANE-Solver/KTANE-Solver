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
    public partial class BlindAlleyForm : ModuleForm
    {
        public BlindAlleyForm()
        {
            InitializeComponent();
        }

        public BlindAlleyForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Blind Alley", false)
        {
            InitializeComponent();

            BlindAlley module = new BlindAlley(bomb, logFileWriter);

            string answer = module.Solve();

            answerLabel.Text = answer;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void answerLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
