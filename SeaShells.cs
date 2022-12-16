using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class SeaShells : Module
    {
        private string phrase1;
        private string phrase2;
        private string bigButton;

        private string letters;

        private List<string> answerList;

        public SeaShells(
            Bomb bomb,
            StreamWriter logFileWriter,
            string phrase1,
            string phrase2,
            string bigButton
        ) : base(bomb, logFileWriter, "Sea Shells")
        {
            this.phrase1 = phrase1;
            this.phrase2 = phrase2;
            this.bigButton = bigButton;

            answerList = new List<string>();
        }

        public string Solve()
        {
            FindLetters();

            string aWord;
            string bWord;
            string cWord;
            string dWord;
            string eWord;

            switch (bigButton)
            {
                case "SHIH TZU":
                    aWord = "SHOE";
                    bWord = "SHIH TZU";
                    cWord = "SHE";
                    dWord = "SIT";
                    eWord = "SUSHI";
                    break;

                case "TOUCAN":
                    aWord = "CAN";
                    bWord = "TOUCAN";
                    cWord = "TUTU";
                    dWord = "2";
                    eWord = "CANCAN";
                    break;

                case "SWITCH":
                    aWord = "WITCH";
                    bWord = "SWITCH";
                    cWord = "ITCH";
                    dWord = "TWITCH";
                    eWord = "STITCH";
                    break;

                default:
                    aWord = "BURGLAR ALARM";
                    bWord = "BULGARIA";
                    cWord = "ARMOUR";
                    dWord = "BURGER";
                    eWord = "LLAMA";
                    break;
            }

            foreach (char c in letters)
            {
                switch (c)
                {
                    case 'A':
                        answerList.Add(aWord);
                        break;

                    case 'B':
                        answerList.Add(bWord);
                        break;

                    case 'C':
                        answerList.Add(cWord);
                        break;

                    case 'D':
                        answerList.Add(dWord);
                        break;

                    default:
                        answerList.Add(eWord);
                        break;
                }
            }

            answerList = SimplifyDirections(answerList);

            string answer = string.Join(", ", answerList);

            PrintDebugLine($"Phrase 1: {phrase1}");
            PrintDebugLine($"Phrase 2: {phrase2}");
            PrintDebugLine($"Letters: " + string.Join(", ", letters));

            ShowAnswer(answer, true);

            return answer;
        }

        public string FindLetters()
        {
            switch (phrase1)
            {
                case "SHE SELLS":

                    if (phrase2 == "SEA SHELLS")
                    {
                        letters = "BDABDAB";
                    }
                    else if (phrase2 == "SHE SHELLS")
                    {
                        letters = "ACEEAC";
                    }
                    else if (phrase2 == "SEA SELLS")
                    {
                        letters = "EACEACE";
                    }
                    else
                    {
                        letters = "DAABDAB";
                    }

                    break;

                case "SHE SHELLS":

                    if (phrase2 == "SEA SHELLS")
                    {
                        letters = "BEEBBE";
                    }
                    else if (phrase2 == "SHE SHELLS")
                    {
                        letters = "CDCCDB";
                    }
                    else if (phrase2 == "SEA SELLS")
                    {
                        letters = "EAEAEA";
                    }
                    else
                    {
                        letters = "BEEDA";
                    }

                    break;

                case "SEA SHELLS":

                    if (phrase2 == "SEA SHELLS")
                    {
                        letters = "ABABA";
                    }
                    else if (phrase2 == "SHE SHELLS")
                    {
                        letters = "EAAEEA";
                    }
                    else if (phrase2 == "SEA SELLS")
                    {
                        letters = "DBEAC";
                    }
                    else
                    {
                        letters = "ABDBAA";
                    }

                    break;

                default:

                    if (phrase2 == "SEA SHELLS")
                    {
                        letters = "ACACEAC";
                    }
                    else if (phrase2 == "SHE SHELLS")
                    {
                        letters = "DBAEC";
                    }
                    else if (phrase2 == "SEA SELLS")
                    {
                        letters = "EBDADAB";
                    }
                    else
                    {
                        letters = "CECEC";
                    }

                    break;
            }

            return letters;
        }

        private List<string> SimplifyDirections(List<string> list)
        {
            List<string> directions = new List<string>();
            while(list.Count > 0) 
            { 
                string currentWord = list[list.Count - 1];
                int num = 1;
                list.RemoveAt(list.Count - 1);

                while (list.Count > 0 && list[list.Count - 1] == currentWord)
                {
                    num++;
                    list.RemoveAt(list.Count - 1);
                }

                directions.Add($"{currentWord} x{num}");
            }

            return directions;
        }
    }
}
