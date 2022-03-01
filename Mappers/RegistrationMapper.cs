using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralApplication.Entities.Enumerations;
using FluentNHibernate.Mapping;

namespace CentralApplication.Mappers
{
    public class RegistrationMapper : ClassMap<Entities.Registration>
    {
        public RegistrationMapper()
        {
            Id(x => x.Id);
            Map(x => x.BookletCount).Not.Nullable();
            Map(o => o.CompanyType).CustomType<CompanyType>().Not.Nullable();
            Map(o => o.DocumentType).CustomType<DocumentType>().Not.Nullable();

            HasMany(x => x.Documents).Not.KeyNullable()
                .Inverse()
                .Cascade.All();

            HasOne(s => s.CreatedBy);
            HasOne(s => s.UpdatedBy);

            Map(x => x.CreatedAt).Not.Nullable();
            Map(x => x.UpdatedAt).Not.Nullable();

            Table("document_registration");
        }
    }
}