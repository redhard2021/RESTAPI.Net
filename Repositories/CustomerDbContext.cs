using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomersApi.Repositories
{
    public class CustomerDbContext : DbContext
    {
        private DbSet<CustomerEntity> customers { get; init; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }
        
        public async Task<List<CustomerEntity>> Get()
        {
            return await customers.ToListAsync();
        }

        public async Task<CustomerEntity> Get(long id)
        {
            return await customers.SingleOrDefaultAsync(x => x.Id == id) ?? throw new InvalidOperationException();
        }

        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        {
            CustomerEntity entity = new CustomerEntity()
            {
                Id = 15,
                Name = customerDto.Name,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Address = customerDto.Address,
            };

            //EntityEntry<CustomerEntity> resp = await customers.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
            //return await Get(resp.Entity.Id ?? throw new Exception("Error on save new customer"));
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