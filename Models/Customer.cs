using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Models
{
    public class Customer
    {
        [Required]
        public string NameSurname { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}