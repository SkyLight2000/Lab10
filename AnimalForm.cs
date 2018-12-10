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
    public partial class AnimalForm : Form
    {
        public Animal TheAnimal;

        public AnimalForm(Animal t)
        {
            TheAnimal = t;
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                TheAnimal.Name = tbName.Text.Trim();
                TheAnimal.Type = tbType.Text.Trim();
                TheAnimal.Breed = tbBreed.Text.Trim();
                TheAnimal.Color = tbColor.Text.Trim();
                TheAnimal.Age = int.Parse(tbAge.Text.Trim());
                TheAnimal.Weight = int.Parse(tbWeight.Text.Trim());
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string err = String.Format("Error number. {0}", ex.Message);
                MessageBox.Show(err, "Conversion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AnimalForm_Load(object sender, EventArgs e)
        {
            if (TheAnimal != null)
            {
                tbName.Text = TheAnimal.Name;
                tbType.Text = TheAnimal.Type;
                tbBreed.Text = TheAnimal.Breed;
                tbColor.Text = TheAnimal.Color;
                tbAge.Text = TheAnimal.Age.ToString();
                tbWeight.Text = TheAnimal.Weight.ToString();
            }
        }
    }
}