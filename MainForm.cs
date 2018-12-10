using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_10
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gvLakes.AutoGenerateColumns = false;
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Имя";
            gvLakes.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Type";
            column.Name = "Вид";
            gvLakes.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Breed";
            column.Name = "Порода";
            gvLakes.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Color";
            column.Name = "Цвет";
            gvLakes.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Age";
            column.Name = "Возраст";
            gvLakes.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Weight";
            column.Name = "Вес";
            gvLakes.Columns.Add(column);

            EventArgs args = new EventArgs();
            OnResize(args);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 5 * btnAdd.Width + 2 * tsSeparator1.Width + 30;
            btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Animal animal = new Animal();
            AnimalForm af = new AnimalForm(animal);
            if (af.ShowDialog() == DialogResult.OK)
            {
                bindSrcAnimals.Add(animal);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Animal lake = (Animal)bindSrcAnimals.List[bindSrcAnimals.Position];
            AnimalForm lf = new AnimalForm(lake);
            if (lf.ShowDialog() == DialogResult.OK)
            {
                bindSrcAnimals.List[bindSrcAnimals.Position] = lake;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить текущую запись?",
                "Удаление записи", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcAnimals.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистить таблицу?\n\nВсе данные будут утраченны",
                "Очищение данных", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcAnimals.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрыть приложение?", "Выход из программы",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
