using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the morse code module
    /// </summary>
    public class MorseCode : Module
    {
        public MorseCode(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Morse Code") { }

        public void Solve(String word)
        {
            decimal answer;
            switch (word.ToLower())
            {
                case "shell":
                    answer = 3.505m;
                    break;

                case "halls":
                    answer = 3.515m;
                    break;

                case "slick":
                    answer = 3.522m;
                    break;

                case "vector":
                    answer = 3.595m;
                    break;

                case "strobe":
                    answer = 3.545m;
                    break;

                case "flick":
                    answer = 3.555m;
                    break;

                case "leaks":
                    answer = 3.542m;
                    break;

                case "bistro":
                    answer = 3.552m;
                    break;

                case "beats":
                    answer = 3.600m;
                    break;

                case "brick":
                    answer = 3.575m;
                    break;

                case "break":
                    answer = 3.572m;
                    break;

                case "bombs":
                    answer = 3.565m;
                    break;

                case "trick":
                    answer = 3.532m;
                    break;

                case "steak":
                    answer = 3.582m;
                    break;

                default:
                    answer = 3.535m;
                    break;
            }

            PrintDebugLine($"Word: {word}\nAnswer: {answer:0.000}\n");

            ShowAnswer($"{answer:0.000}", true);
        }
    }
}
