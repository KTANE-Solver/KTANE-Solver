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
    /// Purpose: Represnts a indicator
    /// </summary>
    public class Indicator
    {
        //===============FIELDS===============

        //the nme of te indicator
        private String name;

        //if the indicator is visible on the bomb
        private bool visible;

        //if the indicator is lit
        private bool lit;

        //===============PROPERTIES===============

        public String Name
        {
            get { return name; }
        }

        public bool Visible
        {
            get { return visible; }
        }

        public bool Lit
        {
            get { return lit; }
        }

        //Tells if this indicator can actually appear on the bomb
        public bool ValidIndicator
        {
            get { return !(!visible && lit); }
        }

        //tells if an indicator is visible and not lit
        public bool VisibleNotLit
        {
            get { return visible && !lit; }
        }

        public bool VisibleAndLit
        {
            get { return visible && lit; }
        }

        //===============CONSTRUCTOR===============
        /// <summary>
        /// Creates an indicator
        /// </summary>
        /// <param name="name">the name of thie indicaotr</param>
        /// <param name="visible">if the indicator is on the bomb</param>
        /// <param name="lit">if the indicator is lit (can't be lit and invisible)</param>
        public Indicator(String name, bool visible, bool lit)
        {
            this.name = name;
            this.visible = visible;

            if (!visible)
            {
                lit = false;
            }
            else
            {
                this.lit = lit;
            }
        }

        //===============NETHODS===============
    }
}
