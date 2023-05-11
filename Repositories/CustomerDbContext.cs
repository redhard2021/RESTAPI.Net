using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomersApi.Repositories
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; init; } = null!;

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public async Task<List<CustomerEntity>> GetAll()
        {
            return await Customers.ToListAsync();
        }

        public async Task<CustomerEntity> Get(long id)
        {
            return await Customers.SingleOrDefaultAsync(x => x.Id == id) ?? throw new InvalidOperationException();
        }

        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        {
            CustomerEntity entity = new CustomerEntity()
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Address = customerDto.Address,
            };

            EntityEntry<CustomerEntity> resp = await Customers.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(resp.Entity.Id);
        }

        public async Task<CustomerEntity> Delete(long id)
        {
            CustomerEntity customer = await Get(id);
            Customers.Remove(customer);
            SaveChanges();
            return customer;
        }

        public async Task<CustomerEntity> Update(CustomerDto dto)
        {
            CustomerEntity newCustomerEntity = new CustomerEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address
            };

            Customers.Update(newCustomerEntity);
            await SaveChangesAsync();
            return newCustomerEntity;
        }
    }

}