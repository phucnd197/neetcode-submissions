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
    public int DiameterOfBinaryTree(TreeNode root) {
        if (root is null) {
            return 0;
        }
        var diameter = 0;
        Depth(root, ref diameter);
        return diameter;
    }
    public int Depth(TreeNode root, ref int diameter) {
        if (root is null) {
            return 0;
        }
        var leftDepth = root.left is not null ? 1 + Depth(root.left, ref diameter) : 0;
        var rightDepth = root.right is not null ? 1 + Depth(root.right, ref diameter) : 0;
        diameter = Math.Max(diameter, leftDepth + rightDepth);
        return Math.Max(leftDepth, rightDepth);
    }
}
