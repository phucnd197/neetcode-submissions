public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        var result = new List<List<int>>();
        Array.Sort(nums);
        for (var i = 0; i < nums.Length - 2; i++) {
            if (nums[i] > 0)
                break;
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            var target = -nums[i];
            var j = i + 1;
            var k = nums.Length - 1;
            while (j < k) {
                var sum = nums[j] + nums[k];
                if (sum < target) {
                    j++;
                } else if (sum > target) {
                    k--;
                } else {
                    result.Add(new List<int> { nums[i], nums[j], nums[k] });
                    j++;
                    k--;
                    while (j < k && nums[j] == nums[j - 1]) {
                        j++;
                    }
                }
            }
        }
        return result;
    }
}
