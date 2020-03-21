using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Chapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            Timing sortTime = new Timing();
            Random rnd = new Random(100);
            int numItems = 100000;
            CAarry theArray = new CAarry(numItems);
            //#region 选择排序时间
            for (int i = 0; i < numItems; i++)
            {
                theArray.Insert(rnd.Next(0, 1000));
            }
            //theArray.DisPlayElements();
            sortTime.StartTime();
            theArray.SelectionSort();
            sortTime.StopTime();
            Console.WriteLine();
            Console.WriteLine($"Time for Selection sort :{sortTime.Result().TotalMilliseconds}");
            theArray.Clear();
            //#endregion
            #region 冒泡排序时间
            for (int i = 0; i < numItems; i++)
            {
                theArray.Insert(rnd.Next(0, 1000));
            }
            sortTime.StartTime();
            theArray.BubbleSort();
            sortTime.StopTime();
            Console.WriteLine();
            Console.WriteLine($"Time for Bubble sort :{sortTime.Result().TotalMilliseconds}");
            theArray.Clear();
            #endregion
            #region 插入排序时间
            for (int i = 0; i < numItems; i++)
            {
                theArray.Insert(rnd.Next(0, 1000));
            }
            sortTime.StartTime();
            theArray.InsertionSort();
            sortTime.StopTime();
            Console.WriteLine();
            Console.WriteLine($"Time for Insertion sort :{sortTime.Result().TotalMilliseconds}");
            theArray.Clear();
            for (int i = 0; i < numItems; i++)
            {
                theArray.Insert(rnd.Next(0, 1000));
            }
            sortTime.StartTime();
            theArray.InsertionSort2();
            sortTime.StopTime();
            Console.WriteLine();
            Console.WriteLine($"Time for Insertion sort :{sortTime.Result().TotalMilliseconds}");
            #endregion
            #region 快速排序时间
            theArray.Clear();
            for (int i = 0; i < numItems; i++)
            {
                theArray.Insert(rnd.Next(0, 1000));
            }
            //theArray.DisPlayElements();
            sortTime.StartTime();
            theArray.QSort();
            sortTime.StopTime();
            Console.WriteLine();
            Console.WriteLine($"Time for Q sort :{sortTime.Result().TotalMilliseconds}");
            theArray.Clear();
            #endregion
            Console.ReadLine();
        }
    }
    public class CAarry
    {
        private int[] arr;
        private int upper;
        private int numElements;
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
            for (int i = 0; i <=upper; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
        public void Clear()
        {
            for (int i = 0; i <=upper; i++)
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
            for (int outer = upper; outer>=1 ; outer--)
            {
                for (int inner = 0; inner <= outer-1; inner++)
                {
                    if (arr[inner]>arr[inner+1])
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner+1];
                        arr[inner + 1] = temp;
                        total++;
                    }
                }
                //Console.WriteLine();
                //Console.WriteLine($"显示第{upper-outer+1}次排序");
                //this.DisPlayElements();
            }
            Console.WriteLine($"冒泡排序共计交换次数:{total}");
        }
        //先找最小的
        public void BubbleSort2()
        {
            int temp;
            int total = 0;
            for (int outer = 0; outer <=upper; outer++)
            {
                for (int inner = upper; inner>=outer+1 ; inner--)
                {
                    if (arr[inner]<arr[inner-1])
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner-1];
                        arr[inner-1] = temp;
                        total++;
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"显示第{outer+1}次排序");
                this.DisPlayElements();
            }
            Console.WriteLine($"共计比较次数:{total}");
        }
        #endregion
        #region 选择排序法
        public void SelectionSort()
        {
            int min, temp,total=0;
            for (int outer = 0; outer <=upper; outer++)
            {
                min = outer;
                for (int inner = outer+1; inner <=upper; inner++)
                {
                    if (arr[inner]<arr[min])
                    {
                        min = inner;
                        total++;
                    }
                    temp = arr[outer];
                    arr[outer] = arr[min];
                    arr[min] = temp;
                    //this.DisPlayElements();
                }
            }
            Console.WriteLine($"选择排序共计交换次数:{total}");
        }

        #endregion
        #region 插入排序法
        public void InsertionSort()
        {
            int inner, temp;
            for (int outer = 1; outer <=upper; outer++)
            {
                temp = arr[outer];
                inner = outer;
                while (inner > 0 && arr[inner - 1] >= temp)
                {
                    arr[inner] = arr[inner - 1];
                    inner -= 1;
                }
                arr[inner] = temp;
                //this.DisPlayElements();
            }
        }
        //冒泡排序是从一端开始，比较大小后存到另一端。每次都是从前开始，把最大或最小的结果放到最后。
        //插入排序始终是从前面开始，把下一个元素存到前面，不用比较最大最小的结果
        public void InsertionSort2()
        {
            int temp, total = 0;
            for (int outer = 0; outer <=upper; outer++)
            {
                for (int inner = outer; inner >0; inner--)
                {
                    if (arr[inner]>arr[inner-1])
                    {
                        break;
                    }
                    else
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner - 1];
                        arr[inner - 1] = temp;
                        total++;
                    }
                }
            }
            Console.WriteLine($"第二种插入排序的交换次数是{total}");
        }

        #endregion
        #region 快速排序法
        public void QSort()
        {
            RecQSort(0, numElements - 1);
        }
        public void RecQSort(int first ,int last)
        {
            if (first >= last)
                return;
            else
            {
                int part = Partition(first, last);
                RecQSort(first, part - 1);
                RecQSort(part + 1, last);
            }
        }
        public int Partition(int first,int last)
        {
            int pivotVal = arr[first];
            int theFisrt = first;
            bool okSide;
            first++;
            do
            {
                okSide = true;
                while (okSide)
                {
                    if (arr[first] > pivotVal)
                        okSide = false;
                    else
                    {
                        first++;
                        okSide = (first <= last);
                    }
                }
                okSide = true;
                while (okSide)
                {
                    if (arr[last] <= pivotVal)
                        okSide = false;
                    else
                    {
                        last--;
                        okSide = (first <= last);
                    }
                }
                if (first < last)
                {
                    Swap(first, last);
                    //this.DisPlayElements();
                    first++;
                    last--;
                }
            } while (first <= last);
            Swap(theFisrt, last);
            //this.DisPlayElements();
            return last;
            
        }
        public void Swap(int item1,int item2)
        {
            int temp = arr[item1];
            arr[item1] = arr[item2];
            arr[item2] = temp;
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
