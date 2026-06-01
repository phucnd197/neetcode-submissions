public class Solution {
    public bool hasDuplicate(int[] nums) {
        var numbers = new HashSet<int>();
        for (var i = 0; i < nums.Length; i++) {
            if (numbers.Contains(nums[i])) {
                return true;
            }
            numbers.Add(nums[i]);
        }
        return false;
    }
}