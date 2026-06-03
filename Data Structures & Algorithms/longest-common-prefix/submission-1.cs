public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        var length = int.MaxValue;
        for (var i = 0; i < strs.Length; i++) {
            if (length > strs[i].Length) {
                length = strs[i].Length;
            }
        }
        var prefix = new StringBuilder(length);
        var index = 0;
        while (index < length) {
            var character = strs[0][index];
            for (var j = 0; j < strs.Length; j++) {
                if (strs[j][index] != character) {
                    return prefix.ToString();
                }
            }
            prefix.Append(character);
            index++;
        }
        return prefix.ToString();
    }
}