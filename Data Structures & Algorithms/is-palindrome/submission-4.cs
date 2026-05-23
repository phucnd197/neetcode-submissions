public class Solution {
    public bool IsPalindrome(string s) {
        for (int i = 0, j = s.Length - 1; i < s.Length && j > -1;) {
            var characterA = s[i];
            if (!IsLetterOrDigit(characterA)) {
                i++;
                continue;
            }
            var characterB = s[j];
            if (!IsLetterOrDigit(characterB)) {
                j--;
                continue;
            }
            if (ToLower(characterA) != ToLower(characterB)) {
                return false;
            }
            i++;
            j--;
        }
        return true;
    }

    static int ToLower(char character) {
        return character > 'Z' ? character : (character - 'A' + 'a');
    }

    static bool IsLetterOrDigit(char character) {
        return (character >= 'A' && character <= 'Z') || (character >= 'a' && character <= 'z') ||
               (character >= '0' && character <= '9');
    }
}
