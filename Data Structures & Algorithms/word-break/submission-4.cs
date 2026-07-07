public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {
        if (string.IsNullOrEmpty(s) || wordDict.Count == 0) {
            return false;
        }

        var dict = new HashSet<string>();
        var minWord = int.MaxValue;
        foreach (var word in wordDict) {
            dict.Add(word);
            minWord = Math.Min(minWord, word.Length);
        }

        return WordBreak(0, minWord, s, dict, []);
    }

    private static bool WordBreak(int i, int minWord, string s, HashSet<string> dict,
                                  Dictionary<int, bool> mem) {
        if (mem.TryGetValue(i, out bool value)) {
            return value;
        }

        if (i == s.Length) {
            return true;
        }

        if (i + minWord > s.Length) {
            return false;
        }

        for (var j = i + 1; j <= s.Length; j++) {
            if (dict.Contains(s.Substring(i, j - i)) && WordBreak(j, minWord, s, dict, mem)) {
                mem[i] = true;
                return true;
            }
        }

        mem[i] = false;
        return false;
    }
}
