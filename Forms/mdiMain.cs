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

        public mdiMain()
        {
            InitializeComponent();
        }

        public ToolStrip toolStripControl()
        {
            return this.toolStrip;
        }
        public MenuStrip menuStripControl()
        {
            return this.menuStrip;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var login = new frmLogin();
            login.ShowDialog();
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelperUtils.loadChild(new frmRegistration(),isDelete: false);
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelperUtils.loadChild(new frmRelease(), isDelete: false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            HelperUtils.loadModalAE();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            HelperUtils.loadModalAE(1);
        }

        private void approvalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelperUtils.loadChild(new frmApproval(), isAdd: false,isEdit:false,isDelete:false);
        }

        private void transmittalShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelperUtils.loadChild(new frmTransmittal(), isDelete: false);
        }
    }
}
