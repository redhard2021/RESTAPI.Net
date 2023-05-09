using CustomersApi.Models;
using Microsoft.AspNetCore.Mvc;
using CustomersApi.Repositories;

namespace CustomersApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerDbContext dbContext;
        public CustomerController(CustomerDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<List<CustomerDto>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(long _id)
        {

            return new OkObjectResult(0);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCustomer(long _id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customerDto)
        {
            CustomerEntity customer = await dbContext.Add(customerDto);
            
            return new CreatedResult($"IDK", customer);
        }

        [HttpPut]
        public async Task<CustomerDto> UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }

    }
}
