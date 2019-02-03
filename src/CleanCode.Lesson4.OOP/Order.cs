using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Lesson4.OOP
{
    public abstract class Order
    {
        public OrderHeader Header { get; }
        protected List<Item> Items { get; set; }

        protected Order(OrderHeader header)
        {
            Header = header;
            Items = new List<Item>();
        }

        protected Order(string id, string description)
        {
            Header = new OrderHeader(id, description);
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void RemoveItem(string id)
        {
            var item = Get(id);
            Items.Remove(item);
        }

        public Item Get(string id)
        {
            return Items.FirstOrDefault(i => i.Id == id);
        }

        public abstract bool IsValid();

        public IEnumerable<Item> Get()
        {
            return Items;
        }
    }

}
