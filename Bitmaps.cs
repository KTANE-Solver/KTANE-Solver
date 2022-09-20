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
    /// Purpose: Solves the bitmaps module
    /// </summary>
    public class Bitmaps : Module
    {
        private bool[,] grid;
        private Quadrant topLeftQuadrant;
        private Quadrant topRightQuadrant;
        private Quadrant bottomLeftQuadrant;
        private Quadrant bottomRightQuadrant;

        public Bitmaps(bool[,] grid, Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Bitmaps")
        {
            this.grid = grid;

            bool[,] topLeft = new bool[4, 4];
            bool[,] topRight = new bool[4, 4];
            bool[,] bottomLeft = new bool[4, 4];
            bool[,] bottomRight = new bool[4, 4];

            //fill quadrants
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    topLeft[row, column] = grid[row, column];
                    topRight[row, column] = grid[row, column + 4];
                    bottomLeft[row, column] = grid[row + 4, column];
                    bottomRight[row, column] = grid[row + 4, column + 4];
                }
            }

            topLeftQuadrant = new Quadrant(topLeft);
            topRightQuadrant = new Quadrant(topRight);
            bottomLeftQuadrant = new Quadrant(bottomLeft);
            bottomRightQuadrant = new Quadrant(bottomRight);
        }

        public int Solve(bool debug)
        {
            PrintGrid();

            int answer = -1;
            int ruleNumber = Bomb.LastDigit;
            bool condition = false;

            while (!condition)
            {
                switch (ruleNumber)
                {
                    case 0:
                        //If exactly one quadrant has 5 or fewer white pixels,
                        condition = Rule0();
                        break;

                    case 1:
                        //If there are exactly as many mostly-white quadrants as there are lit indicators,
                        condition = Rule1();
                        break;

                    case 2:
                        //If exactly one row or column is completely white or completely black,
                        condition = Rule2();
                        break;

                    case 3:
                        //If there are fewer mostly-white quadrants than mostly-black quadrants,
                        condition = Rule3();
                        break;

                    case 4:
                        //If the entire bitmap has 36 or more white pixels,
                        condition = Rule4();
                        break;

                    case 5:
                        //If there are more mostly - white quadrants than mostly - black quadrants,
                        condition = Rule5();
                        break;

                    case 6:
                        //If exactly one quadrant has 5 or fewer black pixels,
                        condition = Rule6();
                        break;

                    case 7:
                        //If there are exactly as many mostly-black quadrants as there are unlit indicators,
                        condition = Rule7();
                        break;

                    case 8:
                        //If there is a 3×3 square that is completely white or completely black,
                        condition = Rule8();
                        break;

                    case 9:
                        //If there are exactly as many mostly-white quadrants as mostly-black quadrants,
                        condition = Rule9();
                        break;
                }

                PrintDebugLine($"Rule {ruleNumber}: {condition}\n");

                if (!condition)
                {
                    ruleNumber++;
                    ruleNumber %= 10;
                }
            }

            switch (ruleNumber)
            {
                case 0:

                    //the answer is the number of white pixels in the other 3 quadrants.
                    if (topLeftQuadrant.FiveWhiteOrLess)
                    {
                        answer = topRightQuadrant.WhiteNum;
                        answer += bottomLeftQuadrant.WhiteNum;
                        answer += bottomRightQuadrant.WhiteNum;
                    }
                    else if (topRightQuadrant.FiveWhiteOrLess)
                    {
                        answer = topLeftQuadrant.WhiteNum;
                        answer += bottomLeftQuadrant.WhiteNum;
                        answer += bottomRightQuadrant.WhiteNum;
                    }
                    else if (bottomLeftQuadrant.FiveWhiteOrLess)
                    {
                        answer = topRightQuadrant.WhiteNum;
                        answer += topLeftQuadrant.WhiteNum;
                        answer += bottomRightQuadrant.WhiteNum;
                    }
                    else
                    {
                        answer = topRightQuadrant.WhiteNum;
                        answer += bottomLeftQuadrant.WhiteNum;
                        answer += topLeftQuadrant.WhiteNum;
                    }
                    break;

                case 1:

                    //the answer is the number of batteries
                    answer = Bomb.Battery;
                    break;

                case 2:

                    // the answer is its x-/y-coordinate
                    for (int i = 0; i < 8; i++)
                    {
                        if (RowHasSameColor(i) || ColumnHasSameColor(i))
                        {
                            answer = i + 1;
                            break;
                        }
                    }
                    break;

                case 3:

                    //the answer is the number of mostly-black quadrants.
                    answer = MostlyBlackQuadrantNum();
                    break;

                case 4:

                    //the answer is the total number of white pixels.
                    answer = WhitePixelNum();
                    break;

                case 5:

                    //the answer is the smallest number of black pixels in any quadrant
                    answer = topLeftQuadrant.BlackNum;

                    if (topRightQuadrant.BlackNum < answer)
                    {
                        answer = topRightQuadrant.BlackNum;
                    }

                    if (bottomLeftQuadrant.BlackNum < answer)
                    {
                        answer = bottomLeftQuadrant.BlackNum;
                    }

                    if (bottomRightQuadrant.BlackNum < answer)
                    {
                        answer = bottomRightQuadrant.BlackNum;
                    }
                    break;

                case 6:
                    //the answer is the number of black pixels in the other 3 quadrants.
                    if (topLeftQuadrant.FiveBlackOrLess)
                    {
                        answer = topRightQuadrant.BlackNum;
                        answer += bottomLeftQuadrant.BlackNum;
                        answer += bottomRightQuadrant.BlackNum;
                    }
                    else if (topRightQuadrant.FiveBlackOrLess)
                    {
                        answer = topLeftQuadrant.BlackNum;
                        answer += bottomLeftQuadrant.BlackNum;
                        answer += bottomRightQuadrant.BlackNum;
                    }
                    else if (bottomLeftQuadrant.FiveBlackOrLess)
                    {
                        answer = topRightQuadrant.BlackNum;
                        answer += topLeftQuadrant.BlackNum;
                        answer += bottomRightQuadrant.BlackNum;
                    }
                    else
                    {
                        answer = topRightQuadrant.BlackNum;
                        answer += bottomLeftQuadrant.BlackNum;
                        answer += topLeftQuadrant.BlackNum;
                    }
                    break;

                case 7:

                    //the answer is the number of ports
                    answer = Bomb.PortNum;
                    break;

                case 8:

                    // the answer is the x-coordinate (starting from 1)
                    // of the center of the first such square in reading order
                    do
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                if (i == 3 && j == 2)
                                {
                                    Console.Write("");
                                }
                                answer = ThreeByThreeSquare(i, j);

                                if (answer != -1)
                                {
                                    break;
                                }
                            }

                            if (answer != -1)
                            {
                                break;
                            }
                        }
                    } while (answer == -1);
                    break;

                case 9:

                    //the answer is the first numeric digit of the serial number
                    answer = Bomb.FirstDigit;
                    break;
            }

            answer %= 4;

            while (answer <= 0)
            {
                answer += 4;
            }

            if (!debug)
            {
                ShowAnswer("Press " + answer, true);
            }

            return answer;
        }

        #region Rules
        /// <summary>
        /// If exactly one quadrant has 5 or fewer white pixels
        /// </summary>
        /// <returns></returns>
        private bool Rule0()
        {
            int fiveWhiteOrLess = 0;

            if (topLeftQuadrant.FiveWhiteOrLess)
            {
                fiveWhiteOrLess++;
            }

            if (topRightQuadrant.FiveWhiteOrLess)
            {
                fiveWhiteOrLess++;
            }

            if (bottomLeftQuadrant.FiveWhiteOrLess)
            {
                fiveWhiteOrLess++;
            }

            if (bottomRightQuadrant.FiveWhiteOrLess)
            {
                fiveWhiteOrLess++;
            }

            return fiveWhiteOrLess == 1;
        }

        /// <summary>
        /// If there are exactly as many mostly - white
        /// quadrants as there are lit indicators
        /// </summary>
        /// <returns></returns>
        private bool Rule1()
        {
            int mostlyWhiteNum = 0;

            if (topLeftQuadrant.MostlyWhite)
            {
                mostlyWhiteNum++;
            }

            if (topRightQuadrant.MostlyWhite)
            {
                mostlyWhiteNum++;
            }

            if (bottomLeftQuadrant.MostlyWhite)
            {
                mostlyWhiteNum++;
            }

            if (bottomRightQuadrant.MostlyWhite)
            {
                mostlyWhiteNum++;
            }

            return mostlyWhiteNum == Bomb.LitIndicatorsList.Count;
        }

        /// <summary>
        /// If exactly one row or column is completely
        /// white or completely black,
        /// </summary>
        /// <returns></returns>
        private bool Rule2()
        {
            for (int i = 0; i < 8; i++)
            {
                if (RowHasSameColor(i) || ColumnHasSameColor(i))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// If there are fewer mostly-white quadrants than
        /// mostly-black quadrants
        /// </summary>
        /// <returns></returns>
        private bool Rule3()
        {
            return MostlyWhiteQuadrantNum() < MostlyBlackQuadrantNum();
        }

        /// <summary>
        /// If the entire bitmap has 36 or more white pixels
        /// </summary>
        /// <returns></returns>
        private bool Rule4()
        {
            return WhitePixelNum() >= 36;
        }

        /// <summary>
        ///If there are more mostly-white quadrants than
        ///mostly-black quadrants
        /// </summary>
        /// <returns></returns>
        private bool Rule5()
        {
            return MostlyWhiteQuadrantNum() > MostlyBlackQuadrantNum();
        }

        /// <summary>
        ///If exactly one quadrant has 5 or fewer black pixels
        /// </summary>
        private bool Rule6()
        {
            int fiveBlackOrLess = 0;

            if (topLeftQuadrant.FiveBlackOrLess)
            {
                fiveBlackOrLess++;
            }

            if (topRightQuadrant.FiveBlackOrLess)
            {
                fiveBlackOrLess++;
            }

            if (bottomLeftQuadrant.FiveBlackOrLess)
            {
                fiveBlackOrLess++;
            }

            if (bottomRightQuadrant.FiveBlackOrLess)
            {
                fiveBlackOrLess++;
            }

            return fiveBlackOrLess == 1;
        }

        /// <summary>
        /// If there are exactly as many mostly-black quadrants
        /// as there are unlit indicators
        /// </summary>
        /// <returns></returns>
        private bool Rule7()
        {
            return MostlyBlackQuadrantNum() == Bomb.UnlitIndicatorsList.Count;
        }

        /// <summary>
        /// If there is a 3×3 square that is
        /// completely white or completely black
        /// </summary>
        /// <returns></returns>
        private bool Rule8()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (ThreeByThreeSquare(i, j) != -1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// If there are exactly as many mostly-white
        /// quadrants as mostly-black quadrants
        /// </summary>
        /// <returns></returns>
        private bool Rule9()
        {
            return MostlyWhiteQuadrantNum() == MostlyBlackQuadrantNum();
        }

        #endregion


        #region Helper Methods
        /// <summary>
        /// Find the three by three square
        /// </summary>
        /// <param name="row">top left row</param>
        /// <param name="column">top left column</param>
        /// <returns>the center x quordinate</returns>
        private int ThreeByThreeSquare(int row, int column)
        {
            bool color = grid[row, column];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (color != grid[i + row, j + column])
                    {
                        return -1;
                    }
                }
            }

            return column + 2;
        }

        private int WhitePixelNum()
        {
            return topLeftQuadrant.WhiteNum
                + topRightQuadrant.WhiteNum
                + bottomLeftQuadrant.WhiteNum
                + bottomRightQuadrant.WhiteNum;
        }

        private int MostlyBlackQuadrantNum()
        {
            int mostlyBlackNum = 0;

            if (topLeftQuadrant.MostlyBlack)
            {
                mostlyBlackNum++;
            }

            if (topRightQuadrant.MostlyBlack)
            {
                mostlyBlackNum++;
            }

            if (bottomLeftQuadrant.MostlyBlack)
            {
                mostlyBlackNum++;
            }

            if (bottomRightQuadrant.MostlyBlack)
            {
                mostlyBlackNum++;
            }

            return mostlyBlackNum;
        }

        private int MostlyWhiteQuadrantNum()
        {
            int mostlyWhiteNum = 0;

            if (topLeftQuadrant.MostlyWhite)
            {
                mostlyWhiteNum++;
            }

            if (topRightQuadrant.MostlyWhite)
            {
                mostlyWhiteNum++;
            }

            if (bottomLeftQuadrant.MostlyWhite)
            {
                mostlyWhiteNum++;
            }

            if (bottomRightQuadrant.MostlyWhite)
            {
                mostlyWhiteNum++;
            }

            return mostlyWhiteNum;
        }

        /// <summary>
        /// Makes sure row is all one color
        /// </summary>
        /// <param name="row">which row</param>
        /// <returns></returns>
        private bool RowHasSameColor(int row)
        {
            bool color = grid[row, 0];

            for (int column = 1; column < 8; column++)
            {
                if (color != grid[row, column])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Makes sure column is all one color
        /// </summary>
        /// <param name="column">which row</param>
        /// <returns></returns>
        private bool ColumnHasSameColor(int column)
        {
            bool color = grid[0, column];

            for (int row = 1; row < 8; row++)
            {
                if (color != grid[row, column])
                {
                    return false;
                }
            }

            return true;
        }

        private void PrintGrid()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (grid[i, j])
                    {
                        PrintDebug("1 ");
                    }
                    else
                    {
                        PrintDebug("0 ");
                    }
                }

                PrintDebugLine("");
            }

            PrintDebugLine("");
        }

        #endregion

        public class Quadrant
        {
            public bool[,] QuadrantGrid { get; }
            public bool MostlyWhite { get; }
            public bool MostlyBlack { get; }
            public int BlackNum { get; }
            public int WhiteNum { get; }
            public bool FiveWhiteOrLess { get; }
            public bool FiveBlackOrLess { get; }

            public Quadrant(bool[,] quadrant)
            {
                this.QuadrantGrid = quadrant;

                WhiteNum = 0;
                WhiteNum = 0;

                foreach (bool b in quadrant)
                {
                    if (b)
                    {
                        WhiteNum++;
                    }
                    else
                    {
                        BlackNum++;
                    }
                }

                MostlyWhite = WhiteNum > BlackNum;
                MostlyBlack = BlackNum > WhiteNum;

                FiveWhiteOrLess = WhiteNum <= 5;
                FiveBlackOrLess = BlackNum <= 5;
            }
        }
    }
}
