namespace MapperApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           ProductEntity productEntity = new ProductEntity
           {
               Id = 1,
               Name = "Dell XPS 15",
               Price = 1200000,
               Description = "A high-performance 15 inch laptop from dell"
           };
            
            Mapper mapper = new Mapper();
            //productEntity => source object
            //Map<ProductDto> => destination object
            //ProductDto dto =  mapper.Map<ProductDto>(productEntity);
            //Console.WriteLine($"Id: {dto.Id}, Name: {dto.Name}, Price: {dto.Price}, Description: {dto.Description}");
        }
    }
}
