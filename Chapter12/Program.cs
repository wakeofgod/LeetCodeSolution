using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter12
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 中序遍历
            BinarySearchTree nums = new BinarySearchTree();
            nums.Insert(23);
            nums.Insert(45);
            nums.Insert(16);
            nums.Insert(37);
            nums.Insert(3);
            nums.Insert(99);
            nums.Insert(22);
            Console.WriteLine($"Inorder traversal: ");
            //nums.InOrder(nums.root);
            //nums.InOrderNoRecursion(nums.root);
            //nums.PreOrder(nums.root);
            //nums.PreOrderNoRecursion(nums.root);
            nums.PostOrder(nums.root);
            //nums.PostOrderNocursion(nums.root);
            //nums.PostOrderNocursion2(nums.root);
            //nums.LevelOrder(nums.root);
            #endregion
            Console.ReadLine();
        }
    }
    public class Node
    {
        public int Data;
        public Node left;
        public Node right;
        public void DisplayNode()
        {
            Console.Write($"{Data} ");
        }
    }
    public class BinarySearchTree
    {
        public Node root;
        public BinarySearchTree()
        {
            root = null;
        }
        public void Insert(int i)
        {
            Node newNode = new Node();
            newNode.Data = i;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (i < current.Data)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            break;
                        }
                    }
                }
            }
        }
        //中序遍历
        public void InOrder(Node theRoot)
        {
            if (theRoot != null)
            {
                InOrder(theRoot.left);
                theRoot.DisplayNode();
                InOrder(theRoot.right);
            }
        }
        //非递归中序遍历
        public void InOrderNoRecursion(Node theRoot)
        {
            if (theRoot == null)
                return;
            System.Collections.Generic.Stack<Node> stack = new Stack<Node>();
            Node node = theRoot;
            Console.WriteLine("开始非递归中序遍历:");
            while (node != null || stack.Any())
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    var item = stack.Pop();
                    Console.Write(item.Data);
                    node = item.right;
                }
            }
        }
        //先序遍历
        public void PreOrder(Node theRoot)
        {
            if (theRoot != null)
            {
                theRoot.DisplayNode();
                PreOrder(theRoot.left);
                PreOrder(theRoot.right);
            }
        }
        //先序遍历非递归
        public void PreOrderNoRecursion(Node theRoot)
        {
            if (theRoot == null)
                return;
            System.Collections.Generic.Stack<Node> stack = new Stack<Node>();
            Node node = theRoot;
            Console.WriteLine("开始非递归先序遍历:");
            while(node!=null || stack.Any())
            {
                if (node != null)
                {
                    stack.Push(node);
                    Console.Write($"{ node.Data} ");
                    node = node.left;
                }
                else
                {
                    var item = stack.Pop();
                    node = item.right;
                }
            }
        }
        //后序遍历
        public void PostOrder(Node theRoot)
        {
            if (theRoot != null)
            {
                PostOrder(theRoot.left);
                PostOrder(theRoot.right);
                theRoot.DisplayNode();
            }
        }
        //非递归后续遍历,比其他两种复杂一些
        public void PostOrderNocursion(Node theRoot)
        {
            if (theRoot == null)
                return;
            System.Collections.Generic.Stack<Node> stack = new Stack<Node>();
            Node node = theRoot;
            Node pre = null;
            stack.Push(node);
            Console.WriteLine("开始非递归后续遍历:");
            while (stack.Any())
            {
                node = stack.Peek();
                if( (node.left==null && node.right == null) || (pre!= null && (pre == node.left || pre == node.right)))
                {
                    Console.Write($"{node.Data} ");
                    pre = node;
                    stack.Pop();
                }
                else
                {
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }
                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }
                }
            }
        }

        public void PostOrderNocursion2(Node theRoot)
        {
            HashSet<Node> visited = new HashSet<Node>();
            Stack<Node> stack = new Stack<Node>();
            Node node = theRoot;
            Console.WriteLine("第二种非递归后续遍历:");
            while(node!=null || stack.Any())
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    var item = stack.Peek();
                    if(item.right!=null && !visited.Contains(item.right))
                    {
                        node = item.right;
                    }
                    else
                    {
                        Console.Write($"{ item.Data} ");
                        visited.Add(item);
                        stack.Pop();
                    }
                }
            }
        }
        //层序遍历
        //按照层次从左到右一层层的遍历
        public void LevelOrder(Node theRoot)
        {
            if (theRoot == null)
                return;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(theRoot);
            Console.WriteLine("开始层序遍历");
            while (queue.Any())
            {
                var item = queue.Dequeue();
                Console.Write($"{item.Data} ");
                if (item.left != null)
                {
                    queue.Enqueue(item.left);
                }
                if (item.right != null)
                {
                    queue.Enqueue(item.right);
                }
            }
        }

        #region Z-型层序遍历 待完成
        //查找树的层数
        public int GetDepth(Node tree,Node node)
        {
            if (tree == null)
                return 0;

            if (tree == node)
                return 1;

            if (tree.left == node || tree.right == node)
                return 2;

            int lDepth = GetDepth(tree.left, node);
            lDepth = lDepth == 0 ? 0 : lDepth + 1;

            int rDepth = GetDepth(tree.right, node);
            rDepth = rDepth == 0 ? 0 : rDepth + 1;

            return lDepth >= rDepth ? lDepth : rDepth;
        }

        #endregion
        //查找最小值
        public int FindMin()
        {
            Node current = root;
            while (current.left != null)
                current = current.left;
            return current.Data;
        }
        //查找最大值
        public int FindMax()
        {
            Node current = root;
            while (current.right != null)
                current = current.right;
            return current.Data;
        }
        //查找
        public Node Find(int key)
        {
            Node current = root;
            while (current.Data != key)
            {
                if (key < current.Data)
                    current = current.left;
                else
                    current = current.right;
                if (current == null)
                    return null;
            }
            return current;
        }

        //查找要删除节点的子节点
        public Node GetSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            Node current = delNode.right;
            while (current != null)
            {
                successorParent = current;
                successor = current;
                current = current.left;
            }
            if (successor != delNode.right)
            {
                successorParent.left = successor.right;
                successor.right = delNode.right;
            }
            return successor;
        }
        //删除子节点
        public bool Delete(int key)
        {
            Node current = root;
            Node parrent = root;
            bool isLeftChild = true;
            //第一步:while循环查找节点
            while(current.Data!=key)
            {
                //起始的时候parent和current相等，后面立马就不等了
                parrent = current;
                if (key < current.Data)
                {
                    isLeftChild = true;
                    current = current.left;
                }
                else
                {
                    isLeftChild = false;
                    current = current.right;
                }
                if (current == null)
                    return false;
            }
            //删除的节点是叶子
            if(current.left==null &&current.right==null)
            {
                if (current == root)
                    root = null;
                else if (isLeftChild)
                    parrent.left = null;
                else
                    parrent.right = null;
                return true;
            }
            //删除的节点只有一个子节点
            //删除的节点只有左树
            else if (current.right == null)
            {
                if (current == root)
                    root = current.left;
                else if (isLeftChild)
                    parrent.left = current.left;
                else
                    //parrent.right = current.right;
                    parrent.right = current.left;
            }
            //删除的节点只有右树
            else if (current.left == null)
            {
                if (current == root)
                    root = current.right;
                else if (isLeftChild)
                    parrent.left = current.right;
                else
                    parrent.right = current.right;
            }
            //删除的节点左右都有
            else
            {
                Node successor = GetSuccessor(current);
                if (current == root)
                    root = successor;
                else if (isLeftChild)
                    parrent.left = successor;
                else
                    parrent.right = successor;
                successor.left = current.left;
            }
            return true;
        }
    }
}
