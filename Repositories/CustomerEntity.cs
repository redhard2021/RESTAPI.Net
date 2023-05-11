using CustomersApi.Models;

namespace CustomersApi.Repositories;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("customers")]
public class CustomerEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

    public CustomerDto ToDto()
    {
        return new CustomerDto
        {
            Id = Id,
            Name = Name,
            Email = Email,
            Phone = Phone,
            Address = Address
        };
    }
}