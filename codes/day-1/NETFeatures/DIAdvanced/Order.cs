namespace DIAdvanced
{
    public class Order
    {
        public int OrderId { get; set; }
        public double OrderAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public required Customer Customer { get; set; }
    }
}
