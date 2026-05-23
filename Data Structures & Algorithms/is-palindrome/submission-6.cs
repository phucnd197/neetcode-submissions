public class Solution {
    public bool IsPalindrome(string s) {
        for (int i = 0, j = s.Length - 1; i < s.Length && j > -1;) {
            var characterA = s[i];
            if (!char.IsLetterOrDigit(characterA)) {
                i++;
                continue;
            }
            var characterB = s[j];
            if (!char.IsLetterOrDigit(characterB)) {
                j--;
                continue;
            }
            if (char.ToLower(characterA) != char.ToLower(characterB)) {
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
