using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class Plate
    {
        public bool pp { get;}
        public bool rca { get; }
        public bool serial { get; }
        public bool rj { get; }
        public bool dvi { get; }
        public bool ps { get; }

        public int portNum { get; }

        public Plate(bool pp, bool rca, bool serial, bool rj, bool dvi, bool ps)
        { 
            this.pp = pp;
            this.rca = rca;
            this.serial = serial;
            this.rj = rj;
            this.dvi = dvi;
            this.ps = ps;

            portNum = 0;

            if (pp)
            {
                portNum++;
            }

            if(rca) 
            {
                portNum++;
            }

            if(serial)
            {
                portNum++;
            }

            if(rj)
            {
                portNum++;
            }

            if (dvi)
            {
                portNum++;
            }

            if (ps)
            {
                portNum++;
            }
        }

        public bool OnlyPP()
        {
            return pp && !rca && !serial && !rj && !dvi && !ps;
        }

        public bool OnlyRCA()
        {
            return !pp && rca && !serial && !rj && !dvi && !ps;
        }

        public bool OnlySerial ()
        {
            return !pp && !rca && serial && !rj && !dvi && !ps;
        }

        public bool OnlyRJ()
        {
            return !pp && !rca && !serial && rj && !dvi && !ps;
        }

        public bool OnlyDVI()
        {
            return !pp && !rca && !serial && !rj && dvi && !ps;
        }

        public bool OnlyPS()
        {
            return !pp && !rca && !serial && !rj && !dvi && ps;
        }

        public bool Empty()
        { 
            return !pp && !rca && !serial && !rj && !dvi && !ps;
        }
    }
}
