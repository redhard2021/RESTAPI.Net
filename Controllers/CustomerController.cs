using CustomersApi.Models;
using Microsoft.AspNetCore.Mvc;
using CustomersApi.Repositories;

namespace CustomersApi.Controllers
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController : Controller
    {
        private readonly CustomerDbContext dbContext;

        public CustomerController(CustomerDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            List<CustomerEntity> customers = await dbContext.Get();
            return new OkObjectResult(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(long id)
        {
            CustomerEntity customer = await dbContext.Get(id);
            return new OkObjectResult(customer);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCustomer(long id)
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