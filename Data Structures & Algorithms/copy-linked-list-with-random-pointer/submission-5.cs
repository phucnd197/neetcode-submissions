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

        var curr = head;
        while (curr is not null) {
            var oldNext = curr.next;
            var newNode = new Node(curr.val) { next = oldNext };
            curr.next = newNode;
            curr = oldNext;
        }

        curr = head;
        var newHead = head.next;
        var currNew = newHead;
        while (curr is not null && currNew is not null) {
            if (curr.random is not null) {
                currNew.random = curr.random.next;
            }
            currNew = currNew.next?.next;
            curr = curr.next?.next;
        }

        currNew = newHead;
        curr = head;
        while (currNew is not null) {
            var oldNext = curr.next?.next;
            var newNext = currNew.next?.next;
            curr.next = oldNext;
            currNew.next = newNext;
            curr = oldNext;
            currNew = newNext;
        }

        return newHead;
    }
}
