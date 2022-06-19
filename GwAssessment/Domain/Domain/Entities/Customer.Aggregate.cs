using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Customer
    {
        public Customer()
        {
        }
        public Customer(string name,
            DateTimeOffset dateOfBirth,
            DateTimeOffset dateOfRegistration,
            string address,
            IList<string> documentNames)
        {
            this.Name = name;
            DateOfBirth = dateOfBirth;
            DateOfRegistration = dateOfRegistration;
            IsActive = true;
            Address = address;
            foreach (var item in documentNames)
            {
                this.AddDocument(item);
            }
        }

        public void AddDocument(string documentName)
        {
            if (Documents != null)
            {
                Documents.Add(new Document(documentName));
            }
            else
            {
                var document = new Document(documentName);
                Documents = new List<Document> { document };
            }
        }
    }
}
