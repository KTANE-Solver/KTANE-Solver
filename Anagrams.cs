using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    public class Anagrams : Module
    {
        private Dictionary<string, string> dictionary;

        public Anagrams(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Anagrams")
        {
            //set up the dictionary
            dictionary = new Dictionary<string, string>
            {
                { "ARMETS", "MASTER" },
                { "BARELY", "BLEARY" },
                { "BARLEY", "BLEARY" },
                { "BLEARY", "BARELY" },
                { "CALLER", "RECALL" },
                { "CELLAR", "RECALL" },
                { "CEREUS", "SECURE" },
                { "CERUSE", "SECURE" },
                { "DUSTER", "RUSTED" },
                { "LOOPED", "POODLE" },
                { "MASTER", "STREAM" },
                { "MATERS", "MASTER" },
                { "MATRES", "MASTER" },
                { "POODLE", "LOOPED" },
                { "POOLED", "LOOPED" },
                { "RAMETS", "MASTER" },
                { "RASHES", "SHARES" },
                { "RECALL", "CALLER" },
                { "RECUSE", "SECURE" },
                { "RESCUE", "SECURE" },
                { "RUDEST", "DUSTER" },
                { "RUSTED", "DUSTER" },
                { "SEATED", "TEASED" },
                { "SEDATE", "TEASED" },
                { "SECURE", "RESCUE" },
                { "SHARES", "SHEARS" },
                { "SHEARS", "SHARES" },
                { "STREAM", "MASTER" },
                { "TAMERS", "MASTER" },
                { "TEASED", "SEATED" }
            };
        }

        /// <summary>
        /// Gives the user an anagram of the given word
        /// </summary>
        /// <param name="word"></param>
        public string Solve(string word, bool debug)
        {
            string answer = dictionary[word];
            if (!debug)
            { 
                ShowAnswer(answer, true);
            }

            return answer;
        }
    }
}
