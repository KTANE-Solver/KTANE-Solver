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
    public partial class ChordQualitiesForm : ModuleForm
    {
        public ChordQualitiesForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Chord Qualities", false)
        {
            InitializeComponent();
            UpdateForm();
        }

        private void UpdateForm()
        {
            UpdateNoteComboBox(note1ComboBox);
            UpdateNoteComboBox(note2ComboBox);
            UpdateNoteComboBox(note3ComboBox);
            UpdateNoteComboBox(note4ComboBox);
        }

        private void UpdateNoteComboBox(ComboBox comboBox)
        {
            string[] notes = new string[]
            {
                "A",
                "A#",
                "B",
                "C",
                "C#",
                "D",
                "D#",
                "E",
                "F",
                "F#",
                "G",
                "G#"
            };

            comboBox.Items.Clear();
            comboBox.Items.AddRange(notes);
            comboBox.Text = notes[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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
            string note1 = note1ComboBox.Text;
            string note2 = note2ComboBox.Text;
            string note3 = note3ComboBox.Text;
            string note4 = note4ComboBox.Text;

            if (
                note1 == note2
                || note1 == note3
                || note1 == note4
                || note2 == note3
                || note2 == note4
                || note3 == note4
            )
            {
                ShowErrorMessage("Can't have duplicate Notes");
                return;
            }

            ChordQualities module = new ChordQualities(
                Bomb,
                LogFileWriter,
                new List<string>() { note1, note2, note3, note4}
            );

            module.Solve(false);
            UpdateForm();
        }
    }
}
