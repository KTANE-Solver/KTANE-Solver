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
        private Note note1;
        private Note note2;
        private Note note3;
        private Note note4;

        private Note currentRoot;
        private string currentQuality;

        private List<string> qualities;

        private Note newRoot;
        private string newQuality;

        public ChordQualities(
            Bomb bomb,
            StreamWriter logFileWriter,
            Note note1,
            Note note2,
            Note note3,
            Note note4
        ) : base(bomb, logFileWriter, "Chord Qualities")
        {
            this.note1 = note1;
            this.note2 = note2;
            this.note3 = note3;
            this.note4 = note4;

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
            PrintDebugLine("Note 1: " + this.note1);
            PrintDebugLine("Note 2: " + this.note2);
            PrintDebugLine("Note 3: " + this.note3);
            PrintDebugLine("Note 4: " + this.note4 + "\n");

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
            Note[] notes = new Note[] { note1, note2, note3, note4 };

            if (note1 != notes.Min())
            {
                int minIndex = Array.IndexOf(notes, notes.Min());

                Note minNote = notes[minIndex];
                Note firstNote = notes[0];

                notes[0] = minNote;
                notes[minIndex] = firstNote;
            }

            if (note4 != notes.Max())
            {
                int maxIndex = Array.IndexOf(notes, notes.Max());

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

            note1 = notes[0];
            note2 = notes[1];
            note3 = notes[2];
            note4 = notes[3];
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

            switch (startingNote)
            {
                case 1:
                    currentRoot = note1;
                    break;

                case 2:
                    currentRoot = note2;
                    break;

                case 3:
                    currentRoot = note3;
                    break;

                default:
                    currentRoot = note4;
                    break;
            }

            this.currentQuality = quality;
        }

        private int[] FindGaps(int startingNote)
        {
            int[] gaps;

            switch (startingNote)
            {
                case 1:
                    gaps = new int[] { note2 - note1, note3 - note2, note4 - note3, note4 - note1 };
                    break;

                case 2:
                    gaps = new int[] { note3 - note2, note4 - note3, note4 - note1, note2 - note1 };
                    break;

                case 3:
                    gaps = new int[] { note4 - note3, note4 - note1, note2 - note1, note3 - note2 };
                    break;

                default:
                    gaps = new int[] { note4 - note1, note2 - note1, note3 - note2, note4 - note3 };
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

        private List<Note> FindAnswer()
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
                Note newNote = (Note)(((int)(currentNote + gap) % 12));
                answer.Add(newNote);
                currentNote = newNote;
            }

            return answer;
        }
    }
}
