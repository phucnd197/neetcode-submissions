public class Solution {
    public uint ReverseBits(uint n) {
        uint result = 0;
        for (var i = 0; i < 32; i++) {
            uint bit = (n >> i) & 1;
            result += (bit << (31 - i));
        }
        return result;
    }
}
