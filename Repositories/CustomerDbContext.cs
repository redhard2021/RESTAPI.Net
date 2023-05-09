using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomersApi.Repositories
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<CustomerEntity> Customer { get; set; }

        public async Task<CustomerEntity> Get(long id)
        {
            return await Customer.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        {
            CustomerEntity entity = new CustomerEntity()
            {
                Id = null,
                Name = customerDto.Name,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Address = customerDto.Address,
            };

            EntityEntry<CustomerEntity> resp = await Customer.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(resp.Entity.Id ?? throw new Exception("Error on save new customer"));
        }
    }

    public class CustomerEntity
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}