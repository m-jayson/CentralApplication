using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace CentralApplication.Mappers
{
    public class UserCredentialMapper: ClassMap<Entities.UserCredential>
    {
        public UserCredentialMapper()
        {
            Id(x => x.Id);
            Map(x => x.Username).Not.Nullable();
            Map(x => x.Password).Not.Nullable();

            HasMany(x => x.UserRole).Not.KeyNullable().Cascade.All();

            Table("user_credential");
        }
    }
}
