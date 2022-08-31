using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class PointOfOrder : Module
    {
        public Card[] cards;

        private bool rule1;
        private bool rule2;
        private bool rule3;
        private Dictionary<Suit, Suit[]> suitRow;
        private List<Number> rule2List;
        private int requiredDifference1;
        private int requiredDifference2;

        public PointOfOrder(Bomb bomb, StreamWriter logFileWriter, Card[] cards)
            : base(bomb, logFileWriter, "Point of Order")
        {
            this.cards = cards;
            rule1 = false;
            rule2 = false;
            rule3 = false;
        }

        private void Solve()
        {
            List<string> answer = new List<string>();
            Rule1();
            Rule2();
            Rule3();

            if (rule1)
            {
                answer.Add($"Suit: " + string.Join(", ", suitRow));
            }

            if (rule2)
            {
                answer.Add($"Number: " + string.Join(", ", rule2List));
            }

            if (rule3)
            {
                answer.Add(
                    $"Number: "
                        + string.Join(
                            ", ",
                            FindNextNumbers(
                                new int[] { requiredDifference1, requiredDifference2 },
                                cards[4].number
                            )
                        )
                );
            }

            ShowAnswer(string.Join("\n", answer), true);
        }

        private void Rule1()
        {
            suitRow = FindSuitRow();

            rule1 = true;

            //suit rule
            for (int i = cards.Length - 1; i > 0; i--)
            {
                Suit currentCard = cards[i].suit;
                Suit previousCard = cards[i - 1].suit;

                if (!suitRow[previousCard].Contains(currentCard))
                {
                    rule1 = false;
                    break;
                }
            }
        }

        private void Rule2()
        {
            rule2 = true;

            int num = (Bomb.SerialNumber[3] - 64) % 3;

            if (num == 0)
            {
                num += 3;
            }

            rule2List = new List<Number>();

            foreach (int i in Enum.GetValues(typeof(Number)))
            {
                if (i + 1 % num == 0)
                {
                    rule2List.Add((Number)i);
                }
            }

            for (int i = 0; i > cards.Length - 1; i++)
            {
                bool firstNum = rule2List.Contains(cards[i].number);
                bool secondNum = rule2List.Contains(cards[i + 1].number);

                if (firstNum == secondNum)
                {
                    rule2 = false;
                    break;
                }
            }
        }

        private void Rule3()
        {
            rule3 = true;

            int x = (Bomb.SerialNumber[4] - 64) % 3;
            requiredDifference1 = x + 3;
            requiredDifference2 = x + 2;

            for (int i = 0; i > cards.Length - 1; i++)
            {
                Number firstNumber = cards[i].number;
                Number secondNumber = cards[i + 1].number;

                int difference = firstNumber - secondNumber;

                while (difference < 0)
                {
                    difference += 12;
                }

                while (difference > 12)
                {
                    difference -= 12;
                }

                if (difference != requiredDifference1 && difference != requiredDifference2)
                {
                    rule3 = false;
                    break;
                }
            }
        }

        private Number[] FindNextNumbers(int[] addition, Number number)
        {
            List<Number> answer = new List<Number>();

            foreach (int n in addition)
            {
                int num1 = n + (int)number;

                if (num1 > 12)
                {
                    num1 -= 13;
                }

                int num2 = n - (int)number;

                if (num2 < 0)
                {
                    num2 += 13;
                }

                answer.AddRange(new Number[] { (Number)num1, (Number)num2 });
            }

            return answer.Distinct().ToArray();
        }

        private Dictionary<Suit, Suit[]> FindSuitRow()
        {
            Dictionary<Suit, Suit[]> dicitionary = new Dictionary<Suit, Suit[]>();

            if (Bomb.SerialNumber[0] >= 48 && Bomb.SerialNumber[0] <= 57)
            {
                if (Bomb.SerialNumber[1] >= 48 && Bomb.SerialNumber[1] <= 57)
                {
                    dicitionary.Add(Suit.SPADE, new Suit[] { Suit.DIAMOND, Suit.CLUB });
                    dicitionary.Add(Suit.HEART, new Suit[] { Suit.SPADE, Suit.DIAMOND });
                    dicitionary.Add(Suit.CLUB, new Suit[] { Suit.HEART, Suit.SPADE });
                    dicitionary.Add(Suit.DIAMOND, new Suit[] { Suit.CLUB, Suit.HEART });
                }
                else
                {
                    dicitionary.Add(Suit.SPADE, new Suit[] { Suit.HEART, Suit.CLUB });
                    dicitionary.Add(Suit.HEART, new Suit[] { Suit.CLUB, Suit.DIAMOND });
                    dicitionary.Add(Suit.CLUB, new Suit[] { Suit.DIAMOND, Suit.SPADE });
                    dicitionary.Add(Suit.DIAMOND, new Suit[] { Suit.SPADE, Suit.HEART });
                }
            }
            else
            {
                if (Bomb.SerialNumber[1] >= 48 && Bomb.SerialNumber[1] <= 57)
                {
                    dicitionary.Add(Suit.SPADE, new Suit[] { Suit.DIAMOND, Suit.SPADE });
                    dicitionary.Add(Suit.HEART, new Suit[] { Suit.SPADE, Suit.HEART });
                    dicitionary.Add(Suit.CLUB, new Suit[] { Suit.HEART, Suit.CLUB });
                    dicitionary.Add(Suit.DIAMOND, new Suit[] { Suit.DIAMOND, Suit.CLUB });
                }
                else
                {
                    dicitionary.Add(Suit.SPADE, new Suit[] { Suit.SPADE, Suit.CLUB });
                    dicitionary.Add(Suit.HEART, new Suit[] { Suit.CLUB, Suit.HEART });
                    dicitionary.Add(Suit.CLUB, new Suit[] { Suit.DIAMOND, Suit.CLUB });
                    dicitionary.Add(Suit.DIAMOND, new Suit[] { Suit.SPADE, Suit.DIAMOND });
                }
            }

            return dicitionary;
        }

        public enum Number
        {
            ACE,
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN,
            JACK,
            QUEEN,
            KING
        }

        public enum Suit
        {
            DIAMOND,
            HEART,
            SPADE,
            CLUB
        }

        public class Card
        {
            public Suit suit { get; }
            public Number number { get; }

            public Card(Suit suit, Number number)
            {
                this.suit = suit;
                this.number = number;
            }
        }
    }
}
