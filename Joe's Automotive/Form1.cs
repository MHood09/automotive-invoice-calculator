using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joe_s_Automotive
{
    public partial class Form1 : Form
    {
        public object Resquest { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        public decimal oilLubeCharges()
        {
            decimal Oil;
            decimal Lube;
            if(oilChangeCheckBox.Checked == true)
            {
                Oil = 26.00m;
           
            }
            else
            {
                Oil = 0;
            }
            if(lubeJobCheckBox.Checked == true)
            {
                Lube = 18.00m;
            }
            else
            {
                Lube = 0;
            }

            return Oil + Lube;
        }

        public decimal flushCharges()
        {
            decimal Radiator;
            decimal Trans;
            if (radiatorFlushCheckBox.Checked == true)
            {
                Radiator = 30.00m;
            }
            else
            {
                Radiator = 0;
            }
            if (transFlushCheckBox.Checked == true)
            {
                Trans = 80.00m;
            }
            else
            {
                Trans = 0;
            }

            return Radiator + Trans;
        }

        public decimal miscCharges()
        {
            decimal Tire;
            decimal Muffler;
            decimal Inspection;
            if (tireRotationCheckBox.Checked == true)
            {
                Tire = 20.00m;
            }
            else
            {
                Tire = 0;
            }
            if (replaceMufflerCheckBox.Checked == true)
            {
                Muffler = 100.00m;
            }
            else
            {
                Muffler = 0;
            }
            if (inspectionCheckBox.Checked == true)
            {
                Inspection = 15.00m;
            }
            else
            {
                Inspection = 0;
            }
            
            return Tire + Muffler + Inspection;
        }

        public void oilLubeClear()
        {
            oilChangeCheckBox.Checked = false;
            lubeJobCheckBox.Checked = false;
        }

        public void miscClear()
        {
            inspectionCheckBox.Checked = false;
            replaceMufflerCheckBox.Checked = false;
            tireRotationCheckBox.Checked = false;
        }

        public void flushesClear()
        {
            radiatorFlushCheckBox.Checked = false;
            transFlushCheckBox.Checked = false;
        }

        public void partsLaborClear()
        {
            partsTextBox.Text = "";
            laborTextBox.Text = "";
        }

        public void summaryClear()
        {
            serviceLaborLabel.Text = "";
            partsLabel.Text = "";
            taxLabel.Text = "";
            totalFeesLabel.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            oilLubeClear();
            miscClear();
            flushesClear();
            partsLaborClear();
            summaryClear();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            decimal Parts = 0;
            decimal Labor = 0;
            decimal Tax = 0;
            decimal Total = 0;
            if (string.IsNullOrEmpty(partsTextBox.Text))
            {
                partsLabel.Text = 0.ToString("c");
                taxLabel.Text = 0.ToString("c");
            }
            else
                if (decimal.TryParse(partsTextBox.Text, out Parts))
                {
                    Tax = Parts * .06m;
                    partsLabel.Text = Parts.ToString("c");
                    taxLabel.Text = Tax.ToString("c");
                }
            else
            {
                MessageBox.Show("Parts must be numeric");
            }

            if (string.IsNullOrEmpty(laborTextBox.Text))
            {
                serviceLaborLabel.Text = 0.ToString("c");
            }
            else 
                if (decimal.TryParse(laborTextBox.Text, out Labor))
                {
                    serviceLaborLabel.Text = Labor.ToString("c");
                }
            else
            {
                MessageBox.Show("Labor must be numeric");
            }

            Total = oilLubeCharges() + flushCharges() + miscCharges() + Labor + Parts + Tax;

            totalFeesLabel.Text = Total.ToString("c");

        }
    }
}
