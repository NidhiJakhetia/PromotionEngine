using PromotionEngine.Models;
using System;
using System.Collections.Generic;

namespace PromotionEngine.PromotionCheckerModule
{
    public static class ActivePromotions
    {
        public static IList<Promotion> GetActivePromotions()
        {
            Dictionary<String, int> promotion1 = new Dictionary<String, int>();
            promotion1.Add("A", 3);

            Dictionary<String, int> promotion2 = new Dictionary<String, int>();
            promotion2.Add("B", 2);

            Dictionary<String, int> promotion33 = new Dictionary<String, int>();
            promotion33.Add("C", 1);
            promotion33.Add("D", 1);

            IList<Promotion> activePromotions = new List<Promotion>()
            {
                new Promotion(1, promotion1, 130),
                new Promotion(2, promotion2, 45),
                new Promotion(3, promotion33, 30)
            };

            return activePromotions;
        }
    }
}
