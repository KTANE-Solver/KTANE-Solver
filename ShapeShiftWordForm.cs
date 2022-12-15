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
    public partial class ShapeShiftWordForm : ModuleForm
    {
        public ShapeShiftWordForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Shape Shift", false)
        {
            InitializeComponent();
            UpdateForm();
        }

        private void UpdateForm()
        {
            UpdateComboBox(leftTicketComboBox);
            UpdateComboBox(rightTicketComboBox);
        }

        private void UpdateComboBox(ComboBox comboBox)
        {
            string[] words = new string[]  { "Flat", "Point", "Round", "Ticket" };
            comboBox.Items.Clear();
            comboBox.Items.AddRange(words);
            comboBox.Text = words[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoToMoudleSelectionForm();
        }

        private void strikeButton_Click(object sender, EventArgs e)
        {
            IncrementStrike();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            ShapeShift.TicketShape leftTicket = GetTicketEnum(leftTicketComboBox);
            ShapeShift.TicketShape rightTicket = GetTicketEnum(rightTicketComboBox);

            ShapeShift module = new ShapeShift(Bomb, LogFileWriter, leftTicket, rightTicket);
            module.Solve();
            UpdateForm();
        }

        private ShapeShift.TicketShape GetTicketEnum(ComboBox comboBox)
        {
            return (ShapeShift.TicketShape)
                Enum.Parse(typeof(ShapeShift.TicketShape), comboBox.Text);
        }
    }
}
