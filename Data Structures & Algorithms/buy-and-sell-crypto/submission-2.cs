public class Solution {
    public int MaxProfit(int[] prices) {
        var maxProfit = 0;
        var buyPrice = Int32.MaxValue;
        for (var i = 0; i < prices.Length; i++) {
            var todayPrice = prices[i];
            if (buyPrice > todayPrice) {
                buyPrice =  todayPrice;
            }
            var profit = todayPrice - buyPrice;
            if (profit > maxProfit) {
                maxProfit = profit;
            }
        }

        return maxProfit;
    }
}
