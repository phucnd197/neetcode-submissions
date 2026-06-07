/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node is null) {
            return null;
        }
        var nodes = new Queue<Node>();
        nodes.Enqueue(node);
        var nodeDict = new Dictionary<int, Node>();

        while (nodes.Count > 0) {
            var currNode = nodes.Dequeue();

            if (!nodeDict.TryGetValue(currNode.val, out var newNode)) {
                newNode = new Node(currNode.val);
                nodeDict.Add(newNode.val, newNode);
            }

            if (currNode.neighbors is not { Count : > 0 }) {
                continue;
            }

            var newNeighbors = new List<Node>();
            for (var i = 0; i < currNode.neighbors.Count; i++) {
                var neighbor = currNode.neighbors[i];
                if (!nodeDict.TryGetValue(neighbor.val, out var newNeighbor)) {
                    newNeighbor = new Node(neighbor.val);
                    nodeDict.Add(newNeighbor.val, newNeighbor);
                    nodes.Enqueue(neighbor);
                }
                newNeighbors.Add(newNeighbor);
            }
            newNode.neighbors = newNeighbors;
        }

        return nodeDict[node.val];
    }
}
