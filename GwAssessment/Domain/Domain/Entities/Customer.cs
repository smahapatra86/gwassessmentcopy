using Domain.Base;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Customer : BaseEntity
    {
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public DateTimeOffset DateOfRegistration { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public List<Document> Documents { get; set; }

    }
}
