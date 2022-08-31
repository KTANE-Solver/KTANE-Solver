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
    /// Purpose: Solves the Bulb Module
    /// </summary>
    class Bulb : Module
    {
        private bool Lit;
        private bool Opaque;
        private String Color;
        private Indicator RemeberedIndicator;

        private bool Step1LightWentOff;
        private bool Step3LightWentOff;

        private String Step1Direction;
        private String Step2Direction;
        private String Step3Direction;

        private List<string> list;

        public Bulb(Bomb bomb, StreamWriter logFileWriter, bool lit, bool opaque, String color)
            : base(bomb, logFileWriter, "Bulb")
        {
            list = new List<string>();
            Lit = lit;
            Opaque = opaque;
            Color = color;

            RemeberedIndicator = null;

            Step1LightWentOff = false;
            Step3LightWentOff = false;

            Step1Direction = null;
            Step2Direction = null;
            Step3Direction = null;
        }

        public void Solve()
        {
            String bulbLit;
            String bulbOpaque;

            if (Lit)
            {
                bulbLit = "lit";
            }
            else
            {
                bulbLit = "unlit";
            }

            if (Opaque)
            {
                bulbOpaque = "opqaue";
            }
            else
            {
                bulbOpaque = "translucent";
            }

            PrintDebugLine($"Bulb is {Color}, {bulbLit}, and {bulbOpaque}\n");

            Step1();
        }

        private void Step1()
        {
            PrintDebugLine($"Stage 1...\n");

            //If the light is on and the bulb is see-through, press I and go to Step 2.
            if (!Opaque && Lit)
            {
                PressI();
                Step1Direction = "Press I";
                PrintList();
                Step1LightWentOff = LightWentOff();
                Step2();
            }
            //If the light is on and the bulb is opaque, press O and go to Step 3.
            else if (Lit)
            {
                PressO();
                Step1Direction = "Press O";
                PrintList();
                Step1LightWentOff = LightWentOff();
                Step3();
            }
            //Otherwise, unscrew the bulb and go to Step 4.
            else
            {
                Unscrew();
                Step4();
            }
        }

        private void Step2()
        {
            PrintDebugLine($"\nStage 2...\n");

            //If the bulb is red, press I, then unscrew it and go to Step 5.
            if (Color == "Red")
            {
                Step2Direction = "Press I";
                PressI();
                Unscrew();
                Step5();
            }
            //If the bulb is white, press O, then unscrew it and go to Step 6.
            else if (Color == "White")
            {
                Step2Direction = "Press O";
                PressO();
                Unscrew();
                Step6();
            }
            //Otherwise, unscrew the bulb and go to Step 7.
            else
            {
                Unscrew();
                Step7();
            }
        }

        private void Step3()
        {
            PrintDebugLine($"\nStage 3...\n");

            //If the bulb is green, press I, then unscrew it and go to Step 6.
            if (Color == "Green")
            {
                PressI();
                Step3Direction = "Press I";
                PrintList();
                Step3LightWentOff = LightWentOff();
                Unscrew();
                Step6();
            }
            //If the bulb is purple, press O, then unscrew it and go to Step 5.
            else if (Color == "Purple")
            {
                Step3Direction = "Press O";
                PressO();
                Unscrew();
                Step5();
            }
            //Otherwise, unscrew the bulb and go to Step 8.
            else
            {
                Unscrew();
                Step8();
            }
        }

        private void Step4()
        {
            PrintDebugLine($"\nStage 4...\n");

            //If the bomb has any of the following indicators: CAR, IND, MSA or SND, press I and go to Step 9.
            if (Bomb.Car.Visible || Bomb.Ind.Visible || Bomb.Msa.Visible || Bomb.Snd.Visible)
            {
                PressI();
                Step9();
            }
            //Otherwise, press O and go to Step 10.
            else
            {
                PressO();
                Step10();
            }
        }

        private void Step5()
        {
            PrintDebugLine($"\nStage 5...\n");

            //If the light went off at Step 1, press the same button again, then screw the bulb back in.
            if (Step1LightWentOff)
            {
                list.Add(Step1Direction);
            }
            //Otherwise, press the button you haven’t yet pressed, then screw the bulb back in.
            else
            {
                if (Step1Direction == "Press I")
                {
                    PressO();
                }
                else
                {
                    PressI();
                }
            }

            Screw();
            PrintList();
        }

        private void Step6()
        {
            PrintDebugLine($"\nStage 6...\n");

            //If the bulb went off when you pressed I, press the button that you pressed in Step 1, then screw the bulb back in.
            if (
                (Step1LightWentOff && Step1Direction == "Press I")
                || Step3Direction == "Press I" && Step3LightWentOff
            )
            {
                list.Add(Step1Direction);
            }
            //Otherwise, press the button that you pressed in Step 2 or 3, then screw the bulb back in.
            else
            {
                if (Step2Direction != null)
                {
                    list.Add(Step2Direction);
                }
                else
                {
                    list.Add(Step3Direction);
                }
            }

            Screw();
            PrintList();
        }

        private void Step7()
        {
            PrintDebugLine($"\nStage 7...\n");

            //If the bulb is green, press I, remember SIG and go to Step 11.
            if (Color == "Green")
            {
                PressI();
                RemeberedIndicator = Bomb.Sig;
                Step11();
            }
            //If the bulb is purple, press I, then screw it back in and go to Step 12.
            else if (Color == "Purple")
            {
                PressI();
                Screw();
                Step12();
            }
            //If the bulb is blue, press O, remember CLR and go to Step 11.
            else if (Color == "Blue")
            {
                PressO();
                RemeberedIndicator = Bomb.Clr;
                Step11();
            }
            //Otherwise, press O, then screw the bulb back in and go to Step 13.
            else
            {
                PressO();
                Screw();
                Step13();
            }
        }

        private void Step8()
        {
            PrintDebugLine($"\nStage 8...\n");

            //If the bulb is white, press I, remember FRQ and go to Step 11.
            if (Color == "White")
            {
                PressI();
                RemeberedIndicator = Bomb.Frq;
                Step11();
            }
            //If the bulb is red, press I, then screw it back in and go to Step 13.
            else if (Color == "Red")
            {
                PressI();
                Screw();
                Step13();
            }
            //If the bulb is yellow, press O, remember FRK and go to Step 11.
            else if (Color == "Yellow")
            {
                PressO();
                RemeberedIndicator = Bomb.Frk;
                Step11();
            }
            //Otherwise, press O, then screw the bulb back in and go to Step 12.
            else
            {
                PressO();
                Screw();
                Step12();
            }
        }

        private void Step9()
        {
            PrintDebugLine($"\nStage 9...\n");

            //If the bulb is blue, press I and go to Step 14.
            if (Color == "Blue")
            {
                PressI();
                Step14();
            }
            //If the bulb is green, press I, then screw it back in and go to Step 12.
            else if (Color == "Green")
            {
                PressI();
                Screw();
                Step12();
            }
            //If the bulb is yellow, press O and go to Step 15.
            else if (Color == "Yellow")
            {
                PressO();
                Step15();
            }
            //If the bulb is white, press O, then screw it back in and go to Step 13.
            else if (Color == "White")
            {
                PressO();
                Screw();
                Step13();
            }
            //If the bulb is purple, screw it back in, then press I and go to Step 12.
            else if (Color == "Purple")
            {
                Screw();
                PressI();
                Step12();
            }
            //Otherwise, screw the bulb back in, then press O and go to Step 13.
            else
            {
                Screw();
                PressO();
                Step13();
            }
        }

        private void Step10()
        {
            PrintDebugLine($"\nStage 10...\n");

            //If the bulb is purple, press I and go to Step 14.
            if (Color == "Purple")
            {
                PressI();
                Step14();
            }
            //If the bulb is red, press I, then screw it back in and go to Step 13.
            else if (Color == "Red")
            {
                PressI();
                Screw();
                Step13();
            }
            //If the bulb is blue, press O and go to Step 15.
            else if (Color == "Blue")
            {
                PressO();
                Step15();
            }
            //If the bulb is yellow, press O, then screw it back in and go to Step 12.
            else if (Color == "Yellow")
            {
                PressO();
                Screw();
                Step12();
            }
            //If the bulb is green, screw it back in, then press I and go to Step 13.
            else if (Color == "Green")
            {
                Screw();
                PressI();
                Step13();
            }
            //Otherwise, screw the bulb back in, then press O and go to Step 12.
            else
            {
                Screw();
                PressO();
                Step12();
            }
        }

        private void Step11()
        {
            PrintDebugLine($"\nStage 11...\n");

            //If the bomb has the remembered indicator, press I, then screw the bulb back in.
            if (RemeberedIndicator.Visible)
            {
                PressI();
            }
            //Otherwise, press O, then screw the bulb back in.
            else
            {
                PressO();
            }

            Screw();
            PrintList();
        }

        private void Step12()
        {
            PrintDebugLine($"\nStage 12...\n");

            //If the light is now on, press I.

            PrintList();

            //Otherwise, press O.
            if (LightIsOn())
            {
                PressI();
            }
            else
            {
                PressO();
            }

            PrintList();
        }

        private void Step13()
        {
            PrintDebugLine($"\nStage 13...\n");

            PrintList();

            //If the light is now on, press O.
            //Otherwise, press I.
            if (LightIsOn())
            {
                PressO();
            }
            else
            {
                PressI();
            }

            PrintList();
        }

        private void Step14()
        {
            PrintDebugLine($"\nStage 14...\n");

            //If the bulb is opaque, press I, then screw the bulb back in.
            if (Opaque)
            {
                PressI();
            }
            //Otherwise, press O, then screw the bulb back in.
            else
            {
                PressO();
            }

            Screw();
            PrintList();
        }

        private void Step15()
        {
            PrintDebugLine($"\nStage 15...\n");

            //If the bulb is see - through, press I, then screw the bulb back in.
            if (!Opaque)
            {
                PressI();
            }
            //Otherwise, press O, then screw the bulb back in.
            else
            {
                PressO();
            }

            Screw();
            PrintList();
        }

        private void PressI()
        {
            list.Add("Press I");

            PrintDebugLine("Press I");
        }

        private void PressO()
        {
            list.Add("Press O");
            PrintDebugLine("Press O");
        }

        private void Screw()
        {
            list.Add("Screw");
            PrintDebugLine("Screw");
        }

        private void Unscrew()
        {
            list.Add("Unscrew");
            PrintDebugLine("Unscrew");
        }

        private void PrintList()
        {
            ShowAnswer(string.Join(", ", list), true);
            list.Clear();
        }

        private bool LightWentOff()
        {
            return MessageBox.Show("Did the light go off?", "The Bulb", MessageBoxButtons.YesNo)
                == DialogResult.Yes;
        }

        private bool LightIsOn()
        {
            return MessageBox.Show("Is the light on?", "", MessageBoxButtons.YesNo)
                == DialogResult.Yes;
        }
    }
}
