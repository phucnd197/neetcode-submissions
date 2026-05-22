public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var result = new int[2];
        for (var i = 0; i < numbers.Length; i++)
        {
            var test = numbers[i];
            result[0] = i + 1;
           
            for (var j = i + 1; j < numbers.Length; j++)
            {
                test += numbers[j];
                if (test == target)
                {
                    result[1] = j + 1;
                    break;
                }
                test -= numbers[j];
            }
            if (test == target)
            {
                break;
            }
            Array.Clear(result);
        }
        return result;
    }
}
