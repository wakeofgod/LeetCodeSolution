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
            #region 希尔 归并 快速排序
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
            //Console.WriteLine("开始归并排序:");
            //theArray.MergeSort();
            Console.WriteLine("开始快速排序:");
            theArray.QSort();
            #endregion

            #region 堆排序
            //const int SIZE = 9;
            //Heap aHeap = new Heap(SIZE);
            //Random random = new Random();
            //for (int i = 0; i < SIZE; i++)
            //{
            //    int rn = random.Next(1, 100);
            //    aHeap.Insert(rn);
            //}
            //Console.WriteLine("Random:");
            //aHeap.ShowArray();
            //Console.WriteLine();
            //Console.WriteLine("Heap: ");
            //for (int i =(int) SIZE/2-1; i >=0; i--)
            //{
            //    aHeap.ShiftDown(i);
            //}
            //aHeap.ShowArray();
            //for (int i = SIZE-1; i >=0; i--)
            //{
            //    Node bigNode = aHeap.Remove();
            //    aHeap.InsertAt(i, bigNode);
            //}
            //Console.WriteLine();
            //Console.WriteLine("Sorted: ");
            //aHeap.ShowArray();
            #endregion
            Console.ReadLine();
        }
    }
    public class Node
    {
        public int data;
        public Node(int key)
        {
            data = key;
        }
    }
    public class Heap
    {
        Node[] heapArray = null;
        public int maxSize = 0;
        public int currSize = 0;
        public Heap(int maxSize)
        {
            this.maxSize = maxSize;
            heapArray = new Node[maxSize];
        }
        public bool Insert(int key)
        {
            if (currSize == maxSize)
                return false;
            heapArray[currSize] = new Node(key);
            currSize++;
            return true;
        }
        public bool InsertAt(int pos,Node nd)
        {
            heapArray[pos] = nd;
            return true;
        }
        public void ShiftUp(int index)
        {
            int parent = (index - 1) / 2;
            Node bottom = heapArray[index];
            while(index>0 && heapArray[parent].data < bottom.data)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }

        public void ShiftDown(int index)
        {
            int largeChild;
            Node top = heapArray[index];
            while (index < (int)(currSize / 2))
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                if(rightChild<currSize && heapArray[leftChild].data < heapArray[rightChild].data)
                {
                    largeChild = rightChild;
                }
                else
                {
                    largeChild = leftChild;
                }
                if (top.data >= heapArray[largeChild].data)
                {
                    break;
                }
                heapArray[index] = heapArray[largeChild];
                index = largeChild;
            }
            heapArray[index] = top;
        }
        public void ShowArray()
        {
            for (int i = 0; i < maxSize; i++)
            {
                if (heapArray[i] != null)
                {
                    Console.Write($"{heapArray[i].data} ");
                }
            }
        }

        public Node Remove()
        {
            Node root = heapArray[0];
            currSize--;
            heapArray[0] = heapArray[currSize];
            ShiftDown(0);
            return root;
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
        #region 快速排序
        public void QSort()
        {
            RecQSort(0, numElements - 1);
        }
        public void RecQSort(int first,int last)
        {
            if (first >= last)
                return;
            else
            {
                int part = this.Partition(first, last);
               // Console.WriteLine($"part is {part} ");
                RecQSort(first, part - 1);
                RecQSort(part + 1, last);
            }
        }
        public int Partition(int first,int last)
        {
            //Console.WriteLine($"当前first{first} last{last} ");
            int pivotVal = arr[first];
            int theFirst = first;
            bool okSide;
            first++;
            do
            {
                okSide = true;
                while (okSide)
                {
                    if (arr[first] > pivotVal)
                    {
                        okSide = false;
                    }
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
                    {
                        okSide = false;
                    }
                    else
                    {
                        last--;
                        okSide = (first <= last);
                    }
                }
                //Console.WriteLine($"分割点数据是:{pivotVal}");
                if (first < last)
                {
                   // Console.WriteLine($"交换时first:{first} 数据:{arr[first]} last:{last} 数据:{arr[last]}");
                    Swap(first, last);
                    Console.WriteLine();
                    this.DisPlayElements();
                    first++;
                    last--;
                }
            } while (first <= last);
            Console.WriteLine();
            //Console.WriteLine($"first大于last:first{first} last:{last}");
            //Console.WriteLine($"交换分割点和末位theFirst:{theFirst} 数据:{arr[theFirst]} last:{last} 数据:{arr[last]}");
            Swap(theFirst, last);
            this.DisPlayElements();
            return last;
        }
        public void Swap(int item1,int item2)
        {
            int temp = arr[item1];
            arr[item1] = arr[item2];
            arr[item2] = temp;
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
