using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class MysticSquares : Module
    {
        private List<Puzzle> openList;
        private List<Puzzle> closedList;
        private Puzzle startingPuzzle;

        public MysticSquares(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Mystic Squares")
        {
            openList = new List<Puzzle>();
            closedList = new List<Puzzle>();
        }

        public int FindSkullDebug(int[,] grid)
        {
            int skull;
            int startingNum = grid[1, 1];

            if (grid[1, 1] == 0)
            {
                skull = 7;
            }
            else
            {
                int[] arr;

                int row = -1;
                int col = -1;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (grid[i, j] == 0)
                        {
                            row = i;
                            col = j;

                            break;
                        }
                    }

                    if (row != -1)
                    {
                        break;
                    }
                }

                if (
                    grid[0, 0] == Bomb.LastDigit
                    || grid[1, 1] == Bomb.LastDigit
                    || grid[0, 2] == Bomb.LastDigit
                    || grid[2, 0] == Bomb.LastDigit
                    || grid[2, 2] == Bomb.LastDigit
                )
                {
                    arr = FindSkullRow(startingNum);
                }
                else
                {
                    arr = FindSkullColumn(startingNum);
                }

                foreach (int n in arr)
                {
                    int[] coor = FindSkull(row, col, n, grid);

                    if (coor.Length != 1)
                    {
                        row = coor[0];
                        col = coor[1];
                    }
                }

                skull = grid[row, col];
            }

            return skull;
        }

        public void FindSkull(int[,] grid)
        {
            int skull;
            int startingNum = grid[1, 1];

            if (grid[1, 1] == 0)
            {
                skull = 7;
            }
            else
            {
                int[] arr;

                int row = -1;
                int col = -1;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (grid[i, j] == 0)
                        {
                            row = i;
                            col = j;

                            break;
                        }
                    }

                    if (row != -1)
                    {
                        break;
                    }
                }

                if (
                    Bomb.LastDigit != 0
                    && (
                        grid[0, 0] == Bomb.LastDigit
                        || grid[1, 1] == Bomb.LastDigit
                        || grid[0, 2] == Bomb.LastDigit
                        || grid[2, 0] == Bomb.LastDigit
                        || grid[2, 2] == Bomb.LastDigit
                    )
                )
                {
                    arr = FindSkullRow(startingNum);
                }
                else
                {
                    arr = FindSkullColumn(startingNum);
                }

                foreach (int n in arr)
                {
                    int[] coor = FindSkull(row, col, n, grid);

                    if (coor.Length != 1)
                    {
                        row = coor[0];
                        col = coor[1];
                    }
                }

                skull = grid[row, col];
            }

            ShowAnswer("Skull is under " + skull, true);
        }

        private int[] FindSkullRow(int middle)
        {
            switch (middle)
            {
                case 1:
                    return new int[] { 1, 3, 5, 4, 6, 7, 2, 8 };

                case 2:
                    return new int[] { 2, 5, 7, 3, 8, 1, 4, 6 };

                case 3:
                    return new int[] { 6, 4, 8, 1, 7, 3, 5, 2 };

                case 4:
                    return new int[] { 8, 1, 2, 5, 3, 4, 6, 7 };

                case 5:
                    return new int[] { 3, 2, 6, 8, 4, 5, 7, 1 };

                case 6:
                    return new int[] { 7, 6, 1, 2, 5, 8, 3, 4 };

                case 7:
                    return new int[] { 4, 7, 3, 6, 1, 2, 8, 5 };

                default:
                    return new int[] { 5, 8, 4, 7, 2, 6, 1, 3 };
            }
        }

        private int[] FindSkullColumn(int middle)
        {
            switch (middle)
            {
                case 1:
                    return new int[] { 1, 2, 6, 8, 3, 7, 4, 5 };

                case 2:
                    return new int[] { 3, 5, 4, 1, 2, 6, 7, 8 };

                case 3:
                    return new int[] { 5, 7, 8, 2, 6, 1, 3, 4 };

                case 4:
                    return new int[] { 4, 3, 1, 5, 8, 2, 6, 7 };

                case 5:
                    return new int[] { 6, 8, 7, 3, 4, 5, 1, 2 };

                case 6:
                    return new int[] { 7, 1, 3, 4, 5, 8, 2, 6 };

                case 7:
                    return new int[] { 2, 4, 5, 6, 7, 3, 8, 1 };

                default:
                    return new int[] { 8, 6, 2, 7, 1, 4, 5, 3 };
            }
        }

        private int[] FindSkull(int currentRow, int currentColumn, int nextTarget, int[,] grid)
        {
            int[][] directions = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 0, 1 },
                new int[] { -1, 0 },
                new int[] { 0, -1 },
            };

            foreach (int[] direction in directions)
            {
                try
                {
                    if (grid[currentRow + direction[0], currentColumn + direction[1]] == nextTarget)
                    {
                        return new int[]
                        {
                            currentRow + direction[0],
                            currentColumn + direction[1]
                        };
                    }
                }
                catch
                {
                    continue;
                }
            }

            return new int[] { -1 };
        }

        public void Solve(int[,] startingPuzzle)
        {
            this.startingPuzzle = new Puzzle(startingPuzzle, null);
            this.startingPuzzle.GCost = 0;

            openList.Add(this.startingPuzzle);

            Puzzle currentPuzzle = this.startingPuzzle;

            while (!GoalIsInOpenList())
            {
                List<Puzzle> children = currentPuzzle.GetChildren();

                openList.Remove(currentPuzzle);
                closedList.Add(currentPuzzle);

                foreach (Puzzle p in children)
                {
                    if (p.Parent == null)
                    {
                        p.Parent = currentPuzzle;
                    }
                    else
                    {
                        if (p.GCost > currentPuzzle.GCost + 1)
                        {
                            p.Parent = currentPuzzle;
                        }
                    }

                    openList.Add(p);

                    if (p.Parent == currentPuzzle)
                    {
                        p.GCost = currentPuzzle.GCost + 1;
                    }

                    p.TotalCost = p.GCost + p.HeuristicCost;
                }

                currentPuzzle = Puzzle.FindLowestCostNeighbor(openList);
            }

            //find the goal in the open list
            Puzzle goal = null;
            foreach (Puzzle p in openList)
            {
                int[,] grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };

                if (p.GridsAreEqual(grid))
                {
                    goal = p;
                    break;
                }
            }

            List<Puzzle> puzzleAnswer = new List<Puzzle>();

            Puzzle current = goal;

            do
            {
                puzzleAnswer.Add(current);
                current = current.Parent;
            } while (current != null);

            puzzleAnswer.Reverse();

            List<int[,]> answer = new List<int[,]>();

            foreach (Puzzle p in puzzleAnswer)
            {
                answer.Add(p.Grid);

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        PrintDebug(p.Grid[i, j] + " ");
                    }

                    PrintDebugLine("");
                }

                PrintDebugLine("");
            }

            ShowAnswer(FindAnswer(answer), true);
        }

        public bool GoalIsInOpenList()
        {
            int[,] grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            foreach (Puzzle p in openList)
            {
                if (p.GridsAreEqual(grid))
                {
                    return true;
                }
            }

            return false;
        }

        private string FindAnswer(List<int[,]> list)
        {
            List<string> answer = new List<string>();

            for (int i = 0; i < list.Count - 1; i++)
            {
                int[,] puzzle1 = list[i];
                int[,] puzzle2 = list[i + 1];

                int num = -1;
                //find which number has changed possition

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (
                            num == -1
                            && puzzle1[row, col] != puzzle2[row, col]
                            && puzzle1[row, col] != 0
                        )
                        {
                            num = puzzle1[row, col];
                            break;
                        }
                    }

                    if (num != -1)
                    {
                        break;
                    }
                }

                answer.Add("" + num);
            }

            List<string> brokenUpAnswer = new List<string>();

            for (int i = 0; i < answer.Count / 3; i++)
            {
                string str = "" + answer[i * 3] + answer[i * 3 + 1] + answer[i * 3 + 2];
                brokenUpAnswer.Add(str);
            }

            int difference = answer.Count % 3;

            if (difference != 0)
            {
                string str = "";

                for (int i = difference; i > 0; i--)
                {
                    str += answer[answer.Count - i];
                }

                brokenUpAnswer.Add(str);
            }

            return string.Join("\n", brokenUpAnswer);
        }

        public class Puzzle
        {
            public int[,] Grid { get; }

            public Puzzle Parent;
            List<Puzzle> children;

            public int GCost;
            public int HeuristicCost;
            public int TotalCost;

            public Puzzle(int[,] grid, Puzzle parent)
            {
                this.Grid = grid;
                this.Parent = parent;
                children = new List<Puzzle>();
                FindHeuristicCost();
            }

            //for each tile in the grid, calculate how far away the tile currently is to its goal state (use manhattan distance)
            //add up all costs to get the grid's estimated cost
            private void FindHeuristicCost()
            {
                int cost = 0;

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        int num = Grid[row, col];

                        if (num == 0)
                        {
                            continue;
                        }

                        int goalRow = (num - 1) / 3;
                        int goalCol = (num - 1) % 3;

                        cost += Math.Abs(goalRow - row) + Math.Abs(goalCol - col);
                    }
                }

                HeuristicCost = cost;
            }

            public bool IsSolved()
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        int target = row * 3 + col + 1;

                        if (row == 2 && col == 2)
                        {
                            continue;
                        }

                        if (target != Grid[row, col])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            public bool AreEqual(Puzzle p)
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (Grid[row, col] != p.Grid[row, col])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            public List<Puzzle> GetChildren()
            {
                int zeroRow = -1;
                int zeroCol = -1;

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (Grid[row, col] == 0)
                        {
                            zeroRow = row;
                            zeroCol = col;
                            break;
                        }
                    }

                    if (zeroRow != -1)
                    {
                        break;
                    }
                }

                //create 4 puzzles based on this current puzzle where the zero tile moves is each cardinal directon
                Puzzle upPuzzle = null;
                Puzzle leftPuzzle = null;
                Puzzle rightPuzzle = null;
                Puzzle downPuzzle = null;

                if (zeroRow != 0)
                {
                    //up
                    upPuzzle = new Puzzle(CopyGrid(), this);
                    upPuzzle.SwapIndexWith0(zeroRow - 1, zeroCol, zeroRow, zeroCol);
                }

                if (zeroRow != 2)
                {
                    //down
                    downPuzzle = new Puzzle(CopyGrid(), this);
                    downPuzzle.SwapIndexWith0(zeroRow + 1, zeroCol, zeroRow, zeroCol);
                }

                if (zeroCol != 0)
                {
                    //left
                    leftPuzzle = new Puzzle(CopyGrid(), this);
                    leftPuzzle.SwapIndexWith0(zeroRow, zeroCol - 1, zeroRow, zeroCol);
                }

                if (zeroCol != 2)
                {
                    //right
                    rightPuzzle = new Puzzle(CopyGrid(), this);
                    rightPuzzle.SwapIndexWith0(zeroRow, zeroCol + 1, zeroRow, zeroCol);
                }

                children.AddRange(new Puzzle[] { upPuzzle, downPuzzle, leftPuzzle, rightPuzzle });

                //remove null children
                children.RemoveAll(x => x == null);

                //don't add any children that are the same as this current puzzle's parent
                if (Parent != null)
                {
                    for (int i = children.Count - 1; i > -1; i--)
                    {
                        if (children[i].GridsAreEqual(Parent.Grid))
                        {
                            children.RemoveAt(i);
                        }
                    }
                }

                //fix heuristic costs
                foreach (Puzzle p in children)
                {
                    p.FindHeuristicCost();
                }

                return children;
            }

            public bool GridsAreEqual(int[,] grid)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (grid[i, j] != this.Grid[i, j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            public void SwapIndexWith0(int targetRow, int targetCol, int zeroRow, int zeroCol)
            {
                int targetNum = Grid[targetRow, targetCol];

                Grid[targetRow, targetCol] = 0;

                Grid[zeroRow, zeroCol] = targetNum;
            }

            public int[,] CopyGrid()
            {
                int[,] newGrid = new int[3, 3];

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        newGrid[i, j] = Grid[i, j];
                    }
                }

                return newGrid;
            }

            public static Puzzle FindLowestCostNeighbor(List<Puzzle> children)
            {
                List<int> costList = new List<int>();

                foreach (Puzzle p in children)
                {
                    costList.Add(p.TotalCost);
                }

                int lowestCost = costList.Min();

                Puzzle lowestChild = null;

                foreach (Puzzle p in children)
                {
                    if (p.TotalCost == lowestCost)
                    {
                        lowestChild = p;
                        break;
                    }
                }

                return lowestChild;
            }
        }
    }
}
