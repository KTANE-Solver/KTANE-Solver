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
    /// Purpose: Tells the user to alert the customer and give a new cash amout
    /// </summary>

    public partial class CheapCheckoutAlertForm : ModuleForm
    {
        decimal total;

        public CheapCheckoutAlertForm(decimal total, StreamWriter logfileWriter)
        {
            LogFileWriter = logfileWriter;
            InitializeComponent();
            this.total = total;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //check to make sure text box converts to double
            Decimal amount;

            try
            {
                amount = Decimal.Parse(newAmountTextBox.Text);
            }
            catch
            {
                ShowErrorMessage("Invalid amount");
                return;
            }

            //make sure amount only has to decimals

            if (Decimal.Round(amount, 2) != amount)
            {
                ShowErrorMessage("Amount should only have 2 decimals");
                return;
            }

            //new amount cant be lower than total
            if (amount < total)
            {
                ShowErrorMessage("New amount can't be less than total");
                return;
            }

            decimal answer = RoundPrice(amount - total);

            PrintDebugLine($"Answer: ${answer}\n");
            ShowAnswer($"${string.Format("{0:0.00}", answer)}");

            this.Hide();
        }

        private Decimal RoundPrice(Decimal oldPrice)
        {
            //round the price
            return Math.Round(oldPrice, 2, MidpointRounding.AwayFromZero);
        }
    }
}
