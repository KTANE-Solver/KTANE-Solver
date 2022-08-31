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
    public partial class BrokenButtonsWordSelectionForm : Form
    {
        private BrokenButtons module;

        public BrokenButtonsWordSelectionForm(
            string type,
            BrokenButtons module,
            StreamWriter logFileWriter
        )
        {
            InitializeComponent();
            this.module = module;
            UpdateForm(type);
        }

        private void UpdateForm(string type)
        {
            List<string> words = new List<string>();

            words.AddRange(
                new string[]
                {
                    // Explosion Related
                    "bomb",
                    "blast",
                    "boom",
                    "burst",
                    // Bomb Components
                    "wire",
                    "button",
                    "module",
                    "light",
                    "led",
                    "switch",
                    "RJ-45",
                    "DVI-D",
                    "RCA",
                    "PS/2",
                    "serial",
                    "port",
                    // Descriptions
                    "row",
                    "column",
                    "one",
                    "two",
                    "three",
                    "four",
                    "five",
                    "six",
                    "seven",
                    "eight",
                    "size",
                    // Misc
                    "this",
                    "that",
                    "other",
                    "submit",
                    "abort",
                    "drop",
                    "thing",
                    "blank",
                    "",
                    "broken",
                    "too",
                    "to",
                    "yes",
                    "see",
                    "sea",
                    "c",
                    "wait",
                    "word",
                    "bob",
                    "no",
                    "not",
                    "first",
                    "hold",
                    "late",
                    "fail"
                }
            );

            switch (type)
            {
                case "T":

                    for (int i = words.Count - 1; i > -1; i--)
                    {
                        string word = words[i];

                        if (word == "" || word[0] != 't')
                        {
                            words.Remove(word);
                        }
                    }
                    break;

                case "Port":
                    words = new string[]
                    {
                        "RJ-45",
                        "DVI-D",
                        "RCA",
                        "PS/2",
                        "serial"
                    }.ToList<string>();
                    break;

                case "threeLess":

                    for (int i = words.Count - 1; i > -1; i--)
                    {
                        string word = words[i];

                        if (word.Length >= 3)
                        {
                            words.Remove(word);
                        }
                    }
                    break;
            }

            words.Sort((x, y) => string.Compare(x, y));

            for (int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].ToUpper();
            }

            comboBox.Items.Clear();
            comboBox.Items.AddRange(words.ToArray());
            comboBox.Text = words[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string answer = comboBox.Text;

            if (answer == "")
            {
                answer = "LITERALLY BLANK";
            }

            module.tempAnswer = answer;

            this.Close();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
