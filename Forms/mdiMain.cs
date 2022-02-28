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

        public ToolStripMenuItem actionStripControl()
        {
            return this.actionsToolStripMenuItem;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var login = new frmLogin();
            login.ShowDialog();
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            tsExit_Click(sender, e);
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiHelper.loadChild(new frmRegistration(),isDelete: false);
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiHelper.loadChild(new frmRelease(), isDelete: false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MdiHelper.loadModalAE();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MdiHelper.loadModalAE(1);
        }

        private void approvalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiHelper.loadChild(new frmApproval(), isAdd: false,isEdit:false,isDelete:false);
        }

        private void transmittalShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiHelper.loadChild(new frmTransmittal(), isDelete: false);
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            string message = "This will exit the system.\n\nDo you want to proceed?";
            string title = "Exit Application";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
               Application.Exit();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MdiHelper.refreshChildRecord();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsExit_Click(sender, e);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsDelete_Click(sender, e);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton4_Click(sender, e);
        }
    }
}
