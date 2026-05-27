public class Solution {
    public int ClimbStairs(int n) {
        if (n <= 2) {
            return n;
        }

        var dp = new int[2];
        dp[0] = 1;
        dp[1] = 2;
        for (var i = 2; i < n; i++) {
            var temp = dp[1];
            dp[1] = dp[0] + dp[1];
            dp[0] = temp;
        }

        return dp[1];
    }
}
