using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class ColorFlash1 : Module
    {
        string lastColor;
        public ColorFlash1(string lastColor,StreamWriter logFileWriter) : base(null, logFileWriter, "Color Flash")
        {
            this.lastColor = lastColor;
        }

        public string Solve(bool debug)
        {
            string answer;
            switch (lastColor)
            {
                case "Red":
                    if (MessageBox.Show("Is green is used as the word at least three times in the sequence?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press Yes on the third time Green is used as either the word or the colour of the word in the sequence";
                    }

                    else if (MessageBox.Show("Is Blue is used as the colour of the word exactly once?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press No when the word Magenta is shown";
                    }

                    else
                    {
                        answer = "press Yes the last time White is either the word or the colour of the word in the sequence";
                    }

                    break;

                case "Yellow":
                    if (MessageBox.Show("Is the word Blue is shown in Green colour?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press Yes on the third time Green is used as either the word or the colour of the word in the sequence";
                    }

                    else if (MessageBox.Show("Is the word White is shown in either White or Red colour?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press Yes on the second time in the sequence where the colour of the word does not match the word itself";
                    }

                    else
                    {
                        answer = "count the number of times Magenta is used as either the word or the colour of the word in the sequence";
                    }

                    break;

                case "Green":
                    if (MessageBox.Show("Is a word occurs consecutively with different colours?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press No on the fifth entry in the sequence";
                    }

                    else if (MessageBox.Show("Is Magenta is used as the word at least three times in the sequence?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press No on the first time Yellow is used as either the word or the colour of the word in the sequence";
                    }

                    else
                    {
                        answer = "press Yes on any colour where the colour of the word matches the word itself";
                    }
                    break ;

                case "Blue":
                    if (MessageBox.Show("Is the colour of the word does not match the word itself three times or more in the sequence?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press Yes on the first time in the sequence where the colour of the word does not match the word itself";
                    }

                    else if (MessageBox.Show("Is the word Red is shown in Yellow colour or the word Yellow is shown in White colour?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press No when the word White is shown in Red colour";
                    }

                    else
                    {
                        answer = "press Yes the last time Green is either the word or the colour of the word in the sequence";
                    }
                    break;

                case "Magenta":
                    if (MessageBox.Show("Is a colour occurs consecutively with different words?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press Yes on the third entry in the sequence";
                    }

                    else if (MessageBox.Show("Is the number of times the word Yellow appears is greater than the number of times that the colour of the word is Blue?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press No the last time the word Yellow is in the sequence";
                    }

                    else
                    {
                        answer = "press No on the first time in the sequence where the colour of the word matches the word of the seventh entry in the sequence";
                    }
                    break;

                    default:
                    if (MessageBox.Show("Is the colour of the third word matches the word of the fourth word or fifth word?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press No the first time that Blue is used as the word or the colour of the word in the sequence";
                    }

                    else if (MessageBox.Show("Is the word Yellow is shown in Red colour?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        answer = "press Yes on the last time Blue is used as the colour of the word";
                    }

                    else
                    {
                        answer = "press No";
                    }
                    break;
            }

            if (!debug)
            {
                ShowAnswer(answer, true);
            }

            return answer;
        }
    }
}
