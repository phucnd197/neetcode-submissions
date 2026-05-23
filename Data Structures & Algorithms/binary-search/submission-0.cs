public class Solution {
    public int Search(int[] nums, int target) {
        var left = 0;
        var right = nums.Length - 1;
        var mid = (nums.Length - 1) / 2;
        while (left <= right) {
            var diff = nums[mid] - target;
            if (diff == 0) {
                return mid;
            } else if (diff < 0) {
                left = mid + 1;
            } else if (diff > 0) {
                right = mid - 1;
            }
            mid = (left + right) / 2;
        }
        return -1;
    }
}
