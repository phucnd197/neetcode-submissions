public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var indices = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) {
            var diff = target - nums[i];
            if (indices.TryGetValue(diff, out var j)) {
                return new int[] {j, i};
            }
            indices[nums[i]] = i;
        }
        return Array.Empty<int>();
    }
}
