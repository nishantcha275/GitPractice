using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Class1
    {
        public void add(int a, int b)
        {
            Console.WriteLine(a+b);
        }
        public static void main(string[] args)
        {
           Class1 class1 = new Class1();
           class1.add(1,2);
        }
    }
}
