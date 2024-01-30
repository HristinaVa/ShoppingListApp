using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Data.Models
{
    [Comment("ShoppingList Product")]
    public class Product
    {
        [Key]
        [Comment("Product identifire")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public List<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}
