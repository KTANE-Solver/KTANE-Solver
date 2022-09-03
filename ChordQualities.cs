using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class ChordQualities : Module
    {
        private List<Note> notes;

        private Note currentRoot;
        private string currentQuality;

        private List<string> qualities;

        private Note newRoot;
        private string newQuality;

        public ChordQualities(
            Bomb bomb,
            StreamWriter logFileWriter,
            List<string> notes
        ) : base(bomb, logFileWriter, "Chord Qualities")
        {
            this.notes = new List<Note>();

            for (int i = 0; i < notes.Count; i++)
            {
                this.notes.Add(ConvertNote(notes[i]));
            }

            RefactorNotes();

            qualities = new List<string>
            {
                "X...X..X..X.",
                "X..X...X..X.",
                "X...X..X...X",
                "X..X...X...X",
                "X..XX.....X.",
                "X..X..X...X.",
                "X.X.X..X....",
                "X.XX...X....",
                "X...X...X.X.",
                "X...X...X..X",
                "X....X.X..X.",
                "X..X....X..X"
            };
        }

        public enum Note
        {
            A,
            ASharp,
            B,
            C,
            CSharp,
            D,
            DSharp,
            E,
            F,
            FSharp,
            G,
            GSharp
        }

        public string Solve(bool debug)
        {
            PrintDebugLine ($"Notes: {string.Join(",", notes)}");

            FindQualityAndRoot();

            PrintDebugLine("Old Quality: " + currentQuality);
            PrintDebugLine("Old Root: " + currentRoot + "\n");

            FindNewRoot();
            FindNewQuality();

            PrintDebugLine("New Quality: " + newQuality);
            PrintDebugLine("New Root: " + newRoot + "\n");

            string answer = string.Join(", ", FindAnswer());

            PrintDebugLine(answer + "\n");

            if (!debug)
            { 
                ShowAnswer(answer, true);
            }

            return answer;
        }

        private void RefactorNotes()
        {

            if (notes[0] != notes.Min())
            {
                int minIndex = notes.IndexOf(notes.Min());

                Note minNote = notes[minIndex];
                Note firstNote = notes[0];

                notes[0] = minNote;
                notes[minIndex] = firstNote;
            }

            if (notes[3] != notes.Max())
            {
                int maxIndex = notes.IndexOf(notes.Max());

                Note minNote = notes[maxIndex];
                Note lastNote = notes[3];

                notes[3] = minNote;
                notes[maxIndex] = lastNote;
            }

            if (notes[1] > notes[2])
            {
                Note thirdNote = notes[1];
                Note secondNote = notes[2];

                notes[1] = secondNote;
                notes[2] = thirdNote;
            }
        }

        private void FindQualityAndRoot()
        {
            string quality = "";
            bool correctQuality = false;
            int startingNote = -1;

            for (int i = 0; i < 12; i++)
            {
                quality = qualities[i];

                for (int j = 1; j < 5; j++)
                {
                    startingNote = j;
                    correctQuality = CoorectQuality(quality, j);

                    if (correctQuality)
                    {
                        break;
                    }
                }

                if (correctQuality)
                {
                    break;
                }
            }

            currentRoot = notes[startingNote - 1];

            this.currentQuality = quality;
        }

        private int[] FindGaps(int startingNote)
        {
            int[] gaps;

            switch (startingNote)
            {
                case 1:
                    gaps = new int[] { notes[1] - notes[0], notes[2] - notes[1], notes[3] - notes[2], notes[3] - notes[0] };
                    break;

                case 2:
                    gaps = new int[] { notes[2] - notes[1], notes[3] - notes[2], notes[3] - notes[0], notes[1] - notes[0] };
                    break;

                case 3:
                    gaps = new int[] { notes[3] - notes[2], notes[3] - notes[0], notes[1] - notes[0], notes[2] - notes[1] };
                    break;

                default:
                    gaps = new int[] { notes[3] - notes[0], notes[1] - notes[0], notes[2] - notes[1], notes[3] - notes[2] };
                    break;
            }

            for (int i = 0; i < 4; i++)
            {
                gaps[i] = Math.Abs(gaps[i]);

                if (gaps[i] > 6)
                {
                    gaps[i] = 12 - gaps[i];
                }

                gaps[i] %= 12;
            }

            return gaps;
        }

        private int[] FindGaps(string quality)
        {
            List<int> indexList = new List<int>();

            List<int> gaps = new List<int>();

            for (int i = 0; i < quality.Length; i++)
            {
                if (quality[i] == 'X')
                {
                    indexList.Add(i);
                }
            }

            for (int i = indexList.Count - 1; i > 0; i--)
            {
                gaps.Add(indexList[i] - indexList[i - 1]);
            }

            gaps.Reverse();

            List<char> reversedQuality = quality.ToCharArray().ToList();

            reversedQuality.Reverse();

            quality = string.Join("", reversedQuality);

            gaps.Add(quality.IndexOf('X') + 1);

            return gaps.ToArray();
        }

        private bool CoorectQuality(string quality, int startingNote)
        {
            int[] noteGaps = FindGaps(startingNote);

            if (quality == "X..XX.....X." && startingNote == 3)
            {
                PrintDebug("");
            }

            int[] qualityGaps = FindGaps(quality);

            bool correctQuality = false;

            for (int i = 0; i < noteGaps.Length; i++)
            {
                correctQuality = noteGaps[i] == qualityGaps[i];

                if (!correctQuality)
                {
                    break;
                }
            }

            if (correctQuality)
            {
                PrintDebugLine("Gaps: " + string.Join(", ", qualityGaps) + "\n");
                return true;
            }

            return false;
        }

        private void FindNewRoot()
        {
            switch (currentQuality)
            {
                case "X...X..X..X.":
                    newRoot = Note.G;
                    break;

                case "X..X...X..X.":
                    newRoot = Note.GSharp;
                    break;

                case "X...X..X...X":
                    newRoot = Note.ASharp;
                    break;

                case "X..X...X...X":
                    newRoot = Note.F;
                    break;

                case "X..XX.....X.":
                    newRoot = Note.A;
                    break;

                case "X..X..X...X.":
                    newRoot = Note.CSharp;
                    break;

                case "X.X.X..X....":
                    newRoot = Note.DSharp;
                    break;

                case "X.XX...X....":
                    newRoot = Note.E;
                    break;

                case "X...X...X.X.":
                    newRoot = Note.FSharp;
                    break;

                case "X...X...X..X":
                    newRoot = Note.C;
                    break;

                case "X....X.X..X.":
                    newRoot = Note.D;
                    break;

                case "X..X....X..X":
                    newRoot = Note.B;
                    break;
            }
        }

        private void FindNewQuality()
        {
            switch (currentRoot)
            {
                case Note.A:
                    newQuality = qualities[11];
                    break;
                case Note.ASharp:
                    newQuality = qualities[9];
                    break;
                case Note.B:
                    newQuality = qualities[1];
                    break;
                case Note.C:
                    newQuality = qualities[5];
                    break;
                case Note.CSharp:
                    newQuality = qualities[7];
                    break;
                case Note.D:
                    newQuality = qualities[2];
                    break;
                case Note.DSharp:
                    newQuality = qualities[4];
                    break;
                case Note.E:
                    newQuality = qualities[10];
                    break;
                case Note.F:
                    newQuality = qualities[6];
                    break;
                case Note.FSharp:
                    newQuality = qualities[0];
                    break;
                case Note.G:
                    newQuality = qualities[3];
                    break;
                case Note.GSharp:
                    newQuality = qualities[8];
                    break;
            }
        }

        private List<string> FindAnswer()
        {
            List<Note> answer = new List<Note>();

            answer.Add(newRoot);

            List<int> indexList = new List<int>();

            List<int> gaps = new List<int>();

            for (int i = 0; i < newQuality.Length; i++)
            {
                if (newQuality[i] == 'X')
                {
                    indexList.Add(i);
                }
            }

            for (int i = indexList.Count - 1; i > 0; i--)
            {
                gaps.Add(indexList[i] - indexList[i - 1]);
            }

            gaps.Reverse();

            Note currentNote = newRoot;

            foreach (int gap in gaps)
            {
                Note newNote = (Note)((int)(currentNote + gap) % 12);
                answer.Add(newNote);
                currentNote = newNote;
            }

            List<string> strAnswer = new List<string>();

            foreach (Note n in answer)
            { 
                strAnswer.Add(ConvertNote(n));
            }

            return strAnswer;
        }

        private Note ConvertNote(string s)
        {

            if (s.Length != 1)
            {
                s = s[0] + "Sharp";   
            }

            return (Note)Enum.Parse(typeof(Note), s);
        }

        private string ConvertNote(Note note)
        { 
            if(note.ToString().Length > 1)
            {
                return note.ToString()[0] + "#";
            }

            return note.ToString();
        }
    }
}
