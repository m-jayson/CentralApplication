using NHibernate.Event;
using NHibernate.Persister.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CentralApplication.Classes.EventListener
{
    public class AuditEventListener : IPreInsertEventListener
    {
        public bool OnPreInsert(PreInsertEvent @event)
        {
            var audit = @event.Entity as IHaveAuditInformation;
            if (audit == null)
                return false;

            var time = DateTime.Now;
            var user = UserStateHolder.CurrentUser();

            Set(@event.Persister, @event.State, "CreatedAt", time);
            Set(@event.Persister, @event.State, "UpdatedAt", time);
            Set(@event.Persister, @event.State, "CreatedBy", user);
            Set(@event.Persister, @event.State, "UpdatedBy", user);

            audit.CreatedAt = time;
            audit.CreatedBy = user;
            audit.UpdatedAt = time;
            audit.UpdatedBy = user;

            return false;
        }

        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }
    }
}
