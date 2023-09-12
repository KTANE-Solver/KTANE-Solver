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
    /// Purpose: Solves the color math module
    /// </summary>
    public class ColorMath : Module
    {
        Color[] leftColors;

        public Color[] rightColors;

        int leftNumberThousand;
        int leftNumberHundred;
        int leftNumberTen;
        int leftNumberOne;
        int leftNumber;

        int rightNumberThousand;
        int rightNumberHundred;
        int rightNumberTen;
        int rightNumberOne;
        int rightNumber;

        char letter;

        public ColorMath(
            Color[] leftColors,
            Color[] rightColors,
            char letter,
            Bomb bomb,
            StreamWriter logfileWriter
        ) : base(bomb, logfileWriter, "Color Math")
        {
            this.leftColors = leftColors;
            this.rightColors = rightColors;

            this.letter = letter;
        }

        private void GetLeftNumbers()
        {
            leftNumberThousand = GetLeftSideNumber(1, leftColors[0]);
            leftNumberHundred = GetLeftSideNumber(2, leftColors[1]);
            leftNumberTen = GetLeftSideNumber(3, leftColors[2]);
            leftNumberOne = GetLeftSideNumber(4, leftColors[3]);

            leftNumber =
                leftNumberThousand * 1000
                + leftNumberHundred * 100
                + leftNumberTen * 10
                + leftNumberOne;

            for (int i = 0; i < 4; i++)
            {
                PrintDebugLine($"Left Color {i + 1}: {leftColors[i]}");
            }

            PrintDebugLine("");

            PrintDebugLine($"Left Number: {leftNumber}\n");
        }

        private void GetRightNumbers()
        {
            //if the letter is red, use edgework

            if (rightColors == null)
            {
                PrintDebugLine($"Number of batteries: {Bomb.Battery}\n");

                rightNumberThousand = GetRightSideNumber(1);
                rightNumberHundred = GetRightSideNumber(2);
                rightNumberTen = GetRightSideNumber(3);
                rightNumberOne = GetRightSideNumber(4);
            }
            else
            {
                rightNumberThousand = GetRightSideNumber(1, rightColors[0]);
                rightNumberHundred = GetRightSideNumber(2, rightColors[1]);
                rightNumberTen = GetRightSideNumber(3, rightColors[2]);
                rightNumberOne = GetRightSideNumber(4, rightColors[3]);

                for (int i = 0; i < 4; i++)
                {
                    PrintDebugLine($"Right Color {i + 1}: {rightColors[i]}");
                }

                PrintDebugLine("");
            }

            rightNumber =
                rightNumberThousand * 1000
                + rightNumberHundred * 100
                + rightNumberTen * 10
                + rightNumberOne;

            PrintDebugLine($"Right Number: {rightNumber}\n");
        }

        public string Solve(bool debug)
        {
            GetLeftNumbers();
            GetRightNumbers();

            string color = rightColors == null ? "Red" : "Green";

            PrintDebugLine($"{color} {letter}\n");

            int answer;

            char operation;
            switch (letter)
            {
                case 'A':
                    operation = '+';
                    answer = leftNumber + rightNumber;
                    break;

                case 'M':
                    operation = '*';
                    answer = leftNumber * rightNumber;
                    break;

                case 'D':
                    operation = '/';
                    answer = leftNumber / rightNumber;
                    break;

                default:
                    operation = '-';
                    answer = leftNumber - rightNumber;
                    break;
            }

            answer = Math.Abs(answer);

            answer %= 10000;

            PrintDebugLine($"{leftNumber} {operation} {rightNumber} = {answer}\n");

            string colorAnswer = ConvertAnswerToColor(answer);

            colorAnswer = colorAnswer.Replace("[", "").Replace("]", "").Replace("Color ", "");

            if (!debug)
            {
                ShowAnswer(colorAnswer, true);
            }

            return colorAnswer;
        }

        public int GetLeftSideNumber(int place, Color color)
        {
            if (place == 1)
            {
                if (Color.Blue == color)
                {
                    return 6;
                }

                if (Color.Green == color)
                {
                    return 1;
                }

                if (Color.Purple == color)
                {
                    return 2;
                }

                if (Color.Yellow == color)
                {
                    return 4;
                }

                if (Color.White == color)
                {
                    return 9;
                }

                if (Color.Magenta == color)
                {
                    return 0;
                }

                if (Color.Red == color)
                {
                    return 8;
                }

                if (Color.Orange == color)
                {
                    return 5;
                }

                if (Color.Gray == color)
                {
                    return 3;
                }

                return 7;
            }
            else if (place == 2)
            {
                {
                    if (Color.Blue == color)
                    {
                        return 8;
                    }

                    if (Color.Green == color)
                    {
                        return 1;
                    }

                    if (Color.Purple == color)
                    {
                        return 9;
                    }

                    if (Color.Yellow == color)
                    {
                        return 4;
                    }

                    if (Color.White == color)
                    {
                        return 3;
                    }

                    if (Color.Magenta == color)
                    {
                        return 6;
                    }

                    if (Color.Red == color)
                    {
                        return 0;
                    }

                    if (Color.Orange == color)
                    {
                        return 5;
                    }

                    if (Color.Gray == color)
                    {
                        return 7;
                    }

                    return 2;
                }
            }
            else if (place == 3)
            {
                {
                    if (Color.Blue == color)
                    {
                        return 4;
                    }

                    if (Color.Green == color)
                    {
                        return 1;
                    }

                    if (Color.Purple == color)
                    {
                        return 9;
                    }

                    if (Color.Yellow == color)
                    {
                        return 7;
                    }

                    if (Color.White == color)
                    {
                        return 0;
                    }

                    if (Color.Magenta == color)
                    {
                        return 2;
                    }

                    if (Color.Red == color)
                    {
                        return 5;
                    }

                    if (Color.Orange == color)
                    {
                        return 3;
                    }

                    if (Color.Gray == color)
                    {
                        return 8;
                    }

                    return 6;
                }
            }
            else
            {
                {
                    if (Color.Blue == color)
                    {
                        return 6;
                    }

                    if (Color.Green == color)
                    {
                        return 8;
                    }

                    if (Color.Purple == color)
                    {
                        return 7;
                    }

                    if (Color.Yellow == color)
                    {
                        return 5;
                    }

                    if (Color.White == color)
                    {
                        return 4;
                    }

                    if (Color.Magenta == color)
                    {
                        return 9;
                    }

                    if (Color.Red == color)
                    {
                        return 1;
                    }

                    if (Color.Orange == color)
                    {
                        return 3;
                    }

                    if (Color.Gray == color)
                    {
                        return 0;
                    }

                    return 2;
                }
            }
        }

        public int GetRightSideNumber(int place, Color color)
        {
            if (place == 1)
            {
                if (Color.Blue == color)
                {
                    return 0;
                }

                if (Color.Green == color)
                {
                    return 6;
                }

                if (Color.Purple == color)
                {
                    return 5;
                }

                if (Color.Yellow == color)
                {
                    return 4;
                }

                if (Color.White == color)
                {
                    return 3;
                }

                if (Color.Magenta == color)
                {
                    return 7;
                }

                if (Color.Red == color)
                {
                    return 9;
                }

                if (Color.Orange == color)
                {
                    return 8;
                }

                if (Color.Gray == color)
                {
                    return 1;
                }

                return 2;
            }
            else if (place == 2)
            {
                if (Color.Blue == color)
                {
                    return 2;
                }

                if (Color.Green == color)
                {
                    return 9;
                }

                if (Color.Purple == color)
                {
                    return 8;
                }

                if (Color.Yellow == color)
                {
                    return 0;
                }

                if (Color.White == color)
                {
                    return 5;
                }

                if (Color.Magenta == color)
                {
                    return 3;
                }

                if (Color.Red == color)
                {
                    return 4;
                }

                if (Color.Orange == color)
                {
                    return 7;
                }

                if (Color.Gray == color)
                {
                    return 1;
                }

                return 6;
            }
            else if (place == 3)
            {
                if (Color.Blue == color)
                {
                    return 5;
                }

                if (Color.Green == color)
                {
                    return 0;
                }

                if (Color.Purple == color)
                {
                    return 6;
                }

                if (Color.Yellow == color)
                {
                    return 4;
                }

                if (Color.White == color)
                {
                    return 2;
                }

                if (Color.Magenta == color)
                {
                    return 7;
                }

                if (Color.Red == color)
                {
                    return 9;
                }

                if (Color.Orange == color)
                {
                    return 3;
                }

                if (Color.Gray == color)
                {
                    return 8;
                }

                return 1;
            }
            else
            {
                if (Color.Blue == color)
                {
                    return 5;
                }

                if (Color.Green == color)
                {
                    return 4;
                }

                if (Color.Purple == color)
                {
                    return 2;
                }

                if (Color.Yellow == color)
                {
                    return 9;
                }

                if (Color.White == color)
                {
                    return 8;
                }

                if (Color.Magenta == color)
                {
                    return 6;
                }

                if (Color.Red == color)
                {
                    return 7;
                }

                if (Color.Orange == color)
                {
                    return 1;
                }

                if (Color.Gray == color)
                {
                    return 3;
                }

                return 0;
            }
        }

        public int GetRightSideNumber(int place)
        {
            switch (Bomb.Battery)
            {
                case 0:
                case 1:

                    if (place == 1)
                    {
                        return Bomb.FirstDigit;
                    }
                    else if (place == 2)
                    {
                        return Bomb.UnlitIndicatorsList.Count;
                    }
                    else if (place == 3)
                    {
                        return 9;
                    }

                    return Bomb.RJNum;

                case 2:
                case 3:

                    if (place == 1)
                    {
                        return 0;
                    }
                    else if (place == 2)
                    {
                        return Bomb.PSNum;
                    }
                    else if (place == 3)
                    {
                        return Bomb.LetterNum;
                    }

                    return Bomb.LastDigit;

                case 4:
                case 5:

                    if (place == 1)
                    {
                        return Bomb.VowelNum;
                    }
                    else if (place == 2)
                    {
                        return Bomb.BatteryHolder;
                    }
                    else if (place == 3)
                    {
                        return Bomb.RcaNum;
                    }

                    return 4;

                default:

                    if (place == 1)
                    {
                        return Bomb.DviNum;
                    }
                    else if (place == 2)
                    {
                        return 5;
                    }
                    else if (place == 3)
                    {
                        return Bomb.SerialNumber.Length - (Bomb.VowelNum + Bomb.DigitNum);
                    }

                    return Bomb.LitIndicatorsList.Count;
            }
        }

        private string ConvertAnswerToColor(int answer)
        {
            int thousandPlace = answer / 1000;
            int hundredPlace = (answer % 1000) / 100;
            int tenPlace = (answer % 100) / 10;
            int onePlace = answer % 10;

            List<Color> answerList = new List<Color>();

            switch (thousandPlace)
            {
                case 0:
                    answerList.Add(Color.Gray);
                    break;

                case 1:
                    answerList.Add(Color.Green);
                    break;

                case 2:
                    answerList.Add(Color.Orange);
                    break;

                case 3:
                    answerList.Add(Color.White);
                    break;

                case 4:
                    answerList.Add(Color.Purple);
                    break;

                case 5:
                    answerList.Add(Color.Blue);
                    break;

                case 6:
                    answerList.Add(Color.Magenta);
                    break;

                case 7:
                    answerList.Add(Color.Black);
                    break;

                case 8:
                    answerList.Add(Color.Yellow);
                    break;

                case 9:
                    answerList.Add(Color.Red);
                    break;
            }

            switch (hundredPlace)
            {
                case 0:
                    answerList.Add(Color.Blue);
                    break;

                case 1:
                    answerList.Add(Color.Green);
                    break;

                case 2:
                    answerList.Add(Color.Black);
                    break;

                case 3:
                    answerList.Add(Color.Purple);
                    break;

                case 4:
                    answerList.Add(Color.Magenta);
                    break;

                case 5:
                    answerList.Add(Color.Red);
                    break;

                case 6:
                    answerList.Add(Color.Gray);
                    break;

                case 7:
                    answerList.Add(Color.Yellow);
                    break;

                case 8:
                    answerList.Add(Color.Orange);
                    break;

                case 9:
                    answerList.Add(Color.White);
                    break;
            }

            switch (tenPlace)
            {
                case 0:
                    answerList.Add(Color.Magenta);
                    break;

                case 1:
                    answerList.Add(Color.Yellow);
                    break;

                case 2:
                    answerList.Add(Color.Blue);
                    break;

                case 3:
                    answerList.Add(Color.Gray);
                    break;

                case 4:
                    answerList.Add(Color.Red);
                    break;

                case 5:
                    answerList.Add(Color.Black);
                    break;

                case 6:
                    answerList.Add(Color.Green);
                    break;

                case 7:
                    answerList.Add(Color.Purple);
                    break;

                case 8:
                    answerList.Add(Color.Orange);
                    break;

                case 9:
                    answerList.Add(Color.White);
                    break;
            }

            switch (onePlace)
            {
                case 0:
                    answerList.Add(Color.Gray);
                    break;

                case 1:
                    answerList.Add(Color.Blue);
                    break;

                case 2:
                    answerList.Add(Color.Purple);
                    break;

                case 3:
                    answerList.Add(Color.Red);
                    break;

                case 4:
                    answerList.Add(Color.Yellow);
                    break;

                case 5:
                    answerList.Add(Color.Magenta);
                    break;

                case 6:
                    answerList.Add(Color.Black);
                    break;

                case 7:
                    answerList.Add(Color.Orange);
                    break;

                case 8:
                    answerList.Add(Color.Green);
                    break;

                case 9:
                    answerList.Add(Color.White);
                    break;
            }

            return string.Join(", ", answerList);
        }
    }
}
