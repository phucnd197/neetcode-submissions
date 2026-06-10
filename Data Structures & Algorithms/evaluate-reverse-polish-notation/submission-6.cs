public class Solution {
    public int EvalRPN(string[] tokens) {
        var nums = new Stack<int>();
        for (var i = 0; i < tokens.Length; i++) {
            var character = tokens[i];
            if (int.TryParse(character, out var number)) {
                nums.Push(number);
            } else {
                // reversed order
                var second = nums.Pop();
                var first = nums.Pop();
                var result = character switch { "+" => first + second, "-" => first - second,
                                                "/" => first / second, "*" => first * second,
                                                _ => 0 };

                nums.Push(result);
            }
        }
        return nums.Peek();
    }
}
