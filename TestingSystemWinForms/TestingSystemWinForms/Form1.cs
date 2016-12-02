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
        public Form1()
        {
            InitializeComponent();
            r = new registrationForm();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
           
            User_Db u = new User_Db();

            var query = from b in u.Users
                        //where b.UserName == "user2"
                        select b;
           
            foreach(var el in query)
            {
                label1.Text += el.IsAdmin;
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            r.Show();
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          