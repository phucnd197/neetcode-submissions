public class Solution {
    record struct Position(int row, int col);
    public int OrangesRotting(int[][] grid) {
        var rotting = new List<Position>();
        var orangeCount = 0;
        for (var i = 0; i < grid.Length; i++) {
            for (var j = 0; j < grid[i].Length; j++) {
                var data = grid[i][j];
                if (data == 2) {
                    rotting.Add(new Position(i, j));
                } else if (data == 1) {
                    orangeCount++;
                }
            }
        }

        if (rotting.Count == 0) {
            return orangeCount > 0 ? -1 : 0;
        }

        var mins = 0;
        var index = 0;
        while (index < rotting.Count) {
            var originalCount = rotting.Count;
            for (; index < originalCount; index++) {
                var position = rotting[index];
                if (position.row > 0 && grid[position.row - 1][position.col] == 1) {
                    var up = position with { row = position.row - 1 };
                    rotting.Add(up);
                    grid[up.row][up.col] = 2;
                    orangeCount--;
                }

                if (position.row < grid.Length - 1 && grid[position.row + 1][position.col] == 1) {
                    var down = position with { row = position.row + 1 };
                    rotting.Add(down);
                    grid[down.row][down.col] = 2;
                    orangeCount--;
                }

                if (position.col > 0 && grid[position.row][position.col - 1] == 1) {
                    var left = position with { col = position.col - 1 };
                    rotting.Add(left);
                    grid[left.row][left.col] = 2;
                    orangeCount--;
                }

                if (position.col < grid[position.row].Length - 1 &&
                    grid[position.row][position.col + 1] == 1) {
                    var right = position with { col = position.col + 1 };
                    rotting.Add(right);
                    grid[right.row][right.col] = 2;
                    orangeCount--;
                }
            }

            if (originalCount < rotting.Count) {
                mins++;
            }
        }

        return orangeCount > 0 ? -1 : mins;
    }
}
