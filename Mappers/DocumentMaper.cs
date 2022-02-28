using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace CentralApplication.Mappers
{
    public class DocumentMapper : ClassMap<Entities.Document>
    {
        public DocumentMapper()
        {
            Id(x => x.Id);
            Map(x => x.SequenceFrom).Not.Nullable();
            Map(x => x.SequenceTo).Not.Nullable();

            References(s => s.Registration);

            Table("document");
        }
    }
}