public class Solution {
    public int FindDuplicate(int[] nums) {
        var existed = new HashSet<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (existed.Contains(nums[i]))
            {
                return nums[i];
            }
            existed.Add(nums[i]);
        }
        return -1;
    }
}
