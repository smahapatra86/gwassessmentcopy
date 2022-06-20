using Domain.Base;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Document : BaseEntity
    {
        public string DocumentName { get; set; }
        public virtual Guid CustomerId { get; set; }
    }
}
