using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace New_KTANE_Solver
{
    public partial class PlateForm : Form
    {
        public static List<Plate> plates;

        public Plate plate;

        public int stage;

        public int plateNum;

        private EdgeworkInputForm edgeworkInputForm;

        private EdgeworkConfirmationForm edgeworkConfirmationForm;

        private StreamWriter logFileWriter;

        Bomb oldBomb;

        public PlateForm(int stage, int plateNum, Bomb oldBomb, EdgeworkInputForm edgeworkInputForm, StreamWriter logFileWriter)
        {
            InitializeComponent();
            ControlBox = false;
            ResetPlateList();
            this.stage = stage;
            this.plateNum = plateNum;
            ClearForm();
            this.edgeworkInputForm = edgeworkInputForm;
            this.logFileWriter = logFileWriter;
            this.oldBomb = oldBomb;
        }



        public void ResetPlateList()
        { 
            plates = new List<Plate>();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (stage == 1)
            {
                edgeworkInputForm.Show();
                this.Close();
            }

            else
            {
                plates.Remove(plates.Last());

                stage -= 1;

                ClearForm();
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            bool pp = parellelCheckBox.Checked;
            bool rca = RcaCheckBox.Checked;
            bool serial = serialCheckBox.Checked;
            bool rj = rjCheckBox.Checked;
            bool dvi = DviCheckBox.Checked;
            bool ps = psCheckBox.Checked;

            int checkCount = CheckCount();
            bool ppSerial = pp && serial;

            bool fullPlate = rca && rj && dvi && ps;

            if (ppSerial && checkCount > 2)
            {
                MessageBox.Show("Plate can't have more ports if there is a serial and parallel ports on it", "Invalid Port Plate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fullPlate && checkCount > 4)
            {
                MessageBox.Show("Plate can't have more ports if there is a rj, rca, dvi, and ps/2 ports on it", "Invalid Port Plate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            plate = new Plate(parellelCheckBox.Checked, RcaCheckBox.Checked, serialCheckBox.Checked, rjCheckBox.Checked, DviCheckBox.Checked, psCheckBox.Checked);

            plates.Add(plate);

            if (stage == plateNum)
            {
                this.Hide();

                edgeworkInputForm.Hide();

                Bomb newBomb = new Bomb(oldBomb.Day, oldBomb.SerialNumber, oldBomb.Battery, oldBomb.BatteryHolder, oldBomb.Bob, oldBomb.Car, oldBomb.Clr, oldBomb.Frk, oldBomb.Frq, oldBomb.Ind, oldBomb.Msa, oldBomb.Nsa, oldBomb.Sig, oldBomb.Snd, oldBomb.Trn, plates);

                edgeworkConfirmationForm = new EdgeworkConfirmationForm(newBomb, edgeworkInputForm, logFileWriter);

                edgeworkConfirmationForm.Show();
            }

            else
            {
                stage += 1;
                ClearForm();
            }
        }

        public void ClearForm()
        {
            label1.Text = $"Plate {stage} of {plateNum}";

            parellelCheckBox.Checked = false;
            DviCheckBox.Checked = false;
            serialCheckBox.Checked = false;
            RcaCheckBox.Checked = false;
            psCheckBox.Checked = false;
            rjCheckBox.Checked = false;
        }


        private int CheckCount()
        {
            List<bool> checkList = new List<bool>()
            {
            parellelCheckBox.Checked, RcaCheckBox.Checked, serialCheckBox.Checked, rjCheckBox.Checked, DviCheckBox.Checked, psCheckBox.Checked
            };

            return checkList.Where(x => x).Count();
        }
    }
}
