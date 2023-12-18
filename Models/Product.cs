
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public float Price { get; set; }
        public string? Color { get; set; }
        public byte[]? Image { get; set; }
        public int? Rating { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductType? ProductType { get; set; }
    }
}
