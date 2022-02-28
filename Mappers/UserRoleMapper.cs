using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralApplication.Entities;
using FluentNHibernate.Mapping;

namespace CentralApplication.Mappers
{
    public class UserRoleMapper: ClassMap<Entities.UserRole>
    {
        public UserRoleMapper()
        {
            Id(x => x.Id);
            Map(o => o.ModuleType).CustomType<ModuleType>().Not.Nullable();
            Map(o => o.AccessType).CustomType<AccessType>().Not.Nullable();
            Table("user_roles");
        }
    }
}
