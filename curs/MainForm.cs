using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace curs
{
    public partial class MainForm : Form
    {
        private Person loggedInPerson;
        private List<Animal> animals = new List<Animal>();

        public MainForm(Person person)
        {
            InitializeComponent();
            this.loggedInPerson = person;
            SetupFormBasedOnRole();
        }

        private void SetupFormBasedOnRole()
        {
            switch (loggedInPerson.Type)
            {
                case PersonType.User:
                    // Show animal management UI
                    lblWelcome.Text = $"Welcome, {loggedInPerson.Username} (User)";
                    break;
                case PersonType.Sponsor:
                    // Setup UI for sponsors
                    lblWelcome.Text = $"Welcome, {loggedInPerson.Username} (Sponsor)";
                    SetupSponsorUI();
                    break;
            }
        }

        private void SetupSponsorUI()
        {
            // Example: Add a TextBox for donation and a button to submit donation
            TextBox txtDonation = new TextBox();
            Button btnDonate = new Button();
            Label lblDonationInfo = new Label { Text = "Enter donation amount:" };
            btnDonate.Text = "DONATE";
            btnDonate.Location = new Point(1300, 150);
            txtDonation.Location = new Point(1300, 50);
            lblDonationInfo.Location = new Point(1300, 10);

            // Setup event for donation button
            btnDonate.Click += (sender, args) =>
            {
                MessageBox.Show($"Thank you for your donation of ${txtDonation.Text}!");
                // Logic to handle the donation
            };

            this.Controls.Add(lblDonationInfo);
            this.Controls.Add(txtDonation);
            this.Controls.Add(btnDonate);
        }

        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtAge.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                try
                {
                    int age = int.Parse(txtAge.Text);
                    if (cmbAnimalType.SelectedItem != null)
                    {
                        string animalType = cmbAnimalType.SelectedItem.ToString();
                        switch (animalType)
                        {
                            case "Dog":
                                animals.Add(new Dog(txtName.Text, age, txtDescription.Text, txtBreed.Text));
                                break;
                            case "Cat":
                                animals.Add(new Cat(txtName.Text, age, txtDescription.Text, txtCharacteristics.Text));
                                break;
                            default:
                                MessageBox.Show("Invalid animal type!");
                                break;
                        }
                        UpdateAnimalList();
                    }
                    else
                    {
                        MessageBox.Show("Please select an animal type!");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please ensure age is a valid number!", "Input Error");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields!", "Input Error");
            }
        }


        private void btnDeleteAnimal_Click(object sender, EventArgs e)
        {
            if (lstAnimals.SelectedIndex >= 0)
            {
                animals.RemoveAt(lstAnimals.SelectedIndex);
                UpdateAnimalList();
            }
            else
            {
                MessageBox.Show("Please select an animal to delete.");
            }
        }

        private void UpdateAnimalList()
        {
            lstAnimals.Items.Clear();
            foreach (Animal animal in animals)
            {
                lstAnimals.Items.Add(animal.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtAge_Leave(object sender, EventArgs e)
        {
        }

        private void txtAge_Enter(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
