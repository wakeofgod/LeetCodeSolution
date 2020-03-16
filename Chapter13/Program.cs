using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Chapter13
{
    class Program
    {
        static void Main(string[] args)
        {
            CSet setA = new CSet();
            CSet setB = new CSet();
            setA.Add("milk");
            setA.Add("eggs");
            setA.Add("bacon");
            setA.Add("cereal");
            setB.Add("bacon");
            setB.Add("eggs");
            setB.Add("bread");
            CSet setC = new CSet();
            setC = setA.Union(setB);
            Console.WriteLine();
            Console.WriteLine($"A: {setA.ToString()}");
            Console.WriteLine($"B: {setB.ToString()}");
            Console.WriteLine($"A union B: {setC.ToString()}");
            setC = setA.Intersection(setB);
            Console.WriteLine($"A intersect B: {setC.ToString()}");
            setC = setA.Difference(setB);
            Console.WriteLine($"A difference B: {setC.ToString()}");
            setC = setB.Difference(setA);
            Console.WriteLine($"B difference A: {setC.ToString()}");
            if (setB.Subset(setA))
            {
                Console.WriteLine(" b is a subset of a");
            }
            else
            {
                Console.WriteLine(" b is not a subset of a");
            }
            Console.ReadLine();
        }
    }
    #region 用散列表的Set类实现
    public class CSet
    {
        public Hashtable data;
        public CSet()
        {
            data = new Hashtable();
        }
        public void Add(Object item)
        {
            if (!data.ContainsValue(item))
                data.Add(Hash(item), item);
        }
        public string Hash(Object item)
        {
            char[] chars;
            string s = item.ToString();
            int hashValue = 0;
            chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                hashValue +=(int)chars[i];
            }
            return hashValue.ToString();
        }


        public void Remove(Object item)
        {
            data.Remove(Hash(item));
        }
        public int Size()
        {
            return data.Count;
        }
        //并集
        public CSet Union(CSet aset)
        {
            CSet tempSet = new CSet();
            foreach (var item in data.Keys)
            {
                tempSet.Add(this.data[item]);
            }
            foreach (var item in aset.data.Keys)
            {
                if (!this.data.ContainsKey(item))
                    tempSet.Add(aset.data[item]);
            }
            return tempSet;
        }
        //交集
        public CSet Intersection(CSet aSet)
        {
            CSet tempSet = new CSet();
            foreach (var item in data.Keys)
            {
                if (aSet.data.Contains(item))
                {
                    tempSet.Add(aSet.data[item]);
                }
            }
            return tempSet;
        }
        //子集
        public bool Subset(CSet aSet)
        {
            if (this.Size() > aSet.Size())
                return false;
            else
            {
                foreach (var item in this.data.Keys)
                {
                    if (!aSet.data.Contains(item))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //差集
        public CSet Difference(CSet aSet)
        {
            CSet tempSet = new CSet();
            foreach (var item in data.Keys)
            {
                if (!aSet.data.Contains(item))
                    tempSet.Add(data[item]);
            }
            return tempSet;
        }
        public override string ToString()
        {
            string s = "";
            foreach (var item in data.Keys)
            {
                s += data[item] + " ";
            }
            return s;
        }
    }
    #endregion
    #region BitArray实现

    #endregion
}
