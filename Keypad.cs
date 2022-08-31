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
    /// Date: 5/20/21
    /// Purpose: Solves the "Keypad" module
    /// </summary>
    public class Keypad : Module
    {
        //the 4 symbols on the bomb
        Symbol symbol1;
        Symbol symbol2;
        Symbol symbol3;
        Symbol symbol4;

        //an enum list that will contain every symbol
        public enum Symbol
        {
            Three,
            Six,
            A,
            Ae,
            B,
            BackwardsC,
            BlackStar,
            Butt,
            C,
            Copyright,
            E,
            H,
            Hashtag,
            Lambda,
            Lightning,
            N,
            O,
            Omega,
            Paragraph,
            QuestionMark,
            SmilyFace,
            Squid,
            Swirl,
            Trident,
            UfinishedR,
            WhiteStar,
            X,
            Null
        }

        //lists of all of the symbols
        Symbol[] row1 = new Symbol[]
        {
            Symbol.O,
            Symbol.A,
            Symbol.Lambda,
            Symbol.Lightning,
            Symbol.Squid,
            Symbol.H,
            Symbol.BackwardsC
        };
        Symbol[] row2 = new Symbol[]
        {
            Symbol.E,
            Symbol.O,
            Symbol.BackwardsC,
            Symbol.Swirl,
            Symbol.WhiteStar,
            Symbol.H,
            Symbol.QuestionMark
        };
        Symbol[] row3 = new Symbol[]
        {
            Symbol.Copyright,
            Symbol.Butt,
            Symbol.Swirl,
            Symbol.X,
            Symbol.UfinishedR,
            Symbol.Lambda,
            Symbol.WhiteStar
        };
        Symbol[] row4 = new Symbol[]
        {
            Symbol.Six,
            Symbol.Paragraph,
            Symbol.B,
            Symbol.Squid,
            Symbol.X,
            Symbol.QuestionMark,
            Symbol.SmilyFace
        };
        Symbol[] row5 = new Symbol[]
        {
            Symbol.Trident,
            Symbol.SmilyFace,
            Symbol.B,
            Symbol.C,
            Symbol.Paragraph,
            Symbol.Three,
            Symbol.BlackStar
        };
        Symbol[] row6 = new Symbol[]
        {
            Symbol.Six,
            Symbol.E,
            Symbol.Hashtag,
            Symbol.Ae,
            Symbol.Trident,
            Symbol.N,
            Symbol.Omega
        };

        public Keypad(
            String image1,
            String image2,
            String image3,
            String image4,
            Bomb bomb,
            StreamWriter logFileWriter
        ) : base(bomb, logFileWriter, "Keypad")
        {
            symbol1 = SetUpSymbol(image1);
            symbol2 = SetUpSymbol(image2);
            symbol3 = SetUpSymbol(image3);
            symbol4 = SetUpSymbol(image4);
        }

        public void Solve()
        {
            //Debug information
            PrintSymbol(1, symbol1);
            PrintSymbol(2, symbol2);
            PrintSymbol(3, symbol3);
            PrintSymbol(4, symbol4);

            //check which row contains all symbols
            Symbol[] row = FindCorrectRow();

            if (row == null)
            {
                ShowErrorMessage("Can't find answer");
                PrintDebugLine("\nUnable to find answer\n");
                return;
            }

            //find the index of each symbol and sort it by lowest to higest
            int symbol1Index = Array.IndexOf(row, symbol1);
            int symbol2Index = Array.IndexOf(row, symbol2);
            int symbol3Index = Array.IndexOf(row, symbol3);
            int symbol4Index = Array.IndexOf(row, symbol4);

            int[] array = new int[] { symbol1Index, symbol2Index, symbol3Index, symbol4Index };

            Array.Sort(array);

            //keeps track of the places of each symbol
            int symbol1Place = Array.IndexOf(array, symbol1Index) + 1;
            int symbol2Place = Array.IndexOf(array, symbol2Index) + 1;
            int symbol3Place = Array.IndexOf(array, symbol3Index) + 1;
            int symbol4Place = Array.IndexOf(array, symbol4Index) + 1;

            KeyPadAnswerForm answerForm;

            if (symbol1Place == 1 && symbol2Place == 2 && symbol3Place == 3 && symbol4Place == 4)
                answerForm = new KeyPadAnswerForm(symbol1, symbol2, symbol3, symbol4);
            else if (
                symbol1Place == 1 && symbol2Place == 2 && symbol3Place == 4 && symbol4Place == 3
            )
                answerForm = new KeyPadAnswerForm(symbol1, symbol2, symbol4, symbol3);
            else if (
                symbol1Place == 1 && symbol2Place == 3 && symbol3Place == 4 && symbol4Place == 2
            )
                answerForm = new KeyPadAnswerForm(symbol1, symbol4, symbol2, symbol3);
            else if (
                symbol1Place == 1 && symbol2Place == 3 && symbol3Place == 2 && symbol4Place == 4
            )
                answerForm = new KeyPadAnswerForm(symbol1, symbol3, symbol2, symbol4);
            else if (
                symbol1Place == 1 && symbol2Place == 4 && symbol3Place == 2 && symbol4Place == 3
            )
                answerForm = new KeyPadAnswerForm(symbol1, symbol3, symbol4, symbol2);
            else if (
                symbol1Place == 1 && symbol2Place == 4 && symbol3Place == 3 && symbol4Place == 2
            )
                answerForm = new KeyPadAnswerForm(symbol1, symbol4, symbol3, symbol2);
            else if (
                symbol1Place == 2 && symbol2Place == 1 && symbol3Place == 3 && symbol4Place == 4
            )
                answerForm = new KeyPadAnswerForm(symbol2, symbol1, symbol3, symbol4);
            else if (
                symbol1Place == 2 && symbol2Place == 1 && symbol3Place == 4 && symbol4Place == 3
            )
                answerForm = new KeyPadAnswerForm(symbol2, symbol1, symbol4, symbol3);
            else if (
                symbol1Place == 2 && symbol2Place == 3 && symbol3Place == 1 && symbol4Place == 4
            )
                answerForm = new KeyPadAnswerForm(symbol3, symbol1, symbol2, symbol4);
            else if (
                symbol1Place == 2 && symbol2Place == 3 && symbol3Place == 4 && symbol4Place == 1
            )
                answerForm = new KeyPadAnswerForm(symbol4, symbol1, symbol2, symbol3);
            else if (
                symbol1Place == 2 && symbol2Place == 4 && symbol3Place == 1 && symbol4Place == 3
            )
                answerForm = new KeyPadAnswerForm(symbol3, symbol1, symbol4, symbol2);
            else if (
                symbol1Place == 2 && symbol2Place == 4 && symbol3Place == 3 && symbol4Place == 1
            )
                answerForm = new KeyPadAnswerForm(symbol4, symbol1, symbol3, symbol2);
            else if (
                symbol1Place == 3 && symbol2Place == 1 && symbol3Place == 2 && symbol4Place == 4
            )
                answerForm = new KeyPadAnswerForm(symbol2, symbol3, symbol1, symbol4);
            else if (
                symbol1Place == 3 && symbol2Place == 1 && symbol3Place == 4 && symbol4Place == 2
            )
                answerForm = new KeyPadAnswerForm(symbol2, symbol4, symbol1, symbol3);
            else if (
                symbol1Place == 3 && symbol2Place == 2 && symbol3Place == 1 && symbol4Place == 4
            )
                answerForm = new KeyPadAnswerForm(symbol3, symbol2, symbol1, symbol4);
            else if (
                symbol1Place == 3 && symbol2Place == 2 && symbol3Place == 4 && symbol4Place == 1
            )
                answerForm = new KeyPadAnswerForm(symbol4, symbol2, symbol1, symbol3);
            else if (
                symbol1Place == 3 && symbol2Place == 4 && symbol3Place == 1 && symbol4Place == 2
            )
                answerForm = new KeyPadAnswerForm(symbol3, symbol4, symbol1, symbol2);
            else if (
                symbol1Place == 3 && symbol2Place == 4 && symbol3Place == 2 && symbol4Place == 1
            )
                answerForm = new KeyPadAnswerForm(symbol4, symbol3, symbol1, symbol2);
            else if (
                symbol1Place == 4 && symbol2Place == 1 && symbol3Place == 2 && symbol4Place == 3
            )
                answerForm = new KeyPadAnswerForm(symbol2, symbol3, symbol4, symbol1);
            else if (
                symbol1Place == 4 && symbol2Place == 1 && symbol3Place == 2 && symbol4Place == 3
            )
                answerForm = new KeyPadAnswerForm(symbol2, symbol3, symbol4, symbol1);
            else if (
                symbol1Place == 4 && symbol2Place == 1 && symbol3Place == 3 && symbol4Place == 2
            )
                answerForm = new KeyPadAnswerForm(symbol2, symbol4, symbol3, symbol1);
            else if (
                symbol1Place == 4 && symbol2Place == 2 && symbol3Place == 1 && symbol4Place == 3
            )
                answerForm = new KeyPadAnswerForm(symbol3, symbol2, symbol4, symbol1);
            else if (
                symbol1Place == 4 && symbol2Place == 2 && symbol3Place == 3 && symbol4Place == 1
            )
                answerForm = new KeyPadAnswerForm(symbol4, symbol2, symbol3, symbol1);
            else if (
                symbol1Place == 4 && symbol2Place == 3 && symbol3Place == 1 && symbol4Place == 2
            )
                answerForm = new KeyPadAnswerForm(symbol3, symbol4, symbol2, symbol1);
            else
                answerForm = new KeyPadAnswerForm(symbol4, symbol3, symbol2, symbol1);

            int rowIndex;

            if (row1 == row)
            {
                rowIndex = 1;
            }
            else if (row2 == row)
            {
                rowIndex = 2;
            }
            else if (row3 == row)
            {
                rowIndex = 3;
            }
            else if (row4 == row)
            {
                rowIndex = 4;
            }
            else if (row5 == row)
            {
                rowIndex = 5;
            }
            else
            {
                rowIndex = 6;
            }

            PrintDebugLine("\nFound sybmols in row " + rowIndex);

            PrintDebug("\nAnswer: ");
            for (int i = 0; i < 3; i++)
            {
                PrintDebug($"{i + 1}. {row[i]}, ");
            }

            PrintDebugLine($"4. {row[3]}\n");

            answerForm.ShowDialog();
        }

        private void PrintSymbol(int num, Symbol symbol)
        {
            PrintDebugLine($"Symbol {num}: " + symbol);
        }

        /// <summary>
        /// Finds the row the contains all symbols
        /// </summary>
        private Symbol[] FindCorrectRow()
        {
            if (
                row1.Contains<Symbol>(symbol1)
                && row1.Contains<Symbol>(symbol2)
                && row1.Contains<Symbol>(symbol3)
                && row1.Contains<Symbol>(symbol4)
            )
                return row1;

            if (
                row2.Contains<Symbol>(symbol1)
                && row2.Contains<Symbol>(symbol2)
                && row2.Contains<Symbol>(symbol3)
                && row2.Contains<Symbol>(symbol4)
            )
                return row2;

            if (
                row3.Contains<Symbol>(symbol1)
                && row3.Contains<Symbol>(symbol2)
                && row3.Contains<Symbol>(symbol3)
                && row3.Contains<Symbol>(symbol4)
            )
                return row3;

            if (
                row4.Contains<Symbol>(symbol1)
                && row4.Contains<Symbol>(symbol2)
                && row4.Contains<Symbol>(symbol3)
                && row4.Contains<Symbol>(symbol4)
            )
                return row4;

            if (
                row5.Contains<Symbol>(symbol1)
                && row5.Contains<Symbol>(symbol2)
                && row5.Contains<Symbol>(symbol3)
                && row5.Contains<Symbol>(symbol4)
            )
                return row5;

            if (
                row6.Contains<Symbol>(symbol1)
                && row6.Contains<Symbol>(symbol2)
                && row6.Contains<Symbol>(symbol3)
                && row6.Contains<Symbol>(symbol4)
            )
                return row6;

            return null;
        }

        /// <summary>
        /// A method that will take the name of the image and return the respective symbol
        /// </summary>
        /// <param name="image">the image on the bomb</param>
        private Symbol SetUpSymbol(String imageName)
        {
            switch (imageName)
            {
                case "3":
                    return Symbol.Three;

                case "6":
                    return Symbol.Six;

                case "A":
                    return Symbol.A;

                case "AE":
                    return Symbol.Ae;

                case "B":
                    return Symbol.B;

                case "Backwards C":
                    return Symbol.BackwardsC;

                case "Black Star":
                    return Symbol.BlackStar;

                case "Butt":
                    return Symbol.Butt;

                case "C":
                    return Symbol.C;

                case "Copyright":
                    return Symbol.Copyright;

                case "E":
                    return Symbol.E;

                case "H":
                    return Symbol.H;

                case "Hashtag":
                    return Symbol.Hashtag;

                case "Lambda":
                    return Symbol.Lambda;

                case "Lightning":
                    return Symbol.Lightning;

                case "N":
                    return Symbol.N;

                case "O":
                    return Symbol.O;

                case "Omega":
                    return Symbol.Omega;

                case "Paragraph":
                    return Symbol.Paragraph;

                case "Question Mark":
                    return Symbol.QuestionMark;

                case "Smily Face":
                    return Symbol.SmilyFace;

                case "Squid":
                    return Symbol.Squid;

                case "Swirl":
                    return Symbol.Swirl;

                case "Trident":
                    return Symbol.Trident;

                case "Unfinished R":
                    return Symbol.UfinishedR;

                case "White Star":
                    return Symbol.WhiteStar;

                case "X":
                    return Symbol.X;

                //should never happen
                default:
                    return Symbol.Null;
            }
        }
    }
}
