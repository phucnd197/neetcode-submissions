public class Solution {
    public int MaxSubArray(int[] nums) {
        var maxSub = nums[0];
        var trail = nums[0];
        for (var i = 1; i < nums.Length; i++) {
            if (trail < 0 && trail < nums[i]) {
                trail = nums[i];
            } else {
                trail += nums[i];
            }
            if (trail > maxSub) {
                maxSub = trail;
            }
        }
        return maxSub;
    }
}
