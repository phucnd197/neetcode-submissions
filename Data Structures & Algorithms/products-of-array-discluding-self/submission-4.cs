public class Solution {
    // with division operator
    public int[] ProductExceptSelf(int[] nums) {
        if (nums.Length <= 1) {
            return nums;
        }

        var result = new int[nums.Length];
        Array.Fill(result, 1);
        var multiple = 1;
        var zeroCount = 0;
        var zeroIndex = -1;
        for (var i = nums.Length - 2; i > -1; i--) {
            if (nums[i + 1] == 0) {
                zeroCount++;
                zeroIndex = i + 1;
                continue;
            }
            result[i] = multiple *= nums[i + 1];
        }

        if (nums[0] == 0) {
            zeroCount++;
            zeroIndex = 0;
        } else {
            multiple *= nums[0];
        }

        if (zeroCount > 0) {
            Array.Fill(result, 0);
            if (zeroCount == 1) {
                result[zeroIndex] = multiple;
            }
        } else {
            multiple = 1;
            for (var i = 1; i < nums.Length; i++) {
                result[i] *= multiple *= nums[i - 1];
            }
        }

        return result;
    }
}
