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
    public ListNode MiddleNode(ListNode head) {
        var count = 0;
        var curr = head;
        while (curr is not null) {
            curr = curr.next;
            count++;
        }

        var mid = count / 2;

        var index = 0;
        curr = head;
        while (index < mid) {
            curr = curr.next;
            index++;
        }
        return curr;
    }
}