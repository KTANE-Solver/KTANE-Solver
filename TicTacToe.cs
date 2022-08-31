using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class TicTacToe : Module
    {
        private char[,] grid;
        public int currentRow;
        private char targetSymbol;
        private int[] targetCoordiantes;
        private int tilesCovered;

        public TicTacToe(Bomb bomb, StreamWriter logFileWriter, char[,] grid)
            : base(bomb, logFileWriter, "Tic Tac Toe")
        {
            tilesCovered = 0;
            this.grid = grid;
        }

        public void FindStartingRow()
        {
            List<int> row = new List<int>();

            if (Bomb.LastDigit % 2 == 0)
            {
                row.AddRange(new int[] { 5, 6, 7, 8, 9 });
                PrintDebugLine("Last digit of serial number is even");
                DebugLinesForCurrentRow(row);
            }
            else
            {
                row.AddRange(new int[] { 1, 2, 3, 4 });
                PrintDebugLine("Last digit of serial number is odd");
                DebugLinesForCurrentRow(row);
            }

            if (Bomb.Parallel.Visible)
            {
                PrintDebugLine("A pararrel port is present");
                for (int i = row.Count - 1; i > -1; i--)
                {
                    if (row[i] % 2 == 1)
                    {
                        row.RemoveAt(i);
                    }
                }

                DebugLinesForCurrentRow(row);
            }
            else
            {
                PrintDebugLine("No pararrel port is present");
                for (int i = row.Count - 1; i > -1; i--)
                {
                    if (row[i] % 2 == 0)
                    {
                        row.RemoveAt(i);
                    }
                }

                DebugLinesForCurrentRow(row);
            }

            if (Bomb.UnlitIndicatorsList.Count > Bomb.LitIndicatorsList.Count)
            {
                PrintDebugLine("More unlit indicators than lit");

                currentRow = row.Min();
            }
            else if (Bomb.LitIndicatorsList.Count > Bomb.UnlitIndicatorsList.Count)
            {
                PrintDebugLine("More lit indicators than unlit");

                currentRow = row.Max();
            }
            else
            {
                PrintDebugLine("Even number of lit and unlit indicators");

                currentRow = row.Sum() / row.Count();
            }

            PrintDebugLine($"Starting Row: {currentRow}\n");
        }

        private int[] FindSymbolToPlace(char symbol)
        {
            PrintDebugLine($"Current Row is now {currentRow}\n");
            targetSymbol = PlaceSymbol(symbol);

            PrintDebugLine($"Attemting to place {symbol} at {targetSymbol}");

            targetCoordiantes = NumberIsInGrid(targetSymbol);

            while (targetCoordiantes.Length == 1)
            {
                PrintDebugLine($"{targetSymbol} was not found in grid\n");

                currentRow++;

                currentRow %= 10;

                if (currentRow == 0)
                {
                    currentRow++;
                }

                PrintDebugLine($"Starting row is now {currentRow}");

                targetSymbol = PlaceSymbol(symbol);

                PrintDebugLine($"Attemting to place {symbol} at {targetSymbol}");

                targetCoordiantes = NumberIsInGrid(targetSymbol);
            }

            grid[targetCoordiantes[0], targetCoordiantes[1]] = symbol;

            PrintDebugLine("Checking for Tic Tac Toe...\n");

            if (!MakesTicTacToe(targetCoordiantes[0], targetCoordiantes[1]))
            {
                PrintDebugLine($"No Tic Tac Toe was made. Placing {symbol} at {targetSymbol}");
                currentRow++;
                return new int[] { targetCoordiantes[0], targetCoordiantes[1] };
            }

            grid[targetCoordiantes[0], targetCoordiantes[1]] = targetSymbol;

            return new int[] { -1 };
        }

        public int[] Solve(char symbol)
        {
            int[] answer = FindSymbolToPlace(symbol);

            if (answer.Length == 2)
            {
                return answer;
            }

            PrintDebugLine(
                $"{symbol} made Tic Tac at {targetSymbol}. Changing symbol to {GetOppositeSymbol(symbol)}"
            );

            symbol = GetOppositeSymbol(symbol);

            answer = FindSymbolToPlace(symbol);

            if (answer.Length == 2)
            {
                ShowAnswer("Pass", true);
            }
            else
            {
                ShowAnswer("Dobule Pass", true);
            }

            return answer;
        }

        public void SetSymbolPosition(int rowNum, int colNum, char target)
        {
            PrintDebugLine($"Setting {rowNum + 1},{colNum + 1} to {target}\n");
            grid[rowNum, colNum] = target;
        }

        private char GetOppositeSymbol(char symbol)
        {
            if (symbol == 'X')
            {
                return 'O';
            }

            return 'X';
        }

        public char PlaceSymbol(char symbol)
        {
            int xCount = XCount();
            int oCount = OCount();

            if (xCount > oCount)
            {
                if (symbol == 'X')
                {
                    switch (currentRow)
                    {
                        case 1:
                            return '9';

                        case 2:
                            return '5';

                        case 3:
                            return '7';

                        case 4:
                            return '4';

                        case 5:
                            return '1';

                        case 6:
                            return '8';

                        case 7:
                            return '6';

                        case 8:
                            return '2';

                        default:
                            return '3';
                    }
                }
                else
                {
                    switch (currentRow)
                    {
                        case 1:
                            return '3';

                        case 2:
                            return '6';

                        case 3:
                            return '8';

                        case 4:
                            return '5';

                        case 5:
                            return '4';

                        case 6:
                            return '7';

                        case 7:
                            return '1';

                        case 8:
                            return '2';

                        default:
                            return '9';
                    }
                }
            }
            else if (xCount == oCount)
            {
                if (symbol == 'X')
                {
                    switch (currentRow)
                    {
                        case 1:
                            return '3';

                        case 2:
                            return '6';

                        case 3:
                            return '2';

                        case 4:
                            return '7';

                        case 5:
                            return '1';

                        case 6:
                            return '5';

                        case 7:
                            return '8';

                        case 8:
                            return '9';

                        default:
                            return '4';
                    }
                }
                else
                {
                    switch (currentRow)
                    {
                        case 1:
                            return '9';

                        case 2:
                            return '7';

                        case 3:
                            return '1';

                        case 4:
                            return '8';

                        case 5:
                            return '6';

                        case 6:
                            return '2';

                        case 7:
                            return '4';

                        case 8:
                            return '5';

                        default:
                            return '3';
                    }
                }
            }
            else
            {
                {
                    if (symbol == 'X')
                    {
                        switch (currentRow)
                        {
                            case 1:
                                return '8';

                            case 2:
                                return '1';

                            case 3:
                                return '5';

                            case 4:
                                return '9';

                            case 5:
                                return '7';

                            case 6:
                                return '4';

                            case 7:
                                return '3';

                            case 8:
                                return '2';

                            default:
                                return '6';
                        }
                    }
                    else
                    {
                        switch (currentRow)
                        {
                            case 1:
                                return '1';

                            case 2:
                                return '2';

                            case 3:
                                return '8';

                            case 4:
                                return '6';

                            case 5:
                                return '3';

                            case 6:
                                return '4';

                            case 7:
                                return '9';

                            case 8:
                                return '5';

                            default:
                                return '7';
                        }
                    }
                }
            }
        }

        private int XCount()
        {
            int sum = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == 'X')
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private int OCount()
        {
            int sum = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == 'O')
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private int[] NumberIsInGrid(char target)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { -1 };
        }

        public bool MakesTicTacToe(int rowNum, int colNum)
        {
            PrintGrid();

            List<char> row = new List<char>();
            int xCount;
            int oCount;
            //horizontal
            row.Clear();
            for (int j = 0; j < 3; j++)
            {
                row.Add(grid[rowNum, j]);
            }

            xCount = row.Where(x => x.Equals('X')).Count();
            oCount = row.Where(x => x.Equals('O')).Count();

            if (oCount == 3 || xCount == 3)
            {
                return true;
            }

            //vertical
            row.Clear();
            for (int j = 0; j < 3; j++)
            {
                row.Add(grid[j, colNum]);
            }

            xCount = row.Where(x => x.Equals('X')).Count();
            oCount = row.Where(x => x.Equals('O')).Count();

            if (oCount == 3 || xCount == 3)
            {
                return true;
            }

            //diagnoal

            row.Clear();

            if (rowNum == colNum)
            {
                for (int i = 0; i < 3; i++)
                {
                    row.Add(grid[i, i]);
                }

                xCount = row.Where(x => x.Equals('X')).Count();
                oCount = row.Where(x => x.Equals('O')).Count();

                if (oCount == 3 || xCount == 3)
                {
                    return true;
                }
            }

            row.Clear();

            if (rowNum + colNum == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    row.Add(grid[i, 2 - i]);
                }

                xCount = row.Where(x => x.Equals('X')).Count();
                oCount = row.Where(x => x.Equals('O')).Count();

                if (oCount == 3 || xCount == 3)
                {
                    return true;
                }
            }

            return false;
        }

        public void PrintGrid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PrintDebug(grid[i, j] + " ");
                }

                PrintDebugLine("");
            }

            PrintDebugLine("");
        }

        public bool SolvedModule(bool doublePass)
        {
            int symbolCount = XCount() + OCount();

            if (doublePass)
            {
                return symbolCount == 9 || symbolCount == 8;
            }

            return symbolCount == 9;
        }

        private void DebugLinesForCurrentRow(List<int> row)
        {
            PrintDebugLine($"Possbile numbers for row: " + string.Join(", ", row) + "\n");
        }
    }
}
