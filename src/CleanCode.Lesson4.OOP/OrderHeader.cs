using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Lesson4.OOP
{
    public struct OrderHeader
    {
        public string Id { get; }
        public string Description { get; }

        public OrderHeader(string id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
