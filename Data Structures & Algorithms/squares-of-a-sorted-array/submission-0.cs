public class Solution {
    public int[] SortedSquares(int[] nums) {
        var lastNegative = -1;
        for (var i = 0; i < nums.Length; i++) {
            var num = nums[i];
            if (num >= 0) {
                break;
            }
            lastNegative = i;
        }

        if (lastNegative == -1) {
            for (var i = 0; i < nums.Length; i++) {
                nums[i] = (int)Math.Pow(nums[i], 2);
            }
            return nums;
        }

        var negative = lastNegative;
        var positive = negative + 1;
        var result = new int[nums.Length];
        var index = 0;
        while (negative > -1 && positive < nums.Length) {
            var negativeSquare = (int)Math.Pow(nums[negative], 2);
            var positiveSquare = (int)Math.Pow(nums[positive], 2);
            if (negativeSquare > positiveSquare) {
                result[index++] = positiveSquare;
                positive++;
            } else if (negativeSquare < positiveSquare) {
                result[index++] = negativeSquare;
                negative--;
            } else {
                result[index++] = negativeSquare;
                result[index++] = positiveSquare;
                negative--;
                positive++;
            }
        }

        if (negative > -1) {
            for (var i = negative; i > -1; i--) {
                result[index++] = (int)Math.Pow(nums[i], 2);
            }
        }
        if (positive < nums.Length) {
            for (var i = positive; i < nums.Length; i++) {
                result[index++] = (int)Math.Pow(nums[i], 2);
            }
        }

        return result;
    }
}