using CentralApplication.Classes;
using CentralApplication.Entities;
using CentralApplication.Entities.Enumerations;
using CentralApplication.Forms;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentralApplication
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var _session = SessionFactory.OpenSession)
            {
                using (var _transaction = _session.BeginTransaction())
                {

                    var user = new User();
                    var cred = new UserCredential();

                    cred.Username = "admin";
                    cred.Password = "pass";


                    var userRole = new UserRole();
                    userRole.ModuleType = ModuleType.Registration;
                    userRole.AccessType = AccessType.CAN_ADD;

                    cred.UserRole = new List<UserRole>();
                    cred.UserRole.Add(userRole);

                    user.Firstname = "Jayson";
                    user.Lastname = "Gonzaga";
                    user.Middlename = "Vargas";

                    user.UserCredential = cred;

                    _session.Save(user);
                    _transaction.Commit();
                }
            }

            var helper = MdiHelper.Instance();
            Application.Run(helper.ParentForm);
        }
    }
}
