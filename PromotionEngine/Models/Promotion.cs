using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public Dictionary<string, int> ProductInfo { get; set; }
        public decimal PromoPrice { get; set; }

        public Promotion(int _promotionId, Dictionary<string, int> _productInfo, decimal _promoprice)
        {
            this.PromotionId = _promotionId;
            this.ProductInfo = _productInfo;
            this.PromoPrice = _promoprice;
        }
    }
}
