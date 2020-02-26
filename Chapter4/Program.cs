using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Timing sortTime = new Timing();
            int arrayLength = 50000;
            //三个数据一样的数组，用来比较查找时间
            CAarry mynums = new CAarry(arrayLength);
            CAarry mynums2 = new CAarry(arrayLength);
            //CAarry mynums3 = new CAarry(arrayLength);
            int[] mynums3 = new int[arrayLength];
            int position = 0;
            for (int i = 0; i < arrayLength-1; i++)
            {
                int temp = random.Next(100);
                mynums.Insert(temp);
                mynums2.Insert(temp);
                //mynums3.Insert(temp);
            }
            //mynums.DisPlayElements();
            mynums.BubbleSort();
            mynums2.BubbleSort();
            //mynums3.BubbleSort();
            for (int i = 0; i < arrayLength-1; i++)
            {
                mynums3[i] = mynums.arr[i];
            }
            #region 二叉查找
            sortTime.StartTime();
            position = mynums.binSearch(77);
            sortTime.StopTime();
            Console.WriteLine($"二叉查找总共用时:{sortTime.Result().TotalMilliseconds}");
            #endregion
            #region 递归二叉查找
            sortTime.StartTime();
            position = mynums2.RbinSearch(77, 0, arrayLength);
            sortTime.StopTime();
            Console.WriteLine($"递归二叉查找总共用时:{sortTime.Result().TotalMilliseconds}");
            #endregion
            #region 数组内置二叉查找
            sortTime.StartTime();
            position = Array.BinarySearch(mynums3, 77);
            sortTime.StopTime();
            Console.WriteLine($"数组内置二叉查找总共用时:{sortTime.Result().TotalMilliseconds}");
            #endregion
            if (position>-1)
            {
                Console.WriteLine("found item");
                //mynums.DisPlayElements();
            }
            else
            {
                Console.WriteLine("Not in the array");
            }
            Console.Read();
        }
        #region 查询最大最小值
        public static int FindMin(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i]<min)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        public static int FindMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
        #endregion
        #region 所谓的自组织数据,把频繁查找的数据移动到数组的前面位置
        public static bool SeqSearch(int sValue,int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                if (arr[index] == sValue)
                {
                    Swap(index, 0,arr);
                    return true;
                }
            }
            return false;

        }
        public static int SeqSearch2(int sValue,int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                if(arr[index]== sValue)
                {
                    Swap(index, index - 1, arr);
                    return index;
                }
            }
            return -1;
        }
        public static void Swap(int item1,int item2, int[] arr)
        {
            int temp = arr[item1];
            arr[item1] = arr[item2];
            arr[item2] = temp;
        }
        #endregion
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
                while (lowerBound<=upperBound)
                {
                    mid = (upperBound + lowerBound) / 2;
                    if(arr[mid]==value)
                    {
                        return mid;
                    }
                    else
                    {
                        if (value<arr[mid])
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
            public int RbinSearch(int value,int lower,int upper)
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
                    else if(value==arr[mid])
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
}
