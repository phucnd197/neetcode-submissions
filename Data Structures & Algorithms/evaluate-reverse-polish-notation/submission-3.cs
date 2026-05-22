public class Solution {
    public int EvalRPN(string[] tokens) {
        var numbers = new Stack<int>();
        for (var i = 0; i < tokens.Length; i++)
        {
            if (CalMethod.TryGetValue(tokens[i], out var calMethod))
            {
                var a = numbers.Pop();
                var b = numbers.Pop();

                numbers.Push(calMethod(b, a));
            }
            else
            {
                numbers.Push(int.Parse(tokens[i]));
            }
        }
        return numbers.Pop();
    }

    
    private static readonly Dictionary<string, Func<int, int, int>> CalMethod = new()
    {
        ["+"] = Plus,
        ["-"] = Minus,
        ["*"] = Time,
        ["/"] = Divide,
    };
    private static int Plus(int a, int b) => a + b;
    private static int Minus(int a, int b) => a - b;
    private static int Time(int a, int b) => a * b;
    private static int Divide(int a, int b) => a / b;
}
