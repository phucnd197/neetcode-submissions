public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var queue = new PriorityQueue<int[], double>();
        for (var i = 0; i < points.Length; i++) {
            var point = points[i];
            var distance = Math.Sqrt(Math.Pow(point[0], 2) + Math.Pow(point[1], 2));
            queue.Enqueue(point, distance);
        }

        var result = new int [k][];
        for (var i = 0; i < k; i++) {
            result[i] = queue.Dequeue();
        }
        return result;
    }
}
