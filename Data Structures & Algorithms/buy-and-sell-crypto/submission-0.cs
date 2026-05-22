public class Solution {
    public int MaxProfit(int[] prices) {
        var maxProfit = int.MinValue;
        var minSell = int.MaxValue;

        for(var i = 0; i < prices.Length; i++) {
            minSell = int.Min(prices[i], minSell);
            maxProfit = int.Max(maxProfit, prices[i] - minSell);
        }
        
        return maxProfit;
    }
}
