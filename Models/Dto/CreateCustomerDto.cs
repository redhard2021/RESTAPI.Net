using System.ComponentModel.DataAnnotations;

namespace CustomersApi.Models
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "Name field is required, please complete it and try again")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email field is required, please complete it and try again")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone field is required, please complete it and try again")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address field is required, please complete it and try again")]
        public string Address { get; set; }

    }
}