using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Models;
using System.Collections.Generic;

namespace PromotionEngine.UnitTests
{
    [TestClass]
    public class PromotionEngineTests
    {
        public OrderProcessor orderProcessor;

        [TestInitialize]
        public void TestInitialize()
        {
            orderProcessor = new OrderProcessor();
        }

        [TestMethod]
        public void PromotionEngineTests_Scenario1()
        {
            decimal expectedValue = 100;

            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("B"), new Product("C") });

            decimal totalOrderValue = orderProcessor.GetTotalOrderValue(order);

            Assert.AreEqual(expectedValue, totalOrderValue);
        }

        [TestMethod]
        public void PromotionEngineTests_Scenario2()
        {
            decimal expectedValue = 370;

            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("B"), new Product("B"),
            new Product("B"),new Product("B"),new Product("B"),new Product("C")});

            decimal totalOrderValue = orderProcessor.GetTotalOrderValue(order);

            Assert.AreEqual(expectedValue, totalOrderValue);
        }

        [TestMethod]
        public void PromotionEngineTests_Scenario3()
        {
            decimal expectedValue = 280;

            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("B"), new Product("B"),
            new Product("B"),new Product("B"),new Product("B"),new Product("C"), new Product("D")});

            decimal totalOrderValue = orderProcessor.GetTotalOrderValue(order);

            Assert.AreEqual(expectedValue, totalOrderValue);
        }
    }
}
