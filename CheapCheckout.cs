using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static New_KTANE_Solver.CheapCheckout.Item;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the Cheap Checkout module
    /// </summary>
    public class CheapCheckout : Module
    {

        public enum ItemName
        {
            Bananas,
            Broccoli,
            CandyCanes,
            CanolaOil,
            Cereal,
            Cheese,
            Chicken,
            ChocolateBar,
            ChocolateMilk,
            CoffeeBeans,
            Cookies,
            Deodorant,
            FruitPunch,
            GrapeJelly,
            Grapefruit,
            Gum,
            Honey,
            Ketchup,
            Lemons,
            Lettuce,
            Lollipops,
            Lotion,
            Mayonnaise,
            Mints,
            Mustard,
            Oranges,
            PaperTowels,
            PastaSauce,
            PeanutButter,
            Pork,
            PotatoChips,
            Potatoes,
            Shampoo,
            Socks,
            Soda,
            Spaghetti,
            Steak,
            Sugar,
            Tea,
            Tissues,
            Tomatoes,
            Toothpaste,
            Turkey,
            WaterBottles,
            WhiteBread,
            WhiteMilk
        }
        
                List<Item> itemList;

        Decimal amount;

        //used to convert decimals to doubles
        double temp;

        public CheapCheckout(
            Bomb bomb,
            StreamWriter logFileWriter,
            Decimal amount,
            ItemName item1Name,
            ItemName item2Name,
            ItemName item3Name,
            ItemName item4Name,
            double item5Weight,
            ItemName item5Name,
            double item6Wieght,
            ItemName item6Name
        ) : base(bomb, logFileWriter, "Cheap Checkout")
        {
            itemList = new List<Item>()
            {
                new Item(item1Name, 1),
                new Item(item2Name, 1),
                new Item(item3Name, 1),
                new Item(item4Name, 1),
                new Item(item5Name, item5Weight),
                new Item(item6Name, item6Wieght)
            };

            this.amount = amount;
        }

        public decimal Solve(bool debug, int newAmount)
        {
            //print the day
            PrintDebugLine($"Day: {Bomb.Day}\n");

            //print the amount
            PrintDebugLine($"Amount: ${amount}\n");

            //print the items
            for (int i = 0; i < 6; i++)
            {
                PrintItem(itemList[0], i + 1);
            }
            PrintDebugLine(
                "==============================After Sale==============================\n"
            );

            //apply the sale
            ApplySale();

            //print the items
            for (int i = 0; i < 6; i++)
            {
                PrintItem(itemList[0], i + 1);
            }

            //check the total


            Decimal total = RoundPrice(
                itemList[0].price
                    + itemList[1].price
                    + itemList[2].price
                    + itemList[3].price
                    + itemList[4].price
                    + itemList[5].price
            );

            PrintDebugLine($"Total: ${total}\n");

            decimal answer = 0;
            //see if the customer has enough money
            if (amount > total)
            {
                //if yes, tell the user the amount to give back

               answer = RoundPrice(amount - total);

                PrintDebugLine($"Answer: ${answer}\n");

                if (!debug)
                { 
                    ShowAnswer($"${string.Format("{0:0.00}", answer)}", true);
                }
            }

            else if(debug)
            {
                answer = newAmount - total;
            }

            else
            {
                //if not, then tell ther user to alert the customer and tell the new amount
                CheapCheckoutAlertForm alertForm = new CheapCheckoutAlertForm(total, LogFileWriter);

                alertForm.ShowDialog();
            }

            return answer;
        }

        /// <summary>
        /// Prints information about an item
        /// </summary>
        /// <param name="item"></param>
        private void PrintItem(Item item, int num)
        {
            PrintDebugLine($"Item {num}: {item.name}");

            PrintDebugLine($"Weight: {item.weight}");

            PrintDebugLine($"Price: {item.price}");

            PrintDebugLine($"Category: {item.category}\n");
        }

        /// <summary>
        /// Applies the sale depending on the day of the week
        /// </summary>
        private void ApplySale()
        {
            switch (Bomb.Day)
            {
                case Day.Sunday:
                    //Special Sunday
                    //All fixed price items that contain an S in them are $2.15 more.

                    for (int i = 0; i < 4; i++)
                    {
                        if (itemList[i].name.ToString().ToUpper().Contains('S'))
                        {
                            itemList[i].price += 2.15m;
                        }
                    }
                    break;

                case Day.Monday:
                    //Malleable Monday
                    //The 1st, 3rd and 6th items on the shopping list are 15 % off.

                    itemList[0].price = RoundPrice(itemList[0].price *= .85m);

                    itemList[2].price = RoundPrice(itemList[2].price *= .85m);

                    itemList[5].price = RoundPrice(itemList[5].price *= .85m);

                    break;
                case Day.Tuesday:
                    //Troublesome Tuesday
                    //Calculate the digital root of the item price without the decimal point.
                    //Add that many dollars to the item price. Only applies to fixed price items.

                    for (int i = 0; i < 4; i++)
                    {
                        itemList[i].price += DigitalRoot(itemList[i].price);
                    }

                    break;
                case Day.Wednesday:
                    //Wacky Wednesday
                    //Change each occurrence of the largest digit in the price with the smallest digit
                    //in the price, and vice versa.

                    foreach (Item item in itemList)
                    {
                        item.price = WackyWednesday(item.price);
                    }

                    break;

                case Day.Thursday:
                    //Thrilling Thursday
                    //All of the odd positioned items on the shopping list are half off.

                    for (int i = 0; i < 6; i++)
                    {
                        if (i % 2 == 0)
                        {
                            itemList[i].price = Convert.ToDecimal(
                                RoundPrice(itemList[i].price /= 2)
                            );
                        }
                    }
                    break;
                case Day.Friday:
                    //Fruity Friday
                    //All fruits are 25 % more per pound.

                    for (int i = 4; i < 6; i++)
                    {
                        if (itemList[i].category == Item.Category.Fruit)
                        {
                            temp = Convert.ToDouble(itemList[i].price);
                            itemList[i].price = Convert.ToDecimal(
                                RoundPrice(Convert.ToDecimal(temp *= 1.25 * itemList[i].weight))
                            );
                        }
                    }
                    break;

                case Day.Saturday:
                    //Sweet Saturday
                    //All sweet items are 35 % off.

                    foreach (Item item in itemList)
                    {
                        if (item.category == Item.Category.Sweet)
                        {
                            item.price = Convert.ToDecimal(RoundPrice(item.price /= .65m));
                        }
                    }
                    break;
            }
        }

        private Decimal WackyWednesday(Decimal price)
        {
            //convert price to string
            string pricestring = ("" + price);

            //find highest value

            char highestDigit = pricestring[0];

            for (int i = 1; i < pricestring.Length; i++)
            {
                char currentChar = pricestring[i];

                //highest character can't be '.'
                if (currentChar == '.')
                {
                    continue;
                }

                if (highestDigit < currentChar)
                {
                    highestDigit = currentChar;
                }
            }

            //find the lowest digit

            char lowestDigit = pricestring[0];

            for (int i = 1; i < pricestring.Length; i++)
            {
                //lowest digit can't be '.'
                if (lowestDigit == '.')
                {
                    lowestDigit = pricestring[i];
                }

                char currentChar = pricestring[i];

                //lowest digit can't be '.'
                if (currentChar == '.')
                {
                    continue;
                }

                if (lowestDigit > currentChar)
                {
                    lowestDigit = currentChar;
                }
            }

            string newPrice = "";

            //for every place with the lowest digit, swap it with the highest digit

            //for every place with the highest digit, swap it with the lowest digit

            for (int i = 0; i < pricestring.Length; i++)
            {
                char currentChar = pricestring[i];

                if (currentChar == highestDigit)
                    newPrice += lowestDigit;
                else if (currentChar == lowestDigit)
                    newPrice += highestDigit;
                else
                    newPrice += pricestring[i];
            }

            //insert the .

            newPrice.Insert(pricestring.IndexOf('.'), ".");

            //parse the price and return

            return Decimal.Parse(newPrice);
        }

        private int DigitalRoot(Decimal price)
        {
            //remove .

            string newPricestring = price.ToString().Replace(".", "");

            //convert to int

            int newPrice = Int32.Parse(newPricestring);

            int root = 0;

            // Loop to do sum while
            // sum is not less than
            // or equal to 9
            while (newPrice > 0 || root > 9)
            {
                if (newPrice == 0)
                {
                    newPrice = root;
                    root = 0;
                }

                root += newPrice % 10;
                newPrice /= 10;
            }
            return root;
        }

        /// <summary>
        /// Rounds the price always up to 2 decimals
        /// </summary>
        private Decimal RoundPrice(Decimal oldPrice)
        {
            //round the price
            return Math.Round(oldPrice, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Represents each item
        /// </summary>
        public class Item
        {
            //The category each item can fits into
            public enum Category
            {
                CareProduct,
                Dairy,
                Fruit,
                Grain,
                Protein,
                Oil,
                Other,
                Sweet,
                Vegetable,
                Water
            }

            public ItemName name;

            public Decimal price;

            public double weight;

            public Category category;

            public Item(ItemName name, double weight)
            {
                this.name = name;
                this.weight = weight;

                //set up price and category
                switch (name)
                {
                    case ItemName.Bananas:
                        price = Convert.ToDecimal(RoundPrice(0.87m, weight));
                        category = Category.Fruit;
                        break;

                    case ItemName.Broccoli:
                        price = Convert.ToDecimal(RoundPrice(1.39m, weight));
                        category = Category.Vegetable;
                        break;

                    case ItemName.CandyCanes:
                        price = Convert.ToDecimal(RoundPrice(3.51m, weight));
                        category = Category.Sweet;
                        break;

                    case ItemName.CanolaOil:
                        price = Convert.ToDecimal(RoundPrice(2.28m, weight));
                        category = Category.Oil;
                        break;

                    case ItemName.Cereal:
                        price = Convert.ToDecimal(RoundPrice(4.19m, weight));
                        category = Category.Grain;
                        break;

                    case ItemName.Cheese:
                        price = Convert.ToDecimal(RoundPrice(4.49m, weight));
                        category = Category.Dairy;
                        break;

                    case ItemName.Chicken:
                        price = Convert.ToDecimal(RoundPrice(1.99m, weight));
                        category = Category.Protein;
                        break;

                    case ItemName.ChocolateBar:
                        price = Convert.ToDecimal(RoundPrice(2.10m, weight));
                        category = Category.Sweet;
                        break;

                    case ItemName.ChocolateMilk:
                        price = Convert.ToDecimal(RoundPrice(5.68m, weight));
                        category = Category.Dairy;
                        break;

                    case ItemName.CoffeeBeans:
                        price = Convert.ToDecimal(RoundPrice(7.85m, weight));
                        category = Category.Other;
                        break;

                    case ItemName.Cookies:
                        price = Convert.ToDecimal(RoundPrice(2.00m, weight));
                        category = Category.Sweet;
                        break;

                    case ItemName.Deodorant:
                        price = Convert.ToDecimal(RoundPrice(3.97m, weight));
                        category = Category.CareProduct;
                        break;

                    case ItemName.FruitPunch:
                        price = Convert.ToDecimal(RoundPrice(2.08m, weight));
                        category = Category.Sweet;
                        break;

                    case ItemName.GrapeJelly:
                        price = Convert.ToDecimal(RoundPrice(2.98m, weight));
                        category = Category.Sweet;
                        break;

                    case ItemName.Grapefruit:
                        price = Convert.ToDecimal(RoundPrice(1.08m, weight));
                        category = Category.Fruit;
                        break;

                    case ItemName.Gum:
                        price = Convert.ToDecimal(RoundPrice(1.12m, weight));
                        category = Category.Sweet;
                        break;

                    case ItemName.Honey:
                        price = Convert.ToDecimal(RoundPrice(8.25m, weight));
                        category = Category.Sweet;
                        break;

                    case ItemName.Ketchup:
                        price = Convert.ToDecimal(RoundPrice(3.59m, weight));
                        category = Category.Other;
                        break;

                    case ItemName.Lemons:
                        price = Convert.ToDecimal(RoundPrice(1.74m, weight));
                        category = Category.Fruit;
                        break;

                    case ItemName.Lettuce:
                        price = Convert.ToDecimal(RoundPrice(1.10m, weight));
                        category = Category.Vegetable;
                        break;

                    case ItemName.Lollipops:
                        price = Convert.ToDecimal(RoundPrice(2.61m, weight));
                        category = Category.Sweet;
                        break;

                    case ItemName.Lotion:
                        price = Convert.ToDecimal(RoundPrice(7.97m, weight));
                        category = Category.CareProduct;
                        break;

                    case ItemName.Mayonnaise:
                        price = Convert.ToDecimal(RoundPrice(3.99m, weight));
                        category = Category.Oil;
                        break;

                    case ItemName.Mints:
                        price = Convert.ToDecimal(RoundPrice(6.39m, weight));
                        category = Category.Sweet;
                        break;

                    case ItemName.Mustard:
                        price = Convert.ToDecimal(RoundPrice(2.36m, weight));
                        category = Category.Other;
                        break;

                    case ItemName.Oranges:
                        price = Convert.ToDecimal(RoundPrice(0.80m, weight));
                        category = Category.Fruit;
                        break;

                    case ItemName.PaperTowels:
                        price = Convert.ToDecimal(RoundPrice(9.46m, weight));
                        category = Category.CareProduct;
                        break;

                    case ItemName.PastaSauce:
                        price = Convert.ToDecimal(RoundPrice(2.30m, weight));
                        category = Category.Vegetable;
                        break;

                    case ItemName.PeanutButter:
                        price = Convert.ToDecimal(RoundPrice(5.00m, weight));
                        category = Category.Protein;
                        break;

                    case ItemName.Pork:
                        price = Convert.ToDecimal(RoundPrice(4.14m, weight));
                        category = Category.Protein;
                        break;

                    case ItemName.PotatoChips:
                        price = Convert.ToDecimal(RoundPrice(3.25m, weight));
                        category = Category.Oil;
                        break;

                    case ItemName.Potatoes:
                        price = Convert.ToDecimal(RoundPrice(0.68m, weight));
                        category = Category.Vegetable;
                        break;

                    case ItemName.Shampoo:
                        price = Convert.ToDecimal(RoundPrice(4.98m, weight));
                        category = Category.CareProduct;
                        break;

                    case ItemName.Socks:
                        price = Convert.ToDecimal(RoundPrice(6.97m, weight));
                        category = Category.Other;
                        break;

                    case ItemName.Soda:
                        price = Convert.ToDecimal(RoundPrice(2.05m, weight));
                        category = Category.Sweet;
                        break;

                    case ItemName.Spaghetti:
                        price = Convert.ToDecimal(RoundPrice(2.92m, weight));
                        category = Category.Grain;
                        break;

                    case ItemName.Steak:
                        price = Convert.ToDecimal(RoundPrice(4.97m, weight));
                        category = Category.Protein;
                        break;

                    case ItemName.Sugar:
                        price = Convert.ToDecimal(RoundPrice(2.08m, weight));
                        category = Category.Sweet;
                        break;

                    case ItemName.Tea:
                        price = Convert.ToDecimal(RoundPrice(2.35m, weight));
                        category = Category.Water;
                        break;

                    case ItemName.Tissues:
                        price = Convert.ToDecimal(RoundPrice(3.94m, weight));
                        category = Category.CareProduct;
                        break;

                    case ItemName.Tomatoes:
                        price = Convert.ToDecimal(RoundPrice(1.80m, weight));
                        category = Category.Fruit;
                        break;

                    case ItemName.Toothpaste:
                        price = Convert.ToDecimal(RoundPrice(2.50m, weight));
                        category = Category.CareProduct;
                        break;

                    case ItemName.Turkey:
                        price = Convert.ToDecimal(RoundPrice(2.98m, weight));
                        category = Category.Protein;
                        break;

                    case ItemName.WaterBottles:
                        price = Convert.ToDecimal(RoundPrice(9.37m, weight));
                        category = Category.Water;
                        break;

                    case ItemName.WhiteBread:
                        price = Convert.ToDecimal(RoundPrice(2.43m, weight));
                        category = Category.Grain;
                        break;

                    case ItemName.WhiteMilk:
                        price = Convert.ToDecimal(RoundPrice(3.62m, weight));
                        category = Category.Dairy;
                        break;
                }
            }

            private decimal RoundPrice(decimal amount, double weight)
            {
                return decimal.Round(
                    amount * Convert.ToDecimal(weight),
                    2,
                    MidpointRounding.AwayFromZero
                );
            }
        }
    }
}
