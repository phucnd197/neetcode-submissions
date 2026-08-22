public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var total = nums1.Length + nums2.Length;
        var evenTotal = total % 2 == 0;
        var current = 0;
        var prev = 0;
        int i = 0, j = 0;
        var median = total / 2;
        // 1 median
        while (i < nums1.Length && j < nums2.Length) {
            int curr;
            if (nums1[i] <= nums2[j]) {
                curr = nums1[i];
                i++;
            } else {
                curr = nums2[j];
                j++;
            }

            if (current == median) {
                if (evenTotal) {
                    return (double)(curr + prev) / 2;
                } else {
                    return curr;
                }
            }
            current++;
            prev = curr;
        }
        if (i < nums1.Length) {
            return CalculateMedian(i, median, current, prev, evenTotal, nums1);
        }
        if (j < nums2.Length) {
            return CalculateMedian(j, median, current, prev, evenTotal, nums2);
        }

        return 0;
    }

    static double CalculateMedian(int numsIndex, int median, int current, int prev, bool evenTotal,
                                  int[] nums) {
        var gap = median - current;
        var numsMedian = numsIndex + (median - current);
        if (evenTotal) {
            var first = nums[numsMedian];
            var second = gap == 0 ? prev : nums[numsMedian - 1];
            return (double)(first + second) / 2;
        } else {
            return nums[numsMedian];
        }
    }
}
