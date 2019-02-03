using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Lesson4.OOP
{
    public class FinancialCenter
    {
        private IOrderProcessor _orderProcessor;

        public FinancialCenter(IOrderProcessor orderProcessor)
        {
            _orderProcessor = orderProcessor;
        }

        public void Process(Ledger ledger)
        {
            var orders = ledger.Get();
            foreach (var order in orders)
            {
                if(order.IsValid())
                    _orderProcessor.Accept(order);
                else
                    _orderProcessor.Decline(order);
            }
        }
    }
}
