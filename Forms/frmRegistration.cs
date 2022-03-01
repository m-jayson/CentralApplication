using CentralApplication.Classes;
using CentralApplication.Entities;
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
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            string[] columns = new string [] { "Transaction Id", "Document Type","Booklet" };

            var group1 = new ListViewGroup("test group1");
            var group2 = new ListViewGroup("test group2");

            lvRecord.Groups.Add(group1);
            lvRecord.Groups.Add(group2);


            //create columns
            foreach (var col in columns)
            {
                lvRecord.Columns.Add(col);
            }

            ListViewItem item1 = new ListViewItem("item1", group1);
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            ListViewItem item2 = new ListViewItem("item2", group1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            item2.SubItems.Add("6");
            ListViewItem item3 = new ListViewItem("item3", group2);
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");
            item3.SubItems.Add("9");

            //add items to the listview
            lvRecord.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
            lvRecord.View = View.Details;
            lvRecord.MultiSelect = false;
            lvRecord.FullRowSelect = true;
            lvRecord.GridLines = true;
            lvRecord.Sorting = SortOrder.Ascending;
            lvRecord.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
