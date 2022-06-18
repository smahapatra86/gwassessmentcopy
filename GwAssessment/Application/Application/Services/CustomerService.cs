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
            var address = request.Address?.HouseNo + " "
                + request.Address?.StreetName + " "
                + request.Address?.Area + " "
                + request.Address?.City + " "
                + request.Address?.State + " "
                + request.Address?.Pin;

            var customer = new Customer(name: request.Name,
                dateOfBirth: request.DateOfBirth,
                dateOfRegistration: DateTimeOffset.MaxValue.UtcDateTime,
                //, documentNames: request.Documents,
                address: address
                );

            var repository = UnitOfWork.AsyncRepository<Customer>();
            await repository.AddEntity(customer).ConfigureAwait(false);
            await UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
            var addCustomerResponse = new AddCustomerResponse { Name = customer.Name };
            return addCustomerResponse;
        }
    }
}
