using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentralApplication.Forms
{
    public partial class frmApproval : Form
    {
        public frmApproval()
        {
            InitializeComponent();
        }

        private void frmApproval_Load(object sender, EventArgs e)
        {

        }

        public void loadData()
        {
            MessageBox.Show("Refreshing Data from approval");
        }
    }
}
