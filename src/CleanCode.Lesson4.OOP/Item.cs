using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Lesson4.OOP
{
    public struct Item
    {
        public string Id { get; }
        public String Description { get; set; }
        public decimal Price { get; set; }

        public Item(string id, string description, decimal price)
        {
            Id = id;
            Description = description;
            Price = price;
        }
    }
}
