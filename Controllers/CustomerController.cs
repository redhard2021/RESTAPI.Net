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

        public CustomerController(CustomerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomers()
        {
            List<CustomerEntity> customers = await dbContext.GetAll();
            return new OkObjectResult(customers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerById(long id)
        {
            CustomerEntity customer = await dbContext.Get(id);
            return new OkObjectResult(customer);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            CustomerEntity result = await dbContext.Delete(id);
            return new OkObjectResult(result.Name + " has been deleted");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customerDto)
        {
            CustomerEntity customer = await dbContext.Add(customerDto);
            return new CreatedResult($"https://localhost:7051/api/v1/customers/{customer.Id}", null);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<CustomerDto> UpdateCustomer(CustomerDto customer)
        {
            CustomerEntity customerUpdated = await dbContext.Update(customer);
            return customerUpdated.ToDto();
        }
    }
}