public class Solution {
    public bool IsPalindrome(int x) {
        if (x < 0) {
            return false;
        }
        if (x < 10) {
            return true;
        }
        var numbers = new List<int>();
        while (x > 0) {
            var remainder = x % 10;
            x /= 10;
            numbers.Add(remainder);
        }

        var left = 0;
        var right = numbers.Count - 1;
        while (left < right) {
            if (numbers[left] != numbers[right]) {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}