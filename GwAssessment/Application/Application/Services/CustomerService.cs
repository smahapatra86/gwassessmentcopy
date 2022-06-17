using Application.DTO;
using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : BaseService
    {
        public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<AddCustomerResponse> AddNewAsync(AddCustomerRequest request)
        {
            var customer = new Customer(name: request.Name);
            var repository = UnitOfWork.AsyncRepository<Customer>();
            await repository.AddEntity(customer).ConfigureAwait(false);
            await UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
            var addCustomerResponse = new AddCustomerResponse { Name = customer.Name };
            return addCustomerResponse;
        }
    }
}
