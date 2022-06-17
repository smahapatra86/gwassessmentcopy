using Domain.Base;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public DateTimeOffset DateOfRegistration { get; set; }
        public bool IsActive { get; set; }
        //public IList<Document> Documents { get; set; }
        //public Address Address { get; set; }

        public Customer(string name,
            DateTimeOffset dateOfBirth,
            DateTimeOffset dateOfRegistration
            //,            IList<string> documentNames,
            //Address address
            )
        {
            this.Name = name;
            DateOfBirth = dateOfBirth;
            DateOfRegistration = dateOfRegistration;
            IsActive = true;
            //Address = address;
            //foreach (var item in documentNames)
            //{
            //    this.AddDocument(item);
            //}
        }

        //public void AddDocument(string documentName)
        //{
        //    if (Documents != null)
        //    {
        //        Documents.Add(new Document(documentName));
        //    }
        //    else
        //    {
        //        var document = new Document(documentName);
        //        Documents = new List<Document> { document };
        //    }
        //}
    }
}
