using System;
using System.Collections.Generic;

namespace lab2.BinaryTreeModel
{
    public class BinaryTree
    {
        public Node Root;

        public BinaryTree(int value)
        {
            Root = new Node(value);
        }

        // Add Node
        public void Add(int value)
        {
            var child = new Node(value);
            AddNode(child);
        }
        
        public void Add(params int[] values)
        {
            foreach (var value in values)
            {
                Add(value);
            }
        }

        private void AddNode(Node item)
        {
            if (Root == null)
            {
                Root = item;
            }
            else
            {
                AddChildNode(Root, item);
            }
        }

        private static void AddChildNode(Node node, Node child)
        {
            if (child.Data < node.Data)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = child;
                }
                else
                {
                    AddChildNode(node.LeftNode, child);
                }
            }
            else
            {
                if (node.RightNode == null)
                {
                    node.RightNode = child;
                }
                else
                {
                    AddChildNode(node.RightNode, child);
                }
            }
        }
        
        // Traversals
        public string PreOrder()
        {
            return PreOrder(Root);
        }
        
        public string InOrderLeft()
        {
            return InOrderLeft(Root);
        }
        
        public string InOrderRight()
        {
            return InOrderRight(Root);
        }

        public string OutOrder()
        {
            return OutOrder(Root);
        }
        
        public static string PreOrder(Node root)
        {
            var str = "";
            
            if (root != null)
            {
                str += root.Data + ", ";
                str += PreOrder(root.LeftNode);
                str += PreOrder(root.RightNode);
            }

            return str;
        }
        
        public static string InOrderLeft(Node root)
        {
            var str = "";
            
            if (root != null)
            {
                str += InOrderLeft(root.LeftNode);
                str += root.Data + ", ";
                str += InOrderLeft(root.RightNode);
            }

            return str;
        }

        public static string InOrderRight(Node root)
        {
            var str = "";
            
            if (root != null)
            {
                str += InOrderRight(root.RightNode);
                str += root.Data + ", ";
                str += InOrderRight(root.LeftNode);
            }

            return str;
        }

        public static string OutOrder(Node root)
        {
            var str = "";
            
            if (root != null)
            {
                str += OutOrder(root.LeftNode);
                str += OutOrder(root.RightNode);
                str += root.Data + ", ";
            }

            return str;
        }
        
        // Search
        public Node KthSmallestElement(int k)
        {
            return KthSmallestElement(Root, k);
        }
        
        public static Node KthSmallestElement(Node root, int k)
        {
            var count = Count(root.LeftNode);
            
            if (count + 1 == k) return root;
            if (k <= count) return KthSmallestElement(root.LeftNode, k);
            return KthSmallestElement(root.RightNode, k - count - 1);
        }
        
        private static int Count(Node root) 
        {
            if (root == null) return 0;
            return 1 + Count(root.LeftNode) + Count(root.RightNode);
        }
        
        private int HeightFromNodeToNode(Node startingNode, Node endingNode)
        {
            var node = startingNode;
            var height = 0;
            while (node.Data != endingNode.Data)
            {
                height++;
                if (endingNode.Data <= node.Data)
                {
                    node = node.LeftNode;
                }
                else
                {
                    node = node.RightNode;
                }
            }

            return height;
        }

        public void BalanceBinaryTree()
        {
            BalanceBinaryTree(Root);
        }
        
        private void BalanceBinaryTree(Node current)
        {
            var middleIndex = (Count(current.LeftNode) + 1 + Count(current.RightNode)) / 2;
            var middle = KthSmallestElement(current, middleIndex);
            var heightFromCurrentNodeToMiddleNode = HeightFromNodeToNode(current, middle);

            if (middle != null)
            {
                for (var i = 0; i < heightFromCurrentNodeToMiddleNode - 2; i++)
                {
                    if (middle.Data <= current.Data) RotateRight(current);
                    else RotateLeft(current);
                }

                if (middle.LeftNode != null && middle.RightNode != null)
                {
                    BalanceBinaryTree(middle.LeftNode);
                    BalanceBinaryTree(middle.RightNode);
                }
            }
        }

        public void RotateLeft(Node root)
        {
            var pivot = root.RightNode;
            root.RightNode = pivot.LeftNode;
            pivot.LeftNode = root;
            if (root == Root) Root = pivot;
        }

        public void RotateRight(Node parent)
        {
            var pivot = parent.LeftNode;
            parent.LeftNode = pivot.RightNode;
            pivot.RightNode = parent;
            if (parent == Root) Root = pivot;
        }
    }
}