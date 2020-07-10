using PromotionEngine.Models;
using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    class Program
    {
        public static void Main(string[] args)
        {
            OrderProcessor orderProcessor = new OrderProcessor();

            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("B"), new Product("C") });

            decimal totalOrderValue = orderProcessor.GetTotalOrderValue(order);

            Console.WriteLine(totalOrderValue);
        }
    }
}
