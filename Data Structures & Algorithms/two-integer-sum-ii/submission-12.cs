public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int l = 0, r = numbers.Length - 1;
        while (l < r)
        {
            var result = numbers[l] + numbers[r];
            if (result > target)
            {
                r--;
            }
            else if (result < target)
            {
                l++;
            }
            else
            {
                return new int[] { l + 1, r + 1 };
            }
        }
        return Array.Empty<int>();
    }
}
