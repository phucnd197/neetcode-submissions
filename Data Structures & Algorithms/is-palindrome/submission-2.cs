public class Solution {
    public bool IsPalindrome(string s) {
        var reverseWord = new Stack<char>();
        for (var i = 0; i < s.Length; i++) {
            var character = s[i];
            if (!IsLetterOrDigit(character)) {
                continue;
            }
            reverseWord.Push(s[i]);
        }

        for (var i = 0; i < s.Length; i++) {
            var characterA = s[i];
            if (!IsLetterOrDigit(characterA)) {
                continue;
            }

            var characterB = reverseWord.Pop();
            var lowerA = ToLower(characterA);
            var lowerB = ToLower(characterB);
            if (lowerA != lowerB) {
                return false;
            }
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
