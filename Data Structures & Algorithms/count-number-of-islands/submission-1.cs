public class Solution {
    public int NumIslands(char[][] grid) {
        var numIsland = 0;
        var processed = new HashSet<Point>();
        for (var i = 0; i < grid.Length; i++) {
            for (var j = 0; j < grid[i].Length; j++) {
                var hasNewIsland = Check(grid, new Point(i, j), processed);
                if (hasNewIsland) {
                    numIsland++;
                }
            }
        }
        return numIsland;
    }

    record Point(int X, int Y);
    private static bool Check(char[][] grid, Point start, HashSet<Point> processed) {
        if (processed.Contains(start)) {
            return false;
        }

        processed.Add(start);
        if (grid[start.X][start.Y] == '0') {
            return false;
        }

        if (start.X > 0) {
            Check(grid, new Point(start.X - 1, start.Y), processed);
        }

        if (start.X < grid.Length - 1) {
            Check(grid, new Point(start.X + 1, start.Y), processed);
        }

        if (start.Y > 0) {
            Check(grid, new Point(start.X, start.Y - 1), processed);
        }

        if (start.Y < grid[start.X].Length - 1) {
            Check(grid, new Point(start.X, start.Y + 1), processed);
        }

        return true;
    }
}
