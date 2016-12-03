using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingSystemWinForms
{
    public partial class Form1 : Form
    {
        registrationForm r;
        User_Db userDb;

        ClientForm clientForm;
        AdminForm adminForm;

        public Form1()
        {
            InitializeComponent();

            userDb = new User_Db();
            r = new registrationForm();

            clientForm = new ClientForm();
            adminForm = new AdminForm();
        }

        private bool UserLoginInformationIsValid(User userLoginInfo)
        {
            foreach(var user in userDb.Users)
            {
                if(user.UserName == userLoginInfo.UserName)
                { 
                    return user.Password == userLoginInfo.Password;
                }
            }
            return false;
        }

        private bool UserIsAdmin(User userInfo)
        {
            foreach(var user in userDb.Users)
            {
                if(user.UserName == userInfo.UserName)
                {
                    return user.IsAdmin;
                }
            }

            return false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

            User user = new User();
            user.UserName = userName;
            user.Password = password;

            bool loginInfomationIsValid = UserLoginInformationIsValid(user);

            if (loginInfomationIsValid)
            {
                if (UserIsAdmin(user))
                {
                    adminForm.Show();
                }
                else
                {
                    clientForm.Show();
                }
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            r.Show();
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          