using System;
using System.Collections.Generic;

namespace Application.DTO
{
    public class AddCustomerRequest
    {
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Address Address { get; set; }
        public IList<string> Documents { get; set; }
    }

    public class Address
    {
        public string Area { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int HouseNo { get; set; }
        public long Pin { get; set; }
    }
}
