using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace CleanCode.Lesson4.OOP.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Adding_SingleItem_Test()
        {
            var wallet = new Item("Wallet", "Common wallet", 15);
            var loan = new Item("Loan1", "It's a loan", -5000);

            var order = new SalesOrder("Order1", "Buying wallet with a loan");

            order.AddItem(wallet);
            order.AddItem(loan);

            var itemCount = order.Get().Count();
            const int expectedCount = 2;
            Assert.Equal(expectedCount, itemCount);
        }
    }
}
