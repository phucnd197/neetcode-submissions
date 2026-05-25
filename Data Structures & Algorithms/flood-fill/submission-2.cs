public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        var queue = new Queue<(int, int)>();
        queue.Enqueue((sr, sc));
        var originalColor = image[sr][sc];
        var processed = new HashSet<string>();
        while (queue.Count > 0) {
            var (row, col) = queue.Dequeue();
            processed.Add(row + "_" + col);
            image[row][col] = color;
            if (col > 0 && image[row][col - 1] == originalColor &&
                !processed.Contains($"{row}_{col - 1}")) {
                queue.Enqueue((row, col - 1));
            }

            if (col < (image[row].Length - 1) && image[row][col + 1] == originalColor &&
                !processed.Contains($"{row}_{col + 1}")) {
                queue.Enqueue((row, col + 1));
            }

            if (row > 0 && image[row - 1][col] == originalColor &&
                !processed.Contains($"{row - 1}_{col}")) {
                queue.Enqueue((row - 1, col));
            }

            if (row < (image.Length - 1) && image[row + 1][col] == originalColor &&
                !processed.Contains($"{row + 1}_{col}")) {
                queue.Enqueue((row + 1, col));
            }
        }

        return image;
    }
}