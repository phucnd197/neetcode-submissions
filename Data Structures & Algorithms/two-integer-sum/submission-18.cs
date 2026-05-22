public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var numbers = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++) {
            var diff = target - nums[i];
            if (!numbers.TryGetValue(diff, out var secondIndex)) {
                numbers[nums[i]] = i;
                continue;
            }

            if (i > secondIndex) {
                return [secondIndex, i];
            }
            return [i, secondIndex];
        }
        return [];
    }
}
