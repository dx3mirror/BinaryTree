using System;
using System.Collections.Generic;


namespace BinaryTreeHHRU
{
    class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }

        public class BinarySearchTree
        {
            public Node Root { get; private set; }

            public void Insert(int value)
            {
                Node newNode = new Node(value);

                if (Root == null)
                {
                    Root = newNode;
                    return;
                }

                Node current = Root;
                while (true)
                {
                    if (value < current.Value)
                    {
                        if (current.Left == null)
                        {
                            current.Left = newNode;
                            return;
                        }
                        current = current.Left;
                    }
                    else
                    {
                        if (current.Right == null)
                        {
                            current.Right = newNode;
                            return;
                        }

                        current = current.Right;
                    }
                }
            }

            public void PreorderTraversal(Action<Node> visitAction)
            {
                PreorderTraversal(Root, visitAction);
            }

            private void PreorderTraversal(Node node, Action<Node> visitAction)
            {
                if (node == null)
                    return;
                visitAction(node);
                PreorderTraversal(node.Left, visitAction);
                PreorderTraversal(node.Right, visitAction);
            }

            public void BreadthFirstTraversal(Action<Node> visitAction)
            {
                Queue<Node> nodesQueue = new Queue<Node>();
                nodesQueue.Enqueue(Root);
                while (nodesQueue.Count != 0)
                {
                    Node currentNode = nodesQueue.Dequeue();
                    visitAction(currentNode);

                    if (currentNode.Left != null)
                        nodesQueue.Enqueue(currentNode.Left);
                    if (currentNode.Right != null)
                        nodesQueue.Enqueue(currentNode.Right);
                }
            }
        }
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(4);
            bst.Insert(6);

            bst.PreorderTraversal(node => Console.Write(node.Value + " ")); //=> 10 5 4 6 15
            Console.WriteLine();

            bst.BreadthFirstTraversal(node => Console.Write(node.Value + " ")); //=> 10 5 15 4 6
            Console.ReadKey();
        }
    }
}
