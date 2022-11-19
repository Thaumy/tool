using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;//临时变量
            string str1 = "5bcc5f3a30016c114e3b30016587660e3001548c8c10ff0c2081ea753130015e737b493001516c6b6330016cd56cbbff0c20723156fd3001656c4e1a30018bda4fe1300153cb5584";
            int len = str1.Length;
            string[,] strArray = new string[100, 100];

            for (int y = 0; y < 100; y++)//写零
            {
                for (int x = 0; x < 100; x++)
                {
                    strArray[x, y] = "!";
                }
            }

            for (int a = 1; a < len; a++)//将字符串分割成数组
            {
                i++;
                str1 = str1.Insert(a + i - 1, " ");
            }

            i = 0;//临时变量
            for (int y = 0; y < 100; y++)//数组赋值到矩阵
            {
                for (int x = 0; x < 100; x++)
                {

                    if (i < str1.Split(' ').Length)
                    {
                        strArray[x, y] = str1.Split(' ')[i];
                    }
                    Console.Write(strArray[x, y]);
                    i++;
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
