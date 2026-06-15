public class PrefixTree {
    class Node {
        public bool IsEnd { get; set; }
        private readonly Dictionary<char, Node> _neighbors;
        public Node() {
            _neighbors = new Dictionary<char, Node>();
        }

        public bool TryGetNeighbor(char value, out Node? neighbor) {
            return _neighbors.TryGetValue(value, out neighbor);
        }

        public Node AddValue(char value) {
            if (_neighbors.ContainsKey(value)) {
                return _neighbors[value];
            }
            var newNode = new Node();
            _neighbors[value] = newNode;
            return newNode;
        }
    }

    private readonly Dictionary<char, Node> starts;

    public PrefixTree() {
        starts = new Dictionary<char, Node>();
    }

    public void Insert(string word) {
        if (string.IsNullOrEmpty(word)) {
            return;
        }
        Node? current;
        if (starts.TryGetValue(word[0], out Node? value))
        {
            current = value;
        } else {
            starts[word[0]] = current = new Node();
        }
        for (var i = 1; i < word.Length; i++) {
            var character = word[i];
            current = current.AddValue(character);
        }
        current.IsEnd = true;
    }

    public bool Search(string word) {
        var node = FindString(word);
        return node is not null && node.IsEnd;
    }

    public bool StartsWith(string prefix) {
        return FindString(prefix) is not null;
    }

    private Node FindString(string word) {
        if (string.IsNullOrEmpty(word)) {
            return null;
        }
        var current = starts.TryGetValue(word[0], out Node? value) ? value : null;
        for (var i = 1; i < word.Length; i++) {
            if (current is null) {
                return null;
            }
            current.TryGetNeighbor(word[i], out current);
        }
        return current;
    }
}