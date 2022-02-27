using CentralApplication.Classes;
using CentralApplication.Forms;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CentralApplication
{
    public partial class mdiMain : Form
    {
        ArrayList childWindows = new ArrayList();

        public mdiMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var login = new frmLogin();
            login.ShowDialog();
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildFormHelper.loadChild(new frmRegistration(), this);
        }
    }
}
