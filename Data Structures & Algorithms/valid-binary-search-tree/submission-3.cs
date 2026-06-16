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
    public bool IsValidBST(TreeNode root) {
        return IsValidBST(root, long.MinValue, long.MaxValue);
    }

    public static bool IsValidBST(TreeNode root, long left, long right) {
        if (root == null) {
            return true;
        }

        if (root.val <= left || root.val >= right) {
            return false;
        }

        return IsValidBST(root.left, left, root.val) && IsValidBST(root.right, root.val, right);
    }
}
