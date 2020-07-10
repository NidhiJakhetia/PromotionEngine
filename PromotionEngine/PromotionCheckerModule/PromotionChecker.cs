using PromotionEngine.Models;
using System.Linq;

namespace PromotionEngine.PromotionCheckerModule
{
    public class PromotionChecker
    {
        public decimal GetTotalPrice(Order order, Promotion promotion)
        {
            decimal totalPrice = 0M;

            //It will fetch the count of products eligible for promotion.
            int count = order.Products
                .GroupBy(x => x.SkuId)
                .Where(grp => promotion.ProductInfo.Any(y => grp.Key == y.Key && grp.Count() >= y.Value))
                .Select(grp => grp.Count())
                .Sum();

            if (count == 0)
            {
                totalPrice = NoPromoApplied(order, promotion, totalPrice);
                return totalPrice;
            }

            //It will fetch the count of products in promotion
            int promotedProductscount = promotion.ProductInfo.Sum(kvp => kvp.Value);

            while (count >= promotedProductscount)
            {
                totalPrice += promotion.PromoPrice;
                count -= promotedProductscount;
            }

            if (count != 0 && count < promotedProductscount)
            {
                totalPrice = LeftSkuCalculation(order, promotion, totalPrice, count);
            }

            return totalPrice;
        }

        private static decimal LeftSkuCalculation(Order ord, Promotion prom, decimal d, int copp)
        {
            var sku = ord.Products
                       .GroupBy(x => x.SkuId)
                       .Where(grp => prom.ProductInfo.Any(y => grp.Key == y.Key))
                       .Select(grp => grp.Key).FirstOrDefault();

            if (sku == "A")
            {
                int priceofA = 50;

                d = d + (copp * priceofA);
            }
            if (sku == "B")
            {
                int priceofB = 30;

                d = d + (copp * priceofB);
            }
            if (sku == "C")
            {
                int priceofC = 20;

                d = d + (copp * priceofC);
            }
            if (sku == "D")
            {
                int priceofD = 15;

                d = d + (copp * priceofD);
            }
            return d;
        }

        private static decimal NoPromoApplied(Order ord, Promotion prom, decimal d)
        {
            var sku = ord.Products
                       .GroupBy(x => x.SkuId)
                       .Where(grp => prom.ProductInfo.Any(y => grp.Key == y.Key))
                       .Select(grp => grp.Key).FirstOrDefault();

            if (sku == "A")
            {
                int counterofA = 0;
                int priceofA = 50;
                var listOfProducts = ord.Products;
                foreach (Product pr in listOfProducts)
                {
                    if (pr.SkuId == "A" || pr.SkuId == "a")
                    {
                        counterofA = counterofA + 1;
                    }
                }

                d = counterofA * priceofA;
            }

            if (sku == "B")
            {
                int counterofB = 0;
                int priceofB = 30;
                var listOfProducts = ord.Products;
                foreach (Product pr in listOfProducts)
                {
                    if (pr.SkuId == "B" || pr.SkuId == "b")
                    {
                        counterofB = counterofB + 1;
                    }
                }

                d = counterofB * priceofB;
            }

            if (sku == "C")
            {
                int counterofC = 0;
                int priceofC = 20;
                var listOfProducts = ord.Products;
                foreach (Product pr in listOfProducts)
                {
                    if (pr.SkuId == "C" || pr.SkuId == "c")
                    {
                        counterofC = counterofC + 1;
                    }
                }

                d = counterofC * priceofC;
            }

            if (sku == "D")
            {
                int counterofD = 0;
                int priceofD = 15;
                var listOfProducts = ord.Products;
                foreach (Product pr in listOfProducts)
                {
                    if (pr.SkuId == "D" || pr.SkuId == "d")
                    {
                        counterofD = counterofD + 1;
                    }
                }

                d = counterofD * priceofD;
            }

            return d;
        }
    }
}
