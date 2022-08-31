using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class SafetySafe : Module
    {
        public int offset;
        public int firstTurn;
        public int secondTurn;
        public int thirdTurn;
        public int fourthTurn;
        public int fifthTurn;
        public int sixthTurn;

        public SafetySafe(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Saftey Safe")
        {
            offset = 0;
            firstTurn = 0;
            secondTurn = 0;
            thirdTurn = 0;
            fourthTurn = 0;
            firstTurn = 0;
            sixthTurn = 0;
        }

        public void Debug()
        {
            offset = FindOffset();

            firstTurn = FindFirstTurn();
            secondTurn = FindSecondTurn();
            thirdTurn = FindThirdTurn();
            fourthTurn = FindFourthTurn();
            fifthTurn = FindFifthTurn();
            sixthTurn = FindSixthTurn() % 12;

            PrintDebugLine("Offset: " + offset);
            PrintDebugLine("First Turn: " + firstTurn);
            PrintDebugLine("Second Turn: " + secondTurn);
            PrintDebugLine("Third Turn: " + thirdTurn);
            PrintDebugLine("Fourth Turn: " + fourthTurn);
            PrintDebugLine("Fifth Turn: " + fifthTurn);
            PrintDebugLine("Sixth Turn: " + sixthTurn + "\n");
        }

        public int[] Solve()
        {
            offset = FindOffset();

            firstTurn = FindFirstTurn();
            PrintDebugLine("Local First Turn: " + firstTurn);

            secondTurn = FindSecondTurn();
            PrintDebugLine("Local Second Turn: " + secondTurn);

            thirdTurn = FindThirdTurn();
            PrintDebugLine("Local Third Turn: " + thirdTurn);

            fourthTurn = FindFourthTurn();
            PrintDebugLine("Local Fourth Turn: " + fourthTurn);

            fifthTurn = FindFifthTurn();
            PrintDebugLine("Local Fifth Turn: " + fifthTurn);

            sixthTurn = FindSixthTurn() % 12;
            PrintDebugLine("Local Sixth Turn: " + sixthTurn + "\n");

            firstTurn = (firstTurn + offset) % 12;
            secondTurn = (secondTurn + offset) % 12;
            thirdTurn = (thirdTurn + offset) % 12;
            fourthTurn = (fourthTurn + offset) % 12;
            fifthTurn = (fifthTurn + offset) % 12;
            sixthTurn = (sixthTurn + offset) % 12;

            string answer =
                $"1. {firstTurn}\n2. {secondTurn}\n3. {thirdTurn}\n4. {fourthTurn}\n5. {fifthTurn}\n6. {sixthTurn}";

            PrintDebugLine("Answer:\n" + answer + "\n");

            int[] arr = new int[]
            {
                firstTurn,
                secondTurn,
                thirdTurn,
                fourthTurn,
                fifthTurn,
                sixthTurn
            };

            return arr;
        }

        private int FindOffset()
        {
            int portNum = Bomb.UniquePortNum;
            int offset = portNum * 7;

            PrintDebugLine($"{portNum} port types were found. Offset is {offset}");

            int indicatorLitNum = 0;
            foreach (Indicator indicator in Bomb.LitIndicatorsList)
            {
                if (HasLetterInSerialNumber(indicator.Name))
                {
                    indicatorLitNum++;
                }
            }

            offset += indicatorLitNum * 5;

            PrintDebugLine(
                $"{indicatorLitNum} lit indicators that share a letter with the serial number were found. Offset is now {offset}"
            );

            int indicatorUnlitNum = 0;
            foreach (Indicator indicator in Bomb.UnlitIndicatorsList)
            {
                if (HasLetterInSerialNumber(indicator.Name))
                {
                    indicatorUnlitNum++;
                }
            }

            offset += indicatorUnlitNum;

            PrintDebugLine(
                $"{indicatorUnlitNum} unlit indicators that share a letter with the serial number were found. Offset is now {offset}"
            );

            offset %= 12;

            PrintDebugLine($"Updated offset is now {offset}\n");

            return offset;
        }

        private int FindFirstTurn()
        {
            switch (Bomb.SerialNumber[0])
            {
                case 'A':
                    return 8;

                case 'B':
                    return 10;

                case 'C':
                    return 2;
                case 'D':
                    return 11;

                case 'E':
                    return 0;

                case 'F':
                    return 4;

                case 'G':
                    return 7;
                case 'H':
                    return 8;
                case 'I':
                    return 0;
                case 'J':
                    return 2;
                case 'K':
                    return 5;
                case 'L':
                    return 1;
                case 'M':
                    return 1;
                case 'N':
                    return 9;
                case 'O':
                    return 5;
                case 'P':
                    return 3;
                case 'Q':
                    return 4;
                case 'R':
                    return 8;
                case 'S':
                    return 9;
                case 'T':
                    return 7;
                case 'U':
                    return 11;
                case 'V':
                    return 11;
                case 'W':
                    return 6;
                case 'X':
                    return 4;
                case 'Y':
                    return 10;
                case 'Z':
                    return 3;
                case '0':
                    return 7;
                case '1':
                    return 9;
                case '2':
                    return 2;
                case '3':
                    return 10;
                case '4':
                    return 6;
                case '5':
                    return 6;
                case '6':
                    return 1;
                case '7':
                    return 0;
                case '8':
                    return 5;
                default:
                    return 3;
            }
        }

        private int FindSecondTurn()
        {
            switch (Bomb.SerialNumber[1])
            {
                case 'A':
                    return 3;
                case 'B':
                    return 1;
                case 'C':
                    return 1;
                case 'D':
                    return 6;
                case 'E':
                    return 5;
                case 'F':
                    return 2;
                case 'G':
                    return 4;
                case 'H':
                    return 3;
                case 'I':
                    return 11;
                case 'J':
                    return 11;
                case 'K':
                    return 2;
                case 'L':
                    return 9;
                case 'M':
                    return 7;
                case 'N':
                    return 5;
                case 'O':
                    return 9;
                case 'P':
                    return 10;
                case 'Q':
                    return 10;
                case 'R':
                    return 0;
                case 'S':
                    return 4;
                case 'T':
                    return 6;
                case 'U':
                    return 9;
                case 'V':
                    return 11;
                case 'W':
                    return 0;
                case 'X':
                    return 2;
                case 'Y':
                    return 7;
                case 'Z':
                    return 7;
                case '0':
                    return 0;
                case '1':
                    return 10;
                case '2':
                    return 5;
                case '3':
                    return 8;
                case '4':
                    return 8;
                case '5':
                    return 3;
                case '6':
                    return 1;
                case '7':
                    return 6;
                case '8':
                    return 4;
                default:
                    return 8;
            }
        }

        private int FindThirdTurn()
        {
            switch (Bomb.SerialNumber[2])
            {
                case 'A':
                    return 4;
                case 'B':
                    return 3;
                case 'C':
                    return 1;
                case 'D':
                    return 11;
                case 'E':
                    return 5;
                case 'F':
                    return 7;
                case 'G':
                    return 4;
                case 'H':
                    return 6;
                case 'I':
                    return 0;
                case 'J':
                    return 8;
                case 'K':
                    return 5;
                case 'L':
                    return 8;
                case 'M':
                    return 9;
                case 'N':
                    return 1;
                case 'O':
                    return 8;
                case 'P':
                    return 9;
                case 'Q':
                    return 6;
                case 'R':
                    return 4;
                case 'S':
                    return 0;
                case 'T':
                    return 7;
                case 'U':
                    return 6;
                case 'V':
                    return 2;
                case 'W':
                    return 11;
                case 'X':
                    return 7;
                case 'Y':
                    return 10;
                case 'Z':
                    return 1;
                case '0':
                    return 3;
                case '1':
                    return 10;
                case '2':
                    return 11;
                case '3':
                    return 10;
                case '4':
                    return 0;
                case '5':
                    return 3;
                case '6':
                    return 5;
                case '7':
                    return 2;
                case '8':
                    return 9;
                default:
                    return 2;
            }
        }

        private int FindFourthTurn()
        {
            switch (Bomb.SerialNumber[3])
            {
                case 'A':
                    return 8;
                case 'B':
                    return 7;
                case 'C':
                    return 5;
                case 'D':
                    return 11;
                case 'E':
                    return 8;
                case 'F':
                    return 7;
                case 'G':
                    return 2;
                case 'H':
                    return 6;
                case 'I':
                    return 0;
                case 'J':
                    return 0;
                case 'K':
                    return 1;
                case 'L':
                    return 11;
                case 'M':
                    return 5;
                case 'N':
                    return 4;
                case 'O':
                    return 10;
                case 'P':
                    return 1;
                case 'Q':
                    return 1;
                case 'R':
                    return 0;
                case 'S':
                    return 6;
                case 'T':
                    return 11;
                case 'U':
                    return 3;
                case 'V':
                    return 8;
                case 'W':
                    return 6;
                case 'X':
                    return 2;
                case 'Y':
                    return 10;
                case 'Z':
                    return 10;
                case '0':
                    return 5;
                case '1':
                    return 9;
                case '2':
                    return 7;
                case '3':
                    return 4;
                case '4':
                    return 3;
                case '5':
                    return 3;
                case '6':
                    return 2;
                case '7':
                    return 4;
                case '8':
                    return 9;
                default:
                    return 9;
            }
        }

        private int FindFifthTurn()
        {
            switch (Bomb.SerialNumber[4])
            {
                case 'A':
                    return 9;
                case 'B':
                    return 3;
                case 'C':
                    return 3;
                case 'D':
                    return 7;
                case 'E':
                    return 2;
                case 'F':
                    return 1;
                case 'G':
                    return 10;
                case 'H':
                    return 6;
                case 'I':
                    return 9;
                case 'J':
                    return 5;
                case 'K':
                    return 0;
                case 'L':
                    return 11;
                case 'M':
                    return 6;
                case 'N':
                    return 4;
                case 'O':
                    return 2;
                case 'P':
                    return 9;
                case 'Q':
                    return 4;
                case 'R':
                    return 6;
                case 'S':
                    return 3;
                case 'T':
                    return 5;
                case 'U':
                    return 11;
                case 'V':
                    return 1;
                case 'W':
                    return 11;
                case 'X':
                    return 8;
                case 'Y':
                    return 8;
                case 'Z':
                    return 0;
                case '0':
                    return 8;
                case '1':
                    return 1;
                case '2':
                    return 7;
                case '3':
                    return 10;
                case '4':
                    return 5;
                case '5':
                    return 0;
                case '6':
                    return 7;
                case '7':
                    return 2;
                case '8':
                    return 10;
                default:
                    return 4;
            }
        }

        private int FindSixthTurn()
        {
            int num = 0;
            PrintDebug("Sixth number: ");
            for (int i = 0; i < Bomb.SerialNumber.Length; i++)
            {
                int addition;

                switch (Bomb.SerialNumber[i])
                {
                    case 'A':
                        addition = 0;
                        break;
                    case 'B':
                        addition = 8;
                        break;

                    case 'C':
                        addition = 6;
                        break;

                    case 'D':
                        addition = 7;
                        break;

                    case 'E':
                        addition = 1;
                        break;

                    case 'F':
                        addition = 5;
                        break;

                    case 'G':
                        addition = 5;
                        break;

                    case 'H':
                        addition = 5;
                        break;

                    case 'I':
                        addition = 10;
                        break;

                    case 'J':
                        addition = 6;
                        break;

                    case 'K':
                        addition = 4;
                        break;

                    case 'L':
                        addition = 11;
                        break;

                    case 'M':
                        addition = 2;
                        break;

                    case 'N':
                        addition = 9;
                        break;

                    case 'O':
                        addition = 8;
                        break;

                    case 'P':
                        addition = 7;
                        break;

                    case 'Q':
                        addition = 8;
                        break;

                    case 'R':
                        addition = 11;
                        break;

                    case 'S':
                        addition = 10;
                        break;

                    case 'T':
                        addition = 3;
                        break;

                    case 'U':
                        addition = 1;
                        break;

                    case 'V':
                        addition = 0;
                        break;

                    case 'W':
                        addition = 2;
                        break;

                    case 'X':
                        addition = 10;
                        break;

                    case 'Y':
                        addition = 9;
                        break;

                    case 'Z':
                        addition = 4;
                        break;

                    case '0':
                        addition = 6;
                        break;

                    case '1':
                        addition = 2;
                        break;

                    case '2':
                        addition = 3;
                        break;

                    case '3':
                        addition = 4;
                        break;

                    case '4':
                        addition = 0;
                        break;

                    case '5':
                        addition = 11;
                        break;

                    case '6':
                        addition = 3;
                        break;

                    case '7':
                        addition = 1;
                        break;

                    case '8':
                        addition = 7;
                        break;

                    default:
                        addition = 9;
                        break;
                }

                num += addition;

                PrintDebug($"{addition}");

                if (i != Bomb.SerialNumber.Length - 1)
                {
                    PrintDebug(" + ");
                }
            }

            PrintDebugLine("");

            return num;
        }

        private bool HasLetterInSerialNumber(string str)
        {
            foreach (char c in Bomb.SerialNumber)
            {
                if (str.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
