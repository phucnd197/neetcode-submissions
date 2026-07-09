public class Solution {
    public bool CanPartition(int[] nums) {
        var sum = nums.Sum();

        if (sum % 2 != 0) {
            return false;
        }

        var target = sum / 2;
        var mem = new bool [nums.Length][];
        for (var i = 0; i < nums.Length; i++) {
            mem[i] = new bool[target];
        }
        return FindTarget(nums, 0, mem, target);
    }

    private static bool FindTarget(int[] nums, int i, bool[][] mem, int target) {
        if (mem[i][target - 1]) {
            return false;
        }

        for (; i < nums.Length; i++) {
            if (nums[i] > target) {
                continue;
            }

            if (nums[i] == target) {
                return true;
            }

            if (i >= nums.Length - 1) {
                return false;
            }

            if (FindTarget(nums, i + 1, mem, target - nums[i])) {
                return true;
            }

            mem[i][target - 1] = false;
        }

        return false;
    }
}
