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
    /// Date: 4/27/21
    /// Purpose: Solves the complicated module
    /// </summary>
    public class ComplicatedWires : Module
    {
        //the list of wires on the module
        private List<ComplicatedWire> wires;

        //tells the user which wires to cut
        private List<string> directions;

        /// <summary>
        /// Creates the class that will solve the "Complicated Wires" module
        /// </summary>
        /// <param name="wires">the list of wires</param>
        /// <param name="bomb">used for edgework</param>
        /// <param name="logFileWriter">used to write to the log file</param>
        public ComplicatedWires(List<ComplicatedWire> wires, Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Complicated Wires")
        {
            this.wires = wires;
        }

        public string Solve(bool debug)
        {
            directions = new List<string>();

            for (int i = 0; i < wires.Count; i++)
            {
                PrintWire(i + 1, wires[i]);
            }

            PrintDebugLine("");

            //find which wire needs to be cut
            foreach (ComplicatedWire wire in wires)
            {
                if (wire.ColorPropety == Color.Blue)
                {
                    //if the wire is lit, cut if parllel port is there
                    if (wire.Lit)
                    {
                        AddParallelCondition();
                    }
                    //if the wire is unlit and has star, don't cut
                    else if (wire.Star)
                        directions.Add("Don't Cut");
                    //if the wire doesn't have a star, cut if last digit is even
                    else
                    {
                        AddEvenNumberCondition();
                    }
                }
                //if the wire is red,
                else if (wire.ColorPropety == Color.Red)
                {
                    //if the light is lit, cut if there's two or more batteries
                    if (wire.Lit)
                    {
                        AddBatteryCondition();
                    }
                    //if the light is unlit and has no star, cut if last digit is even
                    else if (!wire.Lit && !wire.Star)
                    {
                        AddEvenNumberCondition();
                    }
                    //if the light is unlit and there's a star, cut the wire
                    else
                        directions.Add("Cut");
                }
                else if (wire.ColorPropety == Color.Purple)
                {
                    if (wire.Lit && wire.Star)
                        directions.Add("Don't Cut");
                    //if the light is unlit, and star, cut if parallel port is there
                    else if (!wire.Lit && wire.Star)
                    {
                        AddParallelCondition();
                    }
                    //if the light is unlit and no star, cut if last digit is even

                    //if the light is lit, and no star, cut if last digit is even

                    else
                        AddEvenNumberCondition();
                }
                else
                {
                    if (wire.Lit && wire.Star)
                    {
                        AddBatteryCondition();
                    }
                    else if (wire.Lit)
                    {
                        directions.Add("Don't Cut");
                    }
                    else
                    {
                        directions.Add("Cut");
                    }
                }
            }

            string answer = "";

            for (int i = 0; i < directions.Count; i++)
            {
                answer += $"{i + 1}. {directions[i]}";

                if (i != directions.Count - 1)
                {
                    answer += "\n";
                }
            }

            if (!debug)
            {
                ShowAnswer(answer, true);
            }

            return answer;
        }

        /// <summary>
        /// Tells the user to cut the wire if there are two or more batteries
        /// </summary>
        private void AddBatteryCondition()
        {
            if (Bomb.Battery >= 2)
                directions.Add("Cut");
            else
                directions.Add("Don't Cut");
        }


        private void AddParallelCondition()
        {
            if (Bomb.PPVisuble)
                directions.Add("Cut");
            else
                directions.Add("Don't Cut");
        }

        private void AddEvenNumberCondition()
        {
            if (Bomb.LastDigit % 2 == 0)
                directions.Add("Cut");
            else
                directions.Add("Don't Cut");
        }

        /// <summary>
        /// Prints the wire information
        /// </summary>
        /// <param name="num">the index of the wire</param>
        /// <param name="wire">the wire itself</param>
        private void PrintWire(int num, ComplicatedWire wire)
        {
            PrintDebugLine(
                $"Wire {num} Color: {wire.ColorPropety} Light: {wire.Lit} Star: {wire.Star}"
            );
        }
    }

    public class ComplicatedWire
    {
        //PROPERTIES

        //the color of the wire
        public Color ColorPropety { get; set; }

        //if there's a star
        public bool Star { get; set; }

        //if the light is lit
        public bool Lit { get; set; }

        //CONSTURCTOR

        /// <summary>
        /// Creates a complicated wire
        /// </summary>
        /// <param name="color">the color of the wire</param>
        /// <param name="star">If thee's a star on the wire</param>
        /// <param name="lit">If the light is lit</param>
        public ComplicatedWire(Color color, bool star, bool lit)
        {
            ColorPropety = color;
            Star = star;
            Lit = lit;
        }

        //METHOD
    }
}
