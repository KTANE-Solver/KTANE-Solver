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
    public partial class RoundKeypadForm : ModuleForm
    {
        private RoundKeypad.Symbol[] symbols;
        private List<System.Windows.Forms.Button> buttonList;

        private List<System.Windows.Forms.Button> fixedButtonList;

        public RoundKeypadForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Round Keypad", false)
        {
            InitializeComponent();

            symbols = new RoundKeypad.Symbol[8];

            fixedButtonList = new List<System.Windows.Forms.Button>()
            {
                threeButton,
                sixButton,
                aButton,
                aeButton,
                bButton,
                backwardsCButton,
                blackStarButton,
                buttButton,
                cButton,
                copyrightButton,
                eButton,
                hButton,
                hashtagButton,
                lambdaButton,
                lightningButton,
                nButton,
                oButton,
                omegaButton,
                paragraphButton,
                questionMarkButton,
                smilyFaceButton,
                squidButton,
                swirlButton,
                tridentButton,
                unfinishedRButton,
                whiteStarButton,
                xButton
            };

            buttonList = new List<System.Windows.Forms.Button>()
            {
                northButton,
                northEastButton,
                eastButton,
                southEastButton,
                southButton,
                southWestButton,
                westButton,
                northWestButton
            };

            foreach (System.Windows.Forms.Button b in fixedButtonList)
            {
                b.Click += new EventHandler(AddSelection);
            }

            foreach (System.Windows.Forms.Button b in buttonList)
            {
                b.Click += new EventHandler(RemoveSelection);
            }

            threeButton.Image = SetUpImage("3");
            sixButton.Image = SetUpImage("6");
            aButton.Image = SetUpImage("A");
            aeButton.Image = SetUpImage("AE");
            bButton.Image = SetUpImage("B");
            backwardsCButton.Image = SetUpImage("Backwards C");
            blackStarButton.Image = SetUpImage("Black Star");
            buttButton.Image = SetUpImage("Butt");
            cButton.Image = SetUpImage("C");
            copyrightButton.Image = SetUpImage("Copyright");
            eButton.Image = SetUpImage("E");
            hButton.Image = SetUpImage("H");
            hashtagButton.Image = SetUpImage("Hashtag");
            lambdaButton.Image = SetUpImage("Lambda");
            lightningButton.Image = SetUpImage("Lightning");
            nButton.Image = SetUpImage("N");
            oButton.Image = SetUpImage("O");
            omegaButton.Image = SetUpImage("Omega");
            paragraphButton.Image = SetUpImage("Paragraph");
            questionMarkButton.Image = SetUpImage("Question Mark");
            smilyFaceButton.Image = SetUpImage("Smily Face");
            squidButton.Image = SetUpImage("Squid");
            swirlButton.Image = SetUpImage("Swirl");
            tridentButton.Image = SetUpImage("Trident");
            unfinishedRButton.Image = SetUpImage("Unfinished R");
            whiteStarButton.Image = SetUpImage("White Star");
            xButton.Image = SetUpImage("X");

            UpdateForm();
        }

        private void UpdateForm()
        {
            foreach (System.Windows.Forms.Button b in buttonList)
            {
                b.Image = null;
            }
        }

        private void UpdateColoredButton()
        {
            int nullIndex = -1;

            for (int i = 0; i > buttonList.Count; i++)
            {
                if (buttonList[i].Image == null)
                {
                    buttonList[i].BackColor = Color.Red;
                    nullIndex = i;
                    break;
                }
            }

            for (int i = 0; i > buttonList.Count; i++)
            {
                if (i == nullIndex)
                {
                    continue;
                }

                buttonList[i].BackColor = default;
            }
        }

        private void RemoveSelection(object sender, EventArgs e)
        {
            System.Windows.Forms.Button selectedButton = (System.Windows.Forms.Button)sender;

            selectedButton.Image = null;

            UpdateColoredButton();
        }

        private void AddSelection(object sender, EventArgs e)
        {
            System.Windows.Forms.Button nullImageButton = null;

            foreach (System.Windows.Forms.Button b in buttonList)
            {
                if (b.Image == null)
                {
                    nullImageButton = b;
                    break;
                }
            }

            if (nullImageButton == null)
            {
                return;
            }

            //the image that was selected
            Image selectedImage = ((System.Windows.Forms.Button)sender).Image;

            System.Windows.Forms.Button selectedButton = (System.Windows.Forms.Button)sender;

            String fileName = null;

            //finding which button was selected
            if (selectedButton == threeButton)
                fileName = "3";
            else if (selectedButton == sixButton)
                fileName = "6";
            else if (selectedButton == aButton)
                fileName = "A";
            else if (selectedButton == aeButton)
                fileName = "AE";
            else if (selectedButton == bButton)
                fileName = "B";
            else if (selectedButton == backwardsCButton)
                fileName = "Backwards C";
            else if (selectedButton == blackStarButton)
                fileName = "Black Star";
            else if (selectedButton == buttButton)
                fileName = "Butt";
            else if (selectedButton == cButton)
                fileName = "C";
            else if (selectedButton == copyrightButton)
                fileName = "Copyright";
            else if (selectedButton == eButton)
                fileName = "E";
            else if (selectedButton == hButton)
                fileName = "H";
            else if (selectedButton == hashtagButton)
                fileName = "Hashtag";
            else if (selectedButton == lambdaButton)
                fileName = "Lambda";
            else if (selectedButton == lightningButton)
                fileName = "Lightning";
            else if (selectedButton == nButton)
                fileName = "N";
            else if (selectedButton == oButton)
                fileName = "O";
            else if (selectedButton == omegaButton)
                fileName = "Omega";
            else if (selectedButton == paragraphButton)
                fileName = "Paragraph";
            else if (selectedButton == questionMarkButton)
                fileName = "Question Mark";
            else if (selectedButton == smilyFaceButton)
                fileName = "Smily Face";
            else if (selectedButton == squidButton)
                fileName = "Squid";
            else if (selectedButton == swirlButton)
                fileName = "Swirl";
            else if (selectedButton == tridentButton)
                fileName = "Trident";
            else if (selectedButton == unfinishedRButton)
                fileName = "Unfinished R";
            else if (selectedButton == whiteStarButton)
                fileName = "White Star";
            else if (selectedButton == xButton)
                fileName = "X";

            nullImageButton.Image = selectedImage;

            symbols[buttonList.IndexOf(nullImageButton)] = FindSymbol(fileName);

            UpdateColoredButton();
        }

        private Image SetUpImage(String fileName)
        {
            return Image.FromFile($"Keypad Pictures/{fileName}.png");
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
            bool nullButton = false;

            foreach (System.Windows.Forms.Button b in buttonList)
            {
                if (b.BackColor == Color.Red)
                {
                    nullButton = true;
                    break;
                }
            }

            if (nullButton)
            {
                ShowErrorMessage("There neeeds to be 8 buttons selected");
                return;
            }

            RoundKeypad module = new RoundKeypad(Bomb, LogFileWriter, symbols.ToList());

            RoundKeypad.Symbol[] answer = module.Solve();

            RoundKeypadAnswerForm answerForm = new RoundKeypadAnswerForm(symbols, answer);
            answerForm.ShowDialog();
            UpdateForm();
        }

        private RoundKeypad.Symbol FindSymbol(String imageName)
        {
            switch (imageName)
            {
                case "3":
                    return RoundKeypad.Symbol.Three;

                case "6":
                    return RoundKeypad.Symbol.Six;

                case "A":
                    return RoundKeypad.Symbol.A;

                case "AE":
                    return RoundKeypad.Symbol.Ae;

                case "B":
                    return RoundKeypad.Symbol.B;

                case "Backwards C":
                    return RoundKeypad.Symbol.BackwardsC;

                case "Black Star":
                    return RoundKeypad.Symbol.BlackStar;

                case "Butt":
                    return RoundKeypad.Symbol.Butt;

                case "C":
                    return RoundKeypad.Symbol.C;

                case "Copyright":
                    return RoundKeypad.Symbol.Copyright;

                case "E":
                    return RoundKeypad.Symbol.E;

                case "H":
                    return RoundKeypad.Symbol.H;

                case "Hashtag":
                    return RoundKeypad.Symbol.Hashtag;

                case "Lambda":
                    return RoundKeypad.Symbol.Lambda;

                case "Lightning":
                    return RoundKeypad.Symbol.Lightning;

                case "N":
                    return RoundKeypad.Symbol.N;

                case "O":
                    return RoundKeypad.Symbol.O;

                case "Omega":
                    return RoundKeypad.Symbol.Omega;

                case "Paragraph":
                    return RoundKeypad.Symbol.Paragraph;

                case "Question Mark":
                    return RoundKeypad.Symbol.QuestionMark;

                case "Smily Face":
                    return RoundKeypad.Symbol.SmilyFace;

                case "Squid":
                    return RoundKeypad.Symbol.Squid;

                case "Swirl":
                    return RoundKeypad.Symbol.Swirl;

                case "Trident":
                    return RoundKeypad.Symbol.Trident;

                case "Unfinished R":
                    return RoundKeypad.Symbol.UfinishedR;

                case "White Star":
                    return RoundKeypad.Symbol.WhiteStar;

                case "X":
                    return RoundKeypad.Symbol.X;

                //should never happen
                default:
                    return RoundKeypad.Symbol.Null;
            }
        }
    }
}
