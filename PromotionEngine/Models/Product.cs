namespace PromotionEngine.Models
{
    public class Product
    {
        public string SkuId { get; set; }
        public decimal Price { get; set; }

        public Product(string skuId)
        {
            this.SkuId = skuId;
            switch (skuId)
            {
                case "A":
                    this.Price = 50m;
                    break;

                case "B":
                    this.Price = 30m;
                    break;

                case "C":
                    this.Price = 20m;
                    break;

                case "D":
                    this.Price = 15m;
                    break;
            }
        }
    }
}
