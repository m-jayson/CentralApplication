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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (var _session = SessionFactory.OpenSession)
            {
                var userResult = _session.Query<User>()
                   .Where(user => user.UserCredential.Username == txtUsername.Text)
                   .SingleOrDefault();

                Cursor.Current = Cursors.Default;
                if (userResult == null)
                {
                    MessageBox.Show("User not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if(userResult.UserCredential.Password != txtPassword.Text)
                    {
                        MessageBox.Show("Invalid Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                MdiHelper.showNotification($"Welcome {userResult.Firstname} {userResult.Lastname}", "Login Successfull",SystemIcons.Information );
                this.Close();
            }
        }
    }
}
