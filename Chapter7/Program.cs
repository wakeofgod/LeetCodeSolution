using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace Chapter7
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 自定义的分割字符串方法
            //string astring = "now is the time for all good people ";
            //ArrayList words = new ArrayList();
            //words = SplitWords(astring);
            //foreach (var item in words)
            //{
            //    Console.Write($"{item} ");
            //}
            #endregion
            #region Split and Join
            //string data = "Mike ,McMillan,3000 w.Scenic,North Little Rock,AR,72118";
            //string[] sdata;
            //char[] delimeter = new char[] { ',' };
            ////传入分隔符数组,只有一个字节
            ////sdata = data.Split(delimeter, data.Length);
            ////传入单个字节
            //sdata = data.Split(',');
            //foreach (var item in sdata)
            //{
            //    Console.Write($"{item }");
            //}
            //Console.WriteLine();
            //string joined;
            //joined = string.Join(",", sdata);
            //Console.WriteLine($"{joined}");
            #endregion
            #region 比较字符串
            //111111111
            //Equals ,Compare To,Compare
            //string s1 = "foobar";
            //string s2 = "foobar";
            //if(s1.Equals(s2))
            //    Console.WriteLine($"They are the same");
            //else
            //    Console.WriteLine($"They are not the same");
            //222222222
            //string s1 = "foobar";
            //string s2 = "foobar";
            ////returns 0 两个字符串相等
            //Console.WriteLine(s1.CompareTo(s2));
            //s2 = "foofoo";
            ////returns -1 传入的字符串低于调用方法的字符串
            //Console.WriteLine(s1.CompareTo(s2));
            //s2 = "fooaar";
            ////returns 1 传入的字符串高于调用方法的字符串
            //Console.WriteLine(s1.CompareTo(s2));
            //3333333333
            //string s1 = "foobar";
            //string s2 = "foobar";
            //int compVal = String.Compare(s1, s2);
            //switch (compVal)
            //{
            //    case 0:
            //        Console.WriteLine($"{s1} {s2} are equal");
            //        break;
            //    case 1:
            //        Console.WriteLine($"{s1} is less than {s2}");
            //        break;
            //    case 2:
            //        Console.WriteLine($"{s1} is greater than {s2}");
            //        break;
            //    default:
            //        Console.WriteLine($"Cant compare");
            //        break;
            //}
            #endregion
            #region StartWith  and EndWith
            //string[] nouns = new string[] { "cat", "dog", "bird", "eggs", "bones" };
            //ArrayList pluralNous = new ArrayList();
            //foreach (string noun in nouns)
            //{
            //    if (noun.EndsWith("s"))
            //        pluralNous.Add(noun);
            //}
            //foreach (var item in pluralNous)
            //{
            //    Console.WriteLine($"{item}");
            //}
            #endregion
            #region Insert Remove Replace PadLeft PadRight Concat ToLower ToUpper Trim TrimEnd
            //string s1 = "Hello, .Welcome to my class";
            //string name = "Clayton";
            //int pos = s1.IndexOf(",");
            ////在指定的位置插入另一个字符串
            //s1 = s1.Insert(pos + 2, name);
            //Console.WriteLine(s1);
            ////从指定的位置删除指定长度
            //s1 = s1.Remove(pos + 2, name.Length);
            //Console.WriteLine(s1);
            //string s1 = "Hello";
            //string s2 = "world";
            //string s3 = "Goodbye";
            ////在字符串左侧填充空格
            //Console.Write($"{s1.PadLeft(10)}");
            //Console.WriteLine($"{s2.PadLeft(10)}");
            //Console.Write($"{s3.PadLeft(10)}");
            //Console.WriteLine($"{s2.PadLeft(10)}");
            //string s1 = "hello";
            //string s2 = "world";
            //string s3 = "";
            //s3 = String.Concat(s1, " ", s2);
            //Console.WriteLine($"{s3}");
            //string[] names = new string[] { " David", " Raymond", "Mike ", "Bernica " };
            //Console.WriteLine();
            //foreach (var item in names)
            //{
            //    Console.Write($"{item}");
            //}
            //char[] charArr = new char[] { ' ' };
            //for (int i = 0; i <names.Length; i++)
            //{
            //    //有了trim就没必要使用trimend
            //    //从string对象中移除数组中指定的一组字符的前导匹配项和尾部匹配项
            //    names[i] = names[i].Trim(charArr[0]);
            //    //从string对象中移除数组中指定的一组字符的尾部匹配项
            //    names[i] = names[i].TrimEnd(charArr[0]);
            //}
            //Console.WriteLine();
            //foreach (var item in names)
            //{
            //    Console.Write($"{item}");
            //}
            #endregion
            #region String和StringBuilder性能比较
            int size = 100;
            Timing timeSB = new Timing();
            Timing timeST = new Timing();
            Console.WriteLine();
            for (int i = 0; i <=3; i++)
            {
                timeSB.StartTime();
                BuildSB(size);
                timeSB.StopTime();
                timeST.StartTime();
                BuildString(size);
                timeST.StopTime();
                Console.WriteLine($"Time (in millseconds) to build StringBuilder" +
                    $"object for {size} elements: {timeSB.Result().TotalMilliseconds}");
                Console.WriteLine($"Time (in millseconds) to build String objec" +
                    $"object for {size} elements: {timeST.Result().TotalMilliseconds}");
                Console.WriteLine();
                size *= 10;
            }
            #endregion
            Console.Read();
        }
        public static ArrayList SplitWords(string astring)
        {
            string[] ws = new string[astring.Length - 1];
            ArrayList words = new ArrayList();
            int pos;
            string word;
            pos = astring.IndexOf(" ");
            while (pos > 0)
            {
                word = astring.Substring(0, pos);
                words.Add(word);
                astring = astring.Substring(pos + 1, astring.Length - pos - 1);
                if (pos == -1)
                {
                    word = astring.Substring(0, astring.Length);
                    words.Add(word);
                }
                pos = astring.IndexOf(" ");
            }
            return words;
        }

        public static void BuildSB(int size)
        {
            StringBuilder sbObject = new StringBuilder();
            for (int i = 0; i <= size; i++)
            {
                sbObject.Append("a");
            }
        }
        public static void BuildString(int size)
        {
            string stringObject = "";
            for (int i = 0; i < size; i++)
            {
                stringObject += "a";
            }
        }
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
