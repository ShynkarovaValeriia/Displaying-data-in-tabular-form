using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class fAnimal : Form
    {
        private Animal animal;

        public fAnimal(ref Animal animal)
        {
            InitializeComponent();
            this.animal = animal;

            if (animal != null)
            {
                txtName.Text = animal.Name;
                txtSpecies.Text = animal.Species;
                txtAge.Text = animal.Age.ToString();
                txtWeight.Text = animal.Weight.ToString();
                txtHeight.Text = animal.Height.ToString();
                txtRegion.Text = animal.Region;
                chkIsWild.Checked = animal.IsWild;
                chkIsDied.Checked = animal.IsDied;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            animal.Name = txtName.Text;
            animal.Species = txtSpecies.Text;
            animal.Age = int.Parse(txtAge.Text);
            animal.Weight = double.Parse(txtWeight.Text);
            animal.Height = double.Parse(txtHeight.Text);
            animal.Region = txtRegion.Text;
            animal.IsWild = chkIsWild.Checked;
            animal.IsDied = chkIsDied.Checked;

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