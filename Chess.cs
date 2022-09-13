using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date: 4/30/21
    /// Purpose: Solves the chess module
    /// </summary>
    public class Chess : Module
    {
        //FIELDS

        //a 6x6 2d char array that represents the board
        private char[,] board;

        private List<Piece> pieceList;

        //CONSTRUCTOR

        //will take 6 positions for the pieces, the bomb, and the streamwriter
        public Chess(
            string position1,
            string position2,
            string position3,
            string position4,
            string position5,
            string position6,
            Bomb bomb,
            StreamWriter logWriterFile
        ) : base(bomb, logWriterFile, "Chess")
        {
            board = new char[6, 6];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    board[i, j] = '.';
                }
            }

            //determine all the piece locations

            List<string> positionList = new List<string>()
            {
                position1.ToLower(),
                position2.ToLower(),
                position3.ToLower(),
                position4.ToLower(),
                position5.ToLower(),
                position6.ToLower()
            };

            pieceList = new List<Piece>();

            foreach (string position in positionList)
            {
                pieceList.Add(new Piece(ConvertLocation(position)));
            }

            //determine and place all the pieces
            DetermineandPlacePiece(4);
            DetermineandPlacePiece(5);
            DetermineandPlacePiece(1);
            DetermineandPlacePiece(2);
            DetermineandPlacePiece(3);
            DetermineandPlacePiece(6);

            //print information about all the pieces
            for (int i = 0; i < 6; i++)
            {
                PrintPiece(i + 1, pieceList[i].PieceChar, positionList[i]);
            }

            PrintDebugLine("");
        }

        //METHODS

        private void DetermineandPlacePiece(int pieceNum)
        {
            Piece piece = pieceList[pieceNum - 1];

            piece.PieceChar = DeterminePiece(piece.PieceLocation, pieceNum);
            PlacePiece(piece);
        }

        /// <summary>
        /// Solves the module
        /// </summary>
        public string Solve(bool debug)
        {
            //sees which tiles are covered by the pieces

            PrintBoard();
            for (int i = 0; i < pieceList.Count; i++)
            {
                Piece piece = pieceList[i];

                PrintDebugLine("Piece " + (i + 1));
                CoverArea(piece);
                PrintBoard();
            }

            List<string> answerList = new List<string>();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (board[i, j] == '.')
                    {
                        answerList.Add("" + i + j);
                    }
                }
            }

            //convert the location back to the module

            string answer = "";

            if (answerList.Count > 1)
            {
                answer = "Unable to find answer. Mutiple possible answers found:\n\n";
                List<string> newAnwerList = new List<string>();

                foreach (string a in answerList)
                {
                    newAnwerList.Add(
                        $"{(char)(int.Parse("" + a[1]) + 97)}{Math.Abs(6 - int.Parse("" + a[0]))}"
                    );
                }

                answer += string.Join(", ", newAnwerList);
            }
            else if (answerList.Count == 0)
            {
                answer = "Couldn't find answer";
            }
            else
            {
                answer =
                    $"{(char)(int.Parse("" + answerList[0][1]) + 97)}{Math.Abs(6 - int.Parse("" + answerList[0][0]))}";
            }

            if (!debug)
            { 
                ShowAnswer(answer, true);
            }

            return answer.ToUpper();
        }

        /// <summary>
        /// Will tell which piece is what
        /// </summary>
        /// <param name="position">the position of the piece on the board</param>
        /// <param name="pieceNum">the number order of the piece</param>
        private char DeterminePiece(int[] position, int pieceNum)
        {
            switch (pieceNum)
            {
                case 1:
                    //Occupied by a king if Position #5 is occupied by a queen.
                    //Otherwise, the field is occupied by a bishop.

                    return pieceList[4].PieceChar == 'Q' ? 'K' : 'B';

                case 2:
                    //Occupied by a rook if the last digit of the serial number is odd.
                    //Otherwise, the field is occupied by a knight.

                    return Bomb.LastDigit % 2 == 1 ? 'R' : 'N';

                case 3:
                    //Occupied by a queen if there are less than two rooks on the board.
                    //Otherwise, the field is occupied by a king.

                    return PieceCount('R') < 2 ? 'Q' : 'K';

                case 4:
                    return 'R';

                case 5:
                    //Occupied by a queen if the field is white.
                    //Otherwise, the field is occupied by a rook.

                    return position[0] % 2 == position[1] % 2 ? 'Q' : 'R';

                default:
                    //Occupied by a queen if there are no other queens on the board.
                    //Otherwise, occupied by a knight if there are no other knights on the board.
                    //Otherwise, the field is occupied by a bishop.

                    return pieceList[4].PieceChar != 'Q' && pieceList[2].PieceChar != 'Q'
                        ? 'Q'
                        : pieceList[1].PieceChar != 'N'
                            ? 'N'
                            : 'B';
            }
        }

        /// <summary>
        /// tells how many of a certain peice is on the baord
        /// </summary>
        /// <param name="piece">the name of the peice</param>
        /// <returns>the number of peices</returns>
        private int PieceCount(char piece)
        {
            int num = 0;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (board[i, j] == piece)
                        num++;
                }
            }

            return num;
        }

        /// <summary>
        /// Converts the location of the peice so it can be placed on the board
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private int[] ConvertLocation(string location)
        {
            return new int[] { Math.Abs((int)location[1] - 54), (int)location[0] - 97 };
        }

        //a method that places all the pieces on the board
        private void PlacePiece(Piece piece)
        {
            board[piece.PieceLocation[0], piece.PieceLocation[1]] = piece.PieceChar;
        }

        /// <summary>
        /// Tells if a tile is a piece
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool IsPiece(int row, int column)
        {
            return Regex.IsMatch("" + board[row, column], @"[K,R,Q,B,N]");
        }

        //a method that will tell where a king will go

        /// <summary>
        /// Tells where the king can go
        /// </summary>
        /// <param name="position">the position of the king</param>
        private void KingArea(int[] position)
        {
            for (int row = -1; row < 2; row++)
            {
                for (int column = -1; column < 2; column++)
                {
                    int newRow = position[0] + row;
                    int newColumn = position[1] + column;

                    if (ValidCoordinate(newRow, newColumn))
                    {
                        CoverTile(newRow, newColumn);
                    }
                }
            }
        }

        /// <summary>
        ///  Tells where the rook can go
        /// </summary>
        /// <param name="position">the position of the rook</param>
        private void RookArea(int[] position)
        {
            //go up

            int newRow = 1;

            while (
                ValidCoordinate(position[0] - newRow, position[1])
                && !IsPiece(position[0] - newRow, position[1])
            )
            {
                board[position[0] - newRow, position[1]] = '*';
                newRow++;
            }

            //go down

            newRow = 1;

            while (
                ValidCoordinate(position[0] + newRow, position[1])
                && !IsPiece(position[0] + newRow, position[1])
            )
            {
                board[position[0] + newRow, position[1]] = '*';
                newRow++;
            }

            //go left

            int newColumn = 1;

            while (
                ValidCoordinate(position[0], position[1] - newColumn)
                && !IsPiece(position[0], position[1] - newColumn)
            )
            {
                board[position[0], position[1] - newColumn] = '*';
                newColumn++;
            }

            //go right

            newColumn = 1;

            while (
                ValidCoordinate(position[0], position[1] + newColumn)
                && !IsPiece(position[0], position[1] + newColumn)
            )
            {
                board[position[0], position[1] + newColumn] = '*';
                newColumn++;
            }
        }

        /// <summary>
        /// Tells where a knight will go
        /// </summary>
        /// <param name="position"></param>
        private void KnightArea(int[] position)
        {
            //left twice and up once
            if (ValidCoordinate(position[0] - 1, position[1] - 2))
                CoverTile(position[0] - 1, position[1] - 2);

            //left twice and down once
            if (ValidCoordinate(position[0] + 1, position[1] - 2))
                CoverTile(position[0] + 1, position[1] - 2);

            //right twice and up once
            if (ValidCoordinate(position[0] - 1, position[1] + 2))
                CoverTile(position[0] - 1, position[1] + 2);

            //right twice and down once
            if (ValidCoordinate(position[0] + 1, position[1] + 2))
                CoverTile(position[0] + 1, position[1] + 2);

            //up twice and left once
            if (ValidCoordinate(position[0] - 2, position[1] - 1))
                CoverTile(position[0] - 2, position[1] - 1);

            //up twice and right once
            if (ValidCoordinate(position[0] - 2, position[1] + 1))
                CoverTile(position[0] - 2, position[1] + 1);

            //down twice and left once
            if (ValidCoordinate(position[0] + 2, position[1] - 1))
                CoverTile(position[0] + 2, position[1] - 1);

            //down twice and right once
            if (ValidCoordinate(position[0] + 2, position[1] + 1))
                CoverTile(position[0] + 2, position[1] + 1);
        }

        //a method that will

        /// <summary>
        /// Tells where a bishop will go
        /// </summary>
        /// <param name="position"></param>
        private void BishopArea(int[] position)
        {
            int newRow = 1;
            int newColumn = 1;

            //top left
            while (ValidCoordinate(position[0] - newRow, position[1] - newColumn) && !IsPiece(position[0] - newRow, position[1] - newColumn))
            {
                CoverTile(position[0] - newRow, position[1] - newColumn);
                newColumn++;
                newRow++;
            }

            //top right

            newRow = 1;
            newColumn = 1;

            while (ValidCoordinate(position[0] - newRow, position[1] + newColumn) && !IsPiece(position[0] - newRow, position[1] + newColumn))
            {
                CoverTile(position[0] - newRow, position[1] + newColumn);
                newColumn++;
                newRow++;
            }

            //bottom left

            newRow = 1;
            newColumn = 1;

            while (ValidCoordinate(position[0] + newRow, position[1] - newColumn) && !IsPiece(position[0] + newRow, position[1] - newColumn))
            {
                CoverTile(position[0] + newRow, position[1] - newColumn);
                newColumn++;
                newRow++;
            }

            //bottom right

            newRow = 1;
            newColumn = 1;

            while (ValidCoordinate(position[0] + newRow, position[1] + newColumn) && !IsPiece(position[0] + newRow, position[1] + newColumn))
            {
                CoverTile(position[0] + newRow, position[1] + newColumn);
                newColumn++;
                newRow++;
            }
        }

        /// <summary>
        /// Tells where a queen will go
        /// </summary>
        /// <param name="position"></param>
        private void QueenArea(int[] position)
        {
            RookArea(position);
            BishopArea(position);
        }

        /// <summary>
        /// Covers the tiles depending on the piece
        /// </summary>
        /// <param name="piece">the piece itself</param>
        /// <param name="position">the position of the piece</param>
        private void CoverArea(Piece piece)
        {
            switch (piece.PieceChar)
            {
                case 'K':
                    KingArea(piece.PieceLocation);
                    break;

                case 'N':
                    KnightArea(piece.PieceLocation);
                    break;

                case 'R':
                    RookArea(piece.PieceLocation);
                    break;

                case 'B':
                    BishopArea(piece.PieceLocation);
                    break;

                case 'Q':
                    QueenArea(piece.PieceLocation);
                    break;
            }
        }

        //a method that will tell if a position is considered valid
        private bool ValidCoordinate(int row, int column)
        {
            return row >= 0 && row <= 5 && column >= 0 && column <= 5;
        }

        /// <summary>
        /// Prints the board
        /// </summary>
        private void PrintBoard()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    PrintDebug(board[i, j] + " ");
                }

                PrintDebugLine("");
            }

            PrintDebugLine("");
        }

        /// <summary>
        /// Prints information about the piece
        /// </summary>
        /// <param name="num"></param>
        /// <param name="piece"></param>
        private void PrintPiece(int num, char piece, string locattion)
        {
            PrintDebugLine($"{num}. Location {locattion}: {piece}");
        }

        /// <summary>
        /// Covers a tile if it's blank
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private void CoverTile(int row, int column)
        {
            if (board[row, column] == '.')
                board[row, column] = '*';
        }

        private class Piece
        {
            //tells what the piece is
            public char PieceChar { get; set; }

            //the location for piece 1
            public int[] PieceLocation { get; }

            public Piece(int[] pieceLocation)
            {
                PieceLocation = pieceLocation;
            }
        }
    }
}
