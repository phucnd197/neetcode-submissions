public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var result = new int[2];
        for (var i = 0; i < numbers.Length; i++)
        {
            var test = numbers[i];
            result[0] = i + 1;
           
            for (var j = i + 1; j < numbers.Length; j++)
            {
                if (test + numbers[j] == target)
                {
                    test += numbers[j];
                    result[1] = j + 1;
                    break;
                }
            }
            if (test == target)
            {
                break;
            }
        }
        return result;
    }
}
