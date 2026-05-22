public class LRUCache
{
    class Data {
        public int Key {get;init;}
        public int Value {get; init;}

        public Data(int key, int value) {
            Key = key;
            Value = value;
        }
    }
    private readonly int _capacity;
    private readonly Dictionary<int, DoubleLinkedNode<Data>> _cache;
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
        _cache[key] = _times.InsertLast(new(node.Data.Key, node.Data.Value));
        return node.Data.Value;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            _times.RemoveAt(node);
            _cache[key] = _times.InsertLast(new(key, value));
            return;
        }
        if (_cache.Count < _capacity)
        {
            _cache[key] = _times.InsertLast(new(key, value));
            return;
        }

        _cache[key] = _times.InsertLast(new(key, value));
        _cache.Remove(_times.RemoveFirst().Key);
    }

    private class DoubleLinkedNode<T>
    {
        public DoubleLinkedNode<T>? Prev { get; set; }
        public DoubleLinkedNode<T>? Next { get; set; }
        public T Data { get; set; }
        public DoubleLinkedNode(T data) { Data = data; }
    }

    private class DoublyLinkedList<T>
    {
        private DoubleLinkedNode<T>? _head;
        private DoubleLinkedNode<T>? _tail;

        public DoubleLinkedNode<T> InsertLast(T data)
        {
            var newNode = new DoubleLinkedNode<T>(data);
            if (_tail is null)
            {
                _head = newNode;
                _tail = newNode;
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

            return newNode;
        }

        public T? RemoveFirst()
        {
            if (_head == null)
            {
                return default(T);
            }

            var data = _head.Data;
            if (_tail == _head)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                var newHead = _head.Next;
                if (newHead != null)
                {
                    newHead.Prev = null;
                }
                _head = newHead;
            }

            return data;
        }

        public T? RemoveAt(DoubleLinkedNode<T> node)
        {
            if (_head == null)
            {
                return default(T);
            }

            var data = node.Data;
            if (_tail == _head)
            {
                _head = null;
                _tail = null;
            }
            else
            {
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

                if (_head == _tail)
                {
                    _head = _tail;
                    _head!.Prev = null;
                    _head.Next = null;
                }
                else
                {
                    if (node == _head)
                    {
                        _head = next;
                        if (_head is not null)
                        {
                            _head.Prev = null;
                        }
                    }
                    if (node == _tail)
                    {
                        _tail = prev;
                        if (_tail is not null)
                        {
                            _tail!.Next = null;
                        }
                    }
                }
            }

            return data;
        }
    }
}