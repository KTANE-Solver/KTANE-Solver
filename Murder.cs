using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date: 4/9/21
    /// Purpose: Solves the murder moudle
    /// </summary>
    public class Murder : Module
    {
        //all the rooms
        public enum Room
        {
            DINING,
            STUDY,
            KITCHEN,
            LOUNGE,
            BILLIARD,
            CONSERVATORY,
            BALLROOM,
            HALL,
            LIBRARY
        }

        //the four suspects
        private List<Suspect> suspects;

        //the four weapons
        private List<Weapon> weapons;

        //the room the body was found
        private Room bodyRoom;

        /// <summary>
        ///
        /// </summary>
        /// <param name="suspects">the four suspects</param>
        /// <param name="weapons">the four weapons</param>
        /// <param name="bodyRoom">the room the body was found</param>
        /// <param name="bomb">used for edgoework</param>
        /// <param name="logFileWriter">used to write to the log file</param>
        public Murder(
            String[] suspects,
            String[] weapons,
            String bodyRoom,
            Bomb bomb,
            StreamWriter logFileWriter
        ) : base(bomb, logFileWriter, "Murder")
        {
            this.suspects = new List<Suspect>();
            this.weapons = new List<Weapon>();

            for (int i = 0; i < 4; i++)
            {
                this.suspects.Add(new Suspect(Suspect.ConvertNameStringToEnum(suspects[i])));
                PrintDebugLine($"Suspect {i + 1}: {suspects[i]}\n");
            }

            for (int i = 0; i < 4; i++)
            {
                this.weapons.Add(new Weapon(Weapon.ConverStringToEnum(weapons[i])));
                PrintDebugLine($"Weapon {i + 1}: {weapons[i]}\n");
            }

            PrintDebugLine($"Body found: {bodyRoom}\n");

            this.bodyRoom = Suspect.ConvertRoomToEnum(bodyRoom);
        }

        public string Solve(bool debug)
        {
            //who did it
            String murderer = null;

            //what they did it with
            String killingItem = null;

            //where they did it
            String room = null;

            //the row to figure out where suspects were
            int suspectRow = FindSuspectRow();

            PrintDebugLine("Suspect Row: " + suspectRow);

            //find where each suspect was
            foreach (Suspect suspect in suspects)
            {
                suspect.SetRoom(suspectRow);
            }

            //the row to figure out where weapon was

            int weaponRow = FindWeaponRow();

            PrintDebugLine("Weapon Row: " + weaponRow + "\n");

            //find where each weapon was
            foreach (Weapon weapon in weapons)
            {
                weapon.SetRoom(weaponRow);
            }

            bool answerFound = false;
            //find which suspect and row were in the same room
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (weapons[i].room == suspects[j].room)
                    {
                        answerFound = true;
                        murderer = Suspect.ConvertEnumToString(suspects[j].name);
                        killingItem = Weapon.ConvertEnumToNameString(weapons[i].name);
                        room = Suspect.ConvertRoomToString(suspects[j].room);
                        break;
                    }
                }
                if (answerFound)
                {
                    break;
                }
            }
            string answer = $"{murderer} with the {killingItem} in the {room}";


            PrintDebugLine(answer + "\n");

            if (!debug)
            { 
                ShowAnswer(answer, true);
            }

            return answer;
        }

        /// <summary>
        /// Finds the suspect row
        /// </summary>
        /// <returns></returns>
        private int FindSuspectRow()
        {
            //If there is a lit indicator with label TRN, use row 5 to locate the suspects.
            if (Bomb.Trn.Lit)
            {
                return 5;
            }

            //Otherwise, if the body was found in the Dining Room, use row 7.
            if (bodyRoom == Room.DINING)
            {
                return 7;
            }

            //Otherwise, if the bomb has 2 or more Stereo RCA ports, use row 8.
            if (Bomb.RcaNum >= 2)
            {
                return 8;
            }
            //Otherwise, if there are no D batteries on the bomb, use row 2.
            if (Bomb.DBattery == 0)
            {
                return 2;
            }

            //Otherwise, if the body was found in the Study, use row 4.
            if (bodyRoom == Room.STUDY)
            {
                return 4;
            }

            //Otherwise, if there are 5 or more batteries, use row 9.
            if (Bomb.Battery >= 5)
            {
                return 9;
            }

            //Otherwise, if there is an unlit indicator with label FRQ, use row 1.
            if (Bomb.Frq.VisibleNotLit)
            {
                return 1;
            }

            //Otherwise, if the body was found in the Conservatory, use row 3.
            if (bodyRoom == Room.CONSERVATORY)
            {
                return 3;
            }

            //Otherwise, the suspects can be located using row 6.
            return 6;
        }

        /// <summary>
        /// Finds the suspect row
        /// </summary>
        private int FindWeaponRow()
        {
            //If the body was found in the Lounge, use row 3 to locate the weapons.
            if (bodyRoom == Room.LOUNGE)
            {
                return 3;
            }

            //Otherwise, if there are 5 or more batteries, use row 1.
            if (Bomb.Battery >= 5)
            {
                return 1;
            }

            //Otherwise, if the bomb has a serial port, use row 9.
            if (Bomb.SerialVisble)
            {
                return 9;
            }

            //Otherwise, if the body was found in the Billiard Room, use row 4.
            if (bodyRoom == Room.BILLIARD)
            {
                return 4;
            }

            //Otherwise, if there are no batteries on the bomb, use row 6.
            if (Bomb.Battery == 0)
            {
                return 6;
            }

            //Otherwise, if there are no lit indicators on the bomb, use row 5.
            if (Bomb.LitIndicatorsList.Count == 0)
            {
                return 5;
            }

            //Otherwise, if the body was found in the Hall, use row 7.
            if (bodyRoom == Room.HALL)
            {
                return 7;
            }

            //Otherwise, if the bomb has 2 or more Stereo RCA ports, use row 2.
            if (Bomb.RcaNum >= 2)
            {
                return 2;
            }

            //Otherwise, the weapons can be located using row 8.
            return 8;
        }

        //Represetns each suspect
        public class Suspect
        {
            public enum Name
            {
                SCARLETT,
                PLUM,
                PEACOCK,
                GREEN,
                MUSTARD,
                WHITE
            }

            //name of the suspect
            public Name name;

            //the room the suspect was by the time of the murder
            public Room room;

            /// <summary>
            /// Sets up the Suspect
            /// </summary>
            /// <param name="name">the name of the suspect</param>
            /// <param name="bodyRoom">where the body was found</param>
            public Suspect(Name name)
            {
                this.name = name;
            }

            /// <summary>
            /// Finds where the wapon was at the time of the mmurder
            /// </summary>
            /// <param name="num">the weapon row</param>
            public void SetRoom(int num)
            {
                switch (name)
                {
                    case Name.SCARLETT:
                        if (num == 1)
                        {
                            room = Room.DINING;
                        }
                        else if (num == 2)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 3)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 4)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 5)
                        {
                            room = Room.BILLIARD;
                        }
                        else if (num == 6)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 7)
                        {
                            room = Room.BALLROOM;
                        }
                        else if (num == 8)
                        {
                            room = Room.HALL;
                        }
                        else if (num == 9)
                        {
                            room = Room.LIBRARY;
                        }
                        break;
                    case Name.PLUM:
                        if (num == 1)
                        {
                            room = Room.LIBRARY;
                        }
                        else if (num == 2)
                        {
                            room = Room.HALL;
                        }
                        else if (num == 3)
                        {
                            room = Room.BILLIARD;
                        }
                        else if (num == 4)
                        {
                            room = Room.BALLROOM;
                        }
                        else if (num == 5)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 6)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 7)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 8)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 9)
                        {
                            room = Room.DINING;
                        }
                        break;
                    case Name.PEACOCK:

                        if (num == 1)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 2)
                        {
                            room = Room.BILLIARD;
                        }
                        else if (num == 3)
                        {
                            room = Room.BALLROOM;
                        }
                        else if (num == 4)
                        {
                            room = Room.DINING;
                        }
                        else if (num == 5)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 6)
                        {
                            room = Room.LIBRARY;
                        }
                        else if (num == 7)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 8)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 9)
                        {
                            room = Room.HALL;
                        }
                        break;

                    case Name.GREEN:
                        if (num == 1)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 2)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 3)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 4)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 5)
                        {
                            room = Room.BALLROOM;
                        }
                        else if (num == 6)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 7)
                        {
                            room = Room.HALL;
                        }
                        else if (num == 8)
                        {
                            room = Room.DINING;
                        }
                        else if (num == 9)
                        {
                            room = Room.BILLIARD;
                        }
                        break;

                    case Name.MUSTARD:
                        if (num == 1)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 2)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 3)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 4)
                        {
                            room = Room.HALL;
                        }
                        else if (num == 5)
                        {
                            room = Room.DINING;
                        }
                        else if (num == 6)
                        {
                            room = Room.BILLIARD;
                        }
                        else if (num == 7)
                        {
                            room = Room.LIBRARY;
                        }
                        else if (num == 8)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 9)
                        {
                            room = Room.BALLROOM;
                        }
                        break;

                    case Name.WHITE:
                        if (num == 1)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 2)
                        {
                            room = Room.LIBRARY;
                        }
                        else if (num == 3)
                        {
                            room = Room.DINING;
                        }
                        else if (num == 4)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 5)
                        {
                            room = Room.HALL;
                        }
                        else if (num == 6)
                        {
                            room = Room.BALLROOM;
                        }
                        else if (num == 7)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 8)
                        {
                            room = Room.BILLIARD;
                        }
                        else if (num == 9)
                        {
                            room = Room.LOUNGE;
                        }
                        break;
                }
            }

            /// <summary>
            /// Converts the name of string to its enum
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static Name ConvertNameStringToEnum(String name)
            {
                if (name == "Scarlett")
                {
                    return Name.SCARLETT;
                }

                if (name == "Plum")
                {
                    return Name.PLUM;
                }

                if (name == "Mustard")
                {
                    return Name.MUSTARD;
                }

                if (name == "Peacock")
                {
                    return Name.PEACOCK;
                }

                if (name == "Green")
                {
                    return Name.GREEN;
                }

                return Name.WHITE;
            }

            /// <summary>
            /// Converts the name of enum to a string
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static String ConvertEnumToString(Name name)
            {
                switch (name)
                {
                    case Name.SCARLETT:
                        return "Scarlett";

                    case Name.PLUM:
                        return "Plum";

                    case Name.PEACOCK:
                        return "Peacock";

                    case Name.GREEN:
                        return "Green";

                    case Name.MUSTARD:
                        return "Mustard";

                    case Name.WHITE:
                        return "White";
                }

                return null;
            }

            /// <summary>
            /// Converts room to its enum equilivant
            /// </summary>
            /// <param name="room"></param>
            public static Room ConvertRoomToEnum(String room)
            {
                if (room == "Dining Room")
                {
                    return Room.DINING;
                }
                else if (room == "Study")
                {
                    return Room.STUDY;
                }
                else if (room == "Kitchen")
                {
                    return Room.KITCHEN;
                }
                else if (room == "Lounge")
                {
                    return Room.LOUNGE;
                }
                else if (room == "Billiard Room")
                {
                    return Room.BILLIARD;
                }
                else if (room == "Conservatory")
                {
                    return Room.CONSERVATORY;
                }
                else if (room == "Ballroom")
                {
                    return Room.BALLROOM;
                }
                else if (room == "Hall")
                {
                    return Room.HALL;
                }

                return Room.LIBRARY;
            }

            /// <summary>
            /// Converts a room to a string
            /// </summary>
            /// <param name="room"></param>
            /// <returns></returns>
            public static String ConvertRoomToString(Room room)
            {
                switch (room)
                {
                    case Room.DINING:
                        return "Dining Room";
                    case Room.STUDY:
                        return "Study";

                    case Room.KITCHEN:
                        return "Kitchen";

                    case Room.LOUNGE:
                        return "Lounge";

                    case Room.BILLIARD:
                        return "Billiard Room";

                    case Room.CONSERVATORY:
                        return "Conservatory";

                    case Room.BALLROOM:
                        return "Ballroom";
                    case Room.HALL:
                        return "Hall";

                    case Room.LIBRARY:
                        return "Library";
                }

                return null;
            }
        }

        //Represetns each suspect
        public class Weapon
        {
            public enum Name
            {
                CANDLE,
                DAGGER,
                PIPE,
                REVOLVER,
                ROPE,
                SPANNER
            }

            //name of the weapon
            public Name name { get; }

            //the room the weapon was by the time of the murder
            public Room room;

            /// <summary>
            /// Sets up the Weapon
            /// </summary>
            /// <param name="name">the name of the weapon</param>
            /// <param name="bodyRoom">where the body was found</param>
            public Weapon(Name name)
            {
                this.name = name;
            }

            /// <summary>
            /// Finds where the wapon was at the time of the mmurder
            /// </summary>
            /// <param name="num">the weapon row</param>
            public void SetRoom(int num)
            {
                switch (name)
                {
                    case Name.CANDLE:
                        if (num == 1)
                        {
                            room = Room.DINING;
                        }
                        else if (num == 2)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 3)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 4)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 5)
                        {
                            room = Room.BILLIARD;
                        }
                        else if (num == 6)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 7)
                        {
                            room = Room.BALLROOM;
                        }
                        else if (num == 8)
                        {
                            room = Room.HALL;
                        }
                        else if (num == 9)
                        {
                            room = Room.LIBRARY;
                        }
                        break;
                    case Name.DAGGER:
                        if (num == 1)
                        {
                            room = Room.LIBRARY;
                        }
                        else if (num == 2)
                        {
                            room = Room.HALL;
                        }
                        else if (num == 3)
                        {
                            room = Room.BILLIARD;
                        }
                        else if (num == 4)
                        {
                            room = Room.BALLROOM;
                        }
                        else if (num == 5)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 6)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 7)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 8)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 9)
                        {
                            room = Room.DINING;
                        }
                        break;
                    case Name.PIPE:

                        if (num == 1)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 2)
                        {
                            room = Room.BILLIARD;
                        }
                        else if (num == 3)
                        {
                            room = Room.BALLROOM;
                        }
                        else if (num == 4)
                        {
                            room = Room.DINING;
                        }
                        else if (num == 5)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 6)
                        {
                            room = Room.LIBRARY;
                        }
                        else if (num == 7)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 8)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 9)
                        {
                            room = Room.HALL;
                        }
                        break;

                    case Name.REVOLVER:
                        if (num == 1)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 2)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 3)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 4)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 5)
                        {
                            room = Room.BALLROOM;
                        }
                        else if (num == 6)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 7)
                        {
                            room = Room.HALL;
                        }
                        else if (num == 8)
                        {
                            room = Room.DINING;
                        }
                        else if (num == 9)
                        {
                            room = Room.BILLIARD;
                        }
                        break;

                    case Name.ROPE:
                        if (num == 1)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 2)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 3)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 4)
                        {
                            room = Room.HALL;
                        }
                        else if (num == 5)
                        {
                            room = Room.DINING;
                        }
                        else if (num == 6)
                        {
                            room = Room.BILLIARD;
                        }
                        else if (num == 7)
                        {
                            room = Room.LIBRARY;
                        }
                        else if (num == 8)
                        {
                            room = Room.LOUNGE;
                        }
                        else if (num == 9)
                        {
                            room = Room.BALLROOM;
                        }
                        break;

                    case Name.SPANNER:
                        if (num == 1)
                        {
                            room = Room.CONSERVATORY;
                        }
                        else if (num == 2)
                        {
                            room = Room.LIBRARY;
                        }
                        else if (num == 3)
                        {
                            room = Room.DINING;
                        }
                        else if (num == 4)
                        {
                            room = Room.KITCHEN;
                        }
                        else if (num == 5)
                        {
                            room = Room.HALL;
                        }
                        else if (num == 6)
                        {
                            room = Room.BALLROOM;
                        }
                        else if (num == 7)
                        {
                            room = Room.STUDY;
                        }
                        else if (num == 8)
                        {
                            room = Room.BILLIARD;
                        }
                        else if (num == 9)
                        {
                            room = Room.LOUNGE;
                        }
                        break;
                }
            }

            /// <summary>
            /// Converts the name of string to its enum
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static Name ConverStringToEnum(String name)
            {
                if (name == "Candle Stick")
                {
                    return Name.CANDLE;
                }

                if (name == "Dagger")
                {
                    return Name.DAGGER;
                }

                if (name == "Lead Pipe")
                {
                    return Name.PIPE;
                }

                if (name == "Revolver")
                {
                    return Name.REVOLVER;
                }

                if (name == "Rope")
                {
                    return Name.ROPE;
                }

                return Name.SPANNER;
            }

            /// <summary>
            /// Converts the name of enum to a string
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static String ConvertEnumToNameString(Name name)
            {
                switch (name)
                {
                    case Name.CANDLE:
                        return "Candle Stick";

                    case Name.DAGGER:
                        return "Dagger";

                    case Name.PIPE:
                        return "Pipe";

                    case Name.REVOLVER:
                        return "Revolver";
                    case Name.ROPE:
                        return "Rope";

                    case Name.SPANNER:
                        return "Spanner";
                }

                return null;
            }
        }
    }
}
