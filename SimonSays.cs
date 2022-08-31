using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the Simon Says module
    /// </summary>
    public class SimonSays : Module
    {
        //a "list" of all the lights that lit up
        public String lights;

        public SimonSays(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Simon Says")
        {
            this.lights = "";
        }

        public string DebugSolve(char newLight)
        {
            lights += newLight;

            PrintDebugLine($"Vowel: {Bomb.HasVowel}\n");

            PrintDebugLine($"Strikes: {Bomb.Strike}\n");

            PrintDebugLine($"New Light: {newLight}\n");

            PrintDebugLine($"Full input: {lights}\n");

            List<String> answerList = new List<string>();

            switch (Bomb.Strike)
            {
                case 0:

                    if (Bomb.HasVowel)
                    {
                        foreach (char character in lights)
                        {
                            if (character == 'B')
                                answerList.Add("Red");
                            else if (character == 'G')
                                answerList.Add("Yellow");
                            else if (character == 'R')
                                answerList.Add("Blue");
                            else
                                answerList.Add("Green");
                        }
                    }
                    else
                    {
                        foreach (char character in lights)
                        {
                            if (character == 'B')
                                answerList.Add("Yellow");
                            else if (character == 'G')
                                answerList.Add("Green");
                            else if (character == 'R')
                                answerList.Add("Blue");
                            else
                                answerList.Add("Red");
                        }
                    }
                    break;

                case 1:
                    if (Bomb.HasVowel)
                    {
                        foreach (char character in lights)
                        {
                            if (character == 'B')
                                answerList.Add("Green");
                            else if (character == 'G')
                                answerList.Add("Blue");
                            else if (character == 'R')
                                answerList.Add("Yellow");
                            else
                                answerList.Add("Red");
                        }
                    }
                    else
                    {
                        foreach (char character in lights)
                        {
                            if (character == 'B')
                                answerList.Add("Blue");
                            else if (character == 'G')
                                answerList.Add("Yellow");
                            else if (character == 'R')
                                answerList.Add("Red");
                            else
                                answerList.Add("Green");
                        }
                    }
                    break;

                default:

                    if (Bomb.HasVowel)
                    {
                        foreach (char character in lights)
                        {
                            if (character == 'B')
                                answerList.Add("Red");
                            else if (character == 'G')
                                answerList.Add("Yellow");
                            else if (character == 'R')
                                answerList.Add("Green");
                            else
                                answerList.Add("Blue");
                        }
                    }
                    else
                    {
                        foreach (char character in lights)
                        {
                            if (character == 'B')
                                answerList.Add("Green");
                            else if (character == 'G')
                                answerList.Add("Blue");
                            else if (character == 'R')
                                answerList.Add("Yellow");
                            else
                                answerList.Add("Red");
                        }
                    }
                    break;
            }

            string answer = string.Join(", ", answerList);

            PrintDebugLine($"Answer: {answer}\n");

            return answer;
        }

        public void Solve(int stage, char newLight)
        {
            PrintDebugLine($"Stage: {stage}\n");

            ShowAnswer(DebugSolve(newLight), true);
        }
    }
}
