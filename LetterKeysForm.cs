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
    public partial class LetterKeysForm : ModuleForm
    {
        public LetterKeysForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Letter Keys", false)
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            int num;

            try
            {
                num = int.Parse(textBox1.Text);
            }
            catch
            {
                ShowErrorMessage("Textbox can only contain a number between 0 and 99");
                return;
            }

            if (num < 0 || num > 99)
            {
                ShowErrorMessage("Textbox can only contain a number between 0 and 99");
                return;
            }

            LetterKeys module = new LetterKeys(Bomb, LogFileWriter, num);
            module.Solve(false);

            textBox1.Text = "";
        }

        private void stikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }
    }
}
