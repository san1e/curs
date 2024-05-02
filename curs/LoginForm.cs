using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curs
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var role = cmbRole.SelectedItem.ToString() == "User" ? PersonType.User : PersonType.Sponsor;

            var person = new Person(username, role);
            MainForm mainForm = new MainForm(person);
            this.Hide();
            mainForm.Show();
        }
    }
}
