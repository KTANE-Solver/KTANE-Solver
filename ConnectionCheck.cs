using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class ConnectionCheck : Module
    {
        private int[] topLeft;
        private int[] topRight;
        private int[] bottomLeft;
        private int[] bottomRight;
        public int targetIndex;
        public List<Node> nodes;

        public ConnectionCheck(
            int[] topLeft,
            int[] topRight,
            int[] bottomLeft,
            int[] bottomRight,
            Bomb bomb,
            StreamWriter logFileWriter
        ) : base(bomb, logFileWriter, "Connection Check")
        {
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;

            PrintDebugLine($"Top Left Pair {topLeft[0]},{topLeft[1]}");
            PrintDebugLine($"Top Right Pair {topRight[0]},{topRight[1]}");
            PrintDebugLine($"Bottom Left Pair {bottomLeft[0]},{bottomLeft[1]}");
            PrintDebugLine($"Bottom Right Pair {bottomRight[0]},{bottomRight[1]}\n");

            nodes = new List<Node>();

            for (int i = 1; i <= 8; i++)
            {
                nodes.Add(new Node(i));
            }
        }

        public void FindTargetIndex()
        {
            List<int> displayNumbers = new List<int>();

            displayNumbers.AddRange(topLeft);
            displayNumbers.AddRange(topRight);
            displayNumbers.AddRange(bottomLeft);
            displayNumbers.AddRange(bottomRight);

            //If the numbers on this module are all different, use the last character of the serial number.

            if (displayNumbers.Distinct().Count() == 8)
            {
                targetIndex = Bomb.SerialNumber.Length - 1;
                PrintDebugLine("Numbers are all different. Using index " + targetIndex);
            }
            //Otherwise, if there is more than one ''1'' on the module, look at the first character of the serial number.
            else if (displayNumbers.Count(x => x == 1) > 1)
            {
                targetIndex = 0;
                PrintDebugLine("More than one \'1\'. Using index " + targetIndex);
            }
            //Otherwise, if there is more than one ''7'' on the module, look at the last character of the serial number.
            else if (displayNumbers.Count(x => x == 7) > 1)
            {
                targetIndex = Bomb.SerialNumber.Length - 1;
                PrintDebugLine("More than one \'7\'. Using index " + targetIndex);
            }
            //Otherwise, if there are at least three ''2'' on the module, look at the second character of the serial number.
            else if (displayNumbers.Count(x => x == 2) > 2)
            {
                targetIndex = 1;
                PrintDebugLine("At least 3 \'2\'. Using index " + targetIndex);
            }
            //Otherwise, if there is no ''5'' on the module, look at the fifth character of the serial number.
            else if (displayNumbers.Count(x => x == 5) == 0)
            {
                targetIndex = 4;
                PrintDebugLine("At least 3 \'2\'. Using index " + targetIndex);
            }
            //Otherwise, if there are exactly two ''8''s on the module, look at the third character of the serial number.

            else if (displayNumbers.Count(x => x == 8) == 2)
            {
                targetIndex = 2;
                PrintDebugLine("At least 2 \'8\'. Using index " + targetIndex);
            }
            //Otherwise, if there are more than 6 batteries or no batteries on the bomb, look at the last character of the serial number.
            else if (Bomb.Battery > 6 || Bomb.Battery == 0)
            {
                targetIndex = Bomb.SerialNumber.Length - 1;
                PrintDebugLine("At least 6 or no batteries. Using index " + targetIndex);
            }
            //Otherwise, count the number of batteries on the bomb. Use that number to decide which character of the serial number you should look at.
            else
            {
                targetIndex = Bomb.Battery - 1;
                PrintDebugLine($"{Bomb.Battery} batteries. Using index " + targetIndex);
            }

            PrintDebugLine("");
        }

        public string CreateGraph()
        {
            char target = Bomb.SerialNumber[targetIndex];

            PrintDebugLine("Target Char: " + target + "\n");

            if ("SLIM".Contains(target))
            {
                nodes[0].AddNeighbor(nodes[1]);
                nodes[0].AddNeighbor(nodes[2]);
                nodes[0].AddNeighbor(nodes[5]);

                nodes[1].AddNeighbor(nodes[5]);

                nodes[2].AddNeighbor(nodes[3]);
                nodes[2].AddNeighbor(nodes[5]);

                nodes[3].AddNeighbor(nodes[4]);
                nodes[3].AddNeighbor(nodes[5]);
                nodes[3].AddNeighbor(nodes[6]);
                nodes[3].AddNeighbor(nodes[7]);

                nodes[4].AddNeighbor(nodes[5]);
                nodes[4].AddNeighbor(nodes[6]);

                nodes[6].AddNeighbor(nodes[7]);

                PrintDebugLine("Using SLIM graph \n");

                return "SLIM";
            }
            else if ("15BRO".Contains(target))
            {
                nodes[0].AddNeighbor(nodes[1]);
                nodes[0].AddNeighbor(nodes[6]);

                nodes[1].AddNeighbor(nodes[6]);

                nodes[2].AddNeighbor(nodes[3]);
                nodes[2].AddNeighbor(nodes[7]);

                nodes[3].AddNeighbor(nodes[7]);

                nodes[4].AddNeighbor(nodes[5]);
                nodes[4].AddNeighbor(nodes[6]);

                nodes[5].AddNeighbor(nodes[6]);

                PrintDebugLine("Using 15BRO graph \n");

                return "15BRO";
            }
            else if ("20DGT".Contains(target))
            {
                nodes[0].AddNeighbor(nodes[1]);
                nodes[0].AddNeighbor(nodes[2]);

                nodes[1].AddNeighbor(nodes[3]);
                nodes[1].AddNeighbor(nodes[6]);

                nodes[2].AddNeighbor(nodes[4]);
                nodes[2].AddNeighbor(nodes[6]);

                nodes[3].AddNeighbor(nodes[5]);
                nodes[3].AddNeighbor(nodes[6]);
                nodes[3].AddNeighbor(nodes[7]);

                nodes[4].AddNeighbor(nodes[5]);
                nodes[4].AddNeighbor(nodes[6]);

                nodes[5].AddNeighbor(nodes[7]);

                PrintDebugLine("Using 20DGT graph \n");

                return "20DGT";
            }
            else if ("34XYZ".Contains(target))
            {
                nodes[0].AddNeighbor(nodes[1]);
                nodes[0].AddNeighbor(nodes[3]);
                nodes[0].AddNeighbor(nodes[5]);

                nodes[1].AddNeighbor(nodes[2]);
                nodes[1].AddNeighbor(nodes[3]);

                nodes[3].AddNeighbor(nodes[6]);

                nodes[4].AddNeighbor(nodes[5]);

                nodes[5].AddNeighbor(nodes[6]);
                nodes[5].AddNeighbor(nodes[7]);

                nodes[6].AddNeighbor(nodes[7]);

                PrintDebugLine("Using 34XYZ graph \n");

                return "34XYZ";
            }
            else if ("7HPJ".Contains(target))
            {
                nodes[0].AddNeighbor(nodes[1]);
                nodes[0].AddNeighbor(nodes[2]);

                nodes[1].AddNeighbor(nodes[2]);

                nodes[3].AddNeighbor(nodes[5]);
                nodes[3].AddNeighbor(nodes[6]);

                nodes[4].AddNeighbor(nodes[5]);
                nodes[4].AddNeighbor(nodes[6]);

                PrintDebugLine("Using 7HPJ graph \n");

                return "7HPJ";
            }
            else if ("6WUF".Contains(target))
            {
                nodes[0].AddNeighbor(nodes[1]);
                nodes[0].AddNeighbor(nodes[5]);
                nodes[0].AddNeighbor(nodes[6]);

                nodes[1].AddNeighbor(nodes[2]);
                nodes[1].AddNeighbor(nodes[6]);
                nodes[1].AddNeighbor(nodes[7]);

                nodes[2].AddNeighbor(nodes[4]);
                nodes[2].AddNeighbor(nodes[5]);
                nodes[2].AddNeighbor(nodes[7]);

                nodes[3].AddNeighbor(nodes[4]);
                nodes[3].AddNeighbor(nodes[6]);
                nodes[3].AddNeighbor(nodes[7]);

                nodes[4].AddNeighbor(nodes[5]);
                nodes[4].AddNeighbor(nodes[6]);

                nodes[5].AddNeighbor(nodes[6]);

                nodes[6].AddNeighbor(nodes[7]);

                PrintDebugLine("Using 6WUF graph \n");

                return "6WUF";
            }
            else if ("8CAKE".Contains(target))
            {
                nodes[0].AddNeighbor(nodes[1]);
                nodes[0].AddNeighbor(nodes[2]);
                nodes[0].AddNeighbor(nodes[5]);
                nodes[0].AddNeighbor(nodes[7]);

                nodes[1].AddNeighbor(nodes[3]);
                nodes[1].AddNeighbor(nodes[5]);

                nodes[2].AddNeighbor(nodes[3]);
                nodes[2].AddNeighbor(nodes[5]);
                nodes[2].AddNeighbor(nodes[6]);
                nodes[2].AddNeighbor(nodes[7]);

                nodes[3].AddNeighbor(nodes[4]);
                nodes[3].AddNeighbor(nodes[5]);
                nodes[3].AddNeighbor(nodes[6]);

                nodes[4].AddNeighbor(nodes[6]);
                nodes[4].AddNeighbor(nodes[7]);

                nodes[6].AddNeighbor(nodes[7]);

                PrintDebugLine("Using 8CAKE graph \n");

                return "8CAKE";
            }
            else
            {
                nodes[0].AddNeighbor(nodes[1]);
                nodes[0].AddNeighbor(nodes[3]);
                nodes[0].AddNeighbor(nodes[7]);

                nodes[1].AddNeighbor(nodes[2]);
                nodes[1].AddNeighbor(nodes[5]);
                nodes[1].AddNeighbor(nodes[6]);

                nodes[2].AddNeighbor(nodes[3]);
                nodes[2].AddNeighbor(nodes[5]);
                nodes[2].AddNeighbor(nodes[6]);

                nodes[3].AddNeighbor(nodes[4]);

                nodes[4].AddNeighbor(nodes[5]);
                nodes[4].AddNeighbor(nodes[7]);

                nodes[5].AddNeighbor(nodes[6]);

                nodes[6].AddNeighbor(nodes[7]);

                PrintDebugLine("Using 9QVN graph \n");

                return "9QVN";
            }
        }

        public string Solve(bool debug)
        {
            FindTargetIndex();

            CreateGraph();

            string answer = string.Join(
                "\n",
                new string[]
                {
                    "\nTop Left: " + GetAnswer(topLeft),
                    "Top Right: " + GetAnswer(topRight),
                    "Bottom Left: " + GetAnswer(bottomLeft),
                    "Bottom Right: " + GetAnswer(bottomRight)
                }
            );

            if (!debug)
            { 
                ShowAnswer(answer, true);
            }

            return answer;
        }

        private string GetAnswer(int[] pairs)
        {
            Node node1 = nodes[pairs[0] - 1];
            Node node2 = nodes[pairs[1] - 1];

            return node1.neighbors.Contains(node2) ? "Green" : "Red";
        }

        public class Node
        {
            public int Num { get; }
            public List<Node> neighbors;

            public Node(int num)
            {
                Num = num;
                neighbors = new List<Node>();
            }

            public void AddNeighbor(Node node)
            {
                neighbors.Add(node);
                node.neighbors.Add(this);
            }
        }
    }
}
