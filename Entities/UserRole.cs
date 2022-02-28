using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralApplication.Entities
{
    public enum ModuleType
    {
        Registration = 1,
        Releasing = 2
    }

    public enum AccessType
    {
        CAN_ADD = 1,
        CAN_EDIT = 2
    }
    public class UserRole
    {
        public virtual int Id { get; set; }
        public virtual AccessType AccessType { get; set; }

        public virtual ModuleType ModuleType { get; set; }
    }
}
