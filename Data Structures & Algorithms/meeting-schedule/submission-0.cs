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
        intervals = intervals.OrderBy(x => x.start).ToList();
        for (var i = 0; i < intervals.Count - 1; i++) {
            var start1 = intervals[i].start;
            var end1 = intervals[i].end;
            var start2 = intervals[i + 1].start;
            var end2 = intervals[i + 1].end;
            if (start1 <= start2 && start2 < end1 || start2 <= start1 && end1 <= end2 ||
                start1 <= end2 && end2 <= end1) {
                return false;
            }
        }
        return true;
    }
}
