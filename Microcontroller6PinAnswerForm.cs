﻿using System;
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
    public partial class Microcontroller6PinAnswerForm: Form
    {
        public Microcontroller6PinAnswerForm(
            Color button1Color,
            Color button2Color,
            Color button3Color,
            Color button4Color,
            Color button5Color,
            Color button6Color
        )
        {
            InitializeComponent();
            button1.BackColor = button1Color;
            button2.BackColor = button2Color;
            button3.BackColor = button3Color;
            button4.BackColor = button4Color;
            button5.BackColor = button5Color;
            button6.BackColor = button6Color;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
