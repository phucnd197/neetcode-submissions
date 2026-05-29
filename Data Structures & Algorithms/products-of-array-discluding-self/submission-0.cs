public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        if (nums.Length <= 1) {
            return nums;
        }
        var allProduct = nums[0];
        var zeroCount = 0;
        for (var i = 1; i < nums.Length; i++) {
            if (nums[i] == 0) {
                zeroCount++;
                continue;
            }
            allProduct *= nums[i];
        }
        for (var i = 0; i < nums.Length; i++) {
            if (zeroCount > 1) {
                nums[i] = 0;
                continue;
            }
            if (zeroCount == 0) {
                nums[i] = allProduct / nums[i];
                continue;
            }
            
            if (nums[i] == 0) {
                nums[i] = allProduct;
            } else {
                nums[i] = 0;
            }
        }
        return nums;
    }
}
