/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var length = 0;
        var curr = head;
        while (curr != null) {
            length++;
            curr = curr.next;
        }

        curr = head;
        ListNode? prev = null;
        while (length-- != n) {
            prev = curr;
            curr = curr.next;
        }

        if (prev is not null) {
            prev.next = prev.next?.next;
        } else {
            head = head.next;
        }

        return head;
    }
}
