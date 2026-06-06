public class Solution {
    public int[] SortedSquares(int[] nums) {
        int length = nums.Length, left = 0, right = length - 1, index = length - 1;
        var result = new int[length];
        while (left <= right) {
            var leftValue = nums[left] * nums[left];
            var rightValue = nums[right] * nums[right];
            if (leftValue < rightValue) {
                result[index--] = rightValue;
                right--;
            } else {
                result[index--] = leftValue;
                left++;
            }
        }

        return result;
    }
}