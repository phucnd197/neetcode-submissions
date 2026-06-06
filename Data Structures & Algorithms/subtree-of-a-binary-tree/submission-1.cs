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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        var nodes = new Queue<TreeNode>();
        nodes.Enqueue(root);
        var compareNodes = new List<TreeNode>();
        while (nodes.Count > 0)
        {
            var node = nodes.Dequeue();
            if (node.val == subRoot.val)
            {
                compareNodes.Add(node);
            }

            var nodeHasLeft = node.left is not null;
            if (nodeHasLeft)
            {
                nodes.Enqueue(node.left!);
            }

            var nodeHasRight = node.right is not null;
            if (nodeHasRight)
            {
                nodes.Enqueue(node.right!);
            }
        }

        if (compareNodes.Count == 0)
        {
            return false;
        }

        for (var i = 0; i < compareNodes.Count; i++)
        {
            var compareNode = compareNodes[i];
            nodes.Clear();
            nodes.Enqueue(compareNode);
            nodes.Enqueue(subRoot);
            
            var foundSubTree = true;
            while (nodes.Count > 0)
            {
                var rootNode = nodes.Dequeue();
                var subRootNode = nodes.Dequeue();
                if (rootNode.val != subRootNode.val)
                {
                    foundSubTree = false;
                    break;
                }

                var hasLeftRoot = rootNode.left is not null;
                var hasLeftSub = subRootNode.left is not null;
                if (hasLeftSub ^ hasLeftRoot)
                {
                    foundSubTree = false;
                    break;
                }

                if (hasLeftSub)
                {
                    nodes.Enqueue(rootNode.left!);
                    nodes.Enqueue(subRootNode.left!);
                }

                var hasRightRoot = rootNode.right is not null;
                var hasRightSub = subRootNode.right is not null;

                if (hasRightSub ^ hasRightRoot)
                {
                    foundSubTree = false;
                    break;
                }

                if (hasRightSub)
                {
                    nodes.Enqueue(rootNode.right!);
                    nodes.Enqueue(subRootNode.right!);
                }
            }

            if (foundSubTree)
            {
                return true;
            }
        }

        return false;
    }
}
