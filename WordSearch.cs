using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Purpose: Solves the word search module
    /// </summary>
    public class WordSearch : Module
    {
        private char TopLeftLetter { get; set; }
        private char TopRightLetter { get; set; }
        private char BottomLeftLetter { get; set; }
        private char BottomRightLetter { get; set; }

        Dictionary<char, Letter> dictionary = new Dictionary<char, Letter>();

        public WordSearch(
            Bomb bomb,
            StreamWriter logFileWriter,
            char topLeftLetter,
            char topRightLetter,
            char bottomLeftLetter,
            char bottomRightLetter
        ) : base(bomb, logFileWriter, "Word Search")
        {
            TopLeftLetter = topLeftLetter;
            TopRightLetter = topRightLetter;
            BottomLeftLetter = bottomLeftLetter;
            BottomRightLetter = bottomRightLetter;

            dictionary.Add(
                'V',
                new Letter("Hotel", "Search", "Boom", "Line", "Done", "Quebec", "Submit", "Blue")
            );
            dictionary.Add(
                'U',
                new Letter("Search", "Add", "Line", "Kaboom", "Quebec", "Check", "Blue", "Echo")
            );
            dictionary.Add(
                'S',
                new Letter("Add", "Sierra", "Kaboom", "Panic", "Check", "Find", "Echo", "False")
            );
            dictionary.Add(
                'Z',
                new Letter("Sierra", "Finish", "Panic", "Manual", "Find", "East", "False", "Alarm")
            );
            dictionary.Add(
                'P',
                new Letter("Port", "Boom", "See", "India", "Color", "Submit", "Twenty", "North")
            );
            dictionary.Add(
                'Q',
                new Letter("Boom", "Line", "India", "Number", "Submit", "Blue", "North", "Look")
            );
            dictionary.Add(
                'N',
                new Letter("Line", "Kaboom", "Number", "Zulu", "Blue", "Echo", "Look", "Green")
            );
            dictionary.Add(
                'X',
                new Letter("Kaboom", "Panic", "Zulu", "Victor", "Echo", "False", "Green", "Xray")
            );
            dictionary.Add(
                'F',
                new Letter("Panic", "Manual", "Victor", "Delta", "False", "Alarm", "Xray", "Yes")
            );
            dictionary.Add(
                'Y',
                new Letter("Manual", "Decoy", "Delta", "Help", "Alarm", "Call", "Yes", "Locate")
            );
            dictionary.Add(
                'T',
                new Letter("See", "India", "Romeo", "True", "Twenty", "North", "Beep", "Expert")
            );
            dictionary.Add(
                'I',
                new Letter("India", "Number", "True", "Mike", "North", "Look", "Expert", "Edge")
            );
            dictionary.Add(
                'M',
                new Letter("Number", "Zulu", "Mike", "Found", "Look", "Green", "Edge", "Red")
            );
            dictionary.Add(
                'E',
                new Letter("Zulu", "Victor", "Found", "Bombs", "Green", "Xray", "Red", "Word")
            );
            dictionary.Add(
                'D',
                new Letter("Victor", "Delta", "Bombs", "Work", "Xray", "Yes", "Word", "Unique")
            );
            dictionary.Add(
                'A',
                new Letter("Delta", "Help", "Work", "Test", "Yes", "Locate", "Unique", "Jinx")
            );
            dictionary.Add(
                'K',
                new Letter("Romeo", "True", "Golf", "Talk", "Beep", "Expert", "Letter", "Six")
            );
            dictionary.Add(
                'B',
                new Letter("True", "Mike", "Talk", "Bravo", "Expert", "Edge", "Six", "Serial")
            );
            dictionary.Add(
                'W',
                new Letter("Mike", "Found", "Bravo", "Seven", "Edge", "Red", "Serial", "Timer")
            );
            dictionary.Add(
                'H',
                new Letter("Found", "Bombs", "Seven", "Module", "Red", "Word", "Timer", "Spell")
            );
            dictionary.Add(
                'J',
                new Letter("Bombs", "Work", "Module", "List", "Word", "Unique", "Spell", "Tango")
            );
            dictionary.Add(
                'O',
                new Letter("Work", "Test", "List", "Yankee", "Unique", "Jinx", "Tango", "Solve")
            );
            dictionary.Add(
                'R',
                new Letter("Talk", "Bravo", "Chart", "Math", "Six", "Serial", "Oscar", "Next")
            );
            dictionary.Add(
                'L',
                new Letter("Bravo", "Seven", "Math", "Read", "Serial", "Timer", "Next", "Listen")
            );
            dictionary.Add(
                'C',
                new Letter("Seven", "Module", "Read", "Lima", "Timer", "Spell", "Listen", "Four")
            );
            dictionary.Add(
                'G',
                new Letter("Module", "List", "Lima", "Count", "Spell", "Tango", "Four", "Office")
            );
        }

        public string Solve(bool debug)
        {
            String topLeftWord;
            String topRightWord;
            String bottomLeftWord;
            String bottomRightWord;

            if (Bomb.LastDigit % 2 == 0)
            {
                topLeftWord = dictionary[TopLeftLetter].topLeftWordEven;
                topRightWord = dictionary[TopRightLetter].topRightWordEven;
                bottomLeftWord = dictionary[BottomLeftLetter].bottomLeftWordEven;
                bottomRightWord = dictionary[BottomRightLetter].bottomRightWordEven;

                PrintDebugLine("Last digit is even\n");
            }
            else
            {
                topLeftWord = dictionary[TopLeftLetter].topLeftWordOdd;
                topRightWord = dictionary[TopRightLetter].topRightWordOdd;
                bottomLeftWord = dictionary[BottomLeftLetter].bottomLeftWordOdd;
                bottomRightWord = dictionary[BottomRightLetter].bottomRightWordOdd;

                PrintDebugLine("Last digit is odd\n");
            }

            topLeftWord = topLeftWord.ToUpper();
            topRightWord = topRightWord.ToUpper();
            bottomLeftWord = bottomLeftWord.ToUpper();
            bottomRightWord = bottomRightWord.ToUpper();

            PrintDebugLine(
                $"Possible Answers:\n{topLeftWord}\n{topRightWord}\n{bottomLeftWord}\n{bottomRightWord}\n"
            );

            List<string> words = new List<string>()
            {
                topLeftWord,
                topRightWord,
                bottomLeftWord,
                bottomRightWord
            };

            words = words.Distinct().ToList();

            string answer = $"{string.Join("\n", words)}";

            if (!debug)
            { 
                ShowAnswer(answer, true);
            }

            return answer;
        }

        public class Letter
        {
            public String topLeftWordEven { get; }

            public String topRightWordEven { get; }

            public String bottomLeftWordEven { get; }

            public String bottomRightWordEven { get; }

            public String topLeftWordOdd { get; }

            public String topRightWordOdd { get; }

            public String bottomLeftWordOdd { get; }

            public String bottomRightWordOdd { get; }

            public Letter(
                String bottomRightWordEven,
                String bottomLeftWordEven,
                String topRightWordEven,
                String topLeftWordEven,
                String bottomRightWordOdd,
                String bottomLeftWordOdd,
                String topRightWordOdd,
                String topLeftWordOdd
            )
            {
                this.topLeftWordEven = topLeftWordEven;
                this.topRightWordEven = topRightWordEven;
                this.bottomLeftWordEven = bottomLeftWordEven;
                this.bottomRightWordEven = bottomRightWordEven;
                this.topLeftWordOdd = topLeftWordOdd;
                this.topRightWordOdd = topRightWordOdd;
                this.bottomLeftWordOdd = bottomLeftWordOdd;
                this.bottomRightWordOdd = bottomRightWordOdd;
            }
        }
    }
}
