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
    public partial class SkewedSlotForm : ModuleForm
    {
        public SkewedSlotForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Skewed Slots", false)
        {
            InitializeComponent();
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
            if (textBox1.Text.Length != 3)
            {
                ShowErrorMessage("Text box must contain a 3 digit number");
                return;
            }

            int num;

            try
            {
                num = int.Parse(textBox1.Text);
            }
            catch
            {
                ShowErrorMessage("Text box must contain a 3 digit number");
                return;
            }

            SkewedSlots module = new SkewedSlots(Bomb, LogFileWriter, num);
            module.Solve();

            textBox1.Text = "";
        }
    }
}
