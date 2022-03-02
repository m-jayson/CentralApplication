using CentralApplication.Classes;
using CentralApplication.Entities;
using System;
using System.Windows.Forms;

namespace CentralApplication.Forms
{
    public partial class frmRegistration : Form
    {
        private DisplayerListView<Registration> displayerList;
        private string[] columns = new string[] { "Transaction Id", "Document Type", "Booklet", "Added By" };
        
        //actual population of data
        private Action<ListViewItem, Registration> action = (item, data) => {
            item.SubItems.Add(data.DocumentType.ToString());
            item.SubItems.Add(data.BookletCount.ToString());
        };
        
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            this.displayerList = new DisplayerListView<Registration>(this.lvRecord, columns);
            loadData();
        }

        public void loadData()
        {
            this.displayerList.displayByCurrentDate(this.action);
        }

 
        private void button1_Click(object sender, EventArgs e)
        {
            this.displayerList.displayByRange(this.monthCalendar, this.action);
        }
    }
}
