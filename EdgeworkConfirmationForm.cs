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
    ///Author: Nya Bentley
    /// Date: 3/1/21
    /// Purpose: Shows the edgework the user inputted
    /// and asks for confirmation
    /// </summary>
    public partial class EdgeworkConfirmationForm : Form
    {
        //FIELDS

        //the form the user will go to if they press backButton
        private EdgeworkInputForm inputForm;

        //where the edgework will be read from
        private Bomb bomb;

        private ModuleSelectionForm moduleSelectionForm;

        //used to write to the log file
        private StreamWriter logFileWriter;

        //Maze colors
        Color[] mazeColors;

        /// <summary>
        /// Tells the user what the edgework is
        /// </summary>
        /// <param name="bomb">the bomb that was created</param>
        public EdgeworkConfirmationForm(Bomb bomb, StreamWriter logFileWriter, Color[] mazeColors)
        {
            InitializeComponent();
            this.mazeColors = mazeColors;
            this.logFileWriter = logFileWriter;
            inputForm = new EdgeworkInputForm(logFileWriter);
            UpdateForm(bomb);
        }

        /// <summary>
        /// Tells the user what the edgework is
        /// </summary>
        /// <param name="bomb">the bomb that was created</param>
        /// <param name="inputForm">the form used to get to this form</param>
        public EdgeworkConfirmationForm(
            Bomb bomb,
            EdgeworkInputForm inputForm,
            StreamWriter logFileWriter
        )
        {
            InitializeComponent();
            this.logFileWriter = logFileWriter;
            UpdateForm(bomb, inputForm);
        }

        /// <summary>
        /// Used to set the form so it looks good as new
        /// </summary>
        /// <param name="bomb">the bomb needed to show the edgework</param>
        public void UpdateForm(Bomb bomb)
        {
            this.bomb = bomb;
            SetUpLabels();

            //writing out information for the log file
            WriteLog();
        }

        /// <summary>
        /// Used to set the form so it looks good as new
        /// </summary>
        /// <param name="bomb">the bomb needed to show the edgework</param>
        /// <param name="inputForm">the form used to get to this form</param>
        public void UpdateForm(Bomb bomb, EdgeworkInputForm inputForm)
        {
            this.inputForm = inputForm;
            this.bomb = bomb;
            SetUpLabels();

            //writing out information for the log file
            WriteLog();
        }

        /// <summary>
        /// Write edgework to log file
        /// </summary>
        private void WriteLog()
        {
            PrintDebugLine(
                "======================EDGEWORK CONFIRMATION======================" + "\n",
                logFileWriter
            );
            PrintDebugLine("Day of the week: " + bomb.Day, logFileWriter);
            PrintDebugLine("Serial Number: " + bomb.SerialNumber, logFileWriter);
            PrintDebugLine("# of batteries: " + bomb.Battery, logFileWriter);
            PrintDebugLine("# battery holders:" + bomb.BatteryHolder + "\n", logFileWriter);

            PrintDebugLine(
                $"BOB - Visisble: {bomb.Bob.Visible} Lit: {bomb.Bob.Lit}",
                logFileWriter
            );
            PrintDebugLine(
                $"CAR - Visisble: {bomb.Car.Visible} Lit: {bomb.Car.Lit}",
                logFileWriter
            );
            PrintDebugLine(
                $"CLR - Visisble: {bomb.Clr.Visible} Lit: {bomb.Clr.Lit}",
                logFileWriter
            );
            PrintDebugLine(
                $"FRK - Visisble: {bomb.Frk.Visible} Lit: {bomb.Frk.Lit}",
                logFileWriter
            );
            PrintDebugLine(
                $"FRQ - Visisble: {bomb.Frq.Visible} Lit: {bomb.Frq.Lit}",
                logFileWriter
            );
            PrintDebugLine(
                $"IND - Visisble: {bomb.Ind.Visible} Lit: {bomb.Ind.Lit}",
                logFileWriter
            );
            PrintDebugLine(
                $"MSA - Visisble: {bomb.Msa.Visible} Lit: {bomb.Msa.Lit}",
                logFileWriter
            );
            PrintDebugLine(
                $"NSA - Visisble: {bomb.Nsa.Visible} Lit: {bomb.Nsa.Lit}",
                logFileWriter
            );
            PrintDebugLine(
                $"SIG - Visisble: {bomb.Sig.Visible} Lit: {bomb.Sig.Lit}",
                logFileWriter
            );
            PrintDebugLine(
                $"SND - Visisble: {bomb.Snd.Visible} Lit: {bomb.Snd.Lit}",
                logFileWriter
            );
            PrintDebugLine(
                $"TRN - Visisble: {bomb.Trn.Visible} Lit: {bomb.Trn.Lit}\n",
                logFileWriter
            );

            PrintDebugLine($"Empty Port Plate: {bomb.EmptyPortPlate}", logFileWriter);
            PrintDebugLine($"# Port Plates: {bomb.PortPlateNum}", logFileWriter);
            PrintDebugLine("# of dvid ports: " + bomb.DviNum, logFileWriter);
            PrintDebugLine("# of parallel ports: " + bomb.PPNum, logFileWriter);
            PrintDebugLine("# of ps ports: " + bomb.PSNum, logFileWriter);
            PrintDebugLine("# of rj ports: " + bomb.RJNum, logFileWriter);
            PrintDebugLine("# of serial ports: " + bomb.SerialNum, logFileWriter);
            PrintDebugLine("# of stereo ports: " + bomb.RcaNum + "\n", logFileWriter);
        }

        /// <summary>
        /// Sets up that labels so they are evenly spaced on the form
        /// </summary>
        public void SetUpLabels()
        {
            SetLabel(dayOfWeekLabel, "Day of the week: " + bomb.Day, 1);
            SetLabel(serialNumberLabel, "Serial Number: " + bomb.SerialNumber, 2);
            SetLabel(batteryLabel, "# of batteries: " + bomb.Battery, 3);
            SetLabel(batteryHolderLabel, "# battery holders:" + bomb.BatteryHolder, 4);

            SetLabel(indicatorLabel, "Indicator", 5);

            SetIndicatorLabel(bobLabel, bomb.Bob, 6);
            SetIndicatorLabel(carLabel, bomb.Car, 7);
            SetIndicatorLabel(clrLabel, bomb.Clr, 8);
            SetIndicatorLabel(frkLabel, bomb.Frk, 9);
            SetIndicatorLabel(frqLabel, bomb.Frq, 10);
            SetIndicatorLabel(indLabel, bomb.Ind, 11);
            SetIndicatorLabel(msaLabel, bomb.Msa, 12);
            SetIndicatorLabel(nsaLabel, bomb.Nsa, 13);
            SetIndicatorLabel(sigLabel, bomb.Sig, 14);
            SetIndicatorLabel(sndLabel, bomb.Snd, 15);
            SetIndicatorLabel(trnLabel, bomb.Trn, 16);

            SetLabel(portLabel, "Port", 17);

            if (bomb.EmptyPortPlate)
            {
                SetLabel(emptyPortPlateLabel, "There is an empty port plate", 18);
            }
            else
            {
                SetLabel(emptyPortPlateLabel, "There isn't an empty port plate", 18);
            }

            SetLabel(portPlateNumLabel, "# of port Plates: " + bomb.PortPlateNum, 19);

            SetPortLabel(dvidLabel, "DVID", bomb.DviNum, 20);
            SetPortLabel(parallelLabel, "Parallel", bomb.PPNum , 21);
            SetPortLabel(psLabel, "PS/2", bomb.PSNum, 22);
            SetPortLabel(rjLabel, "RJ-45", bomb.RJNum, 23);
            SetPortLabel(serialLabel, "Serial", bomb.SerialNum, 24);
            SetPortLabel(stereoLabel, "Stero RCA", bomb.RcaNum, 25);
        }

        /// <summary>
        /// Sets up the label for a port
        /// </summary>
        /// <param name="label">the label itself</param>
        /// <param name="port">the port for the label</param>
        /// <param name="index">where the label in terms of the rest of the labels</param>
        public void SetPortLabel(Label label, string name, int num, int index)
        {
            SetLabel(label, $"# of {name} ports: {num}", index);
        }

        /// <summary>
        /// Sets up the label for a indicator
        /// </summary>
        /// <param name="label">the label itself</param>
        /// <param name="indicator">the indicator for the label</param>
        /// <param name="index">where the label in temrs of the res of the labels</param>
        public void SetIndicatorLabel(Label label, Indicator indicator, int index)
        {
            String text;

            if (!indicator.Visible)
            {
                text = indicator.Name + " is invisible";
            }
            else if (indicator.Visible && indicator.Lit)
            {
                text = indicator.Name + " is visible and lit";
            }
            else
            {
                text = indicator.Name + " is visible and unlit";
            }

            SetLabel(label, text, index);
        }

        /// <summary>
        /// Sets up the labels
        /// </summary>
        /// <param name="label">the label itself</param>
        /// <param name="text">what the label will say</param>
        /// <param name="index">where the label in temrs of the res of the labels</param>
        public void SetLabel(Label label, String text, int index)
        {
            label.Text = text;

            //sets the label in the middle hoirzontally
            int positionX = (this.Width - label.Width) / 2;

            //sets where the label is going to be vertically
            int positionY = index * 22;

            label.Location = new Point(positionX, positionY);
        }

        /// <summary>
        /// Asks if the player is sure they want to program. If they say yes, the entire program will be closed
        /// </summary>
        private void EdgeworkConfirmationForm_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Sends the user to the edgeworkInput form
        /// </summary>
        private void backButton_Click(object sender, EventArgs e)
        {
            if (inputForm == null)
            {
                inputForm = new EdgeworkInputForm(this, logFileWriter, mazeColors);
            }

            this.Hide();
            inputForm.UpdateForm();
            inputForm.Show();
        }

        /// <summary>
        /// Sends the user to the module selction form
        /// </summary>
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (moduleSelectionForm == null)
            {
                moduleSelectionForm = new ModuleSelectionForm(
                    bomb,
                    this,
                    inputForm,
                    logFileWriter,
                    mazeColors
                );
            }
            else
            {
                moduleSelectionForm.UpdateForm(bomb);
            }

            this.Hide();

            moduleSelectionForm.Show();
        }

        public void PrintDebugLine(string message, StreamWriter logFileWriter)
        {
            logFileWriter.WriteLine(message);
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
