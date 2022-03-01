using CentralApplication.Classes;
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

        /**
         * Method to find the latest seqence encoded
         */
        public static int findLastSequenceRegistered(DocumentType documentType)
        {
            using (var _session = SessionFactory.OpenSession)
            {
                var result = _session.Query<Registration>()
                                .Where(r => r.DocumentType == documentType)
                                .OrderByDescending(r => r.Id)
                                .FirstOrDefault();

                if (null == result) return 0;

                return result.Documents.Max(d => d.SequenceTo);
            }
        }
    }
}
