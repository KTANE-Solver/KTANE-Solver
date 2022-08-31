using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class BrokenButtons : Module
    {
        public List<string> buttonPressed;

        private bool leftSubmitButton;

        public string tempAnswer;
        public bool closeProgram;

        public BrokenButtons(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Broken Buttons")
        {
            leftSubmitButton = true;

            buttonPressed = new List<string>();
            closeProgram = false;
        }

        public void Solve()
        {
            string answer = "left";

            if (!leftSubmitButton)
            {
                answer = "right";
            }

            ShowAnswer($"Press the {answer} submit button", true);
        }

        public void FindButtonToPress()
        {
            string answer = "";

            if (AskWordAppearQuestion("SEA"))
            {
                answer = "SEA";
            }
            else if (
                AskQuestion("Is there a button on the third or first row starts with the letter T?")
            )
            {
                BrokenButtonsWordSelectionForm wordSelectionForm =
                    new BrokenButtonsWordSelectionForm("T", this, LogFileWriter);
                wordSelectionForm.ShowDialog();
                answer = tempAnswer;
            }
            else if (AskMutipleWordAppearQuestion("ONE", "SUBMIT", true))
            {
                answer = "ONE";
                PrintDebug("Found ONE AND SUBMIT. ");

                leftSubmitButton = true;

                PrintSubitButtonDebugLine();
            }
            else if (AskQuestion("Is there a button that is literally blank?"))
            {
                answer = "LITERALLY BLANK";
            }
            else if (AskWordAppearQuestion("OTHER"))
            {
                answer = "OTHER";
                leftSubmitButton = !leftSubmitButton;

                PrintDebug("Found OTHER. ");

                PrintSubitButtonDebugLine();
            }
            else if (AskQuestion("Is there a duplicate word?"))
            {
                BrokenButtonsWordSelectionForm wordSelectionForm =
                    new BrokenButtonsWordSelectionForm("All", this, LogFileWriter);
                wordSelectionForm.ShowDialog();
                answer = tempAnswer;
            }
            else if (
                AskQuestion("Is there a button that has a port name on it?")
                && AskMutipleWordAppearQuestion("MODULE", "PORT", false)
            )
            {
                BrokenButtonsWordSelectionForm wordSelectionForm =
                    new BrokenButtonsWordSelectionForm("Port", this, LogFileWriter);
                wordSelectionForm.ShowDialog();
                answer = tempAnswer;
            }
            else if (AskMutipleWordAppearQuestion("BOOM", "BOMB", true))
            {
                answer = "BOOM";
            }
            else if (AskQuestion("Is there a button that has less than 3 characters on it?"))
            {
                BrokenButtonsWordSelectionForm wordSelectionForm =
                    new BrokenButtonsWordSelectionForm("threeLess", this, LogFileWriter);
                wordSelectionForm.ShowDialog();
                answer = tempAnswer;
            }
            else if (AskMutipleWordAppearQuestion("SUBMIT", "BUTTON", true))
            {
                answer = "DON'T PRESS";
            }
            else if (
                AskWordAppearQuestion("COLUMN")
                && AskMutipleWordAppearQuestion("SEVEN", "TWO", false)
            )
            {
                answer = "COLUMN";
            }
            else if (buttonPressed.Count == 0)
            {
                ShowAnswer("Find the word that is in the 2nd row and 3rd column", false);
                BrokenButtonsWordSelectionForm wordSelectionForm =
                    new BrokenButtonsWordSelectionForm("All", this, LogFileWriter);
                wordSelectionForm.ShowDialog();
                answer = tempAnswer;
            }
            else if ((buttonPressed.Count != 0 && buttonPressed[0].Contains('E')))
            {
                answer = "NO ANSWER";
                leftSubmitButton = false;

                PrintDebug("First button contains an E. ");

                PrintSubitButtonDebugLine();

                buttonPressed.Add(answer);
            }

            if (answer == "LITERALLY BLANK")
            {
                ShowAnswer("Press the literally blank button", false);
                buttonPressed.Add("");
                PrintDebugLine(
                    $"{buttonPressed.Count}: {buttonPressed[buttonPressed.Count - 1]}\n"
                );
            }
            else if (answer != "DON'T PRESS" && answer != "NO ANSWER" && answer != "")
            {
                ShowAnswer($"Press \"{answer}\"", false);
                buttonPressed.Add(answer);
                PrintDebugLine(
                    $"{buttonPressed.Count}: {buttonPressed[buttonPressed.Count - 1]}\n"
                );
            }
            else
            {
                answer = "NO ANSWER";
                buttonPressed.Add(answer);
            }
        }

        private void PrintSubitButtonDebugLine()
        {
            string side = "left";

            if (!leftSubmitButton)
            {
                side = "right";
            }

            PrintDebugLine($"The {side} is now the correct submit button\n");
        }

        private bool AskWordAppearQuestion(string word)
        {
            return AskQuestion($"Is there a button labled \"{word}\"?");
        }

        private bool AskMutipleWordAppearQuestion(string word1, string word2, bool and)
        {
            if (and)
            {
                return AskQuestion($"Are there buttons labled \"{word1}\" AND labled \"{word2}\"?");
            }

            return AskQuestion($"Are there buttons labled \"{word1}\" OR labled \"{word2}\"?");
        }

        private bool AskQuestion(string question)
        {
            return MessageBox.Show(question, "The Bulb", MessageBoxButtons.YesNo)
                == DialogResult.Yes;
        }
    }
}
