public class Solution {
    public int FindMin(int[] nums) {
        if (!(nums[0] > nums[nums.Length - 1])) {
            return nums[0];
        }
        var lowest = int.MaxValue;
        var i = 0;
        var l = 0;
        var r = nums.Length - 1;
        while (l <= r) {
            var mid = (r + l) / 2;
            if (nums[mid] > nums[nums.Length - 1]) {
                l = mid + 1;
            } else if (nums[mid] < nums[nums.Length - 1]) {
                r = mid - 1;
            } else {
                l++;
            }

            if (lowest > nums[mid]) {
                lowest = nums[mid];
                i = mid;
            }
        }
        return lowest;
    }
}
