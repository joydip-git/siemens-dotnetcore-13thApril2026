using System.Runtime.CompilerServices;

namespace FunctionalProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];

            //method syntax
            //delayed execution
            var result = numbers
                .OrderByDescending(num => num)
                .Where(num => num % 2 == 0)
                .Select(num => num * 5)
                .Take(3);


            result
                .ToList<int>()
                .ForEach((num) => Console.WriteLine(num));

            var avg = result.Average();

            //query syntax
            //deferred or delayed execution
            var query = from num in numbers
                        orderby num descending
                        where num % 2 == 0
                        select num * 5;

            //query.ToList<int>().ForEach((num) => Console.WriteLine(num));
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            List<string> names = ["anil", "sunil", "joydip", "mahesh", "suresh", "amit"];

            //immediate execution
            names
                .OrderByDescending(name => name)
                .Where(name => name.ToLower().Contains('n'))
                .Select(name => $"Mr./Mrs. {name}")
                .Take(3)
                .ToList<string>()
                .ForEach(name => Console.WriteLine(name));

            IEnumerable<IGrouping<char, string>> groupQuery = from name in names
                                                              orderby name ascending
                                                              group name by name[0];

            IEnumerable<IGrouping<char, string>> groupMethod =
                names
                .OrderBy(name => name)
                .GroupBy(name => name[0]);

            Console.WriteLine("\n\nGroup Method query result\n\n");
            foreach (IGrouping<char, string> group in groupQuery)
            {
                Console.WriteLine($"Group starting with letter {group.Key}");
                foreach (string groupElement in group)
                {
                    Console.WriteLine(groupElement);
                }
                Console.WriteLine("\n");
            }
            */

            List<Customer> customers =
                [
                    new(){MobileNo=9090909090, Name="joydip"},
                    new(){MobileNo=9090909091, Name="anil"},
                    new(){MobileNo=9090909092, Name="sunil"}
                ];

            List<Order> orders =
                [
                    new(){CustomerMobileNo=9090909090, OrderId=100, OrderAmount=1000, OrderDate=new DateTime(2026,4,13)},
                    new(){CustomerMobileNo=9090909090, OrderId=101, OrderAmount=2000, OrderDate=new DateTime(2026,3,15)},
                    new(){CustomerMobileNo=9090909091, OrderId=102, OrderAmount=2300, OrderDate=DateTime.Now},
                ];

            //var joinQuery = from c in customers
            //                join o in orders
            //                on c.MobileNo equals o.CustomerMobileNo
            //                orderby c.Name ascending
            //                select new { CustomerName = c.Name, TotalOrder = o.OrderAmount, OrderPlacedOn = o.OrderDate };

            //customers => outer collection (table)
            //orders => inner collection (inner table)

            //outer-collection.Join(
            //inner-collection,
            //Func<in Customer,out PKeyOfCustomer>,
            //Func<in Order, out FKeyOfOrder,
            //Func<in Customer,in Order, out TResult>)
            IOrderedEnumerable<CustomerOrderResult> joinQuery =
                customers.Join(
                    orders,
                    c => c.MobileNo,
                    o => o.CustomerMobileNo,
                    (c, o) => new CustomerOrderResult { CustomerName = c.Name, TotalOrder = o.OrderAmount, OrderPlacedOn = o.OrderDate }
                    )
                .OrderBy(co => co.CustomerName);

            foreach (CustomerOrderResult item in joinQuery)
            {
                Console.WriteLine($"{item.CustomerName}, {item.TotalOrder}, {item.OrderPlacedOn:d}");
            }

            /*
             *  anil, 2300, 15-04-2026
                joydip, 1000, 13-04-2026
                joydip, 2000, 15-03-2026
             */

            //display name of every customer and total order placed. If there is no order for that customer, display the name of the customer anyway with total order amlount as 0
            /*
             *  anil   2300
                joydip 3000
                sunil   0
             */

            
        }
    }
}
