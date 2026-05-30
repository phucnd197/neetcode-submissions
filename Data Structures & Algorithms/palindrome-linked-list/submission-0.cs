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
    public bool IsPalindrome(ListNode head) {
        if (head is null) {
            return true;
        }

        var count = 0;
        var current = head;
        while (current is not null) {
            count++;
            current = current.next;
        }

        var mid = count / 2;
        var startMid = mid + (count % 2 == 0 ? 0 : 1);
        var index = 0;
        ListNode prev = null;
        current = head;
        while (index < count) {
            if (index >= startMid) {
                var temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            } else {
                prev = current;
                current = current.next;
            }

            index++;
        }

        index = 0;
        var left = head;
        var right = prev;
        while (index < mid) {
            if (left.val != right.val) {
                return false;
            }

            left = left.next;
            right = right.next;
            index++;
        }

        return true;
    }
}