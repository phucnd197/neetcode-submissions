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
    public TreeNode InvertTree(TreeNode root) {
        if (root is null) {
            return null;
        }
        if (root.left is not null) {
            root.left = InvertTree(root.left);
        }
        if (root.right is not null) {
            root.right = InvertTree(root.right);
        }
        var oldLeft = root.left;
        root.left = root.right;
        root.right = oldLeft;
        return root;
    }
}
