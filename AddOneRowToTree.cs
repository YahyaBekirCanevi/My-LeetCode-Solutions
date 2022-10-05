/**
 * Definition for a binary tree node.
  */
public class AddOneRowToTree
{
    public TreeNode? AddOneRow(TreeNode? root, int val, int depth)
    {
        if (root == null) return null;
        if (depth == 1) return new TreeNode(val, root, null);
        depth--;
        if (depth == 1)
        {
            TreeNode? newLeft = new TreeNode(val, root.left, null);
            TreeNode? newRight = new TreeNode(val, null, root.right);
            root.left = newLeft;
            root.right = newRight;
        }
        else
        {
            root.left = AddOneRow(root.left, val, depth);
            root.right = AddOneRow(root.right, val, depth);
        }
        return root;
    }
}