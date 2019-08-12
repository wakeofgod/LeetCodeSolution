using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            bool aBoolean = true;
            char aCharacter = '#';
            int anInteger = 9258;
            string aString = "DataStructure";

            list.InsertAtFront(aBoolean);
            list.Display();
            list.InsertAtFront(aCharacter);
            list.Display();
            list.InsertAtBack(anInteger);
            list.Display();
            list.InsertAtBack(aString);
            list.Display();

            object removedObject;

            try
            {
                removedObject = list.RemoveFromFront();
                Console.WriteLine(removedObject + " removed");
                Console.WriteLine($"Remove form front");
                list.Display();

                removedObject = list.RemoveFromFront();
                Console.WriteLine(removedObject + " removed");
                Console.WriteLine($"Remove form front");
                list.Display();


                removedObject = list.RemoveFromBack();
                Console.WriteLine(removedObject + " removed");
                Console.WriteLine($"Remove form back");
                list.Display();

                removedObject = list.RemoveFromBack();
                Console.WriteLine(removedObject + " removed");
                Console.WriteLine($"Remove form back");
                list.Display();
            }
            catch (EmptyListException emptyListException)
            {
                Console.Error.WriteLine("\n" + emptyListException);
            }

            Console.ReadLine();
        }
    }
        //链表的节点类
        public class LinkedListNode
        {
            public object Data { get; set; }
            public LinkedListNode Next { get; set; }
            public LinkedListNode(object dataValue):this(dataValue,null)
            {

            }
            public LinkedListNode(object dataValue,LinkedListNode nextNode)
            {
                Data = dataValue;
                Next = nextNode;
            }
        }
        //链表类
        public class LinkedList
        {
            public LinkedListNode firstNode { get; set; }
            public LinkedListNode lastNode { get; set; }
            public string Name { get; set; }

            public LinkedList(string listName)
            {
                Name = listName;
                firstNode = lastNode = null;
            }
            public LinkedList():this("list")
            {

            }
            public void InsertAtFront(object insertItem)
            {
                if (IsEmpty())
                {
                    firstNode = lastNode = new LinkedListNode(insertItem);
                }
                else
                {
                    lastNode=lastNode.Next = new LinkedListNode(insertItem);
                }
            }
            public void InsertAtBack(object insertItem)
            {
                if (IsEmpty())
                {
                    firstNode = lastNode = new LinkedListNode(insertItem);
                }
                else
                {
                    firstNode = new LinkedListNode(insertItem, firstNode);
                }
            }
            public object RemoveFromFront()
            {
                if (IsEmpty())
                {
                    throw new EmptyListException(Name);
                }
                object removeItem = firstNode.Data;
                if (firstNode==lastNode)
                {
                    firstNode = lastNode = null;
                }
                else
                {
                    firstNode = firstNode.Next;
                }
                return removeItem;
            }
            public object RemoveFromBack()
            {
                if (IsEmpty())
                {
                    throw new EmptyListException(Name);
                }
                object removeItem = lastNode.Data;
                if (firstNode==lastNode)
                {
                    firstNode = lastNode = null;
                }
                else
                {
                    LinkedListNode current = firstNode;
                    while (current.Next!=lastNode)
                    {
                        current = current.Next;
                    }
                    lastNode = current;
                    current.Next = null;
                }
                return removeItem;
            }
            public bool IsEmpty()
            {
                return firstNode == null;
            }
            public void Display()
            {
                if (IsEmpty())
                {
                    Console.WriteLine($"Empty:{Name}");
                }
                else
                {
                    Console.Write($"The {Name} is:");
                    LinkedListNode current = firstNode;
                    while (current!=null)
                    {
                        Console.Write($" {current.Data} ");
                        current = current.Next;
                    }
                    Console.WriteLine("\n");
                }
            }
        }
        //异常类
        public class EmptyListException : Exception
        {
            public EmptyListException():base("The list is empty")
            {

            }
            public EmptyListException(string name):base("the " + name + " is empty")
            {

            }
            public EmptyListException(string exception,Exception inner):base(exception,inner)
            {

            }
        }
}
