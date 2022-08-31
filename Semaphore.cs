using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class Semaphore : Module
    {
        private FlagMode mode;

        public Semaphore(Bomb bomb, StreamWriter logFileWriter, Flag firstFlag)
            : base(bomb, logFileWriter, "Semaphore")
        {
            if (firstFlag.AreEqual(FlagState.North, FlagState.East))
            {
                mode = FlagMode.Letter;
            }
            else
            {
                mode = FlagMode.Number;
            }
        }

        public enum FlagState
        {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest
        }

        public enum FlagMode
        {
            Letter,
            Number
        }

        public string DebugSolve(Flag flag)
        {
            bool invalidFlag = false;

            if (flag.AreEqual(FlagState.North, FlagState.NorthEast))
            {
                mode = FlagMode.Number;
            }
            else if (flag.AreEqual(FlagState.North, FlagState.East))
            {
                if (mode == FlagMode.Letter)
                {
                    invalidFlag = true;
                }
                else
                {
                    mode = FlagMode.Letter;
                }
            }
            else if (mode == FlagMode.Letter)
            {
                invalidFlag = !LetterFlag(flag);
            }
            else
            {
                invalidFlag = !NumberFlag(flag);
            }

            string answer = invalidFlag ? "Invalid" : "Valid";

            PrintDebug($"{FlagDescription(flag)}: ");

            return answer;
        }

        public string Solve(Flag flag)
        {
            string answer = DebugSolve(flag);

            ShowAnswer(answer, true);

            return answer;
        }

        private bool LetterFlag(Flag flag)
        {
            FlagState left = flag.leftState;
            FlagState right = flag.rightState;

            if (left == FlagState.SouthWest && right == FlagState.South)
            {
                return Bomb.SerialNumber.Contains('A');
            }

            if (left == FlagState.West && right == FlagState.South)
            {
                return Bomb.SerialNumber.Contains('B');
            }

            if (left == FlagState.NorthWest && right == FlagState.South)
            {
                return Bomb.SerialNumber.Contains('C');
            }

            if (left == FlagState.North && right == FlagState.South)
            {
                return Bomb.SerialNumber.Contains('D');
            }

            if (left == FlagState.South && right == FlagState.NorthEast)
            {
                return Bomb.SerialNumber.Contains('E');
            }

            if (left == FlagState.South && right == FlagState.East)
            {
                return Bomb.SerialNumber.Contains('F');
            }

            if (left == FlagState.South && right == FlagState.SouthEast)
            {
                return Bomb.SerialNumber.Contains('G');
            }

            if (left == FlagState.West && right == FlagState.SouthWest)
            {
                return Bomb.SerialNumber.Contains('H');
            }

            if (left == FlagState.SouthWest && right == FlagState.NorthWest)
            {
                return Bomb.SerialNumber.Contains('I');
            }

            if (left == FlagState.SouthWest && right == FlagState.North)
            {
                return Bomb.SerialNumber.Contains('K');
            }

            if (left == FlagState.SouthWest && right == FlagState.NorthEast)
            {
                return Bomb.SerialNumber.Contains('L');
            }

            if (left == FlagState.SouthWest && right == FlagState.East)
            {
                return Bomb.SerialNumber.Contains('M');
            }

            if (left == FlagState.SouthWest && right == FlagState.SouthEast)
            {
                return Bomb.SerialNumber.Contains('N');
            }

            if (left == FlagState.West && right == FlagState.NorthWest)
            {
                return Bomb.SerialNumber.Contains('O');
            }

            if (left == FlagState.West && right == FlagState.North)
            {
                return Bomb.SerialNumber.Contains('P');
            }

            if (left == FlagState.West && right == FlagState.NorthEast)
            {
                return Bomb.SerialNumber.Contains('Q');
            }

            if (left == FlagState.West && right == FlagState.East)
            {
                return Bomb.SerialNumber.Contains('R');
            }

            if (left == FlagState.West && right == FlagState.SouthEast)
            {
                return Bomb.SerialNumber.Contains('S');
            }

            if (left == FlagState.NorthWest && right == FlagState.North)
            {
                return Bomb.SerialNumber.Contains('T');
            }

            if (left == FlagState.NorthWest && right == FlagState.NorthEast)
            {
                return Bomb.SerialNumber.Contains('U');
            }

            if (left == FlagState.North && right == FlagState.SouthEast)
            {
                return Bomb.SerialNumber.Contains('V');
            }

            if (left == FlagState.NorthEast && right == FlagState.East)
            {
                return Bomb.SerialNumber.Contains('W');
            }

            if (left == FlagState.NorthEast && right == FlagState.SouthEast)
            {
                return Bomb.SerialNumber.Contains('X');
            }

            if (left == FlagState.NorthWest && right == FlagState.East)
            {
                return Bomb.SerialNumber.Contains('Y');
            }

            return Bomb.SerialNumber.Contains('Z');
        }

        private bool NumberFlag(Flag flag)
        {
            FlagState left = flag.leftState;
            FlagState right = flag.rightState;

            if (left == FlagState.SouthWest && right == FlagState.South)
            {
                return Bomb.SerialNumber.Contains('1');
            }

            if (left == FlagState.West && right == FlagState.South)
            {
                return Bomb.SerialNumber.Contains('2');
            }

            if (left == FlagState.NorthWest && right == FlagState.South)
            {
                return Bomb.SerialNumber.Contains('3');
            }

            if (left == FlagState.North && right == FlagState.South)
            {
                return Bomb.SerialNumber.Contains('4');
            }

            if (left == FlagState.South && right == FlagState.NorthEast)
            {
                return Bomb.SerialNumber.Contains('5');
            }

            if (left == FlagState.South && right == FlagState.East)
            {
                return Bomb.SerialNumber.Contains('6');
            }

            if (left == FlagState.South && right == FlagState.SouthEast)
            {
                return Bomb.SerialNumber.Contains('7');
            }

            if (left == FlagState.West && right == FlagState.SouthWest)
            {
                return Bomb.SerialNumber.Contains('8');
            }

            if (left == FlagState.SouthWest && right == FlagState.NorthWest)
            {
                return Bomb.SerialNumber.Contains('9');
            }

            return Bomb.SerialNumber.Contains('0');
        }

        private string FlagDescription(Flag flag)
        {
            return $"{flag.leftState} {flag.rightState}";
        }

        public class Flag
        {
            public FlagState leftState { get; }
            public FlagState rightState { get; }

            public Flag(FlagState leftState, FlagState rightState)
            {
                this.leftState = leftState;
                this.rightState = rightState;
            }

            public bool AreEqual(Flag flag)
            {
                return flag.leftState == leftState && flag.rightState == rightState;
            }

            public bool AreEqual(FlagState left, FlagState right)
            {
                return AreEqual(new Flag(left, right));
            }
        }
    }
}
