using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date: 2/27/21
    /// Purpose: Represnts a port
    /// </summary>
    public class Port
    {
        //===============FIELDS===============
        //the name of the port
        private String name;

        //the number of this port on the bomb
        private int num;

        //===============PROPERTIES===============
        public String Name
        {
            get { return name; }
        }

        public int Num
        {
            get { return num; }
        }

        //tells if the port is visible on the
        //bomb
        public bool Visible
        {
            get { return num > 0; }
        }

        //===============PROPERTIES===============
        /// <summary>
        /// Creates the port
        /// </summary>
        /// <param name="name">the name of the port</param>
        /// <param name="num">how many of this port are on the bomb</param>
        public Port(String name, int num)
        {
            this.name = name;
            this.num = num;
        }

        //===============METHODS===============
    }
}
