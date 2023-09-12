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
    /// Purpose: Solves the light cycle module
    /// </summary>
    public class LightCycle : Module
    {
        String pair1,
            pair2,
            pair3,
            pair4,
            pair5,
            pair6;
        String sequence1,
            sequence2,
            sequence3,
            sequence4,
            sequence5,
            sequence6;
        private string cycle;

        public LightCycle(Bomb bomb, StreamWriter logFileWriter, String cycle)
            : base(bomb, logFileWriter, "Light Cycle")
        {
            this.cycle = cycle;

            pair1 = "" + bomb.SerialNumber[0] + bomb.SerialNumber[bomb.SerialNumber.Length - 1];
            pair2 = "" + bomb.SerialNumber[1] + bomb.SerialNumber[bomb.SerialNumber.Length - 2];
            pair3 = "" + bomb.SerialNumber[2] + bomb.SerialNumber[bomb.SerialNumber.Length - 3];
            pair4 = "" + bomb.SerialNumber[3] + bomb.SerialNumber[bomb.SerialNumber.Length - 4];
            pair5 = "" + bomb.SerialNumber[4] + bomb.SerialNumber[bomb.SerialNumber.Length - 5];
            pair6 = "" + bomb.SerialNumber[5] + bomb.SerialNumber[bomb.SerialNumber.Length - 6];
        }

        public string Solve(bool debug)
        {
            string orignalcycle = cycle;

            PrintDebugLine($"Starting cycle: {cycle}\n");

            sequence1 = GetSequence(pair1);

            cycle = SwapCycle(cycle, sequence1);

            PrintSequenceInformation(sequence1, 1, pair1);

            PrintCycle(cycle);

            sequence2 = GetSequence(pair2);

            PrintSequenceInformation(sequence2, 2, pair2);

            cycle = SwapCycle(cycle, sequence2);

            PrintCycle(cycle);

            sequence3 = GetSequence(pair3);

            PrintSequenceInformation(sequence3, 3, pair3);

            cycle = SwapCycle(cycle, sequence3);

            PrintCycle(cycle);

            sequence4 = GetSequence(pair4);

            PrintSequenceInformation(sequence4, 4, pair4);

            cycle = SwapCycle(cycle, sequence4);

            PrintCycle(cycle);

            sequence5 = GetSequence(pair5);

            PrintSequenceInformation(sequence5, 5, pair5);

            cycle = SwapCycle(cycle, sequence5);

            PrintCycle(cycle);

            sequence6 = GetSequence(pair6);

            PrintSequenceInformation(sequence6, 6, pair6);

            cycle = SwapCycle(cycle, sequence6);

            String answer = GetAnswer(cycle, orignalcycle);

            if (!debug)
            { 
            ShowAnswer(answer, true);
            }

            return answer;
        }

        private String GetSequence(String pair)
        {
            if (pair[0] == 'A')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "5B";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "BR";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "MG";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "Y5";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "41";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "RW";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "64";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "16";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "23";

                    case '1':
                    case '2':
                    case '3':
                        return "3M";

                    case '4':
                    case '5':
                    case '6':
                        return "GY";

                    default:
                        return "W2";
                }
            }

            if (pair[0] == 'B')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "2R";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "6M";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "43";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "5B";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "R5";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "Y2";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "1G";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "MY";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "W6";

                    case '1':
                    case '2':
                    case '3':
                        return "34";

                    case '4':
                    case '5':
                    case '6':
                        return "BW";

                    default:
                        return "G1";
                }
            }

            if (pair[0] == 'C')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "MY";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "24";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "YR";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "35";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "W2";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "GB";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "1W";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "R3";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "5G";

                    case '1':
                    case '2':
                    case '3':
                        return "46";

                    case '4':
                    case '5':
                    case '6':
                        return "BM";

                    default:
                        return "61";
                }
            }

            if (pair[0] == 'D')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "56";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "63";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "14";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "M2";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "RY";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "2M";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "WR";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "BG";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "YW";

                    case '1':
                    case '2':
                    case '3':
                        return "3B";

                    case '4':
                    case '5':
                    case '6':
                        return "G1";

                    default:
                        return "45";
                }
            }

            if (pair[0] == 'E')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "BR";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "W2";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "23";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "14";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "MB";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "56";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "YW";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "RM";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "GY";

                    case '1':
                    case '2':
                    case '3':
                        return "6G";

                    case '4':
                    case '5':
                    case '6':
                        return "35";

                    default:
                        return "41";
                }
            }

            if (pair[0] == 'F')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "RY";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "2G";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "1M";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "Y5";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "5R";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "WB";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "63";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "B1";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "M4";

                    case '1':
                    case '2':
                    case '3':
                        return "G6";

                    case '4':
                    case '5':
                    case '6':
                        return "32";

                    default:
                        return "4W";
                }
            }

            if (pair[0] == 'G')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "Y1";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "54";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "2W";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "RY";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "1R";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "B3";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "6G";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "G6";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "MB";

                    case '1':
                    case '2':
                    case '3':
                        return "W5";

                    case '4':
                    case '5':
                    case '6':
                        return "42";

                    default:
                        return "3M";
                }
            }

            if (pair[0] == 'H')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "35";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "WY";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "G2";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "2B";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "5G";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "MR";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "B3";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "14";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "46";

                    case '1':
                    case '2':
                    case '3':
                        return "YM";

                    case '4':
                    case '5':
                    case '6':
                        return "6W";

                    default:
                        return "R1";
                }
            }

            if (pair[0] == 'I')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "RM";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "45";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "5W";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "B1";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "M6";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "32";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "WB";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "GY";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "YR";

                    case '1':
                    case '2':
                    case '3':
                        return "14";

                    case '4':
                    case '5':
                    case '6':
                        return "6G";

                    default:
                        return "23";
                }
            }

            if (pair[0] == 'J')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "WB";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "R6";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "5Y";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "41";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "25";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "Y3";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "MW";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "32";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "BG";

                    case '1':
                    case '2':
                    case '3':
                        return "GM";

                    case '4':
                    case '5':
                    case '6':
                        return "1R";

                    default:
                        return "64";
                }
            }

            if (pair[0] == 'K')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "64";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "B2";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "WG";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "R5";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "G1";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "2Y";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "YR";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "MB";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "16";

                    case '1':
                    case '2':
                    case '3':
                        return "3W";

                    case '4':
                    case '5':
                    case '6':
                        return "53";

                    default:
                        return "4M";
                }
            }

            if (pair[0] == 'L')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "64";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "B5";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "W6";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "1G";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "R2";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "4R";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "GW";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "3M";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "2B";

                    case '1':
                    case '2':
                    case '3':
                        return "Y3";

                    case '4':
                    case '5':
                    case '6':
                        return "5Y";

                    default:
                        return "M1";
                }
            }

            if (pair[0] == 'M')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "W3";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "3G";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "24";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "YM";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "M2";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "R5";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "6R";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "B6";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "GY";

                    case '1':
                    case '2':
                    case '3':
                        return "5B";

                    case '4':
                    case '5':
                    case '6':
                        return "1W";

                    default:
                        return "41";
                }
            }

            if (pair[0] == 'N')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "1Y";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "6M";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "21";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "GR";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "3G";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "5B";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "R4";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "43";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "W2";

                    case '1':
                    case '2':
                    case '3':
                        return "YW";

                    case '4':
                    case '5':
                    case '6':
                        return "B5";

                    default:
                        return "M6";
                }
            }

            if (pair[0] == 'O')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "R5";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "3G";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "23";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "W4";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "B2";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "1M";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "56";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "M1";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "4Y";

                    case '1':
                    case '2':
                    case '3':
                        return "GB";

                    case '4':
                    case '5':
                    case '6':
                        return "GR";

                    default:
                        return "YW";
                }
            }

            if (pair[0] == 'P')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "14";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "4B";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "62";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "3W";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "MR";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "Y6";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "BY";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "2G";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "5M";

                    case '1':
                    case '2':
                    case '3':
                        return "G5";

                    case '4':
                    case '5':
                    case '6':
                        return "R3";

                    default:
                        return "W1";
                }
            }

            if (pair[0] == 'Q')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "5G";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "MB";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "4W";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "Y2";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "RM";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "W4";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "61";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "36";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "BY";

                    case '1':
                    case '2':
                    case '3':
                        return "15";

                    case '4':
                    case '5':
                    case '6':
                        return "GR";

                    default:
                        return "23";
                }
            }

            if (pair[0] == 'R')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "MG";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "56";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "GM";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "W5";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "Y2";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "R4";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "B1";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "1B";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "2R";

                    case '1':
                    case '2':
                    case '3':
                        return "43";

                    case '4':
                    case '5':
                    case '6':
                        return "6W";

                    default:
                        return "3Y";
                }
            }

            if (pair[0] == 'S')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "RY";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "65";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "5G";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "GB";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "WM";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "43";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "1W";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "B1";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "36";

                    case '1':
                    case '2':
                    case '3':
                        return "24";

                    case '4':
                    case '5':
                    case '6':
                        return "Y2";

                    default:
                        return "MR";
                }
            }

            if (pair[0] == 'T')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "G3";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "B2";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "6W";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "MB";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "15";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "Y4";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "5M";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "WR";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "46";

                    case '1':
                    case '2':
                    case '3':
                        return "3Y";

                    case '4':
                    case '5':
                    case '6':
                        return "2G";

                    default:
                        return "R1";
                }
            }

            if (pair[0] == 'U')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "51";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "W3";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "45";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "34";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "YW";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "1Y";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "BG";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "62";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "M6";

                    case '1':
                    case '2':
                    case '3':
                        return "GR";

                    case '4':
                    case '5':
                    case '6':
                        return "2M";

                    default:
                        return "RB";
                }
            }

            if (pair[0] == 'V')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "MG";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "6B";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "1G";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "35";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "WR";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "B4";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "GM";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "R1";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "2W";

                    case '1':
                    case '2':
                    case '3':
                        return "52";

                    case '4':
                    case '5':
                    case '6':
                        return "4Y";

                    default:
                        return "Y3";
                }
            }

            if (pair[0] == 'W')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "YM";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "B1";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "53";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "2G";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "32";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "R5";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "14";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "W6";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "4W";

                    case '1':
                    case '2':
                    case '3':
                        return "GR";

                    case '4':
                    case '5':
                    case '6':
                        return "MY";

                    default:
                        return "6B";
                }
            }

            if (pair[0] == 'X')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "42";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "RB";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "W5";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "YM";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "2Y";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "51";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "BR";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "G3";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "MG";

                    case '1':
                    case '2':
                    case '3':
                        return "36";

                    case '4':
                    case '5':
                    case '6':
                        return "6W";

                    default:
                        return "14";
                }
            }

            if (pair[0] == 'Y')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "GY";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "1R";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "54";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "4G";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "3B";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "M6";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "25";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "Y2";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "R1";

                    case '1':
                    case '2':
                    case '3':
                        return "W3";

                    case '4':
                    case '5':
                    case '6':
                        return "BW";

                    default:
                        return "6M";
                }
            }

            if (pair[0] == 'Z')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "GB";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "BG";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "15";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "M1";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "3M";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "R3";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "YW";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "6Y";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "52";

                    case '1':
                    case '2':
                    case '3':
                        return "46";

                    case '4':
                    case '5':
                    case '6':
                        return "WR";

                    default:
                        return "24";
                }
            }

            if (pair[0] == 'Z')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "2R";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "RB";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "5G";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "W2";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "Y1";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "4Y";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "35";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "1M";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "BW";

                    case '1':
                    case '2':
                    case '3':
                        return "G6";

                    case '4':
                    case '5':
                    case '6':
                        return "64";

                    default:
                        return "24";
                }
            }

            if (pair[0] == '0')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "2R";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "RB";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "5G";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "W2";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "Y1";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "4Y";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "35";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "1M";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "BW";

                    case '1':
                    case '2':
                    case '3':
                        return "G6";

                    case '4':
                    case '5':
                    case '6':
                        return "64";

                    default:
                        return "M3";
                }
            }

            if (pair[0] == '1')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "R4";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "W6";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "32";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "2W";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "4Y";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "65";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "BR";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "5G";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "YB";

                    case '1':
                    case '2':
                    case '3':
                        return "GM";

                    case '4':
                    case '5':
                    case '6':
                        return "M1";

                    default:
                        return "13";
                }
            }

            if (pair[0] == '2')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "4B";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "B3";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "64";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "W1";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "MY";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "R6";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "G5";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "YW";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "52";

                    case '1':
                    case '2':
                    case '3':
                        return "2R";

                    case '4':
                    case '5':
                    case '6':
                        return "3G";

                    default:
                        return "1M";
                }
            }

            if (pair[0] == '3')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "B6";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "M3";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "4B";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "14";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "25";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "Y1";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "GY";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "RW";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "WG";

                    case '1':
                    case '2':
                    case '3':
                        return "52";

                    case '4':
                    case '5':
                    case '6':
                        return "6M";

                    default:
                        return "3R";
                }
            }

            if (pair[0] == '4')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "MR";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "2B";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "W5";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "6Y";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "B3";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "42";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "G1";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "YG";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "5G";

                    case '1':
                    case '2':
                    case '3':
                        return "3M";

                    case '4':
                    case '5':
                    case '6':
                        return "RW";

                    default:
                        return "14";
                }
            }

            if (pair[0] == '5')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "Y1";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "56";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "1W";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "W4";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "BG";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "G5";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "4M";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "2B";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "3R";

                    case '1':
                    case '2':
                    case '3':
                        return "63";

                    case '4':
                    case '5':
                    case '6':
                        return "M2";

                    default:
                        return "RY";
                }
            }

            if (pair[0] == '6')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "34";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "WB";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "YG";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "5M";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "R1";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "GW";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "12";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "6Y";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "BR";

                    case '1':
                    case '2':
                    case '3':
                        return "M6";

                    case '4':
                    case '5':
                    case '6':
                        return "43";

                    default:
                        return "25";
                }
            }

            if (pair[0] == '7')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "4G";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "65";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "Y4";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "GB";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "31";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "MY";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "53";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "1M";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "2R";

                    case '1':
                    case '2':
                    case '3':
                        return "R2";

                    case '4':
                    case '5':
                    case '6':
                        return "BW";

                    default:
                        return "W6";
                }
            }

            if (pair[0] == '8')
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "YB";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "R2";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "WR";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "53";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "1W";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "35";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "BM";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "G4";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "6Y";

                    case '1':
                    case '2':
                    case '3':
                        return "4G";

                    case '4':
                    case '5':
                    case '6':
                        return "21";

                    default:
                        return "M6";
                }
            }
            else
            {
                switch (pair[1])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        return "GY";

                    case 'D':
                    case 'E':
                    case 'F':
                        return "31";

                    case 'G':
                    case 'H':
                    case 'I':
                        return "5M";

                    case 'J':
                    case 'K':
                    case 'L':
                        return "R2";

                    case 'M':
                    case 'N':
                    case 'O':
                        return "6W";

                    case 'P':
                    case 'Q':
                    case 'R':
                        return "MB";

                    case 'S':
                    case 'T':
                    case 'U':
                        return "Y6";

                    case 'V':
                    case 'W':
                    case 'X':
                        return "24";

                    case 'Y':
                    case 'Z':
                    case '0':
                        return "4G";

                    case '1':
                    case '2':
                    case '3':
                        return "B5";

                    case '4':
                    case '5':
                    case '6':
                        return "1R";

                    default:
                        return "W3";
                }
            }
        }

        private String SwapCycle(String cycle, String sequence)
        {
            char[] cycleArr = cycle.ToCharArray();
            int firstIndex;
            int secondIndex;
            //two numbers
            if (sequence[0] >= 49 && sequence[0] <= 57 && sequence[1] >= 49 && sequence[1] <= 57)
            {
                //get index of both colors

                firstIndex = int.Parse("" + sequence[0]) - 1;
                secondIndex = int.Parse("" + sequence[1]) - 1;
            }
            //two letters
            else if (
                sequence[0] >= 65 && sequence[0] <= 90 && sequence[1] >= 65 && sequence[1] <= 90
            )
            {
                firstIndex = cycle.IndexOf(sequence[0]);
                secondIndex = cycle.IndexOf(sequence[1]);
            }
            //letter than number
            else if (
                sequence[0] >= 65 && sequence[0] <= 90 && sequence[1] >= 49 && sequence[1] <= 57
            )
            {
                firstIndex = cycle.IndexOf(sequence[0]);
                secondIndex = int.Parse("" + sequence[1]) - 1;
            }
            //number then letter
            else
            {
                firstIndex = int.Parse("" + sequence[0]) - 1;
                secondIndex = cycle.IndexOf(sequence[1]);
            }

            char firstChar = cycle[firstIndex];

            cycleArr[firstIndex] = cycleArr[secondIndex];

            cycleArr[secondIndex] = firstChar;

            return string.Join("", cycleArr);
        }

        private void PrintSequenceInformation(string sequence, int num, string pair)
        {
            PrintDebugLine($"Pair {num}: {sequence[0]}/{sequence[1]} ({pair})");
        }

        private void PrintCycle(String cycle)
        {
            PrintDebugLine($"Cycle now: {cycle}\n");
        }

        private String GetAnswer(String cycle, String orignalCycle)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < 6; i++)
            {
                string str;

                switch (cycle[i])
                {
                    case 'R':
                        str = "Red";
                        break;

                    case 'B':
                        str = "Blue";
                        break;

                    case 'Y':
                        str = "Yellow";
                        break;

                    case 'G':
                        str = "Green";
                        break;

                    case 'W':
                        str = "White";
                        break;

                    default:
                        str = "Magenta";
                        break;
                }

                list.Add($"({orignalCycle.IndexOf(cycle[i]) + 1}) {str}");
            }

            //tells where the new lines need to be placed
            List<int> newLineList = new List<int>();

            for (int i = 0; i < cycle.Length - 1; i++)
            {
                if (orignalCycle.IndexOf(cycle[i]) > orignalCycle.IndexOf(cycle[i + 1]))
                {
                    newLineList.Add(i + 1);
                }
            }

            string answer = "";

            for (int i = 0; i < list.Count; i++)
            {
                bool newLine = newLineList.Contains(i);

                if (newLine)
                {
                    answer += "\n";
                }

                answer += list[i];

                if (i != list.Count - 1)
                {
                    answer += ", ";
                }
            }

            return answer;
        }
    }
}
