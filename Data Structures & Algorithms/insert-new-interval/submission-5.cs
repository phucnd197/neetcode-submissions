public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        if (intervals.Length == 0) {
            return [newInterval];
        }
        var start = 0;
        var before = -1;
        for (var i = 0; i < intervals.Length; i++) {
            if (intervals[i][0] >= newInterval[0]) {
                break;
            }

            before = i;
        }

        var after = before + 1;
        var merged = 0;
        while (true) {
            var changed = false;
            if (before >= 0) {
                var interval = intervals[before];
                if ((interval[0] <= newInterval[0] && interval[1] >= newInterval[0]) ||
                    (newInterval[0] < interval[0] &&
                     (newInterval[1] >= interval[0] && newInterval[1] <= interval[1] ||
                      newInterval[1] > interval[1]))) {
                    newInterval[0] = interval[0] < newInterval[0] ? interval[0] : newInterval[0];
                    newInterval[1] = interval[1] > newInterval[1] ? interval[1] : newInterval[1];
                    changed = true;
                    merged++;
                    before--;
                }
            }

            if (after <= intervals.Length - 1) {
                var interval = intervals[after];
                if ((interval[0] <= newInterval[1] && interval[1] >= newInterval[1]) ||
                    (newInterval[1] > interval[1] &&
                     (newInterval[0] < interval[0] ||
                      newInterval[0] >= interval[0] && newInterval[0] <= interval[1]))) {
                    newInterval[0] = interval[0] < newInterval[0] ? interval[0] : newInterval[0];
                    newInterval[1] = interval[1] > newInterval[1] ? interval[1] : newInterval[1];
                    changed = true;
                    merged++;
                    after++;
                }
            }

            if (!changed) {
                break;
            }
        }

        var length = intervals.Length - merged + 1;
        var newArray = new int [length][];

        var index = 0;
        for (; index <= before; index++) {
            newArray[index] = intervals[index];
        }

        newArray[index] = newInterval;
        index++;
        for (var j = after; j < intervals.Length; j++) {
            newArray[index++] = intervals[j];
        }

        return newArray;
    }
}
