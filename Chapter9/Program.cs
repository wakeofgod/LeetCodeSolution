using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Chapter9
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DictionaryBase
            //IPAddress myIPs = new IPAddress();
            //myIPs.Add("Mike", "192.155.12.1");
            //myIPs.Add("David", "192.155.12.2");
            //myIPs.Add("Bernica", "192.155.12.3");
            //Console.WriteLine($"There are {myIPs.Count} IP Address");
            //Console.WriteLine($"David's IP adress :{myIPs.Item("David")}");
            //myIPs.Clear();
            //Console.WriteLine($"There are {myIPs.Count} IP Address");
            #endregion
            #region

            #endregion
            Console.Read();
        }
    }
    public class IPAddress : DictionaryBase
    {
        public IPAddress()
        {

        }
        public IPAddress(string txtFile)
        {
            string line;
            string[] words;
            StreamReader inFile;
            inFile = File.OpenText(txtFile);
            while (inFile.Peek() != -1)
            {
                line = inFile.ReadLine();
                words = line.Split(',');
                this.InnerHashtable.Add(words[0], words[1]);
            }
            inFile.Close();
        }
        public void Add(string name,string ip)
        {
            base.InnerHashtable.Add(name, ip);
        }
        public string Item(string name)
        {
            return base.InnerHashtable[name].ToString();
        }
        public void Remove(string name)
        {
            base.InnerHashtable.Remove(name);
        }
    }
}
