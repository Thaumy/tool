using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace DataXL查询器
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ArcaneinterstellarStudios...Loading");

            String path = @"DataXL\表征库";
            String temp;

            while (true)
            {
                Console.WriteLine("输入你要查询的关键字:");

                var files = Directory.GetFiles(path, "*.txt");

                temp = Console.ReadLine();

                foreach (string file in files)
                {
                    if (file.Contains(temp) == true)
                    {
                        Console.WriteLine(file);
                    }
                }
                
            }
        }
    }
}
