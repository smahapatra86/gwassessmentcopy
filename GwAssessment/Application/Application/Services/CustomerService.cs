using Application.DTO;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : BaseService
    {
        public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<AddCustomerResponse> AddNewAsync(AddCustomerRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<Customer>();
            //Check if customer already exists
            var customer = await repository.GetEntityAsync(o => o.Name == request.Name).ConfigureAwait(false);
            if (customer != null)
            {
                var addCustomerErrorResponse = new AddCustomerResponse { IsError = true, Message = "Customer is already registered" };
                return addCustomerErrorResponse;
            }

            var address = request.Address?.HouseNo + " "
                + request.Address?.StreetName + " "
                + request.Address?.Area + " "
                + request.Address?.City + " "
                + request.Address?.State + " "
                + request.Address?.Pin;

            customer = new Customer(name: request.Name,
                dateOfBirth: request.DateOfBirth,
                dateOfRegistration: DateTimeOffset.UtcNow,
                address: address,
                documentNames: request.Documents);

            await repository.AddEntity(customer).ConfigureAwait(false);
            await UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
            var addCustomerSuccessResponse = new AddCustomerResponse { IsError = false, Name = customer.Name, Message = "Customer registered successfully" };
            return addCustomerSuccessResponse;
        }

        public async Task<GetCustomerResponse> GetAsync(string name)
        {
            var repository = UnitOfWork.AsyncRepository<Customer>();
            //Check if customer already exists
            var customer = await repository.GetEntityAsync(o => o.Name == name).ConfigureAwait(false);
            if (customer == null)
            {
                var responseError = new GetCustomerResponse { IsError = true, Message = "Customer not found" };
                return responseError;
            }

            var documents = new List<string>();
            customer.Documents?.ForEach(o => documents.Add(o.DocumentName));
            var responseSuccess = new GetCustomerResponse
            {
                Customer = new CustomerDTO
                {
                    Name = customer.Name,
                    DateOfBirth = customer.DateOfBirth,
                    DateOfRegistration = customer.DateOfRegistration,
                    Address = customer.Address,
                    Documents = documents,
                    IsActive = customer.IsActive
                },
                IsError = false
            };
            return responseSuccess;
        }
    }
}
