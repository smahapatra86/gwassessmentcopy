using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Under development");
        }
    }
}
