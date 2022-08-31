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
    /// Purpose: Solves the blind alley module
    /// </summary>
    class BlindAlley : Module
    {
        //FIELDS
        private Section topLeft;
        private Section topMid;
        private Section midLeft;
        private Section mid;
        private Section midRight;
        private Section bottomLeft;
        private Section bottomMid;
        private Section bottomRight;

        public BlindAlley(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Blind Alley")
        {
            //unlit bob
            //lit car
            //lit ind
            //even battery holders
            topLeft = new Section(
                "Top Left",
                bomb.Bob.VisibleNotLit,
                "Unlit Bob",
                bomb.Car.Lit,
                "Lit Car",
                bomb.Ind.Lit,
                "Lit Ind",
                bomb.BatteryHolder % 2 == 0,
                "Even number of battery holders"
            );

            //unlit car
            //unlit nsa
            //lit frk
            //rj visible
            topMid = new Section(
                "Top Middle",
                bomb.Car.VisibleNotLit,
                "Unlit Car",
                bomb.Nsa.VisibleNotLit,
                "Unlit Nsa",
                bomb.Frk.Lit,
                "Lit Frk",
                bomb.Rj.Visible,
                "RJ-45 Visible"
            );

            //unlit frq
            //unlit ind
            //unlit trn
            //dvid visible
            midLeft = new Section(
                "Middle Left",
                bomb.Frq.VisibleNotLit,
                "Unlit Frq",
                bomb.Ind.VisibleNotLit,
                "Unlit Ind",
                bomb.Trn.VisibleNotLit,
                "Unlit Trn",
                bomb.Dvid.Visible,
                "DVI-D Visible"
            );

            //unit sig
            //unlit snd
            //lit nsa
            //even batteries

            mid = new Section(
                "Middle",
                bomb.Sig.VisibleNotLit,
                "Unlit Sig",
                bomb.Snd.VisibleNotLit,
                "Unlit Snd",
                bomb.Nsa.Lit,
                "Lit Nsa",
                bomb.Battery % 2 == 0,
                "Even number of batteries"
            );

            //lit bob
            //lit clr
            //ps 2 visible
            //serial visble
            midRight = new Section(
                "Middle Right",
                bomb.Bob.Lit,
                "Lit Bob",
                bomb.Clr.Lit,
                "Lit Clr",
                bomb.Ps.Visible,
                "PS/2 Visible",
                bomb.Serial.Visible,
                "Serial Visible"
            );

            //lit frq
            //lit sig
            //lit trn
            //even digit in serial
            bottomLeft = new Section(
                "Bottom Left",
                bomb.Frq.Lit,
                "Lit Frq",
                bomb.Sig.Lit,
                "Lit Sig",
                bomb.Trn.Lit,
                "Lit Trn",
                bomb.EvenDigit,
                "Even digit in the serial number"
            );

            //unlit frk
            //lit msa
            //parallel visible
            //vowel in serial
            bottomMid = new Section(
                "Bottom Middle",
                bomb.Frk.VisibleNotLit,
                "Unlit Frk",
                bomb.Msa.Lit,
                "Lit Msa",
                bomb.Parallel.Visible,
                "Parallel Visible",
                bomb.HasVowel,
                "Vowel in serial number"
            );

            //unlit car
            //unlit msa
            //lit snd
            //stero visible
            bottomRight = new Section(
                "Bottom Right",
                bomb.Car.VisibleNotLit,
                "Unlit Car",
                bomb.Msa.VisibleNotLit,
                "Unlit Msa",
                bomb.Snd.Lit,
                "Lit Snd",
                bomb.Stereo.Visible,
                "Stereo Visible"
            );
        }

        public string Solve()
        {
            List<Section> sections = new List<Section>()
            {
                topLeft,
                topMid,
                midLeft,
                mid,
                midRight,
                bottomLeft,
                bottomMid,
                bottomRight
            };
            List<int> sectionNumArr = new List<int>();

            //find the higest number of true conditions in one section

            foreach (Section section in sections)
            {
                int sectionNum = section.GetTrueConditionNum();

                PrintDebugLine(
                    $"{section.Name} conditions met: {sectionNum} ({section.GetTrueConditions()})"
                );

                sectionNumArr.Add(sectionNum);
            }

            int highestTrueConditions = sectionNumArr.Max();

            //add all the sections that have the highest number of true condition
            List<string> answer = new List<string>();

            foreach (Section section in sections)
            {
                if (highestTrueConditions == section.GetTrueConditionNum())
                {
                    answer.Add(section.Name);
                }
            }

            return string.Join("" + '\n', answer);
        }

        public class Section
        {
            private bool condition1;
            private bool condition2;
            private bool condition3;
            private bool condition4;

            private string condition1String;
            private string condition2String;
            private string condition3String;
            private string condition4String;

            public string Name { get; }

            public Section(
                string name,
                bool condition1,
                string condition1String,
                bool condition2,
                string condition2String,
                bool condition3,
                string condition3String,
                bool condition4,
                string condition4String
            )
            {
                this.condition1 = condition1;
                this.condition2 = condition2;
                this.condition3 = condition3;
                this.condition4 = condition4;

                this.condition1String = condition1String;
                this.condition2String = condition2String;
                this.condition3String = condition3String;
                this.condition4String = condition4String;

                Name = name;
            }

            public string GetTrueConditions()
            {
                List<string> list = new List<string>();

                if (condition1)
                {
                    list.Add(condition1String);
                }

                if (condition2)
                {
                    list.Add(condition2String);
                }

                if (condition3)
                {
                    list.Add(condition3String);
                }

                if (condition4)
                {
                    list.Add(condition4String);
                }

                return string.Join(", ", list);
            }

            public int GetTrueConditionNum()
            {
                return new bool[] { condition1, condition2, condition3, condition4 }
                    .Where(x => x)
                    .Count();
            }
        }
    }
}
