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
    public partial class MicrocontrollerForm : ModuleForm
    {
        public MicrocontrollerForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Microcontroller", false)
        {
            InitializeComponent();
            UpdateForm();
        }

        private void UpdateForm()
        {
            secondNumTextBox.Text = "";
            LastNumTextBox.Text = "";
            pinNumTextBox.Text = "";

            string[] controller = new string[] { "CNTD", "EXPL", "LEDS", "STRK" };

            controllerTypeComboBox.Items.Clear();
            controllerTypeComboBox.Items.AddRange(controller);

            controllerTypeComboBox.Text = controller[0];

            controllerTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            string[] corner = new string[]
            {
                "Top Left",
                "Top Right",
                "Bottom Left",
                "Bottom Right"
            };

            whiteDotComboBox.Items.Clear();
            whiteDotComboBox.Items.AddRange(corner);

            whiteDotComboBox.Text = corner[0];

            whiteDotComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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
            string secondNumStr = secondNumTextBox.Text;
            string lastNumStr = LastNumTextBox.Text;
            string pinNumStr = pinNumTextBox.Text;
            int secondNum;
            int lastNum;
            int pinNum;

            if (secondNumStr.Length != 1 || lastNumStr.Length != 1)
            {
                ShowErrorMessage("Serial Digit Text Boxes can only take 1 number");
                return;
            }

            try
            {
                secondNum = int.Parse(secondNumStr);
            }
            catch
            {
                ShowErrorMessage("Second Num Text Box can only take numbers");
                return;
            }

            try
            {
                lastNum = int.Parse(lastNumStr);
            }
            catch
            {
                ShowErrorMessage("Last Num Text Box can only take numbers");
                return;
            }

            try
            {
                pinNum = int.Parse(pinNumStr);
            }
            catch
            {
                ShowErrorMessage("Pin Num Text Box can only take numbers");
                return;
            }

            if (pinNum != 6 && pinNum != 8 && pinNum != 10)
            {
                ShowErrorMessage("# of pins can only be 6, 8, or 10");
                return;
            }

            Microcontroller module = new Microcontroller(
                Bomb,
                LogFileWriter,
                whiteDotComboBox.Text,
                controllerTypeComboBox.Text,
                pinNum,
                secondNum,
                lastNum
            );
            List<Color> answer = module.Solve();

            Microcontroller6PinAnswerForm sixForm = null;
            Microcontroller8PinAnswerForm eigthForm = null;
            Microcontroller10PinAnswerForm tenForm = null;

            if (answer.Count == 6)
            {
                sixForm = new Microcontroller6PinAnswerForm(
                    Bomb,
                    LogFileWriter,
                    ModuleSelectionForm,
                    answer[0],
                    answer[1],
                    answer[2],
                    answer[3],
                    answer[4],
                    answer[5]
                );
                sixForm.ShowDialog();
            }
            else if (answer.Count == 8)
            {
                eigthForm = new Microcontroller8PinAnswerForm(
                    Bomb,
                    LogFileWriter,
                    ModuleSelectionForm,
                    answer[0],
                    answer[1],
                    answer[2],
                    answer[3],
                    answer[4],
                    answer[5],
                    answer[6],
                    answer[7]
                );
                eigthForm.ShowDialog();
            }
            else
            {
                tenForm = new Microcontroller10PinAnswerForm(
                    Bomb,
                    LogFileWriter,
                    ModuleSelectionForm,
                    answer[0],
                    answer[1],
                    answer[2],
                    answer[3],
                    answer[4],
                    answer[5],
                    answer[6],
                    answer[7],
                    answer[8],
                    answer[9]
                );
                tenForm.ShowDialog();
            }

            UpdateForm();
        }
    }
}
