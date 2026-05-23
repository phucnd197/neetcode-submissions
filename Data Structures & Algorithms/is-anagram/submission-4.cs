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
        var word = new int[26];
        for (var i = 0; i < s.Length; i++) {
            var index = s[i] - 'a';
            word[index]++;

            index = t[i] - 'a';
            word[index]--;
        }
        for (var i = 0; i < word.Length; i++) {
            if (word[i] < 0) {
                return false;
            }
        }
        return true;
    }
}
