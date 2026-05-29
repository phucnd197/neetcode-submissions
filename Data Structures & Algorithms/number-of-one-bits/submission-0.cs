public class Solution {
    public int HammingWeight(uint n) {
        if (n == 0) {
            return 0;
        }
        var result = 0;
        while (n > 0) {
            uint left = 0;
            uint right = 32;
            uint mid = 32;
            while (left <= right) {
                var temp = (left + right) / 2;
                var exponential = Math.Pow(2, temp);
                if (exponential > n) {
                    right = temp - 1;
                } else if (exponential < n) {
                    mid = temp;
                    left = temp + 1;
                } else {
                    mid = temp;
                    break;
                }
            }
            n -= (uint)Math.Pow(2, mid);
            result++;
        }
        return result;
    }
}
