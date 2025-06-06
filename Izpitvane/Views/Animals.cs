using Izpitvane.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Izpitvane
{
    public partial class Animals : Form
    {

        AnimalController animalsController = new AnimalController();
        BreedController breedController = new BreedController();

        public Animals()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Breed> allBreeds = breedController.GetAllBreeds();
            comboBox1.DataSource = allBreeds;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            btnall_Click(sender, e);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                textBox2.Focus();
                return;
            }
            Animal newAnimal = new Animal();
            newAnimal.Age = int.Parse(textBox3.Text);
            newAnimal.Name = textBox2.Text;
            newAnimal.BreedId = (int)comboBox1.SelectedValue;

            animalsController.Create(newAnimal);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            btnAdd_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                Animal findedAnimal = animalsController.Get(findId);
                if (findedAnimal == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    textBox1.BackColor = Color.Red;
                    textBox1.Focus();
                    return;
                }
                LoadRecord(findedAnimal);
            }
            else
            {
                Animal updatedAnimal = new Animal();
                updatedAnimal.Name = textBox2.Text;
                updatedAnimal.Age = int.Parse(textBox3.Text);
                updatedAnimal.BreedId = (int)comboBox1.SelectedValue;

                animalsController.Update(findId, updatedAnimal);
            }
            btnall_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }
            Animal findedAnimal = animalsController.Get(findId);
            if (findedAnimal == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            LoadRecord(findedAnimal);

            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис No " +
            findId + " ?",
             "PROMPT", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                animalsController.Delete(findId);
            }

            btnall_Click(sender, e);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }
            Animal findedAnimal = animalsController.Get(findId);
            if (findedAnimal == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            LoadRecord(findedAnimal);
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            List<Animal> allAnimals = animalsController.GetAll();
            listItem.Items.Clear();
            foreach (var item in allAnimals)
            {
                listItem.Items.Add($"{item.Id}. {item.Name} - Age: {item.Age} Breed:{item.Breeds.Name}");
            }
        }

        private void LoadRecord(Animal animal)
        {
            textBox1.BackColor = Color.White;
            textBox1.Text = animal.Id.ToString();
            textBox2.Text = animal.Name;
            textBox3.Text = animal.Age.ToString();
            comboBox1.Text = animal.Breeds.Name;
        }

        private void ClearScreen()
        {
            textBox1.BackColor = Color.White;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.Text)
                {
                    case "Улично":
                        pictureBox1.Image = System.Drawing.Image.FromFile("ulichno-kuche-spasqva-ot-hipotermiq-i-smurt-3-godishno-momichence.jpg");
                        break;
                    case "Йорки":
                        pictureBox1.Image = System.Drawing.Image.FromFile("Yorkie-pozira.jpg");
                        break;
                    case "Хъски":
                        pictureBox1.Image = System.Drawing.Image.FromFile("768x432.jpg");
                        break;
                    case "Мопс":
                        pictureBox1.Image = System.Drawing.Image.FromFile("Pug1.jpg");
                        break;
                    case "Пинчер":
                        pictureBox1.Image = System.Drawing.Image.FromFile("3-1.jpg");
                        break;
                    case "Чихуахуа":
                        pictureBox1.Image = System.Drawing.Image.FromFile("chihuahuas-running-on-grass-1024x675.jpg");
                        break;
                    case "Чао-чао":
                        pictureBox1.Image = System.Drawing.Image.FromFile("vanshen-vid-na-chau-chau.jpg");
                        break;
                    case "Лабрадор":
                        pictureBox1.Image = System.Drawing.Image.FromFile("1250-666-labrador-retrivyr.jpg");
                        break;
                    default:
                        pictureBox1.Image = null;
                        break;
                }
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }
    }
}
 

