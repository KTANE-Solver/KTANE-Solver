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
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Gets information needed to solve the number pad module
    /// </summary>
    public partial class NumberPadForm : ModuleForm
    {
        public NumberPadForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Number Pad", false)
        {
            InitializeComponent();

            oneButton.Click += new EventHandler(numberButton_Click);
            twoButton.Click += new EventHandler(numberButton_Click);
            threeButton.Click += new EventHandler(numberButton_Click);
            fourButton.Click += new EventHandler(numberButton_Click);
            fiveButton.Click += new EventHandler(numberButton_Click);
            sixButton.Click += new EventHandler(numberButton_Click);
            sevenButton.Click += new EventHandler(numberButton_Click);
            eightButton.Click += new EventHandler(numberButton_Click);
            nineButton.Click += new EventHandler(numberButton_Click);
            zeroButton.Click += new EventHandler(numberButton_Click);

            UpdateForm(bomb, logFileWriter, moduleSelectionForm);
        }

        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            oneButton.BackColor = Color.White;
            twoButton.BackColor = Color.White;
            threeButton.BackColor = Color.White;
            fourButton.BackColor = Color.White;
            fiveButton.BackColor = Color.White;
            sixButton.BackColor = Color.White;
            sevenButton.BackColor = Color.White;
            eightButton.BackColor = Color.White;
            nineButton.BackColor = Color.White;
            zeroButton.BackColor = Color.White;
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Red;
            }
            else if (button.BackColor == Color.Red)
            {
                button.BackColor = Color.Yellow;
            }
            else if (button.BackColor == Color.Yellow)
            {
                button.BackColor = Color.Green;
            }
            else if (button.BackColor == Color.Green)
            {
                button.BackColor = Color.Blue;
            }
            else
            {
                button.BackColor = Color.White;
            }
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
            Color zeroColor = zeroButton.BackColor;
            Color oneColor = oneButton.BackColor;
            Color twoColor = twoButton.BackColor;
            Color threeColor = threeButton.BackColor;
            Color fourColor = fourButton.BackColor;
            Color fiveColor = fiveButton.BackColor;
            Color sixColor = sixButton.BackColor;
            Color sevenColor = sevenButton.BackColor;
            Color eightColor = eightButton.BackColor;
            Color nineColor = nineButton.BackColor;

            PrintHeader();

            NumberPad module = new NumberPad(
                zeroColor,
                oneColor,
                twoColor,
                threeColor,
                fourColor,
                fiveColor,
                sixColor,
                sevenColor,
                eightColor,
                nineColor,
                Bomb,
                LogFileWriter
            );
            module.Solve();

            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }
    }
}
