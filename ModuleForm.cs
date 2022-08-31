using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date: 4/9/21
    /// Purpose: Keeps all the information that
    ///           all module forms have here
    /// </summary>
    public partial class ModuleForm : Form
    {
        protected Bomb Bomb { get; set; }

        protected StreamWriter LogFileWriter { get; set; }

        protected ModuleSelectionForm ModuleSelectionForm;

        protected string ModuleName { get; set; }

        //this should never be used
        public ModuleForm()
        {
            InitializeComponent();

            FormClosing += CloseProgram;

            Shown += ChangeTitle;
        }

        public ModuleForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm,
            string name,
            bool answerForm
        )
        {
            InitializeComponent();

            FormClosing += CloseProgram;

            string[] wordList = name.Split(' ');

            name = "";

            foreach (string word in wordList)
            {
                name += ("" + word[0]).ToUpper();
                name += word.Substring(1).ToLower();
                name += " ";
            }

            ModuleName = name.Trim();

            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            if (!answerForm)
            {
                Shown += ChangeTitle;
            }
        }

        /// <summary>
        /// Updates infomration needed to solve most modules
        /// and reset the form
        /// </summary>
        /// <param name="bomb"></param>
        /// <param name="logFileWriter"></param>
        /// <param name="moduleSelectionForm"></param>
        public void UpdateEdgeWork(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            Bomb = bomb;
            LogFileWriter = logFileWriter;
            ModuleSelectionForm = moduleSelectionForm;
        }

        /// <summary>
        /// Adds one strike to the bomb
        /// </summary>
        public void IncrementStrike()
        {
            Bomb.Strike++;
            string info =
                $"A stike has been added by {ModuleName}. Currently at {Bomb.Strike} strike(s)";
            PrintDebugLine(info + "\n");
            MessageBox.Show(info, "Strike Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Asks the user if they want to close the program
        /// </summary>
        /// <param name="e"></param>
        public void CloseProgram(object sender, FormClosingEventArgs e)
        {
            if (this.Visible)
            {
                String message = "Are you sure you want to quit the program?";
                String caption = "Quit Program";

                DialogResult result = MessageBox.Show(
                    message,
                    caption,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                //if the user clicks no, don't close the program
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    PrintDebug("User closed program...");
                    LogFileWriter.Close();
                    this.Visible = false;
                    Application.Exit();
                }
            }
        }

        public void ChangeTitle(object sender, EventArgs e)
        {
            Text = "KTANE Bot by Hawker";
        }

        public void ShowErrorMessage(String message)
        {
            MessageBox.Show(
                message,
                $"{ModuleName} Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public void ShowAnswer(String message)
        {
            MessageBox.Show(
                message,
                $"{ModuleName} Answer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
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

        public void GoToMoudleSelectionForm()
        {
            PrintDebugLine("User is going back to module selection\n");
            this.Hide();
            ModuleSelectionForm.UpdateForm();
            ModuleSelectionForm.Show();
        }

        /// <summary>
        /// Prints a header for whenever a module is solved (or it's first stage is)
        /// </summary>
        /// <param name="name"></param>
        public void PrintHeader()
        {
            PrintDebugLine($"================={ModuleName.ToUpper()}=================\n");
        }
    }
}
