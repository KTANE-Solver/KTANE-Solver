using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date: 3/14/21
    /// Purpose: Solves the ice cream module
    /// </summary>
    public class IceCream : Module
    {
        //=======================FIELDS=======================
        //the name of the customer
        private String customer;

        //the ingredients the customer is allergic to
        private List<IceCreamFlavor.Ingredient> allergyList;

        //all of the ice cream flavors
        private IceCreamFlavor flavor1;
        private IceCreamFlavor flavor2;
        private IceCreamFlavor flavor3;
        private IceCreamFlavor flavor4;

        //=======================PROPERTIES=======================

        //=======================CONSTRUCTOR=======================
        /// <summary>
        /// Creates an instance of the ice cream module
        /// </summary>
        /// <param name="customer">the customer's name</param>
        /// <param name="flavor1">one of the ice cream flavors</param>
        /// <param name="flavor2">one of the ice cream flavors</param>
        /// <param name="flavor3">one of the ice cream flavors</param>
        /// <param name="flavor4">one of the ice cream flavors</param>
        /// <param name="Bomb">used to get the edgework</param>
        public IceCream(
            String customer,
            String flavor1,
            String flavor2,
            String flavor3,
            String flavor4,
            Bomb Bomb,
            StreamWriter LogFileWriter
        ) : base(Bomb, LogFileWriter, "Ice Cream")
        {
            this.customer = customer;

            //convert the flavor as a string to an enum
            this.flavor1 = new IceCreamFlavor(flavor1);
            this.flavor2 = new IceCreamFlavor(flavor2);
            this.flavor3 = new IceCreamFlavor(flavor3);
            this.flavor4 = new IceCreamFlavor(flavor4);
        }

        //=======================METHODS=======================
        /// <summary>
        /// Solves the ice cream module
        /// </summary>
        public void Solve()
        {
            PrintDebugLine($"Customer: {customer}\n");

            //find out what the customer is allergic to
            SetCustomerAllergies();

            PrintDebugLine("Allergy List");

            foreach (IceCreamFlavor.Ingredient ingredient in allergyList)
            {
                PrintDebugLine(ingredient.ToString());
            }

            PrintDebugLine("");

            //set the heriarachy of the flavors
            SetHeirarchy(flavor1);
            SetHeirarchy(flavor2);
            SetHeirarchy(flavor3);
            SetHeirarchy(flavor4);

            //sort the heirarchy
            IceCreamFlavor[] flavors = new IceCreamFlavor[] { flavor1, flavor2, flavor3, flavor4 };

            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    if (flavors[i].place > flavors[j].place)
                    {
                        IceCreamFlavor temp = flavors[j];

                        flavors[j] = flavors[i];

                        flavors[i] = temp;
                    }
                }
            }

            //print out the heriearcy of flavors
            PrintDebugLine("Hierarchy of Flavors:");

            for (int i = 0; i < 4; i++)
            {
                PrintDebugLine(flavors[i].FlavorProperty.ToString() + " " + flavors[i].place);

                if (i == 3)
                {
                    PrintDebugLine("");
                }
            }

            //find the most popular flavor the user isn't allergic to
            foreach (IceCreamFlavor flavor in flavors)
            {
                if (!IsAllergic(flavor))
                {
                    String message = ConvertFlavorEnumToString(flavor.FlavorProperty);

                    PrintDebugLine($"Answer: {message}\n");

                    ShowAnswer(message, true);
                    return;
                }
            }

            PrintDebugLine($"Answer: Vanilla\n");

            ShowAnswer("Vanilla", true);
        }

        /// <summary>
        /// Tells if the customer is alleric to a falvor
        /// </summary>
        /// <param name="flavor">the flavor the customer might be allergic to</param>
        /// <returns>true if the customer is allerigc to the flavor</returns>
        private bool IsAllergic(IceCreamFlavor flavor)
        {
            foreach (IceCreamFlavor.Ingredient ingredient in flavor.IngredientList)
            {
                if (allergyList.Contains(ingredient))
                {
                    PrintDebugLine(
                        $"Cant have {flavor.FlavorProperty} since allergic to {ingredient}"
                    );
                    return true;
                }
            }

            return false;
        }

        //setting the heirarachy of the flavors based on the
        //edgework
        private void SetHeirarchy(IceCreamFlavor iceCreamFlavor)
        {
            //if there are more lit than until indicators
            if (Bomb.LitIndicatorsList.Count > Bomb.UnlitIndicatorsList.Count)
            {
                //order of popularity:

                //cookies
                if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.COOKIES)
                {
                    iceCreamFlavor.place = 1;
                }
                //neapolitan
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.NEAPOLITAN)
                {
                    iceCreamFlavor.place = 2;
                }
                //tutti
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.TUTTI)
                {
                    iceCreamFlavor.place = 3;
                }
                //classic
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.CLASSIC)
                {
                    iceCreamFlavor.place = 4;
                }
                //rocky
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.ROCKY)
                {
                    iceCreamFlavor.place = 5;
                }
                //chocolate
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.CHOCOLATE)
                {
                    iceCreamFlavor.place = 6;
                }
                //mint
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.MINT)
                {
                    iceCreamFlavor.place = 7;
                }
                //strawberry
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.STRAWBERRY)
                {
                    iceCreamFlavor.place = 8;
                }
                //raspberry
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.RASPBERRY)
                {
                    iceCreamFlavor.place = 9;
                }
            }
            //if there is an empty port plate
            else if (Bomb.EmptyPortPlate)
            {
                //order of popularity:

                //chocolate
                if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.CHOCOLATE)
                {
                    iceCreamFlavor.place = 1;
                }
                //mint
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.MINT)
                {
                    iceCreamFlavor.place = 2;
                }
                //neapolitan
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.NEAPOLITAN)
                {
                    iceCreamFlavor.place = 3;
                }
                //rocky
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.ROCKY)
                {
                    iceCreamFlavor.place = 4;
                }
                //tutti
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.TUTTI)
                {
                    iceCreamFlavor.place = 5;
                }
                //strawberry
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.STRAWBERRY)
                {
                    iceCreamFlavor.place = 6;
                }
                //cookies
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.COOKIES)
                {
                    iceCreamFlavor.place = 7;
                }
                //raspberry
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.RASPBERRY)
                {
                    iceCreamFlavor.place = 8;
                }
                //classic
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.CLASSIC)
                {
                    iceCreamFlavor.place = 9;
                }
            }
            //if there are 3 or more batteries
            else if (Bomb.Battery >= 3)
            {
                //neapolitan
                if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.NEAPOLITAN)
                {
                    iceCreamFlavor.place = 1;
                }
                //tutti
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.TUTTI)
                {
                    iceCreamFlavor.place = 2;
                }
                //cookies
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.COOKIES)
                {
                    iceCreamFlavor.place = 3;
                }
                //raspberry
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.RASPBERRY)
                {
                    iceCreamFlavor.place = 4;
                }
                //strawberry
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.STRAWBERRY)
                {
                    iceCreamFlavor.place = 5;
                }
                //mint
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.MINT)
                {
                    iceCreamFlavor.place = 6;
                }
                //chocolate
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.CHOCOLATE)
                {
                    iceCreamFlavor.place = 7;
                }
                //classic
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.CLASSIC)
                {
                    iceCreamFlavor.place = 8;
                }
                //rocky
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.ROCKY)
                {
                    iceCreamFlavor.place = 9;
                }
            }
            else
            {
                //strawberry
                if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.STRAWBERRY)
                {
                    iceCreamFlavor.place = 1;
                }
                //cookies
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.COOKIES)
                {
                    iceCreamFlavor.place = 2;
                }
                //rocky
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.ROCKY)
                {
                    iceCreamFlavor.place = 3;
                }
                //classic
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.CLASSIC)
                {
                    iceCreamFlavor.place = 4;
                }
                //neapolitan
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.NEAPOLITAN)
                {
                    iceCreamFlavor.place = 5;
                }
                //chocolate
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.CHOCOLATE)
                {
                    iceCreamFlavor.place = 6;
                }
                //tutti
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.TUTTI)
                {
                    iceCreamFlavor.place = 7;
                }
                //raspberry
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.RASPBERRY)
                {
                    iceCreamFlavor.place = 8;
                }
                //mint
                else if (iceCreamFlavor.FlavorProperty == IceCreamFlavor.Flavor.MINT)
                {
                    iceCreamFlavor.place = 9;
                }
            }
        }

        /// <summary>
        /// Converts the flavor enum to an string
        /// </summary>
        /// <param name="flavor">the flavor being converted</param>
        /// <returns>the ice cream flavor as a string</returns>
        private String ConvertFlavorEnumToString(IceCreamFlavor.Flavor flavor)
        {
            switch (flavor)
            {
                case IceCreamFlavor.Flavor.COOKIES:
                    return "Cookies and Cream";
                case IceCreamFlavor.Flavor.NEAPOLITAN:
                    return "Neapolitan";
                case IceCreamFlavor.Flavor.TUTTI:
                    return "Tutti Frutti";
                case IceCreamFlavor.Flavor.CLASSIC:
                    return "The Classic";
                case IceCreamFlavor.Flavor.ROCKY:
                    return "Rocky Road";
                case IceCreamFlavor.Flavor.CHOCOLATE:
                    return "Double Chocolate";
                case IceCreamFlavor.Flavor.MINT:
                    return "Mint Chocolate Chip";
                case IceCreamFlavor.Flavor.STRAWBERRY:
                    return "Double Strawberry";
                case IceCreamFlavor.Flavor.RASPBERRY:
                    return "Raspberry Ripple";
            }

            return "Vanilla";
        }

        /// <summary>
        /// Sets what the customer is allergic to depending on the
        /// last digit of the serial number
        /// </summary>
        private void SetCustomerAllergies()
        {
            int lastDigit = Bomb.LastDigit;

            //if the serial number ends with 0 or 1
            if (lastDigit == 0 || lastDigit == 1)
            {
                switch (customer)
                {
                    case "Mike":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)0
                        };
                        break;

                    case "Tim":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)3
                        };
                        break;

                    case "Tom":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)5
                        };
                        break;

                    case "Dave":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "Adam":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "Cheryl":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)3
                        };
                        break;

                    case "Sean":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "Ashley":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)5
                        };
                        break;

                    case "Jessica":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)6
                        };
                        break;

                    case "Taylor":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)5
                        };
                        break;

                    case "Simon":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)5
                        };
                        break;

                    case "Sally":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)6
                        };
                        break;

                    case "Jade":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "Sam":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "Gary":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "Victor":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "George":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "Jacob":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Pat":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Bob":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)8
                        };
                        break;
                }
            }
            //if the serial number ends with 2 or 3
            else if (lastDigit == 2 || lastDigit == 3)
            {
                switch (customer)
                {
                    case "Mike":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)3
                        };
                        break;

                    case "Tim":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Tom":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "Dave":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Adam":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Cheryl":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Sean":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)6
                        };
                        break;

                    case "Ashley":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "Jessica":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)3
                        };
                        break;

                    case "Taylor":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)5
                        };
                        break;

                    case "Simon":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Sally":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Jade":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Sam":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "Gary":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)0
                        };
                        break;

                    case "Victor":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "George":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Jacob":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)6
                        };
                        break;

                    case "Pat":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)6
                        };
                        break;

                    case "Bob":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)0
                        };
                        break;
                }
            }
            //if the serial number ends with 4 or 5
            else if (lastDigit == 4 || lastDigit == 5)
            {
                switch (customer)
                {
                    case "Mike":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "Tim":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Tom":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Dave":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)3
                        };
                        break;

                    case "Adam":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Cheryl":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)5
                        };
                        break;

                    case "Sean":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "Ashley":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Jessica":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Taylor":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)6
                        };
                        break;

                    case "Simon":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Sally":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Jade":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)3
                        };
                        break;

                    case "Victor":
                    case "Sam":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)6
                        };
                        break;

                    case "Gary":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "George":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)3
                        };
                        break;

                    case "Jacob":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Pat":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Bob":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;
                }
            }
            //if the serial number ends with 6 or 7
            else if (lastDigit == 6 || lastDigit == 7)
            {
                switch (customer)
                {
                    case "Mike":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Tim":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "Tom":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "Dave":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "Adam":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Cheryl":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)0
                        };
                        break;

                    case "Sean":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Ashley":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Jessica":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)5
                        };
                        break;

                    case "Taylor":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)0
                        };
                        break;

                    case "Simon":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "Sally":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)8
                        };
                        break;

                    case "Jade":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)8
                        };
                        break;

                    case "Sam":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)0
                        };
                        break;

                    case "Gary":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)5
                        };
                        break;

                    case "Victor":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "George":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Jacob":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)4
                        };
                        break;

                    case "Pat":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)5
                        };
                        break;

                    case "Bob":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;
                }
            }
            //if the serial number ends with 8 or 9
            else if (lastDigit == 8 || lastDigit == 9)
            {
                switch (customer)
                {
                    case "Mike":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "Tim":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)3
                        };
                        break;

                    case "Tom":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)6
                        };
                        break;

                    case "Dave":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "Adam":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)6
                        };
                        break;

                    case "Cheryl":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)5
                        };
                        break;

                    case "Sean":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Ashley":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)7
                        };
                        break;

                    case "Jessica":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)8
                        };
                        break;

                    case "Taylor":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Simon":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)7,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)6
                        };
                        break;

                    case "Sally":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "Jade":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "Sam":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)2
                        };
                        break;

                    case "Gary":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)4,
                            (IceCreamFlavor.Ingredient)8
                        };
                        break;

                    case "Victor":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)0
                        };
                        break;

                    case "George":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)3,
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)5
                        };
                        break;

                    case "Jacob":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)6,
                            (IceCreamFlavor.Ingredient)2,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;

                    case "Pat":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)8,
                            (IceCreamFlavor.Ingredient)1,
                            (IceCreamFlavor.Ingredient)3
                        };
                        break;

                    case "Bob":
                        allergyList = new List<IceCreamFlavor.Ingredient>
                        {
                            (IceCreamFlavor.Ingredient)0,
                            (IceCreamFlavor.Ingredient)5,
                            (IceCreamFlavor.Ingredient)1
                        };
                        break;
                }
            }

            //if allergic to fruit, also add strawberries, raspberries, and cherries
            if (allergyList.Contains(IceCreamFlavor.Ingredient.FRUIT))
            {
                allergyList.Add(IceCreamFlavor.Ingredient.STRAWBERRY);
                allergyList.Add(IceCreamFlavor.Ingredient.RASPBERRY);
                allergyList.Add(IceCreamFlavor.Ingredient.CHERRY);
            }

            //get rid of duplicate ingredients
            for (int i = allergyList.Count - 1; i > -1; i--)
            {
                for (int j = allergyList.Count - 1; j > -1; j--)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    if (allergyList[i] == allergyList[j])
                    {
                        allergyList.RemoveAt(j);
                        break;
                    }
                }
            }
        }

        //=======================INNER CLASSES=======================
        /// <summary>
        /// The ice cream flavors
        /// </summary>
        private class IceCreamFlavor
        {
            //all of the flavors of ice cream
            public enum Flavor
            {
                TUTTI,
                ROCKY,
                RASPBERRY,
                CHOCOLATE,
                STRAWBERRY,
                COOKIES,
                NEAPOLITAN,
                MINT,
                CLASSIC
            }

            //all the ingredientList
            public enum Ingredient
            {
                CHOCOLATE,
                STRAWBERRY,
                RASPBERRY,
                NUTS,
                COOKIES,
                MINT,
                FRUIT,
                CHERRY,
                MARSHMALLOWS
            }

            //the current flavor of ice cream
            private Flavor flavor;

            //the ingrediants the flavor has
            private List<Ingredient> ingredientList;

            //how popular the ice crem flavor is
            public int place;

            public Flavor FlavorProperty
            {
                get { return flavor; }
            }

            public List<Ingredient> IngredientList
            {
                get { return ingredientList; }
            }

            /// <summary>
            /// Creates a new ice cream flavor and gets
            /// the list of ingredientList
            /// </summary>
            /// <param name="flavor">the flavor the ice cream flavor is</param>
            public IceCreamFlavor(String flavor)
            {
                //parses the flavor to the enum eqivulant
                this.flavor = convertFlavorStringToEnumString(flavor);
                ingredientList = new List<Ingredient>();
                SetUpIngredientList();
                place = 1000;
            }

            /// <summary>
            /// Sets up the ingrediets list depenedind on
            /// the ice cream flavor
            /// </summary>
            private void SetUpIngredientList()
            {
                ingredientList.Clear();

                switch (flavor)
                {
                    case Flavor.TUTTI:
                        ingredientList.Add(Ingredient.FRUIT);
                        break;

                    case Flavor.ROCKY:
                        ingredientList.Add(Ingredient.CHOCOLATE);
                        ingredientList.Add(Ingredient.NUTS);
                        ingredientList.Add(Ingredient.MARSHMALLOWS);
                        break;

                    case Flavor.RASPBERRY:
                        ingredientList.Add(Ingredient.RASPBERRY);
                        break;

                    case Flavor.CHOCOLATE:
                        ingredientList.Add(Ingredient.CHOCOLATE);
                        break;

                    case Flavor.STRAWBERRY:
                        ingredientList.Add(Ingredient.STRAWBERRY);
                        break;

                    case Flavor.COOKIES:
                        ingredientList.Add(Ingredient.COOKIES);
                        break;

                    case Flavor.NEAPOLITAN:
                        ingredientList.Add(Ingredient.STRAWBERRY);
                        ingredientList.Add(Ingredient.CHOCOLATE);
                        break;

                    case Flavor.MINT:
                        ingredientList.Add(Ingredient.MINT);
                        ingredientList.Add(Ingredient.CHOCOLATE);
                        break;

                    case Flavor.CLASSIC:
                        ingredientList.Add(Ingredient.CHOCOLATE);
                        ingredientList.Add(Ingredient.CHERRY);
                        break;
                }

                //if the ingredient contain fruit, then it also contains strawberry, cherry, and raspberry
                if (ingredientList.Contains(Ingredient.FRUIT))
                {
                    ingredientList.Add(Ingredient.CHERRY);
                    ingredientList.Add(Ingredient.STRAWBERRY);
                    ingredientList.Add(Ingredient.RASPBERRY);
                }
            }

            /// <summary>
            /// Converts the string of the flavor to
            /// an enum flavor
            /// of the enum
            /// </summary>
            /// <param name="flavor">the flavor as a string</param>
            /// <returns>the enum flavor</returns>
            private IceCreamFlavor.Flavor convertFlavorStringToEnumString(String flavor)
            {
                flavor = flavor.ToUpper();

                if (flavor == "TUTTI FRUTTI")
                {
                    return IceCreamFlavor.Flavor.TUTTI;
                }

                if (flavor == "ROCKY ROAD")
                {
                    return IceCreamFlavor.Flavor.ROCKY;
                }

                if (flavor == "RASPBERRY RIPPLE")
                {
                    return IceCreamFlavor.Flavor.RASPBERRY;
                }

                if (flavor == "DOUBLE CHOCOLATE")
                {
                    return IceCreamFlavor.Flavor.CHOCOLATE;
                }

                if (flavor == "DOUBLE STRAWBERRY")
                {
                    return IceCreamFlavor.Flavor.STRAWBERRY;
                }

                if (flavor == "COOKIES AND CREAM")
                {
                    return IceCreamFlavor.Flavor.COOKIES;
                }

                if (flavor == "NEAPOLITAN")
                {
                    return IceCreamFlavor.Flavor.NEAPOLITAN;
                }

                if (flavor == "MINT CHOCOLATE CHIP")
                {
                    return IceCreamFlavor.Flavor.MINT;
                }

                if (flavor == "THE CLASSIC")
                {
                    return IceCreamFlavor.Flavor.CLASSIC;
                }

                //this should never happen
                return IceCreamFlavor.Flavor.COOKIES;
            }
        }
    }
}
