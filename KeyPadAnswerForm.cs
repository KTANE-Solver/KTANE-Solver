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
    /// Purpose: Shows the answer of keypad
    /// </summary>

    public partial class KeyPadAnswerForm : ModuleForm
    {
        //all of the images
        Image threeImage = Image.FromFile("Keypad Pictures/3.png");
        Image sixImage = Image.FromFile("Keypad Pictures/6.png");
        Image aImage = Image.FromFile("Keypad Pictures/A.png");
        Image aeImage = Image.FromFile("Keypad Pictures/AE.png");
        Image BImage = Image.FromFile("Keypad Pictures/B.png");
        Image backwardsCImage = Image.FromFile("Keypad Pictures/Backwards C.png");
        Image blackStarImage = Image.FromFile("Keypad Pictures/Black Star.png");
        Image buttImage = Image.FromFile("Keypad Pictures/Butt.png");
        Image cImage = Image.FromFile("Keypad Pictures/C.png");
        Image copyrightImage = Image.FromFile("Keypad Pictures/Copyright.png");
        Image eImage = Image.FromFile("Keypad Pictures/E.png");
        Image hImage = Image.FromFile("Keypad Pictures/H.png");
        Image hashtagImage = Image.FromFile("Keypad Pictures/Hashtag.png");
        Image lambdaImage = Image.FromFile("Keypad Pictures/Lambda.png");
        Image lightningImage = Image.FromFile("Keypad Pictures/Lightning.png");
        Image nImage = Image.FromFile("Keypad Pictures/N.png");
        Image oImage = Image.FromFile("Keypad Pictures/O.png");
        Image omegaImage = Image.FromFile("Keypad Pictures/Omega.png");
        Image paragraphImage = Image.FromFile("Keypad Pictures/Paragraph.png");
        Image questionMarkImage = Image.FromFile("Keypad Pictures/Question Mark.png");
        Image smilyFaceImage = Image.FromFile("Keypad Pictures/Smily Face.png");
        Image squidImage = Image.FromFile("Keypad Pictures/Squid.png");
        Image swirlImage = Image.FromFile("Keypad Pictures/Swirl.png");
        Image tridentImage = Image.FromFile("Keypad Pictures/Trident.png");
        Image unfinishedRImage = Image.FromFile("Keypad Pictures/Unfinished R.png");
        Image whiteStarImage = Image.FromFile("Keypad Pictures/White Star.png");
        Image xImage = Image.FromFile("Keypad Pictures/X.png");

        public KeyPadAnswerForm()
        {
            InitializeComponent();
        }

        public KeyPadAnswerForm(
            Keypad.Symbol symbol1,
            Keypad.Symbol symbol2,
            Keypad.Symbol symbol3,
            Keypad.Symbol symbol4
        ) : base(null, null, null, "Keypad", true)
        {
            InitializeComponent();
            UpdateForm(symbol1, symbol2, symbol3, symbol4);

            Text = ModuleName + " Answer";
        }

        public void UpdateForm(
            Keypad.Symbol symbol1,
            Keypad.Symbol symbol2,
            Keypad.Symbol symbol3,
            Keypad.Symbol symbol4
        )
        {
            button1.Image = GetImage(symbol1);
            button2.Image = GetImage(symbol2);
            button3.Image = GetImage(symbol3);
            button4.Image = GetImage(symbol4);
        }

        public Image GetImage(Keypad.Symbol symbol)
        {
            switch (symbol)
            {
                case Keypad.Symbol.Three:
                    return threeImage;

                case Keypad.Symbol.Six:
                    return sixImage;

                case Keypad.Symbol.A:
                    return aImage;

                case Keypad.Symbol.Ae:
                    return aeImage;

                case Keypad.Symbol.B:
                    return BImage;

                case Keypad.Symbol.BackwardsC:
                    return backwardsCImage;

                case Keypad.Symbol.BlackStar:
                    return blackStarImage;

                case Keypad.Symbol.Butt:
                    return buttImage;

                case Keypad.Symbol.C:
                    return cImage;

                case Keypad.Symbol.Copyright:
                    return copyrightImage;

                case Keypad.Symbol.E:
                    return eImage;

                case Keypad.Symbol.H:
                    return hImage;

                case Keypad.Symbol.Hashtag:
                    return hashtagImage;

                case Keypad.Symbol.Lambda:
                    return lambdaImage;

                case Keypad.Symbol.Lightning:
                    return lightningImage;

                case Keypad.Symbol.N:
                    return nImage;

                case Keypad.Symbol.O:
                    return oImage;

                case Keypad.Symbol.Omega:
                    return omegaImage;

                case Keypad.Symbol.Paragraph:
                    return paragraphImage;

                case Keypad.Symbol.QuestionMark:
                    return questionMarkImage;

                case Keypad.Symbol.SmilyFace:
                    return smilyFaceImage;

                case Keypad.Symbol.Squid:
                    return squidImage;

                case Keypad.Symbol.Swirl:
                    return swirlImage;

                case Keypad.Symbol.Trident:
                    return tridentImage;

                case Keypad.Symbol.UfinishedR:
                    return unfinishedRImage;

                case Keypad.Symbol.WhiteStar:
                    return whiteStarImage;

                case Keypad.Symbol.X:
                    return xImage;

                default:
                    return null;
            }
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
