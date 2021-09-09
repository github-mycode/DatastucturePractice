using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    public class BinaryTreeNode
    {
        public int data;
        public BinaryTreeNode left;
        public BinaryTreeNode right;
        public BinaryTreeNode(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
        public static BinaryTreeNode getTestTree()
        {
            BinaryTreeNode root = new BinaryTreeNode(1);

            BinaryTreeNode rootLeft = new BinaryTreeNode(2);
            root.setLeft(rootLeft);
            BinaryTreeNode rootRight = new BinaryTreeNode(3);
            root.setRight(rootRight);


            BinaryTreeNode rootLeftLeft = new BinaryTreeNode(4);
            rootLeft.setLeft(rootLeftLeft);
            BinaryTreeNode rootLeftRight = new BinaryTreeNode(5);
            rootLeft.setRight(rootLeftRight);

            BinaryTreeNode rootRightLeft = new BinaryTreeNode(6);
            rootRight.setLeft(rootRightLeft);
            BinaryTreeNode rootRightRight = new BinaryTreeNode(7);
            rootRight.setRight(rootRightRight);
            return root;
        }
        public int getData()
        {
            return this.data;
        }
        public void setData(int data)
        {
            this.data = data;
        }
        public BinaryTreeNode getLeft()
        {
            return this.left;
        }
        public void setLeft(BinaryTreeNode left)
        {
            this.left = left;
        }
        public BinaryTreeNode getRight()
        {
            return this.right;
        }
        public void setRight(BinaryTreeNode right)
        {
            this.right = right;
        }

        public static void PreOrderTraversal(BinaryTreeNode root)
        {
            if(root == null)
            {
                return;
            }
            Console.WriteLine(root.data);
            PreOrderTraversal(root.left);
            PreOrderTraversal(root.right);
        }

        public static void PreOrderTraversalNonRecur(BinaryTreeNode root)
        {
            Stack<BinaryTreeNode> s = new Stack<BinaryTreeNode>();
            s.Push(root);
            while (s.Count > 0)
            {
                BinaryTreeNode node = s.Pop();
                Console.WriteLine(node.data);
                if (node.right != null)
                {
                    s.Push(node.right);
                }
                if (node.left != null)
                {
                    s.Push(node.left);
                }
            }
        }
        public static void InOrderTraversal(BinaryTreeNode root)
        {
            if (root == null)
            {
                return;
            }
            InOrderTraversal(root.left);
            Console.WriteLine(root.data);
            InOrderTraversal(root.right);
        }
        //public static void InOrderTraversalNonRecur(BinaryTreeNode root)
        //{
        //    Stack<BinaryTreeNode> s = new Stack<BinaryTreeNode>();
        //    BinaryTreeNode node = root;
        //    s.Push(node);
        //    while (s.Count > 0)
        //    {
        //        if (node.left != null)
        //        {
        //            node = node.left;
        //            s.Push(node);
        //        }
        //        else
        //        {
        //            BinaryTreeNode temp = s.Pop();
        //            Console.WriteLine(temp.data);

        //            if(temp.right != null)
        //            {
        //                s.Push(node.right);
        //            }
        //            else
        //            {
        //                temp = s.Pop();
        //                Console.WriteLine(temp.data);
        //            }
        //            node = temp;
        //        }
        //    }
        //}

        public static void InOrderTraversalNonRecur(BinaryTreeNode root)
        {
            Stack<BinaryTreeNode> s = new Stack<BinaryTreeNode>();
            BinaryTreeNode node = root;
            while (true)
            {
                if (node != null)
                {
                    s.Push(node);
                    node = node.left;
                }
                else
                {
                    if (s.Count <= 0)
                    {
                        break;
                    }
                    BinaryTreeNode temp = s.Pop();
                    Console.WriteLine(temp.data);
                    node = temp.right;
                }
            }
        }
        public static void PreOrderTraversalNonRecurNew(BinaryTreeNode root)
        {
            Stack<BinaryTreeNode> s = new Stack<BinaryTreeNode>();
            BinaryTreeNode node = root;
            while (true)
            {
                if (node != null)
                {
                    s.Push(node);
                    Console.WriteLine(node.data);
                    node = node.left;
                }
                else
                {
                    if (s.Count <= 0)
                    {
                        break;
                    }
                    BinaryTreeNode temp = s.Pop();

                    node = temp.right;
                }
            }
        }
        public static void PostOrderTraversal(BinaryTreeNode root)
        {
            if (root == null)
            {
                return;
            }
            PostOrderTraversal(root.left);
            PostOrderTraversal(root.right);
            Console.WriteLine(root.data);
        }
        public static void PostOrderTraversalNonRecurTwoStack(BinaryTreeNode root)
        {
            Stack<BinaryTreeNode> s1 = new Stack<BinaryTreeNode>();
            Stack<BinaryTreeNode> s2 = new Stack<BinaryTreeNode>();

            s1.Push(root);
            while(s1.Count > 0)
            {
                if(root.left != null)
                    s1.Push(root.left);
                if(root.right != null)
                    s1.Push(root.right);
                s2.Push(root);
                root = s1.Pop();
            }
            while(s2.Count > 0)
            {
                Console.WriteLine(s2.Pop().data);
            }
        }
        public static void PostOrderTraversalNonRecur(BinaryTreeNode root)
        {
            Stack<BinaryTreeNode> s = new Stack<BinaryTreeNode>();
            BinaryTreeNode curr = root;
            //s.Push(root);
            while(s.Count > 0 || curr != null)
            {
                if(curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }
                else
                {
                    BinaryTreeNode temp = s.Peek().right;
                    if(temp == null)
                    {
                        temp = s.Pop();
                        Console.WriteLine(temp.data);
                        while(s.Count > 0 && s.Peek().right == null)
                        {
                            temp = s.Pop();
                            Console.WriteLine(temp.data);
                        }
                    }
                    else
                    {
                        curr = temp;
                    }
                }
            }
        }
        public static void postOrderItrOneStack(BinaryTreeNode root)
        {
            BinaryTreeNode current = root;
            Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
            while (current != null || stack.Count > 0)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                else
                {
                    BinaryTreeNode temp = stack.Peek().right;
                    if (temp == null)
                    {
                        temp = stack.Pop();
                        Console.WriteLine(temp.data + " ");
                        while (stack.Count>0 && temp == stack.Peek().right)
                        {
                            temp = stack.Pop();
                            Console.WriteLine(temp.data + " ");
                        }
                    }
                    else
                    {
                        current = temp;
                    }
                }
            }
        }

        public static void levelOrderTraversal(BinaryTreeNode root)
        {
            Queue<BinaryTreeNode> q = new Queue<BinaryTreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                BinaryTreeNode temp = q.Dequeue();
                Console.WriteLine(temp.data); 
                if(temp.left != null)
                {
                    q.Enqueue(temp.left);
                }
                if (temp.right != null)
                {
                    q.Enqueue(temp.right);
                }
            }
        }

        public static int findMaxRecur(BinaryTreeNode root)
        {
            int maxVal = int.MinValue;
            if(root != null)
            {
                int leftMax = findMaxRecur(root.left);
                int rightMax = findMaxRecur(root.right);
                if(leftMax > rightMax)
                {
                    maxVal = leftMax;
                }
                else
                {
                    maxVal = rightMax;
                }
                if(root.data > maxVal)
                {
                    maxVal = root.data;
                }
            }
            return maxVal;
        }

        public static bool findValRecur(BinaryTreeNode root, int data)
        {
            if(root == null)
            {
                return false;
            }
            if(root.data == data)
            {
                return true;
            }
            return findValRecur(root.left, data) || findValRecur(root.right, data);
        }
    }
}
