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
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();

            //prevent form closing and hide it instead
            this.FormClosing += ((s, ev) =>
            {
                ev.Cancel = true;
                this.Hide();
            });
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
