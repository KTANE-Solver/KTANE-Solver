using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the switches module
    /// </summary>
    class Switches : Module
    {
        private bool[] start;
        private bool[] end;
        private List<int> directions;

        public Switches(bool[] start, bool[] end, Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Switches")
        {
            this.start = start;
            this.end = end;

            directions = new List<int>();
        }

        public void Solve()
        {
            //if the initial start is not special, all the switches down from left to right
            if (!Special(start))
            {
                PrintDebugLine("Start is not special\n");
                //checking which switches need to be put down while checking if the module has be solved
                if (start[0])
                {
                    turnSwitchOff(0);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }

                if (start[1])
                {
                    turnSwitchOff(1);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }

                if (start[2])
                {
                    turnSwitchOff(2);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }

                if (start[3])
                {
                    turnSwitchOff(3);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }

                if (start[4])
                {
                    turnSwitchOff(4);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }
            }
            else
            {
                PrintDebugLine("Start is special\n");
                //checking which special start the initial start is and doing the proper commands
                //to make them all down

                //12345
                if (start[0] && start[1] && start[2] && start[3] && start[4])
                {
                    //34125
                    turnSwitchOff(2);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }

                    turnSwitchOff(3);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }

                    turnSwitchOff(0);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }

                    turnSwitchOff(1);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }

                    turnSwitchOff(4);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }
                //13 - 31
                else if (start[0] && start[2])
                {
                    turnSwitchOff(2);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }

                    turnSwitchOff(0);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }
                //23 - 32
                else if (start[1] && start[2])
                {
                    turnSwitchOff(2);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }

                    turnSwitchOff(1);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }
                //1245 - 4125
                else
                {
                    turnSwitchOff(3);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }

                    turnSwitchOff(0);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }

                    turnSwitchOff(1);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }

                    turnSwitchOff(4);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }
            }

            //if the ending position is not special, put the desired switches up from right to left
            if (!Special(end))
            {
                PrintDebugLine("End is not special\n");
                if (end[4])
                {
                    turnSwitchOn(4);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }

                if (end[3])
                {
                    turnSwitchOn(3);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }

                if (end[2])
                {
                    turnSwitchOn(2);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }

                if (end[1])
                {
                    turnSwitchOn(1);

                    if (IsComplete())
                    {
                        ShowAnswer(Answer(), true);
                        return;
                    }
                }

                if (end[0])
                {
                    turnSwitchOn(0);

                    ShowAnswer(Answer(), true);
                    return;
                }
            }
            else
            {
                PrintDebugLine("End is special\n");

                //13
                if (end[0] && !end[1] && end[2] && !end[3] && !end[4])
                {
                    turnSwitchOn(0);
                    turnSwitchOn(2);

                    ShowAnswer(Answer(), true);
                    return;
                }

                //23
                if (!end[0] && end[1] && end[2] && !end[3] && !end[4])
                {
                    turnSwitchOn(1);
                    turnSwitchOn(2);

                    ShowAnswer(Answer(), true);
                    return;
                }

                //5214
                if (end[0] && end[1] && !end[2] && end[3] && end[4])
                {
                    turnSwitchOn(4);
                    turnSwitchOn(1);
                    turnSwitchOn(0);
                    turnSwitchOn(3);

                    ShowAnswer(Answer(), true);
                    return;
                }

                //352143
                if (end[0] && end[1] && end[2] && end[3] && end[4])
                {
                    turnSwitchOn(4);
                    turnSwitchOn(1);
                    turnSwitchOn(0);
                    turnSwitchOn(3);
                    turnSwitchOn(2);

                    ShowAnswer(Answer(), true);
                    return;
                }
            }
        }

        //turns a certain switch off
        private void turnSwitchOff(int num)
        {
            PrintDebugLine($"Turned off switch {num + 1}\n");

            if (directions.Count != 0 && directions[directions.Count - 1] == num + 1)
            {
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            directions.Add(num + 1);
            start[num] = false;
        }

        private void turnSwitchOn(int num)
        {
            PrintDebugLine($"Turned on switch {num + 1}\n");

            if (directions.Count != 0 && directions[directions.Count - 1] == num + 1)
            {
                directions.RemoveAt(directions.Count - 1);
            }
            else
            {
                directions.Add(num + 1);
            }

            start[num] = true;
        }

        private bool IsComplete()
        {
            for (int i = 0; i < 5; i++)
            {
                if (start[i] != end[i])
                {
                    return false;
                }
            }

            return true;
        }

        private bool Special(bool[] arr)
        {
            //12345
            if (arr[0] && arr[1] && arr[2] && arr[3] && arr[4])
            {
                return true;
            }

            //1245
            if (arr[0] && arr[1] && !arr[2] && arr[3] && arr[4])
            {
                return true;
            }

            //13
            if (arr[0] && !arr[1] && arr[2] && !arr[3] && !arr[4])
            {
                return true;
            }

            //23
            return !arr[0] && arr[1] && arr[2] && !arr[3] && !arr[4];
        }

        private String Answer()
        {
            String str = string.Join(", ", directions);

            PrintDebugLine($"Answer: {str}\n");

            return str;
        }
    }
}
