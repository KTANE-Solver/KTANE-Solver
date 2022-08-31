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
    /// Purpose: Solves the Button Module
    /// </summary>
    public class Button : Module
    {
        public Button(Bomb bomb, StreamWriter logFileWriter) : base(bomb, logFileWriter, "Button")
        { }

        public string Solve(Color color, String word)
        {
            string answer;
            PrintDebugLine($"{color} {word}\n");

            if (color == Color.Red)
            {
                if (word == "Detonate")
                {
                    answer = DentonateAnswer();
                }
                else if (word == "Hold")
                {
                    answer = PressAnswer();
                }
                else
                {
                    answer = CheckAnswer();
                }
            }
            else if (color == Color.Blue)
            {
                if (word == "Abort")
                {
                    answer = HoldAnswer();
                }
                else if (word == "Detonate")
                {
                    answer = DentonateAnswer();
                }
                else
                {
                    answer = CheckAnswer();
                }
            }
            else if (color == Color.White)
            {
                if (word == "Detonate")
                {
                    answer = DentonateAnswer();
                }
                else if (Bomb.Car.Lit)
                {
                    answer = HoldAnswer();
                }
                else
                {
                    answer = CheckAnswer();
                }
            }
            else
            {
                if (word == "Detonate")
                {
                    answer = DentonateAnswer();
                }
                else
                {
                    answer = CheckAnswer();
                }
            }

            ShowAnswer(answer, true);
            return answer;
        }

        private string CheckAnswer()
        {
            if (Bomb.Battery >= 3 && Bomb.Frk.Lit)
            {
                return PressAnswer();
            }
            return HoldAnswer();
        }

        private string DentonateAnswer()
        {
            if (Bomb.Battery >= 2)
            {
                return PressAnswer();
            }

            return HoldAnswer();
        }

        private string PressAnswer()
        {
            return "Press";
        }

        private string HoldAnswer()
        {
            return "Hold Button\nBlue: 4\nYellow: 5\nElse: 1";
        }
    }
}
