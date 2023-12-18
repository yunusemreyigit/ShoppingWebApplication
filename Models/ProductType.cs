using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
