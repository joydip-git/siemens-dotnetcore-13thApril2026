namespace MapperApp
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double? Price { get; set; }
        public string? Description { get; set; }
    }
}
