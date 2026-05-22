public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var count = new Dictionary<int, int>();
        var frequencyGroups = new List<int>[nums.Length + 1];

        for (var i = 0; i < frequencyGroups.Length; i++)
        {
            frequencyGroups[i] = new List<int>();
        }

        // get frequency
        for (var i = 0; i < nums.Length; i++)
        {
            if (count.TryGetValue(nums[i], out int value))
            {
                count[nums[i]] = ++value;
            }
            else
            {
                count[nums[i]] = 1;
            }
        }

        foreach (var (number, freq) in count)
        {
            frequencyGroups[freq].Add(number);
        }

        var top = new int[k];
        var index = 0;
        for (var i = frequencyGroups.Length - 1; i > 0; i--)
        {
            for (var j = 0; j < frequencyGroups[i].Count; j++)
            {
                if (index == k)
                {
                    break;
                }
                top[index++] = frequencyGroups[i][j];
            }
        }
        return top;
    }
}
