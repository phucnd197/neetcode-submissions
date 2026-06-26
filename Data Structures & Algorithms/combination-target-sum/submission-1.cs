public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        var result = new List<List<int>>();
        Array.Sort(nums);
        return CombinationSum(result, nums, target, 0, []);
    }

    public static List<List<int>> CombinationSum(List<List<int>> result, int[] nums, int target,
                                                 int start, List<int> current) {
        for (var i = start; i < nums.Length; i++) {
            if (nums[i] > target) {
                break;
            } else if (nums[i] == target) {
                result.Add([..current, nums[i]]);
                break;
            }

            var loop = target / nums[i];
            var original = new List<int>(current);
            for (var j = 1; j <= loop; j++) {
                var remainder = target - nums[i] * j;
                original.Add(nums[i]);
                if (remainder == 0) {
                    result.Add(original);
                    break;
                } else if (remainder < nums[i]) {
                    break;
                }

                CombinationSum(result, nums, remainder, i + 1, original);

                // var other = new List<int>();
                // for (var k = i + 1; k < nums.Length; k++)
                //{
                //     if (remainder < nums[k])
                //     {
                //         break;
                //     }
                //     var multiple = remainder / nums[k];
                //     for (var z = 0; z < multiple; z++)
                //     {
                //         other.Add(nums[k]);
                //     }
                //     remainder -= multiple * nums[k];
                //     if (remainder == 0)
                //     {
                //         var final = new List<int>(original);
                //         final.AddRange(other);
                //         result.Add(final);
                //         break;
                //     }
                // }
            }
        }

        return result;
    }
}
