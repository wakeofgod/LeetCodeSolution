using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class CAarry
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
                Console.Write($"{arr[i]}");
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
                Console.WriteLine();
                Console.WriteLine($"显示第{upper-outer+1}次排序");
                this.DisPlayElements();
            }
            Console.WriteLine($"共计比较次数:{total}");
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
    }
}
