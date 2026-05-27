public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if (ransomNote.Length > magazine.Length) {
            return false;
        }
        var words = new int[26];
        for (var i = 0; i < magazine.Length; i++) {
            var index = magazine[i] - 'a';
            words[index]++;
        }
        for (var i = 0; i < ransomNote.Length; i++) {
            var index = ransomNote[i] - 'a';
            words[index]--;
            if (words[index] < 0) {
                return false;
            }
        }
        return true;
    }
}