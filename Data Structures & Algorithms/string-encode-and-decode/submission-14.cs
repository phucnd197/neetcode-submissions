public class Solution {
    public string Encode(IList<string> strs) {
        if (strs.Count == 0) {
            return null;
        }

        var result = new StringBuilder();
        result.Append('[');
        for (var i = 0; i < strs.Count; i++) {
            if (i > 0) {
                result.Append(',');
            }

            result.Append(strs[i].Length);
        }

        result.Append(']');
        for (var i = 0; i < strs.Count; i++) {
            result.Append(strs[i]);
        }

        return result.ToString();
    }

    public List<string> Decode(string s) {
        if (s is null) {
            return [];
        }

        if (s == "[0]") {
            return [""];
        }

        var headerEnd = 0;
        for (var i = 1; i < s.Length; i++) {
            if (s[i] == ']') {
                headerEnd = i - 1;
                break;
            }
        }

        var headerIndex = 1;
        var stringIndex = headerEnd + 2;
        var result = new List<string>();
        while (headerIndex <= headerEnd) {
            var lengthBuilder = new StringBuilder();
            while (headerIndex <= headerEnd) {
                if (s[headerIndex] == ',') {
                    headerIndex++;
                    break;
                }

                lengthBuilder.Append(s[headerIndex]);
                headerIndex++;
            }

            if (!int.TryParse(lengthBuilder.ToString(), out var length)) {
                throw new ArgumentException("length format invalid");
            }

            result.Add(s.Substring(stringIndex, length));
            stringIndex += length;
        }

        return result;
    }
}
