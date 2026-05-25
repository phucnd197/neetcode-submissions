public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        var originalColor = image[sr][sc];
        if (originalColor == color) {
            return image;
        }
        var queue = new Queue<(int, int)>();
        queue.Enqueue((sr, sc));
        while (queue.Count > 0) {
            var (row, col) = queue.Dequeue();
            image[row][col] = color;
            if (col > 0 && image[row][col - 1] == originalColor) {
                queue.Enqueue((row, col - 1));
            }

            if (col < (image[row].Length - 1) && image[row][col + 1] == originalColor) {
                queue.Enqueue((row, col + 1));
            }

            if (row > 0 && image[row - 1][col] == originalColor) {
                queue.Enqueue((row - 1, col));
            }

            if (row < (image.Length - 1) && image[row + 1][col] == originalColor) {
                queue.Enqueue((row + 1, col));
            }
        }

        return image;
    }
}