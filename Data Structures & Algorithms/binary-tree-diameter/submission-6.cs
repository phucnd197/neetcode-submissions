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
        DFS(root, ref diameter);
        return diameter;
    }
    public int DFS(TreeNode root, ref int diameter) {
        if (root is null) {
            return 0;
        }
        var leftDepth = root.left is not null ? DFS(root.left, ref diameter) : 0;
        var rightDepth = root.right is not null ?  DFS(root.right, ref diameter) : 0;
        diameter = Math.Max(diameter, leftDepth + rightDepth);
        return 1 + Math.Max(leftDepth, rightDepth);
    }
}
