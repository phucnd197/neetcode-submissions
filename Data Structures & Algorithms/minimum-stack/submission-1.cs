public class MinStack {
    private readonly Stack<int> _min;
    private readonly Stack<int> _actual;

    public MinStack() {
        _min = new Stack<int>();
        _actual = new Stack<int>();
    }

    public void Push(int val) {
        _actual.Push(val);
        var min = _min.Count == 0 ? int.MaxValue : _min.Peek();
        if (min > val) {
            min = val;
        }
        _min.Push(min);
    }

    public void Pop() {
        _actual.Pop();
        _min.Pop();
    }

    public int Top() {
        return _actual.Peek();
    }

    public int GetMin() {
        return _min.Peek();
    }
}
