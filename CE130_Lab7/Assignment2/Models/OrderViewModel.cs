using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Please enter customer name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please select a product")]
        public int ProductId { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please enter delivery address")]
        [StringLength(200, MinimumLength = 10,
            ErrorMessage = "Address must be between 10 and 200 characters")]
        public string DeliveryAddress { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter pincode")]
        [RegularExpression(@"^[0-9]{6}$",
            ErrorMessage = "Pincode must contain exactly 6 digits")]
        public string Pincode { get; set; }
    }
}