using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

namespace Chapter5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 检验回文字符串
            ////类似于dad,madam向前向后拼写都完全一样的字符串
            //CStack alist = new CStack();
            //string ch;
            //string word = "sees";
            //bool isPalindrome = true;
            //for (int i = 0; i < word.Length; i++)
            //{
            //    alist.push(word.Substring(i, 1));
            //}
            //int pos = 0;
            //while (alist.count > 0)
            //{
            //    ch = alist.pop().ToString();
            //    if (ch != word.Substring(pos, 1))
            //    {
            //        isPalindrome = false;
            //        break;
            //    }
            //    pos++;
            //}
            //if(isPalindrome)
            //    Console.WriteLine($"{word} is a palindrome");
            //else
            //    Console.WriteLine($"{word} is not a palindrome");
            #endregion
            #region 栈操作运算
            //Stack nums = new Stack();
            //Stack ops = new Stack();
            ////注意表达式中的空格
            //string expression = "5 + 10 + 15 + 20";
            //Calculate(nums, ops, expression);
            //Console.WriteLine(nums.Pop());

            #endregion
            #region stack的CopyTo方法
            //Stack使用copyto不能指定起始索引位置???
            //Stack myStack = new Stack();
            //for (int i = 20; i >0; i--)
            //{
            //    myStack.Push(i);
            //}
            //object[] myArray = new object[20];
            //myStack.CopyTo(myArray, 0);
            //foreach (var item in myArray)
            //{
            //    Console.Write($"{item} ");
            //}
            //Console.WriteLine("显示合并数组");
            //int[] copy1 = { 1, 2, 3, 4 };
            //int[] copy2 = { 5, 6, 7, 8 };
            //int[] copy3 = new int[copy1.Length + copy2.Length];
            //copy1.CopyTo(copy3, 0);
            //copy2.CopyTo(copy3, 4);
            //foreach (var item in copy3)
            //{
            //    Console.Write($"{item} ");
            //}
            #endregion
            #region 十进制向多种进制的转换
            //int num, baseNum;
            //Console.WriteLine("Enter a decimal number");
            //num = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter a base");
            //baseNum = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"{num} converts to");
            //MulBase(num, baseNum);
            //Console.WriteLine($" Base {baseNum} ");
            #endregion
            #region 测试Queue 舞伴
            //Queue males = new Queue();
            //Queue females = new Queue();
            //formLines(males, females);
            //startDancing(males, females);
            //if (males.Count > 0 || females.Count > 0)
            //{
            //    headOfLine(males, females);
            //}
            //newDancers(males, females);
            //if (males.Count > 0 || females.Count > 0)
            //{
            //    headOfLine(males, females);
            //}
            //newDancers(males, females);
            //Console.WriteLine("press enter");
            #endregion
            #region 队列排序数据
            //Queue[] numQueue = new Queue[10];
            //int[] nums = new int[] { 91, 46, 85, 15, 92, 35, 31, 22 };
            //for (int i = 0; i < 10; i++)
            //{
            //    numQueue[i] = new Queue();
            //}
            ////第一次排序，个位数
            //RSort(numQueue, nums, DigitType.ones);
            //BuildArray(numQueue, nums);
            //Console.WriteLine();
            //Console.WriteLine($"First pass results: ");
            //DisplayArray(nums);
            ////第二次排序，十位数
            //RSort(numQueue, nums, DigitType.tens);
            //BuildArray(numQueue, nums);
            //Console.WriteLine();
            //Console.WriteLine($"Second pass results: ");
            //DisplayArray(nums);
            //Console.WriteLine($"Press enter to quit");
            #endregion
            #region 优先队列
            PQueue erwait = new PQueue();
            pqItem[] erPatient = new pqItem[3];
            pqItem nextPatient;
            erPatient[0].name = "Joe Smith";
            erPatient[0].priority = 1;
            erPatient[1].name = "Mary Brown";
            erPatient[1].priority = 0;
            erPatient[2].name = "Sam Jones";
            erPatient[2].priority = 3;
            for (int i = 0; i < erPatient.Length; i++)
            {
                erwait.Enqueue(erPatient[i]);
            }
            nextPatient =(pqItem) erwait.Dequeue();
            Console.WriteLine($"{nextPatient.name}");
            #endregion
            Console.Read();
        }
        public static bool IsNumeric(string input)
        {
            bool flag = true;
            string pattern = (@"^\d+$");
            Regex validate = new Regex(pattern);
            if (!validate.IsMatch(input))
            {
                flag = false;
            }
            return flag;
        }

        public static void Calculate(Stack N,Stack O,string exp)
        {
            string ch, token = "";
            for (int p = 0; p < exp.Length; p++)
            {
                ch = exp.Substring(p, 1);
                //Console.WriteLine($"当前截取的字符是:{ch}");
                if (IsNumeric(ch))
                {
                    token += ch;
                }
                if (ch == " " || p == (exp.Length - 1))
                {
                    if (IsNumeric(token))
                    {
                        N.Push(token);
                        //Console.WriteLine($"当前数字是{token}");
                        token = "";
                    }
                }
                else if (ch == "+" || ch == "-" || ch == "*" || ch == "/")
                    O.Push(ch);
                if (N.Count == 2)
                    Compute(N, O);
            }
        }

        public static void Compute(Stack N,Stack O)
        {
            int oper1, oper2;
            string oper;
            oper1 =Convert.ToInt32( N.Pop());
            oper2= Convert.ToInt32(N.Pop());
            oper= Convert.ToString(O.Pop());
            switch (oper)
            {
                case "+":
                    N.Push(oper1 + oper2);
                    break;
                case "-":
                    N.Push(oper1 - oper2);
                    break;
                case "*":
                    N.Push(oper1 * oper2);
                    break;
                case "/":
                    N.Push(oper1 / oper2);
                    break;
            }
        }

        public static void MulBase(int n,int b)
        {
            Stack Digits = new Stack();
            do
            {
                Digits.Push(n % b);
                n /= b;
            } while (n != 0);
            while(Digits.Count>0)
                Console.Write($"{Digits.Pop()}");
        }

        #region queue类实例应用 舞伴方法
        public static void newDancers(Queue male, Queue female)
        {
            Dancer m, w;
            m = new Dancer();
            w = new Dancer();
            if (male.Count>0 && female.Count>0)
            {
                //和自定义的CQueue类不同，返回并删除
                m.GetName(male.Dequeue().ToString());
                w.GetName(female.Dequeue().ToString());
            }
            else if (male.Count>0 && female.Count==0)
            {
                Console.WriteLine("waiting on a female dancer");
            }
            else if (male.Count == 0 && female.Count >= 0)
            {
                Console.WriteLine("waiting on a male dancer");
            }

        }

        public static void headOfLine(Queue male,Queue female)
        {
            Dancer w = new Dancer();
            Dancer m = new Dancer();
            if (male.Count>0)
            {
                m.GetName(male.Peek().ToString());
            }
            if (female.Count > 0)
            {
                w.GetName(female.Peek().ToString());
            }
            if(m.name!="" && w.name != "")
            {
                Console.WriteLine($"Next in line are:{m.name}  {w.name}");
            }
            else
            {
                if (m.name != "")
                {
                    Console.WriteLine($"Next in line is {m.name}");
                }
                else
                {
                    Console.WriteLine($"Next in line is {w.name}");
                }
            }
        }

        public static void startDancing(Queue male,Queue female)
        {
            Dancer m = new Dancer();
            Dancer w = new Dancer();
            Console.WriteLine($"Dance parters are :");
            Console.WriteLine();
            for (int count = 0; count <=3; count++)
            {
                m.GetName(male.Dequeue().ToString());
                w.GetName(female.Dequeue().ToString());
                Console.WriteLine($"{w.name}  {m.name}");
            }
        }
        public static void formLines(Queue male,Queue female)
        {
            Dancer d = new Dancer();
            StreamReader inFile;
            inFile = File.OpenText(@"d:\dancers.txt");
            string line;
            while (inFile.Peek() != -1)
            {
                line = inFile.ReadLine();
                d.sex = line.Substring(0, 1);
                d.name = line.Substring(2, line.Length - 2);
                if (d.sex == "M")
                    male.Enqueue(d);
                else
                    female.Enqueue(d);
            }
        }
        #endregion
        #region 用队列排序 数据
        public static void DisplayArray(int[] n)
        {
            //GetUpperBound获取数组指定维度最后一个元素的索引
            for (int i = 0; i < n.Length; i++)
            {
                Console.Write($"{n[i]}  ");
            }
        }
        public static void RSort(Queue[] que,int[]n,DigitType digit)
        {
            int snum;
            for (int i = 0; i < n.Length; i++)
            {
                //int temp = n.GetUpperBound(0);
                //Console.WriteLine(temp);
                if (digit == DigitType.ones)
                    snum = n[i] % 10;
                else
                    snum = n[i] / 10;
                que[snum].Enqueue(n[i]);
            }
        }
        public static void BuildArray(Queue[] que, int[] n)
        {
            int y = 0;
            for (int x = 0; x <=9; x++)
            {
                while (que[x].Count > 0)
                {
                    n[y] = Convert.ToInt32(que[x].Dequeue().ToString());
                    y++;
                }
            }
        }
        #endregion
    }
    public class CStack
    {
        public int p_index;
        public ArrayList list;
        public CStack()
        {
            list = new ArrayList();
            p_index = -1;
        }
        public int count
        {
            get
            {
                return list.Count;
            }
        }
        public void push(object item)
        {
            list.Add(item);
            p_index++;
        }
        public object pop()
        {
            object obj = list[p_index];
            list.RemoveAt(p_index);
            p_index--;
            return obj;
        }
        public void clear()
        {
            list.Clear();
            p_index = -1;
        }
        public object peek()
        {
            return list[p_index];
        }
    }

    public class CQueue
    {
        public ArrayList pqueue;
        public CQueue()
        {
            pqueue = new ArrayList();
        }
        public void EnQueue(object item)
        {
            pqueue.Add(item);
        }
        public void DeQueue()
        {
            pqueue.RemoveAt(0);
        }
        public object Peek()
        {
            return pqueue[0];
        }
        public void ClearQueue()
        {
            pqueue.Clear();
        }
        public int Count()
        {
            return pqueue.Count;
        }
    }

    #region queue类实例应用 舞伴结构
    public struct Dancer
    {
        public string name;
        public string sex;
        public void GetName(string n)
        {
            name = n;
        }
        public override string ToString()
        {
            return name;
        }
    }
    #endregion
    public enum DigitType
    {
        ones=1,
        tens=10
    }
    #region 优先队列
    public struct pqItem
    {
        public int priority;
        public string name;
    }
    public class PQueue : Queue
    {
        public PQueue()
        {

        }
        public override object Dequeue()
        {
            object[] items;
            int min;
            items = this.ToArray();
            min = ((pqItem)items[0]).priority;
            for (int x = 0; x < items.Length; x++)
            {
                if (((pqItem)items[x]).priority<min)
                {
                    min = ((pqItem)items[x]).priority;
                }
            }
            this.Clear();
            int x2;
            for ( x2 = 0; x2 < items.Length; x2++)
            {
                if (((pqItem)items[x2]).priority == min && ((pqItem)items[x2]).name != "")
                    this.Enqueue(items[x2]);
            }
            return base.Dequeue();
        }
    }
    #endregion
}
