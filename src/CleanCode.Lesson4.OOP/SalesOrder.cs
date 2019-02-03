using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Lesson4.OOP
{
    public class SalesOrder:Order
    {
        public SalesOrder(OrderHeader header) : base(header)
        {
        }

        public SalesOrder(string id, string description) : base(id, description)
        {
        }

        public override bool IsValid()
        {
            decimal sum = 0;
            Items.ForEach(i => sum += i.Price);

            return sum > 0;
        }
    }
}
