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
    public bool IsBalanced(TreeNode root) 
    {
        if(root is null) {
            return true;
        }
        var isBalanced = true;
        IsBalanced(root, ref isBalanced);
        return isBalanced;
    }

    public static int IsBalanced(TreeNode root, ref bool isBalanced)
    {
        var left = root.left is null ? 0 : IsBalanced(root.left, ref isBalanced) + 1;
        var right = root.right is null ? 0 : IsBalanced(root.right, ref isBalanced) + 1;

        if (Math.Abs(left - right) > 1)
        {
            isBalanced = false;
        }

        return Math.Max(left, right);
    }
}
