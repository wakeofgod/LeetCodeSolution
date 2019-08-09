using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            //GreetPeople("Jimmy Zhang", EnglishGreeting);
            //GreetPeople("张子阳", ChineseGreeting);
            #endregion
            #region 委托的简单调用
            //DoubleOp[] operations =
            //{
            //    MathOperations.MultiplyByTwo,
            //    MathOperations.Square
            //};
            //for (int i = 0; i < operations.Length; i++)
            //{
            //    Console.WriteLine($"using operations[{i}]:");
            //    ProcessAndDisplayNumber(operations[i], 2.0);
            //    ProcessAndDisplayNumber(operations[i], 7.94);
            //    ProcessAndDisplayNumber(operations[i], 1.414);
            //    Console.WriteLine();
            //}
            #endregion

            #region Func<T>委托
            Employee[] employees =
           {
                new Employee("Bugs Bunny",20000),
                new Employee("Elmer Fudd",10000),
                new Employee("Daffy Duck",25000),
                new Employee("Wile Coyote",1000000.38m),
                new Employee("Foghorn Leghorn",23000),
                new Employee("RoadRunner",50000)
            };
            BubbleSorter.Sort(employees, Employee.CompareSalary);
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
            #endregion
            Console.ReadKey();
        }
        #region 1
        private static void EnglishGreeting(string name)
        {
            Console.WriteLine($"Morning,{name}");
        }
        private static void ChineseGreeting(string name)
        {
            Console.WriteLine($"早上好,{name}");
        }
        private static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }
        public delegate void GreetingDelegate(string name);
        #endregion

        #region 2 
        public static void ProcessAndDisplayNumber(DoubleOp action, double value)
        {
            double result = action(value);
            Console.WriteLine($"Value is {value},result of operatioin is {result}");
        }
        public delegate double DoubleOp(double x);
        public class MathOperations
        {
            public static double MultiplyByTwo(double value) => value * 2;
            public static double Square(double value) => value * value;
        }
        #endregion
        #region 3
        public class BubbleSorter
        {
            public static void Sort<T>(IList<T> sortArray, Func<T, T, bool> comparison)
            {
                int totalCount = 0;
                bool swapped = true;
                do
                {
                    swapped = false;
                    for (int i = 0; i < sortArray.Count - 1; i++)
                    {
                        totalCount++;
                        if (comparison(sortArray[i + 1], sortArray[i]))
                        {
                            T temp = sortArray[i];
                            sortArray[i] = sortArray[i + 1];
                            sortArray[i + 1] = temp;
                            swapped = true;
                        }
                    }
                } while (swapped);
                Console.WriteLine($"循环次数:{totalCount}");
            }
        }
        public class Employee
        {
            public string Name { get; set; }
            public decimal Salary { get; set; }
            public Employee(string name, decimal salary)
            {
                Name = name;
                Salary = salary;
            }
            public override string ToString() => $"{Name},{Salary:C}";
            public static bool CompareSalary(Employee e1, Employee e2) => e1.Salary < e2.Salary;

        }
        #endregion
    }

}
