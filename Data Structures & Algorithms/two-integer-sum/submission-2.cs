public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var differs = new Dictionary<int, int>();
        for(var i = 0; i < nums.Length; i++) {
            var diff = target - nums[i];
            if(differs.ContainsKey(nums[i])) {
                continue;
            }
            differs.Add(nums[i], i);
        }
        for(var i = 0; i < nums.Length; i++) {
            var diff = target - nums[i];
            if(differs.TryGetValue(diff, out var j) && i != j) {
                if(i > j) {
                    return new int[] {j, i};
                } else {
                    return new int[] {i, j};
                }
            }
        }
        return Array.Empty<int>();
    }
}
