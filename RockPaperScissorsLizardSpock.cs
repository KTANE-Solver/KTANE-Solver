using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the rock paper scissors lizard spock module
    /// </summary>
    public class RockPaperScissorsLizardSpock : Module
    {
        Symbol decoy;
        Symbol bombSymbol;

        Dictionary<Symbol, int> counter;

        public enum Symbol
        {
            Rock,
            Paper,
            Scissors,
            Lizard,
            Spock,
            Null
        }

        public RockPaperScissorsLizardSpock(Symbol decoy, Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Rock Paper Scissors Lizard Spock")
        {
            this.decoy = decoy;

            PrintDebugLine($"Decoy is {decoy}\n");

            counter = new Dictionary<Symbol, int>();
            ResetValues();
        }

        public string Solve(bool debug)
        {
            bombSymbol = FindBombSymbol();

            string answer = string.Join(", ", FindAnswer());

            PrintDebugLine($"Answer: {answer}\n");

            if(!debug)
            {
                ShowAnswer(answer, true);
            }

            return answer;
        }

        private Symbol[] FindAnswer()
        {
            switch (bombSymbol)
            {
                case Symbol.Rock:
                    return new Symbol[] { Symbol.Paper, Symbol.Spock };

                case Symbol.Paper:
                    return new Symbol[] { Symbol.Lizard, Symbol.Scissors };

                case Symbol.Scissors:
                    return new Symbol[] { Symbol.Spock, Symbol.Rock };

                case Symbol.Lizard:
                    return new Symbol[] { Symbol.Rock, Symbol.Scissors };

                case Symbol.Spock:
                    return new Symbol[] { Symbol.Paper, Symbol.Lizard };

                default:
                    List<Symbol> list = new List<Symbol>();

                    foreach (Symbol symbol in counter.Keys)
                    {
                        if (symbol != decoy)
                            list.Add(symbol);
                    }

                    return list.ToArray();
            }
        }

        private Symbol FindBombSymbol()
        {
            Symbol highestSymbol = SerialNumberLetter();

            if (highestSymbol == Symbol.Null || highestSymbol == decoy)
            {
                PrintDebugLine("Unable to find winning symbol in row 1\n");
                ResetValues();
                highestSymbol = Port();

                if (highestSymbol == Symbol.Null || highestSymbol == decoy)
                {
                    PrintDebugLine("Unable to find winning symbol in row 2\n");
                    ResetValues();
                    highestSymbol = LitIndicator();

                    if (highestSymbol == Symbol.Null || highestSymbol == decoy)
                    {
                        PrintDebugLine("Unable to find winning symbol in row 3\n");
                        ResetValues();
                        highestSymbol = UnlitIndicator();

                        if (highestSymbol == Symbol.Null || highestSymbol == decoy)
                        {
                            PrintDebugLine("Unable to find winning symbol in row 4\n");
                            ResetValues();
                            highestSymbol = SerialNumberDigit();
                        }
                    }
                }
            }

            PrintDebugLine($"Highest Symbol is {highestSymbol}\n");

            return highestSymbol;
        }

        private Symbol SerialNumberLetter()
        {
            if (Bomb.SerialNumber.Contains('X') || Bomb.SerialNumber.Contains('Y'))
            {
                PrintDebugLine("Skipping Serial Number Letter Row\n");
                return Symbol.Null;
            }

            PrintDebugLine("Serial Number Letter Row:");

            counter[Symbol.Rock] = CharacterCountInSerialNum('R') + CharacterCountInSerialNum('O');
            counter[Symbol.Paper] = CharacterCountInSerialNum('P') + CharacterCountInSerialNum('A');
            counter[Symbol.Scissors] =
                CharacterCountInSerialNum('S') + CharacterCountInSerialNum('I');
            counter[Symbol.Lizard] =
                CharacterCountInSerialNum('L') + CharacterCountInSerialNum('Z');
            counter[Symbol.Spock] = CharacterCountInSerialNum('C') + CharacterCountInSerialNum('K');

            PrintDebugLine($"Rock: {counter[Symbol.Rock]}");
            PrintDebugLine($"Paper: {counter[Symbol.Paper]}");
            PrintDebugLine($"Scissors: {counter[Symbol.Scissors]}");
            PrintDebugLine($"Lizard: {counter[Symbol.Lizard]}");
            PrintDebugLine($"Spock: {counter[Symbol.Spock]}\n");

            return FindHieghestValue();
        }

        private Symbol Port()
        {
            if (Bomb.PSVisible)
            {
                PrintDebugLine("Skipping Port Row\n");
                return Symbol.Null;
            }

            PrintDebugLine("Port Row\n");

            counter[Symbol.Rock] = Bomb.RJNum;
            counter[Symbol.Paper] = Bomb.PPNum;
            counter[Symbol.Scissors] = Bomb.SerialNum;
            counter[Symbol.Lizard] = Bomb.DviNum;
            counter[Symbol.Spock] = Bomb.RcaNum;

            PrintDebugLine($"Rock: {counter[Symbol.Rock]}");
            PrintDebugLine($"Paper: {counter[Symbol.Paper]}");
            PrintDebugLine($"Scissors: {counter[Symbol.Scissors]}");
            PrintDebugLine($"Lizard: {counter[Symbol.Lizard]}");
            PrintDebugLine($"Spock: {counter[Symbol.Spock]}\n");

            return FindHieghestValue();
        }

        private Symbol LitIndicator()
        {
            if (Bomb.Trn.Lit)
            {
                PrintDebugLine("Skipping Lit Indicator Row\n");
                return Symbol.Null;
            }

            if (Bomb.Frk.Lit)
                counter[Symbol.Rock]++;

            if (Bomb.Frq.Lit)
                counter[Symbol.Rock]++;

            if (Bomb.Bob.Lit)
                counter[Symbol.Paper]++;

            if (Bomb.Ind.Lit)
                counter[Symbol.Paper]++;

            if (Bomb.Car.Lit)
                counter[Symbol.Scissors]++;

            if (Bomb.Sig.Lit)
                counter[Symbol.Scissors]++;

            if (Bomb.Clr.Lit)
                counter[Symbol.Lizard]++;

            if (Bomb.Nsa.Lit)
                counter[Symbol.Lizard]++;

            if (Bomb.Snd.Lit)
                counter[Symbol.Spock]++;

            if (Bomb.Msa.Lit)
                counter[Symbol.Spock]++;

            PrintDebugLine($"Rock: {counter[Symbol.Rock]}");
            PrintDebugLine($"Paper: {counter[Symbol.Paper]}");
            PrintDebugLine($"Scissors: {counter[Symbol.Scissors]}");
            PrintDebugLine($"Lizard: {counter[Symbol.Lizard]}");
            PrintDebugLine($"Spock: {counter[Symbol.Spock]}\n");

            return FindHieghestValue();
        }

        private Symbol UnlitIndicator()
        {
            if (Bomb.Trn.VisibleNotLit)
            {
                PrintDebugLine("Skipping unlit Indicator Row\n");
                return Symbol.Null;
            }

            if (Bomb.Frk.VisibleNotLit)
                counter[Symbol.Rock]++;

            if (Bomb.Frq.VisibleNotLit)
                counter[Symbol.Rock]++;

            if (Bomb.Bob.VisibleNotLit)
                counter[Symbol.Paper]++;

            if (Bomb.Ind.VisibleNotLit)
                counter[Symbol.Paper]++;

            if (Bomb.Car.VisibleNotLit)
                counter[Symbol.Scissors]++;

            if (Bomb.Sig.VisibleNotLit)
                counter[Symbol.Scissors]++;

            if (Bomb.Clr.VisibleNotLit)
                counter[Symbol.Lizard]++;

            if (Bomb.Nsa.VisibleNotLit)
                counter[Symbol.Lizard]++;

            if (Bomb.Snd.VisibleNotLit)
                counter[Symbol.Spock]++;

            if (Bomb.Msa.VisibleNotLit)
                counter[Symbol.Spock]++;

            PrintDebugLine($"Rock: {counter[Symbol.Rock]}");
            PrintDebugLine($"Paper: {counter[Symbol.Paper]}");
            PrintDebugLine($"Scissors: {counter[Symbol.Scissors]}");
            PrintDebugLine($"Lizard: {counter[Symbol.Lizard]}");
            PrintDebugLine($"Spock: {counter[Symbol.Spock]}\n");

            return FindHieghestValue();
        }

        private Symbol SerialNumberDigit()
        {
            counter[Symbol.Rock] = CharacterCountInSerialNum('0') + CharacterCountInSerialNum('5');
            counter[Symbol.Paper] = CharacterCountInSerialNum('3') + CharacterCountInSerialNum('6');
            counter[Symbol.Scissors] =
                CharacterCountInSerialNum('1') + CharacterCountInSerialNum('9');
            counter[Symbol.Lizard] =
                CharacterCountInSerialNum('2') + CharacterCountInSerialNum('8');
            counter[Symbol.Spock] = CharacterCountInSerialNum('4') + CharacterCountInSerialNum('7');

            PrintDebugLine($"Rock: {counter[Symbol.Rock]}");
            PrintDebugLine($"Paper: {counter[Symbol.Paper]}");
            PrintDebugLine($"Scissors: {counter[Symbol.Scissors]}");
            PrintDebugLine($"Lizard: {counter[Symbol.Lizard]}");
            PrintDebugLine($"Spock: {counter[Symbol.Spock]}\n");

            return FindHieghestValue();
        }

        private void ResetValues()
        {
            counter[Symbol.Rock] = 0;
            counter[Symbol.Paper] = 0;
            counter[Symbol.Scissors] = 0;
            counter[Symbol.Lizard] = 0;
            counter[Symbol.Spock] = 0;
        }

        private Symbol FindHieghestValue()
        {
            Symbol highestSymbol = Symbol.Null;

            int highest = -1;

            foreach (Symbol symbol in counter.Keys)
            {
                if (counter[symbol] > highest)
                {
                    highestSymbol = symbol;
                    highest = counter[symbol];
                }
            }

            //if highest repeats, then there's a tie

            int numFound = 0;

            foreach (Symbol symbol in counter.Keys)
            {
                if (counter[symbol] == highest)
                {
                    numFound++;
                }
            }

            return numFound == 1 ? highestSymbol : Symbol.Null;
        }

        private int CharacterCountInSerialNum(char target)
        {
            int num = 0;

            foreach (char character in Bomb.SerialNumber)
            {
                if (character == target)
                {
                    num++;
                }
            }

            return num;
        }
    }
}
