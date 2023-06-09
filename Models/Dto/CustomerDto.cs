﻿using System.ComponentModel.DataAnnotations;

namespace CustomersApi.Models
{
    public class CustomerDto
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Name field is required")] 
        public string Name { get; set; }
        [Required(ErrorMessage = "Email field is required")] 
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
