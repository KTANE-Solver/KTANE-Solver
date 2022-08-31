using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class Listening : Module
    {
        private string sound;

        public Listening(string sound, Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Listening")
        {
            this.sound = sound;
        }

        public string DebugSolve()
        {
            PrintDebugLine("Sound: " + sound + "\n");

            string answer = "";
            switch (sound)
            {
                case "Taxi Dispatch":
                    answer = "&&&**";
                    break;

                case "Cow":
                    answer = "&$#$&";
                    break;

                case "Extractor Fan":
                    answer = "$#$*&";
                    break;

                case "Train Station":
                    answer = "#$$**";
                    break;

                case "Arcade":
                    answer = "$#$#*";
                    break;

                case "Casino":
                    answer = "**$*#";
                    break;

                case "Supermarket":
                    answer = "#$$&*";
                    break;

                case "Soccer Match":
                    answer = "##*$*";
                    break;

                case "Tawny Owl":
                    answer = "$#*$&";
                    break;

                case "Sewing Machine":
                    answer = "#&&*#";
                    break;

                case "Thrush Nightingale":
                    answer = "**#**";
                    break;

                case "Car Engine":
                    answer = "&#**&";
                    break;

                case "Reloading Glock 19":
                    answer = "$&**#";
                    break;

                case "Oboe":
                    answer = "&#$$#";
                    break;

                case "Saxophone":
                    answer = "$&&**";
                    break;

                case "Tuba":
                    answer = "#&$##";
                    break;

                case "Marimba":
                    answer = "&*$*$";
                    break;

                case "Phone Ringing":
                    answer = "&$$&*";
                    break;

                case "Tibetan Nuns":
                    answer = "#&&&&";
                    break;

                case "Throat Singing":
                    answer = "**$$$";
                    break;

                case "Beach":
                    answer = "*&*&&";
                    break;

                case "Dial-up Internet":
                    answer = "*#&*&";
                    break;

                case "Police Radio Scanner":
                    answer = "**###";
                    break;

                case "Censorship Bleep":
                    answer = "&&$&*";
                    break;

                case "Medieval Weapons":
                    answer = "&$**&";
                    break;

                case "Door Closing":
                    answer = "#$#&$";
                    break;

                case "Chainsaw":
                    answer = "&#&&#";
                    break;

                case "Compressed Air":
                    answer = "$$*$*";
                    break;

                case "Servo Motor":
                    answer = "$&#$$";
                    break;

                case "Waterfall":
                    answer = "&**$$";
                    break;

                case "Tearing Fabric":
                    answer = "$&&*&";
                    break;

                case "Zipper":
                    answer = "&$&##";
                    break;

                case "Vacuum Cleaner":
                    answer = "#&$*&";
                    break;

                case "Ballpoint Pen Writing":
                    answer = "$*$**";
                    break;

                case "Rattling Iron Chain":
                    answer = "*#$&&";
                    break;

                case "Book Page Turning":
                    answer = "###&$";
                    break;

                case "Table Tennis":
                    answer = "*$$&$";
                    break;

                case "Squeaky Toy":
                    answer = "$*&##";
                    break;

                case "Helicopter":
                    answer = "#&$&&";
                    break;

                case "Firework Exploding":
                    answer = "$&$$*";
                    break;

                case "Glass Shattering":
                    answer = "*$*$*";
                    break;
            }

            return answer;
        }

        public void Solve()
        {
            PrintDebugLine("Sound: " + sound + "\n");

            string answer = "";
            switch (sound)
            {
                case "Taxi Dispatch":
                    answer = "&&&**";
                    break;

                case "Cow":
                    answer = "&$#$&";
                    break;

                case "Extractor Fan":
                    answer = "$#$*&";
                    break;

                case "Train Station":
                    answer = "#$$**";
                    break;

                case "Arcade":
                    answer = "$#$#*";
                    break;

                case "Casino":
                    answer = "**$*#";
                    break;

                case "Supermarket":
                    answer = "#$$&*";
                    break;

                case "Soccer Match":
                    answer = "##*$*";
                    break;

                case "Tawny Owl":
                    answer = "$#*$&";
                    break;

                case "Sewing Machine":
                    answer = "#&&*#";
                    break;

                case "Thrush Nightingale":
                    answer = "**#**";
                    break;

                case "Car Engine":
                    answer = "&#**&";
                    break;

                case "Reloading Glock 19":
                    answer = "$&**#";
                    break;

                case "Oboe":
                    answer = "&#$$#";
                    break;

                case "Saxophone":
                    answer = "$&&**";
                    break;

                case "Tuba":
                    answer = "#&$##";
                    break;

                case "Marimba":
                    answer = "&*$*$";
                    break;

                case "Phone Ringing":
                    answer = "&$$&*";
                    break;

                case "Tibetan Nuns":
                    answer = "#&&&&";
                    break;

                case "Throat Singing":
                    answer = "**$$$";
                    break;

                case "Beach":
                    answer = "*&*&&";
                    break;

                case "Dial-up Internet":
                    answer = "*#&*&";
                    break;

                case "Police Radio Scanner":
                    answer = "**###";
                    break;

                case "Censorship Bleep":
                    answer = "&&$&*";
                    break;

                case "Medieval Weapons":
                    answer = "&$**&";
                    break;

                case "Door Closing":
                    answer = "#$#&$";
                    break;

                case "Chainsaw":
                    answer = "&#&&#";
                    break;

                case "Compressed Air":
                    answer = "$$*$*";
                    break;

                case "Servo Motor":
                    answer = "$&#$$";
                    break;

                case "Waterfall":
                    answer = "&**$$";
                    break;

                case "Tearing Fabric":
                    answer = "$&&*&";
                    break;

                case "Zipper":
                    answer = "&$&##";
                    break;

                case "Vacuum Cleaner":
                    answer = "#&$*&";
                    break;

                case "Ballpoint Pen Writing":
                    answer = "$*$**";
                    break;

                case "Rattling Iron Chain":
                    answer = "*#$&&";
                    break;

                case "Book Page Turning":
                    answer = "###&$";
                    break;

                case "Table Tennis":
                    answer = "*$$&$";
                    break;

                case "Squeaky Toy":
                    answer = "$*&##";
                    break;

                case "Helicopter":
                    answer = "#&$&&";
                    break;

                case "Firework Exploding":
                    answer = "$&$$*";
                    break;

                case "Glass Shattering":
                    answer = "*$*$*";
                    break;
            }

            ShowAnswer(answer, true);
        }
    }
}
