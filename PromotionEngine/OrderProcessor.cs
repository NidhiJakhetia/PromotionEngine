using PromotionEngine.Models;
using PromotionEngine.PromotionCheckerModule;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class OrderProcessor
    {
        public decimal GetTotalOrderValue(Order order)
        {
            PromotionChecker promotionChecker = new PromotionChecker();

            IList<Promotion> promotions = ActivePromotions.GetActivePromotions(); //will get the list of Active promotions

            List<decimal> promoprices = promotions
                    .Select(promo => promotionChecker.GetTotalPrice(order, promo))
                    .ToList();
            decimal promoprice = promoprices.Sum();
            return promoprice;
        }
    }
}
