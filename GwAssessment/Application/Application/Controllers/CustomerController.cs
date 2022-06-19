using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<AddCustomerResponse>> Add([FromBody] AddCustomerRequest request)
        {
            var response = await customerService.AddNewAsync(request);
            if (response.IsError)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Message);
        }

        [HttpGet("{customerName}")]
        public async Task<ActionResult<GetCustomerResponse>> Get([FromRoute][Required] string customerName)
        {
            var response = await customerService.GetAsync(customerName);
            if (response.IsError)
            {
                return NotFound(response.Message);
            }

            return Ok(response.Customer);
        }
    }
}
