public class Solution {
    public int EvalRPN(string[] tokens) {
        var numbers = new Stack<int>();
        for (var i = 0; i < tokens.Length; i++)
        {
            switch (tokens[i])
            {
                case "+":
                    {
                        var a = numbers.Pop();
                        var b = numbers.Pop();
                        numbers.Push(b + a);
                    }
                    break;
                case "-":
                    {
                        var a = numbers.Pop();
                        var b = numbers.Pop();
                        numbers.Push(b - a);
                    }
                    break;
                case "/":
                    {
                        var a = numbers.Pop();
                        var b = numbers.Pop();
                        numbers.Push(b / a);
                    }
                    break;
                case "*":
                    {
                        var a = numbers.Pop();
                        var b = numbers.Pop();
                        numbers.Push(b * a);
                    }
                    break;

                default:
                    numbers.Push(int.Parse(tokens[i]));
                    break;
            }
        }
        return numbers.Pop();
    }
}
