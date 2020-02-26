using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace Chapter5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 检验回文字符串
            ////类似于dad,madam向前向后拼写都完全一样的字符串
            //CStack alist = new CStack();
            //string ch;
            //string word = "sees";
            //bool isPalindrome = true;
            //for (int i = 0; i < word.Length; i++)
            //{
            //    alist.push(word.Substring(i, 1));
            //}
            //int pos = 0;
            //while (alist.count > 0)
            //{
            //    ch = alist.pop().ToString();
            //    if (ch != word.Substring(pos, 1))
            //    {
            //        isPalindrome = false;
            //        break;
            //    }
            //    pos++;
            //}
            //if(isPalindrome)
            //    Console.WriteLine($"{word} is a palindrome");
            //else
            //    Console.WriteLine($"{word} is not a palindrome");
            #endregion
            #region 栈操作运算
            Stack nums = new Stack();
            Stack ops = new Stack();
            //注意表达式中的空格
            string expression = "5 + 10 + 15 + 20";
            Calculate(nums, ops, expression);
            Console.WriteLine(nums.Pop());
   
            #endregion
            Console.Read();
        }
        public static bool IsNumeric(string input)
        {
            bool flag = true;
            string pattern = (@"^\d+$");
            Regex validate = new Regex(pattern);
            if (!validate.IsMatch(input))
            {
                flag = false;
            }
            return flag;
        }

        public static void Calculate(Stack N,Stack O,string exp)
        {
            string ch, token = "";
            for (int p = 0; p < exp.Length; p++)
            {
                ch = exp.Substring(p, 1);
                //Console.WriteLine($"当前截取的字符是:{ch}");
                if (IsNumeric(ch))
                {
                    token += ch;
                }
                if (ch == " " || p == (exp.Length - 1))
                {
                    if (IsNumeric(token))
                    {
                        N.Push(token);
                        //Console.WriteLine($"当前数字是{token}");
                        token = "";
                    }
                }
                else if (ch == "+" || ch == "-" || ch == "*" || ch == "/")
                    O.Push(ch);
                if (N.Count == 2)
                    Compute(N, O);
            }
        }

        public static void Compute(Stack N,Stack O)
        {
            int oper1, oper2;
            string oper;
            oper1 =Convert.ToInt32( N.Pop());
            oper2= Convert.ToInt32(N.Pop());
            oper= Convert.ToString(O.Pop());
            switch (oper)
            {
                case "+":
                    N.Push(oper1 + oper2);
                    break;
                case "-":
                    N.Push(oper1 - oper2);
                    break;
                case "*":
                    N.Push(oper1 * oper2);
                    break;
                case "/":
                    N.Push(oper1 / oper2);
                    break;
            }
        }
    }
    public class CStack
    {
        public int p_index;
        public ArrayList list;
        public CStack()
        {
            list = new ArrayList();
            p_index = -1;
        }
        public int count
        {
            get
            {
                return list.Count;
            }
        }
        public void push(object item)
        {
            list.Add(item);
            p_index++;
        }
        public object pop()
        {
            object obj = list[p_index];
            list.RemoveAt(p_index);
            p_index--;
            return obj;
        }
        public void clear()
        {
            list.Clear();
            p_index = -1;
        }
        public object peek()
        {
            return list[p_index];
        }
    }
}
