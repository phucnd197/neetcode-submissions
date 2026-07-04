public class Solution {
    public void SortColors(int[] nums) {
        var r = nums.Length - 1;
        var l = 0;
        while (l <= r && nums[l] == 0) {
            l++;
        }
        while (l <= r && nums[r] == 2) {
            r--;
        }
        var afterLastZero = l;
        while (l < r) {
            var current = nums[l];
            var next = nums[l + 1];
            if (current == 1) {
                if (next == 0) {
                    nums[afterLastZero] = 0;
                    nums[++l] = 1;
                    while (afterLastZero <= r && nums[afterLastZero] == 0) {
                        afterLastZero++;
                    }
                    if (afterLastZero > l) {
                        l = afterLastZero;
                    }
                    continue;
                }
                // if (next == 2)
                //{
                //     nums[r] = 2;
                //     nums[l] = 1;
                //     while (r >= l && nums[r] == 2)
                //     {
                //         r--;
                //     }
                //     continue;
                // }
            } else if (current == 2) {
                if (nums[r] == 1) {
                    nums[l] = 1;
                } else if (nums[r] == 0) {
                    var temp = nums[afterLastZero];
                    nums[afterLastZero] = 0;

                    if (afterLastZero != l) {
                        nums[l] = temp;
                    }
                    while (l <= r && nums[afterLastZero] == 0) {
                        afterLastZero++;
                    }
                    if (afterLastZero > l) {
                        l = afterLastZero;
                    }
                }
                nums[r] = 2;
                while (r >= l && nums[r] == 2) {
                    r--;
                }
                continue;
            }
            l++;
        }
    }
}