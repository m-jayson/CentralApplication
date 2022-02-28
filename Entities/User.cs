using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralApplication.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Middlename { get; set; }

        public virtual UserCredential UserCredential { get; set; }
    }
}
