using CentralApplication.Classes;
using CentralApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            ListViewGroup[] list = { new ListViewGroup(DateTime.Now.ToString("MMMM dd,yyyy")) };
            fetchData(new List<ListViewGroup>(list));
        }

        public void fetchData(List<ListViewGroup> listViewGroups)
        {
            Cursor.Current = Cursors.WaitCursor;
            lvRecord.Clear();
            string[] columns = new string[] { "Transaction Id", "Document Type", "Booklet", "Added By" };

            //create columns
            foreach (var col in columns)
            {
                lvRecord.Columns.Add(col);
            }

            foreach (var group in listViewGroups)
            {
                var dateTime = DateTime.ParseExact(group.Header.ToString(), "MMMM dd,yyyy", CultureInfo.InvariantCulture);
                using (var _session = SessionFactory.OpenSession)
                {
                    var list = _session.Query<Registration>()
                        .Where(x => x.CreatedAt.Date == dateTime)
                        .ToList();

                    foreach (var data in list)
                    {
                        var item = new ListViewItem(data.Id.ToString(), group);
                        item.Tag = data.Id;
                        item.SubItems.Add(data.DocumentType.ToString());
                        item.SubItems.Add(data.BookletCount.ToString());
                        item.SubItems.Add(data.CreatedBy.Lastname.ToString());

                        lvRecord.Items.Add(item);
                    }
                }

                lvRecord.Groups.Add(group);
            }


            lvRecord.View = View.Details;
            lvRecord.MultiSelect = false;
            lvRecord.FullRowSelect = true;
            lvRecord.GridLines = true;
            lvRecord.Sorting = SortOrder.Ascending;
            lvRecord.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var StartDate = this.monthCalendar.SelectionRange.Start;
            var EndDate = this.monthCalendar.SelectionRange.End;

            var dateList = new List<ListViewGroup>();

            while (StartDate <= EndDate)
            {
                dateList.Add(new ListViewGroup(StartDate.ToString("MMMM dd,yyyy")));
                StartDate = StartDate.AddDays(1);
            }

            fetchData(dateList);
        }
    }
}
