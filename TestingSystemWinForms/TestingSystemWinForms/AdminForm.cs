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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            //prevent form closing and hide it instead
            this.FormClosing += ((s, ev) =>
                {
                    ev.Cancel = true;
                    this.Hide();
                });
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
