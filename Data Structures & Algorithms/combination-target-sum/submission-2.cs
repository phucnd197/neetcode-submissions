public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        var result = new List<List<int>>();
        Array.Sort(nums);
        CombinationSum(result, nums, target, 0, 0, []);
        return result;
    }

    public static void CombinationSum(List<List<int>> result, int[] nums, int target, int start,
                                      int total, List<int> current) {
        if (total == target) {
            result.Add([..current]);
            return;
        }
        for (var i = start; i < nums.Length; i++) {
            if (total + nums[i] > target) {
                return;
            }

            current.Add(nums[i]);
            CombinationSum(result, nums, target, i, total + nums[i], current);
            current.RemoveAt(current.Count - 1);
        }
    }
}
