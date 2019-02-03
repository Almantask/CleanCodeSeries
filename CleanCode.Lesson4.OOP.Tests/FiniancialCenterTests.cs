using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace CleanCode.Lesson4.OOP.Tests
{
    public class FiniancialCenterTests
    {
        [Fact]
        public void Process_SalesOrdersOnly_Declined_Test()
        {
            var wallet = new Item("Wallet", "Common wallet", 15);
            var loan = new Item("Loan1", "It's a loan", -5000);

            var order = new SalesOrder("Order1", "Buying wallet with a loan");

            order.AddItem(wallet);
            order.AddItem(loan);

            var ledger = new Ledger();
            ledger.AddOrder(order);

            var orderProcessor = new Mock<IOrderProcessor>();
            orderProcessor.Setup(m => m.Accept(order));
            orderProcessor.Setup(m => m.Decline(order));
            
            var financialCenter = new FinancialCenter(orderProcessor.Object);
            financialCenter.Process(ledger);

            orderProcessor.Verify(m => m.Decline(order), Times.Once);
            orderProcessor.Verify(m => m.Accept(order), Times.Never);
        }

        [Fact]
        public void Process_SalesOrdersOnly_Accepted_Test()
        {
            var wallet = new Item("Wallet", "Common wallet", 15);
            var loan = new Item("Inheritence", "It's a loan", 5000);

            var order = new SalesOrder("Order1", "Buying wallet with a loan");

            order.AddItem(wallet);
            order.AddItem(loan);

            var ledger = new Ledger();
            ledger.AddOrder(order);

            var orderProcessor = new Mock<IOrderProcessor>();
            orderProcessor.Setup(m => m.Accept(order));
            orderProcessor.Setup(m => m.Decline(order));

            var financialCenter = new FinancialCenter(orderProcessor.Object);
            financialCenter.Process(ledger);

            orderProcessor.Verify(m => m.Decline(order), Times.Never);
            orderProcessor.Verify(m => m.Accept(order), Times.Once);
        }

        [Fact]
        public void Process_PurhcaseOrdersOnly_Accepted_Test()
        {
            var wallet = new Item("Wallet", "Common wallet", 15);
            var loan = new Item("Inheritence", "It's a loan", -5000);

            var order = new PurhcaseOrder("Order1", "Buying wallet with a loan");

            order.AddItem(wallet);
            order.AddItem(loan);

            var ledger = new Ledger();
            ledger.AddOrder(order);

            var orderProcessor = new Mock<IOrderProcessor>();
            orderProcessor.Setup(m => m.Accept(order));
            orderProcessor.Setup(m => m.Decline(order));

            var financialCenter = new FinancialCenter(orderProcessor.Object);
            financialCenter.Process(ledger);

            orderProcessor.Verify(m => m.Decline(order), Times.Never);
            orderProcessor.Verify(m => m.Accept(order), Times.Once);
        }

        [Fact]
        public void Process_PurchaseOrdersOnly_Declined_Test()
        {
            var wallet = new Item("Wallet", "Common wallet", 15);
            var loan = new Item("Inheritence", "It's a loan", 5000);

            var order = new PurhcaseOrder("Order1", "Buying wallet with a loan");

            order.AddItem(wallet);
            order.AddItem(loan);

            var ledger = new Ledger();
            ledger.AddOrder(order);

            var orderProcessor = new Mock<IOrderProcessor>();
            orderProcessor.Setup(m => m.Accept(order));
            orderProcessor.Setup(m => m.Decline(order));

            var financialCenter = new FinancialCenter(orderProcessor.Object);
            financialCenter.Process(ledger);

            orderProcessor.Verify(m => m.Decline(order), Times.Once);
            orderProcessor.Verify(m => m.Accept(order), Times.Never);
        }

        [Fact]
        public void AcceptAllOrders_Test()
        {
            var wallet = new Item("Wallet", "Common wallet", 15);
            var loan = new Item("loan", "It's a loan", -5000);
            var investment = new Item("Inheritence", "It's a loan", 5000);

            var orderPurchase = new PurhcaseOrder("Order1", "Buying wallet with a loan");
            var orderSales = new SalesOrder("Order1", "Buying wallet with a loan");

            orderPurchase.AddItem(wallet);
            orderPurchase.AddItem(loan);

            orderSales.AddItem(wallet);
            orderSales.AddItem(investment);

            var ledger = new Ledger();
            ledger.AddOrder(orderPurchase);
            ledger.AddOrder(orderSales);

            var orderProcessor = new Mock<IOrderProcessor>();
            orderProcessor.Setup(m => m.Accept(orderSales));
            orderProcessor.Setup(m => m.Decline(orderSales));

            var financialCenter = new FinancialCenter(orderProcessor.Object);
            financialCenter.Process(ledger);

            orderProcessor.Verify(m => m.Decline(orderSales), Times.Never);
            orderProcessor.Verify(m => m.Accept(orderSales), Times.Once);
            orderProcessor.Verify(m => m.Decline(orderPurchase), Times.Never);
            orderProcessor.Verify(m => m.Accept(orderPurchase), Times.Once);
        }

    }
}
