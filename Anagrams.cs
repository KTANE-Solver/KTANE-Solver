using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    class Anagrams : Module
    {
        private Dictionary<string, string> dictionary;

        public Anagrams(Bomb bomb, StreamWriter logFileWriter)
            : base(bomb, logFileWriter, "Anagrams")
        {
            //set up the dictionary
            dictionary = new Dictionary<string, string>();

            dictionary.Add("ARMETS", "MASTER");
            dictionary.Add("BARELY", "BLEARY");
            dictionary.Add("BARLEY", "BLEARY");
            dictionary.Add("BLEARY", "BARELY");
            dictionary.Add("CALLER", "RECALL");
            dictionary.Add("CELLAR", "RECALL");
            dictionary.Add("CEREUS", "SECURE");
            dictionary.Add("CERUSE", "SECURE");
            dictionary.Add("DUSTER", "RUSTED");
            dictionary.Add("LOOPED", "POODLE");
            dictionary.Add("MASTER", "STREAM");
            dictionary.Add("MATERS", "MASTER");
            dictionary.Add("MATRES", "MASTER");
            dictionary.Add("POODLE", "LOOPED");
            dictionary.Add("POOLED", "LOOPED");
            dictionary.Add("RAMETS", "MASTER");
            dictionary.Add("RASHES", "SHARES");
            dictionary.Add("RECALL", "CALLER");
            dictionary.Add("RECUSE", "SECURE");
            dictionary.Add("RESCUE", "SECURE");
            dictionary.Add("RUDEST", "DUSTER");
            dictionary.Add("RUSTED", "DUSTER");
            dictionary.Add("SEATED", "TEASED");
            dictionary.Add("SEDATE", "TEASED");
            dictionary.Add("SECURE", "RESCUE");
            dictionary.Add("SHARES", "SHEARS");
            dictionary.Add("SHEARS", "SHARES");
            dictionary.Add("STREAM", "MASTER");
            dictionary.Add("TAMERS", "MASTER");
            dictionary.Add("TEASED", "SEATED");
        }

        /// <summary>
        /// Gives the user an anagram of the given word
        /// </summary>
        /// <param name="word"></param>
        public void Solve(string word)
        {
            ShowAnswer(dictionary[word], true);
        }
    }
}
