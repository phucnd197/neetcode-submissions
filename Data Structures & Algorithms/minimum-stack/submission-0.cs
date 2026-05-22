public class MinStack {
    class LinkedList
    {
        class Node
        {
            public Node? Next { get; set; }
            public int Value { get; init; }
        }

        private Node? _head;

        public void Push(int val)
        {
            var newNode = new Node
            {
                Value = val
            };
            if (_head is null)
            {
                _head = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }
        }

        public void Pop()
        {
            if (_head is null)
            {
                return;
            }
            _head = _head.Next;
        }

        public int Top()
        {
            return _head is not null ? _head.Value : int.MaxValue;
        }
    }

    private readonly LinkedList _values;
    private readonly LinkedList _min;

    public MinStack()
    {
        _min = new LinkedList();
        _values = new LinkedList();
    }


    public void Push(int val)
    {
        _values.Push(val);
        _min.Push(_min.Top() > val ? val : _min.Top());
    }

    public void Pop()
    {
        _values.Pop();
        _min.Pop();
    }

    public int Top()
    {
        return _values.Top();
    }

    public int GetMin()
    {
        return _min.Top();
    }
}
