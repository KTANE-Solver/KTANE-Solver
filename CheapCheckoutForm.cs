using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static New_KTANE_Solver.CheapCheckout;

namespace New_KTANE_Solver
{
    /// <summary>
    /// Author: Nya Bentley
    /// Date 6/9/21
    /// Purpose: Gets information needed to solve the Cheap Checkout module
    /// </summary>

    public partial class CheapCheckoutForm : ModuleForm
    {
        public CheapCheckoutForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        ) : base(bomb, logFileWriter, moduleSelectionForm, "Cheap Checkout", false)
        {
            InitializeComponent();
            UpdateForm(bomb, logFileWriter, moduleSelectionForm);
        }

        /// <summary>
        /// Updates the form so it looks brand new
        /// </summary>
        public void UpdateForm(
            Bomb bomb,
            StreamWriter logFileWriter,
            ModuleSelectionForm moduleSelectionForm
        )
        {
            UpdateEdgeWork(bomb, logFileWriter, moduleSelectionForm);

            amountTextBox.Text = "";

            SetUpFixedComboBox(item1ComboBox);
            SetUpFixedComboBox(item2ComboBox);
            SetUpFixedComboBox(item3ComboBox);
            SetUpFixedComboBox(item4ComboBox);

            SetUpWeightedComboBox(item5ComboBox);
            SetUpWeightedComboBox(item6ComboBox);

            SetUpWeightComboBox(item5WeightComboBox);
            SetUpWeightComboBox(item6WeightComboBox);
        }

        /// <summary>
        /// Sets up the comboBox that contain fixed items
        /// </summary>
        private void SetUpFixedComboBox(ComboBox comboBox)
        {
            String[] fixedItems = new string[]
            {
                "Candy Canes",
                "Canola Oil",
                "Cereal",
                "Cheese",
                "Chocolate Bar",
                "Chocolate Milk",
                "Coffee Beans",
                "Cookies",
                "Deodorant",
                "Fruit Punch",
                "Grape Jelly",
                "Grapefruit",
                "Gum",
                "Honey",
                "Ketchup",
                "Lollipops",
                "Lotion",
                "Mayonnaise",
                "Mints",
                "Mustard",
                "Oranges",
                "Paper Towels",
                "Pasta Sauce",
                "Peanut Butter",
                "Pork",
                "Potato Chips",
                "Shampoo",
                "Socks",
                "Soda",
                "Spaghetti",
                "Sugar",
                "Tea",
                "Tissues",
                "Toothpaste",
                "Water Bottles",
                "White Bread",
                "White Milk"
            };

            comboBox.Items.Clear();
            comboBox.Items.AddRange(fixedItems);
            comboBox.Text = fixedItems[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Sets up the comboBox that contain weighted items
        /// </summary>
        private void SetUpWeightedComboBox(ComboBox comboBox)
        {
            String[] items = new string[]
            {
                "Bananas",
                "Broccoli",
                "Chicken",
                "Grapefruit",
                "Lemons",
                "Lettuce",
                "Oranges",
                "Pork",
                "Potatoes",
                "Steak",
                "Tomatoes",
                "Turkey"
            };

            comboBox.Items.Clear();
            comboBox.Items.AddRange(items);
            comboBox.Text = items[0];
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Sets up the comboBox that contain wieghts
        /// </summary>
        private void SetUpWeightComboBox(ComboBox comboBox)
        {
            String[] wieghts = new string[] { "0.5", "1.0", "1.5" };
            comboBox.Items.Clear();
            comboBox.Items.AddRange(wieghts);
            comboBox.Text = wieghts[0];
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
            string itemStr1 = RemoveSpaces(item1ComboBox.Text);
            string itemStr2 = RemoveSpaces(item2ComboBox.Text);
            string itemStr3 = RemoveSpaces(item3ComboBox.Text);
            string itemStr4 = RemoveSpaces(item4ComboBox.Text);
            string itemStr5 = RemoveSpaces(item5ComboBox.Text);
            string itemStr6 = RemoveSpaces(item6ComboBox.Text);

            double item5Weight = Double.Parse(item5WeightComboBox.Text);
            double item6Weight = Double.Parse(item6WeightComboBox.Text);
            int amount;

            try
            {
                amount = Int32.Parse(amountTextBox.Text);
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

            //no duplicate items

            if (
                   itemStr1 == itemStr2
                || itemStr1 == itemStr3
                || itemStr1 == itemStr4
                || itemStr2 == itemStr3
                || itemStr2 == itemStr4
                || itemStr3 == itemStr4
                || itemStr5 == itemStr6
            )
            {
                ShowErrorMessage("Can't have duplicate items");
                return;
            }

            ItemName item1 = (ItemName)Enum.Parse(typeof(ItemName), itemStr1);
            ItemName item2 = (ItemName)Enum.Parse(typeof(ItemName), itemStr2);
            ItemName item3 = (ItemName)Enum.Parse(typeof(ItemName), itemStr3);
            ItemName item4 = (ItemName)Enum.Parse(typeof(ItemName), itemStr4);
            ItemName item5 = (ItemName)Enum.Parse(typeof(ItemName), itemStr5);
            ItemName item6 = (ItemName)Enum.Parse(typeof(ItemName), itemStr6);



            CheapCheckout module = new CheapCheckout(
                Bomb,
                LogFileWriter,
                amount,
                item1,
                item2,
                item3,
                item4,
                item5Weight,
                item5,
                item6Weight,
                item6
            );

            module.Solve(false, 0);

            UpdateForm(Bomb, LogFileWriter, ModuleSelectionForm);
        }

        private string RemoveSpaces(string str)
        {
            string s = (string)str.Clone();

            int spaceIndex = str.IndexOf(' ');

            if (spaceIndex != -1)
            {
                s = s.Remove(spaceIndex, 1);
            }

            return s;
        }
    }
}
