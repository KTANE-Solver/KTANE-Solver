using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the password module
    /// </summary>
    public class Password : Module
    {
        public List<char> firstRow;
        public List<char> secondRow;
        public List<char> thirdRow;
        public List<char> fourthRow;
        public List<char> fifthRow;

        public Password(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Password")
        {
            firstRow = new List<char>();
            secondRow = new List<char>();
            thirdRow = new List<char>();
            fourthRow = new List<char>();
            fifthRow = new List<char>();
        }

        public void FillRow(
            char letter1,
            char letter2,
            char letternum,
            char letter4,
            char letter5,
            char letter6,
            int num
        )
        {
            List<char> list = new List<char>
            {
                letter1,
                letter2,
                letternum,
                letter4,
                letter5,
                letter6
            };

            switch (num)
            {
                case 1:
                    firstRow.AddRange(list);
                    break;

                case 2:
                    secondRow.AddRange(list);
                    break;

                case 3:
                    thirdRow.AddRange(list);
                    break;

                case 4:
                    fourthRow.AddRange(list);
                    break;

                default:
                    fifthRow.AddRange(list);
                    break;
            }
        }

        /// <summary>
        /// Attempts to solve the moudle given
        /// only the first three rows
        /// </summary>
        /// <returns></returns>
        public List<String> Solve(int num)
        {
            //a list of all the possible answers
            List<String> possibleAnswer = new List<string>();

            if (ContainsWord("ABOUT", num))
            {
                possibleAnswer.Add("ABOUT");
            }

            if (ContainsWord("AFTER", num))
            {
                possibleAnswer.Add("AFTER");
            }

            if (ContainsWord("AGAIN", num))
            {
                possibleAnswer.Add("AGAIN");
            }

            if (ContainsWord("BELOW", num))
            {
                possibleAnswer.Add("BELOW");
            }

            if (ContainsWord("COULD", num))
            {
                possibleAnswer.Add("COULD");
            }
            if (ContainsWord("EVERY", num))
            {
                possibleAnswer.Add("EVERY");
            }

            if (ContainsWord("FIRST", num))
            {
                possibleAnswer.Add("FIRST");
            }

            if (ContainsWord("FOUND", num))
            {
                possibleAnswer.Add("FOUND");
            }

            if (ContainsWord("GREAT", num))
            {
                possibleAnswer.Add("GREAT");
            }

            if (ContainsWord("HOUSE", num))
            {
                possibleAnswer.Add("HOUSE");
            }

            if (ContainsWord("LARGE", num))
            {
                possibleAnswer.Add("LARGE");
            }

            if (ContainsWord("LEARN", num))
            {
                possibleAnswer.Add("LEARN");
            }

            if (ContainsWord("NEVER", num))
            {
                possibleAnswer.Add("NEVER");
            }

            if (ContainsWord("OTHER", num))
            {
                possibleAnswer.Add("OTHER");
            }

            if (ContainsWord("PLACE", num))
            {
                possibleAnswer.Add("PLACE");
            }

            if (ContainsWord("PLANT", num))
            {
                possibleAnswer.Add("PLANT");
            }

            if (ContainsWord("POINT", num))
            {
                possibleAnswer.Add("POINT");
            }

            if (ContainsWord("RIGHT", num))
            {
                possibleAnswer.Add("RIGHT");
            }

            if (ContainsWord("SMALL", num))
            {
                possibleAnswer.Add("SMALL");
            }

            if (ContainsWord("SOUND", num))
            {
                possibleAnswer.Add("SOUND");
            }

            if (ContainsWord("SPELL", num))
            {
                possibleAnswer.Add("SPELL");
            }

            if (ContainsWord("STILL", num))
            {
                possibleAnswer.Add("STILL");
            }

            if (ContainsWord("STUDY", num))
            {
                possibleAnswer.Add("STUDY");
            }

            if (ContainsWord("THEIR", num))
            {
                possibleAnswer.Add("THEIR");
            }

            if (ContainsWord("THERE", num))
            {
                possibleAnswer.Add("THERE");
            }

            if (ContainsWord("THESE", num))
            {
                possibleAnswer.Add("THESE");
            }

            if (ContainsWord("THING", num))
            {
                possibleAnswer.Add("THING");
            }

            if (ContainsWord("THINK", num))
            {
                possibleAnswer.Add("THINK");
            }

            if (ContainsWord("THREE", num))
            {
                possibleAnswer.Add("THREE");
            }
            if (ContainsWord("WATER", num))
            {
                possibleAnswer.Add("WATER");
            }

            if (ContainsWord("WHERE", num))
            {
                possibleAnswer.Add("WHERE");
            }

            if (ContainsWord("WHICH", num))
            {
                possibleAnswer.Add("WHICH");
            }

            if (ContainsWord("WORLD", num))
            {
                possibleAnswer.Add("WORLD");
            }

            if (ContainsWord("WOULD", num))
            {
                possibleAnswer.Add("WOULD");
            }

            if (ContainsWord("WRITE", num))
            {
                possibleAnswer.Add("WRITE");
            }

            PrintDebugLine($"First Row [{string.Join(", ", firstRow)}]\n");
            PrintDebugLine($"Second Row [{string.Join(", ", secondRow)}]\n");
            PrintDebugLine($"Third Row [{string.Join(", ", thirdRow)}]\n");

            if (fourthRow.Count != 0)
            {
                PrintDebugLine($"Fourth Row [{string.Join(", ", fourthRow)}]\n");
            }

            if (fifthRow.Count != 0)
            {
                PrintDebugLine($"Fifth Row [{string.Join(", ", fifthRow)}]\n");
            }

            PrintDebugLine($"Possible words: {string.Join(", ", possibleAnswer)}\n");

            if (possibleAnswer.Count <= 3 && possibleAnswer.Count != 0)
            {
                ShowAnswer(string.Join(", ", possibleAnswer), true);
            }

            return possibleAnswer;
        }

        /// <summary>
        /// Tells if the rows can possibly spell a word
        /// </summary>
        /// <param name="word"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        private bool ContainsWord(String word, int numRows)
        {
            //this may be a terrible way to inplement, but it looks cleaner

            //depending on the number of rows filled, check to see if you can spell word
            switch (numRows)
            {
                case 3:
                    return firstRow.Contains(word[0])
                        && secondRow.Contains(word[1])
                        && thirdRow.Contains(word[2]);

                case 4:
                    return ContainsWord(word, 3) && fourthRow.Contains(word[3]);

                default:
                    return ContainsWord(word, 4) && fifthRow.Contains(word[4]);
            }
        }
    }
}
