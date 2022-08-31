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
    /// Purpose: Solves the Adventure Game module
    /// </summary>
    public class AdventureGame : Module
    {
        Item item1;
        Item item2;
        Item item3;
        Item item4;
        Item item5;

        Weapon weapon1;
        Weapon weapon2;
        Weapon weapon3;

        int strength;
        int dexterity;
        int intelligence;
        int height;
        int temperature;
        double gravity;
        int pressure;
        string answer;

        Enemy enemy;

        public AdventureGame(
            int strength,
            int dexterity,
            int intelligence,
            int height,
            int temperature,
            double gravity,
            int pressure,
            string weapon1String,
            string weapon2String,
            string weapon3String,
            Item item1,
            Item item2,
            Item item3,
            Item item4,
            Item item5,
            string enemyString,
            Bomb bomb,
            StreamWriter logFileWriter
        ) : base(bomb, logFileWriter, "Adventure Game")
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
            this.height = height;
            this.temperature = temperature;
            this.gravity = gravity;
            this.pressure = pressure;

            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;

            weapon1 = new Weapon(weapon1String);
            weapon2 = new Weapon(weapon2String);
            weapon3 = new Weapon(weapon3String);

            enemy = new Enemy(enemyString);

            answer = "";
        }

        /// <summary>
        /// Solve the Advenuture Game module
        /// </summary>
        public void Solve()
        {
            PrintDebugLine("======================ADVENTURE GAME======================\n");

            PrintDebugLine("Enemy: " + enemy.Name);
            PrintDebugLine("Strength: " + enemy.Strength);
            PrintDebugLine("Dexterity: " + enemy.Dexterity);
            PrintDebugLine($"Intelligence: {enemy.Intelligence}\n");

            PrintDebugLine("Strength: " + strength);
            PrintDebugLine("Dexterity: " + dexterity);
            PrintDebugLine("Intelligence: " + intelligence);
            PrintDebugLine("Height: " + height);
            PrintDebugLine("Temperature: " + temperature);
            PrintDebugLine("Gravity: " + gravity);
            PrintDebugLine($"Pressure: {pressure}\n");

            PrintDebugLine("Items\n");
            PrintDebugLine(item1.ToString());
            PrintDebugLine(item2.ToString());
            PrintDebugLine(item3.ToString());
            PrintDebugLine(item4.ToString());
            PrintDebugLine(item5.ToString());

            //check which Items to use
            CheckItem(item1);
            CheckItem(item2);
            CheckItem(item3);
            CheckItem(item4);
            CheckItem(item5);

            //check which weapon does most damage
            int damage1 = DamageDealt(weapon1);
            int damage2 = DamageDealt(weapon2);
            int damage3 = DamageDealt(weapon3);

            PrintDebugLine("Weapons\n");
            PrintDebugLine($"{weapon1.Name}: {damage1}");
            PrintDebugLine($"{weapon2.Name}: {damage2}");
            PrintDebugLine($"{weapon3.Name}: {damage3}\n");

            if (damage1 >= damage2 && damage1 >= damage3)
            {
                answer += weapon1.Name;
            }
            else if (damage2 >= damage1 && damage2 >= damage3)
            {
                answer += weapon2.Name;
            }
            else
            {
                answer += weapon3.Name;
            }

            PrintDebugLine($"Answer:\n\n{answer}\n");

            ShowAnswer(answer, true);
        }

        private void CheckItem(Item item)
        {
            if (UseItem(item))
            {
                answer += item.ToString() + "\n";
            }
        }

        /// <summary>
        /// Figures out if an item needs to be used
        /// </summary>
        /// <param name="item">the targeted item</param>
        /// <returns>true if the item is being used</returns>
        private bool UseItem(Item item)
        {
            switch (item)
            {
                //Gravity is less than 9.3 m/s² or pressure is greater than 110 kPa, and not fighting an Eagle.
                case Item.BALLOON:
                    return (gravity < 9.3 || pressure > 110) && enemy.Name != "EAGLE";

                //There is at most 1 battery on the bomb, and fighting an enemy other than a Golem or a Wizard.
                case Item.BATTERY:
                    return Bomb.Battery <= 1 && enemy.Name != "GOLEM" && enemy.Name != "WIZARD";

                //If fighting a Dragon or an Eagle, use if pressure is greater than 105 kPa. If fighting a different enemy, use if pressure is less than 95 kPa.
                case Item.BELLOWS:
                    return enemy.Name == "DRAGON" || enemy.Name == "EAGLE"
                        ? pressure > 105
                        : pressure < 95;

                //cheat codes are never used, potions were already used at this point (can't use them twice)
                case Item.CHEATCODE:
                case Item.POTION:
                    return false;

                //INT is greater than the last digit of the serial number, and not fighting a Wizard.
                case Item.CRYSTALBALL:
                    return enemy.Name != "WIZARD" && intelligence > Bomb.LastDigit;

                //DEX is greater than either STR or INT.
                case Item.FEATHER:
                    return dexterity > strength || dexterity > intelligence;

                //There are two or more of the same port on the bomb.
                case Item.HARDDRIVE:
                    return Bomb.Dvid.Num > 1
                        || Bomb.Parallel.Num > 1
                        || Bomb.Ps.Num > 1
                        || Bomb.Rj.Num > 1
                        || Bomb.Serial.Num > 1
                        || Bomb.Stereo.Num > 1;

                //Temperature is less than 12°C, and not fighting a Lizard.
                case Item.LAMP:
                    return temperature < 12 && enemy.Name != "LIZARD";

                //There are at least two unlit indicators on the bomb.

                case Item.MOONSTONE:
                    return Bomb.UnlitIndicatorsList.Count >= 2;

                //Fighting an enemy other than a Demon, a Dragon, or a Troll.
                case Item.SMALLDOG:
                    return !(
                        enemy.Name == "DEMON" || enemy.Name == "DRAGON" || enemy.Name == "TROLL"
                    );

                //The player is shorter than 4’, and fighting an enemy other than a Goblin or a Lizard.
                case Item.STEPLADDER:
                    return height < 48 && !(enemy.Name == "GOBLIN" || enemy.Name == "LIZARD");

                //There are at least two lit indicators on the bomb.
                case Item.SUNSTONE:
                    return Bomb.LitIndicatorsList.Count >= 2;

                //Fighting a Demon or a Golem, or if the temperature is greater than 31°C.
                case Item.SYMBOL:
                    return enemy.Name == "DEMON" || enemy.Name == "GOLEM" || temperature > 31;

                //The player is 4’ 6” or taller, and gravity is at least 9.2 m/s², and at most 10.4 m/s².
                case Item.TICKET:
                    return height >= 54 && gravity >= 9.2 && gravity <= 10.4;

                //Trophy
                //STR is greater than the first numeric digit of the serial number, or if fighting a Troll.
                default:
                    return strength > Bomb.FirstDigit || enemy.Name == "TROLL";
            }
        }

        /// <summary>
        /// Tells how much damage a weapon deals
        /// </summary>
        /// <param name="weapon">the weapon in question</param>
        /// <returns>how much damage the weapon does</returns>
        private int DamageDealt(Weapon weapon)
        {
            int damageDelt;

            if (weapon.Name == "BROADSWORD" || weapon.Name == "CABER")
            {
                damageDelt = weapon.Strength + strength - enemy.Strength;
            }
            else if (weapon.Name == "NASTY KNIFE" || weapon.Name == "LONGBOW")
            {
                damageDelt = weapon.Dexterity + dexterity - enemy.Dexterity;
            }
            else
            {
                damageDelt = weapon.Intelligence + intelligence - enemy.Intelligence;
            }

            return damageDelt;
        }

        public enum Item
        {
            BALLOON,
            BATTERY,
            BELLOWS,
            CHEATCODE,
            CRYSTALBALL,
            FEATHER,
            HARDDRIVE,
            LAMP,
            MOONSTONE,
            POTION,
            SMALLDOG,
            STEPLADDER,
            SUNSTONE,
            SYMBOL,
            TICKET,
            TROPHY
        }

        public class Weapon
        {
            public string Name { get; }
            public int Strength { get; }
            public int Intelligence { get; }
            public int Dexterity { get; }

            public Weapon(string name)
            {
                Name = name.ToUpper();
                switch (Name)
                {
                    case "BROADSWORD":
                    case "NASTY KNIFE":
                    case "MAGIC ORB":
                        Strength = 0;
                        Intelligence = 0;
                        Dexterity = 0;
                        break;

                    case "CABER":
                        Strength = 2;
                        Intelligence = 0;
                        Dexterity = 0;
                        break;

                    case "LONGBOW":
                        Strength = 0;
                        Intelligence = 0;
                        Dexterity = 2;
                        break;

                    default:
                        Strength = 0;
                        Intelligence = 2;
                        Dexterity = 0;
                        break;
                }
            }
        }

        public class Enemy
        {
            public string Name { get; }
            public int Strength { get; }
            public int Intelligence { get; }
            public int Dexterity { get; }

            public Enemy(string name)
            {
                Name = name.ToUpper();
                switch (Name)
                {
                    case "DEMON":
                        Strength = 50;
                        Dexterity = 50;
                        Intelligence = 50;
                        break;
                    case "DRAGON":
                        Strength = 10;
                        Dexterity = 11;
                        Intelligence = 13;
                        break;
                    case "EAGLE":
                        Strength = 4;
                        Dexterity = 7;
                        Intelligence = 3;
                        break;
                    case "GOBLIN":
                        Strength = 3;
                        Dexterity = 6;
                        Intelligence = 5;
                        break;
                    case "GOLEM":
                        Strength = 9;
                        Dexterity = 4;
                        Intelligence = 7;
                        break;
                    case "TROLL":
                        Strength = 8;
                        Dexterity = 5;
                        Intelligence = 4;
                        break;
                    case "LIZARD":
                        Strength = 4;
                        Dexterity = 6;
                        Intelligence = 3;
                        break;
                    default:
                        Strength = 4;
                        Dexterity = 3;
                        Intelligence = 8;
                        break;
                }
            }
        }
    }
}
