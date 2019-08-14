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
                #region 测试删除
                //removedObject = list.RemoveFromFront();
                //Console.WriteLine(removedObject + " removed");
                //Console.WriteLine($"Remove form front");
                //list.Display();

                //removedObject = list.RemoveFromFront();
                //Console.WriteLine(removedObject + " removed");
                //Console.WriteLine($"Remove form front");
                //list.Display();


                //removedObject = list.RemoveFromBack();
                //Console.WriteLine(removedObject + " removed");
                //Console.WriteLine($"Remove form back");
                //list.Display();

                //removedObject = list.RemoveFromBack();
                //Console.WriteLine(removedObject + " removed");
                //Console.WriteLine($"Remove form back");
                //list.Display();
                #endregion
                #region 测试查找倒数k个节点时，注释掉删除节点的代码
                //int k = 3;
                //Console.WriteLine($"查找倒数第{k}个节点");
                //LinkedListNode kNode = list.FindKth(list.firstNode, 3);
                //Console.WriteLine($"结果是{kNode.Data}");
                #endregion
                #region 从尾到头打印链表
                //Console.WriteLine($"第一个节点是{list.firstNode.Data}");
                //Console.WriteLine("开始倒叙打印:");
                //list.PrintReverse1(list.firstNode);
                //Console.WriteLine("第二次倒叙打印:");
                //list.PrintReverse2(list.firstNode);
                #endregion
                #region 测试单链表在时间复杂度为O(1)删除链表结点
                //list.DeleteNode(list.firstNode,list.firstNode.Next.Next);
                //Console.WriteLine("测试删除指定节点:");
                //list.DeleteNode(list.firstNode, list.Find(anInteger));
                //list.Display();
                #endregion
                #region 10.反转链表
                //LinkedListNode reverseNode = list.ReverseList(list.firstNode);
                //while (reverseNode != null)
                //{
                //    Console.WriteLine($"{reverseNode.Data}");
                //    reverseNode = reverseNode.Next;
                //}
                LinkedListNode reverseNode = list.ReverseList2(list.firstNode);
                Console.WriteLine($"反转后第一个节点是:{reverseNode.Data}");
                while (reverseNode != null)
                {
                    Console.WriteLine($"{reverseNode.Data}");
                    reverseNode = reverseNode.Next;
                }
                #endregion
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
        public LinkedListNode()
        {
            Data = null;
            Next = null;
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
        //根据值查找节点
        public LinkedListNode Find(object item)
        {
            LinkedListNode current = firstNode;
            //object比较不用==，用equals
            while (!current.Data.Equals(item) &&current.Next!=null)
            {
                current = current.Next;
            }
            return current;
        }
        #region 1.查找链表的倒数第k个节点
        public LinkedListNode FindKth(LinkedListNode firstNode, int k)
            {

                LinkedListNode cur = firstNode;
                LinkedListNode now = firstNode;
                int i = 0;
                //先执行K次循环
                while (cur!=null&i++<k)
                {
                    cur = cur.Next;
                }
                //再执行N-K次循环，now节点就是倒数K的节点
                while (cur != null)
                {
                    now = now.Next;
                    cur = cur.Next;
                }
                return now;
            }
        #endregion
        #region 2.从尾到头打印链表,递归和非递归
        // 非递归,少打印第一个是为什么?
        public void PrintReverse1(LinkedListNode firstNode)
        {
            //利用一个栈
            Stack<LinkedListNode> stack=new Stack<LinkedListNode>();
            LinkedListNode node = firstNode.Next;
            while (node!=null)
            {
                stack.Push(node);
                node = node.Next;
            }
            LinkedListNode popNode;
            while (stack.Count()!=0)
            {
                popNode = stack.First();
                Console.WriteLine($"{popNode.Data}");
                stack.Pop();
            }
        }
        public void PrintReverse2(LinkedListNode firstNode)
        {
            if (firstNode!=null)
            {
                if (firstNode.Next!=null)
                {
                    PrintReverse2(firstNode.Next);
                }
                Console.WriteLine($"{firstNode.Data}");
            }
        }
        #endregion
        #region 3.判断链表是否有环
        //方法一穷举法首先从头节点开始，依次遍历单链表的每一个节点。每遍历到一个新节点，就从头节点重新遍历新节点之前的所有节点，用新节点ID和此节点之前所有节点ID依次作比较。
        //如果发现新节点之前的所有节点当中存在相同节点ID，则说明该节点被遍历过两次，链表有环；如果之前的所有节点当中不存在相同的节点，就继续遍历下一个新节点，继续重复刚才的操作。
        //假设从链表头节点到入环点的距离是D，链表的环长是S。那么算法的时间复杂度是0+1+2+3+….+(D+S-1) = (D+S-1)(D+S)/2 ， 可以简单地理解成 O(NN)。而此算法没有创建额外存储空间，空间复杂度可以简单地理解成为O(1)。
        //这种方法是暴力破解的方式，时间复杂度太高。

        //方法二快慢指针
        //首先创建两个指针1和2，同时指向这个链表的头节点。
        //然后开始一个大循环，在循环体中，让指针1每次向下移动一个节点，让指针2每次向下移动两个节点，然后比较两个指针指向的节点是否相同。
        //如果相同，则判断出链表有环，如果不同，则继续下一次循环
        //说明 ：在循环的环里面，跑的快的指针一定会反复遇到跑的慢的指针 ，
        //比如：在一个环形跑道上，两个运动员在同一地点起跑，一个运动员速度快，一个运动员速度慢。
        //当两人跑了一段时间，速度快的运动员必然会从速度慢的运动员身后再次追上并超过，原因很简单，因为跑道是环形的。
        public bool IsLoopList(LinkedListNode firstNode)
        {
            LinkedListNode slowNode, fastNode;
            slowNode = fastNode = firstNode;
            while (fastNode!=null&&fastNode.Next!=null)
            {
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;
                if (slowNode==fastNode)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region    4.链表中环的大小
        //快慢指针可以找到链表是否有环存在，如果两个指针第一次相遇后，第二次相遇是什么时候呢？
        //第二次相遇是不是可以认为快的指针比慢的指针多跑了一个环的长度。所以找到第二次相遇的时候就找到了环的大小。
        public LinkedListNode CycleNode(LinkedListNode firstNode)
        {
            if (firstNode==null)
            {
                return null;
            }
            LinkedListNode fastNode, slowNode;
            fastNode = slowNode = firstNode;
            while (fastNode != null && fastNode.Next!=null)
            {
                fastNode = fastNode.Next.Next;
                slowNode = slowNode.Next;
            }
            //两指针相遇，则返回相遇的节点
            if (fastNode==slowNode)
            {
                return fastNode;
            }
            //链表无环，返回null
            return null;
        }
        public int GetCycleLength(LinkedListNode firstNode)
        {
            //获取相遇的节点，已经在环里了
            LinkedListNode node = CycleNode(firstNode);
            if (node==null)
            {
                return 0;
            }
            int length = 1;
            LinkedListNode current = node.Next;
            //在环里继续循环，直到再次相遇，长度就是环的长度
            while (current!=node)
            {
                length++;
                current = current.Next;
            }
            return length;
        }
        #endregion
        #region 5.链表中环的入口节点
        //问题描述:给一个链表，若其中包含环，请找出该链表的环的入口结点，否则，输出nul
        //思路:如果链表存在环，那么计算出环的长度n，然后准备两个指针pSlow，pFast，pFast先走n步，然后pSlow和pFast一块走，当两者相遇时，即为环的入口处；
        //所以解决三个问题：如何判断一个链表有环；如何判断链表中环的大小；链表中环的入口结点。
        //实际上最后的判断就如同链表的倒数第k个节点
        public LinkedListNode EntryNodeOfLoop(LinkedListNode pHead)
        {
            if (pHead.Next==null||pHead.Next.Next==null)
            {
                return null;
            }
            LinkedListNode slow = pHead.Next;
            LinkedListNode fast = pHead.Next.Next;
            while (fast!=null)
            {
                if (fast==slow)
                {
                    fast = pHead;
                    while (fast!=slow)
                    {
                        fast = fast.Next;
                        slow = slow.Next;
                    }
                    return fast;
                }
                slow = slow.Next;
                fast = fast.Next;
            }
            return null;
        }
        #endregion
        #region 6.单链表在时间复杂度为O(1)删除链表结点
        public void DeleteNode(LinkedListNode firstNode,LinkedListNode nodeToBeDeleted)
        {
            if (firstNode==null||nodeToBeDeleted==null)
            {
                return;
            }
            if (nodeToBeDeleted.Next!=null)
            {
                LinkedListNode nodeNext = nodeToBeDeleted.Next;
                nodeToBeDeleted.Next = nodeNext.Next;
                nodeToBeDeleted.Data = nodeNext.Data;
                //delete  nodeNext
                nodeNext = null;
            }
            else
            //待删除节点是尾节点
            {
                LinkedListNode nodeTemp = firstNode;
                while (nodeTemp.Next!=nodeToBeDeleted)
                {
                    nodeTemp = nodeTemp.Next;
                }
                nodeTemp.Next = null;
                //delete nodeToBeDeleted
                nodeToBeDeleted = null;
            }
        }
        #endregion
        #region 7.两个链表的第一个公共节点
        //问题描述:输入两个单链表，找出他们的第一个公共结点
        //思路：由于两个链表的长度可能是不一致的，所以首先比较两个链表的长度m，n，
        //然后用两个指针分别指向两个链表的头节点，让较长的链表的指针先走|m-n|个长度，
        //如果他们下面的节点是一样的，就说明出现了第一个公共节点
        public LinkedListNode FindFirstCommonNode(LinkedListNode pHead1,LinkedListNode pHead2)
        {
            if (pHead1==null ||pHead2==null)
            {
                return null;
            }
            //获取链表的长度
            int count1 = 0;
            LinkedListNode p1 = pHead1;
            while (p1 != null)
            {
                p1 = p1.Next;
                count1++;
            }
            int count2 = 0;
            LinkedListNode p2 = pHead2;
            while (p2 != null)
            {
                p2 = p2.Next;
                count2++;
            }
            int flag = count1 - count2;
            //长的链表先走n步
            if (flag>0)
            {
                while (flag>0)
                {
                    pHead1 = pHead1.Next;
                    flag--;
                }
                while (pHead1!=pHead2)
                {
                    pHead1 = pHead1.Next;
                    pHead2 = pHead2.Next;
                }
                return pHead1;
            }
            if (flag<=0)
            {
                while (flag < 0)
                {
                    pHead2 = pHead2.Next;
                    flag++;
                }
                while (pHead1!=pHead2)
                {
                    pHead1 = pHead1.Next;
                    pHead2 = pHead2.Next;
                }
                return pHead1;
            }
            return null;
        }
        #endregion
        #region 8.合并两个排序的链表
        //问题描述:输入两个单调递增的链表，输出两个链表合成后的链表，当然我们需要合成后的链表满足单调不减规则
        #endregion
        #region 9.复杂的链表复制
        //问题描述:

        #endregion
        #region 10.反转链表
        //问题描述:定义一个函数，输入一个链表的头结点，反转该链表并输出反转后链表的头结点
        //使用递归
        public LinkedListNode ReverseList(LinkedListNode firstNode)
        {
            if (firstNode==null||firstNode.Next==null)
            {
                return firstNode;
            }
            LinkedListNode next = firstNode.Next;
            firstNode.Next = null;
            LinkedListNode newHead = ReverseList(next);
            next.Next = firstNode;
            return newHead;
        }
        //不使用递归
        public LinkedListNode ReverseList2(LinkedListNode firstNode)
        {
            LinkedListNode newList = new LinkedListNode(-1);
            while (firstNode != null)
            {
                //新节点指向下一个
                LinkedListNode next = firstNode.Next;
                firstNode.Next = newList.Next;
                newList.Next = firstNode;
                firstNode = next;
            }
            return newList.Next;
        }
        #endregion
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
