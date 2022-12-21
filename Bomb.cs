using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date: 2/27/21
    /// Purpose: Represnts the bomb, will hold all of the edgework
    /// </summary>
    public class Bomb
    {
        //===============ENUM===============

        //an enum that represents the days of the week

        //===============FIELDS===============

        //the day of the week
        private Day day;

        //the seraial number
        private String serialNumber;

        //the number of batteries
        private int battery;

        //the number of battery holders
        private int batteryHolder;

        public List<Plate> Plates { get; }

        //list of lit indicators
        public List<Indicator> LitIndicatorsList { get; }

        //list of unlit indicators
        public List<Indicator> UnlitIndicatorsList { get; }

        //indicator bob
        private Indicator bob;

        //indicator car
        private Indicator car;

        //indicator clr
        private Indicator clr;

        //indicator frk
        private Indicator frk;

        //indicator frq
        private Indicator frq;

        //indicator ind
        private Indicator ind;

        //indicator msa
        private Indicator msa;

        //indicator nsa
        private Indicator nsa;

        //indicator snd
        private Indicator snd;

        //indicator sig
        private Indicator sig;

        //indicator trn
        private Indicator trn;

        //if there is an empty port plate
        public bool EmptyPortPlate { get; }

        //the number of strikes
        private int strike;

        //===============PROPERTIES===============
        public Day Day
        {
            get { return day; }
        }

        public String SerialNumber
        {
            get { return serialNumber; }
        }

        //tells if this serial number
        public bool ValidSerialNumber
        {
            //the serial number must have at least one number
            //the serial number must have at least on letter
            //the serial number's last character must be a number

            get
            {
                bool lastCharIsNum = false;
                bool hasLetter = false;

                for (int i = 0; i < serialNumber.Length; i++)
                {
                    if (!hasLetter && serialNumber[i] >= 65 && serialNumber[i] <= 90)
                    {
                        hasLetter = true;
                    }

                    if (
                        i == serialNumber.Length - 1
                        && serialNumber[i] >= 48
                        && serialNumber[i] <= 57
                    )
                    {
                        lastCharIsNum = true;
                    }
                }

                return lastCharIsNum && hasLetter;
            }
        }

        //tells the first digit in the serial number
        public int FirstDigit
        {
            get
            {
                for (int i = 0; i < serialNumber.Length; i++)
                {
                    if (serialNumber[i] >= 48 && serialNumber[i] <= 57)
                    {
                        return int.Parse("" + serialNumber[i]);
                    }
                }

                //should never happen
                return -1;
            }
        }

        //tells the last digit in the serial number
        public int LastDigit
        {
            get { return int.Parse("" + serialNumber[serialNumber.Length - 1]); }
        }

        //tells if there is an even digit in the serial number
        public bool EvenDigit
        {
            get
            {
                foreach (char c in serialNumber)
                {
                    if (c >= 48 && c <= 57)
                    {
                        int num = int.Parse("" + c);

                        if (num % 2 == 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public char FirstLetter
        {
            get
            {
                return serialNumber.Where(x => char.IsLetter(x)).First();
            }
        }

        //tells the last letter in the serialNumber
        public char LastLetter
        {
            get
            {
                for (int i = serialNumber.Length - 1; i > -1; i--)
                {
                    if (serialNumber[i] >= 65 && serialNumber[i] <= 90)
                    {
                        return serialNumber[i];
                    }
                }

                //this should never happen
                return serialNumber[0];
            }
        }

        //Tells if the last letter is a vowel
        public bool LastLetterIsVowel
        {
            get { return Regex.IsMatch("" + LastLetter, @"[A,E,I,O,U]"); }
        }

        //tells how many digits are in the serial number
        public int DigitNum
        {
            get { return serialNumber.Where(x => x >= 48 && x <= 57).Count(); }
        }

        //tells how many digits are in the serial number
        public int LetterNum
        {
            get { return serialNumber.Where(x => x >= 65 && x <= 90).Count(); }
        }

        //tells how the sum of digits in the serial number
        public int DigitSum
        {
            get
            {
                int sum = 0;

                for (int i = 0; i < serialNumber.Length; i++)
                {
                    if (serialNumber[i] >= 48 && serialNumber[i] <= 57)
                    {
                        sum += int.Parse("" + serialNumber[i]);
                    }
                }

                return sum;
            }
        }

        public int LargestDigit
        {
            get
            {
                int highest = -1;

                foreach (char c in serialNumber)
                {
                    if (Char.IsDigit(c) && int.Parse("" + c) > highest)
                    {
                        highest = int.Parse("" + c);
                    }
                }

                return highest;
            }
        }

        //the number of vowles in the serial number
        public int VowelNum
        {
            get { return serialNumber.Where(x => Regex.IsMatch("" + x, @"[A,E,I,O,U]")).Count(); }
        }

        //tells if the serial number has a vowel
        public bool HasVowel
        {
            get { return Regex.IsMatch(serialNumber, @"[A,E,I,O,U]"); }
        }

        public int Battery
        {
            get { return battery; }
        }

        public int BatteryHolder
        {
            get { return batteryHolder; }
        }

        //the number AA batteries on the bomb
        public int AABattery
        {
            get
            {
                //subtract the number of D batteries from the total
                //amount of batteries
                return battery - DBattery;
            }
        }

        //the number of D batteries on the bomb
        public int DBattery
        {
            get
            {
                //keep subtracting the number of holders by a factor of 1,
                //and keep subtracting the number of batteries by a factor of 2,
                //until the number of batteries and number of holders are the same.
                //That will be the number of d batteries

                int batteryNum = battery;
                int batteryHolderNum = batteryHolder;

                while (batteryHolderNum != batteryNum)
                {
                    batteryNum -= 2;
                    batteryHolderNum -= 1;
                }

                return batteryNum;
            }
        }

        public Indicator Bob
        {
            get { return bob; }
        }

        public Indicator Car
        {
            get { return car; }
        }

        public Indicator Clr
        {
            get { return clr; }
        }

        public Indicator Frk
        {
            get { return frk; }
        }

        public Indicator Frq
        {
            get { return frq; }
        }

        public Indicator Ind
        {
            get { return ind; }
        }

        public Indicator Msa
        {
            get { return msa; }
        }

        public Indicator Nsa
        {
            get { return nsa; }
        }

        public Indicator Sig
        {
            get { return sig; }
        }

        public Indicator Snd
        {
            get { return snd; }
        }

        public Indicator Trn
        {
            get { return trn; }
        }

        //the number of indicaotrs on the bomb
        public int IndicatorNum
        {
            get { return LitIndicatorsList.Count + UnlitIndicatorsList.Count; }
        }

        public int PortPlateNum
        {
            get { return Plates.Count; }
        }

        //the number of unique ports on the bomb
        public int UniquePortNum { get; }

        //tells the total amount of ports on the bomb
        public int PortNum
        {
            get
            {
                return PPNum + RcaNum + SerialNum + DviNum +  RJNum + PSNum;
            }
        }

        public int PPNum { get; }
        public int RcaNum { get; }
        public int SerialNum { get; }
        public int RJNum { get; }
        public int DviNum { get; }
        public int PSNum { get; }

        public bool OnlyPP { get; }
        public bool OnlyRCA { get; }
        public bool OnlySerial { get; }
        public bool OnlyRJ { get; }
        public bool OnlyDVI { get; }
        public bool OnlyPS { get; }

        public bool PPVisuble { get { return PPNum > 0; } }
        public bool RCAVisuble { get { return RcaNum > 0; } }
        public bool SerialVisble { get { return SerialNum > 0; } }
        public bool DVIVisble { get { return DviNum > 0; } }
        public bool PSVisible { get { return PSNum > 0; } }
        public bool RJVisible { get { return RJNum > 0; } }


        public int Strike
        {
            get { return strike; }
            set { strike = value; }
        }

        //===============CONSTRUCTORS===============
        /// <summary>
        /// Create a bomb
        /// </summary>
        /// <param name="day">the day of the week</param>
        /// <param name="serialNumber">the serial number found on the bomb</param>
        /// <param name="battery">the number of batteries on the bomb</param>
        /// <param name="batteryHolder">the number of battery holders on the bomb</param>
        /// <param name="bob">the bob indicator</param>
        /// <param name="car">the car indicator</param>
        /// <param name="clr">the clr indicator</param>
        /// <param name="frk">the frk indicator</param>
        /// <param name="frq">the frq indicator</param>
        /// <param name="ind">the ind indicator</param>
        /// <param name="msa">the msa indicator</param>
        /// <param name="nsa">the nsa indicator</param>
        /// <param name="sig">the sig indicator</param>
        /// <param name="snd">the snd indicator</param>
        /// <param name="trn">the trn indicator</param>
        public Bomb(
            Day day,
            String serialNumber,
            int battery,
            int batteryHolder,
            Indicator bob,
            Indicator car,
            Indicator clr,
            Indicator frk,
            Indicator frq,
            Indicator ind,
            Indicator msa,
            Indicator nsa,
            Indicator sig,
            Indicator snd,
            Indicator trn,
            List<Plate> plates
        )
        {
            LitIndicatorsList = new List<Indicator>();
            UnlitIndicatorsList = new List<Indicator>();

            this.day = day;
            this.serialNumber = serialNumber.ToUpper();
            this.battery = battery;
            this.batteryHolder = batteryHolder;
            this.bob = bob;
            this.car = car;
            this.clr = clr;
            this.frk = frk;
            this.frq = frq;
            this.ind = ind;
            this.msa = msa;
            this.nsa = nsa;
            this.sig = sig;
            this.snd = snd;
            this.trn = trn;

            this.Plates = plates;

            PPNum = plates.Where(x => x.pp).Count();
            RcaNum = plates.Where(x => x.rca).Count();
            SerialNum = plates.Where(x => x.serial).Count();
            RJNum = plates.Where(x => x.rj).Count();
            DviNum = plates.Where(x => x.dvi).Count();
            PSNum = plates.Where(x => x.ps).Count();

            OnlyPP = plates.Where(x => x.OnlyPP()).Count() > 0;
            OnlyRCA = plates.Where(x => x.OnlyRCA()).Count() > 0;
            OnlySerial = plates.Where(x => x.OnlySerial()).Count() > 0;
            OnlyRJ = plates.Where(x => x.OnlyRJ()).Count() > 0;
            OnlyDVI = plates.Where(x => x.OnlyDVI()).Count() > 0;
            OnlyPS = plates.Where(x => x.OnlyPS()).Count() > 0;
            EmptyPortPlate = plates.Where(x => x.Empty()).Count() > 0;



            UniquePortNum = 0;

            if (DviNum > 0)
                UniquePortNum++;

            if (PPNum > 0)
                UniquePortNum++;

            if (PSNum > 0)
                UniquePortNum++;

            if (RJNum > 0)
                UniquePortNum++;

            if (SerialNum > 0)
                UniquePortNum++;

            if (RcaNum > 0)
                UniquePortNum++;


            if (bob.VisibleAndLit)
            {
                LitIndicatorsList.Add(bob);
            }
            else if (bob.VisibleNotLit)
            {
                UnlitIndicatorsList.Add(bob);
            }

            if (car.VisibleAndLit)
            {
                LitIndicatorsList.Add(car);
            }
            else if (car.VisibleNotLit)
            {
                UnlitIndicatorsList.Add(car);
            }

            if (clr.VisibleAndLit)
            {
                LitIndicatorsList.Add(clr);
            }
            else if (clr.VisibleNotLit)
            {
                UnlitIndicatorsList.Add(clr);
            }

            if (frk.VisibleAndLit)
            {
                LitIndicatorsList.Add(frk);
            }
            else if (frk.VisibleNotLit)
            {
                UnlitIndicatorsList.Add(frk);
            }

            if (frq.VisibleAndLit)
            {
                LitIndicatorsList.Add(frq);
            }
            else if (frq.VisibleNotLit)
            {
                UnlitIndicatorsList.Add(frq);
            }

            if (ind.VisibleAndLit)
            {
                LitIndicatorsList.Add(ind);
            }
            else if (ind.VisibleNotLit)
            {
                UnlitIndicatorsList.Add(ind);
            }

            if (msa.VisibleAndLit)
            {
                LitIndicatorsList.Add(msa);
            }
            else if (msa.VisibleNotLit)
            {
                UnlitIndicatorsList.Add(msa);
            }

            if (nsa.VisibleAndLit)
            {
                LitIndicatorsList.Add(nsa);
            }
            else if (nsa.VisibleNotLit)
            {
                UnlitIndicatorsList.Add(nsa);
            }

            if (sig.VisibleAndLit)
            {
                LitIndicatorsList.Add(sig);
            }
            else if (sig.VisibleNotLit)
            {
                UnlitIndicatorsList.Add(sig);
            }

            if (snd.VisibleAndLit)
            {
                LitIndicatorsList.Add(snd);
            }
            else if (snd.VisibleNotLit)
            {
                UnlitIndicatorsList.Add(snd);
            }

            if (trn.VisibleAndLit)
            {
                LitIndicatorsList.Add(trn);
            }
            else if (trn.VisibleNotLit)
            {
                UnlitIndicatorsList.Add(trn);
            }
        }

        //===============METHODS===============
        /// <summary>
        /// increases the amount of strikes by 1
        /// </summary>
        public void IncrementStrike()
        {
            strike++;
        }

        /// <summary>
        /// resets the amount of strikes to 0
        /// </summary>
        public void ResetStrike()
        {
            strike = 0;
        }

        /// <summary>
        /// Tells how many times a desired character
        /// is found in the serial number
        /// </summary>
        /// <param name="character">the character that wants to be found</param>
        /// <returns>the number of times the character was found</returns>
        public int CharacterCount(char character)
        {
            return serialNumber.Where(x => x == character).Count();
        }
    }
}
