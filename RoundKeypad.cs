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

        public RoundKeypad(Bomb bomb, StreamWriter logFileWriter, List<Symbol> symbolList)
            : base(bomb, logFileWriter, "Round Keypad")
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
                    }
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
                    }
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
                    }
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
                    }
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
                    }
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
                    }
                )
            };

            this.symbolList = symbolList;
        }

        public Symbol[] Solve()
        {
            List<int> symbolNumList = new List<int>();

            foreach (SymbolRow symbolRow in symbolRowList)
            {
                symbolRow.SetSymbolNum(symbolList);
                symbolNumList.Add(symbolRow.foundSymbolNum);
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

            List<Symbol> answers = new List<Symbol>();

            foreach (Symbol symbol in symbolList)
            {
                if (!answerRow.row.Contains(symbol))
                {
                    answers.Add(symbol);
                }
            }

            return answers.ToArray();
        }

        public class SymbolRow
        {
            public Symbol[] row;
            public int foundSymbolNum;

            public SymbolRow(Symbol[] row)
            {
                this.row = row;
                foundSymbolNum = 0;
            }

            public void SetSymbolNum(List<Symbol> symbolList)
            {
                foundSymbolNum = row.Where(x => symbolList.Contains(x)).Count();
            }
        }
    }
}
