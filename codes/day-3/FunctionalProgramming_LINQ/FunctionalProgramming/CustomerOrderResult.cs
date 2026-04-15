using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalProgramming
{
    public class CustomerOrderResult
    {
        public required string CustomerName { get; set; }
        public double? TotalOrder { get; set; }
        public DateTime OrderPlacedOn { get; set; }
    }
}
