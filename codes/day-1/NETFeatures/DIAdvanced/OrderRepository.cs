
namespace DIAdvanced
{
    public class OrderRepository : IRepository<Order>
    {
        public ICollection<Order> GetAll()
        {
            return [
                new Order {
                    Customer= new Customer
                    {
                        Name = "joydip", MobileNo = 9090909090
                    },
                    OrderAmount=1000,
                    OrderDate=DateTime.Now,
                    OrderId=100
                }
            ];
        }
    }
}
