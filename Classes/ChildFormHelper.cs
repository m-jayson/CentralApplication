using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CentralApplication.Classes
{
    public class ChildFormHelper
    {
        public static void loadChild(Form form,Form mdiParent)
        {
            form.MdiParent = mdiParent;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }
    }
}
