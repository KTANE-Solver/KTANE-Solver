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
    /// Purpose: Solves the Creation module
    /// </summary>
    public class Creation : Module
    {
        //**FIELDS**

        //goal (LifeForm)
        public LifeForm goal;

        private int permutation;

        //directions (Lifeform)
        private List<LifeForm[]> directions;
        public List<LifeForm[][]> brokenUpDirections;

        public int DirectionCount
        {
            get { return brokenUpDirections.Count; }
        }

        private Weather startingWeather;

        private LifeForm startingElement;

        private string startingElementPostion;

        private string upperLeftElement;
        private string upperRightElement;
        private string lowerLeftElement;
        private string lowerRightElement;

        //a list of all lifeforms
        public Dictionary<string, LifeForm> lifeFormList;

        public Creation(
            Bomb bomb,
            StreamWriter logFileWriter,
            Weather startingWeather,
            string upperLeftElement,
            string lowerLeftElement,
            string upperRightElement,
            string lowerRightElement
        ) : base(bomb, logFileWriter, "Creation")
        {
            lifeFormList = new Dictionary<string, LifeForm>();
            directions = new List<LifeForm[]>();
            brokenUpDirections = new List<LifeForm[][]>();

            this.startingWeather = startingWeather;
            this.upperLeftElement = upperLeftElement;
            this.upperRightElement = upperRightElement;
            this.lowerLeftElement = lowerLeftElement;
            this.lowerRightElement = lowerRightElement;
        }

        public enum Weather
        {
            Rain,
            Wind,
            HeatWave,
            MeteorShower,
            Clear
        }

        public void SetUpModule()
        {
            CreateLifeForms();
            FindStartingElement();
            FindStartingElementPosition();
            FindPermutation();
            FindGoal();
            FindRouteToGoal(goal);
            SortDirections();
            BreakUpDirections();
        }

        private Dictionary<string, LifeForm> CreateLifeForms()
        {
            LifeForm earth = new LifeForm("Earth", 0, null, null);
            LifeForm air = new LifeForm("Air", 0, null, null);
            LifeForm fire = new LifeForm("Fire", 0, null, null);
            LifeForm water = new LifeForm("Water", 0, null, null);
            LifeForm lava = new LifeForm("Lava", 1, fire, earth);
            LifeForm energy = new LifeForm("Energy", 1, fire, air);
            LifeForm dust = new LifeForm("Dust", 1, air, earth);
            LifeForm swamp = new LifeForm("Swamp", 1, earth, water);
            LifeForm steam = new LifeForm("Steam", 1, air, water);
            LifeForm alchohol = new LifeForm("Alchohol", 1, fire, water);
            LifeForm ash = new LifeForm("Ash", 2, fire, dust);
            LifeForm tar = new LifeForm("Tar", 2, fire, swamp);
            LifeForm plasma = new LifeForm("Plasma", 2, fire, energy);
            LifeForm pollen = new LifeForm("Pollen", 2, dust, swamp);
            LifeForm volcano = new LifeForm("Volcano", 2, dust, lava);
            LifeForm cement = new LifeForm("Cement", 2, dust, water);
            LifeForm life = new LifeForm("Life", 2, swamp, energy);
            LifeForm lilyPad = new LifeForm("Lily Pad", 2, swamp, water);
            LifeForm stone = new LifeForm("Stone", 2, lava, water);
            LifeForm bacteria = new LifeForm("Bacteria", 3, swamp, life);
            LifeForm ghost = new LifeForm("Ghost", 3, plasma, life);
            LifeForm metal = new LifeForm("Metal", 3, fire, stone);
            LifeForm weeds = new LifeForm("Weeds", 3, life, water);
            LifeForm sand = new LifeForm("Sand", 3, water, stone);
            LifeForm egg = new LifeForm("Egg", 3, earth, life);
            LifeForm bird = new LifeForm("Bird", 4, air, egg);
            LifeForm dinosaur = new LifeForm("Dinosaur", 4, earth, egg);
            LifeForm lizard = new LifeForm("Lizard", 4, swamp, egg);
            LifeForm seeds = new LifeForm("Seeds", 4, weeds, egg);
            LifeForm turtle = new LifeForm("Turtle", 4, water, egg);
            LifeForm mushroom = new LifeForm("Mushroom", 4, earth, weeds);
            LifeForm moss = new LifeForm("Moss", 4, swamp, weeds);
            LifeForm worm = new LifeForm("Worm", 4, swamp, bacteria);
            LifeForm plankton = new LifeForm("Plankton", 4, water, bacteria);

            earth.Created = true;
            air.Created = true;
            fire.Created = true;
            water.Created = true;

            lifeFormList.Add(earth.Name, earth);
            lifeFormList.Add(air.Name, air);
            lifeFormList.Add(fire.Name, fire);
            lifeFormList.Add(water.Name, water);
            lifeFormList.Add(lava.Name, lava);
            lifeFormList.Add(energy.Name, energy);
            lifeFormList.Add(dust.Name, dust);
            lifeFormList.Add(swamp.Name, swamp);
            lifeFormList.Add(steam.Name, steam);
            lifeFormList.Add(alchohol.Name, alchohol);
            lifeFormList.Add(ash.Name, ash);
            lifeFormList.Add(tar.Name, tar);
            lifeFormList.Add(plasma.Name, plasma);
            lifeFormList.Add(pollen.Name, pollen);
            lifeFormList.Add(volcano.Name, volcano);
            lifeFormList.Add(cement.Name, cement);
            lifeFormList.Add(life.Name, life);
            lifeFormList.Add(lilyPad.Name, lilyPad);
            lifeFormList.Add(stone.Name, stone);
            lifeFormList.Add(bacteria.Name, bacteria);
            lifeFormList.Add(ghost.Name, ghost);
            lifeFormList.Add(metal.Name, metal);
            lifeFormList.Add(weeds.Name, weeds);
            lifeFormList.Add(sand.Name, sand);
            lifeFormList.Add(egg.Name, egg);
            lifeFormList.Add(bird.Name, bird);
            lifeFormList.Add(dinosaur.Name, dinosaur);
            lifeFormList.Add(lizard.Name, lizard);
            lifeFormList.Add(seeds.Name, seeds);
            lifeFormList.Add(turtle.Name, turtle);
            lifeFormList.Add(mushroom.Name, mushroom);
            lifeFormList.Add(moss.Name, moss);
            lifeFormList.Add(worm.Name, worm);
            lifeFormList.Add(plankton.Name, plankton);

            return lifeFormList;
        }

        private void FindStartingElement()
        {
            switch (startingWeather)
            {
                case Weather.Rain:
                    startingElement = lifeFormList["Water"];
                    PrintDebugLine("Starting Element: Water\n");
                    break;

                case Weather.Wind:
                    startingElement = lifeFormList["Air"];
                    PrintDebugLine("Starting Element: Air\n");
                    break;

                case Weather.HeatWave:
                    startingElement = lifeFormList["Fire"];
                    PrintDebugLine("Starting Element: Fire\n");
                    break;

                case Weather.MeteorShower:
                    startingElement = lifeFormList["Earth"];
                    PrintDebugLine("Starting Element: Earth\n");
                    break;

                default:
                    startingElement = null;
                    PrintDebugLine("Starting Element: None\n");
                    break;
            }
        }

        private void FindStartingElementPosition()
        {
            if (startingElement == null)
            {
                PrintDebugLine("Starting Element Position: None\n");
                return;
            }

            string startingElementStr = startingElement.Name;

            if (startingElementStr == upperLeftElement)
            {
                startingElementPostion = "Upper Left";
            }
            else if (startingElementStr == upperRightElement)
            {
                startingElementPostion = "Upper Right";
            }
            else if (startingElementStr == lowerLeftElement)
            {
                startingElementPostion = "Bottom Left";
            }
            else if (startingElementStr == lowerRightElement)
            {
                startingElementPostion = "Bottom Right";
            }

            PrintDebugLine($"Starting Element Position: {startingElementPostion}\n");
        }

        private void FindPermutation()
        {
            if (startingElement == null)
            {
                permutation = 0;
            }
            else
            {
                switch (startingElementPostion)
                {
                    case "Upper Left":
                        if (startingElement == lifeFormList["Water"])
                        {
                            permutation = 2;
                        }
                        else if (startingElement == lifeFormList["Air"])
                        {
                            permutation = 1;
                        }
                        else if (startingElement == lifeFormList["Earth"])
                        {
                            permutation = 4;
                        }
                        else
                        {
                            permutation = 3;
                        }

                        break;

                    case "Upper Right":
                        if (startingElement == lifeFormList["Water"])
                        {
                            permutation = 1;
                        }
                        else if (startingElement == lifeFormList["Air"])
                        {
                            permutation = 2;
                        }
                        else if (startingElement == lifeFormList["Earth"])
                        {
                            permutation = 3;
                        }
                        else
                        {
                            permutation = 4;
                        }

                        break;

                    case "Bottom Left":
                        if (startingElement == lifeFormList["Water"])
                        {
                            permutation = 4;
                        }
                        else if (startingElement == lifeFormList["Air"])
                        {
                            permutation = 3;
                        }
                        else if (startingElement == lifeFormList["Earth"])
                        {
                            permutation = 1;
                        }
                        else
                        {
                            permutation = 2;
                        }
                        break;

                    case "Bottom Right":
                        if (startingElement == lifeFormList["Water"])
                        {
                            permutation = 3;
                        }
                        else if (startingElement == lifeFormList["Air"])
                        {
                            permutation = 4;
                        }
                        else if (startingElement == lifeFormList["Earth"])
                        {
                            permutation = 2;
                        }
                        else
                        {
                            permutation = 1;
                        }
                        break;
                }
            }

            PrintDebugLine($"Permutation: {permutation}\n");
        }

        private void FindGoal()
        {
            //Bomb has 3 or more battery holders:
            if (Bomb.BatteryHolder >= 3)
            {
                //If any lit indicators are present, AND all batteries are Double A
                if (Bomb.LitIndicatorsList.Count > 0 && Bomb.BatteryHolder * 2 == Bomb.AABattery)
                {
                    switch (permutation)
                    {
                        case 0:
                            goal = lifeFormList["Bird"];
                            break;

                        case 1:
                            goal = lifeFormList["Dinosaur"];
                            break;

                        case 2:
                            goal = lifeFormList["Turtle"];
                            break;

                        case 3:
                            goal = lifeFormList["Lizard"];
                            break;

                        case 4:
                            goal = lifeFormList["Worm"];
                            break;
                    }
                }
                //Otherwise, if any lit indicators are present
                else if (Bomb.LitIndicatorsList.Count > 0)
                {
                    switch (permutation)
                    {
                        case 0:
                            goal = lifeFormList["Dinosaur"];
                            break;

                        case 1:
                            goal = lifeFormList["Turtle"];
                            break;

                        case 2:
                            goal = lifeFormList["Lizard"];
                            break;

                        case 3:
                            goal = lifeFormList["Worm"];
                            break;

                        case 4:
                            goal = lifeFormList["Bird"];
                            break;
                    }
                }
                //Otherwise, if any unlit indicators are present AND all batteries are D cell
                else if (Bomb.UnlitIndicatorsList.Count > 0 && Bomb.BatteryHolder == Bomb.DBattery)
                {
                    switch (permutation)
                    {
                        case 0:
                            goal = lifeFormList["Turtle"];
                            break;

                        case 1:
                            goal = lifeFormList["Lizard"];
                            break;

                        case 2:
                            goal = lifeFormList["Worm"];
                            break;

                        case 3:
                            goal = lifeFormList["Bird"];
                            break;

                        case 4:
                            goal = lifeFormList["Dinosaur"];
                            break;
                    }
                }
                //Otherwise, if any unlit indicators are present
                else if (Bomb.UnlitIndicatorsList.Count > 0)
                {
                    switch (permutation)
                    {
                        case 0:
                            goal = lifeFormList["Lizard"];
                            break;

                        case 1:
                            goal = lifeFormList["Worm"];
                            break;

                        case 2:
                            goal = lifeFormList["Bird"];
                            break;

                        case 3:
                            goal = lifeFormList["Dinosaur"];
                            break;

                        case 4:
                            goal = lifeFormList["Turtle"];
                            break;
                    }
                }
                else
                {
                    switch (permutation)
                    {
                        case 0:
                            goal = lifeFormList["Worm"];
                            break;

                        case 1:
                            goal = lifeFormList["Bird"];
                            break;

                        case 2:
                            goal = lifeFormList["Dinosaur"];
                            break;

                        case 3:
                            goal = lifeFormList["Turtle"];
                            break;

                        case 4:
                            goal = lifeFormList["Lizard"];
                            break;
                    }
                }
            }
            //Bomb has 2 or fewer battery holders:
            else
            {
                //If there are more port plates than battery holders:
                if (Bomb.BatteryHolder < Bomb.PortPlateNum)
                {
                    switch (permutation)
                    {
                        case 0:
                        case 4:

                            goal = lifeFormList["Ghost"];
                            break;

                        case 1:
                            goal = lifeFormList["Plankton"];
                            break;

                        case 2:
                            goal = lifeFormList["Seeds"];
                            break;

                        case 3:
                            goal = lifeFormList["Mushroom"];
                            break;
                    }
                }
                //Otherwise, if there are any duplicate ports:
                else if (
                    Bomb.Rj.Num > 1
                    || Bomb.Serial.Num > 1
                    || Bomb.Stereo.Num > 1
                    || Bomb.Dvid.Num > 1
                    || Bomb.Ps.Num > 1
                    || Bomb.Parallel.Num > 1
                )
                {
                    switch (permutation)
                    {
                        case 0:
                        case 4:
                            goal = lifeFormList["Plankton"];
                            break;

                        case 1:
                            goal = lifeFormList["Seeds"];
                            break;

                        case 2:
                            goal = lifeFormList["Mushroom"];
                            break;

                        case 3:
                            goal = lifeFormList["Ghost"];
                            break;
                    }
                }
                //Otherwise, if there are more unlit Indicators than lit Indicators:
                else if (Bomb.UnlitIndicatorsList.Count > Bomb.LitIndicatorsList.Count)
                {
                    switch (permutation)
                    {
                        case 0:
                        case 4:

                            goal = lifeFormList["Seeds"];
                            break;

                        case 1:
                            goal = lifeFormList["Mushroom"];
                            break;

                        case 2:
                            goal = lifeFormList["Ghost"];
                            break;

                        case 3:
                            goal = lifeFormList["Plankton"];
                            break;
                    }
                }
                else
                {
                    switch (permutation)
                    {
                        case 0:
                        case 4:
                            goal = lifeFormList["Mushroom"];
                            break;

                        case 1:
                            goal = lifeFormList["Ghost"];
                            break;

                        case 2:
                            goal = lifeFormList["Plankton"];
                            break;

                        case 3:
                            goal = lifeFormList["Seeds"];
                            break;
                    }
                }
            }

            PrintDebugLine($"Goal: {goal.Name}\n");
        }

        private void FindRouteToGoal(LifeForm lifeForm)
        {
            if (!lifeForm.Created)
            {
                //create ingrediant 1
                if (!lifeForm.Ingrediant1.Created)
                {
                    FindRouteToGoal(lifeForm.Ingrediant1);
                }

                //create ingrediant 2
                if (!lifeForm.Ingrediant2.Created)
                {
                    FindRouteToGoal(lifeForm.Ingrediant2);
                }

                directions.Add(
                    new LifeForm[] { lifeForm, lifeForm.Ingrediant1, lifeForm.Ingrediant2 }
                );
                lifeForm.Created = true;
            }
        }

        private void SortDirections()
        {
            //have directions go from highest generation to lowest

            bool notSorted;
            do
            {
                notSorted = false;

                for (int i = 0; i < directions.Count - 1; i++)
                {
                    for (int j = i + 1; j < directions.Count; j++)
                    {
                        LifeForm[] leftLifeForm = directions[i];
                        LifeForm[] rightLifeForm = directions[j];

                        if (leftLifeForm[0].Generiation < rightLifeForm[0].Generiation)
                        {
                            notSorted = true;
                            directions[j] = leftLifeForm;
                            directions[i] = rightLifeForm;
                            break;
                        }
                    }

                    if (notSorted)
                    {
                        break;
                    }
                }
            } while (notSorted);
        }

        private void BreakUpDirections()
        {
            do
            {
                int endIndex = 0;
                for (int i = 0; i < directions.Count; i++)
                {
                    if (directions[i][1].Generiation == 0 || directions[i][2].Generiation == 0)
                    {
                        endIndex = i;
                        break;
                    }
                }

                if (endIndex == 0)
                {
                    brokenUpDirections.Add(new LifeForm[][] { directions[endIndex] });
                }
                else
                {
                    List<LifeForm[]> newArray = new List<LifeForm[]>();

                    for (int i = 0; i <= endIndex; i++)
                    {
                        newArray.Add(directions[i]);
                    }

                    newArray.Reverse();
                    brokenUpDirections.Add(newArray.ToArray());
                }

                for (int i = 0; i <= endIndex; i++)
                {
                    directions.RemoveAt(0);
                }
            } while (directions.Count != 0);

            brokenUpDirections.Reverse();
        }

        public string SolveTest(Weather currentWeather, int index)
        {
            string affectedElement = null;
            string newElement = null;

            switch (currentWeather)
            {
                case Weather.HeatWave:
                    affectedElement = "Fire";
                    newElement = "Water";
                    break;

                case Weather.Wind:
                    affectedElement = "Air";
                    newElement = "Earth";
                    break;

                case Weather.MeteorShower:
                    affectedElement = "Earth";
                    newElement = "Air";
                    break;

                case Weather.Rain:
                    affectedElement = "Water";
                    newElement = "Fire";
                    break;
            }

            List<string> answerSegments = new List<string>();

            foreach (LifeForm[] arr in brokenUpDirections[index])
            {
                string element1 = arr[1].Name;
                string element2 = arr[2].Name;

                if (element1 == affectedElement)
                {
                    element1 = newElement;
                }

                if (element2 == affectedElement)
                {
                    element2 = newElement;
                }

                answerSegments.Add($"{element1} + {element2}");
            }

            return string.Join(",\n", answerSegments);
        }

        public void Solve(Weather currentWeather, int index)
        {
            string affectedElement = null;
            string newElement = null;

            PrintDebugLine("Current Weather: " + currentWeather.ToString());

            switch (currentWeather)
            {
                case Weather.HeatWave:
                    affectedElement = "Fire";
                    newElement = "Water";
                    break;

                case Weather.Wind:
                    affectedElement = "Air";
                    newElement = "Earth";
                    break;

                case Weather.MeteorShower:
                    affectedElement = "Earth";
                    newElement = "Air";
                    break;

                case Weather.Rain:
                    affectedElement = "Water";
                    newElement = "Fire";
                    break;
            }

            List<string> answerSegments = new List<string>();

            foreach (LifeForm[] arr in brokenUpDirections[index])
            {
                string element1 = arr[1].Name;
                string element2 = arr[2].Name;

                if (element1 == affectedElement)
                {
                    element1 = newElement;
                }

                if (element2 == affectedElement)
                {
                    element2 = newElement;
                }

                answerSegments.Add($"{element1} + {element2}");
            }

            ShowAnswer($"\n" + string.Join(",\n", answerSegments), true);
        }

        public class LifeForm
        {
            public string Name { get; }
            public int Generiation { get; }
            public LifeForm Ingrediant1 { get; }
            public LifeForm Ingrediant2 { get; }
            public bool Created { get; set; }

            public LifeForm(string name, int generation, LifeForm ingrediant1, LifeForm ingrediant2)
            {
                Name = name;
                Generiation = generation;
                Ingrediant1 = ingrediant1;
                Ingrediant2 = ingrediant2;
                Created = false;
            }
        }
    }
}
