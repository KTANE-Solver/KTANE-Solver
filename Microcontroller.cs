using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class Microcontroller : Module
    {

        public enum DotPos
        {
            TL,
            TR,
            BL,
            BR
        }

        private DotPos whiteDotCorner;
        private string moduleType;
        private int pinNum;
        private int secondDigit;
        private int lastDigit;
        public List<Pin> pinList;
        public Dictionary<string, Color> colorDictionary;

        public Microcontroller(
            Bomb bomb,
            StreamWriter logFileWriter,
            DotPos whiteDotCorner,
            string moduleType,
            int pinNum,
            int secondDigit,
            int lastDigit
        ) : base(bomb, logFileWriter, "Microcontroller")
        {
            this.whiteDotCorner = whiteDotCorner;
            this.moduleType = moduleType;
            this.pinNum = pinNum;
            this.secondDigit = secondDigit;
            this.lastDigit = lastDigit;
            pinList = new List<Pin>();
            colorDictionary = new Dictionary<string, Color>();
        }

        public void FindColor()
        {
            colorDictionary.Add("GND", Color.White);
            //If the last digit of the controller's serial number is 1 or 4
            if (lastDigit == 1 || lastDigit == 4)
            {
                colorDictionary.Add("VCC", Color.Yellow);
                colorDictionary.Add("AIN", Color.Magenta);
                colorDictionary.Add("DIN", Color.Green);
                colorDictionary.Add("PWM", Color.Blue);
                colorDictionary.Add("RST", Color.Red);

                PrintDebugLine("The last digit of the controller's serial number is 1 or 4\n");
            }
            //Otherwise, if there is a lit indicator "SIG" or a RJ-45 port
            else if (Bomb.Sig.Lit || Bomb.RJVisible)
            {
                colorDictionary.Add("VCC", Color.Yellow);
                colorDictionary.Add("AIN", Color.Red);
                colorDictionary.Add("DIN", Color.Magenta);
                colorDictionary.Add("PWM", Color.Green);
                colorDictionary.Add("RST", Color.Blue);

                PrintDebugLine("There is a lit indicator SIG or a RJ-45 port\n");
            }
            //Otherwise, if the bomb's serial number contains C, L, R, X, 1 or 8
            else if (
                Bomb.SerialNumber.Contains('C')
                || Bomb.SerialNumber.Contains('L')
                || Bomb.SerialNumber.Contains('R')
                || Bomb.SerialNumber.Contains('X')
                || Bomb.SerialNumber.Contains('1')
                || Bomb.SerialNumber.Contains('8')
            )
            {
                colorDictionary.Add("VCC", Color.Red);
                colorDictionary.Add("AIN", Color.Magenta);
                colorDictionary.Add("DIN", Color.Green);
                colorDictionary.Add("PWM", Color.Blue);
                colorDictionary.Add("RST", Color.Yellow);

                PrintDebugLine("The bomb's serial number contains C, L, R, X, 1 or 8\n");
            }
            //Otherwise, if the second numerical digit of the controller's serial number matches the number of batteries on the bomb
            else if (secondDigit == Bomb.Battery)
            {
                colorDictionary.Add("VCC", Color.Red);
                colorDictionary.Add("AIN", Color.Blue);
                colorDictionary.Add("DIN", Color.Yellow);
                colorDictionary.Add("PWM", Color.Green);
                colorDictionary.Add("RST", Color.Magenta);

                PrintDebugLine(
                    "The second numerical digit of the controller's serial number matches the number of batteries on the bomb\n"
                );
            }
            else
            {
                colorDictionary.Add("VCC", Color.Green);
                colorDictionary.Add("AIN", Color.Red);
                colorDictionary.Add("DIN", Color.Yellow);
                colorDictionary.Add("PWM", Color.Blue);
                colorDictionary.Add("RST", Color.Magenta);

                PrintDebugLine("No above color condition applies\n");
            }
        }

        public void SetUpModule()
        {
            PrintDebugLine($"Controller Type: {moduleType}");
            PrintDebugLine($"White Dot Corner: {whiteDotCorner}");
            PrintDebugLine($"Second Controller Digit: {secondDigit}");
            PrintDebugLine($"Last Controller Digit: {lastDigit}\n");

            FindColor();

            for (int i = 1; i <= pinNum; i++)
            {
                pinList.Add(
                    new Pin(i, moduleType, pinNum, secondDigit, lastDigit, Bomb, colorDictionary)
                );
            }

            foreach (Pin p in pinList)
            {
                PrintDebugLine(p.PrintPin() + "\n");
            }
        }

        public List<Color> Solve()
        {
            SetUpModule();

            List<Color> answers = new List<Color>();
            int halfPinNum = pinNum / 2;
            switch (whiteDotCorner)
            {
                case DotPos.TL:

                    for (int i = 0; i < halfPinNum; i++)
                    {
                        answers.Add(pinList[i].color);
                    }

                    for (int i = pinNum - 1; i >= halfPinNum; i--)
                    {
                        answers.Add(pinList[i].color);
                    }

                    return answers;

                case DotPos.TR:
                    for (int i = halfPinNum - 1; i >= 0; i--)
                    {
                        answers.Add(pinList[i].color);
                    }

                    for (int i = halfPinNum; i < pinNum; i++)
                    {
                        answers.Add(pinList[i].color);
                    }

                    return answers;

                case DotPos.BL:
                    for (int i = pinNum - 1; i >= halfPinNum; i--)
                    {
                        answers.Add(pinList[i].color);
                    }

                    for (int i = 0; i < halfPinNum; i++)
                    {
                        answers.Add(pinList[i].color);
                    }

                    return answers;

                default:
                    for (int i = halfPinNum; i < pinList.Count; i++)
                    {
                        answers.Add(pinList[i].color);
                    }

                    for (int i = halfPinNum - 1; i >= 0; i--)
                    {
                        answers.Add(pinList[i].color);
                    }

                    return answers;
            }
        }

        public class Pin
        {
            private int index;
            public string name;
            public Color color
            {
                get { return c; }
            }
            private Color c;

            public Pin(
                int index,
                string moduleType,
                int pinNum,
                int secondDigit,
                int lastDigit,
                Bomb bomb,
                Dictionary<string, Color> colorDictionary
            )
            {
                this.index = index;
                SetName(moduleType, pinNum);
                SetColor(colorDictionary);
            }

            private void SetName(string moduleType, int pinNum)
            {
                if (pinNum == 6)
                {
                    switch (moduleType)
                    {
                        case "STRK":
                            if (index == 1)
                            {
                                name = "AIN";
                            }
                            else if (index == 2)
                            {
                                name = "VCC";
                            }
                            else if (index == 3)
                            {
                                name = "RST";
                            }
                            else if (index == 4)
                            {
                                name = "DIN";
                            }
                            else if (index == 5)
                            {
                                name = "PWM";
                            }
                            else
                            {
                                name = "GND";
                            }
                            break;

                        case "LEDS":
                            if (index == 1)
                            {
                                name = "PWM";
                            }
                            else if (index == 2)
                            {
                                name = "RST";
                            }
                            else if (index == 3)
                            {
                                name = "VCC";
                            }
                            else if (index == 4)
                            {
                                name = "DIN";
                            }
                            else if (index == 5)
                            {
                                name = "AIN";
                            }
                            else
                            {
                                name = "GND";
                            }
                            break;

                        case "CNTD":
                            if (index == 1)
                            {
                                name = "GND";
                            }
                            else if (index == 2)
                            {
                                name = "AIN";
                            }
                            else if (index == 3)
                            {
                                name = "PWM";
                            }
                            else if (index == 4)
                            {
                                name = "VCC";
                            }
                            else if (index == 5)
                            {
                                name = "DIN";
                            }
                            else
                            {
                                name = "RST";
                            }
                            break;

                        case "EXPL":
                            if (index == 1)
                            {
                                name = "PWM";
                            }
                            else if (index == 2)
                            {
                                name = "VCC";
                            }
                            else if (index == 3)
                            {
                                name = "RST";
                            }
                            else if (index == 4)
                            {
                                name = "AIN";
                            }
                            else if (index == 5)
                            {
                                name = "DIN";
                            }
                            else
                            {
                                name = "GND";
                            }
                            break;
                    }
                }
                else if (pinNum == 8)
                {
                    switch (moduleType)
                    {
                        case "STRK":
                            if (index == 1)
                            {
                                name = "AIN";
                            }
                            else if (index == 2)
                            {
                                name = "PWM";
                            }
                            else if (index == 3)
                            {
                                name = "GND";
                            }
                            else if (index == 4)
                            {
                                name = "DIN";
                            }
                            else if (index == 5)
                            {
                                name = "VCC";
                            }
                            else if (index == 6)
                            {
                                name = "GND";
                            }
                            else if (index == 7)
                            {
                                name = "RST";
                            }
                            else
                            {
                                name = "GND";
                            }
                            break;

                        case "LEDS":
                            if (index == 1)
                            {
                                name = "PWM";
                            }
                            else if (index == 2)
                            {
                                name = "DIN";
                            }
                            else if (index == 3)
                            {
                                name = "VCC";
                            }
                            else if (index == 4)
                            {
                                name = "GND";
                            }
                            else if (index == 5)
                            {
                                name = "AIN";
                            }
                            else if (index == 6)
                            {
                                name = "GND";
                            }
                            else if (index == 7)
                            {
                                name = "RST";
                            }
                            else
                            {
                                name = "GND";
                            }
                            break;

                        case "CNTD":
                            if (index == 1)
                            {
                                name = "PWM";
                            }
                            else if (index == 2)
                            {
                                name = "GND";
                            }
                            else if (index == 3)
                            {
                                name = "GND";
                            }
                            else if (index == 4)
                            {
                                name = "VCC";
                            }
                            else if (index == 5)
                            {
                                name = "AIN";
                            }
                            else if (index == 6)
                            {
                                name = "GND";
                            }
                            else if (index == 7)
                            {
                                name = "DIN";
                            }
                            else
                            {
                                name = "RST";
                            }
                            break;

                        case "EXPL":
                            if (index == 1)
                            {
                                name = "AIN";
                            }
                            else if (index == 2)
                            {
                                name = "GND";
                            }
                            else if (index == 3)
                            {
                                name = "RST";
                            }
                            else if (index == 4)
                            {
                                name = "GND";
                            }
                            else if (index == 5)
                            {
                                name = "VCC";
                            }
                            else if (index == 6)
                            {
                                name = "GND";
                            }
                            else if (index == 7)
                            {
                                name = "DIN";
                            }
                            else
                            {
                                name = "PWM";
                            }
                            break;
                    }
                }
                else if (pinNum == 10)
                {
                    switch (moduleType)
                    {
                        case "STRK":
                            if (index == 1)
                            {
                                name = "GND";
                            }
                            else if (index == 2)
                            {
                                name = "GND";
                            }
                            else if (index == 3)
                            {
                                name = "GND";
                            }
                            else if (index == 4)
                            {
                                name = "GND";
                            }
                            else if (index == 5)
                            {
                                name = "AIN";
                            }
                            else if (index == 6)
                            {
                                name = "DIN";
                            }
                            else if (index == 7)
                            {
                                name = "GND";
                            }
                            else if (index == 8)
                            {
                                name = "VCC";
                            }
                            else if (index == 9)
                            {
                                name = "RST";
                            }
                            else
                            {
                                name = "PWM";
                            }
                            break;

                        case "LEDS":
                            if (index == 1)
                            {
                                name = "PWM";
                            }
                            else if (index == 2)
                            {
                                name = "AIN";
                            }
                            else if (index == 3)
                            {
                                name = "DIN";
                            }
                            else if (index == 4)
                            {
                                name = "GND";
                            }
                            else if (index == 5)
                            {
                                name = "GND";
                            }
                            else if (index == 6)
                            {
                                name = "GND";
                            }
                            else if (index == 7)
                            {
                                name = "GND";
                            }
                            else if (index == 8)
                            {
                                name = "RST";
                            }
                            else if (index == 9)
                            {
                                name = "VCC";
                            }
                            else
                            {
                                name = "GND";
                            }
                            break;

                        case "CNTD":
                            if (index == 1)
                            {
                                name = "PWM";
                            }
                            else if (index == 2)
                            {
                                name = "DIN";
                            }
                            else if (index == 3)
                            {
                                name = "AIN";
                            }
                            else if (index == 4)
                            {
                                name = "GND";
                            }
                            else if (index == 5)
                            {
                                name = "GND";
                            }
                            else if (index == 6)
                            {
                                name = "VCC";
                            }
                            else if (index == 7)
                            {
                                name = "GND";
                            }
                            else if (index == 8)
                            {
                                name = "GND";
                            }
                            else if (index == 9)
                            {
                                name = "RST";
                            }
                            else
                            {
                                name = "GND";
                            }
                            break;

                        case "EXPL":
                            if (index == 1)
                            {
                                name = "RST";
                            }
                            else if (index == 2)
                            {
                                name = "DIN";
                            }
                            else if (index == 3)
                            {
                                name = "VCC";
                            }
                            else if (index == 4)
                            {
                                name = "GND";
                            }
                            else if (index == 5)
                            {
                                name = "GND";
                            }
                            else if (index == 6)
                            {
                                name = "GND";
                            }
                            else if (index == 7)
                            {
                                name = "AIN";
                            }
                            else if (index == 8)
                            {
                                name = "GND";
                            }
                            else if (index == 9)
                            {
                                name = "PWM";
                            }
                            else
                            {
                                name = "GND";
                            }
                            break;
                    }
                }
            }

            private void SetColor(Dictionary<string, Color> colorDictionary)
            {
                c = colorDictionary[name];
            }

            public string PrintPin()
            {
                return $"Index: {index}\nName: {name}\nColor: {color}";
            }
        }
    }
}
