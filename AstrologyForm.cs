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
    public partial class AstrologyForm : ModuleForm
    {
        //the name of the selected images
        private String image1Name;
        private String image2Name;
        private String image3Name;

        public AstrologyForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Astrology", false)
        {
            InitializeComponent();

            airButton.Image = SetUpImage("Air");
            aquariusButton.Image = SetUpImage("Aquarius");
            ariesButton.Image = SetUpImage("Aries");
            cancerButton.Image = SetUpImage("Cancer");
            capricornButton.Image = SetUpImage("Capricorn");
            earthButton.Image = SetUpImage("Earth");
            fireButton.Image = SetUpImage("Fire");
            geminiButton.Image = SetUpImage("Gemini");
            jupiterButton.Image = SetUpImage("Jupiter");
            leoButton.Image = SetUpImage("Leo");
            libraButton.Image = SetUpImage("Libra");
            marsButton.Image = SetUpImage("Mars");
            mercuryButton.Image = SetUpImage("Mercury");
            moonButton.Image = SetUpImage("Moon");
            neptuneButton.Image = SetUpImage("Neptune");
            piscesButton.Image = SetUpImage("Pisces");
            plutoButton.Image = SetUpImage("Pluto");
            sagittariusButton.Image = SetUpImage("Sagittarius");
            saturnButton.Image = SetUpImage("Saturn");
            scorpioButton.Image = SetUpImage("Scorpio");
            sunButton.Image = SetUpImage("Sun");
            taurusButton.Image = SetUpImage("Taurus");
            uranusButton.Image = SetUpImage("Uranus");
            venusButton.Image = SetUpImage("Venus");
            virgoButton.Image = SetUpImage("Virgo");
            waterButton.Image = SetUpImage("Water");

            //set up event triggers for each buttons
            airButton.Click += new EventHandler(AddSelection);
            aquariusButton.Click += new EventHandler(AddSelection);
            ariesButton.Click += new EventHandler(AddSelection);
            cancerButton.Click += new EventHandler(AddSelection);
            capricornButton.Click += new EventHandler(AddSelection);
            earthButton.Click += new EventHandler(AddSelection);
            fireButton.Click += new EventHandler(AddSelection);
            geminiButton.Click += new EventHandler(AddSelection);
            jupiterButton.Click += new EventHandler(AddSelection);
            leoButton.Click += new EventHandler(AddSelection);
            libraButton.Click += new EventHandler(AddSelection);
            marsButton.Click += new EventHandler(AddSelection);
            mercuryButton.Click += new EventHandler(AddSelection);
            moonButton.Click += new EventHandler(AddSelection);
            neptuneButton.Click += new EventHandler(AddSelection);
            piscesButton.Click += new EventHandler(AddSelection);
            plutoButton.Click += new EventHandler(AddSelection);
            sagittariusButton.Click += new EventHandler(AddSelection);
            saturnButton.Click += new EventHandler(AddSelection);
            scorpioButton.Click += new EventHandler(AddSelection);
            sunButton.Click += new EventHandler(AddSelection);
            taurusButton.Click += new EventHandler(AddSelection);
            uranusButton.Click += new EventHandler(AddSelection);
            venusButton.Click += new EventHandler(AddSelection);
            virgoButton.Click += new EventHandler(AddSelection);
            waterButton.Click += new EventHandler(AddSelection);

            selectedImageButton1.Click += new EventHandler(DeleteSelection);
            selectedImageButton2.Click += new EventHandler(DeleteSelection);
            selectedImageButton3.Click += new EventHandler(DeleteSelection);
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
        }

        /// <summary>
        /// Gets images from the astrology folder
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private Image SetUpImage(String fileName)
        {
            return Image.FromFile($"Astrology Pictures/{fileName}.png");
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
            PrintHeader();

            //must have 3 image
            if (SelectedImageNum() != 3)
            {
                ShowErrorMessage("Must have 3 images to continue");
                return;
            }

            //first symbol must be element
            if (!IsElement(image1Name))
            {
                ShowErrorMessage("First symbol must be an element");
                return;
            }

            //second symbol must be planet
            if (!IsPlanet(image2Name))
            {
                ShowErrorMessage("Second symbol must be a planet");
                return;
            }

            //third symbol must be zodiac
            if (IsElement(image3Name) || IsPlanet(image3Name))
            {
                ShowErrorMessage("Third symbol must be a zodiac sign");
                return;
            }

            Astrology module = new Astrology(
                Bomb,
                LogFileWriter,
                image1Name,
                image2Name,
                image3Name
            );
            module.Solve();

            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }

        /// <summary>
        /// tells if the name is an element
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool IsElement(string name)
        {
            switch (name)
            {
                case "Fire":
                case "Water":
                case "Earth":
                case "Air":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// tells if the name is a planet
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool IsPlanet(string name)
        {
            switch (name)
            {
                case "Sun":
                case "Moon":
                case "Mercury":
                case "Venus":
                case "Mars":
                case "Jupiter":
                case "Saturn":
                case "Uranus":
                case "Neptune":
                case "Pluto":
                    return true;
                default:
                    return false;
            }
        }

        private bool IsZodiac(string name)
        {
            return !IsPlanet(name) && !IsElement(name);
        }

        /// <summary>
        /// Adds the image the user selected as one of the selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSelection(object sender, EventArgs e)
        {
            System.Windows.Forms.Button selectedButton = (System.Windows.Forms.Button)sender;

            //the image that was selected
            Image selectedImage = selectedButton.Image;

            string imageName = GetFileName(selectedButton);

            if (IsElement(imageName) && selectedImageButton1.Image == null)
            {
                //if there's no element in the element slot, add the selected image there
                selectedImageButton1.Image = selectedImage;
                image1Name = imageName;
            }
            //check to see if which slot the image belongs in
            else if (IsPlanet(imageName) && selectedImageButton2.Image == null)
            {
                //if there's no planet in the planet slot, add the selected image there
                selectedImageButton2.Image = selectedImage;
                image2Name = imageName;
            }
            else if (IsZodiac(imageName) && selectedImageButton3.Image == null)
            {
                //if there's no zodiac in the zodiac slot, add the selected image there
                selectedImageButton3.Image = selectedImage;
                image3Name = imageName;
            }
        }

        private string GetFileName(System.Windows.Forms.Button selectedButton)
        {
            if (selectedButton == airButton)
                return "Air";

            if (selectedButton == aquariusButton)
                return "Aquarius";

            if (selectedButton == ariesButton)
                return "Aries";

            if (selectedButton == cancerButton)
                return "Cancer";

            if (selectedButton == capricornButton)
                return "Capricorn";

            if (selectedButton == earthButton)
                return "Earth";

            if (selectedButton == fireButton)
                return "Fire";

            if (selectedButton == geminiButton)
                return "Gemini";

            if (selectedButton == jupiterButton)
                return "Jupiter";

            if (selectedButton == leoButton)
                return "Leo";

            if (selectedButton == libraButton)
                return "Libra";

            if (selectedButton == marsButton)
                return "Mars";

            if (selectedButton == mercuryButton)
                return "Mercury";

            if (selectedButton == moonButton)
                return "Moon";

            if (selectedButton == neptuneButton)
                return "Neptune";

            if (selectedButton == piscesButton)
                return "Pisces";

            if (selectedButton == plutoButton)
                return "Pluto";

            if (selectedButton == sagittariusButton)
                return "Sagittarius";

            if (selectedButton == saturnButton)
                return "Saturn";

            if (selectedButton == scorpioButton)
                return "Scorpio";

            if (selectedButton == sunButton)
                return "Sun";

            if (selectedButton == taurusButton)
                return "Taurus";

            if (selectedButton == uranusButton)
                return "Uranus";

            if (selectedButton == venusButton)
                return "Venus";

            if (selectedButton == virgoButton)
                return "Virgo";

            return "Water";
        }

        /// <summary>
        /// A method that will delete an image from the current selection
        /// and shift the other images to the left
        /// </summary>
        private void DeleteSelection(object sender, EventArgs e)
        {
            System.Windows.Forms.Button selectedButton = (System.Windows.Forms.Button)sender;

            selectedButton.Image = null;
        }

        /// <summary>
        /// Tells how many images are currently selected
        /// </summary>
        /// <returns></returns>
        private int SelectedImageNum()
        {
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
                || selectedImageButton3.Image == selectedImage;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void airButton_Click(object sender, EventArgs e)
        {

        }

        private void fireButton_Click(object sender, EventArgs e)
        {

        }

        private void waterButton_Click(object sender, EventArgs e)
        {

        }

        private void earthButton_Click(object sender, EventArgs e)
        {

        }

        private void jupiterButton_Click(object sender, EventArgs e)
        {

        }

        private void AstrologyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
