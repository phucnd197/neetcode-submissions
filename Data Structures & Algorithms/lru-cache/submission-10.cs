public class LRUCache
{
    class Data
    {
        public int Key { get; set; }
        public int Value { get; set; }

        public Data(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }
    private readonly int _capacity;
    private readonly Dictionary<int, DoublyLinkedNode<Data>> _cache;
    private readonly DoublyLinkedList<Data> _times;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new(capacity);
        _times = new();
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node))
        {
            return -1;
        }
        _times.RemoveAt(node);
        _times.InsertNodeLast(node);
        return node.Data.Value;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            _times.RemoveAt(node);
            node.Data.Value = value;
            _times.InsertNodeLast(node);
            return;
        }
        if (_cache.Count < _capacity)
        {
            _cache[key] = _times.InsertLast(new(key, value));
            return;
        }

        var lruKeyNode = _times.RemoveFirst();
        if (lruKeyNode is not null)
        {
            _cache.Remove(lruKeyNode.Data.Key);

            lruKeyNode.Data.Key = key;
            lruKeyNode.Data.Value = value;
            _times.InsertNodeLast(lruKeyNode);
            _cache[key] = lruKeyNode;
        }
    }

    private class DoublyLinkedNode<T>
    {
        public DoublyLinkedNode<T>? Prev { get; set; }
        public DoublyLinkedNode<T>? Next { get; set; }
        public T Data { get; set; }
        public DoublyLinkedNode(T data) { Data = data; }
    }

    private class DoublyLinkedList<T>
    {
        private DoublyLinkedNode<T>? _head;
        private DoublyLinkedNode<T>? _tail;

        public DoublyLinkedNode<T> InsertLast(T data)
        {
            var newNode = new DoublyLinkedNode<T>(data);
            InsertNodeLast(newNode);
            return newNode;
        }

        public void InsertNodeLast(DoublyLinkedNode<T> newNode)
        {
            newNode.Prev = null;
            newNode.Next = null;
            if (_tail is null)
            {
                _head = _tail = newNode;
            }
            else
            {
                newNode.Prev = _tail;
                if (_tail is not null)
                {
                    _tail.Next = newNode;
                }
                _tail = newNode;
            }
        }

        public DoublyLinkedNode<T>? RemoveFirst()
        {
            if (_head is null)
            {
                return default;
            }

            var head = _head;
            if (_tail == _head)
            {
                _head = null;
                _tail = null;
                return head;
            }
            var newHead = _head.Next;
            if (newHead is not null)
            {
                newHead.Prev = null;
            }
            _head = newHead;
            return head;
        }

        public DoublyLinkedNode<T> RemoveAt(DoublyLinkedNode<T> node)
        {
            if (_head is null)
            {
                return node;
            }

            if (_tail == _head)
            {
                _head = null;
                _tail = null;
                return node;
            }

            if (_head == _tail)
            {
                _head.Prev = null;
                _head.Next = null;
                return node;
            }

            var next = node.Next;
            var prev = node.Prev;
            if (next is not null)
            {
                next.Prev = prev;
            }
            if (prev is not null)
            {
                prev.Next = next;
            }
            if (node == _head)
            {
                _head = next;
                if (_head is not null)
                {
                    _head.Prev = null;
                }
            }
            else if (node == _tail)
            {
                _tail = prev;
                if (_tail is not null)
                {
                    _tail.Next = null;
                }
            }

            return node;
        }
    }
}
