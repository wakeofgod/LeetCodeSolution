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
        }
    }
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
        public CSet Intersection(CSet aSet)
        {
            CSet tempSet = new CSet();
            //foreach (var item in data.Keys)
            //{
            //    if (aSet.data.Contains(item))
            //    {
            //        tempSet.Add(aSet.data[item]);
            //    }
            //    tempSet.Add(aSet.getv)
            //}
            return tempSet;
        }
    }
}
