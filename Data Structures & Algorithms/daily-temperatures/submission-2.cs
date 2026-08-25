public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var result = new int[temperatures.Length];
        var stack = new Stack<int>();
        for (var i = temperatures.Length - 1; i > -1; i--) {
            while (stack.Count > 0 && temperatures[stack.Peek()] <= temperatures[i]) {
                stack.Pop();
            }

            var count = stack.Count > 0 ? stack.Peek() - i : 0;
            result[i] = count;
            stack.Push(i);
        }
        return result;
    }
}
