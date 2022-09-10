using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    //an enum list that will contain every symbol
    public enum Symbol
    {
        Air,
        Aquarius,
        Aries,
        Cancer,
        Capricon,
        Earth,
        Fire,
        Gemini,
        Jupiter,
        Leo,
        Libra,
        Mars,
        Mercury,
        Moon,
        Neptune,
        Pices,
        Pluto,
        Sagittarius,
        Saturn,
        Scorpio,
        Sun,
        Taurus,
        Uranus,
        Venus,
        Virgo,
        Water,
        Null
    }

    public class Astrology : Module
    {
        //the 3 symbols on the bomb

        private Symbol[] symbols; 

        private int omen;

        public Astrology(
            Bomb bomb,
            StreamWriter logFileWriter,
            string symbol1Name,
            string symbol2Name,
            string symbol3Name
        ) : base(bomb, logFileWriter, "Astrology")
        {

            symbols = new Symbol[3];

            symbols[0] = SetUpSymbol(symbol1Name);
            symbols[1] = SetUpSymbol(symbol2Name);
            symbols[2] = SetUpSymbol(symbol3Name);

            omen = 0;

            PrintDebugLine("Symbols: " + string.Join(", ", symbols) + "\n");
        }

        public int Solve(bool debug)
        {
            int num1 = GetGrid1Num();
            int num2 = GetGrid2Num();
            int num3 = GetGrid3Num();

            PrintSymbolIntersection(symbols[0], symbols[1], num1);
            PrintSymbolIntersection(symbols[0], symbols[2], num2);
            PrintSymbolIntersection(symbols[1], symbols[2], num3);

            omen = num1 + num2 + num3;

            PrintDebugLine($"Starting omen is {omen}\n");

            foreach (Symbol symbol in symbols)
            { 
                omen += HasLetters(symbol) ? 1 : -1;
                PrintDebugLine($" Omen is now {omen}");

            }

            if (omen == 0)
            {
                if (!debug)
                { 
                    ShowAnswer("Press NO OMEN", true);
                }
            }
            else if (omen < 0)
            {
                if (!debug)
                {
                    ShowAnswer($"Press POOR OMEN when there is a {Math.Abs(omen)} anywhere in the timer", true);
                }
            }
            else
            {
                if (!debug)
                {
                    ShowAnswer($"Press GOOD OMEN when there is a {omen} anywhere in the timer", true);
                }
            }

            return omen;
        }

        /// <summary>
        /// Tells if the symbol shares a letter with the serial number
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private bool HasLetters(Symbol symbol)
        {
            string name = symbol.ToString().ToUpper();

            foreach (char c in Bomb.SerialNumber)
            {
                if (c >= 65 && c <= 90)
                {
                    if (name.Contains(c))
                    {
                        PrintDebug(
                    $"{symbol} shares letter.");
                        return true;
                    }
                }
            }

            PrintDebug(
                   $"{symbol} does not share letter.");
            return false;
        }

        private void PrintSymbolIntersection(Symbol symbol1, Symbol symbol2, int num)
        {
            PrintDebugLine($"{symbol1} and {symbol2} give {num}\n");
        }

        /// <summary>
        /// Gives a symbol based on the name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Symbol SetUpSymbol(string name)
        {
            switch (name)
            {
                case "Air":
                    return Symbol.Air;

                case "Aquarius":
                    return Symbol.Aquarius;

                case "Aries":
                    return Symbol.Aries;

                case "Cancer":
                    return Symbol.Cancer;

                case "Capricorn":
                    return Symbol.Capricon;

                case "Earth":
                    return Symbol.Earth;

                case "Fire":
                    return Symbol.Fire;

                case "Gemini":
                    return Symbol.Gemini;

                case "Jupiter":
                    return Symbol.Jupiter;

                case "Leo":
                    return Symbol.Leo;

                case "Libra":
                    return Symbol.Libra;

                case "Mars":
                    return Symbol.Mars;

                case "Mercury":
                    return Symbol.Mercury;

                case "Moon":
                    return Symbol.Moon;

                case "Neptune":
                    return Symbol.Neptune;

                case "Pisces":
                    return Symbol.Pices;

                case "Pluto":
                    return Symbol.Pluto;

                case "Sagittarius":
                    return Symbol.Sagittarius;

                case "Saturn":
                    return Symbol.Saturn;

                case "Scorpio":
                    return Symbol.Scorpio;

                case "Sun":
                    return Symbol.Sun;

                case "Taurus":
                    return Symbol.Taurus;

                case "Uranus":
                    return Symbol.Uranus;

                case "Venus":
                    return Symbol.Venus;

                case "Virgo":
                    return Symbol.Virgo;

                case "Water":
                    return Symbol.Water;

                default:
                    return Symbol.Null;
            }
        }

        /// <summary>
        /// Tells the number the first two symbols give
        /// </summary>
        /// <returns></returns>
        private int GetGrid1Num()
        {
            switch (symbols[1])
            {
                case Symbol.Jupiter:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 1;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 2;
                        }
                        //air
                        else
                        {
                            return -1;
                        }
                    }
                case Symbol.Mars:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 1;
                        }
                        //air
                        else
                        {
                            return -2;
                        }
                    }

                case Symbol.Mercury:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 1;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return -1;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 0;
                        }
                        //air
                        else
                        {
                            return -1;
                        }
                    }
                case Symbol.Moon:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return -1;
                        }
                        //air
                        else
                        {
                            return 2;
                        }
                    }
                case Symbol.Neptune:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 1;
                        }
                        //air
                        else
                        {
                            return -2;
                        }
                    }
                case Symbol.Pluto:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return -1;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 1;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return -2;
                        }
                        //air
                        else
                        {
                            return 2;
                        }
                    }
                case Symbol.Saturn:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return -2;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return -2;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 0;
                        }
                        //air
                        else
                        {
                            return 0;
                        }
                    }
                case Symbol.Sun:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return -2;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return -1;
                        }
                        //air
                        else
                        {
                            return -1;
                        }
                    }
                case Symbol.Uranus:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 2;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 2;
                        }
                        //air
                        else
                        {
                            return 2;
                        }
                    }

                //venus
                default:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return -1;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return -1;
                        }
                        //air
                        else
                        {
                            return 0;
                        }
                    }
            }
        }

        /// <summary>
        /// Tells the number the first and third symbols give
        /// </summary>
        /// <returns></returns>
        private int GetGrid2Num()
        {
            switch (symbols[2])
            {
                case Symbol.Aquarius:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 1;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 1;
                        }
                        //air
                        else
                        {
                            return -1;
                        }
                    }
                case Symbol.Aries:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 1;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return -2;
                        }
                        //air
                        else
                        {
                            return 1;
                        }
                    }
                case Symbol.Cancer:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 0;
                        }
                        //air
                        else
                        {
                            return -2;
                        }
                    }
                case Symbol.Capricon:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return -2;
                        }
                        //air
                        else
                        {
                            return 0;
                        }
                    }
                case Symbol.Gemini:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return -1;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return -1;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 0;
                        }
                        //air
                        else
                        {
                            return -2;
                        }
                    }
                case Symbol.Leo:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return -1;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 1;
                        }
                        //air
                        else
                        {
                            return 2;
                        }
                    }
                case Symbol.Libra:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 2;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return -2;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 1;
                        }
                        //air
                        else
                        {
                            return -1;
                        }
                    }
                case Symbol.Pices:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 1;
                        }
                        //air
                        else
                        {
                            return -1;
                        }
                    }
                case Symbol.Sagittarius:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 1;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return -1;
                        }
                        //air
                        else
                        {
                            return 0;
                        }
                    }
                case Symbol.Scorpio:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 1;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 2;
                        }
                        //air
                        else
                        {
                            return 1;
                        }
                    }
                case Symbol.Taurus:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return -1;
                        }
                        //air
                        else
                        {
                            return 1;
                        }
                    }
                //virgo
                default:
                    {
                        if (symbols[0] == Symbol.Fire)
                        {
                            return 2;
                        }
                        else if (symbols[0] == Symbol.Water)
                        {
                            return -1;
                        }
                        else if (symbols[0] == Symbol.Earth)
                        {
                            return 0;
                        }
                        //air
                        else
                        {
                            return 0;
                        }
                    }
            }
        }

        /// <summary>
        /// Tells the number the second and third symbols give
        /// </summary>
        /// <returns></returns>
        private int GetGrid3Num()
        {
            switch (symbols[2])
            {
                case Symbol.Aquarius:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return 2;
                        }
                        //pluto
                        else
                        {
                            return 0;
                        }
                    }

                case Symbol.Aries:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return 1;
                        }
                        //pluto
                        else
                        {
                            return -1;
                        }
                    }
                case Symbol.Cancer:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return 1;
                        }
                        //pluto
                        else
                        {
                            return -1;
                        }
                    }
                case Symbol.Capricon:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return -2;
                        }
                        //pluto
                        else
                        {
                            return 0;
                        }
                    }
                case Symbol.Gemini:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return 2;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return 2;
                        }
                        //pluto
                        else
                        {
                            return 0;
                        }
                    }
                case Symbol.Leo:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return 2;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return -1;
                        }
                        //pluto
                        else
                        {
                            return -2;
                        }
                    }
                case Symbol.Libra:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return 1;
                        }
                        //pluto
                        else
                        {
                            return 2;
                        }
                    }
                case Symbol.Pices:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return 0;
                        }
                        //pluto
                        else
                        {
                            return -1;
                        }
                    }
                case Symbol.Sagittarius:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return 2;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return 2;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return 2;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return 0;
                        }
                        //pluto
                        else
                        {
                            return 1;
                        }
                    }
                case Symbol.Scorpio:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return 1;
                        }
                        //pluto
                        else
                        {
                            return 1;
                        }
                    }
                case Symbol.Taurus:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return 2;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return 2;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return 0;
                        }
                        //pluto
                        else
                        {
                            return 0;
                        }
                    }

                //virgo
                default:
                    {
                        if (symbols[1] == Symbol.Sun)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Moon)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Mercury)
                        {
                            return -1;
                        }
                        else if (symbols[1] == Symbol.Venus)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Mars)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbols[1] == Symbol.Saturn)
                        {
                            return 1;
                        }
                        else if (symbols[1] == Symbol.Uranus)
                        {
                            return -2;
                        }
                        else if (symbols[1] == Symbol.Neptune)
                        {
                            return 1;
                        }
                        //pluto
                        else
                        {
                            return 1;
                        }
                    }
            }
        }
    }
}
