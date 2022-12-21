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
    /// Date: 3/6/21
    /// Purpose: Solves the logic module
    /// </summary>
    public class Logic : Module
    {
        //=========FIELDS=========

        //the letters for the top row
        private char[] topLetters;

        //tells if the statement for each top letter is true or false
        private bool[] topStatements;

        //tells if the top statments are the opposite
        private bool[] topNotStatements;

        //the operations for the top evaluation
        private String topFirstOperation;
        private String topSecondOperation;

        //tells if the first two statemetnts should be
        //evalualted first
        private bool topFirstTwoFirst;

        //the letters for the bottom evaluation
        private char[] bottomLetters;

        //tells if the statement for each bottom letter is true or false
        private bool[] bottomStatements;

        //tells if the bottom statments are the opposite
        private bool[] bottomNotStatements;

        //the operations for the top evaluation
        private String bottomFirstOperation;
        private String bottomSecondOperation;

        //tells if the first two statemetnts should be
        //evalualted first
        private bool bottomFirstTwoFirst;

        //=========PROPERTIES=========

        //=========CONSTRUCTORS=========

        /// <summary>
        /// Creates a object that will solve
        /// the logic module
        /// </summary>
        /// <param name="Bomb">used to get the edgework</param>
        /// <param name="topFirstNotStatement">if the top first statement is the opposite</param>
        /// <param name="topFirstLetter">top left letter</param>
        /// <param name="topSecondNotStatement">if the top second statement is the opposite</param>
        /// <param name="topSecondLetter">top middle letter</param>
        /// <param name="topThirdNotStatement">if the top third statement is the opposite</param>
        /// <param name="topThirdLetter">top right letter</param>
        /// <param name="topFirstOperation">top first operation</param>
        /// <param name="topSecondOperation">top second operation</param>
        /// <param name="topFirstTwoFirst">if the top two statments are evaluated first</param>
        /// <param name="bottomFirstLetter">bottom left letter</param>
        /// <param name="bottomSecondLetter">bottom middle letter</param>
        /// <param name="bottomThirdLetter">bottom right letter</param>
        /// <param name="bottomFirstOperation">bottom first operation</param>
        /// <param name="bottomSecondOperation">bottom second operation</param>
        /// <param name="bottomFirstTwoFirst">tells if the first two bottom statements are evaluated first</param>
        ///
        public Logic(
            Bomb Bomb,
            bool topFirstNotStatement,
            char topFirstLetter,
            bool topSecondNotStatement,
            char topSecondLetter,
            bool topThirdNotStatement,
            char topThirdLetter,
            String topFirstOperation,
            String topSecondOperation,
            bool topFirstTwoFirst,
            bool bottomFirstNotStatement,
            char bottomFirstLetter,
            bool bottomSecondNotStatement,
            char bottomSecondLetter,
            bool bottomThirdNotStatement,
            char bottomThirdLetter,
            String bottomFirstOperation,
            String bottomSecondOperation,
            bool bottomFirstTwoFirst,
            StreamWriter LogFileWriter
        ) : base(Bomb, LogFileWriter, "Logic")
        {
            topLetters = new char[3] { topFirstLetter, topSecondLetter, topThirdLetter };
            topNotStatements = new bool[3]
            {
                topFirstNotStatement,
                topSecondNotStatement,
                topThirdNotStatement
            };
            topStatements = new bool[3];

            this.topFirstOperation = topFirstOperation;
            this.topSecondOperation = topSecondOperation;

            this.topFirstTwoFirst = topFirstTwoFirst;

            bottomLetters = new char[3]
            {
                bottomFirstLetter,
                bottomSecondLetter,
                bottomThirdLetter
            };
            bottomNotStatements = new bool[3]
            {
                bottomFirstNotStatement,
                bottomSecondNotStatement,
                bottomThirdNotStatement
            };
            bottomStatements = new bool[3];

            this.bottomFirstOperation = bottomFirstOperation;
            this.bottomSecondOperation = bottomSecondOperation;

            this.bottomFirstTwoFirst = bottomFirstTwoFirst;
        }

        public void Solve()
        {
            //setting the statements
            for (int i = 0; i < 3; i++)
            {
                topStatements[i] = SetStatement(topLetters[i]);
                bottomStatements[i] = SetStatement(bottomLetters[i]);
            }

            PrintTruthTable(1, topLetters, topStatements);
            PrintTruthTable(2, bottomLetters, bottomStatements);

            for (int i = 0; i < 3; i++)
            {
                //updating statements
                topStatements[i] = UpdateStatement(topStatements[i], topNotStatements[i]);
                bottomStatements[i] = UpdateStatement(bottomStatements[i], bottomNotStatements[i]);
            }

            //evaluating the statements

            bool topEvaluation;
            if (topFirstTwoFirst)
            {
                topEvaluation = EvaluateStatement(
                    topStatements[0],
                    topStatements[1],
                    topFirstOperation
                );
                topEvaluation = EvaluateStatement(
                    topEvaluation,
                    topStatements[2],
                    topSecondOperation
                );
            }
            else
            {
                topEvaluation = EvaluateStatement(
                    topStatements[1],
                    topStatements[2],
                    topSecondOperation
                );
                topEvaluation = EvaluateStatement(
                    topStatements[0],
                    topEvaluation,
                    topFirstOperation
                );
            }

            bool bottomEvaluation;
            if (bottomFirstTwoFirst)
            {
                bottomEvaluation = EvaluateStatement(
                    bottomStatements[0],
                    bottomStatements[1],
                    bottomFirstOperation
                );
                bottomEvaluation = EvaluateStatement(
                    bottomEvaluation,
                    bottomStatements[2],
                    bottomSecondOperation
                );
            }
            else
            {
                bottomEvaluation = EvaluateStatement(
                    bottomStatements[1],
                    bottomStatements[2],
                    bottomSecondOperation
                );
                bottomEvaluation = EvaluateStatement(
                    bottomStatements[0],
                    bottomEvaluation,
                    bottomFirstOperation
                );
            }

            //Debug info

            PrintEvaluation(
                1,
                topLetters,
                topNotStatements,
                topFirstTwoFirst,
                topFirstOperation,
                topSecondOperation,
                topEvaluation
            );
            PrintEvaluation(
                2,
                bottomLetters,
                bottomNotStatements,
                bottomFirstTwoFirst,
                bottomFirstOperation,
                bottomSecondOperation,
                bottomEvaluation
            );

            ShowAnswer($"\nTop: {topEvaluation} \nBottom: {bottomEvaluation}", true);
        }

        /// <summary>
        /// Prints what each letters evaluates to
        /// </summary>
        /// <param name="row">the row the letters are in</param>
        /// <param name="letters">the latters</param>
        /// <param name="statements">the evaulation of each letter</param>
        private void PrintTruthTable(int row, char[] letters, bool[] statements)
        {
            PrintDebug($"(Row #{row}): ");

            for (int i = 0; i < 3; i++)
            {
                PrintDebug($"{letters[i]} = {statements[i]} ");
            }

            PrintDebugLine("");
        }

        private void PrintEvaluation(
            int row,
            char[] letters,
            bool[] notStatements,
            bool firstTwoFirst,
            string operation1,
            string operation2,
            bool totalEvaluation
        )
        {
            string actualOperation1 = CovertSymbol(operation1);
            string actualOperation2 = CovertSymbol(operation2);

            string letter1 = "" + letters[0];
            string letter2 = "" + letters[1];
            string letter3 = "" + letters[2];

            if (notStatements[0])
            {
                letter1 = "¬" + letter1;
            }

            if (notStatements[1])
            {
                letter2 = "¬" + letter2;
            }

            if (notStatements[2])
            {
                letter3 = "¬" + letter3;
            }

            PrintDebug($"Row {row}: ");

            if (firstTwoFirst)
            {
                PrintDebugLine(
                    $"({letter1} {actualOperation1} {letter2}) {actualOperation2} {letter3} = {totalEvaluation}"
                );
            }
            else
            {
                PrintDebugLine(
                    $"{letter1} {actualOperation1} ({letter2} {actualOperation2} {letter3}) = {totalEvaluation}"
                );
            }
        }

        private string CovertSymbol(string symbol)
        {
            switch (symbol)
            {
                //AND
                case "∧":
                    return "AND";

                //OR
                case "∨":
                    return "OR";

                //XOR
                case "⊻":
                    return "XOR";

                //NAND
                case "|":
                    return "NAND";

                //NOR
                case "↓":
                    return "NOR";

                //XNOR
                case "↔":
                    return "XNOR";

                //NOT 1 OR 2
                //NOT 2 OR 1
                default:
                    return symbol;
            }
        }

        //=========METHODS=========

        /// <summary>
        /// Tells if a statement if true or false
        /// based on a character
        /// </summary>
        /// <param name="character">the charcter the statement will be based on</param>
        /// <returns>if the statement is true or false</returns>
        private bool SetStatement(char character)
        {
            bool statement = false;
            switch (character)
            {
                //A - Number of batteries = number of indicators
                case 'A':

                    statement = Bomb.Battery == Bomb.IndicatorNum;
                    break;

                //B - Serial number has more letters than digits
                case 'B':

                    statement = Bomb.LetterNum > Bomb.DigitNum;
                    break;

                //C - Has IND indicator
                case 'C':

                    statement = Bomb.Ind.Visible;
                    break;

                //D - Has FRK indicator
                case 'D':

                    statement = Bomb.Frk.Visible;
                    break;

                //E - Exactly 1 unlit indicator
                case 'E':

                    statement = Bomb.UnlitIndicatorsList.Count == 1;
                    break;

                //F - More than 1 port type
                case 'F':

                    statement = Bomb.UniquePortNum > 1;
                    break;

                //G - 2 batteries or more
                case 'G':

                    statement = Bomb.Battery >= 2;
                    break;

                //H - Less than 2 batteries
                case 'H':

                    statement = Bomb.Battery < 2;
                    break;

                //I - Last digit of serial number is odd
                case 'I':

                    statement = Bomb.LastDigit % 2 == 1;
                    break;

                //J - More than 4 batteries
                case 'J':

                    statement = Bomb.Battery > 4;
                    break;

                //K - Exactly 1 lit indicator
                case 'K':

                    statement = Bomb.LitIndicatorsList.Count == 1;
                    break;

                //L - More than 2 indicators
                case 'L':

                    statement = Bomb.IndicatorNum > 2;
                    break;

                //M - No duplicate ports
                case 'M':

                    statement = Bomb.UniquePortNum == Bomb.PortNum;
                    break;

                //N - More than 2 battery holders
                case 'N':

                    statement = Bomb.BatteryHolder > 2;
                    break;

                //O - Has both lit and unlit indicators
                case 'O':

                    statement =
                        Bomb.UnlitIndicatorsList.Count > 0 && Bomb.LitIndicatorsList.Count > 0;
                    break;

                //P - Has parallel port
                case 'P':

                    statement = Bomb.PPVisuble;
                    break;

                //Q - Exactly 2 ports
                case 'Q':

                    statement = Bomb.PortNum == 2;
                    break;

                //R - Has PS/2 port
                case 'R':

                    statement = Bomb.PSVisible;
                    break;

                //S - Sum of digits in serial number > 10
                case 'S':

                    statement = Bomb.DigitSum > 10;
                    break;

                //T - Has MSA indicator
                case 'T':

                    statement = Bomb.Msa.Visible;
                    break;

                //U - Exactly 1 battery holder
                case 'U':

                    statement = Bomb.BatteryHolder == 1;
                    break;

                //V - Serial number contains vowels
                case 'V':

                    statement = Bomb.HasVowel;
                    break;

                //W - No indicators
                case 'W':

                    statement = Bomb.IndicatorNum == 0;
                    break;

                //X - Exactly 1 indicator
                case 'X':

                    statement = Bomb.IndicatorNum == 1;
                    break;

                //Y - More than 5 ports
                case 'Y':

                    statement = Bomb.PortNum > 5;
                    break;

                //Z - Less than 2 ports
                case 'Z':

                    statement = Bomb.PortNum < 2;
                    break;
            }
            return statement;
        }

        private bool UpdateStatement(bool statement, bool notStatement)
        {
            if (notStatement)
            {
                statement = !statement;
            }

            return statement;
        }

        /// <summary>
        /// Evauluatees a boolen operation
        /// </summary>
        /// <param name="bool1">the first boolean</param>
        /// <param name="bool2">the second boolean</param>
        /// <param name="operation">the operation used to evaulate the statement</param>
        /// <returns>the evauluated statement</returns>

        private bool EvaluateStatement(bool bool1, bool bool2, String operation)
        {
            switch (operation)
            {
                //AND
                case "∧":
                    return bool1 && bool2;

                //OR
                case "∨":
                    return bool1 || bool2;

                //XOR
                case "⊻":
                    return bool1 ^ bool2;

                //NAND
                case "|":
                    return !(bool1 && bool2);

                //NOR
                case "↓":
                    return !(bool1 || bool2);

                //XNOR
                case "↔":
                    return !(bool1 ^ bool2);

                //NOT 1 OR 2
                case "→":
                    return !bool1 || bool2;

                //NOT 2 OR 1
                default:
                    return bool1 || !bool2;
            }
        }
    }
}
