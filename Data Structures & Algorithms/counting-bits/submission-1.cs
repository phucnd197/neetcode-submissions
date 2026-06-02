public class Solution {
    public int[] CountBits(int n) {
        if (n == 0) {
            return [0];
        }
        var result = new int[n + 1];
        result[0] = 0;
        for (var i = 1; i <= n; i++) {
            for (var j = 0; j < 32; j++) {
                var bit = (i >> j) & 1;
                if (bit != 1) {
                    continue;
                }
                result[i]++;
            }
        }
        return result;
    }
}
