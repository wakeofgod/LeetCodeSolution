using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1 测试两数之和
            //int[] nums = new int[] { 2, 7, 11, 15 };
            //int target = 26;
            //int[] result = TwoSum(nums, target);
            //if (result.Length > 0)
            //{
            //    foreach (var item in result)
            //    {
            //        Console.WriteLine(item);
            //    }
            //} 
            //int[] nums = new int[] { 2, 7, 11, 15 };
            //int target = 26;
            //int[] result = TwoSum2(nums, target);
            //if (result.Length > 0)
            //{
            //    foreach (var item in result)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            #endregion
            #region 2测试单链表两数相加
            //ListNode result = AddTwoNumbers(new ListNode(2,4,3), new ListNode[5, 6, 4]);
            #endregion
            Console.ReadLine();
        }
        #region 1 两数之和
        //给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
        //你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
        //示例:
        //给定 nums = [2, 7, 11, 15], target = 9
        //因为 nums[0] + nums[1] = 2 + 7 = 9
        //所以返回[0, 1]
        //思路一:遍历两边数组，第一遍用target-nums[i]，
        //第二遍找nums数组中是否存在target-nums[i]这个数字，找到就返回两个数字组成的数组
        //这个很耗时间,复杂度O(n^2)
        public static int[]TwoSum(int []nums,int target)
        {
            int[] result=new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int v = target - nums[i];
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j]==v&&j!=i)
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }
            return result;
        }
        //思路二:哈希表存储查找,复杂度O(n+1)
        public static int[] TwoSum2(int[]nums,int target)
        {
            int[] result = new int[2];
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                map.Add(i,nums[i]);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int v = target - nums[i];
                if (map.ContainsValue(v))
                {
                    //dictionary里根据值查找键没有java里的map方便
                    int vNumber = map.First(a => a.Value == v).Key;
                    if (i!=vNumber)
                    {
                        result[0] = i;
                        result[1] = vNumber;
                        return result;
                    }
                }
            }
            return result;
        }

        #endregion
        //这道题不会
        #region 2两数相加
        //给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序的方式存储的，并且它们的每个节点只能存储 一位数字。
        //如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。
        //您可以假设除了数字 0 之外，这两个数都不会以 0 开头
        //示例
        //输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
        //输出：7 -> 0 -> 8
        //原因：342 + 465 = 807
        //定义单链表
        public class ListNode
        {
            public int val { get; set; }
            public ListNode next { get; set; }
            public ListNode(int x)
            {
                val = x;
            }
        }
        public static ListNode AddTwoNumbers(ListNode l1,ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);//新建头节点
            ListNode p = l1, q = l2, curr = dummyHead;
            int carry = 0;//进位用
            while (p!=null||q!=null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p!=null)
                {
                    p = p.next;
                }
                if (q!=null)
                {
                    q = q.next;
                }
            }
            if (carry>0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
        }
        #endregion
    }
}
