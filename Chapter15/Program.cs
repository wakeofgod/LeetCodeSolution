using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter15
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    #region AVL树待完成
    //public class Node : IComparable
    //{
    //    public object element;
    //    public Node left;
    //    public Node right;
    //    public int height;
    //    public Node(Object data, Node lt, Node rt)
    //    {
    //        element = data;
    //        left = lt;
    //        right = rt;
    //        height = 0;
    //    }
    //    public Node(Object data)
    //    {
    //        element = data;
    //        left = null;
    //        right = null;
    //    }
    //    public int CompareTo(Object obj)
    //    {
    //        return (((int)element).CompareTo((int)obj));
    //    }
    //    public int GetHeight()
    //    {
    //        if (this == null)
    //            return -1;
    //        else
    //            return this.height;
    //    }
    //}

    //public class AVLTree
    //{
    //    public Node Head;
    //    public int Count;
    //    public Node Insert(Object item,Node n)
    //    {
    //        if (n == null)
    //            n = new Node(item, null, null);
    //        else if(((int)item).CompareTo((int)n.element)<0)
    //        {
    //            n.left = Insert(item, n.left);
    //            if (n.left.GetHeight() - n.right.GetHeight() == 2)
    //            {
    //                n = n.;
    //            }
    //        }
    //        return n;
    //    }

    //    public Node RotateWithLeftChild(Node n2)
    //    {
    //        Node n1 = n2.left;
    //        n2.left = n1.right;
    //        n1.right = n2;
    //        n2.height = Math.Max(n2.left.GetHeight(), n2.right.GetHeight()) + 1;
    //        n1.height = Math.Max(n1.left.GetHeight(), n2.height) + 1;
    //        return n1;
    //    }
    //    public Node RotateWithRightChild(Node n1)
    //    {
    //        Node n2 = n1.right;
    //        n1.right = n2.left;
    //        n2.left = n1;
    //        n1.height = Math.Max(n1.left.GetHeight(), n1.right.GetHeight() + 1);
    //        n2.height = Math.Max(n2.right.GetHeight(), n1.height) + 1;
    //        return n2;
    //    }
    //    public Node DoubleWithLeftChild(Node n3)
    //    {
    //        n3.left = RotateWithRightChild(n3.left);
    //        return RotateWithLeftChild(n3);
    //    }
    //    public Node DoubleWithRightChild(Node n1)
    //    {
    //        n1.right = RotateWithLeftChild(n1.right);
    //        return RotateWithRightChild(n1);
    //    }
    //}
    #endregion

    #region 红黑树
    //1树中的每个节点标记成红色或者黑色
    //2根节点是黑色
    //3如果某个节点是红色，那么它的子节点必须是黑色
    //4从一个节点到一个叶子节点的每一条路径都必须包含相同数量的黑色节点
    public class Node
    {
        public string element;
        public Node left;
        public Node right;
        public int color;
        const int RED = 0;
        const int BLACK = 1;
        public Node (string element,Node left,Node right)
        {
            this.element = element;
            this.left = left;
            this.right = right;
            this.color = BLACK;
        }
        public Node (string element)
        {
            this.element = element;
            this.color = BLACK;
        }
    }
    public class RBTree
    {
        const int RED = 0;
        const int BLACK = 1;
        public Node current;
        public Node parent;
        public Node grandParent;
        public Node greatParent;
        public Node header;
        public Node nullNode;
        public RBTree(string element)
        {
            current = new Node("");
            parent= new Node(""); 
            grandParent= new Node("");
            greatParent= new Node(""); 
            nullNode= new Node("");
            nullNode.left = nullNode;
            nullNode.right = nullNode;
            header = new Node(element);
            header.left = nullNode;
            header.right = nullNode;
        }
        public void Insert(string item)
        {
            grandParent = header;
            parent = grandParent;
            current = parent;
            nullNode.element = item;
            while (current.element.CompareTo(item) != 0)
            {
                Node greatParent = grandParent;
                grandParent = parent;
                parent = current;
                if (item.CompareTo(current.element) < 0)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
                if (current.left.color == RED && current.right.color == RED)
                    HandleReorient(item);
            }
            if (current != nullNode)
                current = new Node(item, nullNode, nullNode);
            if (item.CompareTo(parent.element) < 0)
                parent.left = current;
            else
                parent.right = current;
            HandleReorient(item);
        }

        public string FindMin()
        {
            if (this.IsEmpty())
                return null;
            Node itrNode = header.right;
            while (itrNode.left != nullNode)
                itrNode = itrNode.left;
            return itrNode.element;
        }

        public string FindMax()
        {
            if (this.IsEmpty())
                return null;
            Node itrNode = header.right;
            while (itrNode.right != nullNode)
                itrNode = itrNode.right;
            return itrNode.element;
        }

        public string Find(string e)
        {
            nullNode.element = e;
            Node current = header.right;
            while (true)
            {
                if (e.CompareTo(current.element) < 0)
                    current = current.left;
                else if (e.CompareTo(current.element) > 0)
                    current = current.right;
                else if (current != nullNode)
                    return current.element;
                else
                    return null;
            }
        }

        public void MakeEmpty()
        {
            header.right = nullNode;
        }

        public bool IsEmpty()
        {
            return header.right == nullNode;
        }

        public void PrintRNTree()
        {
            if (this.IsEmpty())
                Console.WriteLine("Empty");
            else
                PrintRB(header.right);
        }

        public void PrintRB(Node n)
        {
            if(n!=nullNode)
            {
                PrintRB(n.left);
                Console.WriteLine(n.element);
                PrintRB(n.right);
            }
        }

        public void HandleReorient(string item)
        {
            current.color = RED;
            current.left.color = BLACK;
            current.right.color = BLACK;
            if (parent.color == RED)
            {
                grandParent.color = RED;
                if((item.CompareTo(grandParent.element)<0)!= (item.CompareTo(parent.element) < 0))
                {
                    current = Rotate(item, grandParent);
                    current.color = BLACK;
                }
                header.right.color = BLACK;
            }
        }

        public Node Rotate(string item,Node parent)
        {
            if (item.CompareTo(parent.element) < 0)
            {
                if (item.CompareTo(parent.left.element) < 0)
                {
                    parent.left = RotateWithLeftChild(parent.left);
                }
                else
                {
                    parent.left = RotateWithRightChild(parent.left);
                }
                return parent.left;
            }
            else
            {
                if (item.CompareTo(parent.right.element) < 0)
                {
                    parent.right = RotateWithLeftChild(parent.right);
                }
                else
                {
                    parent.right = RotateWithRightChild(parent.right);
                }
                return parent.right;
            }
        }

        public Node RotateWithLeftChild(Node k2)
        {
            Node k1 = k2.left;
            k2.left = k1.right;
            k1.right = k2;
            return k1;
        }

        public Node RotateWithRightChild(Node k1)
        {
            Node k2 = k1.right;
            k1.right = k2.left;
            k2.left = k1;
            return k2;
        }
    }
    #endregion

    #region 跳跃表
    //由很多层构成，每一层都是一个有序的链表
    //最底层level 1链表包含所有元素
    //如果一个元素出现在level i的链表中，则它一定会出现在level i以下的链表中
    //每个节点包含两个指针，一个指向同一链表中的下一个元素，一个指向下一层的元素
    public class SkipNode
    {
        public int key;
        public Object value;
        public SkipNode[] link;
        public SkipNode(int level,int key,Object value)
        {
            this.key = key;
            this.value = value;
            link = new SkipNode[level];
        }
    }
    public class SkipList
    {
        public int maxLevel;
        public int level;
        public SkipNode header;
        public float probability;
        public const int NIL = Int32.MaxValue;
        public const float PROB = 0.5F;

        private void SkipList2(float probable,int maxLevel)
        {
            this.probability = probable;
            this.maxLevel = maxLevel;
            level = 0;
            header = new SkipNode(maxLevel, 0, null);
            SkipNode nilElement = new SkipNode(maxLevel, NIL, null);
            for (int i = 0; i < maxLevel; i++)
            {
                header.link[i] = nilElement;
            }
        }
        //传入节点总数量，调用私有方法，计算链表层数最大数量
        public SkipList(long maxNodes)
        {
            this.SkipList2(PROB,(int)(Math.Ceiling(Math.Log(maxNodes)/Math.Log(1/PROB)-1)));
        }

        public void Insert(int key,Object value)
        {
            SkipNode[] update = new SkipNode[maxLevel];
            SkipNode cursor = header;
            for (int i = level; i >=0; i--)
            {
                while (cursor.link[i].key < key)
                {
                    cursor = cursor.link[i];
                }
                update[i] = cursor;
            }
            cursor = cursor.link[0];
            if (cursor.key == key)
            {
                cursor.value = value;
            }
            else
            {
                int newLevel = GenRandomLevel();
                if (newLevel > level)
                {
                    for (int i = level; i < newLevel; i++)
                    {
                        update[i] = header;
                    }
                    level = newLevel;
                }
                cursor = new SkipNode(newLevel, key, value);
                for (int i = 0; i < newLevel; i++)
                {
                    cursor.link[i] = update[i].link[i];
                    update[i].link[i] = cursor;
                }
            }
        }

        private int GenRandomLevel()
        {
            int newLevel = 0;
            Random r = new Random();
            int ran = r.Next(0);
            while(newLevel <maxLevel && ran < probability)
            {
                newLevel++;
            }
            return newLevel;
        }

        public void Delete(int key)
        {
            SkipNode[] update = new SkipNode[maxLevel + 1];
            SkipNode cursor = header;
            for (int i = level; i >=0; i--)
            {
                while (cursor.link[i].key < key)
                {
                    cursor = cursor.link[i];
                }
                update[i] = cursor;
            }
            cursor = cursor.link[0];
            if (cursor.key == key)
            {
                for (int i = 0; i < level; i++)
                {
                    if (update[i].link[i] == cursor)
                    {
                        update[i].link[i] = cursor.link[i];
                    }
                    while(level>0 && header.link[level].key == NIL)
                    {
                        level--;
                    }
                }
            }
        }

        public Object Search(int key)
        {
            SkipNode cursor = header;
            for (int i = level; i >=0; i--)
            {
                SkipNode nextElement = cursor.link[i];
                while (nextElement.key < key)
                {
                    cursor = nextElement;
                    nextElement = cursor.link[i];
                }
            }
            cursor = cursor.link[0];
            if (cursor.key == key)
            {
                return cursor.value;
            }
            else
            {
                return " Object not found";
            }
        }
    }

    #endregion
}
