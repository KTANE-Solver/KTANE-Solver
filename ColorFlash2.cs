using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            switch (colors[7])
            {
                case "Red":
                    if (words.Where(x => x == "G").Count() >= 3)
                    {
                        answer = WordColorIndexes("G")[2] + 1;
                        button = "Yes";
                    }

                    else if (words.Where(x => x == "B").Count() == 1)
                    {
                        answer = words.IndexOf("M");
                        button = "No";

                    }

                    else
                    { 
                        answer = WordColorIndexes("W").Last() + 1;
                        button = "Yes";
                    }
                    break;

                case "Yellow":

                    if (FindColorAndWord("G", "B") != -1)
                    {
                        answer = colors.IndexOf("G");
                        button = "Yes";
                    }

                    else if (FindColorAndWord("R", "W") != -1 || FindColorAndWord("W", "W") != -1)
                    {
                        answer = MisMatchIndex()[1];
                        button = "Yes";
                    }

                    else
                    {
                        answer = WordColorIndexes("M").Count();
                        button = "No";
                    }

                    break;


                case "Green":

                    for (int i = 0; i < 7; i++)
                    {
                        int index = ConsecutivePair(words, i);
                        if (index != -1 && colors[index] != colors[index + 1])
                        {
                            answer = 5;
                            button = "No";
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
                        }
                    }
                    break;

                case "Blue":
                    int[] misMatches = MisMatchIndex();
                    if (misMatches.Length >= 3)
                    {
                        button = "Yes";
                        answer = misMatches[0] + 1;
                    }

                    else if (FindColorAndWord("Y", "R") != -1 || FindColorAndWord("W", "Y") != -1)
                    {
                        button = "No";
                        answer = FindColorAndWord("R", "W") + 1;
                    }

                    else
                    {
                        button = "Yes";
                        answer = WordColorIndexes("G").Last() + 1;
                    }
                    break;

                case "Magenta":
                    for (int i = 0; i < 7; i++)
                    {
                        int index = ConsecutivePair(colors, i);
                        if (index != -1 && words[index] != words[index + 1])
                        {
                            answer = 3;
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
                        }

                        else
                        { 
                            string desiredColor = words[7];

                            button = "No";
                            answer = colors.IndexOf(desiredColor);
                        }
                    }

                    break;

                default:
                    if (colors[2] == colors[3] || colors[2] == colors[4])
                    {
                        button = "No";
                        answer = WordColorIndexes("B").First();
                    }

                    else if (FindColorAndWord("R", "Y") == -1)
                    {
                        for (int i = 7; i > 0; i--)
                        {
                            if (colors[i] == "B")
                            {
                                button = "No";
                                answer = i;
                                break;
                            }
                        }
                    }

                    else
                    {
                        button = "Yes";
                        answer = -1;
                    }

                    break;

            }

            answer++;

            if (!debug)
            { 
                
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
                return "1st";
            }

            if (answer == 2)
            {
                return "2nd";
            }

            if (answer == 3)
            {
                return "3rd";
            }

            else
            {
                return answer + "th";
            }
        }
    }
}
