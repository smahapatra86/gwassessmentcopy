using Domain.Base;
using System;

namespace Domain.Entities
{
    public class Document : BaseEntity
    {
        public string DocumentName { get; set; }

        public Document(string documentName)
        {
            DocumentName = documentName;
        }
    }
}
