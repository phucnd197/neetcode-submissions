/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var pathP = new List<TreeNode>();
        var found = false;
        FindNode(root, p, pathP, ref found);
        if (!found) {
            return null;
        }

        var pathQ = new List<TreeNode>();
        found = false;
        FindNode(root, q, pathQ, ref found);

        if (!found) {
            return null;
        }

        var i = 0;
        var j = 0;
        TreeNode prev = null;
        while (i < pathP.Count && j < pathQ.Count) {
            var nodeP = pathP[i++];
            var nodeQ = pathQ[j++];
            if (nodeP != nodeQ) {
                break;
            }

            prev = nodeP;
        }

        return prev;
    }

    private static void FindNode(TreeNode root, TreeNode target, List<TreeNode> path,
                                ref bool found) {
        if (found) {
            return;
        }

        path.Add(root);

        if (root == target) {
            found = true;
            return;
        }

        if (root.left is not null) {
            FindNode(root.left, target, path, ref found);
        }

        if (found) {
            return;
        }

        if (root.right is not null) {
            FindNode(root.right, target, path, ref found);
        }

        if (!found) {
            path.RemoveAt(path.Count - 1);
        }
    }
}