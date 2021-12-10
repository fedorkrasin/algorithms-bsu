using System;

namespace lab2.BinaryTreeModel
{
    public class Node
    {
        public int Data;
        public Node LeftNode;
        public Node RightNode;

        public Node(int data)
        {
            Data = data;
        }
        
        public static int GetHeight(Node root) {
            if (root == null) return 0;
            
            return (int) (MathF.Max(GetHeight(root.LeftNode), GetHeight(root.RightNode)) + 1);
        }

        public override string ToString() => Data.ToString();
    }
}