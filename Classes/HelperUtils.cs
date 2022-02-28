using CentralApplication.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CentralApplication.Classes
{
    public sealed class HelperUtils
    {

        private static HelperUtils instance = null;
        private static readonly object xLock = new object ();

        private mdiMain parentForm;
        private Form activeChild;
        private List<ToolStripMenuItem> allItems = new List<ToolStripMenuItem>();

        public mdiMain ParentForm { get => parentForm; set => parentForm = value; }
        public Form ActiveChild { get => activeChild; set => activeChild = value; }

        private HelperUtils() 
        {
            parentForm = new mdiMain();
            toolbarButtons();

            var menuStrip = parentForm.menuStripControl();
            foreach (ToolStripMenuItem toolItem in menuStrip.Items)
            {
                allItems.Add(toolItem);
                //add sub items
                allItems.AddRange(GetItems(toolItem));
            }

            IEnumerable<ToolStripMenuItem> GetItems(ToolStripMenuItem item)
            {
                foreach (ToolStripMenuItem dropDownItem in item.DropDownItems)
                {
                    if (dropDownItem.HasDropDownItems)
                    {
                        foreach (ToolStripMenuItem subItem in GetItems(dropDownItem))
                            yield return subItem;
                    }
                    yield return dropDownItem;
                }
            }
        }

        public static HelperUtils Instance()
        {
            lock (xLock)
            {
                if (instance == null)
                {
                    instance = new HelperUtils();
                }

                return instance;
            }
        }

        private void toolbarButtons(bool isAdd = false,bool isEdit = false, bool isDelete = false, bool isRefresh = false)
        {
            mdiMain main = parentForm;

            main.toolStripControl().Items[1].Visible = true; //start separator
            main.toolStripControl().Items[2].Visible = isAdd; //add
            main.toolStripControl().Items[3].Visible = isEdit; //edit
            main.toolStripControl().Items[4].Visible = isDelete; //delete
            main.toolStripControl().Items[5].Visible = isDelete  || isRefresh; //end separator
            main.toolStripControl().Items[6].Visible = isRefresh;
        }
        private void menuStrip(Form activeFormChild,bool isEnable = false)
        {
            string tag = activeFormChild.Tag.ToString();

            foreach(var toolTag in allItems)
            {
                var tg = toolTag.Tag;
                if (tg != null && tg.ToString() == tag)
                {
                    toolTag.Enabled = isEnable;
                    return;
                }
            }
        }

        private void form_unload(object sender, EventArgs e)
        {
            toolbarButtons(); //reset toolbar button
            instance.menuStrip(activeChild, true);
            activeChild = null; 
        }

        public static void loadModalAE(long id = -1)
        {
            var currentUser = new User() { Id = 1, Name = "Jayson" };

            var assembly = Assembly.GetExecutingAssembly();
            var tag = instance.activeChild.Tag.ToString();
            var formName = "CentralApplication.Forms.frm" + tag + "_AE";

            var type = assembly.GetType(formName);
            var ci = type.GetConstructor(new Type[2] { typeof(User),typeof(long) });
            var argVals = new object[] { currentUser,id }; 

            var frm = (Form) ci.Invoke(argVals);

            frm.Text = (id <= 0 ? "New" : "Update") + " " + tag;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;

            frm.ShowDialog();
        }

        public static void loadChild(Form childForm, bool isAdd = true, bool isEdit = true, bool isDelete = true)
        {
            lock (xLock)
            {
                if (instance == null)
                {
                    throw new Exception("Instance not defined");
                }


               //close all child form in the parent first
               foreach(Form frm in instance.ParentForm.MdiChildren)
                {
                    instance.menuStrip(frm, true);
                    frm.Dispose();
                    frm.Close();
                }

                instance.activeChild = childForm;
                instance.toolbarButtons(isAdd, isEdit, isDelete, true);
                instance.menuStrip(childForm);

                childForm.Closed += new EventHandler(instance.form_unload);
                childForm.MdiParent = instance.ParentForm;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();

            }
        }

    }
}
