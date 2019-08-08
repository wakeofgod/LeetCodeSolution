using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LeetCodeSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 测试两数之和
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
        //这个很耗时间
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
        //思路二:哈希表存储查找
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
    }
}
