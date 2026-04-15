namespace FunctionalProgramming
{
    public class Order
    {
        //primary key property
        public int OrderId { get; set; }

        public double OrderAmount { get; set; } = 0;
        public required DateTime OrderDate { get; set; }

        //foreign key property
        public required long CustomerMobileNo { get; set; }

        //navigation property (for 1 to 1 relationship)
        public Customer? Customer { get; set; }
    }
}
