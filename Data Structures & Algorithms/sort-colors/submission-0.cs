public class Solution {
    public void SortColors(int[] nums) {
        var arr = new int[3];
        for (var i = 0; i < nums.Length; i++) {
            arr[nums[i]]++;
        }

        Array.Fill(nums, 0, 0, arr[0]);
        Array.Fill(nums, 1, arr[0], arr[1]);
        Array.Fill(nums, 2, arr[1] + arr[0], arr[2]);
    }
}