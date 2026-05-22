public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var numbers = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++) {
            numbers[nums[i]] = i;
        }
        for (var i = 0; i < nums.Length; i++) {
            if (!numbers.TryGetValue(target - nums[i], out var secondIndex) || secondIndex == i) {
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
