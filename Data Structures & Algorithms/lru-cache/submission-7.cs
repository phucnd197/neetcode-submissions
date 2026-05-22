public class LRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, DoubleLinkedNode<(int, int)>> _cache;
    private readonly DoublyLinkedList<(int, int)> _times;

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
        var (nodeKey, nodeValue) = _times.RemoveAt(node);
        _cache[key] = _times.InsertLast((nodeKey, nodeValue));
        return nodeValue;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            var (nodeKey, _) = _times.RemoveAt(node);
            _cache[key] = _times.InsertLast((nodeKey, value));
            return;
        }
        if (_cache.Count < _capacity)
        {
            _cache[key] = _times.InsertLast((key, value));
            return;
        }

        _cache[key] = _times.InsertLast((key, value));
        _cache.Remove(_times.RemoveFirst().Item1);
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
        private int _size;
        private DoubleLinkedNode<T>? _head;
        private DoubleLinkedNode<T>? _tail;
        public DoublyLinkedList()
        {
            _size = 0;
        }

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

            _size++;
            return newNode;
        }

        public T? RemoveFirst()
        {
            if (_head == null)
            {
                return default(T);
            }

            var data = _head.Data;
            if (_size == 1)
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

            _size--;
            return data;
        }

        public T? RemoveAt(DoubleLinkedNode<T> node)
        {
            if (_head == null)
            {
                return default(T);
            }

            var data = node.Data;
            if (_size == 1)
            {
                _head = null;
                _tail = null;
                _size--;
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

                _size--;
                if (_size == 1)
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