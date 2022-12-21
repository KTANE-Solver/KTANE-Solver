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
    public partial class EdgeworkSelectionForm : Form
    {
        //tells whether or not preferences are valid
        bool validPref = false;

        //default Maze Colors
        Color[] defaultMazeColors =
        {
            Color.Blue,
            Color.Green,
            Color.White,
            Color.Red,
            Color.Yellow,
            Color.Orange
        };

        //preference maze Colors
        Color[] mazeColors;

        //the one the bomb is going to use
        Color[] bombMazeColors;

        EdgeworkConfirmationForm confirmationForm;
        EdgeworkInputForm inputForm;

        //used to write to the log file
        StreamWriter logFileWriter;

        public EdgeworkSelectionForm()
        {
            InitializeComponent();

            logFileWriter = new StreamWriter("LogFile.txt");
            logFileWriter.AutoFlush = true;

            logFileWriter.WriteLine(
                "======================EDGEWORK SELECTION======================"
            );
            System.Diagnostics.Debug.WriteLine(
                "======================EDGEWORK SELECTION======================"
            );
            EnablePreferences();

            if (validPref)
            {
                bombMazeColors = mazeColors;
            }
            else
            {
                bombMazeColors = defaultMazeColors;
            }
        }

        /// <summary>
        /// Creates a bomb object and sends the user to the EdgeworkConfirmation Form
        /// </summary>
        private void automaticButton_Click(object sender, EventArgs e)
        {
            logFileWriter.WriteLine(
                "User chose to autmoatically get edgework. Reading Edgework.txt...\n"
            );
            System.Diagnostics.Debug.WriteLine(
                "User chose to autmoatically get edgework. Reading Edgework.txt...\n"
            );

            Day day = Day.Sunday;

            String serialNumber = "0";

            int battery = 0;
            int batteryHolder = 0;

            Indicator bob = null;
            Indicator car = null;
            Indicator clr = null;
            Indicator frk = null;
            Indicator frq = null;
            Indicator ind = null;
            Indicator msa = null;
            Indicator nsa = null;
            Indicator sig = null;
            Indicator snd = null;
            Indicator trn = null;

            bool emptyPortPlate = false;
            int portPlateNum = 0;

            List<Plate> plates = new List<Plate>();

            //if there is a problem reading Edgework.txt
            bool errorReached = false;

            //tells what casued the error
            String errorString = "";

            StreamReader reader = new StreamReader("Edgework.txt");

            //the line the reader is reading

            for (int lineReaing = 1; lineReaing <= 16; lineReaing++)
            {
                String currentLine = reader.ReadLine();

                switch (lineReaing)
                {
                    //day of the week
                    case 1:
                        errorReached = !Enum.TryParse(currentLine, out day);

                        if (errorReached)
                        {
                            errorString = "Can't read day. Read " + currentLine;
                        }
                        break;

                    //serial number
                    case 2:
                        serialNumber = currentLine.ToUpper();
                        break;

                    //batteries
                    case 3:
                        errorReached = !Int32.TryParse(currentLine, out battery);

                        if (errorReached)
                        {
                            errorString = "Can't read battery. Read " + currentLine;
                        }

                        break;

                    //battery holder
                    case 4:
                        errorReached = !Int32.TryParse(currentLine, out batteryHolder);

                        if (errorReached)
                        {
                            errorString = "Can't read batteryHolder. Read " + currentLine;
                        }

                        break;

                    //indicator bob
                    case 5:
                        String[] indicatorInfo = currentLine.Split('|');

                        bool visible;
                        bool lit;

                        try
                        {
                            visible = bool.Parse(indicatorInfo[0]);
                            lit = bool.Parse(indicatorInfo[1]);

                            bob = new Indicator("BOB", visible, lit);
                        }
                        catch
                        {
                            errorReached = true;

                            errorString =
                                $"Can't read bob. Read {indicatorInfo[0]} for visiblity and {indicatorInfo[1]} for lit";
                        }

                        break;

                    //indicator car
                    case 6:
                        indicatorInfo = currentLine.Split('|');

                        try
                        {
                            visible = bool.Parse(indicatorInfo[0]);
                            lit = bool.Parse(indicatorInfo[1]);

                            car = new Indicator("CAR", visible, lit);
                        }
                        catch
                        {
                            errorReached = true;
                            errorString =
                                $"Can't read car. Read {indicatorInfo[0]} for visiblity and {indicatorInfo[1]} for lit";
                        }
                        break;

                    //indicator clr
                    case 7:

                        indicatorInfo = currentLine.Split('|');

                        try
                        {
                            visible = bool.Parse(indicatorInfo[0]);
                            lit = bool.Parse(indicatorInfo[1]);

                            clr = new Indicator("CLR", visible, lit);
                        }
                        catch
                        {
                            errorReached = true;
                            errorString =
                                $"Can't read clr. Read {indicatorInfo[0]} for visiblity and {indicatorInfo[1]} for lit";
                        }

                        break;

                    //indicator frk
                    case 8:

                        indicatorInfo = currentLine.Split('|');

                        try
                        {
                            visible = bool.Parse(indicatorInfo[0]);
                            lit = bool.Parse(indicatorInfo[1]);

                            frk = new Indicator("FRK", visible, lit);
                        }
                        catch
                        {
                            errorReached = true;
                            errorString =
                                $"Can't read frk. Read {indicatorInfo[0]} for visiblity and {indicatorInfo[1]} for lit";
                        }

                        break;

                    //indicator frq
                    case 9:
                        indicatorInfo = currentLine.Split('|');

                        try
                        {
                            visible = bool.Parse(indicatorInfo[0]);
                            lit = bool.Parse(indicatorInfo[1]);

                            frq = new Indicator("FRQ", visible, lit);
                        }
                        catch
                        {
                            errorReached = true;
                            errorString =
                                $"Can't read frq. Read {indicatorInfo[0]} for visiblity and {indicatorInfo[1]} for lit";
                        }

                        break;

                    //indicator ind
                    case 10:

                        indicatorInfo = currentLine.Split('|');

                        try
                        {
                            visible = bool.Parse(indicatorInfo[0]);
                            lit = bool.Parse(indicatorInfo[1]);

                            ind = new Indicator("IND", visible, lit);
                        }
                        catch
                        {
                            errorReached = true;
                            errorString =
                                $"Can't read ind. Read {indicatorInfo[0]} for visiblity and {indicatorInfo[1]} for lit";
                        }

                        break;

                    //indicator msa
                    case 11:

                        indicatorInfo = currentLine.Split('|');

                        try
                        {
                            visible = bool.Parse(indicatorInfo[0]);
                            lit = bool.Parse(indicatorInfo[1]);

                            msa = new Indicator("MSA", visible, lit);
                        }
                        catch
                        {
                            errorReached = true;
                            errorString =
                                $"Can't read msa. Read {indicatorInfo[0]} for visiblity and {indicatorInfo[1]} for lit";
                        }

                        break;

                    //indicator nsa
                    case 12:

                        indicatorInfo = currentLine.Split('|');

                        try
                        {
                            visible = bool.Parse(indicatorInfo[0]);
                            lit = bool.Parse(indicatorInfo[1]);

                            nsa = new Indicator("NSA", visible, lit);
                        }
                        catch
                        {
                            errorReached = true;
                            errorString =
                                $"Can't read nsa. Read {indicatorInfo[0]} for visiblity and {indicatorInfo[1]} for lit";
                        }

                        break;

                    //indicator sig
                    case 13:

                        indicatorInfo = currentLine.Split('|');

                        try
                        {
                            visible = bool.Parse(indicatorInfo[0]);
                            lit = bool.Parse(indicatorInfo[1]);

                            sig = new Indicator("SIG", visible, lit);
                        }
                        catch
                        {
                            errorReached = true;
                            errorString =
                                $"Can't read sig. Read {indicatorInfo[0]} for visiblity and {indicatorInfo[1]} for lit";
                        }

                        break;

                    //indicator snd
                    case 14:

                        indicatorInfo = currentLine.Split('|');

                        try
                        {
                            visible = bool.Parse(indicatorInfo[0]);
                            lit = bool.Parse(indicatorInfo[1]);

                            snd = new Indicator("SND", visible, lit);
                        }
                        catch
                        {
                            errorReached = true;
                            errorString =
                                $"Can't read snd. Read {indicatorInfo[0]} for visiblity and {indicatorInfo[1]} for lit";
                        }

                        break;

                    //indicator trn
                    case 15:

                        indicatorInfo = currentLine.Split('|');

                        try
                        {
                            visible = bool.Parse(indicatorInfo[0]);
                            lit = bool.Parse(indicatorInfo[1]);

                            trn = new Indicator("TRN", visible, lit);
                        }
                        catch
                        {
                            errorReached = true;
                            errorString =
                                $"Can't read trn. Read {indicatorInfo[0]} for visiblity and {indicatorInfo[1]} for lit";
                        }

                        break;

                    //Plates

                    case 16:

                        string[] platesStr = currentLine.Split(',');

                        try
                        {
                            foreach (string platestr in platesStr)
                            {
                                string[] arr = platestr.Split('|');

                                plates.Add(new Plate(bool.Parse(arr[0]), bool.Parse(arr[1]), bool.Parse(arr[2]), bool.Parse(arr[3]), bool.Parse(arr[4]), bool.Parse(arr[5])));
                            }
                        }

                        catch
                        {
                            errorReached = true;
                            errorString = "Can't read ports line. Read " + currentLine;
                        }
                        break;
                }

                if (errorReached)
                {
                    break;
                }
            }

            reader.Close();

            //no point in seeing if there is an error if there already is an error
            if (!errorReached)
            {
                //make sure the serial number is valid

                //the serial number must have at least one number
                //the serial number must have at least on letter
                //the serial number's last character must be a number
                bool lastCharIsNum = false;
                bool hasLetter = false;

                for (int i = 0; i < serialNumber.Length; i++)
                {
                    if (!hasLetter && serialNumber[i] >= 65 && serialNumber[i] <= 90)
                    {
                        hasLetter = true;
                    }

                    if (
                        i == serialNumber.Length - 1
                        && serialNumber[i] >= 48
                        && serialNumber[i] <= 57
                    )
                    {
                        lastCharIsNum = true;
                    }
                }

                if (!(lastCharIsNum && hasLetter))
                {
                    errorReached = true;
                    logFileWriter.WriteLine(serialNumber + " is not a valid serial number");
                    System.Diagnostics.Debug.WriteLine(
                        serialNumber + " is not a valid serial number"
                    );
                }

                //make sure the number of batteries is at least the same number of holders or at most twice
                if (!errorReached && battery < batteryHolder || battery > batteryHolder * 2)
                {
                    errorReached = true;
                    errorString =
                        $"Invalid batteries and battery holders. Battery Count: {battery}. Battery Holder Count: {batteryHolder}";
                }

                //make sure each indicator is valid
                if (!errorReached && !bob.ValidIndicator)
                {
                    errorReached = true;
                    errorString = "Invalid bob";
                }

                if (!errorReached && !car.ValidIndicator)
                {
                    errorReached = true;
                    errorString = "Invalid car";
                }

                if (!errorReached && !clr.ValidIndicator)
                {
                    errorReached = true;
                    errorString = "Invalid clr";
                }

                if (!errorReached && !frk.ValidIndicator)
                {
                    errorReached = true;
                    errorString = "Invalid frk";
                }

                if (!errorReached && !frq.ValidIndicator)
                {
                    errorReached = true;
                    errorString = "Invalid frq";
                }

                if (!errorReached && !ind.ValidIndicator)
                {
                    errorReached = true;
                    errorString = "Invalid ind";
                }

                if (!errorReached && !msa.ValidIndicator)
                {
                    errorReached = true;
                    errorString = "Invalid msa";
                }

                if (!errorReached && !nsa.ValidIndicator)
                {
                    errorReached = true;
                    errorString = "Invalid nsa";
                }

                if (!errorReached && !sig.ValidIndicator)
                {
                    errorReached = true;
                    errorString = "Invalid sig";
                }

                if (!errorReached && !snd.ValidIndicator)
                {
                    errorReached = true;
                    errorString = "Invalid snd";
                }

                if (!errorReached && !trn.ValidIndicator)
                {
                    errorReached = true;
                    errorString = "Invalid trn";
                }

                //can't have a negative port plate num
                if (portPlateNum < 0)
                {
                    errorReached = true;
                    errorString = "Invalid port plate #";
                }

                //can't have no port Plates but still have an empty port plate
                if (portPlateNum == 0 && emptyPortPlate)
                {
                    errorReached = true;
                    errorString = "Can't have no port Plates but still have an empty port plate";
                }
            }

            //if there is an error tell the user that and send them to the manually
            if (errorReached)
            {
                logFileWriter.WriteLine(
                    $"Unable to read edgework. {errorString}. Sending user to manual edgework input\n"
                );
                System.Diagnostics.Debug.WriteLine(
                    $"Unable to read edgework. {errorString}. Sending user to manual edgework input\n"
                );

                MessageBox.Show(
                    "There was an error reading Egdework.txt. Try manually inputting the edgework",
                    "Error Reading Edgework.txt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                inputForm = new EdgeworkInputForm(logFileWriter);
                this.Hide();
                inputForm.Show();
            }
            //otherwise go to the edgework confirmation form
            else
            {
                Bomb bomb = new Bomb(
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
                    plates
                );

                confirmationForm = new EdgeworkConfirmationForm(
                    bomb,
                    logFileWriter,
                    bombMazeColors
                );
                this.Hide();
                confirmationForm.Show();
            }
        }

        /// <summary>
        /// Brings the user to the EdgeworkInput form
        /// </summary>
        private void manualButton_Click(object sender, EventArgs e)
        {
            logFileWriter.WriteLine("User chose to manually input edgeowrk\n");

            inputForm = new EdgeworkInputForm(logFileWriter);
            this.Hide();
            inputForm.Show();
        }

        /// <summary>
        /// Asks the user if the user is sure they want to close the program
        /// </summary>
        private void EdgeworkSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Enables preferences based on Preferences.txt
        /// </summary>
        private void EnablePreferences()
        {
            StreamReader reader = new StreamReader("Preferences.txt");

            //seeing if looking at custom preferences
            string enablePref = reader.ReadLine().ToUpper().Substring(20);

            if (enablePref == "OFF")
            {
                return;
            }
            if (enablePref != "ON")
            {
                MessageBox.Show(
                    $"Invalid \"Enable Preferences\" value ({enablePref}). Using default preferences",
                    "Preferences",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            else
            {
                //the number of preferences being loocked for
                const int MAX_PREFERENCES = 1;

                for (int i = 1; i < MAX_PREFERENCES + 1; i++)
                {
                    switch (i)
                    {
                        //order of button colors being clicked
                        case 1:
                            string[] colors = reader
                                .ReadLine()
                                .ToUpper()
                                .Substring(13)
                                .Trim(new Char[] { '[', ']' })
                                .Split(',');

                            //make sure there are 6 elements
                            if (colors.Length != 6)
                            {
                                MessageBox.Show(
                                    $"Invalid \"Maze Colors\" (Counted {colors.Length} items instead of 6). Using default preferences",
                                    "Preferences",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return;
                            }

                            for (int j = 0; j < 6; j++)
                            {
                                colors[j] = colors[j].Trim();
                            }

                            //make sure there is a blue, green, white, red, yellow, orange

                            if (!colors.Contains("BLUE"))
                            {
                                MessageBox.Show(
                                    $"Invalid \"Maze Colors\" (Missing BLUE). Using default preferences",
                                    "Preferences",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return;
                            }

                            if (!colors.Contains("GREEN"))
                            {
                                MessageBox.Show(
                                    $"Invalid \"Maze Colors\" (Missing GREEN). Using default preferences",
                                    "Preferences",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return;
                            }

                            if (!colors.Contains("WHITE"))
                            {
                                MessageBox.Show(
                                    $"Invalid \"Maze Colors\" (Missing WHITE). Using default preferences",
                                    "Preferences",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return;
                            }

                            if (!colors.Contains("RED"))
                            {
                                MessageBox.Show(
                                    $"Invalid \"Maze Colors\" (Missing RED). Using default preferences",
                                    "Preferences",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return;
                            }

                            if (!colors.Contains("YELLOW"))
                            {
                                MessageBox.Show(
                                    $"Invalid \"Maze Colors\" (Missing YELLOW). Using default preferences",
                                    "Preferences",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return;
                            }

                            if (!colors.Contains("ORANGE"))
                            {
                                MessageBox.Show(
                                    $"Invalid \"Maze Colors\" value (Missing ORANGE). Using default preferences",
                                    "Preferences",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return;
                            }

                            //convert the arr from a string to a color enum
                            mazeColors = new Color[]
                            {
                                Color.FromName(colors[0]),
                                Color.FromName(colors[1]),
                                Color.FromName(colors[2]),
                                Color.FromName(colors[3]),
                                Color.FromName(colors[4]),
                                Color.FromName(colors[5])
                            };

                            break;
                    }
                }

                validPref = true;
            }
        }
    }
}
