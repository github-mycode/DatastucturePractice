using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    public class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;

        public TreeNode()
        {

        }
        public TreeNode(int key)
        {
            this.data = key;
            this.left = null;
            this.right = null;
        }
        public TreeNode getTempTree()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(2);
            root.right = new TreeNode(5);
            root.left.left = new TreeNode(1);
            
            return root;

        }
        private static TreeNode tempPrev;
        public bool isBSTUtil(TreeNode root, TreeNode prev = null)
        {
            if(prev !=null)
            {
                tempPrev = null;
            }
            if(root != null)
            {
                if (isBSTUtil(root.left))
                    return false;
                if(tempPrev != null && root.data >= tempPrev.data)
                {
                    return false;
                }
                tempPrev = root;
                return isBSTUtil(root.right);
            }
            return true;
        }
    }

}