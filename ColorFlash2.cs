using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace New_KTANE_Solver
{
    public class ColorFlash2 : Module
    {
        List<string> colors;
        List<string> words;

        public ColorFlash2(List<string> colors, List<string> words, StreamWriter logFileWriter) : base(null, logFileWriter, "Color Flash")
        {
            this.colors = colors;
            this.words = words;
        }

        public KeyValuePair<string, int> Solve(bool debug)
        {
            int answer = -1;
            string button = "Yes";
            string reason = "";

            PrintDebugLine("Last Color: " + colors[7]);

            switch (colors[7])
            {
                case "R":
                    if (words.Where(x => x == "G").Count() >= 3)
                    {
                        answer = WordColorIndexes("G")[2] + 1;
                        button = "Yes";
                        reason = "Green is used as the word at least three times in the sequence";
                    }

                    else if (words.Where(x => x == "B").Count() == 1)
                    {
                        answer = words.IndexOf("M");
                        button = "No";
                        reason = "Blue is used as the colour of the word exactly once";
                    }

                    else
                    { 
                        answer = WordColorIndexes("W").Last() + 1;
                        button = "Yes";
                        reason = "No other condition applied";
                    }
                    break;

                case "Y":

                    if (FindColorAndWord("G", "B") != -1)
                    {
                        answer = colors.IndexOf("G");
                        button = "Yes";
                        reason = "the word Blue is shown in Green colour";
                    }

                    else if (FindColorAndWord("R", "W") != -1 || FindColorAndWord("W", "W") != -1)
                    {
                        answer = MisMatchIndex()[1];
                        button = "Yes";
                        reason = " the word White is shown in either White or Red colour";
                    }

                    else
                    {
                        answer = WordColorIndexes("M").Count();
                        button = "No";
                        reason = "No other condition applied";
                    }

                    break;


                case "G":

                    for (int i = 0; i < 7; i++)
                    {
                        int index = ConsecutivePair(words, i);
                        if (index != -1 && colors[index] != colors[index + 1])
                        {
                            answer = 5;
                            button = "No";
                            reason = "a word occurs consecutively with different colours";
                            break;
                        }
                    }

                    if (answer == -1)
                    {
                        if (words.Where(x => x == "M").Count() >= 3)
                        {
                            int colorYellow = colors.IndexOf("Y") + 1;
                            int wordYellow = colors.IndexOf("Y") + 1;

                            if (colorYellow != -1 && colorYellow < wordYellow)
                            {
                                button = "No";
                                answer = colorYellow;
                            }

                            else
                            {
                                button = "No";
                                answer = wordYellow;
                            }

                            reason = "Magenta is used as the word at least three times in the sequence";
                        }

                        else
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                if (colors[i] == words[i])
                                {
                                    button = "Yes";
                                    answer = i + 1;
                                    break;
                                }
                            }

                            reason = "No other condition applied";
                        }
                    }
                    break;

                case "B":
                    int[] misMatches = MisMatchIndex();
                    if (misMatches.Length >= 3)
                    {
                        button = "Yes";
                        answer = misMatches[0] + 1;
                        reason = "the colour of the word does not match the word itself three times or more in the sequence";
                    }

                    else if (FindColorAndWord("Y", "R") != -1 || FindColorAndWord("W", "Y") != -1)
                    {
                        button = "No";
                        answer = FindColorAndWord("R", "W") + 1;
                        reason = "the word Red is shown in Yellow colour, or the word Yellow is shown in White colour";
                    }

                    else
                    {
                        button = "Yes";
                        answer = WordColorIndexes("G").Last() + 1;
                        reason = "No other condition applied";
                    }
                    break;

                case "M":
                    for (int i = 0; i < 7; i++)
                    {
                        int index = ConsecutivePair(colors, i);
                        if (index != -1 && words[index] != words[index + 1])
                        {
                            answer = 3;
                            reason = "a colour occurs consecutively with different words";
                            break;
                        }
                    }

                    if (answer == -1)
                    {
                        List<int> yellowWords = new List<int>();

                        for (int i = 0; i < 8; i++)
                        {
                            if (words[i] == "Y")
                            {
                                button = "Yes";
                                yellowWords.Add(i);
                            }
                        }
                        if (yellowWords.Count > words.Where(x => x == "B").Count())
                        {
                            button = "No";
                            answer = yellowWords.Last();
                            reason = "the number of times the word Yellow appears is greater than the number of times that the colour of the word is Blue";
                        }

                        else
                        { 
                            string desiredColor = words[7];

                            button = "No";
                            answer = colors.IndexOf(desiredColor);
                            reason = "No other condition applied";
                        }
                    }

                    break;

                default:
                    if (colors[2] == colors[3] || colors[2] == colors[4])
                    {
                        button = "No";
                        answer = WordColorIndexes("B").First();
                        reason = "the colour of the third word matches the word of the fourth word or fifth word";
                    }

                    else if (FindColorAndWord("R", "Y") == -1)
                    {
                        for (int i = 7; i > 0; i--)
                        {
                            if (colors[i] == "B")
                            {
                                button = "No";
                                answer = i;
                                reason = "the word Yellow is shown in Red colour";
                                break;
                            }
                        }
                    }

                    else
                    {
                        button = "No";
                        answer = -1;
                        reason = "No other condition applied";
                    }

                    break;

            }

            PrintDebugLine("Reason: " + reason);

            if (!debug)
            {
                ShowAnswer($"Press {button} on {FindAnswerIndex(answer)} instance", true);
            }

            return new KeyValuePair<string, int>(button, answer);
        }

        private int ConsecutivePair(List<string> list, int startingIndex)
        {
            return list[startingIndex] == list[startingIndex + 1] ? startingIndex : -1;
        }

        private int[] MisMatchIndex()
        {
            List<int> num = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                if (colors[i] != words[i])
                {
                    num.Add(i);
                }
            }

            return num.ToArray();
        }

        private int FindColorAndWord(string color, string word)
        {
            for (int i = 0; i < 8; i++)
            {
                if (colors[i] == color && words[i] == word)
                {
                    return i;
                }
            }

            return -1;
        }

        private int[] WordColorIndexes(string s)
        {
            List<int> index = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                if (words[i] == s || colors[i] == s)
                {
                    index.Add(i);
                }
            }

            return index.ToArray();
        }

        private string FindAnswerIndex(int answer)
        {
            if (answer == -1)
            {
                return "any";
            }

            if (answer == 1)
            {
                return "the 1st";
            }

            if (answer == 2)
            {
                return "the 2nd";
            }

            if (answer == 3)
            {
                return "the 3rd";
            }

            else
            {
                return "the " + answer + "th";
            }
        }
    }
}
