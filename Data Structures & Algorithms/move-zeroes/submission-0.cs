public class Solution {
    public void MoveZeroes(int[] nums) {
        var left = 0;
        var right = 1;
        while (right < nums.Length) {
            while (left < nums.Length && nums[left] != 0) {
                left++;
            }
            if (right < left) {
                right = left + 1;
            }
            while (right < nums.Length && nums[right] == 0) {
                right++;
            }
            if (right > nums.Length - 1) {
                break;
            }
            nums[left] = nums[right];
            nums[right] = 0;
        }
    }
}