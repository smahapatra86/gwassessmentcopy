using Application.DTO;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : BaseService
    {
        public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<AddCustomerResponse> AddNewAsync(AddCustomerRequest request)
        {
            var address = new Domain.ValueObjects.Address
            {
                Area = request.Address.Area,
                StreetName = request.Address.StreetName,
                City = request.Address.City,
                State = request.Address.State,
                HouseNo = request.Address.HouseNo,
                Pin = request.Address.Pin
            };

            var customer = new Customer(name: request.Name,
                dateOfBirth: request.DateOfBirth,
                dateOfRegistration: DateTimeOffset.MaxValue.UtcDateTime
                //, documentNames: request.Documents,
                //address: address
                );

            var repository = UnitOfWork.AsyncRepository<Customer>();
            await repository.AddEntity(customer).ConfigureAwait(false);
            await UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
            var addCustomerResponse = new AddCustomerResponse { Name = customer.Name };
            return addCustomerResponse;
        }
    }
}
