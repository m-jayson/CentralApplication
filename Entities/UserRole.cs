using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralApplication.Entities
{
    public class UserRole
    {
        public virtual int Id { get; set; }
        public virtual Role Role { get; set; }

    }
}
