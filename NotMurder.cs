using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_KTANE_Solver
{
    public class NotMurder : Module
    {

        public enum Item
        {
            Candlestick,
            Dagger,
            Pipe,
            Revolver,
            Rope,
            Spanner
        }

        Suspect plum;
        Suspect green;
        Suspect peacock;


        Room[,] rooms = new Room[2,3]; 
        
        Suspect[] suspects = new Suspect[5];
        Item[] items = new Item[5];

        private bool greenClockwise;
        private List<string> peacockRooms;
        private bool pausePlum;



        public NotMurder(Bomb bomb, StreamWriter logFile, string[] suspects, Item[] weapons, string[] rooms, string redRoom) : base(bomb, logFile, "Not Murder")
        {
            peacockRooms = new List<string>();
            FillItems(weapons);
            FillSuspects(suspects);
            FillRooms(rooms, redRoom);
            greenClockwise = true;
            pausePlum = false;

            plum = FindSuspect("Plum");
            peacock = FindSuspect("Peacock");
            green = FindSuspect("Green");

        }

        private Suspect FindSuspect(string name)
        {
            Suspect suspect;

            try
            {
                suspect = this.suspects.First(s => s.Name == name);
            }

            catch

            {
                suspect = null;
            }

            return suspect;
        }

        private void FillItems(Item[] weapons)
        {
            items[0] = weapons[0];

            bool left = Bomb.RcaNum > 3 || Bomb.Plates.Any(x => x.OnlyRCA());

            PrintDebugLine($"Items: {(left ? "left" : "right")}");

            for (int i = 1; i < 5; i++)
            {
                int index = left ? 5 - i : i;

                if (index == 5)
                {
                    PrintDebug("");
                }

                items[i] = weapons[index];
            }
        }

        private void FillSuspects(string[] suspects)
        {
            this.suspects[0] = new Suspect(suspects[0], items[0]);

            bool left = Bomb.Trn.Visible;

            PrintDebugLine($"Suspects: {(left ? "left" : "right")}");

            for (int i = 1; i < 5; i++)
            {
                int index = left ? 5 - i : i;

                this.suspects[i] = new Suspect(suspects[index], items[i]);
            }
        }

        private void FillRooms(string[] rooms, string redRoom)
        {
            int suspectCounter = 0;
            bool left = Bomb.DigitSum > 14;

            PrintDebugLine($"Rooms: {(left ? "left" : "right")}\n");

            for (int i = 0; i < 6; i++)
            {
                int row = i / 3;
                int col = i % 3;

                int index = left ? 6 - i : i;

                if (rooms[index % 6] == redRoom)
                {
                    this.rooms[row, col] = new Room(redRoom);
                }

                else
                {
                    Suspect suspect = suspects[suspectCounter];

                    this.rooms[row, col] = new Room(rooms[i], suspect);

                    Room room = this.rooms[row, col];

                    suspect.CurrentRoom = room;

                    if (suspect.Name == "Peacock")
                    {
                        peacockRooms.Add(room.Name);
                    }

                    suspectCounter++;
                }
            }

            int[] clockMap = new int[] { 1,2,5,0,3,4};
            int[] counterMap = new int[] { 3,0,1,4,5,2 };

            for (int i = 0; i < 6; i++)
            {
                int row = i / 3;
                int col = i % 3;
                this.rooms[row, col].Clock = this.rooms[clockMap[i] / 3, clockMap[i] % 3];
                this.rooms[row, col].Counter = this.rooms[counterMap[i] / 3, counterMap[i] % 3];

                try
                {
                    this.rooms[row, col].Top = this.rooms[row - 1, col];
                }
                catch
                {}

                try
                {
                    this.rooms[row, col].Down = this.rooms[row + 1, col];
                }
                catch
                {}

                try
                {
                    this.rooms[row, col].Left = this.rooms[row, col - 1];
                }
                catch
                {}

                try
                {
                    this.rooms[row, col].Right = this.rooms[row, col + 1];
                }
                catch
                {}
            }
        }

        public string Solve(bool debug)
        {
            PrintHouse(0);


            for (int i = 1; i <= 5; i++)
            {
                Move();

                for (int j = 0; j < 6; j++)
                {
                    rooms[j / 3, j % 3].SwapWeapons();
                }

                PrintHouse(i);
            }

            string answer = string.Join("\n", suspects.Select(s => $"{s.Name} with the {s.Item} in the {s.CurrentRoom.Name}"));

            if (!debug)
            {
                ShowAnswer(answer, true);
            }

            return answer;
        }

        public void PrintHouse(int stage)
        {
            PrintDebugLine("Turn " + stage);

            foreach (Room room in rooms)
            {
                string suspectInfo = string.Join(" ", room.Suspects.Select(s => s.SuspectInfo()));

                PrintDebugLine($"{room.Name}: {suspectInfo}");
            }

            PrintDebugLine("");

        }

        public void Move()
        {
            foreach (Suspect s in suspects)
            {
                if (s.Name == "Plum" && pausePlum)
                {
                    pausePlum= false;
                    continue;
                }

                s.Move(greenClockwise, peacockRooms);
            }

            foreach(Room r in rooms)
            {
                r.Suspects.Clear();
            }

            foreach (Suspect s in suspects)
            {
                s.CurrentRoom = s.NewRoom ?? s.CurrentRoom;
                s.CurrentRoom.AddSuspect(s);
            }


            //if plum is used, check to see if he will be frozen on the next turn
            if (!pausePlum && plum != null && new string[] { "Library", "Lounge", "Study" }.Contains(plum.CurrentRoom.Name))
            {
                pausePlum = true;
            }

            //if green is used, update his directional movement here

            if (green != null && new string[] { "Conservatory", "Kitchen", "Study" }.Contains(green.CurrentRoom.Name))
            {
                greenClockwise = !greenClockwise;
            }

            //if peacock is used, update which rooms she has gone from here

            if (peacock != null) 
            {
                peacockRooms.Add(peacock.CurrentRoom.Name);
            }
        }

        public class Suspect
        {
            public string Name { get; }
            public Item Item;
            public Room CurrentRoom;
            public Room NewRoom;
            public Suspect(string name, Item item)
            {
                Name = name;
                Item = item;
            }

            public string SuspectInfo()
            {
                return $"{Name}/{Item}";
            }

            public void Move(bool greenClockwise, List<string> peacockRooms)
            {
                NewRoom = null;
                List<Room> adjacentRooms = CurrentRoom.AdjacentRooms();

                switch (Name)
                {
                    case "Green":
                        
                        if (greenClockwise)
                        {
                            NewRoom = CurrentRoom.Clock;
                        }
                        
                        else
                        {
                            NewRoom = CurrentRoom.Counter;
                        }

                        break;
                    case "Peacock":

                        //She will avoid entering any room she has previously entered, including the room she broke into.

                        List<Room> avaiableRooms = adjacentRooms.Where(r => !peacockRooms.Contains(r.Name)).ToList();

                        avaiableRooms.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));

                        //If she cannot move into a room she has not already entered, she move about the building in a counter-clockwise direction.
                        if (avaiableRooms.Count == 0)
                        {
                            NewRoom = CurrentRoom.Counter;
                        }

                        else
                        {
                            NewRoom = avaiableRooms.First();
                        }


                        break;

                    case "Scarlett":
                        //If all adjacent rooms are empty, she will move between the front and back of the building.
                        bool isEmpty = adjacentRooms.Where(r => r.Suspects.Count == 0).Count() == adjacentRooms.Count;

                        if (isEmpty)
                        {
                            NewRoom = CurrentRoom.Top ?? CurrentRoom.Down;
                        }

                        else
                        {
                            Dictionary<Room, int> d = new Dictionary<Room, int>();

                            foreach (Room r in adjacentRooms)
                            {
                                if(r.Suspects.Count != 0)
                                {
                                    d.Add(r, r.Suspects.Count);
                                }
                            }

                            if (d.Keys.Count == 1)
                            { 
                                NewRoom = d.Keys.First();
                            }

                            else
                            {
                                int max = d.Values.Max();

                                bool tie = d.Values.Where(n => n == max).Count() > 1;

                                if (!tie)
                                {
                                    NewRoom = d.First(x => x.Value == max).Key;
                                }
                            }
                            
                        }


                        break;

                    case "Plum":
                        List<Room> emptyRooms = adjacentRooms.Where(r => r.Suspects.Count == 0).ToList();

                        if (emptyRooms.Count == 1)
                        {
                            NewRoom = emptyRooms.First();
                        }

                        else
                        {
                            adjacentRooms.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));
                            NewRoom = adjacentRooms.First();
                        }
                        break;

                    case "White":
                        List<Room> whiteRooms = new List<Room>();
                        foreach (Room r in adjacentRooms)
                        {
                            bool badWeaponsFound = r.Suspects.Where(s => new Item[] { Item.Revolver, Item.Dagger }.Contains(s.Item)).Any();

                            if (!badWeaponsFound)
                            {
                                whiteRooms.Add(r);
                            }

                           
                        }

                        if (whiteRooms.Count > 0)
                        {
                            whiteRooms.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));
                            List<Room> preferredRooms = whiteRooms.Where(r => !new string[] { "Ballroom", "Billiard", "Conservatory" }.Contains(r.Name)).ToList();

                            NewRoom = preferredRooms.Count > 0 ? preferredRooms.First() : whiteRooms.First();
                        }
                        break;

                        //Mustard

                    default:

                        if (Item == Item.Revolver)
                        {
                            List<Room> rooms = adjacentRooms.Where(r => r.Suspects.Count != 1).ToList();

                            if (rooms.Count > 0)
                            {
                                if (rooms.Contains(CurrentRoom.Clock))
                                {
                                    NewRoom = CurrentRoom.Clock;
                                }

                                else if (CurrentRoom.Top != null && CurrentRoom.Down != null)
                                {
                                    NewRoom = CurrentRoom.Top ?? CurrentRoom.Down;
                                }

                                else
                                {
                                    NewRoom = CurrentRoom.Counter;
                                }
                            }
                        }

                        else
                        {
                            try
                            {
                                Room revolverRoom = adjacentRooms.Where(r => r.Suspects.Where(s => s.Item == Item.Revolver).Any()).First();

                                NewRoom = revolverRoom;
                            }
                            catch
                            {
                                if (CurrentRoom.Left != null && CurrentRoom.Right != null)
                                {
                                    NewRoom = CurrentRoom.Top ?? CurrentRoom.Down;
                                }

                                else
                                {
                                    NewRoom = CurrentRoom.Right ?? CurrentRoom.Left;
                                }
                            }
                        }
                        break;
                }
            }
        }



        public class Room
        {
            public List<Suspect>  Suspects;
            public Room Top { get; set; }
            public Room Left { get; set; }
            public Room Down { get; set; }
            public Room Right { get; set; }
            public Room Clock { get; set; }
            public Room Counter { get; set; }

            public string Name { get; }
            public Room(string name)
            {
                this.Name = name;
                Suspects = new List<Suspect>();
            }

            public Room(string name, Suspect suspect)
            {
                this.Name = name;
                Suspects = new List<Suspect>() { suspect };
                Top = null;
                Left = null;
                Down = null;
                Right = null;
                Clock = null;
                Counter = null;
            }

            public void AddSuspect(Suspect suspect)
            {
                Suspects.Add(suspect);
            }

            public List<Room> AdjacentRooms()
            {
                return new List<Room>() { Top, Left, Down, Right }.Where(r => r != null).ToList();
            }

            public void SwapWeapons()
            {
                if (Suspects.Count == 2)
                { 
                    Suspect s1 = Suspects[0];
                    Suspect s2 = Suspects[1];

                    Item temp = s1.Item;

                    s1.Item = s2.Item;
                    s2.Item = temp;

                }
            }

        } 
    }
}
