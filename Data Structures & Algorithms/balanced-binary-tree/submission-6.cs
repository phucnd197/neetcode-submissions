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
    public bool IsBalanced(TreeNode root) {
        if (root is null || (root.left is null && root.right is null)) {
            return true;
        }
        var balanced = true;
        FindLength(root, ref balanced);
        return balanced;
    }

    private static int FindLength(TreeNode root, ref bool balanced) {
        if (root is null || !balanced) {
            return 0;
        }
        var left = 0;
        var right = 0;
        if (root.left is not null) {
            left = 1 + FindLength(root.left, ref balanced);
        }
        if (root.right is not null) {
            right = 1 + FindLength(root.right, ref balanced);
        }
        if (left > right ? left - right > 1 : right - left > 1) {
            balanced = false;
        }
        return left > right ? left : right;
    }
}
