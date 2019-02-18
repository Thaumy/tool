using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
         {
            int[] a = { 11, 45, 35, 8, 65, 45, 1, 348, 648, 659, 123, 58465, 124, 015, 234, 31, 02, 34, 6, 578, 2643, 25476, 5789, 435, 234, 59, 435, 7980, 435, 234, 798, 12 };
            
            for (int path = 0; path < a.Length; path++)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (i + 1 < a.Length)
                    {


                        int tmp = 0;
                        if (a[i] > a[i + 1])
                        {

                            tmp = a[i];
                            a[i] = a[i + 1];
                            a[i + 1] = tmp;
                            
                        }
                    }

                }
            }
            foreach(int p in a)
            {
                Console.Write(p+",");
            }
            Console.ReadKey();
        }
    }
}
