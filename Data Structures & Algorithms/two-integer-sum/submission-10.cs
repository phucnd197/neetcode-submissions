public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var numbers = new Dictionary<int, List<int>>();
        for (var i = 0; i < nums.Length; i++) {
            if (!numbers.TryGetValue(nums[i], out var indexes)) {
                indexes = [];
                numbers[nums[i]] = indexes;
            }
            indexes.Add(i);
        }
        for (var i = 0; i < nums.Length; i++) {
            if (!numbers.TryGetValue(target - nums[i], out var indexes)) {
                continue;
            }
            var secondIndex = -1;
            if (indexes.Count == 1 && indexes[0] != i) {
                secondIndex = indexes[0];
            } else {
                for (var j = 0; j < indexes.Count; j++) {
                    if (indexes[j] != i) {
                        secondIndex = indexes[j];
                        break;
                    }
                }
            }

            if (secondIndex == -1) {
                continue;
            }

            if (i > secondIndex) {
                return [secondIndex, i];
            }
            return [i, secondIndex];
        }
        return [];
    }
}
