using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class Screw : Module
    {
        List<Color> screwLocationAnswers;
        List<Color> colorLocations;

        public Screw(Bomb bomb, StreamWriter logFileWriter, List<Color> colorLocations)
            : base(bomb, logFileWriter, "Screw")
        {
            this.colorLocations = colorLocations;
            screwLocationAnswers = new List<Color>();

            PrintDebugLine("Color in order: ");

            foreach (Color color in colorLocations)
            {
                PrintDebugLine("" + color);
            }

            PrintDebugLine("");
        }

        public string Solve(int stage, bool debug)
        {
            string answer = $"{screwLocationAnswers[stage - 1]} and {FindLetterAnswers(stage - 1)}"
                .Replace("Color", "")
                .Replace("[", "")
                .Replace("]", "")
                .Trim();

            if (!debug)
            {
                ShowAnswer(answer, true);
            }

            return answer;
        }

        public void FindScrewLocations()
        {
            Color stage1 = ConvertNumToScrewLocation(
                Bomb.Battery + Bomb.UnlitIndicatorsList.Count,
                1
            );
            Color stage2 = ConvertNumToScrewLocation(
                Bomb.LastDigit + Bomb.LitIndicatorsList.Count,
                2
            );
            Color stage3 = ConvertNumToScrewLocation(Bomb.PortNum + Bomb.BatteryHolder, 3);

            if (stage1 == colorLocations[0])
            {
                stage1 = colorLocations[1];

                PrintDebugLine($"Changing Stage 1 color answer to {stage1}\n");
            }

            Color oldStage2 = stage2;

            stage2 = OverrideScrewLocation(oldStage2, stage1);

            if (stage2 != oldStage2)
            {
                PrintDebugLine($"Changing Stage 2 color answer to {stage2}\n");
            }

            Color oldStage3 = stage3;

            stage3 = OverrideScrewLocation(stage3, stage2);

            if (stage3 != oldStage3)
            {
                PrintDebugLine($"Changing Stage 3 color answer to {stage3}\n");
            }

            screwLocationAnswers.AddRange(new Color[] { stage1, stage2, stage3 });
        }

        public string FindLetterAnswers(int stage)
        {
            Color color = screwLocationAnswers[stage];

            int colorIndex = colorLocations.IndexOf(color);

            if (color == Color.Red || color == Color.Yellow || color == Color.Green)
            {
                if (colorIndex < 3)
                {
                    PrintDebugLine($"Stage {stage + 1} screw is in the top row\n");

                    if (colorIndex % 3 + 1 == Bomb.BatteryHolder)
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole position in the top row is equal to the number of battery holders\n"
                        );

                        return "4th position";
                    }
                    else if (
                        MessageBox.Show(
                            "Is the letter A in the 1st or 3rd position?",
                            "",
                            MessageBoxButtons.YesNo
                        ) == DialogResult.Yes
                    )
                    {
                        PrintDebugLine($"The letter A in the 1st or 3rd position\n");

                        return "C";
                    }
                    else if (Bomb.Clr.Visible || Bomb.Frk.Visible || Bomb.Trn.Visible)
                    {
                        PrintDebugLine(
                            $"The bomb has at least one of the following indicators: CLR, FRK, or TRN\n"
                        );

                        return "3rd position";
                    }
                    else if (colorLocations.IndexOf(Color.Blue) / 3 == colorIndex / 3)
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole is in the same row as the blue hole\n"
                        );
                        return "1st position";
                    }
                    else
                    {
                        PrintDebugLine($"None of the rules above applied\n");
                        return "B";
                    }
                }
                else
                {
                    PrintDebugLine($"Stage {stage + 1} screw is in the bottom row\n");

                    if (colorIndex % 3 + 1 == Bomb.UniquePortNum)
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole position in the bottom row is equal to the number of port paltes\n"
                        );
                        return "2nd position";
                    }
                    else if (colorIndex % 3 + 1 == Bomb.Battery)
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole position in the bottom row is equal to the total number of batteries\n"
                        );
                        return "D";
                    }
                    else if (colorIndex % 3 != colorLocations.IndexOf(Color.White) % 3)
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole is not vertically opposite to the white hole\n"
                        );
                        return "A";
                    }
                    else if (
                        (colorLocations[colorIndex - 1] == Color.Magenta && colorIndex - 1 > 2)
                        || (colorIndex + 1 < 5 && colorLocations[colorIndex + 1] == Color.Magenta)
                    )
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole is horizontally adjacent to the magenta hole\n"
                        );
                        return "C";
                    }
                    else
                    {
                        PrintDebugLine($"None of the rules above applied\n");
                        return "1st position";
                    }
                }
            }
            else
            {
                if (colorIndex < 3)
                {
                    PrintDebugLine($"Stage {stage + 1} screw is in the top row\n");

                    if (colorIndex % 3 + 1 == Bomb.UniquePortNum)
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole position in the top row is equal to the number of port types\n"
                        );
                        return "D";
                    }
                    else if (
                        MessageBox.Show(
                            "Is the letter C in the 2nd or 4th position?",
                            "",
                            MessageBoxButtons.YesNo
                        ) == DialogResult.Yes
                    )
                    {
                        PrintDebugLine($"The letter C is in the second or fourth position\n");
                        return "B";
                    }
                    else if (Bomb.Car.Visible || Bomb.Frq.Visible || Bomb.Snd.Visible)
                    {
                        PrintDebugLine(
                            $"The bomb has at least one of the following indicators: CAR, FRQ, or SND\n"
                        );
                        return "4th position";
                    }
                    else if (colorIndex / 3 == colorLocations.IndexOf(Color.Red) / 3)
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole shares the same row as the red hole\n"
                        );
                        return "2nd position";
                    }
                    else
                    {
                        PrintDebugLine($"None of the rules above applied\n");
                        return "A";
                    }
                }
                else
                {
                    PrintDebugLine($"Stage {stage + 1} screw is in the bottom row\n");

                    if (colorIndex % 3 + 1 == Bomb.PortPlateNum)
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole position in the bottom row is equal to the number of port Plates\n"
                        );
                        return "2nd position";
                    }
                    else if (colorIndex % 3 + 1 == Bomb.IndicatorNum)
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole position in the bottom row is equal to the number of indicators\n"
                        );
                        return "A";
                    }
                    else if (
                        (colorIndex - 1 > 2 && colorLocations[colorIndex - 1] == Color.Yellow)
                        || (colorIndex + 1 < 6 && colorLocations[colorIndex + 1] == Color.Yellow)
                    )
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole is horizontally adjacent to the yellow hole\n"
                        );
                        return "C";
                    }
                    else if (colorIndex % 3 != colorLocations.IndexOf(Color.Green) % 3)
                    {
                        PrintDebugLine(
                            $"Stage {stage + 1}'s hole is not vertucally opposite to the green hole\n"
                        );
                        return "D";
                    }
                    else
                    {
                        PrintDebugLine($"None of the rules above applied\n");
                        return "4th position";
                    }
                }
            }
        }

        public Color OverrideScrewLocation(Color currentStageAnswer, Color previousStageAnswer)
        {
            if (currentStageAnswer == previousStageAnswer)
            {
                int index = colorLocations.IndexOf(currentStageAnswer) + 1;

                index %= 6;

                if (index == 0)
                {
                    index = 1;
                }

                return colorLocations[index];
            }

            return currentStageAnswer;
        }

        public Color ConvertNumToScrewLocation(int num, int stage)
        {
            while (num > 6)
            {
                num -= 6;
            }

            if (num == 0)
            {
                num++;
            }

            PrintDebugLine($"Stage {stage} screw num: {num} ({colorLocations[num - 1]})\n");

            return colorLocations[num - 1];
        }
    }
}
