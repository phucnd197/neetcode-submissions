public class Solution {
    public int HammingWeight(uint n) {
        var result = 0;
        for (var i = 0; i < 32; i++) {
            var bit = (n >> i) & 1;
            if (bit == 1) {
                result++;
            }
        }
        return result;
    }
}
