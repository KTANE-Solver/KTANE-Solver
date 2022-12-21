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
    /// Date: 3/1/21
    /// Purpose: Prompts the user to give edgework
    /// </summary>
    public partial class EdgeworkInputForm : Form
    {

        //FIELDS


        //the form the user will go to when they press submit
        private EdgeworkConfirmationForm confirmationForm;

        //the bomb that will be careated
        private Bomb bomb;

        //used to write to the log file
        private StreamWriter logFileWriter;

        //Maze Colors
        private Color[] mazeColors;

        private PlateForm plateForm;

        //PROPERTIES

        //CONSTRUCTOR
        /// <summary>
        /// Creates an instance of the
        /// form that will be used to
        /// input edgework
        /// </summary>
        public EdgeworkInputForm(StreamWriter logFileWriter)
        {
            InitializeComponent();
            this.logFileWriter = logFileWriter;
            UpdateForm();
        }

        /// <summary>
        /// Creates an instance of the
        /// form that will be used to
        /// input edgework
        /// </summary>
        /// <param name="confirmationForm">the confirm form the user will go to</param>
        public EdgeworkInputForm(
            EdgeworkConfirmationForm confirmationForm,
            StreamWriter logFileWriter,
            Color[] mazeColors
        )
        {
            InitializeComponent();
            this.mazeColors = mazeColors;
            this.logFileWriter = logFileWriter;
            UpdateForm();
            this.confirmationForm = confirmationForm;
        }

        /// <summary>
        /// Sets up the form so
        /// it looks good as new
        /// </summary>
        public void UpdateForm()
        {
            SetUpDayOfWeekComboBox();

            //reset checkBoxes
            SetupCheckBoxes(bobVisibleCheckBox, bobLitCheckBox);
            SetupCheckBoxes(carVisibleCheckBox, carLitCheckBox);
            SetupCheckBoxes(clrVisibleCheckBox, clrLitCheckBox);
            SetupCheckBoxes(indVisibleCheckBox, indLitCheckBox);
            SetupCheckBoxes(frkVisibleCheckBox, frkLitCheckBox);
            SetupCheckBoxes(frqVisibleCheckBox, frqLitCheckBox);
            SetupCheckBoxes(msaVisibleCheckBox, msaLitCheckBox);
            SetupCheckBoxes(nsaVisibleCheckBox, nsaLitCheckBox);
            SetupCheckBoxes(sigVisibleCheckBox, sigLitCheckBox);
            SetupCheckBoxes(sndVisibleCheckBox, sndLitCheckBox);
            SetupCheckBoxes(trnVisibleCheckBox, trnLitCheckBox);

            //setting promppt text for battery and port textboxes
            serialNumberTextBox.Text = "";
            SetPromptText(batteryTextBox, "# of batteries");
            SetPromptText(batteryHolderTextBox, "# of battery holders");

            //setting the order of tab control
            dayOfWeekComboBox.TabIndex = 0;
            serialNumberTextBox.TabIndex = 1;
            batteryTextBox.TabIndex = 2;
            batteryHolderTextBox.TabIndex = 3;
            portPlateNumTextBox.TabIndex = 4;

            //labels shouldn't be in the tab order
            dayOfWeekLabel.TabStop = false;
            serialNumberLabel.TabStop = false;
            batteryLabel.TabStop = false;
            batteryHolderLabel.TabStop = false;

            indicatorLabel.TabStop = false;
            bobLabel.TabStop = false;
            carLabel.TabStop = false;
            clrLabel.TabStop = false;
            frkLabel.TabStop = false;
            frqLabel.TabStop = false;
            indLabel.TabStop = false;
            msaLabel.TabStop = false;
            nsaLabel.TabStop = false;
            sigLabel.TabStop = false;
            trnLabel.TabStop = false;

            portLabel.TabStop = false;

            //checkbox shouldn't be in the tab order
            bobVisibleCheckBox.TabStop = false;
            bobLitCheckBox.TabStop = false;

            carVisibleCheckBox.TabStop = false;
            carLitCheckBox.TabStop = false;

            clrVisibleCheckBox.TabStop = false;
            clrLitCheckBox.TabStop = false;

            frkVisibleCheckBox.TabStop = false;
            frkLitCheckBox.TabStop = false;

            frqVisibleCheckBox.TabStop = false;
            frqLitCheckBox.TabStop = false;

            indVisibleCheckBox.TabStop = false;
            indLitCheckBox.TabStop = false;

            msaVisibleCheckBox.TabStop = false;
            msaLitCheckBox.TabStop = false;

            nsaVisibleCheckBox.TabStop = false;
            nsaLitCheckBox.TabStop = false;

            sigVisibleCheckBox.TabStop = false;
            sigLitCheckBox.TabStop = false;

            sndVisibleCheckBox.TabStop = false;
            sndLitCheckBox.TabStop = false;

            trnVisibleCheckBox.TabStop = false;
            trnLitCheckBox.TabStop = false;
        }

        //METHODS
        /// <summary>
        /// Sets up the combo box
        /// </summary>
        private void SetUpDayOfWeekComboBox()
        {
            String[] days = new String[]
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday"
            };
            dayOfWeekComboBox.Items.Clear();
            dayOfWeekComboBox.Items.AddRange(days);
            dayOfWeekComboBox.Text = "Sunday";

            this.dayOfWeekComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Sets the checkBoxes to unchecked
        /// </summary>
        /// <param name="visibleCheckBox">the checkBox that tells if an indicator is visible</param>
        /// <param name="litCheckBox">the checkBox that tells if an indicator is lit</param>
        private void SetupCheckBoxes(CheckBox visibleCheckBox, CheckBox litCheckBox)
        {
            visibleCheckBox.Checked = false;
            litCheckBox.Checked = false;
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void bobVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!bobVisibleCheckBox.Checked)
            {
                bobLitCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void bobLitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (bobLitCheckBox.Checked)
            {
                bobVisibleCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void carVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!carVisibleCheckBox.Checked)
            {
                carLitCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void carLitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (carLitCheckBox.Checked)
            {
                carVisibleCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void clrVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!clrVisibleCheckBox.Checked)
            {
                clrLitCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void clrLitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (clrLitCheckBox.Checked)
            {
                clrVisibleCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void frkVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!frkVisibleCheckBox.Checked)
            {
                frkLitCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void frkLitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (frkLitCheckBox.Checked)
            {
                frkVisibleCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void frqVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!frqVisibleCheckBox.Checked)
            {
                frqLitCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void frqLitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (frqLitCheckBox.Checked)
            {
                frqVisibleCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void indVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!indVisibleCheckBox.Checked)
            {
                indLitCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void indLitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (indLitCheckBox.Checked)
            {
                indVisibleCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void msaVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!msaVisibleCheckBox.Checked)
            {
                msaLitCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void msaLitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (msaLitCheckBox.Checked)
            {
                msaVisibleCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void nsaVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!nsaVisibleCheckBox.Checked)
            {
                nsaLitCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void nsaLitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (nsaLitCheckBox.Checked)
            {
                nsaVisibleCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void sigVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!sigVisibleCheckBox.Checked)
            {
                sigLitCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void sigLitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sigLitCheckBox.Checked)
            {
                sigVisibleCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void sndVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!sndVisibleCheckBox.Checked)
            {
                sndLitCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void sndLitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sndLitCheckBox.Checked)
            {
                sndVisibleCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void trnVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!trnVisibleCheckBox.Checked)
            {
                trnLitCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Changing the checkbox so an invalid indicator
        /// can't be produed
        /// </summary>
        private void trnLitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (trnLitCheckBox.Checked)
            {
                trnVisibleCheckBox.Checked = true;
            }
        }

        /// <summary>
        /// Confirms that all the edgework is valid
        /// and moves on to the confirmation form
        /// </summary>
        private void submitButton_Click(object sender, EventArgs e)
        {
            Day day;
            Enum.TryParse(dayOfWeekComboBox.Text, out day);

            String serialNumber = serialNumberTextBox.Text.ToUpper();
            bool oneLetter = false;

            //make sure the serial number is valid
            //-textbox can't be blank
            //-at least one letter
            //-the last character is a letter

            if (serialNumberTextBox.Text.Length == 0)
            {
                ShowErrorMessageBox("Invalid serial number", "Serial number can't be blank");
                return;
            }

            for (int i = 0; i < serialNumber.Length; i++)
            {
                if (serialNumber[i] >= 65 && serialNumber[i] <= 90)
                {
                    oneLetter = true;
                    break;
                }
            }

            if (!oneLetter)
            {
                logFileWriter.WriteLine("There isn't a letter in the serial number\n");
                System.Diagnostics.Debug.WriteLine("There isn't a letter in the serial number\n");

                String text =
                    "You entered an invalid serial number. There has to be at least 1 letter in the serial number";

                String caption = "Invalid Serial Number";

                ShowErrorMessageBox(caption, text);

                return;
            }

            if (!Char.IsDigit(serialNumber[serialNumber.Length - 1]))
            {
                string error = "The last character of the serial number isn't a number\n";
                logFileWriter.WriteLine(error);
                System.Diagnostics.Debug.WriteLine(error);

                String text =
                    "You entered an invalid serial number. A valid serial number must have the last character be a number";

                String caption = "Invalid Serial Number";

                ShowErrorMessageBox(caption, text);

                return;
            }

            //make sure the batteries can be parsed into an int
            int battery;

            try
            {
                battery = Int32.Parse(batteryTextBox.Text);
            }
            catch
            {
                String text = "You entered an invalid battery number.";

                String caption = "Invalid Battery";

                ShowErrorMessageBox(caption, text);

                return;
            }

            //make sure the battery holder can be parsed into an int
            int batteryHolder;

            try
            {
                batteryHolder = Int32.Parse(batteryHolderTextBox.Text);
            }
            catch
            {
                String text = "You entered an invalid battery holder number.";

                String caption = "Invalid Battery Holder";

                ShowErrorMessageBox(caption, text);

                return;
            }

            //make sure the number of batteries and battery holders isn't invalid
            if (battery < batteryHolder)
            {
                String text =
                    "The number of batteries can't be less than the number of battery holders";

                String caption = "Invalid Battery Holder and Battery";

                ShowErrorMessageBox(caption, text);

                return;
            }

            if (battery > batteryHolder * 2)
            {
                String text =
                    "The number of batteries can't be greater than twice the number of battery holders";

                String caption = "Invalid Battery Holder and Battery";

                ShowErrorMessageBox(caption, text);

                return;
            }

            //setting the indicators
            Indicator bob = new Indicator(
                "BOB",
                bobVisibleCheckBox.Checked,
                bobLitCheckBox.Checked
            );
            Indicator car = new Indicator(
                "CAR",
                carVisibleCheckBox.Checked,
                carLitCheckBox.Checked
            );
            Indicator clr = new Indicator(
                "CLR",
                clrVisibleCheckBox.Checked,
                clrLitCheckBox.Checked
            );
            Indicator frk = new Indicator(
                "FRK",
                frkVisibleCheckBox.Checked,
                frkLitCheckBox.Checked
            );
            Indicator frq = new Indicator(
                "FRQ",
                frqVisibleCheckBox.Checked,
                frqLitCheckBox.Checked
            );
            Indicator ind = new Indicator(
                "IND",
                indVisibleCheckBox.Checked,
                indLitCheckBox.Checked
            );
            Indicator msa = new Indicator(
                "MSA",
                msaVisibleCheckBox.Checked,
                msaLitCheckBox.Checked
            );
            Indicator nsa = new Indicator(
                "NSA",
                nsaVisibleCheckBox.Checked,
                nsaLitCheckBox.Checked
            );
            Indicator snd = new Indicator(
                "SND",
                sndVisibleCheckBox.Checked,
                sndLitCheckBox.Checked
            );
            Indicator sig = new Indicator(
                "SIG",
                sigVisibleCheckBox.Checked,
                sigLitCheckBox.Checked
            );
            Indicator trn = new Indicator(
                "TRN",
                trnVisibleCheckBox.Checked,
                trnLitCheckBox.Checked
            );

            //see if port plate num is valid
            int portPlateNum;

            try
            {
                portPlateNum = int.Parse(portPlateNumTextBox.Text);
            }
            catch
            {
                String text = "You entered an invalid port plate number";

                String caption = "Invalid Port Plate Number";

                ShowErrorMessageBox(caption, text);

                return;
            }

            bomb = new Bomb(
               day,
               serialNumber,
               battery,
               batteryHolder,
               bob,
               car,
               clr,
               frk,
               frq,
               ind,
               msa,
               nsa,
               sig,
               snd,
               trn,
               new List<Plate>()
           );

            plateForm = new PlateForm(1, portPlateNum, bomb, this, logFileWriter);

            plateForm.ShowDialog();
        }

        /// <summary>
        /// Shows a message box that will indicate an error
        /// </summary>
        /// <param name="caption">the caption of the message box</param>
        /// <param name="text">the text the message box with show</param>
        private void ShowErrorMessageBox(String caption, String text)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Makes sure the user is sure they want to close
        /// </summary>
        private void EdgeworkInputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Visible)
            {
                String message = "Are you sure you want to quit the program?";
                String caption = "Quit Program";

                DialogResult result = MessageBox.Show(
                    message,
                    caption,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                //if the user clicks no, don't close the program
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    logFileWriter.Write("User closed program...");
                    System.Diagnostics.Debug.Write("User closed program...");
                    logFileWriter.Close();
                    this.Visible = false;
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Changes textbox color to gray
        /// so it looks like prompt text
        /// </summary>
        /// <param name="textBox">the text box getting the prompt text</param>
        /// <param name="text">what the prompt text will say</param>
        private void SetPromptText(TextBox textBox, String text)
        {
            textBox.Text = text;
            textBox.ForeColor = Color.Gray;
        }

        /// <summary>
        /// Deletes the text in the prompt text
        /// so the user can type in whatever
        /// </summary>
        /// <param name="textBox">the textbox that will be left blank</param>
        /// <param name="propmtText">the prompt text in the textbox</param>
        private void DeletePromptText(TextBox textBox, String propmtText)
        {
            if (textBox.Text == propmtText)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Deletes to prompt text
        /// and make the textbox
        /// text black
        /// </summary>
        private void batteryTextBox_Enter(object sender, EventArgs e)
        {
            DeletePromptText(batteryTextBox, "# of batteries");
        }

        /// <summary>
        /// Deletes to prompt text
        /// and make the textbox
        /// text black
        /// </summary>
        private void batteryHolderTextBox_Enter(object sender, EventArgs e)
        {
            DeletePromptText(batteryHolderTextBox, "# of battery holders");
        }

        private void portPlateNumTextBox_Enter(object sender, EventArgs e)
        {
            DeletePromptText(portPlateNumTextBox, "# of Port Plates");
        }

        /// <summary>
        /// Sets the prompt text
        /// back up if the text box is blank
        /// </summary>
        private void batteryTextBox_Leave(object sender, EventArgs e)
        {
            if (batteryTextBox.Text == "")
            {
                SetPromptText(batteryTextBox, "# of batteries");
            }
        }

        /// <summary>
        /// Sets the prompt text
        /// back up if the text box is blank
        /// </summary>
        private void batteryHolderTextBox_Leave(object sender, EventArgs e)
        {
            if (batteryHolderTextBox.Text == "")
            {
                SetPromptText(batteryHolderTextBox, "# of battery holders");
            }
        }

        private void portPlateNumTextBox_Leave(object sender, EventArgs e)
        {
            if (portPlateNumTextBox.Text == "")
            {
                SetPromptText(portPlateNumTextBox, "# of Port Plates");
            }
        }
    }
}
