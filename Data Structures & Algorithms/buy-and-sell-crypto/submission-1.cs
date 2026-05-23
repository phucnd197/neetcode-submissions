public class Solution {
    public int MaxProfit(int[] prices) {
        var maxProfit = 0;
        var sellPrice = 0;
        var buyPrice = Int32.MaxValue;
        for (var i = 0; i < prices.Length; i++) {
            var todayPrice = prices[i];
            if (sellPrice < prices[i]) {
                sellPrice = todayPrice;
            }
            if (buyPrice > todayPrice) {
                buyPrice = sellPrice = todayPrice;
            }
            var profit = sellPrice - buyPrice;
            if (profit > maxProfit) {
                maxProfit = profit;
            }
        }

        return maxProfit;
    }
}
