using CentralApplication.Classes.EventListener;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentralApplication.Classes
{
    public class DisplayerListView<T> where T: IHaveAuditInformation
    {
        private ListView lvRecord;
        private string[] columns;

        public DisplayerListView(ListView lvRecord, string[] columns)
        {
            this.lvRecord = lvRecord;
            this.columns = columns;
        }

        public void displayByRange(MonthCalendar monthCalendar, Action<ListViewItem, T> action)
        {
            var StartDate = monthCalendar.SelectionRange.Start;
            var EndDate = monthCalendar.SelectionRange.End;

            var dateList = new List<ListViewGroup>();

            while (StartDate <= EndDate)
            {
                dateList.Add(new ListViewGroup(StartDate.ToString("MMMM dd,yyyy")));
                StartDate = StartDate.AddDays(1);
            }

            this.populateListView(dateList,action);
        }

        public void displayByCurrentDate(Action<ListViewItem, T> action)
        {
            ListViewGroup[] dateList = { new ListViewGroup(DateTime.Now.ToString("MMMM dd,yyyy")) };
            this.populateListView(dateList.ToList(), action);
        }

        private void populateListView(List<ListViewGroup> listViewGroups,Action<ListViewItem,T> action,bool isDisplayCreatedTime = true)
        {
            Cursor.Current = Cursors.WaitCursor;

            lvRecord.Clear();
            lvRecord.View = View.Details;
            lvRecord.MultiSelect = false;
            lvRecord.FullRowSelect = true;
            lvRecord.GridLines = true;
            lvRecord.Sorting = SortOrder.Ascending;
            lvRecord.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //add created time

            foreach (var col in columns)
            {
                lvRecord.Columns.Add(col);
            }

            if (isDisplayCreatedTime) lvRecord.Columns.Add("Created Time");

            foreach (var group in listViewGroups)
            {
                var dateTime = DateTime.ParseExact(group.Header.ToString(), "MMMM dd,yyyy", CultureInfo.InvariantCulture);
                using (var _session = SessionFactory.OpenSession)
                {
                    var list = _session.Query<T>()
                        .Where(x => x.CreatedAt.Date == dateTime)
                        .ToList();

                    foreach (T data in list)
                    {
                        var createdBy = data.CreatedBy;
                        var item = new ListViewItem(data.Id.ToString(), group);
                        item.Tag = data.Id;

                        action.Invoke(item, data);
                        item.SubItems.Add(createdBy.Lastname + " " + createdBy.Firstname);
                        item.SubItems.Add(data.CreatedAt.ToString("hh:mm tt"));

                        lvRecord.Items.Add(item);
                    }
                }

                lvRecord.Groups.Add(group);
            }

            Cursor.Current = Cursors.Default;
        }

    }
}
