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
                totalPrice = Helper.NoPromoApplied(order, promotion, totalPrice);
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
                totalPrice = Helper.LeftSkuCalculation(order, promotion, totalPrice, count);
            }

            return totalPrice;
        }        
    }
}
