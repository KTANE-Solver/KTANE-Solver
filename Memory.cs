using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the memory module
    /// </summary>
    public class Memory : Module
    {
        private int[] stage1;
        private int stage1Position;

        private int[] stage2;
        private int stage2Position;

        private int[] stage3;
        private int stage3Position;

        private int[] stage4;
        private int stage4Position;

        private int[] stage5;
        private int stage5Position;

        public Memory(Bomb bomb, StreamWriter logFileWriter) : base(bomb, logFileWriter, "Memory")
        { }

        public void Solve(int stage, int display, int num1, int num2, int num3, int num4)
        {
            PrintDebugLine($"Stage: {stage}\n");

            PrintDebugLine($"Display: {display}\n");

            PrintDebugLine($"Numbers: {num1}{num2}{num3}{num4}\n");

            if (stage == 1)
            {
                stage1 = new int[] { num1, num2, num3, num4 };

                switch (display)
                {
                    case 1:
                    case 2:
                        //If the display is 1, press the button in the second position.
                        //If the display is 2, press the button in the second position.
                        stage1Position = 1;
                        break;

                    case 3:
                        //If the display is 3, press the button in the third position.'
                        stage1Position = 2;
                        break;

                    default:
                        //If the display is 4, press the button in the fourth position.
                        stage1Position = 3;
                        break;
                }

                PrintStageAnswerInfo(stage1, 1, stage1Position);
                ShowAnswer($"Press {stage1[stage1Position]}", true);
            }
            else if (stage == 2)
            {
                stage2 = new int[] { num1, num2, num3, num4 };

                switch (display)
                {
                    case 1:
                        //If the display is 1, press the button labeled "4".
                        stage2Position = Array.IndexOf(stage2, 4);
                        break;

                    case 3:
                        //If the display is 3, press the button in the first position.
                        stage2Position = 0;
                        break;

                    default:
                        //If the display is 2, press the button in the same position as you pressed in stage 1.
                        //If the display is 4, press the button in the same position as you pressed in stage 1.
                        stage2Position = stage1Position;
                        break;
                }

                PrintStageAnswerInfo(stage2, 2, stage2Position);
                ShowAnswer($"Press {stage2[stage2Position]}", true);
            }
            else if (stage == 3)
            {
                stage3 = new int[] { num1, num2, num3, num4 };

                switch (display)
                {
                    case 1:
                        //If the display is 1, press the button with the same label you pressed in stage 2.
                        stage3Position = Array.IndexOf(stage3, stage2[stage2Position]);
                        break;

                    case 2:
                        //If the display is 2, press the button with the same label you pressed in stage 1.
                        stage3Position = Array.IndexOf(stage3, stage1[stage1Position]);
                        break;

                    case 3:
                        //If the display is 3, press the button in the third position.
                        stage3Position = 2;
                        break;

                    default:
                        //If the display is 4, press the button labeled "4".
                        stage3Position = Array.IndexOf(stage3, 4);
                        break;
                }

                PrintStageAnswerInfo(stage3, 3, stage3Position);
                ShowAnswer($"Press {stage3[stage3Position]}", true);
            }
            else if (stage == 4)
            {
                stage4 = new int[] { num1, num2, num3, num4 };

                switch (display)
                {
                    case 1:
                        //If the display is 1, press the button in the same position as you pressed in stage 1.
                        stage4Position = stage1Position;
                        break;

                    case 2:
                        //If the display is 2, press the button in the first position.
                        stage4Position = 0;
                        break;

                    default:
                        //If the display is 3, press the button in the same position as you pressed in stage 2.
                        //If the display is 4, press the button in the same position as you pressed in stage 2.
                        stage4Position = stage2Position;
                        break;
                }

                PrintStageAnswerInfo(stage4, 4, stage4Position);
                ShowAnswer($"Press {stage4[stage4Position]}", true);
            }
            else
            {
                stage5 = new int[] { num1, num2, num3, num4 };

                switch (display)
                {
                    case 1:
                        //If the display is 1, press the button with the same label you pressed in stage 1.
                        stage5Position = Array.IndexOf(stage5, stage1[stage1Position]);
                        break;

                    case 2:
                        //If the display is 2, press the button with the same label you pressed in stage 2.
                        stage5Position = Array.IndexOf(stage5, stage2[stage2Position]);
                        break;

                    case 3:
                        //If the display is 3, press the button with the same label you pressed in stage 4.
                        stage5Position = Array.IndexOf(stage5, stage4[stage4Position]);
                        break;

                    default:
                        //If the display is 4, press the button with the same label you pressed in stage 3.
                        stage5Position = Array.IndexOf(stage5, stage3[stage3Position]);
                        break;
                }

                PrintStageAnswerInfo(stage5, 5, stage5Position);
                ShowAnswer($"Press {stage5[stage5Position]}", true);
            }
        }

        private void PrintStageAnswerInfo(int[] arr, int stage, int position)
        {
            PrintDebugLine(
                $"Stage {stage} position: {position + 1}\nStage {stage} num: {arr[position]}\n"
            );
        }
    }
}
