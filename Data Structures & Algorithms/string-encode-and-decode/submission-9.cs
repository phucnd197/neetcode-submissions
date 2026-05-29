public class Solution {
    public string Encode(IList<string> strs) {
        if (strs.Count == 0)
            return null;
        return string.Join("%5F", strs);
    }

    public List<string> Decode(string s) {
        if (s == null) {
            return [];
        }
        return s.Split("%5F").ToList();
    }
}
