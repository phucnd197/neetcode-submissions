/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals) {
        intervals.Sort((i1, i2) => i1.start.CompareTo(i2.start));
        for (var i = 0; i < intervals.Count - 1; i++) {
            var end1 = intervals[i].end;
            var start2 = intervals[i + 1].start;
            if (end1 > start2) {
                return false;
            }
        }
        return true;
    }
}
