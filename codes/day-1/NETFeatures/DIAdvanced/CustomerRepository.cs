
namespace DIAdvanced
{
    public class CustomerRepository : IRepository<Customer>
    {
        public ICollection<Customer> GetAll()
        {
            return [new Customer { Name = "joydip", MobileNo = 9090909090 }];
        }
    }
}
