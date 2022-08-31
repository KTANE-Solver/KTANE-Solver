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
    /// Purpose: Solves the gamepad module
    /// </summary>
    class Gamepad : Module
    {
        private int x,
            y,
            a,
            b,
            c,
            d;
        private String[] firstSubcommand,
            secondSubcommand,
            command;

        public Gamepad(int x, int y, Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Gamepad")
        {
            this.x = x;
            this.y = y;

            a = x / 10;
            b = x % 10;
            c = y / 10;
            d = y % 10;

            PrintDebugLine($"X: {x}");
            PrintDebugLine($"Y: {y}");
            PrintDebugLine($"A: {a}");
            PrintDebugLine($"B: {b}");
            PrintDebugLine($"C: {c}");
            PrintDebugLine($"D: {d}\n");
        }

        public void Solve()
        {
            SetFirstSubcommand();
            setSecondSubcommand();

            PrintDebugLine(
                $"Answer (before overrides): {string.Join(", ", firstSubcommand)}, {string.Join(",", secondSubcommand)}\n"
            );

            setOverrides();

            String answer = string.Join(", ", command);

            PrintDebugLine($"Answer: {answer}\n");

            ShowAnswer(answer, true);
        }

        private void SetFirstSubcommand()
        {
            //x is prime
            if (IsPrime(x))
            {
                firstSubcommand = new String[] { "UP", "UP", "DOWN", "DOWN" };
            }
            //x is a multiple of 12
            else if (x % 12 == 0)
            {
                firstSubcommand = new String[] { "UP", "A", "LEFT", "LEFT" };
            }
            //a + b = 10 and the last digit of the serial number is odd
            else if (a + b == 10 && Bomb.LastDigit % 2 == 1)
            {
                firstSubcommand = new String[] { "A", "B", "LEFT", "RIGHT" };
            }
            //x = 6n + 3 or x = 10n + 5
            else if ((x - 3) % 6 == 0 || (x - 5) % 10 == 0)
            {
                firstSubcommand = new String[] { "DOWN", "LEFT", "A", "RIGHT" };
            }
            //x = 7n and y != 7n
            else if (x % 7 == 0 && y % 7 != 0)
            {
                firstSubcommand = new String[] { "LEFT", "LEFT", "UP", "B" };
            }
            //x = c * d
            else if (x == c * d)
            {
                firstSubcommand = new String[] { "A", "UP", "LEFT", "LEFT" };
            }
            //x is a perfect square
            else if (IsPerfectSquare(x))
            {
                firstSubcommand = new String[] { "RIGHT", "RIGHT", "A", "DOWN" };
            }
            //x = 3n - 1 or unlit SND
            else if ((x + 1) % 3 == 0 || Bomb.Snd.VisibleNotLit)
            {
                firstSubcommand = new String[] { "RIGHT", "A", "B", "UP" };
            }
            //60 <= x < 90 and no batteries
            else if (60 <= x && x < 90 && Bomb.Battery == 0)
            {
                firstSubcommand = new String[] { "B", "B", "RIGHT", "LEFT" };
            }
            //x = 6n
            else if (x % 6 == 0)
            {
                firstSubcommand = new String[] { "A", "B", "A", "RIGHT" };
            }
            //x = 4n
            else if (x % 4 == 0)
            {
                firstSubcommand = new String[] { "DOWN", "DOWN", "LEFT", "UP" };
            }
            //last resort
            else
            {
                firstSubcommand = new String[] { "A", "LEFT", "B", "RIGHT" };
            }
        }

        public static bool IsPrime(int num)
        {
            if (num == 0 || num == 1)
            {
                return false;
            }

            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void setSecondSubcommand()
        {
            //y is prime
            if (IsPrime(y))
            {
                secondSubcommand = new String[] { "LEFT", "RIGHT", "LEFT", "RIGHT" };
            }
            //y is a multiple of 8
            else if (y % 8 == 0)
            {
                secondSubcommand = new String[] { "DOWN", "RIGHT", "B", "UP" };
            }
            //c - d = 4 and has a stereo rca
            else if (c - d == 4 && Bomb.Stereo.Visible)
            {
                secondSubcommand = new String[] { "RIGHT", "A", "DOWN", "DOWN" };
            }
            //y = 4n + 2 or lit frq
            else if ((y - 2) % 4 == 0 || Bomb.Frq.Lit)
            {
                secondSubcommand = new String[] { "B", "UP", "RIGHT", "A" };
            }
            //y = 7n and x != 7n
            else if (y % 7 == 0 && x % 7 != 0)
            {
                secondSubcommand = new String[] { "LEFT", "LEFT", "DOWN", "A" };
            }
            //y is a perfect square
            else if (IsPerfectSquare(y))
            {
                secondSubcommand = new String[] { "UP", "DOWN", "B", "RIGHT" };
            }
            //y = a * b
            else if (a * b == y)
            {
                secondSubcommand = new String[] { "A", "UP", "LEFT", "DOWN" };
            }
            //y = 4n - 1 or has a ps2
            else if ((y + 1) % 4 == 0 || Bomb.Ps.Visible)
            {
                secondSubcommand = new String[] { "UP", "B", "B", "B" };
            }
            //c > d and 2 or more batteries
            else if (c > d && Bomb.Battery >= 2)
            {
                secondSubcommand = new String[] { "A", "A", "UP", "DOWN" };
            }
            //y = 5n
            else if (y % 5 == 0)
            {
                secondSubcommand = new String[] { "B", "A", "B", "LEFT" };
            }
            //y = 3n
            else if (y % 3 == 0)
            {
                secondSubcommand = new String[] { "RIGHT", "UP", "UP", "LEFT" };
            }
            //last resort
            else
            {
                secondSubcommand = new String[] { "B", "UP", "A", "DOWN" };
            }
        }

        //setting all the overrides
        public void setOverrides()
        {
            //if x is a multiple 11, switch 1 with 2 and switch 5 with 7
            if (x % 11 == 0)
            {
                String temp = firstSubcommand[0];

                firstSubcommand[0] = firstSubcommand[1];

                firstSubcommand[1] = temp;

                temp = secondSubcommand[0];

                secondSubcommand[0] = secondSubcommand[2];

                secondSubcommand[2] = temp;
            }

            //if a = 1 + d, switch 3 with 4 and switch 6 with 8
            if (1 + d == a)
            {
                String temp = firstSubcommand[2];

                firstSubcommand[2] = firstSubcommand[3];

                firstSubcommand[3] = temp;

                temp = secondSubcommand[1];

                secondSubcommand[1] = secondSubcommand[3];

                secondSubcommand[3] = temp;
            }

            //if x or y is a highly composite number, switch the commands
            if (IsHighlyComposite(x) || IsHighlyComposite(y))
            {
                String[] temp = firstSubcommand;

                firstSubcommand = secondSubcommand;

                secondSubcommand = temp;
            }

            //setting the full command
            command = new String[8];

            for (int i = 0; i < 4; i++)
            {
                command[i] = firstSubcommand[i];
                command[4 + i] = secondSubcommand[i];
            }

            //if x and y are prefect squares, flip the entire sequence
            if (IsPerfectSquare(x) && IsPerfectSquare(y))
            {
                int i = 0;
                int j = 7;

                while (i < j)
                {
                    String temp = command[i];

                    command[i] = command[j];
                    command[j] = temp;

                    i++;
                    j--;
                }
            }
        }

        //tells if a number is a perfect square
        public static bool IsPerfectSquare(int num)
        {
            return Math.Sqrt(num) == (int)Math.Sqrt(num);
        }

        // Function to check if a number
        // is a highly composite number
        static bool IsHighlyComposite(int num)
        {
            switch (num)
            {
                case 1:
                case 2:
                case 4:
                case 6:
                case 12:
                case 24:
                case 36:
                case 48:
                case 60:
                    return true;

                default:
                    return false;
            }
        }
    }
}
