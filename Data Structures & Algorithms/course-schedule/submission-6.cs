public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        if (prerequisites.Length == 0) {
            return true;
        }

        var courses = new Dictionary<int, List<int>>();
        for (var i = 0; i < prerequisites.Length; i++) {
            var course = prerequisites[i];
            if (!courses.TryGetValue(course[1], out var prerequisite)) {
                prerequisite = new List<int>();
                courses[course[1]] = prerequisite;
            }

            prerequisite.Add(course[0]);
        }

        foreach (var (course, _) in courses) {
            var metCourse = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(course);
            while (queue.Count > 0) {
                var curr = queue.Dequeue();
                if (!courses.TryGetValue(curr, out var preCourses)) {
                    continue;
                }

                if (!metCourse.Add(curr)) {
                    return false;
                }

                for (var i = 0; i < preCourses.Count; i++) {
                    var preCourse = preCourses[i];
                    queue.Enqueue(preCourse);
                    numCourses--;
                }

                numCourses--;
            }
        }

        return true;
    }
}
