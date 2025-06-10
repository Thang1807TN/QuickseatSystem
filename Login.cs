using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuickseatClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Method.Showpassword(checkBox1, txbPassword);
        }

        public static class Method
        {
            public static void Showpassword(CheckBox checkBox, TextBox textBox)
            {
                if (checkBox.Checked)
                {
                    textBox.UseSystemPasswordChar = false; 
                }
                else
                {
                    textBox.UseSystemPasswordChar = true; 
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text.Trim(); 
            string password = txbPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            string filePath = "users.json.txt";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("User data file not found.");
                return;
            }

            string json = File.ReadAllText(filePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(json);

            string hashedPassword = PasswordHelper.ComputeSha256Hash(password);

            var user = users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.PasswordHash == hashedPassword);

            if (user != null)
            {
                MessageBox.Show("Login successful!");
                ManageBooking manage = new ManageBooking();
                manage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials.");
            }
        }
    }
}
