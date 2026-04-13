namespace DIAdvanced
{
    public class Customer
    {
        public long MobileNo { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Order> Orders { get; set; } = [];
    }
}
