public class Solution {
    public int LongestPalindrome(string s) {
        if (s.Length <= 1) {
            return s.Length;
        }
        var lowercase = new int[26];
        var uppercase = new int[26];

        for (var i = 0; i < s.Length; i++) {
            var c = s[i];
            if (c >= 'A' && c <= 'Z') {
                uppercase[c - 'A']++;
            } else if ('a' <= c && c <= 'z') {
                lowercase[c - 'a']++;
            }
        }
        var longest = 0;
        for (var i = 0; i < lowercase.Length; i++) {
            if (lowercase[i] >= 2) {
                longest += lowercase[i] % 2 == 0 ? lowercase[i] : lowercase[i] - 1;
            }
            if (uppercase[i] >= 2) {
                longest += uppercase[i] % 2 == 0 ? uppercase[i] : uppercase[i] - 1;
            }
        }
        if (longest < s.Length) {
            longest++;
        }
        return longest;
    }
}