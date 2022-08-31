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
    public partial class ListeningForm : ModuleForm
    {
        public ListeningForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Listening", false)
        {
            InitializeComponent();
            UpdateForm();
        }

        private void UpdateForm()
        {
            string[] sounds = new string[]
            {
                "Arcade",
                "Ballpoint Pen Writing",
                "Beach",
                "Book Page Turning",
                "Car Engine",
                "Casino",
                "Censorship Bleep",
                "Chainsaw",
                "Compressed Air",
                "Cow",
                "Dial-up Internet",
                "Door Closing",
                "Extractor Fan",
                "Firework Exploding",
                "Glass Shattering",
                "Helicopter",
                "Marimba",
                "Medieval Weapons",
                "Phone Ringing",
                "Police Radio Scanner",
                "Oboe",
                "Reloading Glock 19",
                "Rattling Iron Chain",
                "Saxophone",
                "Servo Motor",
                "Sewing Machine",
                "Soccer Match",
                "Squeaky Toy",
                "Supermarket",
                "Table Tennis",
                "Tawny Owl",
                "Taxi Dispatch",
                "Throat Singing",
                "Tearing Fabric",
                "Tibetan Nuns",
                "Thrush Nightingale",
                "Train Station",
                "Tuba",
                "Vacuum Cleaner",
                "Waterfall",
                "Zipper"
            };

            soundComboBox.Items.Clear();
            soundComboBox.Items.AddRange(sounds);
            soundComboBox.Text = sounds[0];
            soundComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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
            Listening module = new Listening(soundComboBox.Text, Bomb, LogFileWriter);
            module.Solve();
            UpdateForm();
        }
    }
}
