using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Lesson4.OOP
{
    public class Ledger
    {
        private readonly List<Order> _orders;
        public Ledger()
        {
            _orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }
        public void RemoveOrder(string id)
        {
            var order = Get(id);
            if (order != null)
                _orders.Remove(order);
        }

        public IEnumerable<Order> Get()
        {
            return _orders;
        }
        public Order Get(string id)
        {
            return _orders.FirstOrDefault(o => o.Header.Id == id);
        }
    }
}
