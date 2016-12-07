using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TestingSystemWinForms
{
    public partial class registrationForm : Form
    {
        User_Db db;
        int adminCode;
        public registrationForm()
        {
            InitializeComponent();
            db = new User_Db();
            adminCode = 228;
            
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (userNameTextBox.Text != "" && passworTextBox.Text != "" && confirmPasswordTextBox.Text != "")
            {
                if (!Regex.IsMatch(userNameTextBox.Text, @"[^A-Za-z0-9_]"))
                {

                    foreach (var users in db.Users)
                    {
                        if (users.UserName == userNameTextBox.Text)
                        {
                            MessageBox.Show("User with this username already exists");
                            return;
                        }
                    }
                    int newUserId = (from p in db.Users
                                     select p).Count();


                    User newUser = new User()
                    {
                        UserName = userNameTextBox.Text,
                        Password = passworTextBox.Text,
                        Id = newUserId,
                        IsAdmin = (adminCodeTextBox.Text == adminCode.ToString()) ? true : false
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    MessageBox.Show("New user is added");

                    this.Hide();
                }
                else MessageBox.Show("Incorrect UserName! You can use A-Z, a-z, 0-9 or '_'");
            }
        }
    }
}
