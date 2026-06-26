public class Solution {
    public int Search(int[] nums, int target) {
        var lowest = int.MaxValue;
        var i = 0;
        var l = 0;
        var r = nums.Length - 1;
        if (nums[0] > nums[nums.Length - 1]) {
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
        }

        l = 0;
        r = i - 1;
        while (l <= r) {
            var mid = (r + l) / 2;
            if (nums[mid] < target) {
                l = mid + 1;
            } else if (nums[mid] > target) {
                r = mid - 1;
            } else {
                return mid;
            }
        }

        l = i;
        r = nums.Length - 1;
        while (l <= r) {
            var mid = (r + l) / 2;
            if (nums[mid] < target) {
                l = mid + 1;
            } else if (nums[mid] > target) {
                r = mid - 1;
            } else {
                return mid;
            }
        }

        return -1;
    }
}
