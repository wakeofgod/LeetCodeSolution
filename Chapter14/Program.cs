using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Chapter14
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 
            const int SIZE = 19;
            CAarry theArray = new CAarry(SIZE);
            Random random = new Random();
            for (int i = 0; i < SIZE; i++)
            {
                theArray.Insert(random.Next(100) + 1);
            }
            Console.WriteLine();
            theArray.DisPlayElements();
            Console.WriteLine();
            //theArray.ShellSort();
            //theArray.DisPlayElements();
            Console.WriteLine("开始归并排序:");
            theArray.MergeSort();
            #endregion
            Console.ReadLine();
        }
    }
    public class CAarry
    {
        public int[] arr;
        public int upper;
        public int numElements;
        public CAarry(int size)
        {
            arr = new int[size];
            upper = size - 1;
            numElements = 0;
        }
        public void Insert(int item)
        {
            arr[numElements] = item;
            numElements++;
        }
        public void DisPlayElements()
        {
            for (int i = 0; i <= upper; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
        public void Clear()
        {
            for (int i = 0; i <= upper; i++)
            {
                arr[i] = 0;
            }
            numElements = 0;
        }
        #region 冒泡排序
        //先找最大的
        public void BubbleSort()
        {
            int temp;
            int total = 0;
            for (int outer = upper; outer >= 1; outer--)
            {
                for (int inner = 0; inner <= outer - 1; inner++)
                {
                    if (arr[inner] > arr[inner + 1])
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner + 1];
                        arr[inner + 1] = temp;
                        total++;
                    }
                }
                //Console.WriteLine();
                //Console.WriteLine($"显示第{upper-outer+1}次排序");
                //this.DisPlayElements();
            }
            //Console.WriteLine($"冒泡排序共计交换次数:{total}");
        }
        #endregion
        #region 二叉查找
        public int binSearch(int value)
        {
            int upperBound, lowerBound, mid;
            lowerBound = 0;
            upperBound = upper - 1;
            while (lowerBound <= upperBound)
            {
                mid = (upperBound + lowerBound) / 2;
                if (arr[mid] == value)
                {
                    return mid;
                }
                else
                {
                    if (value < arr[mid])
                    {
                        upperBound = mid - 1;
                    }
                    else
                    {
                        lowerBound = mid + 1;
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// 递归二叉查找
        /// </summary>
        /// <param name="value"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public int RbinSearch(int value, int lower, int upper)
        {
            if (lower > upper)
            {
                return -1;
            }
            else
            {
                int mid;
                mid = (upper + lower) / 2;
                if (value < arr[mid])
                {
                    return RbinSearch(value, lower, mid - 1);
                }
                else if (value == arr[mid])
                {
                    return mid;
                }
                else
                {
                    return RbinSearch(value, mid + 1, upper);
                }
            }
        }
        #endregion
        #region 希尔排序
        public void ShellSort()
        {
            int inner, temp;
            int h = 3;
            int total = 0;
            while (h > 0)
            {
                for (int outer = h; outer < numElements; outer++)
                {
                    temp = arr[outer];
                    inner = outer;
                    while( (inner>h-1)&& arr[inner - h] >= temp)
                    {
                        arr[inner] = arr[inner - h];
                        inner -= h;
                        total++;
                    }
                    arr[inner] = temp;
                }
                h = (h - 1) % 3;
                Console.WriteLine($"当前增量序列是: {h}");
            }
            Console.WriteLine($"希尔排序比较次数是:{total}");
        }
        #endregion
        #region 归并排序算法
        public void MergeSort()
        {
            int[] tempArray = new int[numElements];
            RecMergeSort(tempArray, 0, numElements - 1);
        }
        public void RecMergeSort(int[] tempArray, int lbound,int ubound)
        {
            if (lbound == ubound)
                return;
            else
            {
                int mid = (int)(lbound + ubound) / 2;
                RecMergeSort(tempArray, lbound, mid);
                RecMergeSort(tempArray, mid + 1, ubound);
                Merge(tempArray, lbound, mid + 1, ubound);
            }
        }
        public void Merge(int[] tempArray,int lowp,int highp,int ubound)
        {
            int lbound = lowp;
            int mid = highp - 1;
            int n = (ubound - lbound) + 1;
            int j = 0;
            while(lowp<=mid && highp <= ubound)
            {
                if (arr[lowp] < arr[highp])
                {
                    tempArray[j] = arr[lowp];
                    j++;
                    lowp++;
                }
                else
                {
                    tempArray[j] = arr[highp];
                    j++;
                    highp++;
                }
            }
            while (lowp <= mid)
            {
                tempArray[j] = arr[lowp];
                j++;
                lowp++;
            }
            while (highp <= ubound)
            {
                tempArray[j] = arr[highp];
                j++;
                highp++;
            }
            for ( j = 0; j < n; j++)
            {
                arr[lbound + j] = tempArray[j];
            }
            Console.WriteLine();
            this.DisPlayElements();
        }
        #endregion
        #region 堆排序

        #endregion
    }
    #region 时间测试类
    public class Timing
    {
        TimeSpan duration;
        public Timing()
        {
            duration = new TimeSpan(0);
        }
        public void StopTime()
        {
            duration = Process.GetCurrentProcess().TotalProcessorTime;
        }
        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
    #endregion
}
