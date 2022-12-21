using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class FastMath : Module
    {
        int answer;

        public FastMath(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Fast Math") { }

        public int SolveDebug(char leftLetter, char rightLetter)
        {
            GetInitialNumber(leftLetter, rightLetter);
            ModifyNumber();

            return answer;
        }

        public void Solve(char leftLetter, char rightLetter)
        {
            GetInitialNumber(leftLetter, rightLetter);
            ModifyNumber();

            ShowAnswer("" + answer, true);
        }

        private void GetInitialNumber(char leftLetter, char rightLetter)
        {
            PrintDebugLine($"Left Letter: {leftLetter}");
            PrintDebugLine($"Right Letter: {rightLetter}\n");

            answer = -1;
            switch (leftLetter)
            {
                case 'A':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 25;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 11;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 53;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 97;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 2;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 42;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 51;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 97;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 12;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 86;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 55;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 73;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 33;
                        }
                    }
                    break;

                case 'B':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 54;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 7;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 32;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 19;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 84;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 33;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 27;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 78;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 26;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 46;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 9;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 13;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 58;
                        }
                    }
                    break;

                case 'C':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 86;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 37;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 44;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 1;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 5;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 26;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 93;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 49;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 18;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 69;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 23;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 40;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 22;
                        }
                    }
                    break;
                case 'D':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 54;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 28;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 77;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 93;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 11;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 0;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 35;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 61;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 27;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 48;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 13;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 72;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 80;
                        }
                    }
                    break;

                case 'E':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 99;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 36;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 23;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 95;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 67;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 5;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 26;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 17;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 44;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 60;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 26;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 41;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 67;
                        }
                    }
                    break;

                case 'G':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 74;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 95;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 3;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 4;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 56;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 23;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 54;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 29;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 52;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 38;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 10;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 76;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 98;
                        }
                    }
                    break;

                case 'K':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 88;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 46;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 37;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 96;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 2;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 52;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 81;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 37;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 12;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 70;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 14;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 36;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 78;
                        }
                    }
                    break;

                case 'N':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 54;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 43;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 12;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 65;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 94;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 3;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 47;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 23;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 16;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 62;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 73;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 46;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 21;
                        }
                    }
                    break;

                case 'P':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 7;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 33;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 26;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 1;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 67;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 26;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 27;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 77;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 83;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 14;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 27;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 93;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 9;
                        }
                    }
                    break;

                case 'S':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 63;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 64;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 94;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 27;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 48;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 84;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 33;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 10;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 16;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 74;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 43;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 99;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 4;
                        }
                    }
                    break;

                case 'T':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 35;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 39;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 3;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 25;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 47;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 62;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 38;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 45;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 88;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 48;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 34;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 31;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 27;
                        }
                    }
                    break;

                case 'X':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 67;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 30;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 27;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 71;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 9;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 11;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 44;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 37;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 18;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 40;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 32;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 15;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 78;
                        }
                    }
                    break;

                case 'Z':

                    {
                        if (rightLetter == 'A')
                        {
                            answer = 13;
                        }
                        else if (rightLetter == 'B')
                        {
                            answer = 23;
                        }
                        else if (rightLetter == 'C')
                        {
                            answer = 26;
                        }
                        else if (rightLetter == 'D')
                        {
                            answer = 85;
                        }
                        else if (rightLetter == 'E')
                        {
                            answer = 92;
                        }
                        else if (rightLetter == 'G')
                        {
                            answer = 12;
                        }
                        else if (rightLetter == 'K')
                        {
                            answer = 73;
                        }
                        else if (rightLetter == 'N')
                        {
                            answer = 56;
                        }
                        else if (rightLetter == 'P')
                        {
                            answer = 81;
                        }
                        else if (rightLetter == 'S')
                        {
                            answer = 7;
                        }
                        else if (rightLetter == 'T')
                        {
                            answer = 75;
                        }
                        else if (rightLetter == 'X')
                        {
                            answer = 47;
                        }
                        else if (rightLetter == 'Z')
                        {
                            answer = 99;
                        }
                    }
                    break;
            }

            PrintDebugLine("Initial Number: " + answer + "\n");
        }

        private void ModifyNumber()
        {
            if (Bomb.Msa.Lit)
            {
                answer += 20;
                PrintDebugLine("Bomb has a lit MSA: adding 20\n");
            }

            if (Bomb.RCAVisuble)
            {
                answer += 14;
                PrintDebugLine("Bomb has a serial port: adding 14\n");
            }

            if (
                Bomb.SerialNumber.Contains("F")
                || Bomb.SerialNumber.Contains("A")
                || Bomb.SerialNumber.Contains("S")
                || Bomb.SerialNumber.Contains("T")
            )
            {
                answer -= 5;
                PrintDebugLine(
                    "Bomb contains at least one of the following letters: F, A, S, T: subtracting 5\n"
                );
            }

            if (Bomb.RJVisible)
            {
                answer += 27;
                PrintDebugLine("Bomb has a RJ-45 port: adding 27\n");
            }

            if (Bomb.Battery > 3)
            {
                answer -= 15;
                PrintDebugLine("Bomb has at least 4 batteries: subtracting 15\n");
            }

            if (answer < 0)
            {
                answer += 50;
                PrintDebugLine("Answer is less than 0, adding 50\n");
            }

            answer %= 100;
        }
    }
}
