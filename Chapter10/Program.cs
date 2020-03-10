using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Chapter10
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Hash
            //string[] names = new string[99];
            //string name;
            //string[] someNames = new string[]
            //{
            //    "David","Jennifer","Donnie","Mayo","Raymond","Bernica","Mike",
            //    "Clayton","Beata","Michael"
            //};
            //int hashVal;
            //for (int i = 0; i < 10; i++)
            //{
            //    name = someNames[i];
            //    hashVal = SimpleHash(name, names);
            //    //hashVal = BetterHash(name, names);
            //    names[hashVal] = name;
            //}
            //ShowDistrib(names);
            #endregion
            #region HashTable
            Hashtable symbols = new Hashtable(25);
            symbols.Add("salary", 100000);
            symbols.Add("name", "David Durr");
            symbols.Add("age", 45);
            symbols.Add("dept", "Information Technology");
            symbols["sex"] = "Male";
            Console.WriteLine($"The keys are: ");
            foreach (var item in symbols.Keys)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"The values are: ");
            foreach (var item in symbols.Values)
            {
                Console.WriteLine($"{item}");
            }
            foreach (var item in symbols.Keys)
            {
                Console.WriteLine($"{item.ToString()}: {symbols[item].ToString()}");
            }
            #endregion
            Console.Read();
        }

        public static int SimpleHash(string s ,string[] arr)
        {
            int tot = 0;
            char[] cname;
            cname = s.ToCharArray();
            for (int i = 0; i <= cname.GetUpperBound(0); i++)
            {
                tot += (int)cname[i];
            }
            //有重复的余数
            //Console.WriteLine($"{tot}, {arr.GetUpperBound(0)}, {tot%arr.GetUpperBound(0)}");
            return tot % arr.GetUpperBound(0);
        }

        public static int BetterHash(string s,string [] arr)
        {
            long tot = 0;
            char[] cname;
            cname = s.ToCharArray();
            for (int i = 0; i <= cname.GetUpperBound(0); i++)
            {
                tot += 37 * tot +(int) cname[i];
                //Console.WriteLine($"{tot}  {i}, {tot%arr.Length}");
            }
            tot = tot % arr.GetUpperBound(0);
            if (tot < 0)
                tot += arr.GetUpperBound(0);
            return (int)tot;
        }
        public static void ShowDistrib(string[] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                if(arr[i]!=null)
                    Console.WriteLine($"{i}  {arr[i]}");
            }
        }
    }

    #region 桶式散列法
    public class BucketHash
    {
        private const int SIZE = 101;
        ArrayList[] data;
        public BucketHash()
        {
            data = new ArrayList[SIZE];
            for (int i = 0; i <=SIZE-1; i++)
            {
                data[i] = new ArrayList(4);
            }
        }
        public int Hash(string s)
        {
            long tot = 0;
            char[] charray;
            charray = s.ToCharArray();
            for (int i = 0; i < s.Length-1; i++)
            {
                tot += 37 * tot + (int)charray[i];
            }
            tot = tot % data.GetUpperBound(0);
            if (tot < 0)
                tot += data.GetUpperBound(0);
            return (int)tot;
        }
        public void Insert(string item)
        {
            int hash_value;
            hash_value = Hash(item);
            if (data[hash_value].Contains(item))
                data[hash_value].Add(item);
        }
        public void Remove(string item)
        {
            int hash_value;
            hash_value = Hash(item);
            if (!data[hash_value].Contains(item))
                data[hash_value].Remove(item);
        }
    }
    #endregion
}
