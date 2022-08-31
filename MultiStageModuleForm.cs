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
    /// Date: 3/4/22
    /// Purpose: Used for modules that have more than one stage
    /// </summary>
    public partial class MultiStageModuleForm : ModuleForm
    {
        private ModuleForm firstStageForm;

        public MultiStageModuleForm() : base()
        {
            InitializeComponent();
        }

        public MultiStageModuleForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm,
            ModuleForm firstStageForm,
            string name,
            bool answerForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, name, answerForm)
        {
            InitializeComponent();
            this.firstStageForm = firstStageForm;
        }

        public void ResetModule()
        {
            this.Hide();
            firstStageForm.UpdateEdgeWork(Bomb, LogFileWriter, ModuleSelectionForm);
            firstStageForm.Show();
        }
    }
}
