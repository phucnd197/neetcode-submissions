public class Solution {
    public uint ReverseBits(uint n) {
        uint remainder = n;
        var prev = 31;
        uint result = 0;
        while (remainder > 0) {
            var start = 0;
            var end = prev;
            var mid = 0;
            while (start <= end) {
                var temp = (start + end) / 2;
                var value = (uint)Math.Pow(2, temp);
                if (value < remainder) {
                    start = temp + 1;
                    if (mid < temp) {
                        mid = temp;
                    }
                } else if (value > remainder) {
                    end = temp - 1;
                } else {
                    mid = temp;
                    break;
                }
            }

            result |= (uint)1 << (31 - mid);
            remainder -= (uint)Math.Pow(2, mid);
            prev = mid;
        }

        return result;
    }
}
