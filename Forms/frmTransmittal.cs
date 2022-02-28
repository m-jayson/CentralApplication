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
    public partial class frmTransmittal : Form
    {
        public frmTransmittal()
        {
            InitializeComponent();
        }

        private void frmTransmittal_Load(object sender, EventArgs e)
        {

        }

        public void loadData()
        {
            MessageBox.Show("Refreshing Data from transmittal");
        }
    }
}
