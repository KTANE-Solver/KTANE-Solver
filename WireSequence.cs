using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the wire sequence module
    /// </summary>
    public class WireSequence : Module
    {
        private int RedColor { get; set; }
        private int BlueColor { get; set; }
        private int BlackColor { get; set; }

        public WireSequence(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Wire Sequence")
        {
            RedColor = 0;
            BlueColor = 0;
            BlackColor = 0;
        }

        public String Solve(int wireNum, String color, char letter)
        {
            string answer;
            int colorNum;

            PrintDebugLine($"{color} Wire: {wireNum} to {letter}\n");

            switch (color)
            {
                case "Red":

                    RedColor++;

                    colorNum = RedColor;

                    if (letter == 'A')
                    {
                        if (
                            RedColor == 3
                            || RedColor == 4
                            || RedColor == 6
                            || RedColor == 7
                            || RedColor == 8
                        )
                        {
                            answer = "Cut";
                        }
                        else
                        {
                            answer = "Don't Cut";
                        }
                    }
                    else if (letter == 'B')
                    {
                        if (
                            RedColor == 2
                            || RedColor == 5
                            || RedColor == 7
                            || RedColor == 8
                            || RedColor == 9
                        )
                        {
                            answer = "Cut";
                        }
                        else
                        {
                            answer = "Don't Cut";
                        }
                    }
                    else
                    {
                        if (RedColor == 1 || RedColor == 4 || RedColor == 6 || RedColor == 7)
                        {
                            answer = "Cut";
                        }
                        else
                        {
                            answer = "Don't Cut";
                        }
                    }

                    break;

                case "Blue":

                    BlueColor++;

                    colorNum = BlueColor;

                    if (letter == 'A')
                    {
                        if (BlueColor == 2 || BlueColor == 4 || BlueColor == 8 || BlueColor == 9)
                        {
                            answer = "Cut";
                        }
                        else
                        {
                            answer = "Don't Cut";
                        }
                    }
                    else if (letter == 'B')
                    {
                        if (BlueColor == 1 || BlueColor == 3 || BlueColor == 5 || BlueColor == 6)
                        {
                            answer = "Cut";
                        }
                        else
                        {
                            answer = "Don't Cut";
                        }
                    }
                    else
                    {
                        if (BlueColor == 2 || BlueColor == 7 || BlueColor == 8 || BlueColor == 6)
                        {
                            answer = "Cut";
                        }
                        else
                        {
                            answer = "Don't Cut";
                            ;
                        }
                    }

                    break;

                default:

                    BlackColor++;

                    colorNum = BlackColor;

                    if (letter == 'A')
                    {
                        if (
                            BlackColor == 1 || BlackColor == 2 || BlackColor == 4 || BlackColor == 7
                        )
                        {
                            answer = "Cut";
                        }
                        else
                        {
                            answer = "Don't Cut";
                        }
                    }
                    else if (letter == 'B')
                    {
                        if (
                            BlackColor == 1
                            || BlackColor == 3
                            || BlackColor == 5
                            || BlackColor == 6
                            || BlackColor == 7
                        )
                        {
                            answer = "Cut";
                        }
                        else
                        {
                            answer = "Don't Cut";
                        }
                    }
                    else
                    {
                        if (
                            BlackColor == 1
                            || BlackColor == 2
                            || BlackColor == 4
                            || BlackColor == 6
                            || BlackColor == 8
                            || BlackColor == 9
                        )
                        {
                            answer = "Cut";
                        }
                        else
                        {
                            answer = "Don't Cut";
                        }
                    }

                    break;
            }

            PrintDebugLine($"{GetPlace(colorNum)} instance of a {color} wire\n");

            if (answer == "Cut")
            {
                PrintDebugLine($"Cut wire {wireNum}\n");
            }
            else
            {
                PrintDebugLine($"Don't cut wire {wireNum}\n");
            }

            return answer;
        }

        private string GetPlace(int num)
        {
            if (num == 1)
                return "1st";

            if (num == 2)
                return "2nd";

            if (num == 3)
                return "3rd";

            return $"{num}th";
        }
    }
}
