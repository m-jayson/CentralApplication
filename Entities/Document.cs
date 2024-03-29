﻿using CentralApplication.Classes.EventListener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralApplication.Entities
{
    public class Document : IHaveAuditInformation
    {
        public virtual int SequenceFrom { get; set; }
        public virtual int SequenceTo { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
