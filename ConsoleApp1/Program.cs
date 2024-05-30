using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> dic = new Dictionary<string,string>();
            dic.Add("A", "Apple");
            dic.Add("B", "Boy");
            dic.Add("C", "Cat");
            dic.Add("D", "Dog");
            dic.Add("E", "Elephant");
            foreach(KeyValuePair<string,string> item in dic) 
            {
                Console.WriteLine("key is: " + item.Key+ "\t" + "value is: "+ item.Value);
            }
            Console.ReadLine();
        }
    }
}
