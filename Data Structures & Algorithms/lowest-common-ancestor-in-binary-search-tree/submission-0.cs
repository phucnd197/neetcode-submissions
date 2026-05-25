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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var iterations = new Queue<TreeNode>();
        iterations.Enqueue(root);
        while (iterations.Count > 0) {
            var node = iterations.Dequeue();

            // found either node then return the earliest node
            if (p.val == node.val || q.val == node.val) {
                return node;
            }

            // 1 => left
            // 2 => right
            var pPath = p.val < node.val ? 1 : 0;
            var qPath = q.val < node.val ? 1 : 0;
            if (pPath != qPath) {
                return node;
            }

            if (node.left is not null) {
                iterations.Enqueue(node.left);
            }

            if(node.right is not null) {
                iterations.Enqueue(node.right);
            }
        }
        return null;
    }
}
