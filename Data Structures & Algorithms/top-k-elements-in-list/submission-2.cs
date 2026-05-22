public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var frequencies = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (frequencies.TryGetValue(nums[i], out _))
            {
                frequencies[nums[i]]++;
            }
            else
            {
                frequencies.Add(nums[i], 1);
            }
        }

        var top = new List<KeyValuePair<int, int>>(k);
        var minIndex = -1;
        foreach (var item in frequencies)
        {
            var (_, frequency) = item;
            if (top.Count < k)
            {
                top.Add(item);
                if (top.Count == 1)
                {
                    minIndex = 0;
                }
                else if (frequency < top[minIndex].Value)
                {
                    minIndex = top.Count - 1;
                }
            }
            else
            {
                if (top[minIndex].Value < item.Value)
                {
                    top[minIndex] = item;
                    minIndex = GetMinIndex(top);
                }
            }
        }

        return top.ConvertAll(x => x.Key).ToArray();

        int GetMinIndex(List<KeyValuePair<int, int>> top)
        {
            var minFrequency = int.MaxValue;
            var minIndex = 0;
            for (var i = 0; i < top.Count; i++)
            {
                if (minFrequency > top[i].Value)
                {
                    minIndex = i;
                    minFrequency = top[i].Value;
                }
            }
            return minIndex;
        }
    }
}
