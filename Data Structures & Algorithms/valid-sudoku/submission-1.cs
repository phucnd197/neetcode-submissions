public class Solution {
    public bool IsValidSudoku(char[][] board) {
        if (board.Length == 0) {
            return true;  //?
        }
        var rowLen = board.Length;
        var colLen = board[0].Length;

        // check row
        var seen = new HashSet<int>();
        for (var i = 0; i < rowLen; i++) {
            for (var j = 0; j < colLen; j++) {
                var el = board[i][j];
                if (el == '.') {
                    continue;
                }
                if (!seen.Add(el)) {
                    return false;
                }
            }
            seen.Clear();
        }

        // check col
        for (var i = 0; i < colLen; i++) {
            for (var j = 0; j < rowLen; j++) {
                var el = board[j][i];
                if (el == '.') {
                    continue;
                }
                if (!seen.Add(el)) {
                    return false;
                }
            }
            seen.Clear();
        }

        // check square
        var noBox = (rowLen * colLen) / 9;
        var box = 0;
        while (++box < noBox) {
            var rowStart = ((box - 1) / 3) * 3;
            var rowEnd = rowStart + 3;
            var remainder = box % 3;
            var colEnd = (remainder == 0 ? 3 : remainder) * 3;
            var colStart = colEnd - 3;

            for (var i = rowStart; i < rowEnd; i++) {
                for (var j = colStart; j < colEnd; j++) {
                    var el = board[i][j];
                    if (el == '.') {
                        continue;
                    }
                    if (!seen.Add(el)) {
                        return false;
                    }
                }
            }
            seen.Clear();
        }

        return true;
    }
}
