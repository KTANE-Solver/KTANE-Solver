using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date: 4/25/21 
    /// Purpose: Sovles the Wires module
    /// </summary>
    class Wires : Module
    {
        //=========ENUMS=========

        //the color represents each wire
        public enum Wire
        {
            BLACK,
            BLUE,
            RED,
            YELLOW,
            WHITE,
        }

        //=========PROPERTIES=========

        //A list of all the wires

        private List<Wire> WireList { get; set; }

        //the number of wires on the bomb
        private int WireNum { get { return WireList.Count; } }





        //=========CONSTRUCTORS=========

        /// <summary>
        /// Sets up the class that is going to solve
        /// the "Wires" module
        /// </summary>
        /// <param name="color1">the color of the first wire</param>
        /// <param name="color2">the color of the second wire</param>
        /// <param name="color3">the color of the third wire</param>
        /// <param name="color4">the color of the fourth wire (if appicalbe)</param>
        /// <param name="color5">the color of the fifth wire (if appicalbe)</param>
        /// <param name="color6">the color of the sixth wire (if appicalbe)</param>
        /// <param name="bomb">holds edgework needed to solve bomb</param>
        /// <param name="logFileWriter">writes to the logfile</param>
        public Wires(String color1, String color2, String color3, String color4, String color5, String color6, Bomb bomb, StreamWriter logFileWriter) : base(bomb, logFileWriter, "Wires")
        {
            WireList = new List<Wire>();

            AddWire(color1);
            AddWire(color2);
            AddWire(color3);
            AddWire(color4);
            AddWire(color5);
            AddWire(color6);

            for (int i = 0; i < WireList.Count; i++)
            {
                Console.WriteLine($"Wire {i + 1}: {WireList[i]}\n");
            }
        }

        //=========METHODS=========

        /// <summary>
        /// Converts string and adds color to WireList
        /// </summary>
        /// <param name="color">the string that will be converted</param>
        private void AddWire(String color)
        {
            color = color.ToUpper();

            if (color == null || color == "")
                return;

            Wire wire = (Wire)Enum.Parse(typeof(Wire), color);

            WireList.Add(wire);
        }

        /// <summary>
        /// Solves the wire module
        /// </summary>
        public void Solve()
        {
            //which wire to cut
            String place = "";

            switch (WireNum)
            {
                case 3:
                    //If there are no red wires, cut the second wire.
                    if (ColorCount(Wire.RED) == 0)
                        place = "2nd";

                    //Otherwise, if the last wire is white, cut the last wire.
                    else if (WireList[2] == Wire.WHITE)
                        place = "3rd";

                    //Otherwise, if there is more than one blue wire, cut the last blue wire.
                    else if (ColorCount(Wire.BLUE) > 1)
                    {
                        //if the last wire is blue, cut that one
                        if (WireList[2] == Wire.BLUE)
                            place = "3rd";

                        //else cut the second one
                        else
                            place = "2nd";
                    }
                    //Otherwise, cut the last wire.
                    else
                        place = "3rd";
                    break;

                case 4:
                    //If there is more than one red wire and the last digit of the serial number is odd, cut the last red wire.
                    if (ColorCount(Wire.RED) > 1 && Bomb.LastDigit % 2 == 1)
                        place = "4th";

                    //Otherwise, if the last wire is yellow and there are no red wires, cut the first wire.
                    else if (WireList[3] == Wire.YELLOW && ColorCount(Wire.RED) == 0)
                        place = "1st";

                    //Otherwise, if there is exactly one blue wire, cut the first wire.
                    else if (ColorCount(Wire.BLUE) == 1)
                        place = "1st";

                    //Otherwise, if there is more than one yellow wire, cut the last wire.
                    else if (ColorCount(Wire.YELLOW) > 1)
                        place = "4th";

                    //Otherwise, cut the second wire.
                    else
                        place = "2nd";
                    break;

                case 5:
                    //If the last wire is black and the last digit of the serial number is odd, cut the fourth wire.
                    if (WireList[4] == Wire.BLACK && Bomb.LastDigit % 2 == 1)
                        place = "4th";

                    //Otherwise, if there is exactly one red wire and there is more than one yellow wire, cut the first wire.
                    else if (ColorCount(Wire.RED) == 1 && ColorCount(Wire.YELLOW) > 1)
                        place = "1st";

                    //Otherwise, if there are no black wires, cut the second wire
                    else if (ColorCount(Wire.BLACK) == 0)
                        place = "2nd";

                    //Otherwise, cut the first wire.
                    else
                        place = "1st";
                    break;

                case 6:
                    //If there are no yellow wires and the last digit of the serial number is odd, cut the third wire.
                    if (ColorCount(Wire.YELLOW) == 0 && Bomb.LastDigit % 2 == 1)
                        place = "3rd";

                    //Otherwise, if there is exactly one yellow wire and there is more than one white wire, cut the fourth wire.
                    else if (ColorCount(Wire.YELLOW) == 1 && ColorCount(Wire.WHITE) > 1)
                        place = "4th";

                    //Otherwise, if there are no red wires, cut the last wire.
                    else if (ColorCount(Wire.RED) == 0)
                        place = "6th";

                    //Otherwise, cut the fourth wire.
                    else
                        place = "4th";

                    break;
            }

            ShowAnswer($"Cut the {place} wire", true);

            Console.WriteLine($"Cutting the {place} wire\n");
        }

        /// <summary>
        /// Tells how many wires of a certain color
        /// there are
        /// </summary>
        /// <param name="color">the color of the wire that is being searched for</param>
        /// <returns>the number of wires of a certain color</returns>
        private int ColorCount(Wire color)
        {
            int num = 0;

            foreach (Wire wire in WireList)
            {
                if (wire == color)
                    num++;
            }

            return num;
        }



    }
}
