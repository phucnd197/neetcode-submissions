public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        var ans = new Dictionary<string, List<string>>();
        List<List<string>> result;
        Span<int> count = stackalloc int[26];
        
        foreach (var s in strs)
        {
            foreach (var c in s)
            {
                count[c - 'a']++;
            }
        
            var keyBuilder = new StringBuilder();
            for (var i = 0; i < count.Length; i++)
            {
                keyBuilder.Append(count[i]).Append(',');
            }
            var key = keyBuilder.ToString();
            if (!ans.ContainsKey(key))
            {
                ans[key] = new List<string>();
            }
                
            ans[key].Add(s);
            count.Clear();
        }
        result = new List<List<string>>(ans.Values);
        return result;
    }
}
