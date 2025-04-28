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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 5 * btnAdd.Width + 2 * tsSeparator1.Width + 30;
            btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0);
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            gvTowns.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Назва"; 
            gvTowns.Columns.Add(column);

            column = new DataGridViewTextBoxColumn(); 
            column.DataPropertyName = "Country"; 
            column.Name = "Країна"; 
            gvTowns.Columns.Add(column);

            column = new DataGridViewTextBoxColumn(); 
            column.DataPropertyName = "Region"; 
            column.Name = "Регіон"; 
            gvTowns.Columns.Add(column);

            column = new DataGridViewTextBoxColumn(); 
            column.DataPropertyName = "Population"; 
            column.Name = "Мешканців"; 
            gvTowns.Columns.Add(column);

            column = new DataGridViewTextBoxColumn(); 
            column.DataPropertyName = "YearIncome"; 
            column.Name = "Річн. дохід"; 
            gvTowns.Columns.Add(column);

            column = new DataGridViewTextBoxColumn(); 
            column.DataPropertyName = "Square"; 
            column.Name = "Площа";
            column.Width = 80; 
            gvTowns.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn(); 
            column.DataPropertyName = "HasPort"; 
            column.Name = "Порт";
            column.Width = 60; 
            gvTowns.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn(); 
            column.DataPropertyName = "HasAirport"; 
            column.Name = "Аеропорт";
            column.Width = 60; 
            gvTowns.Columns.Add(column);

            bindSrcTowns.Add(new Town("Львів", "Україна", "Львівська обл.", 800000, 2000000, 400, false, true));
            bindSrcTowns.Add(new Town("Київ", "Україна", "Київська обл.", 2900000, 5000000, 839, true, true));
            bindSrcTowns.Add(new Town("Одеса", "Україна", "Одеська обл.", 1000000, 3200000, 236, true, true));
            bindSrcTowns.Add(new Town("Харків", "Україна", "Харківська обл.", 1400000, 4500000, 350, false, true));
            bindSrcTowns.Add(new Town("Дніпро", "Україна", "Дніпропетровська обл.", 970000, 2500000, 405, false, true));
            bindSrcTowns.Add(new Town("Варшава", "Польща", "Мазовецьке", 1790000, 7000000, 517, false, false));
            bindSrcTowns.Add(new Town("Берлін", "Німеччина", "Берлін", 3760000, 15000000, 891, false, true));
            bindSrcTowns.Add(new Town("Париж", "Франція", "Париж", 2140000, 16000000, 105, false, true));
            bindSrcTowns.Add(new Town("Нью-Йорк", "США", "Нью-Йорк", 8400000, 90000000, 783, true, true));
            bindSrcTowns.Add(new Town("Токіо", "Японія", "Токіо", 13900000, 120000000, 2191, true, false));

            EventArgs args = new EventArgs(); OnResize(args);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Town town = new Town();

            fTown ft = new fTown(ref town);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcTowns.Add(town);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Town town = (Town)bindSrcTowns.List[bindSrcTowns.Position];

            fTown ft = new fTown(ref town);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcTowns.List[bindSrcTowns.Position] = town;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалити поточний запис ?", "Видалення запису", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcTowns.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcTowns.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок?", "Вихід з програми", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}