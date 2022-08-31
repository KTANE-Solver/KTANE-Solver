using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date: 5/4/21
    /// Purpose: Solves the "Who's on First" module
    /// </summary>
    class WhosOnFirst : Module
    {
        //FIELDS

        int stage;

        //the display

        private String display;

        //the six buttons
        private String topLeft;
        private String topRight;
        private String midLeft;
        private String midRight;
        private String bottomLeft;
        private String bottomRight;

        //the reference word
        private String reference;

        //CONSTRUCTOR

        /// <summary>
        /// Creates the class that will solve
        /// "Who's on First"
        /// </summary>
        /// <param name="stage">the current stage</param>
        /// <param name="display">the wrod on the display</param>
        /// <param name="topLeft"></param>
        /// <param name="topRight"></param>
        /// <param name="midLeft"></param>
        /// <param name="midRight"></param>
        /// <param name="bottomLeft"></param>
        /// <param name="bottomRight"></param>
        /// <param name="bomb"></param>
        /// <param name="logFileWriter"></param>
        public WhosOnFirst(
            int stage,
            String display,
            String topLeft,
            String topRight,
            String midLeft,
            String midRight,
            String bottomLeft,
            String bottomRight,
            Bomb bomb,
            StreamWriter logFileWriter
        ) : base(bomb, logFileWriter, "Who's on First")
        {
            this.stage = stage;

            this.display = display;
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.midLeft = midLeft;
            this.midRight = midRight;
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
        }

        public void Solve()
        {
            System.Diagnostics.Debug.WriteLine($"Stage {stage}\n");

            System.Diagnostics.Debug.WriteLine($"Display: {display}\n");

            System.Diagnostics.Debug.WriteLine($"Top Left: {topLeft}");
            System.Diagnostics.Debug.WriteLine($"Top Right: {topRight}");
            System.Diagnostics.Debug.WriteLine($"Middle Left: {midLeft}");
            System.Diagnostics.Debug.WriteLine($"Middle Right: {midRight}");
            System.Diagnostics.Debug.WriteLine($"Bottom Left: {bottomLeft}");
            System.Diagnostics.Debug.WriteLine($"Bottom Right: {bottomRight}\n");

            //find what the reference word is going to be
            switch (display)
            {
                //top left
                case "UR":
                    reference = topLeft;
                    break;

                //top right
                case "FIRST":
                case "OKAY":
                case "C":
                    reference = topRight;
                    break;

                //mid left
                case "YES":
                case "NOTHING":
                case "LED":
                case "THEY ARE":
                    reference = midLeft;
                    break;

                //mid right
                case "BLANK":
                case "READ":
                case "RED":
                case "YOU":
                case "YOUR":
                case "YOU'RE":
                case "THEIR":
                    reference = midRight;
                    break;

                //bottom left
                case "":
                case "REED":
                case "LEED":
                case "THEY'RE":
                    reference = bottomLeft;
                    break;

                //bottom right
                case "DISPLAY":
                case "SAYS":
                case "NO":
                case "LEAD":
                case "HOLD ON":
                case "YOU ARE":
                case "THERE":
                case "SEE":
                case "CEE":
                    reference = bottomRight;
                    break;
            }

            System.Diagnostics.Debug.WriteLine($"Reference: {reference}\n");

            //an array that will hold the order of words depending on the reference
            String[] orderOfWords = new string[0];

            //set up the order of words
            switch (reference)
            {
                case "READY":
                    orderOfWords = new string[]
                    {
                        "YES",
                        "OKAY",
                        "WHAT",
                        "MIDDLE",
                        "LEFT",
                        "PRESS",
                        "RIGHT",
                        "BLANK",
                        "READY",
                        "NO",
                        "FIRST",
                        "UHHH",
                        "NOTHING",
                        "WAIT"
                    };
                    break;

                case "FIRST":
                    orderOfWords = new string[]
                    {
                        "LEFT",
                        "OKAY",
                        "YES",
                        "MIDDLE",
                        "NO",
                        "RIGHT",
                        "NOTHING",
                        "UHHH",
                        "WAIT",
                        "READY",
                        "BLANK",
                        "WHAT",
                        "PRESS",
                        "FIRST"
                    };
                    break;

                case "NO":
                    orderOfWords = new string[]
                    {
                        "BLANK",
                        "UHHH",
                        "WAIT",
                        "FIRST",
                        "WHAT",
                        "READY",
                        "RIGHT",
                        "YES",
                        "NOTHING",
                        "LEFT",
                        "PRESS",
                        "OKAY",
                        "NO",
                        "MIDDLE"
                    };
                    break;

                case "BLANK":
                    orderOfWords = new string[]
                    {
                        "WAIT",
                        "RIGHT",
                        "OKAY",
                        "MIDDLE",
                        "BLANK",
                        "PRESS",
                        "READY",
                        "NOTHING",
                        "NO",
                        "WHAT",
                        "LEFT",
                        "UHHH",
                        "YES",
                        "FIRST"
                    };
                    break;

                case "NOTHING":
                    orderOfWords = new string[]
                    {
                        "UHHH",
                        "RIGHT",
                        "OKAY",
                        "MIDDLE",
                        "YES",
                        "BLANK",
                        "NO",
                        "PRESS",
                        "LEFT",
                        "WHAT",
                        "WAIT",
                        "FIRST",
                        "NOTHING",
                        "READY"
                    };
                    break;

                case "YES":
                    orderOfWords = new string[]
                    {
                        "OKAY",
                        "RIGHT",
                        "UHHH",
                        "MIDDLE",
                        "FIRST",
                        "WHAT",
                        "PRESS",
                        "READY",
                        "NOTHING",
                        "YES",
                        "LEFT",
                        "BLANK",
                        "NO",
                        "WAIT"
                    };
                    break;

                case "WHAT":
                    orderOfWords = new string[]
                    {
                        "UHHH",
                        "WHAT",
                        "LEFT",
                        "NOTHING",
                        "READY",
                        "BLANK",
                        "MIDDLE",
                        "NO",
                        "OKAY",
                        "FIRST",
                        "WAIT",
                        "YES",
                        "PRESS",
                        "RIGHT"
                    };
                    break;

                case "UHHH":
                    orderOfWords = new string[]
                    {
                        "READY",
                        "NOTHING",
                        "LEFT",
                        "WHAT",
                        "OKAY",
                        "YES",
                        "RIGHT",
                        "NO",
                        "PRESS",
                        "BLANK",
                        "UHHH",
                        "MIDDLE",
                        "WAIT",
                        "FIRST"
                    };
                    break;

                case "LEFT":
                    orderOfWords = new string[]
                    {
                        "RIGHT",
                        "LEFT",
                        "FIRST",
                        "NO",
                        "MIDDLE",
                        "YES",
                        "BLANK",
                        "WHAT",
                        "UHHH",
                        "WAIT",
                        "PRESS",
                        "READY",
                        "OKAY",
                        "NOTHING"
                    };
                    break;

                case "RIGHT":
                    orderOfWords = new string[]
                    {
                        "YES",
                        "NOTHING",
                        "READY",
                        "PRESS",
                        "NO",
                        "WAIT",
                        "WHAT",
                        "RIGHT",
                        "MIDDLE",
                        "LEFT",
                        "UHHH",
                        "BLANK",
                        "OKAY",
                        "FIRST"
                    };
                    break;

                case "MIDDLE":
                    orderOfWords = new string[]
                    {
                        "BLANK",
                        "READY",
                        "OKAY",
                        "WHAT",
                        "NOTHING",
                        "PRESS",
                        "NO",
                        "WAIT",
                        "LEFT",
                        "MIDDLE",
                        "RIGHT",
                        "FIRST",
                        "UHHH",
                        "YES"
                    };
                    break;

                case "OKAY":
                    orderOfWords = new string[]
                    {
                        "MIDDLE",
                        "NO",
                        "FIRST",
                        "YES",
                        "UHHH",
                        "NOTHING",
                        "WAIT",
                        "OKAY",
                        "LEFT",
                        "READY",
                        "BLANK",
                        "PRESS",
                        "WHAT",
                        "RIGHT"
                    };
                    break;

                case "WAIT":
                    orderOfWords = new string[]
                    {
                        "UHHH",
                        "NO",
                        "BLANK",
                        "OKAY",
                        "YES",
                        "LEFT",
                        "FIRST",
                        "PRESS",
                        "WHAT",
                        "WAIT",
                        "NOTHING",
                        "READY",
                        "RIGHT",
                        "MIDDLE"
                    };
                    break;

                case "PRESS":
                    orderOfWords = new string[]
                    {
                        "RIGHT",
                        "MIDDLE",
                        "YES",
                        "READY",
                        "PRESS",
                        "OKAY",
                        "NOTHING",
                        "UHHH",
                        "BLANK",
                        "LEFT",
                        "FIRST",
                        "WHAT",
                        "NO",
                        "WAIT"
                    };
                    break;

                case "YOU":
                    orderOfWords = new string[]
                    {
                        "SURE",
                        "YOU ARE",
                        "YOUR",
                        "YOU'RE",
                        "NEXT",
                        "UH HUH",
                        "UR",
                        "HOLD",
                        "WHAT?",
                        "YOU",
                        "UH UH",
                        "LIKE",
                        "DONE",
                        "U"
                    };
                    break;

                case "YOU ARE":
                    orderOfWords = new string[]
                    {
                        "YOUR",
                        "NEXT",
                        "LIKE",
                        "UH HUH",
                        "WHAT?",
                        "DONE",
                        "UH UH",
                        "HOLD",
                        "YOU",
                        "U",
                        "YOU'RE",
                        "SURE",
                        "UR",
                        "YOU ARE"
                    };
                    break;

                case "YOUR":
                    orderOfWords = new string[]
                    {
                        "UH UH",
                        "YOU ARE",
                        "UH HUH",
                        "YOUR",
                        "NEXT",
                        "UR",
                        "SURE",
                        "U",
                        "YOU'RE",
                        "YOU",
                        "WHAT?",
                        "HOLD",
                        "LIKE",
                        "DONE"
                    };
                    break;

                case "YOU'RE":
                    orderOfWords = new string[]
                    {
                        "YOU",
                        "YOU'RE",
                        "UR",
                        "NEXT",
                        "UH UH",
                        "YOU ARE",
                        "U",
                        "YOUR",
                        "WHAT?",
                        "UH HUH",
                        "SURE",
                        "DONE",
                        "LIKE",
                        "HOLD"
                    };
                    break;

                case "UR":
                    orderOfWords = new string[]
                    {
                        "DONE",
                        "U",
                        "UR",
                        "UH HUH",
                        "WHAT?",
                        "SURE",
                        "YOUR",
                        "HOLD",
                        "YOU'RE",
                        "LIKE",
                        "NEXT",
                        "UH UH",
                        "YOU ARE",
                        "YOU"
                    };
                    break;

                case "U":
                    orderOfWords = new string[]
                    {
                        "UH HUH",
                        "SURE",
                        "NEXT",
                        "WHAT?",
                        "YOU'RE",
                        "UR",
                        "UH UH",
                        "DONE",
                        "U",
                        "YOU",
                        "LIKE",
                        "HOLD",
                        "YOU ARE",
                        "YOUR"
                    };
                    break;

                case "UH HUH":
                    orderOfWords = new string[]
                    {
                        "UH HUH",
                        "YOUR",
                        "YOU ARE",
                        "YOU",
                        "DONE",
                        "HOLD",
                        "UH UH",
                        "NEXT",
                        "SURE",
                        "LIKE",
                        "YOU'RE",
                        "UR",
                        "U",
                        "WHAT?"
                    };
                    break;

                case "UH UH":
                    orderOfWords = new string[]
                    {
                        "UR",
                        "U",
                        "YOU ARE",
                        "YOU'RE",
                        "NEXT",
                        "UH UH",
                        "DONE",
                        "YOU",
                        "UH HUH",
                        "LIKE",
                        "YOUR",
                        "SURE",
                        "HOLD",
                        "WHAT?"
                    };
                    break;

                case "WHAT?":
                    orderOfWords = new string[]
                    {
                        "YOU",
                        "HOLD",
                        "YOU'RE",
                        "YOUR",
                        "U",
                        "DONE",
                        "UH UH",
                        "LIKE",
                        "YOU ARE",
                        "UH HUH",
                        "UR",
                        "NEXT",
                        "WHAT?",
                        "SURE"
                    };
                    break;

                case "DONE":
                    orderOfWords = new string[]
                    {
                        "SURE",
                        "UH HUH",
                        "NEXT",
                        "WHAT?",
                        "YOUR",
                        "UR",
                        "YOU'RE",
                        "HOLD",
                        "LIKE",
                        "YOU",
                        "U",
                        "YOU ARE",
                        "UH UH",
                        "DONE"
                    };
                    break;

                case "NEXT":
                    orderOfWords = new string[]
                    {
                        "WHAT?",
                        "UH HUH",
                        "UH UH",
                        "YOUR",
                        "HOLD",
                        "SURE",
                        "NEXT",
                        "LIKE",
                        "DONE",
                        "YOU ARE",
                        "UR",
                        "YOU'RE",
                        "U",
                        "YOU"
                    };
                    break;

                case "HOLD":
                    orderOfWords = new string[]
                    {
                        "YOU ARE",
                        "U",
                        "DONE",
                        "UH UH",
                        "YOU",
                        "UR",
                        "SURE",
                        "WHAT?",
                        "YOU'RE",
                        "NEXT",
                        "HOLD",
                        "UH HUH",
                        "YOUR",
                        "LIKE"
                    };
                    break;

                case "SURE":
                    orderOfWords = new string[]
                    {
                        "YOU ARE",
                        "DONE",
                        "LIKE",
                        "YOU'RE",
                        "YOU",
                        "HOLD",
                        "UH HUH",
                        "UR",
                        "SURE",
                        "U",
                        "WHAT?",
                        "NEXT",
                        "YOUR",
                        "UH UH"
                    };
                    break;

                case "LIKE":
                    orderOfWords = new string[]
                    {
                        "YOU'RE",
                        "NEXT",
                        "U",
                        "UR",
                        "HOLD",
                        "DONE",
                        "UH UH",
                        "WHAT?",
                        "UH HUH",
                        "YOU",
                        "LIKE",
                        "SURE",
                        "YOU ARE",
                        "YOUR"
                    };
                    break;
            }

            //find the smallest index
            int topLeftIndex = Array.IndexOf(orderOfWords, topLeft);
            int topRightIndex = Array.IndexOf(orderOfWords, topRight);
            int midLeftIndex = Array.IndexOf(orderOfWords, midLeft);
            int midRightIndex = Array.IndexOf(orderOfWords, midRight);
            int bottomLeftIndex = Array.IndexOf(orderOfWords, bottomLeft);
            int bottomRightIndex = Array.IndexOf(orderOfWords, bottomRight);

            int smallest = topLeftIndex;

            if (topRightIndex < smallest)
                smallest = topRightIndex;

            if (midLeftIndex < smallest)
                smallest = midLeftIndex;

            if (midRightIndex < smallest)
                smallest = midRightIndex;

            if (bottomLeftIndex < smallest)
                smallest = bottomLeftIndex;

            if (bottomRightIndex < smallest)
                smallest = bottomRightIndex;

            String answer = "";

            if (smallest == topLeftIndex)
                answer = topLeft;
            else if (smallest == topRightIndex)
                answer = topRight;
            else if (smallest == midLeftIndex)
                answer = midLeft;
            else if (smallest == midRightIndex)
                answer = midRight;
            else if (smallest == bottomLeftIndex)
                answer = bottomLeft;
            else
                answer = bottomRight;

            System.Diagnostics.Debug.WriteLine($"Answer: {answer}\n");

            ShowAnswer(answer, true);
        }
    }
}
