using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the number pad module
    /// </summary>
    public class NumberPad : Module
    {
        int firstNumber;
        int secondNumber;
        int thirdNumber;
        int fourthNumber;

        Color zeroColor;
        Color oneColor;
        Color twoColor;
        Color threeColor;
        Color fourColor;
        Color fiveColor;
        Color sixColor;
        Color sevenColor;
        Color eightColor;
        Color nineColor;

        NumberPadTree tree1;
        NumberPadTree tree2;
        NumberPadTree tree3;
        NumberPadTree tree4;

        public NumberPad(
            Color zeroColor,
            Color oneColor,
            Color twoColor,
            Color threeColor,
            Color fourColor,
            Color fiveColor,
            Color sixColor,
            Color sevenColor,
            Color eightColor,
            Color nineColor,
            Bomb bomb,
            StreamWriter logFileWriter
        ) : base(bomb, logFileWriter, "Number Pad")
        {
            this.zeroColor = zeroColor;
            this.oneColor = oneColor;
            this.twoColor = twoColor;
            this.threeColor = threeColor;
            this.fourColor = fourColor;
            this.fiveColor = fiveColor;
            this.sixColor = sixColor;
            this.sevenColor = sevenColor;
            this.eightColor = eightColor;
            this.nineColor = nineColor;

            SetUpTrees();
        }

        private void SetUpTrees()
        {
            //tree 1
            //level 1
            tree1 = new NumberPadTree(new NumberPadNode(2));

            //level 2
            tree1.Root.Children = new List<NumberPadNode>
            {
                new NumberPadNode(2),
                new NumberPadNode(3),
                new NumberPadNode(9),
                new NumberPadNode(0)
            };

            //level 3
            tree1.Root.Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(4),
                new NumberPadNode(3)
            };
            tree1.Root.Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(9),
                new NumberPadNode(4)
            };
            tree1.Root.Children[2].Children = new List<NumberPadNode>
            {
                new NumberPadNode(0),
                new NumberPadNode(9)
            };
            tree1.Root.Children[3].Children = new List<NumberPadNode>
            {
                new NumberPadNode(7),
                new NumberPadNode(9)
            };

            //level 4
            tree1.Root.Children[0].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(6),
                new NumberPadNode(8)
            };
            tree1.Root.Children[0].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(1),
                new NumberPadNode(3)
            };

            tree1.Root.Children[1].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(5),
                new NumberPadNode(1)
            };
            tree1.Root.Children[1].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(3),
                new NumberPadNode(6)
            };

            tree1.Root.Children[2].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(9),
                new NumberPadNode(7)
            };
            tree1.Root.Children[2].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(8),
                new NumberPadNode(9)
            };

            tree1.Root.Children[3].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(8),
                new NumberPadNode(9)
            };
            tree1.Root.Children[3].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(4),
                new NumberPadNode(0)
            };

            //tree 2
            //level 1
            tree2 = new NumberPadTree(new NumberPadNode(5));

            //level 2
            tree2.Root.Children = new List<NumberPadNode>
            {
                new NumberPadNode(2),
                new NumberPadNode(6),
                new NumberPadNode(0),
                new NumberPadNode(9)
            };

            //level 3
            tree2.Root.Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(6),
                new NumberPadNode(4)
            };
            tree2.Root.Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(6),
                new NumberPadNode(2)
            };
            tree2.Root.Children[2].Children = new List<NumberPadNode>
            {
                new NumberPadNode(2),
                new NumberPadNode(8)
            };
            tree2.Root.Children[3].Children = new List<NumberPadNode>
            {
                new NumberPadNode(7),
                new NumberPadNode(4)
            };

            //level 4
            tree2.Root.Children[0].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(0),
                new NumberPadNode(3)
            };
            tree2.Root.Children[0].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(1),
                new NumberPadNode(7)
            };

            tree2.Root.Children[1].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(3),
                new NumberPadNode(5)
            };
            tree2.Root.Children[1].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(8),
                new NumberPadNode(5)
            };

            tree2.Root.Children[2].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(6),
                new NumberPadNode(0)
            };
            tree2.Root.Children[2].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(6),
                new NumberPadNode(0)
            };

            tree2.Root.Children[3].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(9),
                new NumberPadNode(8)
            };
            tree2.Root.Children[3].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(2),
                new NumberPadNode(9)
            };

            //tree 3
            //level 1
            tree3 = new NumberPadTree(new NumberPadNode(7));

            //level 2
            tree3.Root.Children = new List<NumberPadNode>
            {
                new NumberPadNode(4),
                new NumberPadNode(7),
                new NumberPadNode(2),
                new NumberPadNode(0)
            };

            //level 3
            tree3.Root.Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(9),
                new NumberPadNode(8)
            };
            tree3.Root.Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(1),
                new NumberPadNode(5)
            };
            tree3.Root.Children[2].Children = new List<NumberPadNode>
            {
                new NumberPadNode(8),
                new NumberPadNode(0)
            };
            tree3.Root.Children[3].Children = new List<NumberPadNode>
            {
                new NumberPadNode(0),
                new NumberPadNode(9)
            };

            //level 4
            tree3.Root.Children[0].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(1),
                new NumberPadNode(4)
            };
            tree3.Root.Children[0].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(0),
                new NumberPadNode(8)
            };

            tree3.Root.Children[1].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(8),
                new NumberPadNode(5)
            };
            tree3.Root.Children[1].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(8),
                new NumberPadNode(3)
            };

            tree3.Root.Children[2].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(6),
                new NumberPadNode(0)
            };
            tree3.Root.Children[2].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(8),
                new NumberPadNode(2)
            };

            tree3.Root.Children[3].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(3),
                new NumberPadNode(4)
            };
            tree3.Root.Children[3].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(0),
                new NumberPadNode(3)
            };

            //tree 4
            //level 1
            tree4 = new NumberPadTree(new NumberPadNode(8));

            //level 2
            tree4.Root.Children = new List<NumberPadNode>
            {
                new NumberPadNode(9),
                new NumberPadNode(6),
                new NumberPadNode(3),
                new NumberPadNode(1)
            };

            //level 3
            tree4.Root.Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(6),
                new NumberPadNode(0)
            };
            tree4.Root.Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(9),
                new NumberPadNode(2)
            };
            tree4.Root.Children[2].Children = new List<NumberPadNode>
            {
                new NumberPadNode(3),
                new NumberPadNode(6)
            };
            tree4.Root.Children[3].Children = new List<NumberPadNode>
            {
                new NumberPadNode(2),
                new NumberPadNode(3)
            };

            //level 4
            tree4.Root.Children[0].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(7),
                new NumberPadNode(5)
            };
            tree4.Root.Children[0].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(6),
                new NumberPadNode(1)
            };

            tree4.Root.Children[1].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(2),
                new NumberPadNode(9)
            };
            tree4.Root.Children[1].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(0),
                new NumberPadNode(7)
            };

            tree4.Root.Children[2].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(6),
                new NumberPadNode(9)
            };
            tree4.Root.Children[2].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(0),
                new NumberPadNode(6)
            };

            tree4.Root.Children[3].Children[0].Children = new List<NumberPadNode>
            {
                new NumberPadNode(3),
                new NumberPadNode(8)
            };
            tree4.Root.Children[3].Children[1].Children = new List<NumberPadNode>
            {
                new NumberPadNode(3),
                new NumberPadNode(5)
            };
        }

        public string Solve(bool debug)
        {
            NumberPadNode currentNode;

            //If three or more of the numbered buttons are colored yellow, take the first path.
            if (ColorNum(Color.Yellow) >= 3)
            {
                currentNode = tree1.Root;
            }
            //If all three of the numbered buttons 4, 5, and 6 are colored white, blue, or red, take the second path.
            else if (IsAmerican(fourColor) && IsAmerican(fiveColor) && IsAmerican(sixColor))
            {
                currentNode = tree2.Root;
            }
            //If the serial number contains a vowel, take the third path.
            else if (Bomb.HasVowel)
            {
                currentNode = tree3.Root;
            }
            //Otherwise, take the fourth path.
            else
            {
                currentNode = tree4.Root;
            }

            firstNumber = currentNode.Data;

            System.Diagnostics.Debug.WriteLine($"Level 1: {firstNumber}\n");
            System.Diagnostics.Debug.WriteLine($"Code is {firstNumber}\n");

            //If there are at least two blue numbered buttons and at least three green buttons, take the first path.
            if (ColorNum(Color.Blue) >= 2 && ColorNum(Color.Green) >= 3)
            {
                currentNode = currentNode.Children[0];
            }
            //If the numbered button 5 isn't blue nor white, take the second path.
            else if (!IsColor(Color.White, fiveColor) && !IsColor(Color.Blue, fiveColor))
            {
                currentNode = currentNode.Children[1];
            }
            //If there are fewer than two ports on the bomb, take the third path.
            else if (Bomb.PortNum < 2)
            {
                currentNode = currentNode.Children[2];
            }
            //Otherwise, take the fourth path, and if the top row of buttons contains a green button, subtract 1 from the first digit(if it's 0, it becomes 9).
            else
            {
                currentNode = currentNode.Children[3];

                if (
                    IsColor(Color.Green, sevenColor)
                    || IsColor(Color.Green, eightColor)
                    || IsColor(Color.Green, nineColor)
                )
                {
                    if (firstNumber == 0)
                        firstNumber = 9;
                    else
                        firstNumber--;
                }
            }

            secondNumber = currentNode.Data;

            System.Diagnostics.Debug.WriteLine($"Level 2: {secondNumber}\n");
            System.Diagnostics.Debug.WriteLine($"Code is {firstNumber}{secondNumber}\n");

            //tells if you have to reverse code
            bool reverse = false;

            //If there are more than two white numbered buttons and more than two yellow numbered buttons, take the first path.
            if (ColorNum(Color.Yellow) > 2 && ColorNum(Color.White) > 2)
            {
                currentNode = currentNode.Children[0];
            }
            //Otherwise, take the second path and reverse the current 3 - digit code.
            else
            {
                currentNode = currentNode.Children[1];

                reverse = true;
            }

            thirdNumber = currentNode.Data;

            System.Diagnostics.Debug.WriteLine($"Level 3: {thirdNumber}\n");

            System.Diagnostics.Debug.WriteLine(
                $"Code is {firstNumber}{secondNumber}{thirdNumber}\n"
            );

            if (reverse)
            {
                int temp = firstNumber;

                firstNumber = thirdNumber;

                thirdNumber = temp;

                System.Diagnostics.Debug.WriteLine(
                    $"Reversing. Code is {firstNumber}{secondNumber}{thirdNumber}\n"
                );
            }

            //If there are 2 or fewer yellow numbered buttons, take the first path and add 1 to each digit (if a digit is 9, it becomes 0).

            bool addDigit = false;

            if (ColorNum(Color.Yellow) <= 2)
            {
                currentNode = currentNode.Children[0];

                addDigit = true;
            }
            //Otherwise, take the second path.
            else
            {
                currentNode = currentNode.Children[1];
            }

            fourthNumber = currentNode.Data;

            System.Diagnostics.Debug.WriteLine($"Level 4: {fourthNumber}\n");

            System.Diagnostics.Debug.WriteLine(
                $"Code is {firstNumber}{secondNumber}{thirdNumber}{fourthNumber}\n"
            );

            if (addDigit)
            {
                firstNumber = AddDigit(firstNumber);
                secondNumber = AddDigit(secondNumber);
                thirdNumber = AddDigit(thirdNumber);
                fourthNumber = AddDigit(fourthNumber);

                System.Diagnostics.Debug.WriteLine(
                    $"Adding one to each digit is {firstNumber}{secondNumber}{thirdNumber}{fourthNumber}\n"
                );
            }

            bool criteriaMet = false;

            //If the last digit of the serial number is even, swap the first and third digits.
            if (Bomb.LastDigit % 2 == 0)
            {
                int temp = firstNumber;

                firstNumber = thirdNumber;

                thirdNumber = temp;

                criteriaMet = true;

                System.Diagnostics.Debug.WriteLine(
                    $"Last digit is even. Code is: {firstNumber}{secondNumber}{thirdNumber}{fourthNumber}\n"
                );
            }

            //If there are an odd number of batteries, swap the second and third digits.
            if (Bomb.Battery % 2 == 1)
            {
                int temp = secondNumber;

                secondNumber = thirdNumber;

                thirdNumber = temp;

                criteriaMet = true;

                System.Diagnostics.Debug.WriteLine(
                    $"Odd number of batteries. Code is: {firstNumber}{secondNumber}{thirdNumber}{fourthNumber}\n"
                );
            }

            //If neither of the above criteria is met, swap the first and fourth digits.
            if (!criteriaMet)
            {
                int temp = firstNumber;

                firstNumber = fourthNumber;

                fourthNumber = temp;

                System.Diagnostics.Debug.WriteLine(
                    $"First two conditions not met. Code is: {firstNumber}{secondNumber}{thirdNumber}{fourthNumber}\n"
                );
            }

            //Finally, if the sum of all the digits in the code is even, reverse the code.
            if ((firstNumber + secondNumber + thirdNumber + fourthNumber) % 2 == 0)
            {
                int temp = firstNumber;

                firstNumber = fourthNumber;

                fourthNumber = temp;

                temp = secondNumber;

                secondNumber = thirdNumber;

                thirdNumber = temp;

                System.Diagnostics.Debug.WriteLine(
                    $"Sum of digits is even. Code is: {firstNumber}{secondNumber}{thirdNumber}{fourthNumber}\n"
                );
            }

            int answer = firstNumber * 1000 + secondNumber * 100 + thirdNumber * 10 + fourthNumber;
            answer %= 10000;

            string strAnswer = answer.ToString("D4");

            if (!debug)
            {
                ShowAnswer(strAnswer, true);
            }
            
            return strAnswer;
        }

        private int AddDigit(int digit)
        {
            if (digit == 9)
                return 0;

            return digit + 1;
        }

        /// <summary>
        /// Tells how many buttons are a certain color
        /// </summary>
        private int ColorNum(Color color)
        {
            int num = 0;

            if (IsColor(color, zeroColor))
                num++;

            if (IsColor(color, oneColor))
                num++;

            if (IsColor(color, twoColor))
                num++;

            if (IsColor(color, threeColor))
                num++;

            if (IsColor(color, fourColor))
                num++;

            if (IsColor(color, fiveColor))
                num++;

            if (IsColor(color, sixColor))
                num++;

            if (IsColor(color, sevenColor))
                num++;

            if (IsColor(color, eightColor))
                num++;

            if (IsColor(color, nineColor))
                num++;

            return num;
        }

        /// <summary>
        /// Tells if a button is a certain color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        private bool IsColor(Color color, Color button)
        {
            return color == button;
        }

        /// <summary>
        /// Tells if a button is red, white, or blue
        /// </summary>
        /// <returns></returns>
        private bool IsAmerican(Color button)
        {
            return IsColor(Color.Red, button)
                || IsColor(Color.White, button)
                || IsColor(Color.Blue, button);
        }

        public class NumberPadTree
        {
            public NumberPadNode Root { get; }

            public NumberPadTree(NumberPadNode root)
            {
                Root = root;
            }
        }

        /// <summary>
        /// used to set up a tree
        /// </summary>
        public class NumberPadNode
        {
            public int Data { get; }

            public List<NumberPadNode> Children { get; set; }

            public NumberPadNode(int data)
            {
                Data = data;
            }
        }
    }
}
