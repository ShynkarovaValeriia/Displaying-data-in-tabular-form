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
            gvAnimals.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Ім'я";
            gvAnimals.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Species";
            column.Name = "Вид";
            gvAnimals.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Age";
            column.Name = "Вік";
            gvAnimals.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Weight";
            column.Name = "Вага";
            gvAnimals.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Height";
            column.Name = "Зріст";
            gvAnimals.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Region";
            column.Name = "Середовище";
            gvAnimals.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "IsWild";
            column.Name = "Дика";
            gvAnimals.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "IsDied";
            column.Name = "Зникаючий вид";
            gvAnimals.Columns.Add(column);

            bindSrcAnimals.Add(new Animal("Кіт", "Лев", 5, 190, 1.2, "Африка", true, true));
            bindSrcAnimals.Add(new Animal("Біллі", "Домашній пес", 3, 25, 0.5, "Європа", false, false));
            bindSrcAnimals.Add(new Animal("Рекс", "Вовк", 7, 45, 0.7, "Північна Америка", true, false));
            bindSrcAnimals.Add(new Animal("Лукас", "Кінь", 10, 500, 1.7, "Південна Америка", false, false));
            bindSrcAnimals.Add(new Animal("Шеррі", "Панда", 6, 100, 0.9, "Китай", true, true));
            bindSrcAnimals.Add(new Animal("Джек", "Кенгуру", 4, 85, 1.4, "Австралія", true, false));
            bindSrcAnimals.Add(new Animal("Сірко", "Лисиця", 2, 8, 0.4, "Європа", true, false));
            bindSrcAnimals.Add(new Animal("Белла", "Корова", 5, 600, 1.5, "Україна", false, false));
            bindSrcAnimals.Add(new Animal("Моллі", "Дельфін", 8, 150, 2.0, "Атлантичний океан", true, false));
            bindSrcAnimals.Add(new Animal("Тім", "Слон", 20, 5000, 3.2, "Африка", true, true));

            EventArgs args = new EventArgs(); OnResize(args);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Animal animal = new Animal();

            fAnimal fa = new fAnimal(ref animal);
            if (fa.ShowDialog() == DialogResult.OK)
            {
                bindSrcAnimals.Add(animal);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Animal animal = (Animal)bindSrcAnimals.List[bindSrcAnimals.Position];

            fAnimal fa = new fAnimal(ref animal);
            if (fa.ShowDialog() == DialogResult.OK)
            {
                bindSrcAnimals.List[bindSrcAnimals.Position] = animal;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалити поточний запис ?", "Видалення запису", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcAnimals.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcAnimals.Clear();
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