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
    public partial class Microcontroller10PinAnswerForm : ModuleForm
    {
        public Microcontroller10PinAnswerForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm,
            Color button1Color,
            Color button2Color,
            Color button3Color,
            Color button4Color,
            Color button5Color,
            Color button6Color,
            Color button7Color,
            Color button8Color,
            Color button9Color,
            Color button10Color
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Microcontroller", true)
        {
            InitializeComponent();
            button1.BackColor = button1Color;
            button2.BackColor = button2Color;
            button3.BackColor = button3Color;
            button4.BackColor = button4Color;
            button5.BackColor = button5Color;
            button6.BackColor = button6Color;
            button7.BackColor = button7Color;
            button8.BackColor = button8Color;
            button9.BackColor = button9Color;
            button10.BackColor = button10Color;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
