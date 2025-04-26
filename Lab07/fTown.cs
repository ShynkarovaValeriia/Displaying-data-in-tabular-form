using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab07
{
    public partial class fTown : Form
    {
        public class Town
        {
            public string Name;
            public string Country;
            public string Region;
            public int Population;
            public double YearIncome;
            public double Square;
            public bool HasPort;
            public bool HasAirport;

            public double yearIncomePerInhabitant
            {
                get
                {
                    return GetYearIncomePerInhabitant();
                }
            }

            public double GetYearIncomePerInhabitant()
            {
                return YearIncome / Population;
            }
        }

        private Town town;
        private Lab07.Town town1;

        public fTown(ref Town town)
        {
            InitializeComponent();
            this.town = town;

            if (town != null)
            {
                txtName.Text = town.Name;
                txtCountry.Text = town.Country;
                txtRegion.Text = town.Region;
                txtPopulation.Text = town.Population.ToString();
                txtYearIncome.Text = town.YearIncome.ToString("0.00");
                txtSquare.Text = town.Square.ToString("0.000");
                chkHasPort.Checked = town.HasPort;
                chkHasAirport.Checked = town.HasAirport;
            }
        }

        public fTown(ref Lab07.Town town1)
        {
            this.town1 = town1;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            town.Name = txtName.Text;
            town.Country = txtCountry.Text;
            town.Region = txtRegion.Text;
            town.Population = int.Parse(txtPopulation.Text);
            town.YearIncome = double.Parse(txtYearIncome.Text);
            town.Square = double.Parse(txtSquare.Text);
            town.HasPort = chkHasPort.Checked;
            town.HasAirport = chkHasAirport.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
