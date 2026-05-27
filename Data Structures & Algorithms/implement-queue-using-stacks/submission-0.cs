public class MyQueue {
    private readonly Stack<int> first;
    private readonly Stack<int> second;

    public MyQueue() {
        first = new Stack<int>();
        second = new Stack<int>();
    }

    public void Push(int x) {
        if (first.Count == 0) {
            first.Push(x);
            return;
        }

        while (first.Count > 0) {
            second.Push(first.Pop());
        }

        first.Push(x);
        while (second.Count > 0) {
            first.Push(second.Pop());
        }
    }

    public int Pop() {
        return first.Pop();
    }

    public int Peek() {
        return first.Peek();
    }

    public bool Empty() {
        return first.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */