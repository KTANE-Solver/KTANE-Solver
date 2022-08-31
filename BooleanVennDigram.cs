using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    class BooleanVennDiagram : Module
    {
        private string operation1;
        private string operation2;
        private bool parenthesisFirst;

        public BooleanVennDiagram(
            string operation1,
            string operation2,
            bool parenthesisFirst,
            Bomb bomb,
            StreamWriter logFileWriter
        ) : base(bomb, logFileWriter, "Boolean Venn Diagram")
        {
            this.operation1 = operation1;
            this.operation2 = operation2;
            this.parenthesisFirst = parenthesisFirst;
        }

        public void Solve()
        {
            List<string> answers = new List<string>();

            bool statement1;
            bool statement2;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        bool a = i == 1;
                        bool b = j == 1;
                        bool c = k == 1;

                        if (parenthesisFirst)
                        {
                            statement1 = EvaluateStatement(a, b, operation1);

                            statement2 = EvaluateStatement(statement1, c, operation2);

                            if (statement2)
                            {
                                answers.Add(GetAnswer(a, b, c));
                            }
                        }
                        else
                        {
                            statement1 = EvaluateStatement(b, c, operation2);

                            statement2 = EvaluateStatement(a, statement1, operation1);

                            if (statement2)
                            {
                                answers.Add(GetAnswer(a, b, c));
                            }
                        }

                        PrintDebug(a, b, c, parenthesisFirst, statement2, operation1, operation2);
                    }
                }
            }

            ShowAnswer(string.Join(", ", answers), true);
        }

        private string GetAnswer(bool a, bool b, bool c)
        {
            string answer = "";

            if (a)
            {
                answer += "A";
            }

            if (b)
            {
                answer += "B";
            }

            if (c)
            {
                answer += "C";
            }
            else if (!a && !b && !c)
            {
                return "None";
            }

            return answer;
        }

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

        private void PrintDebug(
            bool a,
            bool b,
            bool c,
            bool parenthesisAroundFirst,
            bool totalStatement,
            string operation1,
            string operation2
        )
        {
            if (parenthesisAroundFirst)
            {
                PrintDebugLine(
                    $"({a} {CovertSymbol(operation1)} {b}) {CovertSymbol(operation2)} {c} = {totalStatement}\n"
                );
            }
            else
            {
                PrintDebugLine(
                    $"{a} {CovertSymbol(operation1)} ({b} {CovertSymbol(operation2)} {c}) = {totalStatement}\n"
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
    }
}
