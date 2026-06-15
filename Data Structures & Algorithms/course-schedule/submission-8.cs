public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var indegrees = new int[numCourses];
        var adj = new List<List<int>>(numCourses);
        for (var i = 0; i < numCourses; i++) {
            adj.Add(new List<int>());
        }

        foreach (var prerequisite in prerequisites) {
            indegrees[prerequisite[1]]++;
            adj[prerequisite[0]].Add(prerequisite[1]);
        }

        var queue = new Queue<int>();
        for (var i = 0; i < numCourses; i++) {
            if (indegrees[i] == 0) {
                queue.Enqueue(i);
            }
        }

        var finish = 0;
        while (queue.Count > 0) {
            var course = queue.Dequeue();
            var adjList = adj[course];
            finish++;
            for (var i = 0; i < adjList.Count; i++) {
                indegrees[adjList[i]]--;
                if (indegrees[adjList[i]] == 0) {
                    queue.Enqueue(adjList[i]);
                }
            }
        }

        return finish == numCourses;
    }
}
