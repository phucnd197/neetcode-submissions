public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var numbers = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++) {
            var diff = target - nums[i];
            if (numbers.TryGetValue(diff, out var other)) {
                if (i < other) {
                    return [i, other];
                } else {
                    return [other, i];
                }
            }

            numbers.Add(nums[i], i);
        }
        return [];
    }
}
