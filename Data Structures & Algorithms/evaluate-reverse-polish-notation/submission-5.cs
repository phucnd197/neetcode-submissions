public class Solution {
    public int EvalRPN(string[] tokens) 
    {
        var numbers = new Stack<int>();
        for (var i = 0; i < tokens.Length; i++)
        {
            var result = tokens[i] switch
            {
                "+" => numbers.Pop() + numbers.Pop(),
                "*" => numbers.Pop() * numbers.Pop(),
                "-" => Minus(numbers.Pop(), numbers.Pop()),
                "/" => Divide(numbers.Pop(), numbers.Pop()),
                _ => int.Parse(tokens[i]),
            };
            numbers.Push(result);
        }
        return numbers.Pop();

    }
    static int Minus(int a, int b) => b - a;
    static int Divide(int a, int b) => b / a;
}
