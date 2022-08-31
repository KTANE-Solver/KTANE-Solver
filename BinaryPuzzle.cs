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
    /// Date: 3/15/21
    /// Purpose: Solves Binary Puzzle Module
    /// </summary>
    class BinaryPuzzle : Module
    {
        //============================PROPERTIES============================

        //represents the puzzle itself
        public char[,] Grid;

        //============================CONSTRUCTORS============================
        public BinaryPuzzle(char[,] grid, StreamWriter logFileWriter)
            : base(null, logFileWriter, "Binary Puzzle")
        {
            Grid = grid;
        }

        //============================METHONDS============================

        /// <summary>
        /// Solves the Binary Puzzle module
        /// </summary>
        /// <returns>the answer to the puzzle</returns>
        public char[,] Solve()
        {
            PrintDebugLine("Original Grid\n");

            PrintGrid(Grid);

            MakeMoves(Grid, false, null);

            //if the current grid is not complete, the start guessing

            if (!PuzzledFilled(Grid) || !ValidPuzzle(Grid))
            {
                //a copy to the gird
                char[,] tempGrid0 = new char[6, 6];
                char[,] tempGrid1 = new char[6, 6];

                //copying the grid
                for (int row = 0; row < 6; row++)
                {
                    for (int column = 0; column < 6; column++)
                    {
                        if (Grid[row, column] == '0')
                        {
                            tempGrid0[row, column] = '0';
                            tempGrid1[row, column] = '0';
                        }
                        else if (Grid[row, column] == '1')
                        {
                            tempGrid0[row, column] = '1';
                            tempGrid1[row, column] = '1';
                        }
                        else
                        {
                            tempGrid0[row, column] = '-';
                            tempGrid1[row, column] = '-';
                        }
                    }
                }

                //guess with the first blank being 0
                if (!GuessGrid(tempGrid0, '0'))
                {
                    //if that does't work, have the first blank be 1
                    if (GuessGrid(tempGrid1, '1'))
                    {
                        return Grid;
                    }
                    //if this statement is reached, something is wrong
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return Grid;
                }
            }

            return Grid;
        }

        /// <summary>
        /// Uses logic to make moves
        /// </summary>
        /// <param name="grid">the grid that will be analyzed</param>
        /// <param name="isGuessing">if the program has started guessing</param>
        /// <param name="filledTiles">Tiles that have been filled after a guess has been made</param>
        private void MakeMoves(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            PrintDebugLine("Make Moves\n");

            bool moveMade;

            do
            {
                moveMade = BlockUp(grid, isGuessing, filledTiles);

                bool possibleMoveMade = BlockDown(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillComparableColumn(Grid, false, null);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = BlockLeft(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = BlockRight(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = BlockMiddleRow(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = BlockMiddleColumn(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillRow(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillColumn(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillSecondAndFifthColumn(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FilledSecondAndFifthRow(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillFirstCornerColumn(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillFirstTileRow(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillSixthTileRow(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillSixthTileColumn(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillComparableColumn(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillComparableRow(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FilledFirstTileColumn(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FilledFirstCornerRow(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillSixthCornerColumn(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }

                possibleMoveMade = FillSixthCornerRow(grid, isGuessing, filledTiles);

                if (!moveMade && possibleMoveMade)
                {
                    moveMade = true;
                }
            } while (moveMade);

            PrintGrid(grid);
        }

        /// <summary>
        /// Checks to see if the puzzle is solvable
        /// </summary>
        /// <param name="grid">the puzzle that'll be check</param>
        /// <returns>true if the puzzle doesn't have any mistakes</returns>
        private bool ValidPuzzle(char[,] grid)
        {
            for (int i = 0; i < 6; i++)
            {
                //can't have 3 of the same number in a row or column
                if (ThreeNumInARow(grid))
                {
                    return false;
                }

                if (ThreeNumInAColumn(grid))
                {
                    return false;
                }

                //has to have 3 1's and 0's in each column
                if (NumCoulmnCount(grid, '1', i) != 3)
                {
                    return false;
                }

                //has to have 3 1's and 0's in each row
                if (NumRowCount(grid, '1', i) != 3)
                {
                    PrintDebugLine($"More than 3 1 in row {i}\n");
                    return false;
                }

                //has to have 3 1's and 0's in each column
                if (NumCoulmnCount(grid, '0', i) != 3)
                {
                    PrintDebugLine($"More than 3 0 in column {i}\n");
                    return false;
                }

                //has to have 3 1's and 0's in each row
                if (NumRowCount(grid, '0', i) != 3)
                {
                    PrintDebugLine($"More than 3 0 in row {i}\n");
                    return false;
                }

                for (int j = 0; j < 6; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    //can't have duplicate rows or columns
                    if (SameColumn(grid, i, j))
                    {
                        PrintDebugLine($"Same column {i} and {j}\n");
                        return false;
                    }

                    if (SameRow(grid, i, j))
                    {
                        PrintDebugLine($"Same row {i} and {j}\n");
                        return false;
                    }
                }
            }

            PrintDebugLine($"Valid Puzzle\n");
            return true;
        }

        /// <summary>
        /// Guesses one of the tiles and figures out what is correct
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="startingNum">the number that placed is the tile</param>
        /// <returns>true if the puzzle </returns>
        private bool GuessGrid(char[,] grid, char startingNum)
        {
            //check if there are any blank spaces

            Tile blankSpace = new Tile(-1, -1, '-');

            //find a blank space
            //find a blank space
            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 6; column++)
                {
                    if (grid[row, column] == '-')
                    {
                        blankSpace = new Tile(row, column, startingNum);
                        break;
                    }
                }

                if (blankSpace.row != -1 && blankSpace.column != -1)
                {
                    break;
                }
            }

            //if there isn't a blank space, return false
            if (blankSpace.row == -1 || blankSpace.column == -1)
            {
                return false;
            }

            //fill in the space with the starting num
            grid[blankSpace.row, blankSpace.column] = blankSpace.str;

            PrintDebugLine("Guess\n");

            PrintGrid(grid);

            //see if adding this space causes problems
            for (int i = 0; i < 6; i++)
            {
                if (NumRowCount(grid, '0', i) > 3)
                {
                    PrintDebugLine($"Counted more than 3 0 in row {i}\n");
                    return false;
                }

                if (NumRowCount(grid, '1', i) > 3)
                {
                    PrintDebugLine($"Counted more than 3 1 in row {i}\n");
                    return false;
                }

                if (NumCoulmnCount(grid, '0', i) > 3)
                {
                    PrintDebugLine($"Counted more than 3 0 in column {i}\n");
                    return false;
                }

                if (NumCoulmnCount(grid, '1', i) > 3)
                {
                    PrintDebugLine($"Counted more than 3 1 in column {i}\n");
                    return false;
                }

                if (ThreeNumInARow(grid))
                {
                    PrintDebugLine("Three numbers in a row\n");
                    return false;
                }

                if (ThreeNumInAColumn(grid))
                {
                    PrintDebugLine("Three numbers in a column\n");
                    return false;
                }

                for (int j = 0; j < 6; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (SameRow(grid, i, j))
                    {
                        PrintDebugLine($"Same row. {i} and {j}\n");
                        return false;
                    }

                    if (SameColumn(grid, i, j))
                    {
                        PrintDebugLine($"Same column. {i} and {j}\n");
                        return false;
                    }
                }
            }

            //a list of all the tiles that were filled because of logic
            List<Tile> filledTiles = new List<Tile>();

            //if it doesn't then see if blocking/filling is possible
            MakeMoves(grid, true, filledTiles);

            //if it's not filled or not valid, then return guessGrid with the next blank being 0
            if (!PuzzledFilled(grid) || !ValidPuzzle(grid))
            {
                //if that doesn't work then return guessGrid with the first blank being 1
                if (!GuessGrid(grid, '0'))
                {
                    char blankSpaceNumber = grid[blankSpace.row, blankSpace.column];

                    grid[blankSpace.row, blankSpace.column] = '-';

                    //get rid of all the filled tiles via logic
                    foreach (Tile filledTile in filledTiles)
                    {
                        grid[filledTile.row, filledTile.column] = '-';
                    }

                    if (blankSpaceNumber == '1')
                    {
                        return false;
                    }

                    //if that doesn't work, make this space blank and return false
                    if (!GuessGrid(grid, '1'))
                    {
                        grid[blankSpace.row, blankSpace.column] = '-';

                        //get rid of all the filled tiles via logic
                        foreach (Tile filledTile in filledTiles)
                        {
                            grid[filledTile.row, filledTile.column] = '-';
                        }
                        return false;
                    }
                    else
                    {
                        Grid = grid;
                        return true;
                    }
                }
                else
                {
                    Grid = grid;
                    return true;
                }
            }

            //if everything worked, then have this grid as the real one
            Grid = grid;
            return true;
        }

        /// <summary>
        /// Checks to see if there are any blanks in the puzzle
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <returns>true if the puzzle is filled</returns>
        private bool PuzzledFilled(char[,] grid)
        {
            foreach (char character in grid)
            {
                if (character == '-')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks to see if two rows are exactly the same
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="row1">one of the rows in the puzzle</param>
        /// <param name="row2">the other row in the puzzle</param>
        /// <returns>true if both rows are the same</returns>
        private bool SameRow(char[,] grid, int row1, int row2)
        {
            if (!RowFilled(grid, row1) || !RowFilled(grid, row2))
            {
                return false;
            }

            for (int column = 0; column < 6; column++)
            {
                if (!(grid[row1, column] == grid[row2, column]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks to see if two columns are exactly the same
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="row1">one of the columns in the puzzle</param>
        /// <param name="row2">the other column in the puzzle</param>
        /// <returns>true if both columns are the same</returns>
        private bool SameColumn(char[,] grid, int column1, int column2)
        {
            if (!ColumnFilled(grid, column1) || !ColumnFilled(grid, column2))
            {
                return false;
            }

            for (int row = 0; row < 6; row++)
            {
                if (!(grid[row, column2] == grid[row, column1]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///
        /// Will block 3 in a rows
        ///
        ///         -                     0
        ///         1                     1
        ///         1      will become    1
        ///         -                     -
        ///         -                     -
        ///         -                     -
        ///
        /// </summary>
        /// <param name="grid">the grid that is being checked</param>
        /// <param name="isGuessing">tells if the program is checking</param>
        /// <param name="filledTiles">tiles that are filled via guess</param>
        /// <returns>true of blocking occured at least once</returns>
        private bool BlockUp(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            //tells whether block has occured or not
            bool blocked = false;

            //if this block is blank and the block below this block and the one below that block is the same number,
            //this block is the opposite number
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 6; column++)
                {
                    if (
                        !IsFilled(grid[row, column])
                        && IsFilled(grid[row + 1, column])
                        && grid[row + 1, column] == grid[row + 2, column]
                    )
                    {
                        grid[row, column] = GetOppositeNumber(grid[row + 1, column]);

                        if (isGuessing)
                            filledTiles.Add(new Tile(row, column, grid[row, column]));

                        blocked = true;
                    }
                }
            }

            return blocked;
        }

        /// <summary>
        ///a method that may block two of the same number to the right
        ///will return true if said blocking happens
        ///
        ///
        ///    - 1 1 - - - will become - 1 1 0 - -
        ///
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="isGuessing"></param>
        /// <param name="filledTiles"></param>
        /// <returns></returns>
        private bool BlockRight(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            //tells whether block has occured or not
            bool blocked = false;

            //can't block if the column is less than 3
            for (int row = 0; row < 6; row++)
            {
                for (int column = 2; column < 6; column++)
                {
                    //if this block is blank and the block to the right of this block and the one to the right of that block
                    //is the same number, this block is the opposite number
                    if (
                        grid[row, column] == ('-')
                        && IsFilled(grid[row, column - 1])
                        && grid[row, column - 1] == grid[row, column - 2]
                    )
                    {
                        grid[row, column] = GetOppositeNumber(grid[row, column - 1]);

                        if (isGuessing)
                        {
                            filledTiles.Add(new Tile(row, column, grid[row, column]));
                        }
                        blocked = true;
                    }
                }
            }
            return blocked;
        }

        /// <summary>
        /// Fills a row with the opposite number if there are three of the same number
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if row has been filled</returns>
        private bool FillRow(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            //tells if this method did anything
            bool filled = false;

            for (int row = 0; row < 6; row++)
            {
                if (!RowFilled(grid, row) && NumRowCount(grid, '1', row) == 3)
                {
                    for (int column = 0; column < 6; column++)
                    {
                        if (!IsFilled(grid[row, column]))
                        {
                            grid[row, column] = '0';

                            if (isGuessing)
                            {
                                filledTiles.Add(new Tile(row, column, grid[row, column]));
                            }
                        }
                    }

                    filled = true;
                }
                else if (!RowFilled(grid, row) && NumRowCount(grid, '0', row) == 3)
                {
                    for (int column = 0; column < 6; column++)
                    {
                        if (!IsFilled(grid[row, column]))
                        {
                            grid[row, column] = '1';

                            if (isGuessing)
                            {
                                filledTiles.Add(new Tile(row, column, grid[row, column]));
                            }
                        }
                    }

                    filled = true;
                }
            }

            return filled;
        }

        /// <summary>
        /// Fills a column with the opposite number if there are three of the same number
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if column has been filled</returns>
        private bool FillColumn(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int column = 0; column < 6; column++)
            {
                if (!ColumnFilled(grid, column) && NumCoulmnCount(grid, '1', column) == 3)
                {
                    for (int row = 0; row < 6; row++)
                    {
                        if (!IsFilled(grid[row, column]))
                        {
                            grid[row, column] = '0';

                            if (isGuessing)
                            {
                                filledTiles.Add(new Tile(row, column, grid[row, column]));
                            }

                            filled = true;
                        }
                    }
                }
                else if (!ColumnFilled(grid, column) && NumCoulmnCount(grid, '0', column) == 3)
                {
                    for (int row = 0; row < 6; row++)
                    {
                        if (!IsFilled(grid[row, column]))
                        {
                            grid[row, column] = '1';

                            if (isGuessing)
                            {
                                filledTiles.Add(new Tile(row, column, grid[row, column]));
                            }

                            filled = true;
                        }
                    }
                }
            }

            return filled;
        }

        /// <summary>
        /// Tells how many of a certain char is in a certain row
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="character">the target character</param>
        /// <param name="row">the index row we are looking in</param>
        /// <returns>how many times that charcter was found</returns>
        private int NumRowCount(char[,] grid, char character, int row)
        {
            int num = 0;
            for (int column = 0; column < 6; column++)
            {
                if (grid[row, column] == character)
                {
                    num++;
                }
            }

            return num;
        }

        /// <summary>
        /// Tells how many of a certain char is in a certain column
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="character">the target character</param>
        /// <param name="column">the index column we are looking in</param>
        /// <returns>how many times that charcter was found</returns>
        private int NumCoulmnCount(char[,] grid, char character, int column)
        {
            int num = 0;
            for (int row = 0; row < 6; row++)
            {
                if (grid[row, column] == character)
                {
                    num++;
                }
            }

            return num;
        }

        /// <summary>
        /// Tells if there are 3 numbers in a row
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <returns>true of three munbers are in a row</returns>
        private bool ThreeNumInARow(char[,] grid)
        {
            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    if (
                        IsFilled(grid[row, column])
                        && grid[row, column] == (grid[row, column + 1])
                        && grid[row, column] == (grid[row, column + 2])
                    )
                    {
                        PrintDebugLine($"3 consecutive numbers in row {row}\n");
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Tells if there are 3 numbers in a column
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <returns>true of three munbers are in a column</returns>
        private bool ThreeNumInAColumn(char[,] grid)
        {
            for (int column = 0; column < 6; column++)
            {
                for (int row = 0; row < 4; row++)
                {
                    if (
                        IsFilled(grid[row, column])
                        && grid[row, column] == (grid[row + 1, column])
                        && grid[row, column] == (grid[row + 2, column])
                    )
                    {
                        PrintDebugLine($"3 consecutive numbers in column {column}\n");
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Tells if a row has been filled
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="row">the index of the row</param>
        /// <returns>true if the row doesn't have any blanks</returns>
        private bool RowFilled(char[,] grid, int row)
        {
            for (int column = 0; column < 6; column++)
            {
                if (grid[row, column] == '-')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Tells if a column has been filled
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="column">the index of the column</param>
        /// <returns>true if the column doesn't have any blanks</returns>
        private bool ColumnFilled(char[,] grid, int column)
        {
            for (int row = 0; row < 6; row++)
            {
                if (grid[row, column] == '-')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///a method that may block two of the same number to the left
        ///will return true if said blocking happens
        ///
        ///
        ///    - 1 1 - - - will become 0 1 1 - - -
        ///
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>        ///
        /// <returns>true if was able to block left</returns>
        private bool BlockLeft(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            //tells whether block has occured or not
            bool blocked = false;

            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    //if this block is blank and the block to the left of this block and the one to the left of that block
                    //is the same number, this block is the opposite number
                    if (
                        grid[row, column] == ('-')
                        && IsFilled(grid[row, column + 1])
                        && grid[row, column + 1] == grid[row, column + 2]
                    )
                    {
                        grid[row, column] = GetOppositeNumber(grid[row, column + 1]);

                        if (isGuessing)
                        {
                            filledTiles.Add(new Tile(row, column, grid[row, column]));
                        }

                        blocked = true;
                    }
                }
            }

            return blocked;
        }

        /// <summary>
        /// Attemopts to block a three in a row downwards
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if block downwards was successeful</returns>
        private bool BlockDown(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            //tells whether block has occured or not
            bool blocked = false;

            for (int row = 2; row < 6; row++)
            {
                for (int column = 0; column < 6; column++)
                {
                    if (
                        !IsFilled(grid[row, column])
                        && IsFilled(grid[row - 1, column])
                        && grid[row - 1, column] == grid[row - 2, column]
                    )
                    {
                        grid[row, column] = GetOppositeNumber(grid[row - 1, column]);

                        if (isGuessing)
                            filledTiles.Add(new Tile(row, column, grid[row, column]));

                        blocked = true;
                    }
                }
            }

            return blocked;
        }

        /// <summary>
        /// try to block a three in the row in the middle
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if block middle was successful</returns>
        private bool BlockMiddleRow(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool blocked = false;

            for (int row = 0; row < 6; row++)
            {
                for (int column = 1; column < 5; column++)
                {
                    if (
                        grid[row, column] == '-'
                        && IsFilled(grid[row, column - 1])
                        && grid[row, column - 1] == grid[row, column + 1]
                    )
                    {
                        grid[row, column] = GetOppositeNumber(grid[row, column + 1]);

                        if (isGuessing)
                        {
                            filledTiles.Add(new Tile(row, column, grid[row, column]));
                        }

                        blocked = true;
                    }
                }
            }

            return blocked;
        }

        /// <summary>
        /// try to block a three in the column in the middle
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if block middle was successful</returns>
        private bool BlockMiddleColumn(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool blocked = false;

            for (int row = 1; row < 5; row++)
            {
                for (int column = 0; column < 6; column++)
                {
                    if (
                        grid[row, column] == '-'
                        && IsFilled(grid[row - 1, column])
                        && grid[row - 1, column] == grid[row + 1, column]
                    )
                    {
                        grid[row, column] = GetOppositeNumber(grid[row + 1, column]);

                        if (isGuessing)
                        {
                            filledTiles.Add(new Tile(row, column, grid[row, column]));
                        }

                        blocked = true;
                    }
                }
            }

            return blocked;
        }

        /// <summary>
        /// if either the second or fifth tile if blank and the first and sixth tile is the same number,
        /// the second or fifth tile is the opposite number
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if blocking was successful</returns>
        private bool FillSecondAndFifthColumn(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int column = 0; column < 6; column++)
            {
                if (
                    (!IsFilled(grid[1, column]) || !IsFilled(grid[4, column]))
                    && IsFilled(grid[0, column])
                    && grid[0, column] == (grid[5, column])
                )
                {
                    if (isGuessing && !IsFilled(grid[1, column]))
                    {
                        filledTiles.Add(new Tile(1, column, grid[1, column]));
                    }

                    if (isGuessing && !IsFilled(grid[4, column]))
                    {
                        filledTiles.Add(new Tile(4, column, grid[1, column]));
                    }

                    grid[1, column] = GetOppositeNumber(grid[0, column]);
                    grid[4, column] = GetOppositeNumber(grid[0, column]);

                    filled = true;
                }
            }
            return filled;
        }

        /// <summary>
        /// 1 - - - - 1 will become 1 0 - - 0 1
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if blocking was successful</returns>
        private bool FilledSecondAndFifthRow(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int row = 0; row < 6; row++)
            {
                //if either the second or fifth tile if blank and the first and sixth tile is the same number,
                //the second or fifth tile is the opposite number
                if (
                    (!IsFilled(grid[row, 1]) || !IsFilled(grid[row, 4]))
                    && IsFilled(grid[row, 0])
                    && grid[row, 5] == (grid[row, 0])
                )
                {
                    if (isGuessing && !IsFilled(grid[row, 1]))
                    {
                        filledTiles.Add(new Tile(row, 1, grid[row, 1]));
                    }

                    if (isGuessing && !IsFilled(grid[row, 4]))
                    {
                        filledTiles.Add(new Tile(row, 4, grid[row, 4]));
                    }

                    grid[row, 1] = GetOppositeNumber(grid[row, 0]);
                    grid[row, 4] = GetOppositeNumber(grid[row, 0]);

                    filled = true;
                }
            }
            return filled;
        }

        /// <summary>
        /// Fills the first tile in a row if the second and sixth one are the same
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if blocking was successful</returns>
        private bool FillFirstTileRow(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int row = 0; row < 6; row++)
            {
                if (
                    !IsFilled(grid[row, 0])
                    && IsFilled(grid[row, 1])
                    && grid[row, 1] == grid[row, 5]
                )
                {
                    grid[row, 0] = GetOppositeNumber(grid[row, 1]);

                    if (isGuessing)
                    {
                        filledTiles.Add(new Tile(row, 0, grid[row, 0]));

                        filled = true;
                    }
                }
            }

            return filled;
        }

        /// <summary>
        /// Fills the first tile in a column if the second and sixth one are the same
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if blocking was successful</returns>
        private bool FilledFirstTileColumn(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int column = 0; column < 6; column++)
            {
                if (
                    !IsFilled(grid[0, column])
                    && IsFilled(grid[1, column])
                    && grid[1, column] == grid[5, column]
                )
                {
                    grid[0, column] = GetOppositeNumber(grid[1, column]);

                    if (isGuessing)
                    {
                        filledTiles.Add(new Tile(0, column, grid[0, column]));

                        filled = true;
                    }
                }
            }

            return filled;
        }

        /// <summary>
        /// Fill sixth tile in a row if the first and fifth one are the same number
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if blocking was successful</returns>
        private bool FillSixthTileRow(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int row = 0; row < 6; row++)
            {
                if (
                    !IsFilled(grid[row, 5])
                    && IsFilled(grid[row, 0])
                    && grid[row, 0] == grid[row, 4]
                )
                {
                    grid[row, 5] = GetOppositeNumber(grid[row, 0]);

                    if (isGuessing)
                    {
                        filledTiles.Add(new Tile(row, 5, grid[row, 5]));

                        filled = true;
                    }
                }
            }

            return filled;
        }

        /// <summary>
        /// Fill sixth tile in a column if the first and fifth one are the same number
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if blocking was successful</returns>
        private bool FillSixthTileColumn(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int column = 0; column < 6; column++)
            {
                if (
                    !IsFilled(grid[5, column])
                    && IsFilled(grid[0, column])
                    && grid[0, column] == grid[4, column]
                )
                {
                    grid[5, column] = GetOppositeNumber(grid[0, column]);

                    if (isGuessing)
                    {
                        filledTiles.Add(new Tile(5, column, grid[5, column]));

                        filled = true;
                    }
                }
            }

            return filled;
        }

        /// <summary>
        /// if the first tile is blank and the fifth and sixth tile is the same number,
        /// the first tile is the opposite number (in a column)
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if blocking was successful</returns>
        private bool FillFirstCornerColumn(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int column = 0; column < 6; column++)

                if (
                    !IsFilled(grid[0, column])
                    && IsFilled(grid[4, column])
                    && grid[4, column] == (grid[5, column])
                )
                {
                    grid[0, column] = GetOppositeNumber(grid[4, column]);

                    if (isGuessing)
                    {
                        filledTiles.Add(new Tile(0, column, grid[0, column]));
                    }

                    filled = true;
                }
            return filled;
        }

        /// <summary>
        /// if the first tile is blank and the fifth and sixth tile is the same number,
        /// the first tile is the opposite number (in a row)
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if blocking was successful</returns>
        private bool FilledFirstCornerRow(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int row = 0; row < 6; row++)
                //if the sixth tile is blank and the first and second tile is the same number,
                //the first tile is the opposite number
                if (
                    !IsFilled(grid[row, 0])
                    && IsFilled(grid[row, 4])
                    && grid[row, 4] == (grid[row, 5])
                )
                {
                    grid[row, 0] = GetOppositeNumber(grid[row, 4]);

                    if (isGuessing)
                    {
                        filledTiles.Add(new Tile(row, 0, grid[row, 0]));
                    }

                    filled = true;
                }
            return filled;
        }

        /// <summary>
        /// Fills in one row based on the information of another one
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if filling was successful</returns>
        private bool FillComparableRow(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int currentRow = 0; currentRow < 6; currentRow++)
            {
                //seeing if there are two 1's or 0's in the current row
                bool hasTwo1s = NumRowCount(grid, '1', currentRow) == 2;
                bool hasTwo0s = NumRowCount(grid, '0', currentRow) == 2;

                if (!hasTwo1s && !hasTwo0s)
                {
                    continue;
                }

                //finding the index of those numbers
                if (hasTwo0s)
                {
                    int first0Index = -1;
                    int second0Index = -1;

                    for (int column = 0; column < 6; column++)
                    {
                        if (grid[currentRow, column] == '0')
                        {
                            if (first0Index == -1)
                            {
                                first0Index = column;
                            }
                            else
                            {
                                second0Index = column;
                                break;
                            }
                        }
                    }

                    //if there is a complete row, find if that has to same positioning of 0s
                    for (int completeRow = 0; completeRow < 6; completeRow++)
                    {
                        if (completeRow == currentRow)
                        {
                            continue;
                        }

                        if (
                            RowFilled(grid, completeRow)
                            && grid[completeRow, first0Index] == (grid[currentRow, first0Index])
                            && grid[completeRow, second0Index] == (grid[currentRow, second0Index])
                        )
                        {
                            //find the index of the third 0 and replace that index in the current row with 1
                            for (int column = 0; column < 6; column++)
                            {
                                if (first0Index == column || column == second0Index)
                                {
                                    continue;
                                }

                                if (
                                    grid[completeRow, column] == '0'
                                    && grid[currentRow, column] == '-'
                                )
                                {
                                    grid[currentRow, column] = '1';

                                    if (isGuessing)
                                    {
                                        filledTiles.Add(new Tile(currentRow, column, '1'));
                                    }

                                    filled = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (hasTwo1s)
                {
                    int first1Index = -1;
                    int second1Index = -1;

                    for (int column = 0; column < 6; column++)
                    {
                        if (grid[currentRow, column] == ('1'))
                        {
                            if (first1Index == -1)
                            {
                                first1Index = column;
                            }
                            else
                            {
                                second1Index = column;
                                break;
                            }
                        }
                    }

                    //if there is a complete row, find if that has to same positioning of 0s
                    for (int completeRow = 0; completeRow < 6; completeRow++)
                    {
                        if (completeRow == currentRow)
                        {
                            continue;
                        }

                        if (
                            RowFilled(grid, completeRow)
                            && grid[completeRow, first1Index] == (grid[currentRow, first1Index])
                            && grid[completeRow, second1Index] == (grid[currentRow, second1Index])
                        )
                        {
                            //find the index of the third 0 and replace that index in the current row with 1
                            for (int column = 0; column < 6; column++)
                            {
                                if (first1Index == column || column == second1Index)
                                {
                                    continue;
                                }

                                if (
                                    grid[completeRow, column] == ('1')
                                    && grid[currentRow, column] == ('-')
                                )
                                {
                                    grid[currentRow, column] = '0';

                                    if (isGuessing)
                                    {
                                        filledTiles.Add(
                                            new Tile(currentRow, column, grid[currentRow, column])
                                        );
                                    }
                                    filled = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return filled;
        }

        /// <summary>
        /// Fills in one column based on the information of another one
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if filling was successful</returns>
        private bool FillComparableColumn(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int currentColumn = 0; currentColumn < 6; currentColumn++)
            {
                //seeing if there are two 1's or 0's in the current row
                bool hasTwo1s = NumCoulmnCount(grid, '1', currentColumn) == 2;
                bool hasTwo0s = NumCoulmnCount(grid, '0', currentColumn) == 2;

                if (!hasTwo1s && !hasTwo0s)
                {
                    continue;
                }

                //finding the index of those numbers
                if (hasTwo0s)
                {
                    int first0Index = -1;
                    int second0Index = -1;

                    for (int row = 0; row < 6; row++)
                    {
                        if (grid[row, currentColumn] == '0')
                        {
                            if (first0Index == -1)
                            {
                                first0Index = row;
                            }
                            else
                            {
                                second0Index = row;
                                break;
                            }
                        }
                    }

                    //if there is a complete row, find if that has to same positioning of 0s
                    for (int completeColumn = 0; completeColumn < 6; completeColumn++)
                    {
                        if (completeColumn == currentColumn)
                        {
                            continue;
                        }

                        if (
                            ColumnFilled(grid, completeColumn)
                            && grid[first0Index, completeColumn]
                                == (grid[first0Index, currentColumn])
                            && grid[second0Index, completeColumn]
                                == (grid[second0Index, currentColumn])
                        )
                        {
                            //find the index of the third 0 and replace that index in the current row with 1
                            for (int row = 0; row < 6; row++)
                            {
                                if (first0Index == row || row == second0Index)
                                {
                                    continue;
                                }

                                if (
                                    grid[row, completeColumn] == '0'
                                    && grid[row, currentColumn] == '-'
                                )
                                {
                                    grid[row, currentColumn] = '1';

                                    if (isGuessing)
                                    {
                                        filledTiles.Add(
                                            new Tile(row, currentColumn, grid[row, currentColumn])
                                        );
                                    }

                                    filled = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (hasTwo1s)
                {
                    int first1Index = -1;
                    int second1Index = -1;

                    for (int row = 0; row < 6; row++)
                    {
                        if (grid[row, currentColumn] == '1')
                        {
                            if (first1Index == -1)
                            {
                                first1Index = row;
                            }
                            else
                            {
                                second1Index = row;
                                break;
                            }
                        }
                    }

                    //if there is a complete row, find if that has to same positioning of 0s
                    for (int completeColumn = 0; completeColumn < 6; completeColumn++)
                    {
                        if (completeColumn == currentColumn)
                        {
                            continue;
                        }

                        if (
                            ColumnFilled(grid, completeColumn)
                            && grid[first1Index, completeColumn]
                                == (grid[first1Index, currentColumn])
                            && grid[second1Index, completeColumn]
                                == (grid[second1Index, currentColumn])
                        )
                        {
                            //find the index of the third 0 and replace that index in the current row with 1
                            for (int row = 0; row < 6; row++)
                            {
                                if (first1Index == row || row == second1Index)
                                {
                                    continue;
                                }

                                if (
                                    grid[row, completeColumn] == '1'
                                    && grid[row, currentColumn] == '-'
                                )
                                {
                                    grid[row, currentColumn] = '0';

                                    if (isGuessing)
                                    {
                                        filledTiles.Add(
                                            new Tile(row, currentColumn, grid[row, currentColumn])
                                        );
                                    }

                                    filled = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return filled;
        }

        /// <summary>
        /// Fills 6th tile if first and second are the same in a column
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if filling was successful</returns>
        private bool FillSixthCornerColumn(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int column = 0; column < 6; column++)
                //if the first tile is blank and the fifth and sixth tile is the same number,
                //the first tile is the opposite number
                if (
                    !IsFilled(grid[5, column])
                    && IsFilled(grid[0, column])
                    && grid[0, column] == (grid[1, column])
                )
                {
                    grid[5, column] = GetOppositeNumber(grid[0, column]);

                    if (isGuessing)
                    {
                        filledTiles.Add(new Tile(5, column, grid[5, column]));
                    }

                    filled = true;
                }
            return filled;
        }

        /// <summary>
        /// Fills 6th tile if first and second are the same in a row
        /// </summary>
        /// <param name="grid">the puzzle</param>
        /// <param name="isGuessing">if the current puzzle has guessed yet</param>
        /// <param name="filledTiles">the tiles that has been filled since guessing</param>
        /// <returns>true if filling was successful</returns>
        private bool FillSixthCornerRow(char[,] grid, bool isGuessing, List<Tile> filledTiles)
        {
            bool filled = false;

            for (int row = 0; row < 6; row++)
                //if the sixth tile is blank and the first and second tile is the same number,
                //the first tile is the opposite number
                if (
                    !IsFilled(grid[row, 5])
                    && IsFilled(grid[row, 0])
                    && grid[row, 0] == (grid[row, 1])
                )
                {
                    grid[row, 5] = GetOppositeNumber(grid[row, 0]);

                    if (isGuessing)
                    {
                        filledTiles.Add(new Tile(row, 5, grid[row, 5]));
                    }

                    filled = true;
                }
            return filled;
        }

        /// <summary>
        /// Returns 1 if number is 0 otherwise will return 0
        /// </summary>
        private char GetOppositeNumber(char num)
        {
            if (num == '0')
                return '1';

            return '0';
        }

        /// <summary>
        /// Tells wheter or not a tile is filled
        /// </summary>
        /// <param name="num"></param>
        /// <returns>true if the tile isn't blank</returns>
        private static bool IsFilled(char num)
        {
            return num == '0' || num == '1';
        }

        /// <summary>
        /// Prints the grid in a 6x6 array
        /// </summary>
        /// <param name="grid">the puzzle</param>
        private void PrintGrid(char[,] grid)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    PrintDebug(grid[i, j] + " ");
                }

                PrintDebugLine("");
            }

            PrintDebugLine("");
        }

        //a class that represents a tile on the grid
        public class Tile
        {
            public int row;
            public int column;
            public char str;

            public Tile(int row, int column, char str)
            {
                this.row = row;
                this.column = column;
                this.str = str;
            }
        }
    }
}
