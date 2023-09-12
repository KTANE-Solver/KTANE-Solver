using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class RoundKeypad : Module
    {
        List<Symbol> symbolList;

        List<SymbolRow> symbolRowList;

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

        public RoundKeypad(StreamWriter logFileWriter, List<Symbol> symbolList)
            : base(null, logFileWriter, "Round Keypad")
        {
            symbolRowList = new List<SymbolRow>
            {
                new SymbolRow(
                    new Symbol[]
                    {
                        Symbol.O,
                        Symbol.A,
                        Symbol.Lambda,
                        Symbol.Lightning,
                        Symbol.Squid,
                        Symbol.H,
                        Symbol.BackwardsC
                    },1
                ),
                new SymbolRow(
                    new Symbol[]
                    {
                        Symbol.E,
                        Symbol.O,
                        Symbol.BackwardsC,
                        Symbol.Swirl,
                        Symbol.WhiteStar,
                        Symbol.H,
                        Symbol.QuestionMark
                    },2
                ),
                new SymbolRow(
                    new Symbol[]
                    {
                        Symbol.Copyright,
                        Symbol.Butt,
                        Symbol.Swirl,
                        Symbol.X,
                        Symbol.UfinishedR,
                        Symbol.Lambda,
                        Symbol.WhiteStar
                    },3
                ),
                new SymbolRow(
                    new Symbol[]
                    {
                        Symbol.Six,
                        Symbol.Paragraph,
                        Symbol.B,
                        Symbol.Squid,
                        Symbol.X,
                        Symbol.QuestionMark,
                        Symbol.SmilyFace
                    },4
                ),
                new SymbolRow(
                    new Symbol[]
                    {
                        Symbol.Trident,
                        Symbol.SmilyFace,
                        Symbol.B,
                        Symbol.C,
                        Symbol.Paragraph,
                        Symbol.Three,
                        Symbol.BlackStar
                    },5
                ),
                new SymbolRow(
                    new Symbol[]
                    {
                        Symbol.Six,
                        Symbol.E,
                        Symbol.Hashtag,
                        Symbol.Ae,
                        Symbol.Trident,
                        Symbol.N,
                        Symbol.Omega
                    },6
                )
            };

            this.symbolList = symbolList;
        }

        public Symbol[] Solve()
        {
            PrintDebugLine("Selected Symbols: ");

            foreach (Symbol s in symbolList)
            {
                PrintDebugLine(s.ToString());
            }

            PrintDebugLine("");

            List<int> symbolNumList = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                SymbolRow symbolRow = symbolRowList[i];
                symbolRow.SetSymbolNum(symbolList);
                symbolNumList.Add(symbolRow.foundSymbolNum);

                PrintDebugLine($"Row {i + 1} count: {symbolRow.foundSymbolNum}");
            }

            int maxValue = symbolNumList.Max();

            for (int i = symbolRowList.Count - 1; i > -1; i--)
            {
                if (symbolRowList[i].foundSymbolNum != maxValue)
                {
                    symbolRowList.RemoveAt(i);
                }
            }

            SymbolRow answerRow = symbolRowList.Last();

            PrintDebugLine($"\nUsing Row {answerRow.rowIndex}\n");

            List<Symbol> answers = new List<Symbol>();

            foreach (Symbol symbol in symbolList)
            {
                if (!answerRow.row.Contains(symbol))
                {
                    answers.Add(symbol);
                }
            }

            string asnwer = string.Join(", ", answers.ToArray());

            PrintDebugLine("Answer Symbols: " + asnwer);

            return answers.ToArray();
        }

        public class SymbolRow
        {
            public Symbol[] row;
            public int foundSymbolNum;
            public int rowIndex;

            public SymbolRow(Symbol[] row, int rowIndex)
            {
                this.row = row;
                foundSymbolNum = 0;
                this.rowIndex = rowIndex;
            }

            public void SetSymbolNum(List<Symbol> symbolList)
            {
                foundSymbolNum = row.Where(x => symbolList.Contains(x)).Count();
            }
        }
    }
}
