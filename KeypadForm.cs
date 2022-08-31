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
    /// Purpose: Gets information needed to solve the keypad module
    /// </summary>

    public partial class KeypadForm : ModuleForm
    {
        //the name of the selected images
        private String image1Name;
        private String image2Name;
        private String image3Name;
        private String image4Name;

        public KeypadForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Keypad", false)
        {
            InitializeComponent();

            UpdateForm(bomb, logFileWriter, moduleSelectionForm);

            //setting up the imaages for the buttons
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

            //set up event triggers for each buttons
            threeButton.Click += new EventHandler(AddSelection);
            sixButton.Click += new EventHandler(AddSelection);
            aButton.Click += new EventHandler(AddSelection);
            aeButton.Click += new EventHandler(AddSelection);
            bButton.Click += new EventHandler(AddSelection);
            backwardsCButton.Click += new EventHandler(AddSelection);
            blackStarButton.Click += new EventHandler(AddSelection);
            buttButton.Click += new EventHandler(AddSelection);
            cButton.Click += new EventHandler(AddSelection);
            copyrightButton.Click += new EventHandler(AddSelection);
            eButton.Click += new EventHandler(AddSelection);
            hButton.Click += new EventHandler(AddSelection);
            hashtagButton.Click += new EventHandler(AddSelection);
            lambdaButton.Click += new EventHandler(AddSelection);
            lightningButton.Click += new EventHandler(AddSelection);
            nButton.Click += new EventHandler(AddSelection);
            oButton.Click += new EventHandler(AddSelection);
            omegaButton.Click += new EventHandler(AddSelection);
            paragraphButton.Click += new EventHandler(AddSelection);
            questionMarkButton.Click += new EventHandler(AddSelection);
            smilyFaceButton.Click += new EventHandler(AddSelection);
            squidButton.Click += new EventHandler(AddSelection);
            swirlButton.Click += new EventHandler(AddSelection);
            tridentButton.Click += new EventHandler(AddSelection);
            unfinishedRButton.Click += new EventHandler(AddSelection);
            whiteStarButton.Click += new EventHandler(AddSelection);
            xButton.Click += new EventHandler(AddSelection);

            selectedImageButton1.Click += new EventHandler(DeleteSelection);
            selectedImageButton2.Click += new EventHandler(DeleteSelection);
            selectedImageButton3.Click += new EventHandler(DeleteSelection);
            selectedImageButton4.Click += new EventHandler(DeleteSelection);
        }

        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            selectedImageButton1.Image = null;
            selectedImageButton2.Image = null;
            selectedImageButton3.Image = null;
            selectedImageButton4.Image = null;
        }

        /// <summary>
        /// A helper method that will load
        /// the images for the buttons
        /// </summary>
        /// <param name="fileName">the name of the image</param>
        private Image SetUpImage(String fileName)
        {
            return Image.FromFile($"Keypad Pictures/{fileName}.png");
        }

        /// <summary>
        /// A method that will add image to the current selection as long as
        /// the selection isn't full and the image isn't already selected
        /// </summary>
        private void AddSelection(object sender, EventArgs e)
        {
            //the image that was selected
            Image selectedImage = ((System.Windows.Forms.Button)sender).Image;

            System.Windows.Forms.Button selectedButton = (System.Windows.Forms.Button)sender;

            //check to see if the selection is full and if the selected image is already selected,
            //if neither add the selected image to the current selection
            if (SelectedImageNum() != 4 && !ImageSelected(selectedImage))
            {
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

                if (selectedImageButton1.Image == null)
                {
                    selectedImageButton1.Image = selectedImage;
                    image1Name = fileName;
                }
                else if (selectedImageButton2.Image == null)
                {
                    selectedImageButton2.Image = selectedImage;
                    image2Name = fileName;
                }
                else if (selectedImageButton3.Image == null)
                {
                    selectedImageButton3.Image = selectedImage;
                    image3Name = fileName;
                }
                else if (selectedImageButton4.Image == null)
                {
                    selectedImageButton4.Image = selectedImage;
                    image4Name = fileName;
                }
            }
        }

        /// <summary>
        /// A method that will delete an image from the current selection
        /// and shift the other images to the left
        /// </summary>
        private void DeleteSelection(object sender, EventArgs e)
        {
            System.Windows.Forms.Button selectedButton = (System.Windows.Forms.Button)sender;

            selectedButton.Image = null;

            if (selectedButton == selectedImageButton3)
            {
                selectedImageButton3.Image = selectedImageButton4.Image;
                image3Name = image4Name;

                selectedImageButton4.Image = null;
                image4Name = "";
            }
            else if (selectedButton == selectedImageButton2)
            {
                selectedImageButton2.Image = selectedImageButton3.Image;
                image2Name = image3Name;

                selectedImageButton3.Image = selectedImageButton4.Image;
                image3Name = image4Name;

                selectedImageButton4.Image = null;
                image4Name = "";
            }
            else if (selectedButton == selectedImageButton1)
            {
                selectedImageButton1.Image = selectedImageButton2.Image;
                image1Name = image2Name;

                selectedImageButton2.Image = selectedImageButton3.Image;
                image2Name = image3Name;

                selectedImageButton3.Image = selectedImageButton4.Image;
                image3Name = image4Name;

                selectedImageButton4.Image = null;
                image4Name = "";
            }
        }

        /// <summary>
        /// A helper method that will tell how many selected images there are
        /// </summary>
        private int SelectedImageNum()
        {
            if (selectedImageButton4.Image != null)
                return 4;

            if (selectedImageButton3.Image != null)
                return 3;

            if (selectedImageButton2.Image != null)
                return 2;

            if (selectedImageButton1.Image != null)
                return 1;

            return 0;
        }

        /// <summary>
        /// Tells if an image has already been selected
        /// </summary>
        private bool ImageSelected(Image selectedImage)
        {
            return selectedImageButton1.Image == selectedImage
                || selectedImageButton2.Image == selectedImage
                || selectedImageButton3.Image == selectedImage
                || selectedImageButton4.Image == selectedImage;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //must have 4 image
            if (SelectedImageNum() != 4)
            {
                ShowErrorMessage("Must have 4 images to continue");
                return;
            }

            PrintHeader();

            Keypad module = new Keypad(
                image1Name,
                image2Name,
                image3Name,
                image4Name,
                Bomb,
                LogFileWriter
            );

            module.Solve();

            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }
    }
}
