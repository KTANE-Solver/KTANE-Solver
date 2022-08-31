using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the Rubik cube module
    /// </summary>
    class RubikCube : Module
    {
        //all the possible colors of each face
        public enum Face
        {
            YELLOW,
            BLUE,
            RED,
            GREEN,
            ORANGE,
            WHITE,
        }

        //all the six faces
        public Face upFace;
        public Face leftFace;
        public Face frontFace;
        public Face rightFace;
        public Face bottomFace;

        List<String> directions = new List<string>();

        public RubikCube(
            Face upFace,
            Face leftFace,
            Face frontFace,
            Face rightFace,
            Face bottomFace,
            Bomb bomb,
            StreamWriter logFileWriter
        ) : base(bomb, logFileWriter, "Rubik Cube")
        {
            this.upFace = upFace;
            this.leftFace = leftFace;
            this.frontFace = frontFace;
            this.rightFace = rightFace;
            this.bottomFace = bottomFace;

            directions = new List<string>();
        }

        /// <summary>
        /// Getting the moves required to solve the module
        /// </summary>
        public void Solve()
        {
            PrintDebugLine($"Up: {upFace}");
            PrintDebugLine($"Left: {leftFace}");
            PrintDebugLine($"Front: {frontFace}");
            PrintDebugLine($"Right: {rightFace}");
            PrintDebugLine($"Bottom: {bottomFace}\n");

            //figure out if we're getting both moves

            //If the R face is red, green or blue, take both moves for each serial number character in order.
            bool bothMoves =
                rightFace == Face.RED || rightFace == Face.GREEN || rightFace == Face.BLUE;

            //used just in case moves need to be sperated
            List<String> directions2 = new List<string>();

            for (int i = 0; i < Bomb.SerialNumber.Length; i++)
            {
                //skip bottom face's num
                if (i == (int)bottomFace)
                {
                    PrintDebugLine($"Skipping index {i} ({Bomb.SerialNumber[i]})\n");
                    continue;
                }

                //get the starting character
                char startingChar = Bomb.SerialNumber[i];

                PrintDebugLine($"Starting character: {startingChar}");

                //find the starting row
                int startingRow = GetStartingRow(startingChar);

                PrintDebugLine($"Starting Row: {startingRow}");

                //find which face belongs to the starting row
                Face startingFace = GetStartingFace(startingChar);

                PrintDebugLine($"Starting Face: {startingFace}");

                //find the row to take the moves from

                int endingRow = (startingRow + (int)startingFace + 1) % 12;

                PrintDebugLine($"Ending Row: {endingRow}");

                //find the respective moves
                string firstMove = "";
                string secondMove = "";

                switch (endingRow)
                {
                    case 0:

                        firstMove = "L'";
                        secondMove = "F'";
                        break;
                    case 1:
                        firstMove = "D'";
                        secondMove = "U'";
                        break;
                    case 2:
                        firstMove = "U";
                        secondMove = "B'";
                        break;
                    case 3:
                        firstMove = "F";
                        secondMove = "B";
                        break;
                    case 4:
                        firstMove = "L";
                        secondMove = "D";
                        break;
                    case 5:
                        firstMove = "R'";
                        secondMove = "U";
                        break;
                    case 6:
                        firstMove = "U'";
                        secondMove = "F";
                        break;
                    case 7:
                        firstMove = "B'";
                        secondMove = "L'";
                        break;
                    case 8:
                        firstMove = "B";
                        secondMove = "R";
                        break;
                    case 9:
                        firstMove = "D";
                        secondMove = "L";
                        break;
                    case 10:
                        firstMove = "R";
                        secondMove = "D'";
                        break;
                    case 11:
                        firstMove = "F'";
                        secondMove = "R'";
                        break;
                }

                PrintDebugLine($"First Move: {firstMove}");
                PrintDebugLine($"Second Move: {secondMove}");

                //eiter add the moves next to each other
                if (bothMoves)
                {
                    directions.Add(firstMove);
                    directions.Add(secondMove);

                    PrintDebugLine($"Directions are now: [{string.Join(", ", directions)}]\n");
                }
                //or put them in sperate lists
                else
                {
                    directions.Add(firstMove);
                    directions2.Add(secondMove);

                    PrintDebugLine($"Direction 1 is now: [{string.Join(", ", directions)}]\n");
                    PrintDebugLine($"Direction 2 is now: [{string.Join(", ", directions2)}]\n");
                }
            }

            //if moves were taken seperatly, then combine them now
            if (!bothMoves)
            {
                PrintDebugLine(
                    $"Directions are now: [{string.Join(", ", directions)}, {string.Join(", ", directions2)}]\n"
                );

                directions.AddRange(directions2);
            }

            //If the R face is red or yellow, change the first five moves to their opposites.
            if (rightFace == Face.RED || rightFace == Face.YELLOW)
            {
                PrintDebugLine(
                    $"Right face is {rightFace}, changing first five moves to their opposite\n"
                );

                for (int i = 0; i < 5; i++)
                {
                    directions[i] = GetOppositeMove(directions[i]);
                }

                PrintDebugLine($"Directions are now: [{string.Join(", ", directions)}]\n");
            }
            //If the R face is green or white, reverse the order of all the moves.
            else if (rightFace == Face.GREEN || rightFace == Face.WHITE)
            {
                PrintDebugLine($"Right face is {rightFace}, reversing direction order\n");

                directions.Reverse();

                PrintDebugLine($"Directions are now: [{string.Join(", ", directions)}]\n");
            }

            //updating the directions so unnessary moves aren't made

            PrintDebugLine($"Removing unnessary moves\n");

            for (int i = directions.Count - 1; i > 0; i--)
            {
                if (MovesAreOpposite(directions[i], directions[i - 1]))
                {
                    directions.RemoveAt(i);
                    directions.RemoveAt(i - 1);
                    i--;
                }
            }

            String answer = string.Join(", ", directions);

            PrintDebugLine($"Answer is [{answer}]\n");

            ShowAnswer(answer, true);
        }

        /// <summary>
        /// Tells if two moves are the opposite of each other
        /// </summary>
        /// <returns></returns>
        private bool MovesAreOpposite(String move1, String move2)
        {
            if (move1.Length == move2.Length)
            {
                return false;
            }
            //return if move1 is the same as move2 with a '
            if (move1.Length == 2)
            {
                return move2 == "" + move1[0];
            }

            //return if move1 is the same as move2 without the '
            return move1 == "" + move2[0];
        }

        private String GetOppositeMove(String move)
        {
            if (move.Length == 2)
            {
                return "" + move[0];
            }

            return move + "'";
        }

        public int GetStartingRow(char character)
        {
            switch (character)
            {
                case '0':
                case '1':
                case '2':
                    return 0;

                case '3':
                case '4':
                case '5':
                    return 1;

                case '6':
                case '7':
                case '8':
                    return 2;

                case '9':
                case 'A':
                case 'B':
                    return 3;

                case 'C':
                case 'D':
                case 'E':
                    return 4;

                case 'F':
                case 'G':
                case 'H':
                    return 5;

                case 'I':
                case 'J':
                case 'K':
                    return 6;

                case 'L':
                case 'M':
                case 'N':
                    return 7;

                case 'O':
                case 'P':
                case 'Q':
                    return 8;

                case 'R':
                case 'S':
                case 'T':
                    return 9;

                case 'U':
                case 'V':
                case 'W':
                    return 10;

                default:
                    return 11;
            }
        }

        public Face GetStartingFace(char character)
        {
            switch (character)
            {
                case '0':
                case '3':
                case '6':
                case '9':
                case 'C':
                case 'F':
                case 'I':
                case 'L':
                case 'O':
                case 'R':
                case 'U':
                case 'X':
                    return upFace;

                case '1':
                case '4':
                case '7':
                case 'A':
                case 'D':
                case 'G':
                case 'J':
                case 'M':
                case 'P':
                case 'S':
                case 'V':
                case 'Y':
                    return leftFace;

                default:
                    return frontFace;
            }
        }
    }
}
