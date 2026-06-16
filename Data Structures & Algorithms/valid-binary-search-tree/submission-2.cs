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
        if (root is null) {
            return true;
        }
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var newRoot = new TreeNode(root.val);
        while (queue.Count > 0) {
            var node = queue.Dequeue();
            if (node is null) {
                continue;
            }
            if (node != root) {
                var result = Insert(newRoot, node.val);
                if (!result) {
                    return false;
                }
            }
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        queue.Clear();
        queue.Enqueue(root);
        queue.Enqueue(newRoot);
        while (queue.Count > 0) {
            var node1 = queue.Dequeue();
            var node2 = queue.Dequeue();
            if (node1.val != node2.val) {
                return false;
            }

            var hasLeft1 = node1.left is not null;
            var hasLeft2 = node2.left is not null;

            if (hasLeft1 ^ hasLeft2) {
                return false;
            }

            if (hasLeft1) {
                queue.Enqueue(node1.left);
                queue.Enqueue(node2.left);
            }

            var hasRight1 = node1.right is not null;
            var hasRight2 = node2.right is not null;
            if (hasRight1 ^ hasRight2) {
                return false;
            }

            if (hasRight1) {
                queue.Enqueue(node1.right);
                queue.Enqueue(node2.right);
            }
        }

        return true;
    }

    private static bool Insert(TreeNode root, int val) {
        if (val < root.val) {
            if (root.left is null) {
                root.left = new TreeNode(val);
                return true;
            }
            return Insert(root.left, val);
        }
        if (val > root.val) {
            if (root.right is null) {
                root.right = new TreeNode(val);
                return true;
            }
            return Insert(root.right, val);
        }
        return false;
    }
}
