public class Solution {
    public int[][] Merge(int[][] intervals) {
        if (intervals.Length == 0) {
            return [];
        }
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        int[] prev = intervals[0];
        var i = 1;
        var result = new List<int[]>(intervals.Length);
        while (i < intervals.Length) {
            var current = intervals[i++];
            if (current[0] <= prev[1] || prev[1] >= current[1]) {
                prev[1] = Math.Max(prev[1], current[1]);
                continue;
            }
            result.Add(prev);
            prev = current;
        }
        result.Add(prev);
        return [..result];
    }
}
