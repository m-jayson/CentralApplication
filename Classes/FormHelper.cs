using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentralApplication.Classes
{
    class FormHelper<T>
    {
        public static bool formSave(T model, AbstractValidator<T> validator)
        {
            var results = validator.Validate(model);
            var message = "";
            var icon = SystemIcons.Information;

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    MdiHelper.showNotification($"{failure.ErrorMessage}", "Validation Error", SystemIcons.Exclamation);
                }
                return false;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (var _session = SessionFactory.OpenSession)
                {
                    using (var _transaction = _session.BeginTransaction())
                    {
                        _session.Save(model);
                        _transaction.Commit();
                    }
                }
                message += "Record has been saved.\nPlease refresh your list.";
            }
            catch(Exception ex)
            {
                message += ex.Message;
                icon = SystemIcons.Exclamation;
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            MdiHelper.showNotification(message, "System Notification", icon);
            return true;
        }
    }
}
