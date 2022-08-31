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

    class Astrology : Module
    {
        //the 3 symbols on the bomb
        private Symbol symbol1;
        private Symbol symbol2;
        private Symbol symbol3;

        private int omen;

        public Astrology(
            Bomb bomb,
            StreamWriter logFileWriter,
            string symbol1Name,
            string symbol2Name,
            string symbol3Name
        ) : base(bomb, logFileWriter, "Astrology")
        {
            symbol1 = SetUpSymbol(symbol1Name);
            symbol2 = SetUpSymbol(symbol2Name);
            symbol3 = SetUpSymbol(symbol3Name);

            omen = 0;

            PrintDebugLine("Symbols:");
            PrintDebugLine(symbol1.ToString());
            PrintDebugLine(symbol2.ToString());
            PrintDebugLine(symbol3.ToString());

            PrintDebugLine("");
        }

        public void Solve()
        {
            int num1 = GetGrid1Num();
            int num2 = GetGrid2Num();
            int num3 = GetGrid3Num();

            PrintSymbolIntersection(symbol1, symbol2, num1);
            PrintSymbolIntersection(symbol1, symbol3, num2);
            PrintSymbolIntersection(symbol2, symbol3, num1);

            omen = num1 + num2 + num3;

            PrintDebugLine($"Starting omen is {omen}\n");

            if (HasLetters(symbol1))
            {
                omen++;
                PrintDebugLine(
                    $"{symbol1} shares a letter with the serial number. Omen is now " + omen
                );
            }
            else
            {
                omen--;
                PrintDebugLine(
                    $"{symbol1} does not a letter with the serial number. Omen is now " + omen
                );
            }

            if (HasLetters(symbol2))
            {
                omen++;
                PrintDebugLine(
                    $"{symbol2} shares a letter with the serial number. Omen is now " + omen
                );
            }
            else
            {
                omen--;
                PrintDebugLine(
                    $"{symbol2} does not a letter with the serial number. Omen is now " + omen
                );
            }

            if (HasLetters(symbol3))
            {
                omen++;
                PrintDebugLine(
                    $"{symbol3} shares a letter with the serial number. Omen is now {omen}\n"
                );
            }
            else
            {
                omen--;
                PrintDebugLine(
                    $"{symbol3} does not a letter with the serial number. Omen is now {omen}\n"
                );
            }

            if (omen == 0)
            {
                ShowAnswer("Press NO OMEN", true);
            }
            else if (omen < 0)
            {
                omen = Math.Abs(omen);

                ShowAnswer($"Press POOR OMEN when there is a {omen} anywhere in the timer", true);
            }
            else
            {
                ShowAnswer($"Press GOOD OMEN when there is a {omen} anywhere in the timer", true);
            }
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
                        return true;
                    }
                }
            }

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
            switch (symbol2)
            {
                case Symbol.Jupiter:
                    {
                        if (symbol1 == Symbol.Fire)
                        {
                            return 1;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 1;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return -1;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return -1;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 1;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return -2;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return -2;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return -2;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 2;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return -1;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Earth)
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
            switch (symbol3)
            {
                case Symbol.Aquarius:
                    {
                        if (symbol1 == Symbol.Fire)
                        {
                            return 1;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 1;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return -1;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return -1;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return -1;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 2;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return -2;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 1;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 1;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 0;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return 2;
                        }
                        else if (symbol1 == Symbol.Earth)
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
                        if (symbol1 == Symbol.Fire)
                        {
                            return 2;
                        }
                        else if (symbol1 == Symbol.Water)
                        {
                            return -1;
                        }
                        else if (symbol1 == Symbol.Earth)
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
            switch (symbol3)
            {
                case Symbol.Aquarius:
                    {
                        if (symbol2 == Symbol.Sun)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
                        if (symbol2 == Symbol.Sun)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
                        if (symbol2 == Symbol.Sun)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
                        if (symbol2 == Symbol.Sun)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
                        if (symbol2 == Symbol.Sun)
                        {
                            return 2;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
                        if (symbol2 == Symbol.Sun)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return 2;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
                        if (symbol2 == Symbol.Sun)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
                        if (symbol2 == Symbol.Sun)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
                        if (symbol2 == Symbol.Sun)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return 2;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return 2;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return 2;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
                        if (symbol2 == Symbol.Sun)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
                        if (symbol2 == Symbol.Sun)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return 2;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return 2;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
                        if (symbol2 == Symbol.Sun)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Moon)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Mercury)
                        {
                            return -1;
                        }
                        else if (symbol2 == Symbol.Venus)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Mars)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Jupiter)
                        {
                            return 0;
                        }
                        else if (symbol2 == Symbol.Saturn)
                        {
                            return 1;
                        }
                        else if (symbol2 == Symbol.Uranus)
                        {
                            return -2;
                        }
                        else if (symbol2 == Symbol.Neptune)
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
