using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Lesson4.OOP
{
    public class BasicOrderProcessor:IOrderProcessor
    {
        public void Accept(Order order)
        {
            Console.WriteLine($"{order.Header.Id} was accepted");
        }

        public void Decline(Order order)
        {
            Console.WriteLine($"{order.Header.Id} was declined");
        }
    }
}
