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
                "ASharp",
                "B",
                "C",
                "CSharp",
                "D",
                "DSharp",
                "E",
                "F",
                "FSharp",
                "G",
                "GSharp"
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
            ChordQualities.Note note1 = ConvertStringToNote(note1ComboBox.Text);
            ChordQualities.Note note2 = ConvertStringToNote(note2ComboBox.Text);
            ChordQualities.Note note3 = ConvertStringToNote(note3ComboBox.Text);
            ChordQualities.Note note4 = ConvertStringToNote(note4ComboBox.Text);

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
                note1,
                note2,
                note3,
                note4
            );
            module.Solve();
            UpdateForm();
        }

        private ChordQualities.Note ConvertStringToNote(string note)
        {
            switch (note)
            {
                case "A":
                    return ChordQualities.Note.A;

                case "ASharp":
                    return ChordQualities.Note.ASharp;

                case "B":
                    return ChordQualities.Note.B;

                case "C":
                    return ChordQualities.Note.C;

                case "CSharp":
                    return ChordQualities.Note.CSharp;

                case "D":
                    return ChordQualities.Note.D;

                case "DSharp":
                    return ChordQualities.Note.DSharp;

                case "E":
                    return ChordQualities.Note.E;

                case "F":
                    return ChordQualities.Note.F;

                case "FSharp":
                    return ChordQualities.Note.FSharp;

                case "G":
                    return ChordQualities.Note.G;

                default:
                    return ChordQualities.Note.GSharp;
            }
        }
    }
}
