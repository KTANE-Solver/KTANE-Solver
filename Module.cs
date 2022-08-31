using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date: 4/8/21
    /// Purpose: Keeps all the information that
    ///          all modules have here
    /// </summary>
    public class Module
    {
        //where the information of the bomb is stored
        public Bomb Bomb;

        //used to write to the log file
        public StreamWriter LogFileWriter;

        protected string Name { get; }

        /// <summary>
        /// Base of a module
        /// </summary>
        /// <param name="bomb">used for edgework</param>
        /// <param name="logFileWriter">used to write to the log file</param>
        public Module(Bomb bomb, StreamWriter logFileWriter, string name)
        {
            Bomb = bomb;
            LogFileWriter = logFileWriter;

            string[] wordList = name.Split(' ');

            name = "";

            foreach (string word in wordList)
            {
                name += ("" + word[0]).ToUpper();
                name += word.Substring(1).ToLower();
                name += " ";
            }

            Name = name.Trim();
        }

        /// <summary>
        /// A method that will show the answer in a messageBox
        /// </summary>
        public void ShowAnswer(String answer, bool acutalAnswer)
        {
            if (acutalAnswer)
            {
                PrintDebugLine("Answer: " + answer + "\n");
            }

            MessageBox.Show(
                answer,
                $"{Name} Answer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        public void ShowErrorMessage(String error)
        {
            PrintDebugLine($"{Name} Error: {error}\n");

            MessageBox.Show(error, $"{Name} Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void PrintDebugLine(String message)
        {
            PrintDebug(message + "\n");
        }

        public void PrintDebug(String message)
        {
            LogFileWriter.Write(message);
            System.Diagnostics.Debug.Write(message);
        }
    }
}
