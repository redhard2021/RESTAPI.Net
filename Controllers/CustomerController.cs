using CustomersApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomersApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : Controller
    {

        [HttpGet]
        public async Task<CustomerDto> GetCustomers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<CustomerDto> GetCustomerById(long _id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCustomer(long _id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<CustomerDto> CreateCustomer(CreateCustomerDto customer)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<CustomerDto> UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }

    }
}
