/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if (head is null) {
            return head;
        }
        var mapToRandom = new Dictionary<Node, Node>();
        var mapOldToNew = new Dictionary<Node, Node>();
        var newHead = new Node(head.val);
        var curr = head;
        var newCurr = newHead;

        while (curr is not null) {
            if (curr.random is not null) {
                mapToRandom.Add(newCurr, curr.random);
            }
            mapOldToNew.Add(curr, newCurr);
            if (curr.next is not null) {
                newCurr.next = new Node(curr.next.val);
                newCurr = newCurr.next;
            }
            curr = curr.next;
        }

        foreach (var (node, random) in mapToRandom) {
            if (random is null || !mapOldToNew.TryGetValue(random, out var newRandom)) {
                continue;
            }
            node.random = newRandom;
        }

        return newHead;
    }
}
