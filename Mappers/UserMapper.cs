using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace CentralApplication.Mappers
{
    public class UserMapper: ClassMap<Entities.User>
    {
        public UserMapper()
        {
            Id(x => x.Id);
            Map(x => x.Firstname).Not.Nullable();
            Map(x => x.Lastname).Not.Nullable();
            Map(x => x.Middlename);

            HasOne(s => s.UserCredential).Constrained().Cascade.All();

            Table("user_info");
        }
    }
}
