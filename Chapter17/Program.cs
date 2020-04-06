using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Chapter17
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 对比 递归和动态规划计算斐波那契数列
            //Timing tObj = new Timing();
            //Timing tObj1 = new Timing();
            //Timing tObj2 = new Timing();
            //int num = 40;
            //long fibNumber;
            //tObj.StartTime();
            //fibNumber = RecurFib(num);
            //tObj.StopTime();
            //Console.WriteLine($"Calculating Fibonacci number: {num}");
            //Console.WriteLine($"递归: {fibNumber} in :{tObj.Result().TotalMilliseconds}");
            //tObj1.StartTime();
            //fibNumber = IterFib(num);
            //tObj1.StopTime();
            //Console.WriteLine($"动态规划: {fibNumber} in :{tObj1.Result().TotalMilliseconds}");
            //tObj2.StartTime();
            //fibNumber = IterFib1(num);
            //Console.WriteLine($"动态规划不使用数组: {fibNumber} in :{tObj2.Result().TotalMilliseconds}");
            #endregion

            #region 寻找最长公共子串
            //string word1 = "mavens";
            //string word2 = "hpavoc";
            //string[] warr1 = new string[word1.Length];
            //string[] warr2 = new string[word2.Length];
            //string substr = "";
            //int[,] larray = new int[word1.Length, word2.Length];
            //LCSubstring(word1, word2, warr1, warr2, larray);
            //Console.WriteLine();
            //Dispaly(larray);
            //substr = ShowString(larray, warr1);
            //Console.WriteLine();
            //Console.WriteLine($"The strings are:{word1} {word2}");
            //if (substr.Length > 0)
            //{
            //    Console.WriteLine($"The longest common substring is :{substr}");
            //}
            //else
            //{
            //    Console.WriteLine($"There is no common substring");
            //}

            //暴力穷举法计算
            string word1 = "mavens";
            string word2 = "hpavoc";
            string longest= LongestStr(word1, word2);
            Console.WriteLine(longest);
            #endregion

            #region 背包问题
            //int capacity = 16;                         //背包最大容量
            //int[] size = new int[] { 3, 4, 7, 8, 9 };  //宝物大小数组
            //int[] values = new int[] { 4, 5, 10, 11, 13 };//宝物价值数组
            //int[] total = new int[capacity + 1];       //用来储存最高的总价值
            //int[] best = new int[capacity + 1];        //用来初春最高价值的宝物
            //int n = values.Length;
            //for (int j = 0; j < n; j++)
            //{
            //    for (int i = 0; i <= capacity; i++)
            //    {
            //        if (i >= size[j])
            //        {
            //            if (total[i] < total[i - size[j]] + values[j])
            //            {
            //                total[i] = total[i - size[j]] + values[j];
            //                best[i] = j;
            //            }
            //        }
            //    }
            //}
            //Console.WriteLine($"The maximum value is:{total[capacity]}");
            ////Console.WriteLine($"The item that generate this value are:");
            ////int totcap = 0;
            ////while (totcap <= capacity)
            ////{
            ////    Console.WriteLine($"Item with best value:{size[best[capacity-totcap]]}");
            ////    totcap += size[best[i]];
            ////}
            #endregion

            #region 找零钱问题
            ////假设只有四种硬币：25美分，10美分，5美分，1美分
            ////要找的零钱总数不超过一美元
            //double origAmount = 0.63;
            //double toChange = origAmount;
            //double remainAmount = 0.0;
            //int[] coins = new int[4];
            //MakeChanges(origAmount, remainAmount, coins);
            //Console.WriteLine($"The best way to change {toChange} cent is :");
            //ShowChange(coins);
            #endregion

            #region 哈夫曼编码
            //string input;
            //Console.WriteLine("Enter a string to encode:");
            //input = Console.ReadLine();
            //TreeList treeList = new TreeList(input);
            //for (int i = 0; i < input.Length; i++)
            //{
            //    treeList.AddSign(input[i].ToString());
            //}
            //treeList.SortTree();
            //while (treeList.Length() > 1)
            //{
            //    treeList.MergeTree();
            //}
            //TreeList.MakeKey(treeList.RemoveTree(), "");
            //string newStr = TreeList.translate(input);
            //string[] signTable = treeList.GetSignTable();
            //string[] keyTable = treeList.GetKeyTable();
            //for (int i = 0; i < signTable.Length; i++)
            //{
            //    Console.WriteLine($"{signTable[i]}:{keyTable[i]}");
            //}
            //Console.WriteLine($"The original string is {input.Length*16} bits long.");
            //Console.WriteLine($"The new string is {newStr.Length} bits long.");
            //Console.WriteLine($"The code string looks like this {newStr}");
            #endregion
            Console.ReadLine();
        }

        //递归计算斐波那契数列
        public static long RecurFib(int n)
        {
            if (n < 2)
            {
                return n;
            }
            else
            {
                return RecurFib(n - 1) + RecurFib(n - 2);
            }
        }

        //动态规划计算斐波那契数列
        public static long IterFib(int n)
        {
            int[] val = new int[n];
            if(n==1 || n == 2)
            {
                return 1;
            }
            else
            {
                val[1] = 1;
                val[2] = 2;
                for (int i = 3; i < n; i++)
                {
                    val[i] = val[i - 1] + val[i - 2];
                }
                return val[n - 1];
            }
        }

        //动态规划计算斐波那契数列，不使用数组保存中间结果
        public static long IterFib1(int n)
        {
            long last, nextLast, result;
            last = 1;
            nextLast = 1;
            result = 1;
            for (int i = 2; i <=n; i++)
            {
                result = last + nextLast;
                nextLast = last;
                last = result;
            }
            return last;
        }

        #region 寻找最长公共子串
        public static void LCSubstring(string word1,string word2,string[]warr1,string []warr2,int[,] arr)
        {
            int len1, len2;
            len1 = word1.Length;
            len2 = word2.Length;
            for (int k = 0; k < len1; k++)
            {
                warr1[k] = word1.Substring(k, 1);
                warr2[k] = word2.Substring(k, 1);
            }
            for (int i = len1-1; i >=0; i--)
            {
                for (int j = len2-1; j >=0; j--)
                {
                    if (warr1[i] == warr2[j])
                    {
                        arr[i, j] = 1 + arr[i + 1, j + 1];
                    }
                    else
                    {
                        arr[i, j] = 0;
                    }
                }
            }
        }

        public static string ShowString(int[,] arr,string[] wordArr)
        {
            string substr = "";
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    if(arr[i,j]>0)
                    {
                        substr += wordArr[i];
                    }
                }
            }
            return substr;
        }

        public static void Dispaly(int[,] arr)
        {
            for (int row = 0; row < arr.GetUpperBound(0); row++)
            {
                for (int col = 0; col < arr.GetUpperBound(1); col++)
                {
                    Console.Write(arr[row,col]);
                }
                Console.WriteLine();
            }
        }

        public static string LongestStr(string str1,string str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;
            int max = 0, num = 0, start = 0;
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    int start1 = i;
                    int start2 = j;
                    while((start1<len1-1) && (start2 <= len2 - 1) && str1[start1++] == str2[start2++])
                    {
                        num++;
                    }
                    if (num > max)
                    {
                        max = num;
                        start = i;
                    }
                    num = 0;
                }
            }
            string str;
            str = str1.Substring(start, max);
            return str;
        }

        #endregion

        #region 找零钱问题
        public static void MakeChanges(double origAmount,double remainAmount,int[] coins)
        {
            if((origAmount % 0.25) < origAmount)
            {
                //数组的最后一位是使用25美分硬币的数量，优先使用最高面值的
                coins[3] = (int)(origAmount / 0.25);
                remainAmount = origAmount % 0.25;
                origAmount = remainAmount;
            }
            if( (origAmount%0.1) < origAmount)
            {
                //然后使用次高面值的10美分硬币,数量存在数组的倒数第二位
                coins[2] = (int)(origAmount / 0.1);
                remainAmount = origAmount % 0.1;
                origAmount = remainAmount;
            }
            if ((origAmount % 0.05) < origAmount)
            {
                coins[1] = (int)(origAmount / 0.05);
                remainAmount = origAmount % 0.05;
                origAmount = remainAmount;
            }
            if ((origAmount % 0.01) < origAmount)
            {
                coins[0] = (int)(origAmount / 0.01);
                remainAmount = origAmount % 0.01;
                origAmount = remainAmount;
            }
        }

        public static void ShowChange(int[] arr)
        {
            if (arr[3] > 0)
            {
                Console.WriteLine($"Number of quarters: {arr[3]}");
            }
            if (arr[2] > 0)
            {
                Console.WriteLine($"Number of dimes: {arr[2]}");
            }
            if (arr[1] > 0)
            {
                Console.WriteLine($"Number of nickels: {arr[1]}");
            }
            if (arr[0] > 0)
            {
                Console.WriteLine($"Number of pennies: {arr[0]}");
            }
        }
        #endregion
    }

    #region 哈夫曼编码
    //哈夫曼二叉树是从底部开始构建，而不是从头部开始
    public class Node
    {
        public HuffmanTree data;
        public Node link;
       
        public Node(HuffmanTree newData)
        {
            data = newData;
        }
    }

    public class TreeList
    {
        private int count = 0;
        private Node first = null;
        private static string[] signTable = null;
        private static string[] keyTable = null;

        public TreeList(string input)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!list.Contains(input[i]))
                {
                    list.Add(input[i]);
                }
            }
            signTable = new string[list.Count];
            keyTable = new string[list.Count];
        }

        public string [] GetSignTable()
        {
            return signTable;
        }

        public string [] GetKeyTable()
        {
            return keyTable;
        }

        public void AddLetter(string letter)
        {
            HuffmanTree hTemp = new HuffmanTree(letter);
            Node eTemp = new Node(hTemp);
            if (first == null)
            {
                first = eTemp;
            }
            else
            {
                eTemp.link = first;
                first = eTemp;
            }
            count++;
        }

        public void SortTree()
        {
            if(first!=null && first.link != null)
            {
                Node tmp1;
                Node tmp2;
                for ( tmp1 = first; tmp1 !=null ; tmp1=tmp1.link)
                {
                    for ( tmp2 = tmp1.link; tmp2 !=null; tmp2=tmp2.link)
                    {
                        if (tmp1.data.GetFreq() > tmp2.data.GetFreq())
                        {
                            HuffmanTree tmpHT = tmp1.data;
                            tmp1.data = tmp2.data;
                            tmp2.data = tmp1.data;
                        }
                    }
                }
            }
        }

        public void MergeTree()
        {
            if (first != null)
            {
                if (first.link != null)
                {
                    HuffmanTree aTemp = RemoveTree();
                    HuffmanTree bTemp = RemoveTree();
                    HuffmanTree sumTemp = new HuffmanTree("x");
                    sumTemp.SetLeftChild(aTemp);
                    sumTemp.SetRightChild(bTemp);
                    sumTemp.SetFreq(aTemp.GetFreq() + bTemp.GetFreq());
                    InsertTree(sumTemp);
                }
            }
        }

        public HuffmanTree RemoveTree()
        {
            if (first != null)
            {
                HuffmanTree hTemp;
                hTemp = first.data;
                first = first.link;
                count--;
                return hTemp;
            }
            return null;
        }

        public void InsertTree(HuffmanTree hTemp)
        {
            Node eTemp = new Node(hTemp);
            if (first == null)
            {
                first = eTemp;
            }
            else
            {
                Node p = first;
                while (p.link != null)
                {
                    if((p.data.GetFreq()<=hTemp.GetFreq()) && (p.link.data.GetFreq() >= hTemp.GetFreq()))
                    {
                        break;
                    }
                    p = p.link;
                }
                eTemp.link = p.link;
                p.link = eTemp;
            }
        }

        public int Length()
        {
            return count;
        }

        public void AddSign(string str)
        {
            if (first == null)
            {
                AddLetter(str);
                return;
            }
            Node tmp = first;
            while (tmp != null)
            {
                if (tmp.data.GetSign() == str)
                {
                    tmp.data.IncFreq();
                    return;
                }
                tmp = tmp.link;
            }
            AddLetter(str);
        }

        public static string translate(string original)
        {
            string newStr = "";
            for (int i = 0; i < original.Length; i++)
            {
                for (int j = 0; j < signTable.Length; j++)
                {
                    if (original[i].ToString() == signTable[j])
                    {
                        newStr += keyTable[j];
                    }
                }
            }
            return newStr;
        }

        static int pos = 0;
        public static void MakeKey(HuffmanTree tree,string code)
        {
            if (tree.GetLeftChild() == null)
            {
                signTable[pos] = tree.GetSign();
                keyTable[pos] = code;
                pos++;
            }
            else
            {
                MakeKey(tree.GetLeftChild(), code + "0");
                MakeKey(tree.GetRightChild(), code + "1");
            }
        }
    }

    public class HuffmanTree
    {
        private HuffmanTree leftChild;
        private HuffmanTree rightChild;
        private string letter;
        private int freq;

        public HuffmanTree(string letter)
        {
            this.letter = letter;
            this.freq = 1;
        }

        public void SetLeftChild(HuffmanTree newChild)
        {
            leftChild = newChild;
        }

        public void SetRightChild(HuffmanTree newChild)
        {
            rightChild = newChild;
        }

        public void SetLetter(string newLetter)
        {
            letter = newLetter;
        }

        public void IncFreq()
        {
            freq++;
        }

        public void SetFreq(int newFreq)
        {
            freq = newFreq;
        }

        public HuffmanTree GetLeftChild()
        {
            return leftChild;
        }

        public HuffmanTree GetRightChild()
        {
            return rightChild;
        }

        public int GetFreq()
        {
            return freq;
        }

        public string GetSign()
        {
            return letter;
        }
    }
    #endregion

    #region 贪心算法解决背包问题
    public class Carpet : IComparable
    {
        private string item;
        private float val;
        private int unit;
        public Carpet(string i,float v,int u)
        {
            item = i;
            val = v;
            unit = u;
        }

        public int CompareTo(Object c)
        {
            return this.val.CompareTo(((Carpet)c).val);
        }

        public int GetUnit()
        {
            return unit;
        }

        public string GetItem()
        {
            return item;
        }

        public float GetVal()
        {
            return val * unit;
        }
        public float ItemVal()
        {
            return val;
        }
    }

    public class Knapsack
    {
        private float quantity;
        //SortedList items = new SortedList();
        string itemList;
        public Knapsack(float max)
        {
            quantity = max;
        }
    }
    #endregion

    #region 时间测试类
    public class Timing
    {
        TimeSpan duration;
        TimeSpan start;
        public Timing()
        {
            start = new TimeSpan(0);
            duration = new TimeSpan(0);
        }
        public void StopTime()
        {
            //duration = Process.GetCurrentProcess().TotalProcessorTime;
            duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(start);
        }
        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            start = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
    #endregion
}
