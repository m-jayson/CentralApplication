using CentralApplication.Entities;
using CentralApplication.Entities.Enumerations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CentralApplication.Classes
{
    public sealed class MdiHelper
    {

        private static MdiHelper instance = null;
        private static readonly object xLock = new object ();

        private mdiMain parentForm;
        private Form activeChild;
        private List<ToolStripItem> allItems = new List<ToolStripItem>();

        public mdiMain ParentForm { get => parentForm; set => parentForm = value; }
        public Form ActiveChild { get => activeChild; set => activeChild = value; }

        private MdiHelper() 
        {
            parentForm = new mdiMain();
            toolbarButtons();

            var menuStrip = parentForm.menuStripControl();
            foreach (ToolStripItem toolItem in menuStrip.Items)
            {
                allItems.Add(toolItem);
                //add sub items
                allItems.AddRange(GetItems(toolItem));
            }

            IEnumerable<ToolStripItem> GetItems(ToolStripItem item)
            {
                if (item is ToolStripMenuItem)
                {
                    foreach (ToolStripItem tsi in (item as ToolStripMenuItem).DropDownItems)
                    {
                        if (tsi is ToolStripMenuItem)
                        {
                            if ((tsi as ToolStripMenuItem).HasDropDownItems)
                            {
                                foreach (ToolStripItem subItem in GetItems((tsi as ToolStripMenuItem)))
                                    yield return subItem;
                            }
                            yield return (tsi as ToolStripMenuItem);
                        }
                        else if (tsi is ToolStripSeparator)
                        {
                            yield return (tsi as ToolStripSeparator);
                        }
                    }
                }
                else if (item is ToolStripSeparator)
                {
                    yield return (item as ToolStripSeparator);
                }
            }
        }

        public static MdiHelper Instance()
        {
            lock (xLock)
            {
                if (instance == null)
                {
                    instance = new MdiHelper();
                }

                return instance;
            }
        }


        private void toolbarButtons(bool isAdd = false,bool isEdit = false, bool isDelete = false, bool isRefresh = false)
        {
            mdiMain main = parentForm;
            var toolStrip = main.toolStripControl();
            var actionToolStrip = main.actionStripControl();

            toolStrip.Items[1].Visible = true; //start separator
            toolStrip.Items[2].Visible = isAdd; //add
            toolStrip.Items[3].Visible = isEdit; //edit
            toolStrip.Items[4].Visible = isDelete; //delete
            toolStrip.Items[5].Visible = isDelete  || isRefresh; //end separator
            toolStrip.Items[6].Visible = isRefresh;

            actionToolStrip.Visible = isAdd || isEdit || isDelete || isRefresh;

            actionToolStrip.DropDownItems[0].Visible = isAdd;
            actionToolStrip.DropDownItems[1].Visible = isEdit;
            actionToolStrip.DropDownItems[2].Visible = isDelete;
            actionToolStrip.DropDownItems[3].Visible = isDelete;
            actionToolStrip.DropDownItems[4].Visible = isRefresh;
            actionToolStrip.DropDownItems[5].Visible = isRefresh;
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
            var currentUser = new User() { Id = 1, Firstname = "Jayson" };

            var assembly = Assembly.GetExecutingAssembly();
            var tag = instance.activeChild.Tag.ToString();
            var formName = "CentralApplication.Forms.frm" + tag + "_AE";

            var type = assembly.GetType(formName);
            var ci = type.GetConstructor(new Type[3] { typeof(User),typeof(FormStatus),typeof(long) });
            var argVals = new object[] { currentUser,id <=0 ? FormStatus.FORM_ADD : FormStatus.FORM_EDIT,id }; 

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

        public static void refreshChildRecord()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var childForm = instance.activeChild;
            var childFormName = "CentralApplication.Forms." + childForm.Name;
            var childFormType = assembly.GetType(childFormName);

            MethodInfo methodInfo = childFormType.GetMethod("loadData");
            methodInfo.Invoke(childForm, null);
        }

        public static void showNotification(string text, string title,Icon systemIcons)
        {
            var notifyIcon = instance.parentForm.notifyIconControl();
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipText = text;
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.Icon = systemIcons;
            notifyIcon.ShowBalloonTip(1000);
        }
    }
}
