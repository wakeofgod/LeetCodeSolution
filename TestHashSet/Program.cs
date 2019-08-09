using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace TestHashSet
{
    class Program
    {
        private const int NumberOfTestRuns = 5;
        static void Main(string[] args)
        {
            #region 1 数组赋值给hashset自动去重
            //Console.WriteLine("Using HashSet");
            ////1. Defining String Array (Note that the string "mahesh" is repeated) 
            //string[] names = new string[] {
            //    "mahesh",
            //    "vikram",
            //    "mahesh",
            //    "mayur",
            //    "suprotim",
            //    "saket",
            //    "manish"
            //};
            ////2. Length of Array and Printing array
            //Console.WriteLine("Length of Array " + names.Length);
            //Console.WriteLine();
            //Console.WriteLine("The Data in Array");
            //foreach (var n in names)
            //{
            //    Console.WriteLine(n);
            //}

            //Console.WriteLine();
            ////3. Defining HashSet by passing an Array of string to it
            //HashSet<string> hSet = new HashSet<string>(names);
            ////4. Count of Elements in HashSet
            //Console.WriteLine("Count of Data in HashSet " + hSet.Count);
            //Console.WriteLine();
            ////5. Printing Data in HashSet, this will eliminate duplication of "mahesh" 
            //Console.WriteLine("Data in HashSet");
            //foreach (var n in hSet)
            //{
            //    Console.WriteLine(n);
            //}
            #endregion

            #region 2 使用UnionWith合并两个hashset自动去重
            //string[] Names1 = new string[] {
            //    "mahesh","sabnis","manish","sharma","saket","karnik"
            //};

            //string[] Names2 = new string[] {
            //    "suprotim","agarwal","vikram","pendse","mahesh","mitkari"
            //};
            ////2.

            //HashSet<string> hSetN1 = new HashSet<string>(Names1);
            //Console.WriteLine("Data in First HashSet");
            //foreach (var n in hSetN1)
            //{
            //    Console.WriteLine(n);
            //}
            //Console.WriteLine("_______________________________________________________________");
            //HashSet<string> hSetN2 = new HashSet<string>(Names2);
            //Console.WriteLine("Data in Second HashSet");
            //foreach (var n in hSetN2)
            //{
            //    Console.WriteLine(n);
            //}
            //Console.WriteLine("________________________________________________________________");
            ////3.
            //Console.WriteLine("Data After Union");
            //hSetN1.UnionWith(hSetN2);
            //foreach (var n in hSetN1)
            //{
            //    Console.WriteLine(n);
            //}
            #endregion
            #region 3HashSet、Dictionary、Hashtable三种类型Contains效率对比

            //Stopwatch watch = null;
            //int max = 5000000;
            //int searchStart = 1555555;
            //int searchEnd = 4555555;

            ////Start******************
            //watch = Stopwatch.StartNew();
            //HashSet<string> hashSet = new HashSet<string>();
            //for (int i = 0; i < max; i++)
            //{
            //    hashSet.Add("S" + i);
            //}
            //Console.WriteLine("HashSet写入：".PadLeft(15) + watch.Elapsed);

            //watch = Stopwatch.StartNew();
            ////500万数据，检查中间的300万数据是否存在
            //for (int i = searchStart; i < searchEnd; i++)
            //{
            //    bool ss = hashSet.Contains("S" + i);
            //    if (ss == false)
            //    {
            //        Console.WriteLine("*");
            //    }
            //}
            //Console.WriteLine("HashSet查询：".PadLeft(15) + watch.Elapsed);
            ////End********************

            ////Start******************
            //watch = Stopwatch.StartNew();
            //Dictionary<string, string> dict = new Dictionary<string, string>();
            //for (int i = 0; i < max; i++)
            //{
            //    dict.Add("S" + i, null);
            //}
            //Console.WriteLine("Dictionary写入：".PadLeft(15) + watch.Elapsed);

            //watch = Stopwatch.StartNew();
            //for (int i = searchStart; i < searchEnd; i++)
            //{
            //    bool ss = dict.ContainsKey("S" + i);
            //    if (ss == false)
            //    {
            //        Console.WriteLine("*");
            //    }
            //}
            //Console.WriteLine("Dictionary查询：".PadLeft(15) + watch.Elapsed);
            ////End********************

            ////Start******************
            //watch = Stopwatch.StartNew();
            //Hashtable hashtable = new Hashtable();
            //for (int i = 0; i < max; i++)
            //{
            //    hashtable.Add("S" + i, null);
            //}
            //Console.WriteLine("Hashtable写入：".PadLeft(15) + watch.Elapsed);

            //watch = Stopwatch.StartNew();
            //for (int i = searchStart; i < searchEnd; i++)
            //{
            //    bool ss = hashtable.ContainsKey("S" + i);
            //    if (ss == false)
            //    {
            //        Console.WriteLine("*");
            //    }
            //}
            //Console.WriteLine("Hashtable查询：".PadLeft(15) + watch.Elapsed);
            ////End********************


            //Console.WriteLine("OK....");
            //Console.ReadKey();
            #endregion

            #region 4 HashSet,List,Dictionary比较
            DoTest1();

            DoTest2();

            DoTest3();

            DoTest4();

            DoTest5();

            DoTest6();
            #endregion
            Console.ReadLine();
        }
        public static void DoTest1()
        {
            var inputs = Enumerable.Range(1, 1000000).ToList();
            DoAddTest(1, "Add 1000000 value types", inputs);
        }
        public static void DoTest2()
        {
            var inputs = Enumerable.Range(1, 1000000)
                       .Select(i => new Person { Name = "TestMe", Age = i }).ToList();
            DoAddTest(2, "Add 1000000 reference types", inputs);
        }
        private static void DoTest3()
        {
            var inputs = Enumerable.Range(1, 10000).ToList();

            // look for even numbers
            var targets = inputs.Where(n => n % 2 == 0).ToList();

            DoContainsTest(3, "Run Contains() on half of 10000 value types", inputs, targets);
        }

        private static void DoTest4()
        {
            var inputs = Enumerable.Range(1, 10000)
                            .Select(i => new Person { Name = "TestMe", Age = i }).ToList();

            // look for Person with even age
            var targets = inputs.Where(p => p.Age % 2 == 0).ToList();

            DoContainsTest(4, "Run Contains() on half of 10000 reference types", inputs, targets);
        }

        private static void DoTest5()
        {
            var inputs = Enumerable.Range(1, 10000).ToList();

            // remove even numbers
            var targets = inputs.Where(n => n % 2 == 0).ToList();

            DoRemoveTest(5, "Remove half of 10000 value types", inputs, targets);
        }

        private static void DoTest6()
        {
            var inputs = Enumerable.Range(1, 10000)
                            .Select(i => new Person { Name = "TestMe", Age = i }).ToList();

            // remove Person with even age
            var targets = inputs.Where(p => p.Age % 2 == 0).ToList();

            DoRemoveTest(6, "Remove half of 10000 reference types", inputs, targets);
        }
        public static class PerfTest
        {
            public static long DoTest<TCol, TInput>(
                List<TInput>inputs,         //the inputs for the test
                Func<TCol> initCollection,   //initialize a new collection for the test
                Action<TCol,TInput>action,   //the action to perform against the input
                int numberOFRuns            //how many times do we need to repeat the test
                )where TCol:class,new()
            {
                long totalTime = 0;
                var stopWatch = new Stopwatch();
                for (int i = 0; i < numberOFRuns; i++)
                {
                    //get a new collection  for this test run
                    var collection = initCollection();
                    //start the clock and execute the test
                    stopWatch.Start();
                    inputs.ForEach(n => action(collection, n));
                    stopWatch.Stop();
                    //add to the total time
                    totalTime += stopWatch.ElapsedMilliseconds;
                    //reset the stopWatch for the next run
                    stopWatch.Reset();
                }
                var avgTime = totalTime / numberOFRuns;
                return avgTime;
            }
        }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public static void DoAddTest<T>(int testNumber,string description, List<T> inputs)
        {
            var hashSetResult = PerfTest.DoTest(inputs, () => new HashSet<T>(), (hs, i) => hs.Add(i), NumberOfTestRuns);

            var listResult = PerfTest.DoTest(inputs, () => new List<T>(), (l, i) => l.Add(i), NumberOfTestRuns);

            var dicResult = PerfTest.DoTest(inputs, () => new Dictionary<T, T>(), (dic, i) => dic.Add(i, i), NumberOfTestRuns);

            var dicResult2 = PerfTest.DoTest(inputs, () => new Dictionary<T, T>(), (dic, i) => dic[i] = i, NumberOfTestRuns);

            Console.WriteLine(@"
Test    {0} ({1}) Result:
------------------------------------------------
HashSet.Add              : {2}
            
List.Add                 : {3}
            
Dictionary.Add           : {4}
            
Dictionary[n] = n        : {5}
------------------------------------------------",
            testNumber,
            description,
            hashSetResult,
            listResult,
            dicResult,
            dicResult2
            );
        }

        private static void DoContainsTest<T>(
    int testNumber, string description, List<T> inputs, List<T> targets)
        {
            var hashsetResult = PerfTest.DoTest(
                targets, () => new HashSet<T>(inputs), (hs, t) => hs.Contains(t), NumberOfTestRuns);

            var listResult = PerfTest.DoTest(
                targets, () => new List<T>(inputs), (l, t) => l.Contains(t), NumberOfTestRuns);

            var dictResult = PerfTest.DoTest(
                targets, () => inputs.ToDictionary(i => i, i => i), (dict, t) => dict.ContainsKey(t), NumberOfTestRuns);

            var dictResult2 = PerfTest.DoTest(
                targets, () => inputs.ToDictionary(i => i, i => i), (dict, t) => dict.ContainsValue(t), NumberOfTestRuns);

            Console.WriteLine(@"
Test {0} ({1}) Result:
------------------------------------------------
HashSet.Contains            : {2}
            
List.Contains               : {3}
            
Dictionary.ContainsKey      : {4}
            
Dictionary.ContainsValue    : {5}
------------------------------------------------",
                testNumber,
                description,
                hashsetResult,
                listResult,
                dictResult,
                dictResult2);
        }

        private static void DoRemoveTest<T>(
            int testNumber, string description, List<T> inputs, List<T> targets)
        {
            var hashsetResult = PerfTest.DoTest(
                targets, () => new HashSet<T>(inputs), (hs, t) => hs.Remove(t), NumberOfTestRuns);

            var listResult = PerfTest.DoTest(
                targets, () => new List<T>(inputs), (l, t) => l.Remove(t), NumberOfTestRuns);

            var dictResult = PerfTest.DoTest(
                targets, () => inputs.ToDictionary(i => i, i => i), (dict, t) => dict.Remove(t), NumberOfTestRuns);

            Console.WriteLine(@"
Test {0} ({1}) Result:
------------------------------------------------
HashSet.Remove      : {2}
            
List.Remove         : {3}
            
Dictionary.Remove   : {4}
------------------------------------------------",
                testNumber,
                description,
                hashsetResult,
                listResult,
                dictResult);
        }

    }
}
