using CentralApplication.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralApplication.Entities
{
    public class Registration
    {
        public virtual int Id { get; set; }
        public virtual int BookletCount { get; set; }

        public virtual IList<Document> Documents { get; set; }

        public virtual CompanyType CompanyType { get; set; }

        public virtual DocumentType DocumentType { get; set; }

        public virtual User User { get; set; }
    }
}
