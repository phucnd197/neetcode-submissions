public class Solution {
    public int MaxArea(int[] heights) {
        var l = 0;
        var r = heights.Length - 1;
        var area = int.MinValue;
        while (l < r) {
            var left = heights[l];
            var right = heights[r];
            var leftSmaller = left < right;
            var temp = (leftSmaller ? left : right) * (r - l);
            if (area < temp) {
                area = temp;
            }
            if (leftSmaller) {
                while (l < r && heights[l] <= left) {
                    l++;
                }
            } else {
                while (l < r && heights[r] <= right) {
                    r--;
                }
            }
        }

        return area;
    }
}
