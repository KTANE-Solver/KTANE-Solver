using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class LetterKeys : Module
    {
        int number;

        public LetterKeys(Bomb bomb, StreamWriter logFileWriter, int number)
            : base(bomb, logFileWriter, "Lettered Keys")
        {
            this.number = number;
        }

        public string SolveDebug()
        {
            PrintDebugLine("Number: " + number);

            if (number == 69)
            {
                PrintDebugLine("The number indicated is equal to 69");
                return "D";
            }

            if (number % 6 == 0)
            {
                PrintDebugLine("The number indicated is divisible by 6");
                return "A";
            }

            if (Bomb.Battery >= 2 && number % 3 == 0)
            {
                PrintDebugLine(
                    "There are two or more batteries on the bomb and the number is divisible by 3"
                );
                return "B";
            }

            bool containsCE3 =
                Bomb.SerialNumber.Contains('C')
                || Bomb.SerialNumber.Contains('E')
                || Bomb.SerialNumber.Contains('3');

            if (containsCE3 && number >= 22 && number <= 79)
            {
                PrintDebugLine(
                    "The serial number contains a 'C' 'E' or '3' and the number is greater than or equal to 22, and less than or equal to 79"
                );
                return "B";
            }

            if (containsCE3)
            {
                PrintDebugLine("The serial number contains a 'C' 'E' or '3'");
                return "C";
            }

            if (number < 46)
            {
                PrintDebugLine("The indicated number is less than 46");
                return "D";
            }

            PrintDebugLine("None of the previous rules applies");
            return "A";
        }

        public void Solve()
        {
            ShowAnswer(SolveDebug(), true);
        }
    }
}
