using Siemns.DotNet.PmsApp.APIs.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Siemns.DotNet.PmsApp.APIs.Models.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="name is required")]
        [MaxLength(50,ErrorMessage ="product name should be 50 chars")]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, 10000)]        
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDTO? Category { get; set; }
    }
}
