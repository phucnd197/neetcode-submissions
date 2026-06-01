public class Solution {
    public int RomanToInt(string s) {
        var result = 0;
        for (var i = 0; i < s.Length; i++) {
            var curr = s[i];
            char? next = i < s.Length - 1 ? s[i + 1] : null;
            if (curr == 'I') {
                if (next == 'V') {
                    result += 4;
                    i++;
                    continue;
                } else if (next == 'X') {
                    result += 9;
                    i++;
                    continue;
                }
            }
            if (curr == 'X') {
                if (next == 'L') {
                    result += 40;
                    i++;
                    continue;
                } else if (next == 'C') {
                    result += 90;
                    i++;
                    continue;
                }
            }
            if (curr == 'C') {
                if (next == 'D') {
                    result += 400;
                    i++;
                    continue;
                } else if (next == 'M') {
                    result += 900;
                    i++;
                    continue;
                }
            }
            result += ConvertNumber(curr);
        }
        return result;
    }

    private static int ConvertNumber(char c) {
        return c switch {
            'I' => 1, 'V' => 5, 'X' => 10, 'L' => 50, 'C' => 100, 'D' => 500, 'M' => 1000,
        };
    }
}
