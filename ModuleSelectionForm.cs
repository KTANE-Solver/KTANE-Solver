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
    /// Date: 3/4/21
    /// Purpose: Allows the player to choose which module
    ///          they want to be solved
    /// </summary>
    public partial class ModuleSelectionForm : Form
    {
        //===========FIELDS===========

        //the current bomb
        private Bomb bomb;

        //the confirmation form used get here
        private EdgeworkConfirmationForm confirmationForm;

        //the input form used if the user wants
        //to change the edgework
        private EdgeworkInputForm inputForm;

        //used to write to the log file
        StreamWriter logFileWriter;

        //module forms
        private _3DMazeForm _3DMazeForm;
        private AdjacentLettersForm adjacentLettersForm;
        private AdventureGameForm adventureGameForm;
        private AnagramsForm anagramsForm;
        private AstrologyForm astrologyForm;
        private BinaryPuzzleForm binaryForm;
        private BitmapsForm bitmapsForm;
        private BlindAlleyForm blindAlleyForm;
        private BooleanVennDiagramForm booleanVennDiagramForm;
        private BrokenButtonsForm brokenButtonsForm;
        private BulbForm bulbForm;
        private ButtonForm buttonForm;
        private CheapCheckoutForm cheapForm;
        private ChessForm chessForm;
        private ChordQualitiesForm chordQualitiesForm;
        private ColorMathForm colorMathForm;
        private CreationForm creationForm;
        private ColoredSquaresForm coloredSquaresForm;
        private ComplicatedWiresForm complicatedWiresForm;
        private ConnectionCheckForm connectionCheckForm;
        private FastMathStage1Form fastMathForm;
        private FizzBuzzForm fizzBuzzForm;
        private GamepadForm gamepadForm;
        private IceCreamForm iceCreamForm;
        private KeypadForm keyPadForm;
        private LetterKeysForm letterKeysForm;
        private LightCycleForm lightCycleForm;
        private ListeningForm listeningForm;
        private LogicForm logicForm;
        private MazeForm mazeForm;
        private MemoryStage1Form memoryForm;
        private MicrocontrollerForm microcontrollerForm;
        private MonsplodeTradingCardForm1 monsplodeTradingCardForm;
        private MorseCodeForm morseCodeForm;
        private MurderForm murderForm;
        private MysticSquareForm mysticSquareForm;
        private NumberPadForm numberPadForm;
        private PasswordFirstStageForm passwordForm;
        private PokerStage1Form pokerForm;
        private RockPaperScissorsLizardSpockForm rockPaperScissorsLizardSpockForm;
        private RoundKeypadForm roundKeypadForm;
        private RubikCubeForm rubikCubeForm;
        private SafetySafeForm safetySafeForm;
        private SeaShellsForm seaShellsForm;
        private ShapeShiftWordForm shapeShiftWordForm;
        private SemaphoreStage1Form semaphoreCountForm;
        private ScrewForm screwForm;
        private SillySlotsStage1Form sillySlotsForm;
        private SimonSaysForm simonSaysForm;
        private SkewedSlotForm skewedSlotForm;
        private SwitchesForm switchesForm;
        private TicTacToeForm ticTacToeForm;
        private TwoBitsStage1Form twoBitsForm;
        private WhosOnFirstFirstStageForm whosOnFirstForm;
        private WiresForm wiresForm;
        private WireSequenceStage1Form wireSequenceForm;
        private WordSearchForm wordSearchForm;

        //Preferences
        private Color[] mazeColors;

        //===========CONSTRUCTORS===========



        /// <summary>
        /// Creates an form that allows the user to
        /// pick which module wants to be solved
        /// </summary>
        /// <param name="bomb">the current bomb</param>
        /// <param name="confirmationForm">the form used if the player wants to check the edgework</param>
        /// <param name="inputForm">the form used if the player want to change the edgework</param>
        public ModuleSelectionForm(
            Bomb bomb,
            EdgeworkConfirmationForm confirmationForm,
            EdgeworkInputForm inputForm,
            StreamWriter logFileWriter,
            Color[] mazeColors
        )
        {
            InitializeComponent();
            this.mazeColors = mazeColors;
            this.logFileWriter = logFileWriter;
            this.bomb = bomb;
            this.confirmationForm = confirmationForm;
            this.inputForm = inputForm;
            UpdateForm();
        }

        //===========METHODS===========

        /// <summary>
        /// Sets up the form, so it looks
        /// good as new
        /// </summary>
        public void UpdateForm()
        {
            PrintDebugLine("=================MODULE SELECTION=================");
            SetUpModuleComboBox();
        }

        /// <summary>
        /// Sets up the form, so it looks
        /// good as new
        /// </summary>
        /// <param name="bomb">the new bomb</param>
        public void UpdateForm(Bomb bomb)
        {
            UpdateForm();
            this.bomb = bomb;
        }

        /// <summary>
        /// Sets up the combo box so it has all the modules
        /// </summary>
        private void SetUpModuleComboBox()
        {
            moduleComboBox.Items.Clear();

            String[] modules = new String[]
            {
                "3D Maze",
                "Adjacent Letters",
                "Adventure Game",
                "Anagrams",
                "Astrology",
                "Binary Puzzle",
                "Bitmaps",
                "Blind Alley",
                "Boolean Venn Diagram",
                "Broken Buttons",
                "Bulb",
                "Button",
                "Cheap Checkout",
                "Chess",
                "Chord Qualities",
                "Color Math",
                "Colored Squares",
                "Complicated Wires",
                "Connection Check",
                "Creation",
                "Fast Math",
                "FizzBuzz",
                "Gamepad",
                "Hexamaze",
                "Ice Cream",
                "Keypad",
                "Letter Keys",
                "Light Cycle",
                "Listening",
                "Logic",
                "Maze",
                "Memory",
                "Microcontroller",
                "Monsplode Trading Cards",
                "Morse Code",
                "Mystic Square",
                "Murder",
                "Number Pad",
                "Password",
                "Poker",
                "Rock Paper Scissors Lizard Spock",
                "Round Keypad",
                "Rubik's Cube",
                "Safety Safe",
                "Screw",
                "Semaphore",
                "Sea Shells",
                "Shape Shift",
                "Silly Slots",
                "Simon Says",
                "Skewed Slots",
                "Switches",
                "Tic Tac Toe",
                "Two Bits",
                "Who's on First",
                "Wires",
                "Wires Sequence",
                "Word Search"
            };

            moduleComboBox.Items.AddRange(modules);
            moduleComboBox.Text = modules[0];
            moduleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Sends the user to the edgework input form
        /// </summary>
        private void changeEdgeworkButton_Click(object sender, EventArgs e)
        {
            PrintDebugLine("User is changing edgework...\n");
            this.Hide();
            inputForm.UpdateForm();
            inputForm.Show();
        }

        /// <summary>
        /// sends the user to the edgework confirmation form
        /// </summary>
        private void checkEdgeworkButton_Click(object sender, EventArgs e)
        {
            PrintDebugLine("User is checking edgework...\n");
            this.Hide();
            confirmationForm.UpdateForm(bomb, inputForm);
            confirmationForm.Show();
        }

        /// <summary>
        /// Confirms that the user want to close the program
        /// </summary>
        private void ModuleSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
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
                    PrintDebug("User closed program...");
                    this.Visible = false;
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Saves the current bomb to Edgework.txt
        /// </summary>
        private void saveEdgeworkButton_Click(object sender, EventArgs e)
        {
            PrintDebugLine("User is trying to save edgework...\n");

            StreamWriter writer = new StreamWriter("Edgework.txt");

            try
            {
                writer.WriteLine(bomb.Day);
                writer.WriteLine(bomb.SerialNumber);
                writer.WriteLine(bomb.Battery);
                writer.WriteLine(bomb.BatteryHolder);

                SaveIndicator(writer, bomb.Bob);
                SaveIndicator(writer, bomb.Car);
                SaveIndicator(writer, bomb.Clr);
                SaveIndicator(writer, bomb.Frk);
                SaveIndicator(writer, bomb.Frq);
                SaveIndicator(writer, bomb.Ind);
                SaveIndicator(writer, bomb.Msa);
                SaveIndicator(writer, bomb.Nsa);
                SaveIndicator(writer, bomb.Sig);
                SaveIndicator(writer, bomb.Snd);
                SaveIndicator(writer, bomb.Trn);



                List<string> plates = new List<string>();

                foreach (Plate plate in bomb.Plates)
                {
                    plates.Add($"{plate.pp}|{plate.rca}|{plate.serial}|{plate.rj}|{plate.dvi}|{plate.ps}");
                }

                writer.WriteLine(string.Join(",", plates));

                writer.Close();

                MessageBox.Show(
                    "Edgework saved successfully",
                    "Edgework Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                PrintDebugLine("User has successfully saved edgeork\n");
            }
            catch
            {
                MessageBox.Show(
                    "There was an error saving this edgework to Edgework.txt",
                    "Saving Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                PrintDebugLine("User has unsuccessfully saved edgeork\n");
            }
        }

        /// <summary>
        /// Saves the indicators to Edgework.txt
        /// </summary>
        /// <param name="writer">used to save the data<param>
        /// <param name="indicator">the indicator that will be saved</param>
        private void SaveIndicator(StreamWriter writer, Indicator indicator)
        {
            writer.WriteLine($"{indicator.Visible}|{indicator.Lit}");
        }

        /// <summary>
        /// Sends the player to the module form
        /// they selected in the combo box
        /// </summary>
        private void submitButton_Click(object sender, EventArgs e)
        {
            String moduleName = moduleComboBox.Text;

            PrintDebugLine($"User selected {moduleName}. Attempting to open...\n");

            this.Hide();

            switch (moduleName)
            {
                case "3D Maze":
                    if (_3DMazeForm == null)
                    {
                        _3DMazeForm = new _3DMazeForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        _3DMazeForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    _3DMazeForm.Show();
                    break;

                case "Adjacent Letters":
                    if (adjacentLettersForm == null)
                    {
                        adjacentLettersForm = new AdjacentLettersForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        adjacentLettersForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    adjacentLettersForm.Show();

                    break;

                case "Adventure Game":
                    if (adventureGameForm == null)
                    {
                        adventureGameForm = new AdventureGameForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        adventureGameForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    adventureGameForm.Show();

                    break;

                case "Anagrams":
                    if (anagramsForm == null)
                    {
                        anagramsForm = new AnagramsForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        anagramsForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    anagramsForm.Show();

                    break;

                case "Astrology":
                    if (astrologyForm == null)
                    {
                        astrologyForm = new AstrologyForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        astrologyForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    astrologyForm.Show();

                    break;

                case "Binary Puzzle":

                    if (binaryForm == null)
                    {
                        binaryForm = new BinaryPuzzleForm(this, logFileWriter);
                    }
                    else
                    {
                        binaryForm.UpdateForm(this, logFileWriter);
                    }

                    binaryForm.Show();
                    break;

                case "Bitmaps":
                    bitmapsForm = new BitmapsForm(bomb, this, logFileWriter);

                    bitmapsForm.Show();
                    break;

                case "Blind Alley":

                    blindAlleyForm = new BlindAlleyForm(bomb, logFileWriter, this);

                    blindAlleyForm.Show();
                    break;

                case "Boolean Venn Diagram":

                    booleanVennDiagramForm = new BooleanVennDiagramForm(bomb, logFileWriter, this);

                    booleanVennDiagramForm.Show();
                    break;

                case "Broken Buttons":

                    brokenButtonsForm = new BrokenButtonsForm(bomb, logFileWriter, this);
                    brokenButtonsForm.Show();
                    break;

                case "Button":

                    if (buttonForm == null)
                    {
                        buttonForm = new ButtonForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        buttonForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    buttonForm.Show();
                    break;

                case "Bulb":

                    if (bulbForm == null)
                    {
                        bulbForm = new BulbForm(bomb, logFileWriter, this, "Bulb");
                    }
                    else
                    {
                        bulbForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    bulbForm.Show();

                    break;

                case "Cheap Checkout":

                    if (cheapForm == null)
                    {
                        cheapForm = new CheapCheckoutForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        cheapForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    cheapForm.Show();
                    break;

                case "Chess":

                    if (chessForm == null)
                    {
                        chessForm = new ChessForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        chessForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    chessForm.Show();
                    break;

                case "Chord Qualities":

                    chordQualitiesForm = new ChordQualitiesForm(bomb, logFileWriter, this);
                    chordQualitiesForm.Show();
                    break;

                case "Color Math":

                    if (colorMathForm == null)
                    {
                        colorMathForm = new ColorMathForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        colorMathForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    colorMathForm.Show();
                    break;

                case "Colored Squares":
                    coloredSquaresForm = new ColoredSquaresForm(bomb, logFileWriter, this);
                    coloredSquaresForm.Show();
                    break;

                case "Complicated Wires":

                    if (complicatedWiresForm == null)
                    {
                        complicatedWiresForm = new ComplicatedWiresForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        complicatedWiresForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    complicatedWiresForm.Show();
                    break;

                case "Connection Check":
                    connectionCheckForm = new ConnectionCheckForm(bomb, logFileWriter, this);
                    connectionCheckForm.Show();

                    break;

                case "Fast Math":
                    fastMathForm = new FastMathStage1Form(bomb, logFileWriter, this);

                    fastMathForm.Show();

                    break;
                case "Creation":
                    creationForm = new CreationForm(bomb, logFileWriter, this);

                    creationForm.Show();

                    break;

                case "FizzBuzz":
                    if (fizzBuzzForm == null)
                    {
                        fizzBuzzForm = new FizzBuzzForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        fizzBuzzForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    fizzBuzzForm.Show();
                    break;

                case "Gamepad":
                    if (gamepadForm == null)
                    {
                        gamepadForm = new GamepadForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        gamepadForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    gamepadForm.Show();
                    break;

                case "Ice Cream":

                    iceCreamForm = new IceCreamForm(bomb, logFileWriter, this);

                    iceCreamForm.Show();
                    break;

                case "Keypad":

                    if (keyPadForm == null)
                    {
                        keyPadForm = new KeypadForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        keyPadForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    keyPadForm.Show();
                    break;

                case "Letter Keys":

                    letterKeysForm = new LetterKeysForm(bomb, logFileWriter, this);

                    letterKeysForm.Show();
                    break;

                case "Light Cycle":

                    if (lightCycleForm == null)
                    {
                        lightCycleForm = new LightCycleForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        lightCycleForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    lightCycleForm.Show();
                    break;

                case "Listening":
                    listeningForm = new ListeningForm(bomb, logFileWriter, this);
                    listeningForm.Show();
                    break;

                case "Logic":

                    if (logicForm == null)
                    {
                        logicForm = new LogicForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        logicForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    logicForm.Show();
                    break;

                case "Maze":

                    if (mazeForm == null)
                    {
                        mazeForm = new MazeForm(bomb, logFileWriter, this, mazeColors);
                    }
                    else
                    {
                        mazeForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    mazeForm.Show();
                    break;

                case "Memory":

                    if (memoryForm == null)
                    {
                        memoryForm = new MemoryStage1Form(bomb, logFileWriter, this);
                    }
                    else
                    {
                        memoryForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    memoryForm.Show();
                    break;

                case "Microcontroller":
                    microcontrollerForm = new MicrocontrollerForm(bomb, logFileWriter, this);

                    microcontrollerForm.Show();
                    break;

                case "Monsplode Trading Cards":
                    if (monsplodeTradingCardForm == null)
                    {
                        monsplodeTradingCardForm = new MonsplodeTradingCardForm1(
                            bomb,
                            logFileWriter,
                            this
                        );
                    }
                    else
                    {
                        monsplodeTradingCardForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    monsplodeTradingCardForm.Show();
                    break;

                case "Morse Code":

                    if (morseCodeForm == null)
                    {
                        morseCodeForm = new MorseCodeForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        morseCodeForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    morseCodeForm.Show();
                    break;

                case "Murder":

                    if (murderForm == null)
                    {
                        murderForm = new MurderForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        murderForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    murderForm.Show();
                    break;

                case "Mystic Square":

                    mysticSquareForm = new MysticSquareForm(bomb, logFileWriter, this);
                    mysticSquareForm.Show();
                    break;

                case "Number Pad":

                    if (numberPadForm == null)
                    {
                        numberPadForm = new NumberPadForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        numberPadForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    numberPadForm.Show();
                    break;

                case "Password":

                    if (passwordForm == null)
                    {
                        passwordForm = new PasswordFirstStageForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        passwordForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    passwordForm.Show();
                    break;

                case "Poker":

                    if (pokerForm == null)
                    {
                        pokerForm = new PokerStage1Form(bomb, logFileWriter, this);
                    }
                    else
                    {
                        pokerForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    pokerForm.Show();
                    break;

                case "Rock Paper Scissors Lizard Spock":
                    if (rockPaperScissorsLizardSpockForm == null)
                    {
                        rockPaperScissorsLizardSpockForm = new RockPaperScissorsLizardSpockForm(
                            bomb,
                            logFileWriter,
                            this
                        );
                    }
                    else
                    {
                        rockPaperScissorsLizardSpockForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    rockPaperScissorsLizardSpockForm.Show();
                    break;

                case "Round Keypad":

                    roundKeypadForm = new RoundKeypadForm(bomb, logFileWriter, this);

                    roundKeypadForm.Show();
                    break;

                case "Rubik's Cube":

                    if (rubikCubeForm == null)
                    {
                        rubikCubeForm = new RubikCubeForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        rubikCubeForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    rubikCubeForm.Show();
                    break;
                case "Safety Safe":

                    safetySafeForm = new SafetySafeForm(bomb, logFileWriter, this);
                    safetySafeForm.Show();
                    break;

                case "Sea Shells":

                    seaShellsForm = new SeaShellsForm(bomb, logFileWriter, this);
                    seaShellsForm.Show();
                    break;

                case "Semaphore":

                    semaphoreCountForm = new SemaphoreStage1Form(bomb, logFileWriter, this);
                    semaphoreCountForm.Show();
                    break;

                case "Screw":

                    screwForm = new ScrewForm(bomb, logFileWriter, this);
                    screwForm.Show();
                    break;

                case "Silly Slots":

                    if (sillySlotsForm == null)
                    {
                        sillySlotsForm = new SillySlotsStage1Form(bomb, logFileWriter, this);
                    }
                    else
                    {
                        sillySlotsForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    sillySlotsForm.Show();
                    break;

                case "Simon Says":

                    if (simonSaysForm == null)
                    {
                        simonSaysForm = new SimonSaysForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        simonSaysForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    simonSaysForm.Show();
                    break;

                case "Shape Shift":
                    shapeShiftWordForm = new ShapeShiftWordForm(bomb, logFileWriter, this);
                    shapeShiftWordForm.Show();

                    break;

                case "Skewed Slots":
                    skewedSlotForm = new SkewedSlotForm(bomb, logFileWriter, this);
                    skewedSlotForm.Show();
                    break;

                case "Switches":
                    switchesForm = new SwitchesForm(bomb, logFileWriter, this);
                    switchesForm.Show();
                    break;

                case "Tic Tac Toe":

                    ticTacToeForm = new TicTacToeForm(bomb, logFileWriter, this);
                    ticTacToeForm.Show();
                    break;

                case "Two Bits":

                    SuccessfulModuleOpening(moduleName);

                    if (twoBitsForm == null)
                    {
                        twoBitsForm = new TwoBitsStage1Form(bomb, logFileWriter, this);
                    }
                    else
                    {
                        twoBitsForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    twoBitsForm.Show();
                    break;

                case "Who's on First":

                    if (whosOnFirstForm == null)
                        whosOnFirstForm = new WhosOnFirstFirstStageForm(bomb, logFileWriter, this);
                    else
                        whosOnFirstForm.UpdateForm(bomb, logFileWriter, this);

                    whosOnFirstForm.Show();
                    break;

                case "Wires":

                    if (wiresForm == null)
                    {
                        wiresForm = new WiresForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        wiresForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    wiresForm.Show();
                    break;

                case "Wires Sequence":

                    if (wireSequenceForm == null)
                    {
                        wireSequenceForm = new WireSequenceStage1Form(bomb, logFileWriter, this);
                    }
                    else
                    {
                        wireSequenceForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    wireSequenceForm.Show();
                    break;

                case "Word Search":

                    if (wordSearchForm == null)
                    {
                        wordSearchForm = new WordSearchForm(bomb, logFileWriter, this);
                    }
                    else
                    {
                        wordSearchForm.UpdateForm(bomb, logFileWriter, this);
                    }

                    wordSearchForm.Show();
                    break;

                //this means that the module doesn't exist
                default:
                    this.Show();
                    break;
            }

            if (moduleName != "Two Bits")
            {
                SuccessfulModuleOpening(moduleName);
            }
        }

        /// <summary>
        /// Tells the log the module opend successfully
        /// </summary>
        /// <param name="module"></param>
        private void SuccessfulModuleOpening(String module)
        {
            PrintDebugLine($"{module} opened successfully\n");
        }

        private void PrintDebugLine(String message)
        {
            PrintDebug(message + "\n");
        }

        private void PrintDebug(String message)
        {
            logFileWriter.Write(message);
            System.Diagnostics.Debug.Write(message);
        }
    }
}
