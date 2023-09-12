using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class LionShare : Module
    {
        public List<Lion> lions;
        public List<Lion> aliveLions;
        public List<Lion> deadLions;

        int year;

        public LionShare(int year, Dictionary<string, bool> names,Bomb bomb, StreamWriter logFileWriter) : base(bomb, logFileWriter, "Lion Share")
        {
            lions = names.Select(name => new Lion(year, name.Key, names[name.Key])).ToList();
            this.year = year;
        }

        public string Solve(bool debug)
        {
            PrintDebugLine($"Year: {year}\n");
            
            //get rid dead/absent lions

            aliveLions = lions.Where(l => l.alive).ToList();

            deadLions = lions.Where(l => !l.alive).ToList();

            deadLions.ForEach(l => l.percentage = 0m);

            PrintDebugLine($"Dead Lions: {string.Join(",", GetNames(deadLions))}\n");

            aliveLions.Sort((l1, l2) => l1.name.CompareTo(l2.name));

            //find how many points each lion gets
            aliveLions.ForEach(l => FindAmount(l));

            int total = lions.Sum(l => l.amount);

            PrintDebugLine($"Total: {total}");

            aliveLions.ForEach(l => l.percentage = RoundDown(l.amount / (decimal)total, 2));

            decimal leftover = 1m - aliveLions.Sum(l => l.percentage);

            string answer;

            try
            {
                Lion leader = aliveLions.First(l => l.leader);

                leader.percentage += leftover;

                lions.Sort((l1, l2) => l1.alive ? 1 : -1);

                List<string> answerList = lions.Select(l => $"{l.name}: {(int)(l.percentage * 100)}").ToList();

                answer = string.Join("\n", answerList);

                if (!debug)
                {
                    ShowAnswer(answer, true);
                }
            }

            catch
            {
                answer = "Leader can't be dead";
            }

            if (!debug && answer == "Leader can't be dead")
            {
                ShowErrorMessage(answer);
            }

            return answer;
        }

        public List<string> GetNames(List<Lion> lions)
        { 
        
            return lions.Select(l => l.name).ToList();
        }

        public decimal RoundDown(decimal i, double decimalPlaces)
        {
            var power = Convert.ToDecimal(Math.Pow(10, decimalPlaces));
            return Math.Floor(i * power) / power;
        }

        public void FindAmount(Lion l)
        {
            //add the base
            int amount = l.baseNum;


            //find approritate indicators
            List<string> indicatorNames = Bomb.LitIndicatorsList.Select(i => i.Name).ToList();

            int validIndicatorNum = indicatorNames.Count(i => l.indicatorList.Contains(i));

            amount += validIndicatorNum * l.indicatorBonus;

            //find appopriates characters
            int serialNum = Bomb.SerialNumber.Count(c => l.name.Contains(c));

            amount += serialNum;

            //add cubs\
            List<string> cubNames = lions.Where(a => l.cubNames.Contains(a.name)).Select(l => l.name).ToList();

            l.amount = amount + cubNames.Count;

            PrintDebugLine($"Name: {l.name}");
            PrintDebugLine("Base: " + l.baseNum);
            PrintDebugLine($"Indicators: {validIndicatorNum * l.indicatorBonus} ({validIndicatorNum} * {l.indicatorBonus})");
            PrintDebugLine($"Serial number: {serialNum}");
            PrintDebugLine($"Cubs: {cubNames.Count} ({string.Join(" ", cubNames)})");
            PrintDebugLine($"Total: {l.amount}\n");
        }

        public class Lion
        {
            public string name;
            public int baseNum;
            public bool alive;
            public List<string> indicatorList;
            public int indicatorBonus;
            public List<string> cubNames;
            public bool leader;
            public int amount;
            public decimal percentage;

            public Lion(int year, string name, bool leader)
            {
                this.name = name;
                this.leader = leader;
                cubNames = new List<string>();
                indicatorList = new List<string>();
                alive = false;

                switch (name)
                {
                    case "ASKARI":
                        baseNum = 1;
                        indicatorList = new List<string>() { "CAR", "MSA", "NSA" };
                        indicatorBonus = 2;
                        alive = true;
                        break;

                    case "BABU":
                    case "BOGA":
                        baseNum = 1;
                        indicatorList = new List<string>() { "BOB" };
                        indicatorBonus = 1;
                        alive = true;
                        break;

                    case "CHUMVI":
                        baseNum = 1;
                        indicatorList = new List<string>() { "CAR", "CLR" };
                        indicatorBonus = 2;
                        alive = true;
                        break;

                    case "DIKU":
                        baseNum = 1;
                        indicatorList = new List<string>() { "IND", "SND" };
                        indicatorBonus = 1;
                        alive = true;
                        break;

                    case "KULA":
                        baseNum = 1;
                        indicatorList = new List<string>() { "FRK" };
                        indicatorBonus = 1;
                        alive = true;
                        break;

                    case "MALKA":
                        baseNum = 1;
                        indicatorList = new List<string>() { "MSA" };
                        indicatorBonus = 2;
                        alive = true;
                        break;

                    case "NANNDA":
                    case "NDONA":

                        baseNum = 1;
                        indicatorList = new List<string>() { "IND", "NSA", "SND", "TRN" };
                        indicatorBonus = 1;
                        alive = true;
                        break;

                    case "RANI":
                        baseNum = 1;
                        indicatorList = new List<string>() { "CAR", "CLR", "FRK", "FRQ", "TRN" };
                        indicatorBonus = 1;
                        alive = true;
                        break;

                    case "SABINI":
                    case "SHEENA":
                        baseNum = 1;
                        indicatorList = new List<string>() { "MSA", "NSA", "SIG", "SND" };
                        indicatorBonus = 1;
                        alive = true;
                        break;

                    case "TAMA":
                    case "TIIFU":
                        baseNum = 1;
                        indicatorList = new List<string>() { "TRN" };
                        indicatorBonus = 1;
                        alive = true;
                        break;

                    case "TOJO":
                        baseNum = 1;
                        indicatorList = new List<string>() { "TRN" };
                        indicatorBonus = 2;
                        alive = true;
                        break;

                    case "WEENA":
                    case "ZURI":
                        baseNum = 1;
                        indicatorBonus = 0;
                        alive = true;
                        break;

                    case "AHADI":

                        if (year < 4)
                        {
                            indicatorList = new List<string>() { "CAR", "MSA", "NSA" };
                            alive = true;

                            if (year == 3)
                            {
                                baseNum = 10;
                                indicatorBonus = 4;
                            }

                            else
                            {
                                baseNum = 5;
                                indicatorBonus = 2;
                            }
                        }
                        break;

                    case "MOHATU":

                        if (year < 3)
                        {
                            baseNum = 10;
                            indicatorList = new List<string>() { "MSA" };
                            indicatorBonus = 4;
                            alive = true;

                        }
                        break;

                    case "SARABI":
                        if (year < 15)
                        {
                            indicatorList = new List<string>() { "MSA", "NSA", "SIG", "SND" };
                            indicatorBonus = 1;
                            alive = true;

                            baseNum = year < 3 ? 3 : 5;

                            if (year == 4)
                            {
                                cubNames = new List<string>() { "SIMBA" };
                            }

                            else if (year == 6)
                            {
                                cubNames = new List<string>() { "MHEETU" };
                            }
                        }
                        break;

                    case "SARAFINA":
                        if (year < 13)
                        {
                            indicatorList = new List<string>() { "MSA", "NSA", "SIG", "SND" };
                            indicatorBonus = 1;
                            alive = true;

                            baseNum = year < 3 ? 3 : 5;

                            if (year == 5)
                            {
                                cubNames = new List<string>() { "NALA" };
                            }

                            else if (year == 6)
                            {
                                cubNames = new List<string>() { "ZIRA" };
                            }
                        }
                        break;

                    case "URU":
                        if (year < 7)
                        {
                            baseNum = 5;
                            indicatorBonus = 0;
                            alive = true;

                            if (year == 1)
                            {
                                cubNames = new List<string>() { "MUFASA" };
                            }

                            else if (year == 2)
                            {
                                cubNames = new List<string>() { "TAKA" };
                            }
                        }
                        break;

                    case "ZAMA":
                        if (year < 5)
                        {
                            baseNum = 5;
                            alive = true;
                        }
                        break;

                    case "KIARA":
                        if (year >= 13)
                        {
                            baseNum = year == 13 || year == 14 ? 3 : year == 5 || year == 15 ? 5 : 7;
                            indicatorBonus = year == 16 ? 3 : 1;
                            alive = true;
                            indicatorList = new List<string>() { "FRK" };

                        }
                        break;

                    case "KION":
                        if (year <= 14)
                        {
                            baseNum = year == 16  ? 10 : 3;
                            indicatorBonus = year == 16 ? 4 : 2;
                            alive = true;
                            indicatorList = new List<string>() { "FRK" };
                        }
                        break;

                    case "KOPA":
                        if (year == 13)
                        {
                            baseNum = 3;
                            indicatorBonus = 2;
                            alive = true;
                            indicatorList = new List<string>() { "FRK" };

                        }
                        break;

                    case "KOVU":
                        if (year >= 12)
                        {
                            baseNum = year < 14 ? 3 : 5;
                            indicatorBonus = 2;
                            alive = true;
                            indicatorList = new List<string>() { "FRK" };
                        }
                        break;

                    case "MHEETU":
                        if (year >= 7 && year < 12)
                        { 
                            baseNum = year < 9 ? 3 : 5;
                            indicatorBonus = 2;
                            alive = true;
                            indicatorList = new List<string>() { "MSA" };
                        }
                        break;

                    case "MUFASA":
                        if (year >= 2 && year < 6)
                        {
                            baseNum = year < 4 ? 3 : 10;
                            indicatorBonus = year == 2 ? 2 : year == 3 ? 2 : 4;
                            alive = true;
                            indicatorList = new List<string>() { "MSA" };
                        }
                        break;

                    case "NALA":
                        if (year >= 6 && year != 11)
                        {
                            baseNum = year < 8 ? 3 : 5;
                            indicatorBonus = 1;
                            alive = true;
                            indicatorList = new List<string>() { "IND", "NSA", "SND", "TRN" };
                        }
                        break;

                    case "NUKA":
                        if (year <= 10 && year < 14)
                        {
                            baseNum = year < 12 ? 3 : 5;
                            indicatorBonus = 2;
                            alive = true;
                            indicatorList = new List<string>() { "IND", "NSA", "SND", "TRN" };
                        }
                        break;

                    case "SIMBA":
                        if (year == 5 || (year >= 12 && year < 16))
                        {
                            baseNum = year == 5 ? 3 : 10;
                            indicatorBonus = year == 5 ? 2 : 4;
                            alive = true;
                            indicatorList = new List<string>() { "MSA", "NSA", "SIG", "SND" };
                        }
                        break;

                    case "TAKA":
                        if (year <= 3 && year < 12)
                        {
                            baseNum = year == 3 || year == 4 ? year : year == 5 ? 7 : 10;
                            indicatorBonus = year == 3 || year == 4 ? 2 : year == 5 ? 3 : 4;
                            alive = true;
                            indicatorList = new List<string>() { "TRN" };
                        }
                        break;

                    case "VITANI":
                        if (year >= 11)
                        {
                            baseNum = year == 11 || year == 12 ? 3 : 5;
                            indicatorBonus = 0;
                            alive = true;
                        }
                        break;

                    default: //ZIRA
                        if(year <= 7 && year < 14)
                        {
                            baseNum = year == 7 || year == 8 ? 3 : 5;
                            indicatorBonus = 0;
                            alive = true;
                        }
                        break;

                }

            }

            
        }
    }
}
