using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_KTANE_Solver
{
    public class OrientationCube : Module
    {
        private string eyePosition;
        public OrientationCube(Bomb bomb, StreamWriter logFileWriter, string eyePosition) : base(bomb, logFileWriter, "Orientation Cube")
        { 
            this.eyePosition = eyePosition;
        }

        public string Solve(bool debug)
        {
            string answer;

            //If the serial number contains an R
            if (Bomb.SerialNumber.Contains("R"))
            {
                switch (eyePosition)
                {
                    case "Front":
                        answer = "Clockwise, Set";
                        break;
                    case "Right":
                        answer = "Left, Counter-clockwise, Set";
                        break;
                    case "Back":
                        answer = "Counter-clockwise, Set";
                        break;
                    default:
                        answer = "Counter-clockwise, Set";
                        break;
                }
            }

            //Lit TRN or lit / unlit CAR
            else if (Bomb.Trn.Lit || Bomb.Car.VisibleNotLit)
            {
                switch (eyePosition)
                {
                    case "Front":
                        answer = "Counter-clockwise, Set";
                        break;
                    case "Right":
                        answer = "Clockwise, Right, Set";
                        break;
                    case "Back":
                        answer = "Clockwise, Set";
                        break;
                    default:
                        answer = "Clockwise, Left, Set";
                        break;
                }
            }

            else if (Bomb.PSVisible || Bomb.Strike > 0)
            {
                switch (eyePosition)
                {
                    case "Front":
                        answer = "Counter-clockwise, Left, Set";
                        break;
                    case "Right":
                        answer = "Left, Clockwise, Set";
                        break;
                    case "Back":
                        answer = "Clockwise, Left, Set";
                        break;
                    default:
                        answer = "Left, Counter-clockwise, Set";
                        break;
                }
            }

            else if (Bomb.SerialNumber.Contains("7") || Bomb.SerialNumber.Contains("8"))
            {
                switch (eyePosition)
                {
                    case "Front":
                        answer = "Clockwise, Left, Left, Set";
                        break;
                    case "Right":
                        answer = "Right, Clockwise, Right, Set";
                        break;
                    case "Back":
                        answer = "Counter-clockwise, Left, Left, Set";
                        break;
                    default:
                        answer = "Right, Counter-clockwise, Right, Set";
                        break;
                }
            }

            else if (Bomb.Battery >= 3 || eyePosition == "Left")
            {

                ShowAnswer("Clockwise", false);

                if (eyePosition == "Front")
                {
                    switch (GetNewEyePosition(new string[] { "Left", "Front", "Right" }))
                    {
                        case "Left":
                            answer = "Right, Counter-clockwise, Set";
                            break;

                        case "Front":
                            answer = "Clockwise, Set";
                            break;

                        default:
                            answer = "Right, Clockwise, Set";
                            break;
                    }
                }

                else if (eyePosition == "Right")
                {
                    switch (GetNewEyePosition(new string[] { "Front", "Right", "Back" }))
                    {
                        case "Front":
                            answer = "Left, Counter-clockwise, Set";
                            break;

                        case "Right":
                            answer = "Clockwise, Set";
                            break;

                        default:
                            answer = "Left, Counter-clockwise, Set";
                            break;
                    }
                }

                else if (eyePosition == "Back")
                {
                    switch (GetNewEyePosition(new string[] { "Right", "Back", "Left" }))
                    {
                        case "Right":
                            answer = "Left, Clockwise, Set";
                            break;

                        case "Back":
                            answer = "Clockwise, Set";
                            break;

                        default:
                            answer = "Left, Counter-clockwise, Set";
                            break;
                    }
                }

                else
                {
                    switch (GetNewEyePosition(new string[] { "Front", "Left", "Back" }))
                    {
                        case "Front":
                            answer = "Left, Counter-clockwise, Set";
                            break;

                        case "Left":
                            answer = "Clockwise, Set";
                            break;

                        default:
                            answer = "Left, Clockwise, Set";
                            break;
                    }
                }
            }

            else
            {
                switch (eyePosition)
                {
                    case "Front":
                        answer = "Counter-clockwise, Set";
                        break;
                    case "Right":
                        answer = "Clockwise, Right, Set";
                        break;
                    default:
                        answer = "Clockwise, Set";
                        break;
                }
            }

            if (!debug)
            {
                ShowAnswer(answer, true);
            }

            return answer;
        }

        private string GetNewEyePosition(string[] direction)
        {

            if (MessageBox.Show($"Is the eye in the {direction[0]}?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return direction[0];
            }

            if (MessageBox.Show($"Is the eye in the {direction[1]}?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return direction[1];
            }

            return direction[2];
        }


    }
}
