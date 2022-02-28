using CentralApplication.Classes;
using CentralApplication.Entities;
using CentralApplication.Entities.Enumerations;
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
    public partial class frmRegistration_AE : Form
    {
        long id;
        User user;
        FormStatus formStatus;

        public frmRegistration_AE(User user,FormStatus formStatus,long id)
        {
            InitializeComponent();

            this.id = id;
            this.user = user;
            this.formStatus = formStatus;
        }

        private void frmRegistration_AE_Load(object sender, EventArgs e)
        {

        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var bookletCount = Convert.ToInt32(this.txtBookletCount.Value);
            var partitionCount = 50;
            var registration= new Registration();
            var message = "";
            var icon = SystemIcons.Information;

            try
            {
                using (var _session = SessionFactory.OpenSession)
                {
                    using (var _transaction = _session.BeginTransaction())
                    {
                        var tmpStartingIndex = 0;
                        var documents = Enumerable.Range(1, bookletCount)
                                        .Select(i =>
                                        {
                                            var document =  new Document()
                                            {
                                                Registration = registration,
                                                SequenceFrom = tmpStartingIndex + 1,
                                                SequenceTo = tmpStartingIndex + partitionCount
                                            };

                                            tmpStartingIndex = document.SequenceTo;
                                            return document;
                                        }
                                        ).ToList();

                        registration.BookletCount = bookletCount;
                        registration.Documents = documents;
                        registration.CompanyType = CompanyType.COSMOS;
                        registration.DocumentType = rbLPA.Checked ? DocumentType.LPA : DocumentType.PR;
                        registration.User = this.user;

                        _session.Save(registration);
                        _transaction.Commit();
                    }
                }
                message += "Registration Added.\nPlease refresh your list.";
            }catch(Exception ex)
            {
                message += ex.Message;
                icon = SystemIcons.Exclamation;
            }
            Cursor.Current = Cursors.Default;
            MdiHelper.showNotification(message, "Registration Notification", icon);
            this.Close();
        }
    }
}
