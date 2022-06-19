using System;
using System.Collections.Generic;

namespace Application.DTO
{
    public class GetCustomerResponse
    {
        public CustomerDTO Customer { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
    }

    public class CustomerDTO
    {
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public DateTimeOffset DateOfRegistration { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public List<string> Documents { get; set; }
    }
}
