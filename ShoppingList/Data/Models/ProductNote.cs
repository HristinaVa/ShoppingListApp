using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Data.Models
{
    [Comment("Product Note")]
    public class ProductNote
    {
        [Key]
        [Comment("Note identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [Comment("Note Content")]
        public string Content { get; set; } = string.Empty;
        [Required]
        [Comment("Product Identifier")]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
