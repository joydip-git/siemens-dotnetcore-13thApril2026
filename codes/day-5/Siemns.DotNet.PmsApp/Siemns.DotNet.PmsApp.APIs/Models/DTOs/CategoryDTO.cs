namespace Siemns.DotNet.PmsApp.APIs.Models.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<ProductDTO>? Products { get; set; }
    }
}
