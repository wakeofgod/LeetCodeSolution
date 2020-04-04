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
            string word1 = "mavens";
            string word2 = "hpavoc";
            string[] warr1 = new string[word1.Length];
            string[] warr2 = new string[word2.Length];
            string substr = "";
            int[,] larray = new int[word1.Length, word2.Length];
            LCSubstring(word1, word2, warr1, warr2, larray);
            Console.WriteLine();
            Dispaly(larray);
            substr = ShowString(larray, warr1);
            Console.WriteLine();
            Console.WriteLine($"The strings are:{word1} {word2}");
            if (substr.Length > 0)
            {
                Console.WriteLine($"The longest common substring is :{substr}");
            }
            else
            {
                Console.WriteLine($"There is no common substring");
            }
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

        #endregion
    }

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
