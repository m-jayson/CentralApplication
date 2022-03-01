using CentralApplication.Entities;
using System;

namespace CentralApplication.Classes.EventListener
{
    public abstract class IHaveAuditInformation
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
        public virtual User UpdatedBy { get; set; }
    }
}