/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(p);
        queue.Enqueue(q);
        while (queue.Count > 0) {
            var node1 = queue.Dequeue();
            var node2 = queue.Dequeue();
            if (node1?.val != node2?.val) {
                return false;
            }
            if (node1 is null) {
                continue;
            }
            queue.Enqueue(node1.left);
            queue.Enqueue(node2.left);
            
            queue.Enqueue(node1.right);
            queue.Enqueue(node2.right);
        }
        return true;
    }
}
