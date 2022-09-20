using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the two bits module
    /// </summary>
    public class TwoBits : Module
    {
        public int initalCode;

        public TwoBits(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Two Bits") { }

        public int GetInitalCode()
        {
            //get initial code and show the user

            //If the serial number contains a letter, use the leftmost letter's numeric
            //position in the alphabet as your base value (e.g. A=1, B=2). For no letters, use 0.

            //Add the last digit of the serial number multiplied by the number of batteries present.

            initalCode = Bomb.FirstLetter - 64 + (Bomb.LastDigit * Bomb.Battery);

            //If there is a Stereo RCA port present, double the current value.*

            //*Note: Skip this step if there is also an RJ45 port present.

            if (!Bomb.Rj.Visible && Bomb.Stereo.Visible)
            {
                initalCode *= 2;
            }

            //** Note: Use the last two digits if the value is greater than 99. Prepend with a zero if less than 10.

            initalCode %= 100;

            return initalCode;
        }

        public void Solve(int stage, int response)
        {
            PrintDebugLine($"Stage {stage}:\n");

            PrintDebugLine($"Response was {response}\n");

            String answer = ConvertCode(response, stage);
            string action;

            if (stage == 4)
            {
                action = $"Insert {answer} and press submit";
            }
            else
            {
                action = $"Insert {answer} and press query";
            }

            PrintDebugLine(action + "\n");

            ShowAnswer(action, true);
        }

        public String ConvertCode(int code, int stage)
        {
            string answer;

            switch (code)
            {
                case 0:
                    answer = "KB";
                    break;

                case 1:
                    answer = "DK";
                    break;

                case 2:
                    answer = "GV";
                    break;

                case 3:
                    answer = "TK";
                    break;

                case 4:
                    answer = "PV";
                    break;

                case 5:
                    answer = "KP";
                    break;

                case 6:
                    answer = "BV";
                    break;

                case 7:
                    answer = "VT";
                    break;

                case 8:
                    answer = "PZ";
                    break;

                case 9:
                    answer = "DT";
                    break;

                case 10:
                    answer = "EE";
                    break;

                case 11:
                    answer = "ZK";
                    break;

                case 12:
                    answer = "KE";
                    break;

                case 13:
                    answer = "CK";
                    break;

                case 14:
                    answer = "ZP";
                    break;

                case 15:
                    answer = "PP";
                    break;

                case 16:
                    answer = "TP";
                    break;

                case 17:
                    answer = "TG";
                    break;

                case 18:
                    answer = "PD";
                    break;

                case 19:
                    answer = "PT";
                    break;

                case 20:
                    answer = "TZ";
                    break;

                case 21:
                    answer = "EB";
                    break;

                case 22:
                    answer = "EC";
                    break;

                case 23:
                    answer = "CC";
                    break;

                case 24:
                    answer = "CZ";
                    break;

                case 25:
                    answer = "ZV";
                    break;

                case 26:
                    answer = "CV";
                    break;

                case 27:
                    answer = "GC";
                    break;

                case 28:
                    answer = "BT";
                    break;

                case 29:
                    answer = "GT";
                    break;

                case 30:
                    answer = "BZ";
                    break;

                case 31:
                    answer = "PK";
                    break;

                case 32:
                    answer = "KZ";
                    break;

                case 33:
                    answer = "KG";
                    break;

                case 34:
                    answer = "VD";
                    break;

                case 35:
                    answer = "CE";
                    break;

                case 36:
                    answer = "VB";
                    break;

                case 37:
                    answer = "KD";
                    break;

                case 38:
                    answer = "GG";
                    break;

                case 39:
                    answer = "DG";
                    break;

                case 40:
                    answer = "PB";
                    break;

                case 41:
                    answer = "VV";
                    break;

                case 42:
                    answer = "GE";
                    break;

                case 43:
                    answer = "KV";
                    break;

                case 44:
                    answer = "DZ";
                    break;

                case 45:
                    answer = "PE";
                    break;

                case 46:
                    answer = "DB";
                    break;

                case 47:
                    answer = "CD";
                    break;

                case 48:
                    answer = "TD";
                    break;

                case 49:
                    answer = "CB";
                    break;

                case 50:
                    answer = "GB";
                    break;

                case 51:
                    answer = "TV";
                    break;

                case 52:
                    answer = "KK";
                    break;
                case 53:
                    answer = "BG";
                    break;

                case 54:
                    answer = "BP";
                    break;

                case 55:
                    answer = "VP";
                    break;

                case 56:
                    answer = "EP";
                    break;

                case 57:
                    answer = "TT";
                    break;

                case 58:
                    answer = "ED";
                    break;

                case 59:
                    answer = "ZG";
                    break;

                case 60:
                    answer = "DE";
                    break;

                case 61:
                    answer = "DD";
                    break;

                case 62:
                    answer = "EV";
                    break;

                case 63:
                    answer = "TE";
                    break;

                case 64:
                    answer = "ZD";
                    break;

                case 65:
                    answer = "BB";
                    break;

                case 66:
                    answer = "PC";
                    break;

                case 67:
                    answer = "BD";
                    break;

                case 68:
                    answer = "KC";
                    break;

                case 69:
                    answer = "ZB";
                    break;

                case 70:
                    answer = "EG";
                    break;

                case 71:
                    answer = "BC";
                    break;

                case 72:
                    answer = "TC";
                    break;

                case 73:
                    answer = "ZE";
                    break;

                case 74:
                    answer = "ZC";
                    break;

                case 75:
                    answer = "GP";
                    break;

                case 76:
                    answer = "ET";
                    break;

                case 77:
                    answer = "VC";
                    break;

                case 78:
                    answer = "TB";
                    break;

                case 79:
                    answer = "VZ";
                    break;

                case 80:
                    answer = "EZ";
                    break;

                case 81:
                    answer = "EK";
                    break;

                case 82:
                    answer = "DV";
                    break;

                case 83:
                    answer = "CG";
                    break;

                case 84:
                    answer = "VE";
                    break;

                case 85:
                    answer = "DP";
                    break;

                case 86:
                    answer = "BK";
                    break;

                case 87:
                    answer = "PG";
                    break;

                case 88:
                    answer = "GK";
                    break;

                case 89:
                    answer = "GZ";
                    break;

                case 90:
                    answer = "KT";
                    break;

                case 91:
                    answer = "CT";
                    break;

                case 92:
                    answer = "ZZ";
                    break;

                case 93:
                    answer = "VG";
                    break;

                case 94:
                    answer = "GD";
                    break;

                case 95:
                    answer = "CP";
                    break;

                case 96:
                    answer = "BE";
                    break;

                case 97:
                    answer = "ZT";
                    break;

                case 98:
                    answer = "VK";
                    break;

                default:
                    answer = "GZ";
                    break;
            }

            return answer;
        }
    }
}
