using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter11
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList MyList = new LinkedList();
            ListIter iter = new ListIter(MyList);
            string choice, value;
            try
            {
                iter.InsertAfter("David");
                iter.InsertAfter("Mike");
                iter.InsertAfter("Raymond");
                iter.InsertAfter("Bernica");
                iter.InsertAfter("Jennifer");
                iter.InsertAfter("Donnie");
                iter.InsertAfter("Michael");
                iter.InsertAfter("Terrill");
                iter.InsertAfter("Mayo");
                iter.InsertAfter("Clayton");
                while (true)
                {
                    Console.WriteLine("(n) Move to next node");
                    Console.WriteLine("(g) Get value in current node");
                    Console.WriteLine("(r) Reset iterator");
                    Console.WriteLine("(s) Show complete list");
                    Console.WriteLine("(a) Insert after");
                    Console.WriteLine("(b) Insert before");
                    Console.WriteLine("(c) Clear the screen");
                    Console.WriteLine("(x) Exit");
                    Console.WriteLine();
                    Console.WriteLine("Enter your choice");
                    choice = Console.ReadLine();
                    choice = choice.ToLower();
                    char[] onechar = choice.ToCharArray();
                    switch (onechar[0])
                    {
                        case 'n':
                            if (!MyList.IsEmpty() && (!iter.AtEnd()))
                                iter.NextLink();
                            else
                                Console.WriteLine("Cant move to next link");
                            break;
                        case 'g':
                            if(!MyList.IsEmpty())
                                Console.WriteLine($"Element: {iter.GetCurrent().Element}");
                            else
                                Console.WriteLine("List it empty");
                            break;
                        case 'r':
                            iter.Reset();
                            break;
                        case 's':
                            if (!MyList.IsEmpty())
                                MyList.ShowList();
                            else
                                Console.WriteLine("List is empty");
                            break;
                        case 'a':
                            Console.WriteLine();
                            Console.WriteLine("Enter value to insert");
                            value = Console.ReadLine();
                            iter.InsertAfter(value);
                            break;
                        case 'b':
                            Console.WriteLine();
                            Console.WriteLine("Enter value to insert");
                            value = Console.ReadLine();
                            iter.InsertBefore(value);
                            break;
                        case 'c':
                            // clear the screen
                            break;
                        case 'x':
                            //end of program
                            break;
                    }
                }
            }
            catch(InsertBeforeHeaderException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    #region 普通链表
    //public class Node
    //{
    //    public Object Element;
    //    public Node Link;
    //    public Node()
    //    {
    //        Element = null;
    //        Link = null;
    //    }
    //    public Node(Object theElement)
    //    {
    //        Element = theElement;
    //        Link = null;
    //    }
    //}

    //public class LinkedList
    //{
    //    protected Node header;
    //    public LinkedList()
    //    {
    //        header = new Node("header");
    //    }

    //    public Node Find(Object item)
    //    {
    //        Node current = new Node();
    //        current = header;
    //        while (current.Element != item)
    //        {
    //            current = current.Link;
    //        }
    //        return current;
    //    }
    //    public Node FindPrevious(Object n)
    //    {
    //        Node current = header;
    //        while (!(current.Link == null) && current.Link != n)
    //            current = current.Link;
    //        return current;
    //    }
    //    public void Insert(Object newItem,Object after)
    //    {
    //        Node current = new Node();
    //        Node newNode = new Node(newItem);
    //        current = Find(after);
    //        newNode.Link = current.Link;
    //        current.Link = newNode;
    //    }
    //    public void Remove(Object n)
    //    {
    //        Node p = FindPrevious(n);
    //        if (p.Link != null)
    //            p.Link = p.Link.Link;
    //    }
    //    public void PrintList()
    //    {
    //        Node current = new Node();
    //        current = header;
    //        while (current.Link != null)
    //        {
    //            Console.WriteLine(current.Link.Element);
    //            current = current.Link;
    //        }          
    //    }
    //}
    #endregion

    #region 双向链表
    //public class Node
    //{
    //    public Object Element;
    //    //指向下一个节点的链接
    //    public Node Flink;
    //    //指向前一个节点的链接
    //    public Node Blink;
    //    public Node()
    //    {
    //        Element = null;
    //        Flink = null;
    //        Blink = null;
    //    }
    //    public Node(Object theElement)
    //    {
    //        Element = theElement;
    //        Flink = null;
    //        Blink = null;
    //    }
    //    public Node Find(Object item)
    //    {
    //        Node node = new Node();
    //        while (node.Element != item)
    //            node = node.Flink;
    //        return node;
    //    }
    //    public void Insert(Object newItem,Object after)
    //    {
    //        Node current = new Node();
    //        Node newNode = new Node(newItem);
    //        current = Find(after);
    //        newNode.Flink = current.Flink;
    //        newNode.Blink = current;
    //        current.Flink = newNode;
    //    }
    //    public void Remove(Object n)
    //    {
    //        Node p = Find(n);
    //        if(p.Flink!=null)
    //        {
    //            p.Blink.Flink = p.Flink;
    //            p.Flink.Blink = p.Blink;
    //            p.Flink = null;
    //            p.Blink = null;
    //        }
    //    }
    //    public Node FindLast()
    //    {
    //        Node current = new Node();
    //        while (current.Flink != null)
    //            current = current.Flink;
    //        return current;
    //    }
    //    public void PrintReverse()
    //    {
    //        Node current = new Node();
    //        current = FindLast();
    //        while(current.Blink!=null)
    //        {
    //            Console.WriteLine(current.Element);
    //            current = current.Blink;
    //        }
    //    }
    //}

    #endregion

    #region 循环链表
    //public class Node
    //{
    //    public Object Element;
    //    public Node Link;
    //    public Node()
    //    {
    //        Element = null;
    //        Link = null;
    //    }
    //    public Node(Object theElement)
    //    {
    //        Element = theElement;
    //        Link = null;
    //    }
    //}

    //public class LinkedList
    //{
    //    public Node current;
    //    public Node header;
    //    public int count;
    //    //创建新链表的时候 第一个节点指向自身
    //    public LinkedList()
    //    {
    //        count = 0;
    //        header = new Node("header");
    //        header.Link = header;
    //    }
    //    public bool IsEmpty()
    //    {
    //        return header.Link == null;
    //    }
    //    public void MakeEmpty()
    //    {
    //        header.Link = null;
    //    }
    //    public void PrintList()
    //    {
    //        Node current = new Node();
    //        current = header;
    //        while (current.Link.Element.ToString() != "header")
    //        {
    //            Console.WriteLine(current.Link.Element);
    //            current = current.Link;
    //        }
    //    }
    //    public Node FindPrevious(Object n)
    //    {
    //        Node current = header;
    //        while (current.Link != null && current.Link.Element != n)
    //            current = current.Link;
    //        return current;
    //    }
    //    public Node Find(Object n)
    //    {
    //        Node currrent = new Node();
    //        current = header.Link;
    //        while (current.Element != n)
    //            current = current.Link;
    //        return current;
    //    }
    //    public void Remove(Object n)
    //    {
    //        Node p = FindPrevious(n);
    //        if (p.Link != null)
    //            p.Link = p.Link.Link;
    //        count--;
    //    }
    //    public void Insert(Object n1,Object n2)
    //    {
    //        Node current = new Node();
    //        Node newnode = new Node(n1);
    //        current = Find(n2);
    //        newnode.Link = current.Link;
    //        current.Link = newnode;
    //        count++;
    //    }
    //    public void InsertFirst(Object n)
    //    {
    //        Node current = new Node(n);
    //        current.Link = header;
    //        header.Link = current;
    //        count++;
    //    }
    //    public Node Move(int n)
    //    {
    //        Node current = header.Link;
    //        Node temp;
    //        for (int i = 0; i <=n; i++)
    //        {
    //            current = current.Link;
    //        }
    //        if (current.Element.ToString() == "header")
    //        {
    //            current = current.Link;
    //        }
    //        temp = current;
    //        return temp;
    //    }
    //    public Node getFirst()
    //    {
    //        return header;
    //    }
    //}
    #endregion

    #region Iterator类
    public class Node
    {
        public Object Element;
        public Node Link;
        public Node()
        {
            Element = null;
            Link = null;
        }
        public Node(Object theElement)
        {
            Element = theElement;
            Link = null;
        }
    }
    public class InsertBeforeHeaderException : System.ApplicationException
    {
        public InsertBeforeHeaderException(string message) : base(message)
        {

        }
    }
    public class LinkedList
    {
        public Node header;
        public LinkedList()
        {
            header = new Node("header");
        }
        public bool IsEmpty()
        {
            return header.Link == null;
        }
        public Node GetFirst()
        {
            return header;
        }
        public void ShowList()
        {
            Node current = header.Link;
            while (current != null)
            {
                Console.WriteLine(current.Element);
                current = current.Link;
            }
        }
    }
    public class ListIter
    {
        public Node current;
        public Node previous;
        LinkedList theList;
        public ListIter(LinkedList list)
        {
            theList = list;
            current = theList.GetFirst();
            previous = null;
        }
        public void NextLink()
        {
            previous = current;
            current = current.Link;
        }
        public Node GetCurrent()
        {
            return current;
        }
        public void InsertBefore(Object theElement)
        {
            Node newNode = new Node(theElement);
            if (previous.Link == null)
                throw new InsertBeforeHeaderException("Cant insert here");
            else
            {
                newNode.Link = previous.Link;
                previous.Link = newNode;
                current = newNode;
            }
        }
        public void InsertAfter(Object theElement)
        {
            Node newNode = new Node(theElement);
            newNode.Link = current.Link;
            current.Link = newNode;
            NextLink();
        }
        public void Remove()
        {
            previous.Link = current.Link;
        }
        public void Reset()
        {
            current = theList.GetFirst();
            previous = null;
        }
        public bool AtEnd()
        {
            return current.Link == null;
        }
    }

    #endregion
}
