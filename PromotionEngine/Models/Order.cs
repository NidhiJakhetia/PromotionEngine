using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }

        public Order(int _orderId, List<Product> _products)
        {
            this.OrderId = _orderId;
            this.Products = _products;
        }
    }
}
