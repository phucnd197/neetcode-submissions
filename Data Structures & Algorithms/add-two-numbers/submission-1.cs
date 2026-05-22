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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode? sentinel1 = l1, sentinel2 = l2;
        var result = new ListNode();
        var sentinelResult = result;
        var carryOver = 0;
        while (true)
        {
            var sum = carryOver;
            if (sentinel1 != null)
            {
                sum += sentinel1.val;
                sentinel1 = sentinel1.next;
            }
            if (sentinel2 != null)
            {
                sum += sentinel2.val;
                sentinel2 = sentinel2.next;
            }
            carryOver = sum / 10;
            sentinelResult.val = sum % 10;

            if (sentinel1 == null && sentinel2 == null)
            {
                if (carryOver > 0)
                {
                    sentinelResult.next = new ListNode();
                    sentinelResult = sentinelResult.next;
                    sentinelResult.val = 1;
                }
                break;
            }

            sentinelResult.next = new ListNode();
            sentinelResult = sentinelResult.next;
        }

        return result;
    }
}
