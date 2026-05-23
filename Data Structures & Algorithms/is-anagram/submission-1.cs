public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s is null && t is not null) {
            return false;
        }
        if (s is not null && t is null) {
            return false;
        }
        if (s.Length != t.Length) {
            return false;
        }
        var word = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                               0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        for (var i = 0; i < s.Length; i++) {
            var index = s[i] - 'a';
            word[index] += 1;
        }
        for (var j = 0; j < t.Length; j++) {
            var index = t[j] - 'a';
            word[index] -= 1;
            if (word[index] < 0) {
                return false;
            }
        }
        return true;
    }
}
