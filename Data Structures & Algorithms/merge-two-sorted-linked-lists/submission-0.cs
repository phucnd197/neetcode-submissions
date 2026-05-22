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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 is null && list2 is null) {
            return null;
        } else if (list1 is not null && list2 is null) {
            return list1;
        } else if (list2 is not null && list1 is null) {
            return list2;
        }
        var current1 = list1;
        var current2 = list2;
        ListNode merged = null;
        if (current1.val < current2.val) {
            merged = new ListNode(current1.val);
            current1 = current1.next;
        } else {
            merged = new ListNode(current2.val);
            current2 = current2.next;
        }
        var root = merged;
        while (current1 != null && current2 != null) {
            if (current1.val < current2.val) {
                merged.next = new ListNode(current1.val);
                current1 = current1.next;
            } else {
                merged.next = new ListNode(current2.val);
                current2 = current2.next;
            }
            merged = merged.next;
        }
        if (current1 != null) {
            merged.next = current1;
        } else if (current2 != null) {
            merged.next = current2;
        }
        return root;
    }
}