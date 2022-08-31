using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class SkewedSlots : Module
    {
        private int[] originalNumbers;
        private int[] currentNumbers;

        private int[] fibonacciSequence;
        private int[] primeValues;
        private int[] binaryValueSum;

        public SkewedSlots(Bomb bomb, StreamWriter logFileWriter, int originalNumbers)
            : base(bomb, logFileWriter, "Skewed Slots")
        {
            string OgStr = originalNumbers.ToString();

            if (originalNumbers < 100)
            {
                OgStr = "0" + OgStr;
            }

            this.originalNumbers = OgStr.Select(o => Convert.ToInt32(o) - 48).ToArray();

            currentNumbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                currentNumbers[i] = this.originalNumbers[i];
            }

            fibonacciSequence = new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
            primeValues = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            binaryValueSum = new int[] { 0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2 };
        }

        public string DebugSolve()
        {
            PrintDebugLine(
                "Original numbers: "
                    + originalNumbers[0]
                    + originalNumbers[1]
                    + originalNumbers[2]
                    + "\n"
            );

            for (int i = 0; i < currentNumbers.Length; i++)
            {
                PrintDebugLine($"Slot {i + 1}:\n");
                currentNumbers[i] = AllSlots(currentNumbers[i], originalNumbers[i]);
                PrintSlotNum(i);

                PrintDebugLine("Individual steps:\n");
                switch (i)
                {
                    case 0:
                        currentNumbers[0] = Slot1();
                        break;

                    case 1:
                        currentNumbers[1] = Slot2();
                        break;

                    case 2:
                        currentNumbers[2] = Slot3();
                        break;
                }

                PrintSlotNum(i);
            }

            for (int i = 0; i < currentNumbers.Length; i++)
            {
                currentNumbers[i] = ModifyNumber(currentNumbers[i]);
            }

            return string.Join("", currentNumbers);
        }

        public void Solve()
        {
            ShowAnswer(DebugSolve(), true);
        }

        private int AllSlots(int currentNumber, int orignalNumber)
        {
            if (currentNumber == 2)
            {
                PrintDebugLine("Replacing 2 with 5");
                currentNumber = 5;

                PrintCurrentNumber(currentNumber);
            }
            else if (currentNumber == 7)
            {
                PrintDebugLine("Replacing 7 with 0");
                currentNumber = 0;
                PrintCurrentNumber(currentNumber);
            }

            PrintDebugLine(
                "Adding the number of lit indicators and subtracting the number of unlit indicators"
            );
            currentNumber += Bomb.LitIndicatorsList.Count - Bomb.UnlitIndicatorsList.Count;
            PrintCurrentNumber(currentNumber);

            if (currentNumber % 3 == 0)
            {
                PrintDebugLine("Current number is a multiple of 3");
                return currentNumber + 4;
            }
            else if (currentNumber > 7)
            {
                PrintDebugLine("Current number is greater than 7");
                return currentNumber * 2;
            }
            else if (currentNumber < 3 && currentNumber % 2 == 0)
            {
                PrintDebugLine("Current number is less than 3 and is even");
                return currentNumber / 2;
            }
            else if (Bomb.Stereo.Visible || Bomb.Ps.Visible)
            {
                PrintDebugLine("Current number doesn't change");
                return currentNumber;
            }

            PrintDebugLine("Adding number of batteries to current number");
            return orignalNumber + Bomb.Battery;
        }

        private int Slot1()
        {
            int num = currentNumbers[0];

            if (num % 2 == 0 && num > 5)
            {
                PrintDebugLine("number is even and greater than 5");
                return num / 2;
            }

            if (primeValues.Contains(num))
            {
                PrintDebugLine("number is prime");
                return num + Bomb.LastDigit;
            }

            if (Bomb.Parallel.Visible)
            {
                PrintDebugLine("there is a parallel port on the bomb");
                return num * -1;
            }

            if (originalNumbers[1] % 2 == 1)
            {
                PrintDebugLine("the original digit to the right is odd");
                return num;
            }

            PrintDebugLine("None of the previous condition applied");
            return num - 2;
        }

        private int Slot2()
        {
            int num = currentNumbers[1];

            if (Bomb.Bob.VisibleNotLit)
            {
                PrintDebugLine("there is an unlit BOB indicator");
                return num;
            }

            if (num == 0)
            {
                PrintDebugLine("the number is 0");
                return originalNumbers[0];
            }

            int fibIndex = Array.IndexOf(fibonacciSequence, num);

            if (fibIndex != -1)
            {
                PrintDebugLine("the number is in the Fibonacci sequence");
                return num + fibonacciSequence[fibIndex + 1];
            }

            if (num >= 7)
            {
                PrintDebugLine("the number is greater than or equal to 7");
                return num + 4;
            }

            PrintDebugLine("None of the previous condition applied");
            return num * 3;
        }

        private int Slot3()
        {
            int num = currentNumbers[2];

            if (Bomb.Serial.Visible)
            {
                PrintDebugLine("there is a serial port on the bomb");
                return num + Bomb.LargestDigit;
            }

            int orignalNumCount = originalNumbers.Where(x => x == originalNumbers[2]).Count();

            if (orignalNumCount > 1)
            {
                PrintDebugLine(
                    "the original digit is the same as any of the other original digits"
                );
                return num;
            }

            if (num >= 5)
            {
                PrintDebugLine("the number is greater than or equal to 5");
                return binaryValueSum[originalNumbers[2]];
            }

            PrintDebugLine("None of the previous condition applied");
            return num + 1;
        }

        private int ModifyNumber(int num)
        {
            while (num < 0)
            {
                num += 10;
            }

            while (num > 9)
            {
                num -= 10;
            }

            return num;
        }

        private void PrintSlotNum(int index)
        {
            PrintDebugLine($"Slot {index + 1}'s current number is now {currentNumbers[index]}\n");
        }

        private void PrintCurrentNumber(int num)
        {
            PrintDebugLine($"Current number is now {num}\n");
        }
    }
}
