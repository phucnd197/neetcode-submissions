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
    public int DiameterOfBinaryTree(TreeNode root) 
    {
        if (root is null)
        {
            return 0;
        }

        var sentinel = root;
        var countFromRoot = 0;
        while (sentinel != null)
        {
            if (sentinel.left != null && sentinel.right != null)
            {
                break;
            }
            else if (sentinel.left != null)
            {
                countFromRoot++;
                sentinel = sentinel.left;
            }
            else if (sentinel.right != null)
            {
                countFromRoot++;
                sentinel = sentinel.right;
            }
            else
            {
                sentinel = null;
            }
        }
        if (sentinel == null)
        {
            return countFromRoot;
        }

        var left = LongestPath(sentinel.left);
        var right = LongestPath(sentinel.right);
        return left + right;
    }

    private static int LongestPath(TreeNode? node)
    {
        if (node == null)
        {
            return 0;
        }
        var left = LongestPath(node.left) + 1;
        var right = LongestPath(node.right) + 1;
        return Math.Max(left, right);
    }
}
