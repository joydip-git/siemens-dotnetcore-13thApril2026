namespace FunctionalProgramming
{
    public class Customer
    {
        //primary key property
        public required long MobileNo { get; set; }
        public required string Name { get; set; }

        //navigation property (for 1 to Many relationship)
        public ICollection<Order> Orders { get; set; } = [];
    }
}
