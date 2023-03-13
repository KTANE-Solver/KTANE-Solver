using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the Monsplode Trading Cards module
    /// </summary>
    public class MonsplodeTradingCard : Module
    {
        public Card[] hand { get; }

        public MonsplodeTradingCard(
            Bomb bomb,
            StreamWriter logfileWriter,
            Card card1,
            Card card2,
            Card card3
        ) : base(bomb, logfileWriter, "Monsplode Trading Cards")
        {
            hand = new Card[] { card1, card2, card3 };
        }

        /// <summary>
        /// Returns the cards that the player currently has
        /// </summary>
        public string Solve(Card offeredCard, bool debug)
        {
            System.Diagnostics.Debug.WriteLine("Card 1");
            hand[0].PrintCard();

            System.Diagnostics.Debug.WriteLine("Card 2");
            hand[1].PrintCard();

            System.Diagnostics.Debug.WriteLine("Card 3");
            hand[2].PrintCard();

            System.Diagnostics.Debug.WriteLine("Offering Card");
            offeredCard.PrintCard();

            //find the lowest card in our hand
            Card lowestCard = hand[0];
            int position = 0;

            if (lowestCard.Value > hand[1].Value)
            {
                lowestCard = hand[1];
                position = 1;
            }

            if (lowestCard.Value > hand[2].Value)
            {
                lowestCard = hand[2];
                position = 2;
            }

            string answer = "";
            //see if the lowest card is worse than the offered card, if yes then trade, if not then keep
            if (lowestCard.Value >= offeredCard.Value)
            {
                answer = "Press Keep";
            }
            else
            {
                answer = $"Trade Card {position + 1} ({lowestCard.Name})";
                hand[position] = offeredCard;
            }

            if(!debug)
            {
                ShowAnswer(answer, true);
            }

            return answer;
        }

        public class Card
        {
            public enum Rarity
            {
                Common,
                Uncommon,
                Rare,
                Ultra
            }

            public String Name { get; }

            public char PrintAlphabet { get; }

            public int PrintNumeral { get; }

            public String PrintVersion { get; }

            public Rarity rarity { get; }

            public bool Shiny { get; }

            public int DentCorners { get; }

            public double Value { get; }

            private Bomb bomb;

            public Card(
                String name,
                String printVersion,
                Rarity rarity,
                bool shiny,
                int dentCorners,
                Bomb bomb
            )
            {
                Name = name;
                PrintVersion = printVersion.ToUpper();

                PrintAlphabet = PrintVersion[0];
                PrintNumeral = int.Parse("" + PrintVersion[1]);
                this.rarity = rarity;
                Shiny = shiny;
                DentCorners = dentCorners;
                this.bomb = bomb;

                //finding how much the card is worth

                Value = GetInitalValue(name);

                if (Value == 0)
                {
                    return;
                }

                double mutiplier = 0;

                //If the card is Common, the multiplier is 1.
                if (rarity == Rarity.Common)
                {
                    mutiplier = 1;
                }
                //Otherwise, if the card is Uncommon, the multiplier is 1.25.
                else if (rarity == Rarity.Uncommon)
                {
                    mutiplier = 1.25;
                }
                //Otherwise, if the card is Rare, the multiplier is 1.5.
                else if (rarity == Rarity.Rare)
                {
                    mutiplier = 1.5;
                }
                //Otherwise, if the card is Ultra Rare, the multiplier is 1.75.
                else if (rarity == Rarity.Ultra)
                {
                    mutiplier = 1.75;
                }

                //If the card is a foil (has shiny spots on it), add 0.5 to the multiplier.
                if (shiny)
                {
                    mutiplier += .5;
                }

                //For each bent corner of the card subtract 0.25 from the multiplier.
                mutiplier -= (.25 * dentCorners);

                Value = GetInitalValue(name) * mutiplier;

                if (Value < 0)
                {
                    Value = 0;
                }
            }

            public void PrintCard()
            {
                System.Diagnostics.Debug.WriteLine($"Value: {Value}");
                System.Diagnostics.Debug.WriteLine($"Name: {Name}");
                System.Diagnostics.Debug.WriteLine($"Print Version: {PrintVersion}");
                System.Diagnostics.Debug.WriteLine($"Rarity: {rarity}");
                System.Diagnostics.Debug.WriteLine($"Bent Corners: {DentCorners}");
                System.Diagnostics.Debug.WriteLine($"Shiny: {Shiny}\n");
            }

            private int GetInitalValue(String Name)
            {
                int Value;

                //If the Print Version’s numeral is equal to the alphabetic position of its letter, the card is fake and has 0 value. This overrides everything.
                if ((PrintAlphabet - 64) == PrintNumeral)
                {
                    return 0;
                }

                //two letters
                if (
                    bomb.SerialNumber[0] >= 65
                    && bomb.SerialNumber[0] <= 90
                    && bomb.SerialNumber[1] >= 65
                    && bomb.SerialNumber[1] <= 90
                )
                {
                    switch (Name)
                    {
                        case "Aluga, The Fighter":
                        case "Buhar, The Protector":
                            Value = 6;
                            break;

                        case "Asteran":
                        case "Aluga":
                        case "Bob":
                        case "Caadarim":
                        case "Cutie Pie":
                        case "Docsplode":
                        case "Flaurim":
                        case "Lanaluff":
                        case "Melbor":
                        case "Mountoise":
                        case "Myrchat":
                        case "Pouse":
                            Value = 2;
                            break;

                        case "Buhar":
                        case "Gloorim":
                        case "Bob, The Ancestor":
                            Value = 5;
                            break;

                        case "Clondar":
                        case "Lugirit":
                        case "Nibs":
                        case "Percy":
                        case "Violan":
                        case "Zapra":
                            Value = 3;
                            break;

                        default:
                            Value = 4;
                            break;
                    }
                }
                //letter then number
                else if (
                    bomb.SerialNumber[0] >= 65
                    && bomb.SerialNumber[0] <= 90
                    && bomb.SerialNumber[1] >= 48
                    && bomb.SerialNumber[1] <= 57
                )
                {
                    switch (Name)
                    {
                        case "Aluga":
                        case "Flaurim":
                        case "Lanaluff":
                        case "Lugirit":
                        case "Magmy":
                        case "Nibs":
                        case "Percy":
                        case "Pouse":
                            Value = 3;
                            break;

                        case "Asteran":
                        case "Buhar, The Protector":
                            Value = 5;
                            break;

                        case "Melbor, The Web Bug":
                        case "Aluga, The Fighter":
                        case "Bob":
                        case "Caadarim":
                        case "Cutie Pie":
                        case "Docsplode":
                        case "Melbor":
                        case "Mountoise":
                        case "Violan":
                        case "Zapra":
                            Value = 4;
                            break;

                        case "Bob, The Ancestor":
                            Value = 6;
                            break;

                        default:
                            Value = 2;
                            break;
                    }
                }
                //number then letter
                else if (
                    bomb.SerialNumber[0] >= 48
                    && bomb.SerialNumber[0] <= 57
                    && bomb.SerialNumber[1] >= 65
                    && bomb.SerialNumber[1] <= 90
                )
                {
                    switch (Name)
                    {
                        case "Aluga":
                        case "Clondar":
                        case "Flaurim":
                        case "Lanaluff":
                        case "Melbor":
                        case "Myrchat":
                        case "Bob, The Ancestor":
                        case "Melbor, The Web Bug":
                            Value = 4;
                            break;

                        case "Asteran":
                        case "Bob":
                        case "Buhar":
                        case "Cutie Pie":
                        case "Docsplode":
                        case "Gloorim":
                        case "Magmy":
                        case "Nibs":
                        case "Percy":
                        case "Violan":
                        case "Zapra":
                        case "Zenlad":
                            Value = 2;
                            break;

                        case "Aluga, The Fighter":
                            Value = 5;
                            break;

                        default:
                            Value = 3;
                            break;
                    }
                }
                //two numbers
                else
                {
                    switch (Name)
                    {
                        case "Aluga":
                        case "Asteran":
                        case "Caadarim":
                        case "Flaurim":
                        case "Gloorim":
                        case "Lugirit":
                        case "Vellarim":
                        case "Violan":

                            Value = 2;
                            break;

                        case "Aluga, The Fighter":
                            Value = 3;
                            break;

                        case "Melbor, The Web Bug":
                            Value = 6;
                            break;

                        case "Bob":
                        case "Clondar":
                        case "Docsplode":
                            Value = 5;

                            break;

                        case "Buhar":
                        case "Lanaluff":
                        case "Magmy":
                        case "Melbor":
                        case "Mountoise":
                        case "Myrchat":
                        case "Pouse":
                        case "Ukkens":
                        case "Zapra":

                            Value = 3;
                            break;

                        default:
                            Value = 4;
                            break;
                    }
                }

                //For each indicator on the bomb that contains the letter of the Print Version, add 1 to the card’s value if it’s lit and subtract 1 if it’s unlit
                foreach (Indicator litIndicator in bomb.LitIndicatorsList)
                {
                    if (litIndicator.Name.Contains(PrintAlphabet))
                    {
                        Value++;
                    }
                }

                foreach (Indicator unlitIndicator in bomb.UnlitIndicatorsList)
                {
                    if (unlitIndicator.Name.Contains(PrintAlphabet))
                    {
                        Value--;
                    }
                }

                //If the bomb has no batteries, keep the card’s current value.
                if (bomb.Battery == 0)
                {
                    return Value;
                }
                //Otherwise, if the numeral of the Print Version is greater than the amount of batteries on the bomb, add 1 to the card’s current value.
                else if (PrintNumeral > bomb.Battery)
                {
                    Value++;
                }
                //Otherwise, if the numeral of the Print Version is less than the amount of batteries on the bomb,  subtract 1 from the card’s current value.
                else if (PrintNumeral < bomb.Battery)
                {
                    Value--;
                }
                //Otherwise, add 2 to the card’s current value.
                else
                {
                    Value += 2;
                }

                return Value;
            }
        }
    }
}
