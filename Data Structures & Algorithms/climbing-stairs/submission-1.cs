public class Solution {
    public int ClimbStairs(int n) {
        return ClimbStairs(n, new Dictionary<int, int>(n));
    }

    private int ClimbStairs(int n, Dictionary<int, int> memoize) {
        if (n <= 2) {
            return n;
        }
        if (memoize.TryGetValue(n, out var value)) {
            return value;
        }

        var result = ClimbStairs(n - 1, memoize) + ClimbStairs(n - 2, memoize);
        memoize[n] = result;
        return result;
    }
}
